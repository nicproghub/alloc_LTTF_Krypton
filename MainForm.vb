Imports System.ComponentModel
Imports System.Data.OleDb
Imports System.IO
Imports System.Net
Imports DevExpress
Imports DevExpress.XtraEditors
Imports System.Threading
Imports System.Text.RegularExpressions
Imports System.Web
Imports DevExpress.XtraGrid.Views.Base

NotInheritable Class MainForm
	Private m_WWCaption As String = "Working"
	Private m_WWDescription As String = "working, please wait…"
	Public Property SuppressCloseWarning As Boolean = False
	Private Const save_pdf As String = "PDF File|*.pdf"
	Private Const save_xls As String = "Excel File|*.xlsx"
	Private Const save_csv As String = "CSV File|*.csv"
	Private Const save_html As String = "HTML File|*.html"

	Private Const JOB_FAILED As String = "Job failed with following error:" & vbCrLf

	Dim t_start As DateTime = DateTime.Now

	Private src_dir As String = "D:\Test\"

	'Private accountSize As Decimal = 5000000
	'Private mmFactor As Decimal = 0.002
	'Private slen As Int32 = 10 ' B2
	'Private llen As Int32 = 90 ' B3
	'Private lbp As Decimal = 200 ' C10
	'Private sbp As Decimal = 1350 ' D10
	'Private rar10_5 As Int32 = 100 ' E10

	Private next_id As Int32 = 0

	Private Sub ____Form_Load(sender As Object, e As EventArgs) Handles Me.Load
		If Not Me.DesignMode Then
			oNav.SelectedPageIndex = 0
			Try
				If File.Exists("last_dir.txt") Then
					src_dir = File.ReadAllText("last_dir.txt")
				End If
			Catch ex As Exception

			End Try

			oFolderLoc.Caption = src_dir
			refreshColumnNames()
		End If


	End Sub

	Private Sub refreshColumnNames()
		Using cn As New MsAccess
			Try
				Dim dt As New DataTable
				cn.Open()
				'system config - c1 = name, c2 = value, eg look back length
				'use c1 as PK, 
				With cn.NewCommand("select c1,c2 from [Options]")
					dt.Load(.ExecuteReader())
				End With
				dt.Constraints.Add("pk", dt.Columns("c1"), True)
				'get the name of RAR sheet based on RAR lookback 
				' vbCrLf = line break, dt.Rows.Find("RAR1")("c2") =look for c1 for "RAR1", then get c2 value for this Caption 
				colF3.Caption = "RAR " & vbCrLf & dt.Rows.Find("RAR1")("c2")
				colF4.Caption = "RAR " & vbCrLf & dt.Rows.Find("RAR2")("c2")
				'colF5.Caption = "$ ATR[x]" & vbCrLf & dt.Rows.Find("ATR")("c2")
			Catch ex As Exception
			End Try
		End Using
	End Sub

#Region " wait form "
	'' wait form
	Protected Delegate Sub del_WWSetCaption(tCaption As String)
	Protected m_WWSetCaption As New del_WWSetCaption(AddressOf WWSetCaption)
	Protected Sub WWSetCaption(tCaption As String)
		m_WWCaption = tCaption
		WWRefresh()
	End Sub

	Protected Delegate Sub del_WWSetDescription(tDescription As String)
	Protected m_WWSetDescription As New del_WWSetDescription(AddressOf WWSetDescription)
	Protected Sub WWSetDescription(tDescription As String)
		m_WWDescription = tDescription
		WWRefresh()
	End Sub

	Private Sub WWRefresh()
		If Not ssm.IsSplashFormVisible Then Exit Sub
		ssm.SetWaitFormCaption(m_WWCaption)
		ssm.SetWaitFormDescription(m_WWDescription)
	End Sub

	Protected Delegate Sub del_WWShow()
	Protected Delegate Sub del_WWHide()
	Protected m_WWShow As New del_WWShow(AddressOf WWShow)
	Protected m_WWHide As New del_WWHide(AddressOf WWHide)

	Protected Sub WWShow()
		If Not ssm.IsSplashFormVisible Then ssm.ShowWaitForm()
		ssm.SetWaitFormCaption(m_WWCaption)
		ssm.SetWaitFormDescription(m_WWDescription)
	End Sub
	Protected Sub WWShow_Saving()
		If Not ssm.IsSplashFormVisible Then ssm.ShowWaitForm()
		ssm.SetWaitFormCaption("Saving Data")
		ssm.SetWaitFormDescription("saving data, please wait…")
	End Sub
	Protected Sub WWShow_Refreshing()
		If Not ssm.IsSplashFormVisible Then ssm.ShowWaitForm()
		ssm.SetWaitFormCaption("Refreshing Data")
		ssm.SetWaitFormDescription("fetching data, please wait…")
	End Sub
	Protected Sub WWShow(tDescription As String)
		If Not ssm.IsSplashFormVisible Then ssm.ShowWaitForm()
		ssm.SetWaitFormCaption(m_WWCaption)
		ssm.SetWaitFormDescription(tDescription)
	End Sub
	Protected Sub WWShow(tCaption As String, tDescription As String)
		If Not ssm.IsSplashFormVisible Then ssm.ShowWaitForm()
		m_WWCaption = tCaption
		m_WWDescription = tDescription
		ssm.SetWaitFormCaption(tCaption)
		ssm.SetWaitFormDescription(tDescription)
	End Sub

	Protected Sub WWHide()
		If ssm.IsSplashFormVisible Then ssm.CloseWaitForm()
	End Sub
#End Region

	Private Sub _bwRefresh_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bwRefresh.DoWork
		Dim em As String = ""
		Using cn As New MsAccess
			Try
				cn.Open()
				For Each t As DataTable In ds.Tables
					t.BeginLoadData()
					t.Clear()
				Next

				With cn.NewCommand("select * from rar")
					ds.RAR.Load(.ExecuteReader())
				End With

				With cn.NewCommand("select * from MktSpec")
					ds.MktSpec.Load(.ExecuteReader())
				End With
				With cn.NewCommand("select * from IndexMundi")
					ds.IndexMundi.Load(.ExecuteReader())
				End With
				With cn.NewCommand("select * from ExchangeRate")
					ds.ExchangeRate.Load(.ExecuteReader())
				End With

				With cn.NewCommand("select * from Options")
					ds.Options.Load(.ExecuteReader())
				End With

			Catch ex As Exception
				em = ex.Message
			Finally
				For Each t As DataTable In ds.Tables
					t.AcceptChanges()
					t.EndLoadData()
				Next
				e.Result = {em}
			End Try

		End Using

	End Sub

	Private Sub _oRefreshAllButton_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles oRefreshAllButton.ItemClick
		gvr.BeginDataUpdate()
		'gvs.BeginDataUpdate() ' risk data
		gvm.BeginDataUpdate()
		gvi.BeginDataUpdate()
		gve.BeginDataUpdate()
		'gvt.BeginDataUpdate() ' sector data
		gvo.BeginDataUpdate()
		oRefreshAllButton.Enabled = False

		bwRefresh.RunWorkerAsync()
	End Sub

	Private Sub bwRefresh_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bwRefresh.RunWorkerCompleted
		Dim em As String = e.Result(0)
		gvr.EndDataUpdate()
		'gvs.EndDataUpdate()
		gvm.EndDataUpdate()
		gvi.EndDataUpdate()
		gve.EndDataUpdate()
		'gvt.EndDataUpdate()
		gvo.EndDataUpdate()
		oRefreshAllButton.Enabled = True

		If em.Equals("") Then
			refreshColumnNames()

		Else
			XtraMessageBox.Show(JOB_FAILED & em, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
		End If
	End Sub

	Private Delegate Sub d_writeStatus(f As String, t As String)
	Private writeStatus As New d_writeStatus(AddressOf _writeStatus)
	Private Sub _writeStatus(f As String, t As String)
		Dim x As TimeSpan = DateTime.Now.Subtract(t_start)
		oStatus.Caption = x.Hours.ToString().PadLeft(2, "0") &
			":" & x.Minutes.ToString().PadLeft(2, "0") & ":" &
			x.Seconds.ToString().PadLeft(2, "0") & " -> " & f & ", " & t
	End Sub

	Private Sub _bsCalc_DoWork(sender As Object, e As DoWorkEventArgs) Handles bwCalc.DoWork
		Dim em As String = ""
		Dim mci As Boolean = e.Argument(0)

		Using cn As New MsAccess
			Try
				'Dict in memory, delete when app closed
				Dim lstFile As New Dictionary(Of String, ods.DataDataTable)

				Me.Invoke(writeStatus, "Loading CSVs", "please wait…")

				For Each _f As String In Directory.GetFiles(src_dir, "*.prn", SearchOption.TopDirectoryOnly)
					lstFile.Add(Path.GetFileName(_f).ToLower(), New ods.DataDataTable)
				Next

				Tasks.Parallel.ForEach(
					Directory.GetFiles(src_dir, "*.prn", SearchOption.TopDirectoryOnly),
					Sub(cf)
						Me.Invoke(writeStatus, "Loading CSVs", Path.GetFileName(cf) & ", please wait…")
						Dim _n As Int32 = 0
						Dim s As String() = Nothing
						_n = 0

						Using csv As New FileIO.TextFieldParser(cf) With {
						.Delimiters = {","},
						.TextFieldType = FileIO.FieldType.Delimited,
						.TrimWhiteSpace = True}

							While csv.LineNumber > 0
								Dim _mktr As ods.DataRow = lstFile(Path.GetFileName(cf).ToLower()).NewRow()
								_n += 1

								_mktr.rn = _n

								s = csv.ReadFields()
								If _n = 1 Then
									Try
										Dim u As ods.DataRow = lstFile(Path.GetFileName(cf).ToLower()).NewRow()
										u.c1 = s(0)
									Catch ex As Exception
										lstFile(Path.GetFileName(cf).ToLower()).Rows.Add(_mktr)
										Continue While
									End Try
								End If

								For i As Int32 = 1 To 7 Step 1
									_mktr("c" & i) = s(i - 1)
								Next

								lstFile(Path.GetFileName(cf).ToLower()).Rows.Add(_mktr)
							End While
						End Using
					End Sub)

				Dim x As New ods
				Dim fileName As String = ""
				Dim mktName As String = ""
				Dim rRar As ods.RARRow = Nothing
				Dim rmkt0 As ods.MktSpecRow = Nothing
				Dim rmkt1 As ods.MktSpecRow = Nothing
				'initialize temp data table for each loop
				Dim r0 As ods.DataRow = Nothing
				Dim r1 As ods.DataRow = Nothing

				Dim fileNo As Int32 = 0
				Dim maxRecord As Int32 = 0
				Dim ocol As Int32 = 0
				Dim val As Decimal = 0
				Dim mkt1atr(500) As Integer
				Dim mkt1pc(500) As Decimal
				Dim mkt2atr(500) As Integer
				Dim mkt2pc(500) As Decimal
				Dim mkt1dt(500) As Long
				Dim mkt2dt(500) As Long
				Dim r As Decimal = 0
				Dim sd As Decimal = 0
				Dim numd1 As Decimal = 0
				Dim numd2 As Decimal = 0

				Dim mins As Double = 0
				Dim maxs As Double = 0
				Dim minl As Double = 0
				Dim maxl As Double = 0
				Dim cl As Double = 0
				Dim mktRn As Int32 = 0

				Dim bmktcmi As Double = 0
				Dim smktcmi As Double = 0
				Dim tmpData As ods.DataDataTable = Nothing

				cn.Open()

				x.Options.Load(cn.NewCommand("select * from options").ExecuteReader())

				' get the system seeting
				With cn.NewCommand("select c1,c2 from [Options]")
					x.Options.Load(.ExecuteReader())
				End With
				'x.Options.Constraints.Add("pk", x.Options.Columns("rn"), True)

				Dim accountSize As Decimal = x.Options.Rows.Find(3)("c2")
				Dim mmFactor As Decimal = x.Options.Rows.Find(4)("c2")
				Dim slen As Int32 = x.Options.Rows.Find(1)("c2") ' B2
				'long look back for entry
				Dim llen As Int32 = x.Options.Rows.Find(2)("c2") ' B3
				'short rar look back
				Dim lbp As Decimal = x.Options.Rows.Find(5)("c2") ' C10
				Dim sbp As Decimal = x.Options.Rows.Find(6)("c2") ' D10
				Dim rar10_5 As Int32 = x.Options.Rows.Find(7)("c2") ' E10



				Dim cmMktUpdate As OleDbCommand = cn.NewCommand("update MktSpec set C22=?,C23=? where rn=?")
				With cmMktUpdate.Parameters
					.Add("@c22", OleDbType.Double)
					.Add("@c23", OleDbType.Double)
					.Add("@rn", OleDbType.Integer)
				End With
				cmMktUpdate.Prepare()

				x.MktSpec.Load(cn.NewCommand("select * from MktSpec").ExecuteReader())
				fileNo = 0
				rmkt0 = Nothing
				'loop each file in the directory to calculate info for RAR page
				'read one file, do calculation, put in a row in RAR page (there will be another loop inside)
				For Each f As String In Directory.GetFiles(src_dir, "*.prn", SearchOption.TopDirectoryOnly)
					Me.Invoke(writeStatus, f, "Calculating, please wait…")
					fileNo += 1
					fileName = Path.GetFileName(f)
					mktName = fileName.Substring(0, 2)

					For Each tmp As ods.MktSpecRow In x.MktSpec.Rows
						'once find match exit for loop
						If Len(tmp.c1) = 3 AndAlso tmp.c1.Substring(0, 3).Equals(fileName.Substring(0, 3)) Then
							mktName = fileName.Substring(0, 3)
							rmkt0 = tmp
							Exit For
						ElseIf Len(tmp.c1) = 2 AndAlso tmp.c1.Substring(0, 2).Equals(fileName.Substring(0, 2)) Then
							mktName = fileName.Substring(0, 2)
							rmkt0 = tmp
							Exit For
						End If
					Next
					rRar = x.RAR.NewRow()
					rRar.rn = fileNo
					rRar.F1 = fileName
					rRar.F2 = ""
					If rmkt0 Is Nothing Then
						x.RAR.Rows.Add(rRar)
						XtraMessageBox.Show("Cannot find contract specification for " & fileName & ".", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
						Continue For
					End If
					bmktcmi = rmkt0.c22
					smktcmi = rmkt0.c23

					'rmkt0._slip = rmkt0.c9 / 2 * rmkt0.c5

					' if not traderble, skip for next market
					If rmkt0.c18.ToLower() = "no" Then Continue For

					' F2 and c2 = Market Name
					rRar.F2 = rmkt0.c2

					numd1 = 0
					numd2 = 0

					'load the data to temp
					tmpData = lstFile(fileName.ToLower())
					ocol = tmpData.Rows.Count
					maxRecord = ocol
					'''''''''''''''''''''''''''''''''
					'''
					'''''''calculate LTTF P&L '''''''
					'''
					'''''''''''''''''''''''''''''''''
					' index start 0 and only update maxrecord - 1
					If ocol > llen + 2 Then

						For ocol = slen + 1 To maxRecord Step 1
							'r0 = single row of price data for cal
							r0 = tmpData.Rows(ocol - 1)
							'r1 = previous row's price data for cal
							r1 = tmpData.Rows(ocol - 2)

							'{0} -> ocol-slen + 1, {1} -> ocol
							r0.c9 = tmpData.Compute("min(c4)", String.Format("rn >= {0} and rn <= {1}", ocol - slen + 1, ocol)) - rmkt0.c5
							r0.c11 = tmpData.Compute("max(c3)", String.Format("rn >= {0} and rn <= {1}", ocol - slen + 1, ocol)) + rmkt0.c5


							If ocol >= llen + 1 Then
								r0.c10 = tmpData.Compute("min(c4)", String.Format("rn >= {0} and rn <= {1}", ocol - llen + 1, ocol)) - rmkt0.c5
								r0.c8 = tmpData.Compute("max(c3)", String.Format("rn >= {0} and rn <= {1}", ocol - llen + 1, ocol)) + rmkt0.c5
								If ocol = llen + 1 Then r0.c15 = 0 ' initial p&l

								If ocol >= llen + 2 Then

									If r1.c12 = 0 Then
										If r0.c3 <> r0.c4 Then
											If (r0.c3 >= r1.c8) AndAlso (r0.c4 > r1.c10) Then
												r0.c12 = If(r0.c2 >= r1.c8, -r0.c2, -r1.c8)

											ElseIf (r0.c4 <= r1.c10) AndAlso (r0.c3 < r1.c8) Then
												r0.c12 = If(r0.c2 <= r1.c10, r0.c2, r1.c10)

											ElseIf (r0.c3 >= r1.c8) AndAlso (r0.c4 <= r1.c10) Then
												If r0.c2 >= r0.c5 Then
													r0.c13 = If(r0.c2 >= r1.c8, -r0.c2 + r0.c9, -r1.c8 + r0.c9)
													r0.c12 = r1.c10
												Else
													r0.c13 = If(r0.c2 <= r1.c10, r0.c2 - r0.c11, r1.c10 - r0.c11)
													r0.c12 = r1.c8
												End If
											End If
										End If

									ElseIf r1.c12 < 0 Then
										If r0.c3 <> r0.c4 Then
											If (r0.c4 <= r1.c10) AndAlso (r0.c4 <= r1.c9) Then
												r0.c13 = -r1.c5 + If(r0.c2 <= r1.c9, r0.c2, r1.c9)
												r0.c12 = If(r0.c2 <= r1.c10, r0.c2, r1.c10)

											ElseIf (r0.c4 <= r1.c9) AndAlso (r0.c4 > r1.c10) Then
												r0.c13 = -r1.c5 + If(r0.c2 <= r1.c9, r0.c2, r1.c9)

											Else
												r0.c12 = r1.c12
											End If
										Else
											r0.c12 = r1.c12
										End If

									ElseIf r1.c12 > 0 Then
										If r0.c3 <> r0.c4 Then
											If r0.c3 >= r1.c8 AndAlso r0.c3 >= r1.c11 Then
												r0.c13 = r1.c5 - If(r0.c2 >= r1.c11, r0.c2, r1.c11)
												r0.c12 = If(r0.c2 >= r1.c8, -r0.c2, -r1.c8)

											ElseIf r0.c3 >= r1.c11 AndAlso r0.c3 < r1.c8 Then
												r0.c13 = r1.c5 - If(r0.c2 >= r1.c11, r0.c2, r1.c11)

											Else
												r0.c12 = r1.c12
											End If
										Else
											r0.c12 = r1.c12
										End If
									End If

									' profit and loss
									If (r0.c12 = 0) AndAlso (r0.c13 = 0) Then
										r0.c14 = 0

									ElseIf (r0.c12 = 0) AndAlso (r0.c13 <> 0) Then
										' close trade
										r0.c14 = (r0.c13) * rmkt0.c4

									ElseIf r0.c12 < 0 Then
										If r0.c12 <> r1.c12 Then
											'first date in the trade
											If r0.c13 = 0 Then
												r0.c14 = (r0.c12 + r0.c5) * rmkt0.c4
											Else
												r0.c14 = (r0.c12 + r0.c5 + r0.c13) * rmkt0.c4
											End If
										Else
											r0.c14 = (r0.c5 - r1.c5) * rmkt0.c4
										End If

									ElseIf r0.c12 > 0 Then
										If r0.c12 <> r1.c12 Then
											'first date in the trade
											If r0.c13 = 0 Then
												r0.c14 = (r0.c12 - r0.c5) * rmkt0.c4
											Else
												r0.c14 = (r0.c12 - r0.c5 + r0.c13) * rmkt0.c4
											End If
										Else
											r0.c14 = (-r0.c5 + r1.c5) * rmkt0.c4
										End If
									End If
								End If

								r0.c15 = r1.c15 + r0.c14
							End If
						Next
					End If
					''''''end of reading the price data 
					'''after loop, ocol = # of data +1 ???
					'e.Window.Message = String.Format(Path.GetFileName(f) & vbCrLf & "Performing additional calculation" & vbCrLf & vbCrLf & "Please wait…", ocol, maxRecord)
					Me.Invoke(writeStatus, f, "Performing additional calculation, please wait…")

					'''''''''''''''''''''''''''''''''
					'''
					'''''''calculate ATR[x] '''''''
					'''
					'''''''''''''''''''''''''''''''''
					Dim loop_var As Int32 = 0
					Dim ATR_VAR As Int32 = 0
					'Calculate ATR[x]
					If mci Then 'always true
						loop_var = If(410 > ocol - 2, ocol - 2, 410)
						ATR_VAR = If(rar10_5 < 1, 1, rar10_5)
					Else
						ATR_VAR = 1
						loop_var = 1
					End If

					For z As Int32 = 1 To loop_var Step 1
						'today's row alwas always use previous data's data
						r0 = tmpData.Rows(ocol - z - 1)
						r1 = tmpData.Rows(ocol - z - 1 - 1)

						r0.c17 = If(r0.c3 >= r1.c5, r0.c3, r1.c5)
						r0.c18 = If(r0.c4 <= r1.c5, r0.c4, r1.c5)
						r0.c19 = r0.c17 - r0.c18
					Next

					'ATR with ATR_VAR look back length for current date ocol
					'r0 = tmpData.Rows(ocol - 1 - 1)
					' ATR[x], x = rar10_5
					r0.c20 = tmpData.Compute("avg(c19)", String.Format("rn <= {0} and rn >= {1}", ocol - 1, ocol - ATR_VAR))
					'$ATR[x]
					rRar.F5 = r0.c20 * rmkt0.c4

					'''''''''''''''''''''''''''''''''
					'''
					'''''''calculate mkt1 CMI '''''''
					'''
					'''''''''''''''''''''''''''''''''
					' store mkt1atr & mkt1pc value in an 300 array
					Dim cmi_lb As Int32 = 0
					cmi_lb = If(300 > ocol - 3, ocol - 3, 300)

					For z1 As Int32 = 1 To cmi_lb Step 1
						r0 = tmpData.Rows(ocol - z1 - 1)
						'price change is 2 days price change
						r1 = tmpData.Rows(ocol - z1 - 3)

						' ATR[100] for last 300 days
						r0.c21 = tmpData.Compute("avg(c19)", String.Format("rn <= {0} and rn >= {1}", ocol - z1 - 1, ocol - z1 - 100))
						' today's range  > ATR[100] , 1 else 0
						mkt1atr(z1) = If(r0.c19 > r0.c21, 1, 0)
						' price change
						mkt1pc(z1) = r0.c5 - r1.c5
						' date
						mkt1dt(z1) = r0.c1
					Next
					'r0, check when to recall r0
					'''''''''''''''''''''''''''''''''
					'''
					'''''''calculate MM Risk using long lb & short lb '''''''
					'''
					'''''''''''''''''''''''''''''''''
					r0 = tmpData.Rows(ocol - 1 - 1)
					Dim entry_lb As Int32 = 0
					Dim exit_lb As Int32 = 0
					entry_lb = If(llen > ocol - 1, ocol - 1, llen)
					exit_lb = If(slen > ocol - 1, ocol - 1, slen)
					maxl = (tmpData.Compute("max(c3)", String.Format("rn <= {0} and rn >= {1}", ocol - 1, ocol - entry_lb)) + rmkt0.c5)
					minl = (tmpData.Compute("min(c4)", String.Format("rn <= {0} and rn >= {1}", ocol - 1, ocol - entry_lb)) - rmkt0.c5)
					maxs = (tmpData.Compute("max(c3)", String.Format("rn <= {0} and rn >= {1}", ocol - 1, ocol - exit_lb + 1)) + rmkt0.c5)
					mins = (tmpData.Compute("min(c4)", String.Format("rn <= {0} and rn >= {1}", ocol - 1, ocol - exit_lb + 1)) - rmkt0.c5)
					cl = r0.c5
					'long MM Risk
					rRar.F6 = rmkt0.c4 * (maxl - mins)
					'Short MM Risk
					rRar.F7 = rmkt0.c4 * (maxs - minl)
					rRar.F8 = r0.c1 'date
					'''''''''''''''''''''''''''''''''
					'''
					'''''''calculate short RAR '''''''
					'''
					'''''''''''''''''''''''''''''''''
					numd1 = 0
					numd2 = 0
					If ((ocol - 1) > (llen + 2 + lbp)) AndAlso (lbp > 0) Then
						For sy As Int32 = ocol - lbp - 1 To ocol - 1 Step 1
							r0 = tmpData.Rows(sy - 1)
							If (r0.c12 <> 0) OrElse (r0.c13 <> 0) Then numd1 += 1
							r0.c16 = If(r0.c14 < 0, r0.c14 ^ 2, 0)
						Next

						r = tmpData.Compute("sum(c14)", String.Format("rn <={0} and rn>={1}", ocol - 1, ocol - lbp - 1))
						sd = tmpData.Compute("sum(c16)", String.Format("rn <={0} and rn>={1}", ocol - 1, ocol - lbp - 1))

						If r = 0 Then
							rRar.F3 = 0
						Else
							r = r / numd1
							sd = Math.Sqrt(sd / numd1)
							rRar.F3 = If(r > 0, r / sd, r * sd)
						End If
					Else
						rRar.F3 = Double.NaN
					End If
					'''''''''''''''''''''''''''''''''
					'''
					'''''''calculate long RAR '''''''
					'''
					'''''''''''''''''''''''''''''''''
					If ((ocol - 1) > (llen + 2 + sbp)) AndAlso (sbp > 0) Then
						For sy = (ocol - sbp - 1) To ocol - 1 Step 1
							r0 = tmpData.Rows(sy - 1)

							If (r0.c12 <> 0) OrElse (r0.c13 <> 0) Then numd2 += 1
							r0.c16 = If(r0.c14 < 0, r0.c14 ^ 2, 0)
						Next

						r = tmpData.Compute("sum(c14)", String.Format("rn <={0} and rn>={1}", ocol - 1, ocol - sbp - 1))
						sd = tmpData.Compute("sum(c16)", String.Format("rn <={0} and rn>={1}", ocol - 1, ocol - sbp - 1))

						If r = 0 Then
							rRar.F4 = 0
						Else
							r = r / numd2
							sd = Math.Sqrt(sd / numd2)
							rRar.F4 = If(r > 0, r / sd, r * sd)
						End If
					Else
						rRar.F4 = Double.NaN
					End If

					'if no B or S position
					If Not rmkt0.c19.Equals("") Then
						' color the data
						rRar._color = 1 ' Color.FromArgb(200, 160, 35).ToArgb()

					End If

					'''''''''''''''''''''''''''''''''
					'''
					'''''''calculate 2nd MarketCMI '''''''
					'''
					'''''''''''''''''''''''''''''''''

					If mci Then
						Me.Invoke(writeStatus, f, "Calculating MCI, please wait…")
						Dim rx0 As ods.DataRow = Nothing
						Dim rx1 As ods.DataRow = Nothing
						Dim ocol2 As Int32 = 0
						Dim ff As Boolean = False
						bmktcmi = 0
						smktcmi = 0
						Dim mciData As ods.DataDataTable = Nothing
						Dim fx As String = ""

						For Each rmkt1 In x.MktSpec.Rows
							mciData = New ods.DataDataTable
							ff = False
							If Not rmkt1.Isc19Null() Then

								Dim cmict2 As Int32 = 1
								Dim cmi As Int32 = 0
								Dim necmi As Int32 = 0
								Dim ttdt As Int32 = 0

								If rmkt1.c1 = mktName.Substring(0, 2) Then Continue For

								For Each fx In Directory.GetFiles(src_dir, "*.prn", SearchOption.TopDirectoryOnly)
									'MessageBox.Show(rmkt1.c1.ToLower().Substring(0, 2), Path.GetFileNameWithoutExtension(fx).Substring(0, 2).ToLower())
									If Path.GetFileNameWithoutExtension(fx).Substring(0, 2).ToLower().Equals(rmkt1.c1.ToLower().Substring(0, 2)) Then
										ff = True
										Exit For
									End If
								Next
								If Not ff Then Continue For

								Me.Invoke(writeStatus, f, "Calculating " & Path.GetFileName(fx) & ", please wait…")
								mciData = lstFile(Path.GetFileName(fx).ToLower())
								ocol2 = mciData.Rows.Count
								maxRecord = ocol2
								mciData.AcceptChanges()

								r0 = mciData.Rows(ocol2 - 1)
								For z = 1 To 410
									r0 = mciData.Rows(ocol2 - z)
									r1 = mciData.Rows(ocol2 - z - 1)

									r0.c17 = If(r0.c3 >= r1.c5, r0.c3, r1.c5)

									If r0.c4 <= r1.c5 Then
										r0.c18 = r0.c4
									Else
										r0.c18 = r1.c5
									End If
									'ATR[1]
									r0.c19 = r0.c17 - r0.c18
								Next z

								For z1 As Int32 = 1 To 300 Step 1
									r0 = mciData.Rows(ocol2 - z1)
									r1 = mciData.Rows(ocol2 - z1 - 2)

									r0.c21 = mciData.Compute("avg(c19)", String.Format("rn <= {0} and rn >= {1}", ocol2 - z1 - 1, ocol2 - z1 - 100))

									mkt2atr(z1) = If(r0.c19 > r0.c21, 1, 0)
									mkt2pc(z1) = r0.c5 - r1.c5
									mkt2dt(z1) = r0.c1
								Next

								For cmict As Int32 = 1 To 300 Step 1
									If mkt1dt(cmict) = mkt2dt(cmict2) Then
										If (mkt1atr(cmict) = 1) OrElse (mkt2atr(cmict2) = 1) Then
											If (mkt1pc(cmict) * mkt2pc(cmict2)) > 0 Then cmi += 1
											If (mkt1pc(cmict) * mkt2pc(cmict2)) < 0 Then necmi += 1
											ttdt += 1
										End If
										cmict2 += 1

									ElseIf mkt1dt(cmict) < mkt2dt(cmict2) Then
										Do While mkt1dt(cmict) < mkt2dt(cmict2)
											cmict2 += 1
										Loop
										If mkt1dt(cmict) = mkt2dt(cmict2) Then
											If (mkt1atr(cmict) = 1) OrElse (mkt2atr(cmict2) = 1) Then
												If (mkt1pc(cmict) * mkt2pc(cmict2)) > 0 Then cmi += 1
												If (mkt1pc(cmict) * mkt2pc(cmict2)) < 0 Then necmi += 1
												ttdt += 1
											End If
											cmict2 += 1
										End If

									ElseIf mkt1dt(cmict) > mkt2dt(cmict2) Then
									End If
								Next

								If ttdt <> 0 Then
									If cmi <> 0 Then
										If (cmi / ttdt) > 0.59 Then
											If rmkt1.c19.ToLower().StartsWith("b") Then bmktcmi = bmktcmi + cmi / ttdt * rmkt1.c21
											If rmkt1.c19.ToLower().StartsWith("s") Then smktcmi = smktcmi + cmi / ttdt * rmkt1.c21
										End If
									End If

									If necmi <> 0 Then
										If (necmi / ttdt) > 0.59 Then
											If rmkt1.c19.ToLower().StartsWith("b") Then smktcmi = smktcmi + necmi / ttdt * rmkt1.c21
											If rmkt1.c19.ToLower().StartsWith("s") Then bmktcmi = bmktcmi + necmi / ttdt * rmkt1.c21
										End If
									End If
								End If
							End If
						Next
					End If


					Dim xxxx As String = rmkt0.c2
					rRar.F15 = bmktcmi
					rRar.F16 = smktcmi

					If mci Then
						rmkt0.c22 = bmktcmi
						rmkt0.c23 = smktcmi
						cmMktUpdate.Parameters("@c22").Value = bmktcmi
						cmMktUpdate.Parameters("@c23").Value = smktcmi
						cmMktUpdate.Parameters("@rn").Value = rmkt0.rn
						cmMktUpdate.ExecuteNonQuery()
					End If

					x.RAR.Rows.Add(rRar)
				Next


				'' sorting
				Dim rnk As Double = 1
				Dim avgRk As Int32 = 0

				For Each rRar In x.RAR.Select("", "f3 asc")
					rRar.F9 = rnk
					rnk += 1
				Next

				rnk = 1
				For Each rRar In x.RAR.Select("", "f4 asc")
					rRar.F10 = rnk
					rnk += 1
				Next

				For Each rRar In x.RAR.Select("", "f4 desc")
					If rRar.F2.Equals("") Then Continue For

					rnk = (rRar.F9 + rRar.F10) / 2
					avgRk = ((rnk * 30) \ x.RAR.Rows.Count) + 1
					rRar.F11 = avgRk
					rRar.F12 = (0.0024 * (avgRk) ^ 3 - 0.0715 * (avgRk) ^ 2 + 0.7238 * avgRk + 18.07) / (0.0024 * 30 ^ 3 - 0.0715 * 30 ^ 2 + 0.7238 * 30 + 18.07)
					rRar.F13 = accountSize * mmFactor / rRar.F5 * rRar.F12


				Next


				'' saving to database (rar table)
				cn.NewCommand("delete from [rar]").ExecuteNonQuery()


				Dim cmRarInsert As OleDbCommand = cn.NewCommand("insert into [rar] (rn,f1,f2,f3,f4,f5,f6,f7,f8,f9,f10,f11,f12,f13,f14,f15,f16,_color) values (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)")
				Dim cx As DataColumn = Nothing

				With cmRarInsert.Parameters
					.Add("@rn", OleDbType.Integer)
					For i As Int32 = 1 To 16 Step 1
						cx = x.RAR.Columns("f" & i)
						If cx.DataType.ToString().ToLower().StartsWith("system.int") Then
							.Add("@f" & i, OleDbType.Integer)
						ElseIf cx.DataType Is GetType(Double) Then
							.Add("@f" & i, OleDbType.Double)
						Else
							.Add("@f" & i, OleDbType.VarChar, 250)

						End If
					Next
					.Add("@_color", OleDbType.Integer)
				End With
				cmRarInsert.Prepare()

				fileNo = 0
				For Each rRar In x.RAR.Rows
					fileNo += 1

					With cmRarInsert.Parameters
						'if MktSpec is NOT found then only inset f1 & rn, other empty 
						If rRar.F2.Equals("") Then
							For Each c As DataColumn In ds.RAR.Columns
								If c.ColumnName.ToLower().Equals("f1") Then
									.Item("@" & c.ColumnName).Value = rRar(c.ColumnName)
								ElseIf c.ColumnName.ToLower().Equals("rn") Then
									.Item("@" & c.ColumnName).Value = rRar(c.ColumnName)
								Else
									.Item("@" & c.ColumnName).Value = DBNull.Value
								End If
							Next

						Else
							' if MktSpec is found, inset all 
							For Each c As DataColumn In ds.RAR.Columns
								.Item("@" & c.ColumnName).Value = rRar(c.ColumnName)
							Next
						End If
					End With
					cmRarInsert.ExecuteNonQuery()
				Next


			Catch ex As Exception
				em = ex.Message
			Finally
				e.Result = {em}
			End Try
		End Using



	End Sub
	Private Sub _bwCalc_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bwCalc.RunWorkerCompleted
		Dim em As String = e.Result(0)
		'WWHide()

		oCalcButton.Enabled = True
		oMktMciUpdateButton.Enabled = True

		Dim x As TimeSpan = DateTime.Now.Subtract(t_start)
		oStatus.Caption = "Job completed at " & x.Hours.ToString().PadLeft(2, "0") &
			":" & x.Minutes.ToString().PadLeft(2, "0") & ":" &
			x.Seconds.ToString().PadLeft(2, "0")

		If em.Equals("") Then
			XtraMessageBox.Show("Job completed successfully.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
			oRefreshAllButton.PerformClick()
		Else
			XtraMessageBox.Show(JOB_FAILED & em, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
		End If
	End Sub


	Private Sub _oCalcButton_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles oCalcButton.ItemClick
		'WWShow()
		oMktMciUpdateButton.Enabled = False
		oCalcButton.Enabled = False
		t_start = DateTime.Now


		bwCalc.RunWorkerAsync({False})
		'bwFiles.RunWorkerAsync()
		'taskLoadFile()
		'	WWHide()
	End Sub

	Private Sub taskLoadFile()
		Dim fls As String() = Directory.GetFiles(src_dir, "*.prn", SearchOption.TopDirectoryOnly)
		WWShow()
		Using cn As New MsAccess
			Try
				cn.Open()
				cn.NewCommand("delete from [files]").ExecuteNonQuery()
				cn.NewCommand("delete from [data]").ExecuteNonQuery()
			Catch ex As Exception
				MsgBox(ex.Message)
			End Try
		End Using
		Tasks.Parallel.ForEach(fls, AddressOf loadFiles)
		WWHide()
	End Sub

	Private Sub loadFiles(currentFile As String)
		Dim em As String = ""
		Using cn As New MsAccess
			Dim rnd As New Random()
			Try
				next_id += 1
				WWSetCaption(Path.GetFileName(currentFile))
				Dim rid As Int64 = next_id
				cn.Open()
				cn.BeginTransaction()
				'MsgBox(rid)
				With cn.NewCommand("insert into [files] (fn) values (?)")
					With .Parameters
						'.Add("@a", OleDbType.BigInt).Value = rid
						.Add("@b", OleDbType.VarChar).Value = Path.GetFileName(currentFile)
					End With
					.ExecuteNonQuery()
				End With
				cn.Commit()

				Dim cm As OleDbCommand = cn.NewCommand("insert into [data] (fn, rn, c1, c2,c3,c4,c5,c6,c7) values (?,?,?,?,?,?,?,?,?)")
				With cm.Parameters
					.Add("@fn", OleDbType.BigInt)
					.Add("@rn", OleDbType.BigInt)
					.Add("@c1", OleDbType.Double)
					.Add("@c2", OleDbType.Double)
					.Add("@c3", OleDbType.Double)
					.Add("@c4", OleDbType.Double)
					.Add("@c5", OleDbType.Double)
					.Add("@c6", OleDbType.Double)
					.Add("@c7", OleDbType.Double)
				End With
				cm.Prepare()

				cm.Parameters("@fn").Value = rid

				Dim s As String() = Nothing

				Using csv As New FileIO.TextFieldParser(currentFile) With {.Delimiters = {","}, .TextFieldType = FileIO.FieldType.Delimited, .TrimWhiteSpace = True}
					csv.ReadFields() ' skip 1 line
					While csv.LineNumber > 0

						If csv.LineNumber Mod 1000 = 0 Then
							WWSetCaption(Path.GetFileName(currentFile))
							WWSetDescription(csv.LineNumber)
						End If

						s = csv.ReadFields()
						With cm.Parameters
							.Item("@rn").Value = csv.LineNumber
							For i As Int32 = 1 To 7 Step 1
								.Item("@c" & i).Value = s(i - 1)
							Next
						End With

						cm.ExecuteNonQuery()
					End While
				End Using
			Catch ex As Exception
				cn.Rollback()
				Throw ex
			Finally
			End Try
		End Using


	End Sub

	Private Function stripHtml(s As String) As String
		Return Trim(HttpUtility.HtmlDecode(Regex.Replace(s, "<.*?>", "", RegexOptions.Singleline Or RegexOptions.IgnoreCase)))
	End Function

	Private Function clearText(t As String) As String
		Return Trim(Trim(t).Replace(vbCr, "").Replace(vbLf, "").Replace(vbTab, ""))
	End Function

	Private Sub _bwWeb_DoWork(sender As Object, e As DoWorkEventArgs) Handles bwWeb.DoWork
		Dim em As String = ""
		Dim webem As String = ""
		Using cn As New MsAccess
			Try
				'WWSetCaption("IndexMundi")
				Me.Invoke(writeStatus, "IndexMundi", "Downloading, please wait…")
				Dim cm As OleDbCommand = cn.NewCommand("insert into [IndexMundi] (id,xDate,xArea,xCurrency,xRate,xInverse) values (?,?,?,?,?,?)")
				cn.Open()
				With cm.Parameters
					.Add("@a", OleDbType.VarChar, 3)
					.Add("@b", OleDbType.Date)
					.Add("@c", OleDbType.VarChar, 100)
					.Add("@d", OleDbType.VarChar, 100)
					.Add("@e", OleDbType.Currency)
					With .Add("@f", OleDbType.Decimal)
						.Size = 9
						.Scale = 4
					End With
				End With
				cm.Prepare()

				Dim cmc As OleDbCommand = cn.NewCommand("select count(*) from [IndexMundi] where id = ?")
				cmc.Parameters.Add("@a", OleDbType.VarChar, 3)
				cmc.Prepare()

				Dim html As String = ""
				Dim ws As HttpWebResponse = Nothing
				Dim wr As HttpWebRequest = Nothing

				Dim data As String = ""
				Dim lst As New List(Of String)
				Try
					wr = HttpWebRequest.Create("http://www.indexmundi.com/xrates/table.aspx")
					wr.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:31.0) Gecko/20100101 Firefox/31.0"
					wr.Method = "GET"
					ws = wr.GetResponse()
					html = New StreamReader(ws.GetResponseStream()).ReadToEnd()
					Me.Invoke(writeStatus, "IndexMundi", "Parsing, please wait…")
					' Only clear the table if we successfully got the data
					cn.NewCommand("delete from [IndexMundi]").ExecuteNonQuery()
					data = "<tr>" & Regex.Match(html, "(?<=</tr><tr>)(.*?)</table>", RegexOptions.IgnoreCase Or RegexOptions.Singleline).Value

					'' parsing rows
					For Each m As Match In Regex.Matches(data, "(?<=<tr(.*?)>)(.*?)</tr>", RegexOptions.IgnoreCase Or RegexOptions.Singleline)
						lst.Clear()

						For Each x As Match In Regex.Matches(m.Value, "(?<=>)[^<]*", RegexOptions.Singleline Or RegexOptions.IgnoreCase)
							If clearText(x.Value).Equals("") Then Continue For
							lst.Add(clearText(x.Value))
						Next

						cmc.Parameters("@a").Value = Regex.Match(lst(2), "(?<=\()[^)]*", RegexOptions.Singleline Or RegexOptions.IgnoreCase).Value
						If cmc.ExecuteScalar() = 0 Then

							With cm.Parameters
								.Item("@a").Value = Regex.Match(lst(2), "(?<=\()[^)]*", RegexOptions.Singleline Or RegexOptions.IgnoreCase).Value
								.Item("@b").Value = DateTime.Parse(lst(0))
								.Item("@c").Value = lst(1)
								.Item("@d").Value = lst(2)
								.Item("@e").Value = lst(3)
								.Item("@f").Value = lst(5)
							End With
							cm.ExecuteNonQuery()
						End If
					Next
				Catch ex As Exception
					' If IndexMundi fails, continue without updating
					webem = "IndexMundi data not updated: " & ex.Message
					Me.Invoke(Sub() XtraMessageBox.Show(webem, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning))
				End Try
				' update ExchangeRate page
				'	WWSetCaption("ExchangeRate")
				Me.Invoke(writeStatus, "ExchangeRate", "Downloading, please wait…")
				Try
					cm = cn.NewCommand("insert into [ExchangeRate] (id,xCurrency,xDat0,xDat1,xChange,xCountry) values (?,?,?,?,?,?)")
					cn.Open()
					With cm.Parameters
						.Add("@a", OleDbType.VarChar, 3)
						.Add("@c", OleDbType.VarChar, 30)
						.Add("@d", OleDbType.Currency)
						.Add("@e", OleDbType.Currency)
						With .Add("@f", OleDbType.Decimal)
							.Size = 9
							.Scale = 4
						End With
						.Add("@g", OleDbType.VarChar, 250)
					End With
					cm.Prepare()

					cmc = cn.NewCommand("select count(*) from [ExchangeRate] where id = ?")
					cmc.Parameters.Add("@a", OleDbType.VarChar, 3)
					cmc.Prepare()
					' Only delete existing data if we're going to successfully get new data
					Dim exchangeRateUpdated As Boolean = False


					wr = HttpWebRequest.Create("http://www.exchangerate.com/")
					lst = New List(Of String)

					wr.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:31.0) Gecko/20100101 Firefox/31.0"
					wr.Method = "GET"
					ws = wr.GetResponse()
					html = New StreamReader(ws.GetResponseStream()).ReadToEnd()
					Me.Invoke(writeStatus, "ExchangeRate", "Parsing, please wait…")
					' Only clear the table if we successfully got the data
					cn.NewCommand("delete from ExchangeRate").ExecuteNonQuery()
					exchangeRateUpdated = True

					data = Regex.Match(html, "(?<=xml version)(.*?)GMT\)", RegexOptions.IgnoreCase Or RegexOptions.Singleline).Value
					'' parsing rows
					For Each m As Match In Regex.Matches(data, "(?<=country-flags)(.*?)</TD></TR>", RegexOptions.IgnoreCase Or RegexOptions.Singleline)
						lst.Clear()
						For Each x As Match In Regex.Matches(m.Value, "(?<=<td)(.*?)</td>", RegexOptions.Singleline Or RegexOptions.IgnoreCase)
							If clearText(x.Value).Equals("") Then Continue For
							lst.Add(stripHtml("<td" & x.Value))
						Next

						cmc.Parameters("@a").Value = lst(2)
						If cmc.ExecuteScalar() = 0 Then
							cm.Parameters("@a").Value = lst(2)
							cm.Parameters("@d").Value = lst(3)
							cm.Parameters("@e").Value = lst(4)
							cm.Parameters("@c").Value = lst(1)
							cm.Parameters("@f").Value = lst(5).Replace("%", "")
							cm.Parameters("@g").Value = lst(0)
							cm.ExecuteNonQuery()
						End If
					Next
				Catch ex As Exception
					' If exchange rate fails, continue without updating
					webem = "Exchange rate data not updated: " & ex.Message
					Me.Invoke(Sub() XtraMessageBox.Show(webem, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning))
				End Try
			Catch ex As Exception
				em = ex.Message
			Finally
				e.Result = {em}
			End Try
		End Using
	End Sub

	Private Sub _bwWeb_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bwWeb.RunWorkerCompleted
		Dim em As String = e.Result(0)
		If em.Equals("") Then
			bwMkt.RunWorkerAsync()
		Else
			WWHide()
			XtraMessageBox.Show(JOB_FAILED & em, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
		End If
	End Sub

	Private Sub _oMktMciUpdateButton_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles oMktMciUpdateButton.ItemClick
		'WWShow()
		oCalcButton.Enabled = False
		oMktMciUpdateButton.Enabled = False
		t_start = DateTime.Now
		bwWeb.RunWorkerAsync()
	End Sub

	Private Sub bwMkt_DoWork(sender As Object, e As DoWorkEventArgs) Handles bwMkt.DoWork
		Dim em As String = ""
		Using cn As New MsAccess
			Try
				'WWSetDescription("Updating MKT")
				Me.Invoke(writeStatus, "MKTSpec", "Updating, please wait…")

				cn.Open()

				Dim x As New ods
				x.IndexMundi.Load(cn.NewCommand("select * from IndexMundi").ExecuteReader())
				x.ExchangeRate.Load(cn.NewCommand("select * from ExchangeRate").ExecuteReader())
				x.MktSpec.Load(cn.NewCommand("select * from MktSpec").ExecuteReader())

				Dim rmkt As ods.MktSpecRow = Nothing
				Dim rexc As ods.ExchangeRateRow = Nothing
				Dim rind As ods.IndexMundiRow = Nothing

				For Each rmkt In x.MktSpec.Rows
					rmkt._fnd = rmkt.c1.Substring(0, 2)
					If rmkt.Isc10Null() Then rmkt.c10 = 0
					'if USD, no need search for exchange rate
					If Trim(rmkt.c12).Equals("") OrElse Trim(rmkt.c12).Equals("USD") Then
						If Not rmkt.Isc3Null() Then
							rmkt.c4 = rmkt.c3
						Else
							Throw New Exception("No point value information for " & rmkt.c1 & ".")
						End If
						rmkt.c11 = rmkt.c10
					Else
						rind = x.IndexMundi.Rows.Find(rmkt.c12)
						If rind Is Nothing Then
							' try exchange rate
							rexc = x.ExchangeRate.Rows.Find(rmkt.c12)
							If rexc Is Nothing Then
								Throw New Exception("No Currency Information for " & rmkt.c12 & " currency. Please edit Web Query.")
							Else
								rmkt.c13 = rexc.xDat1
							End If
						Else
							rmkt.c13 = rind.xRate
						End If
						rmkt.c4 = rmkt.c3 / rmkt.c13
						rmkt.c11 = rmkt.c10 / rmkt.c13
					End If
				Next

				cn.NewCommand("delete from MktSpec").ExecuteNonQuery()

				Dim cmd0 As String = ""
				Dim cmd1 As String = ""

				cmd0 = "insert into [MktSpec] ("
				cmd1 = ") values ("
				For Each c As DataColumn In x.MktSpec.Columns
					If c.ColumnName.StartsWith("_") Then Continue For
					cmd0 &= c.ColumnName & ","
					cmd1 &= "?,"
				Next
				cmd0 = cmd0.Substring(0, cmd0.Length - 1)
				cmd1 = cmd1.Substring(0, cmd1.Length - 1)

				Dim cmMkt As OleDbCommand = cn.NewCommand(cmd0 & cmd1 & ")")
				With cmMkt.Parameters
					For Each c As DataColumn In x.MktSpec.Columns
						If c.ColumnName.StartsWith("_") Then Continue For
						If c.DataType.ToString().StartsWith("System.String") Then
							.Add("@" & c.ColumnName, OleDbType.VarChar, 250)
						Else
							.Add("@" & c.ColumnName, OleDbType.Double)
						End If
					Next
				End With
				cmMkt.Prepare()

				For Each rmkt In x.MktSpec.Rows
					With cmMkt.Parameters
						For Each c As DataColumn In x.MktSpec.Columns
							If c.ColumnName.StartsWith("_") Then Continue For
							.Item("@" & c.ColumnName).Value = rmkt(c)
						Next
					End With
					cmMkt.ExecuteNonQuery()
				Next
			Catch ex As Exception
				em = ex.Message
			Finally
				e.Result = {em}
			End Try
		End Using
	End Sub

	Private Sub _bwMkt_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bwMkt.RunWorkerCompleted
		Dim em As String = e.Result(0)
		If em.Equals("") Then
			bwCalc.RunWorkerAsync({True})
		Else
			WWHide()
			XtraMessageBox.Show(JOB_FAILED & em, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
		End If
	End Sub

	Private Sub _oMktSave_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) 
		Dim em As String = ""
		Using cn As New MsAccess
			Try
				gvm.CloseEditor()
				gvm.UpdateCurrentRow()

				WWShow()
				cn.Open()
				cn.BeginTransaction()

				Dim cmu As OleDbCommand = Nothing
				Dim sw As New System.Text.StringBuilder
				sw.Append("update MktSpec set ")

				For Each c As DataColumn In ds.MktSpec.Columns
					If Not c.ColumnName.StartsWith("c") Then Continue For
					sw.Append(c.ColumnName & " = ?,")
				Next
				sw.Remove(sw.Length - 1, 1)
				sw.Append(" where rn = ?")

				cmu = cn.NewCommand(sw.ToString())

				With cmu.Parameters
					For Each c As DataColumn In ds.MktSpec.Columns
						If Not c.ColumnName.StartsWith("c") Then Continue For
						If c.DataType Is GetType(String) Then
							.Add("@" & c.ColumnName, OleDbType.VarChar, 250)
						Else
							.Add("@" & c.ColumnName, OleDbType.Double)
						End If
					Next
					.Add("@rn", OleDbType.Integer)
				End With
				cmu.Prepare()

				For Each r As ods.MktSpecRow In ds.MktSpec.Rows
					If r.RowState = DataRowState.Modified Then
						With cmu.Parameters
							For Each c As DataColumn In ds.MktSpec.Columns
								If Not c.ColumnName.StartsWith("c") Then Continue For
								.Item("@" & c.ColumnName).Value = r(c)
							Next

							.Item("@rn").Value = r.rn
						End With
						cmu.ExecuteNonQuery()
					End If
				Next
				cn.Commit()
				ds.MktSpec.AcceptChanges()
			Catch ex As Exception
				cn.Rollback()
				em = ex.Message
			Finally
				WWHide()
			End Try
		End Using

		If em.Equals("") Then
			XtraMessageBox.Show("Data saved successfully.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
		Else
			XtraMessageBox.Show(JOB_FAILED & em, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
		End If
	End Sub

	Private Sub _oOptionsSaveButton_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs)
		Dim em As String = ""
		Using cn As New MsAccess
			Try
				gvo.CloseEditor()
				gvo.UpdateCurrentRow()

				WWShow()
				cn.Open()
				cn.BeginTransaction()

				Dim cmu As OleDbCommand = Nothing
				Dim sw As New System.Text.StringBuilder
				sw.Append("update [Options] set ")

				For Each c As DataColumn In ds.Options.Columns
					If Not c.ColumnName.StartsWith("c") Then Continue For
					sw.Append(c.ColumnName & " = ?,")
				Next
				sw.Remove(sw.Length - 1, 1)
				sw.Append(" where rn = ?")

				cmu = cn.NewCommand(sw.ToString())

				With cmu.Parameters
					For Each c As DataColumn In ds.Options.Columns
						If Not c.ColumnName.StartsWith("c") Then Continue For
						If c.DataType Is GetType(String) Then
							.Add("@" & c.ColumnName, OleDbType.VarChar, 250)
						Else
							.Add("@" & c.ColumnName, OleDbType.Double)
						End If
					Next
					.Add("@rn", OleDbType.Integer)
				End With
				cmu.Prepare()

				For Each r As ods.OptionsRow In ds.Options.Rows
					If r.RowState = DataRowState.Modified Then
						With cmu.Parameters
							For Each c As DataColumn In ds.Options.Columns
								If Not c.ColumnName.StartsWith("c") Then Continue For
								.Item("@" & c.ColumnName).Value = r(c)
							Next

							.Item("@rn").Value = r.rn
						End With
						cmu.ExecuteNonQuery()
					End If
				Next
				cn.Commit()
				ds.Options.AcceptChanges()
			Catch ex As Exception
				cn.Rollback()
				em = ex.Message
			Finally
				WWHide()
			End Try
		End Using

		If em.Equals("") Then
			refreshColumnNames()
			XtraMessageBox.Show("Data saved successfully.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
		Else
			XtraMessageBox.Show(JOB_FAILED & em, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
		End If
	End Sub

	Private Sub _oRarExport_PDF_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles oRarExport_PDF.ItemClick
		sfd.Filter = save_pdf
		sfd.FileName = ""
		If sfd.ShowDialog(Me) <> DialogResult.OK Then Exit Sub
		gvr.ExportToPdf(sfd.FileName)
	End Sub

	Private Sub _oRarExport_Excel_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles oRarExport_Excel.ItemClick
		sfd.Filter = save_xls
		sfd.FileName = ""
		If sfd.ShowDialog(Me) <> DialogResult.OK Then Exit Sub
		gvr.ExportToXlsx(sfd.FileName)
	End Sub

	Private Sub _oRarExport_Csv_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles oRarExport_Csv.ItemClick
		sfd.Filter = save_csv
		sfd.FileName = ""
		If sfd.ShowDialog(Me) <> DialogResult.OK Then Exit Sub
		gvr.ExportToCsv(sfd.FileName)

	End Sub

	Private Sub _oRarExport_Html_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles oRarExport_Html.ItemClick
		sfd.Filter = save_html
		sfd.FileName = ""
		If sfd.ShowDialog(Me) <> DialogResult.OK Then Exit Sub
		gvr.ExportToHtml(sfd.FileName)
	End Sub

	Private Sub _oSetFolderButton_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles oSetFolderButton.ItemClick
		fbd.SelectedPath = src_dir
		If fbd.ShowDialog(Me) <> DialogResult.OK Then Exit Sub
		src_dir = addBs(fbd.SelectedPath)
		oFolderLoc.Caption = src_dir
		Try
			File.WriteAllText("last_dir.txt", src_dir)
		Catch ex As Exception
		End Try


	End Sub

	Private Function addBs(p As String) As String
		If p.EndsWith("\") Then Return p
		Return p & "\"
	End Function

	Private Sub _gvm_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles gvm.CellValueChanged
		' get the row 
		Dim r As ods.MktSpecRow = gvm.GetDataRow(e.RowHandle)
		Dim em As String = ""
		Using cn As New MsAccess
			Try
				cn.Open()
				Dim w As New System.Text.StringBuilder
				w.Append("update mktspec set ")
				w.Append(e.Column.FieldName & " = ")
				If e.Value Is DBNull.Value Then
					w.Append("null")
				Else
					Dim c As DataColumn = ds.MktSpec.Columns(e.Column.FieldName)
					If c.DataType Is GetType(Double) Then
						If e.Value Is DBNull.Value Then
							w.Append("null")
						Else
							Try
								Convert.ToDouble(e.Value)
								w.Append(e.Value)
							Catch ex As Exception
								w.Append(0)
							Finally
							End Try
						End If
					ElseIf c.DataType.ToString().ToLower().StartsWith("system.int") Then
						If e.Value Is DBNull.Value Then
							w.Append("null")
						Else
							Try
								Convert.ToInt32(e.Value)
								w.Append(e.Value)
							Catch ex As Exception
								w.Append(0)
							Finally
							End Try
						End If
					Else
						w.Append("'" & e.Value & "'")
					End If
				End If

				w.Append(" where rn = " & r.rn)

				cn.NewCommand(w.ToString()).ExecuteNonQuery()

			Catch ex As Exception
				em = ex.Message
			Finally

			End Try

		End Using

		If Not em.Equals("") Then XtraMessageBox.Show(em, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
	End Sub

	Private Sub _gvo_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles gvo.CellValueChanged
		' get the row 
		Dim r As ods.OptionsRow = gvo.GetDataRow(e.RowHandle)
		Dim em As String = ""
		Using cn As New MsAccess
			Try
				cn.Open()
				Dim w As New System.Text.StringBuilder
				w.Append("update [Options] set ")
				w.Append(e.Column.FieldName & " = '" & e.Value & "'")
				w.Append(" where rn = " & r.rn)

				cn.NewCommand(w.ToString()).ExecuteNonQuery()

			Catch ex As Exception
				em = ex.Message
			Finally
				refreshColumnNames()
			End Try

		End Using
	End Sub

	Private Sub oAddButton_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles oAddButton.ItemClick
		Dim em As String = ""
		Using cn As New MsAccess
			Try
				cn.Open()
				cn.NewCommand("insert into MktSpec(rn) select max(rn) + 1 from MktSpec").ExecuteNonQuery()

				gvm.BeginDataUpdate()
				With ds.MktSpec
					.Clear()
					.BeginLoadData()
				End With
				ds.MktSpec.Load(cn.NewCommand("select * from MktSpec").ExecuteReader())


			Catch ex As Exception
				em = ex.Message
			Finally
				With ds.MktSpec
					.EndLoadData()
				End With
				gvm.EndDataUpdate()

				Try
					For i As Int32 = 0 To gvm.RowCount Step 1
						If gvm.GetRowCellValue(i, "c1") Is DBNull.Value Then
							gvm.FocusedRowHandle = i
							gvm.FocusedColumn = gvm.Columns("c1")
							gvm.ShowEditor()
							Exit For
						End If
					Next
				Catch ex As Exception
				End Try

			End Try
		End Using


		If em.Equals("") Then
		Else
			XtraMessageBox.Show(JOB_FAILED & em, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
		End If
	End Sub

	Private Sub oDeleteButton_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles oDeleteButton.ItemClick
		Dim em As String = ""
		Using cn As New MsAccess
			Try
				cn.Open()
				Dim r As ods.MktSpecRow = gvm.GetFocusedDataRow()
				With cn.NewCommand("delete from MktSpec where rn = ?")
					.Parameters.Add("@rn", OleDbType.BigInt).Value = r.rn
					.ExecuteNonQuery()
				End With

			Catch ex As Exception
				em = ex.Message
			Finally
				gvm.DeleteSelectedRows()
			End Try
		End Using


		If em.Equals("") Then
		Else
			XtraMessageBox.Show(JOB_FAILED & em, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
		End If
	End Sub

	Private Sub gvm_FocusedRowChanged(sender As Object, e As FocusedRowChangedEventArgs) Handles gvm.FocusedRowChanged
		Dim en As Boolean = (e.FocusedRowHandle >= 0)
		oDeleteButton.Enabled = en
	End Sub
