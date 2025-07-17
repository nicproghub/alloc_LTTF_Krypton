
Imports System.ComponentModel
Imports System.Data.OleDb
Imports System.IO
Imports System.Net
Imports System.Threading
Imports System.Text.RegularExpressions
Imports System.Web
Imports ComponentFactory.Krypton.Toolkit
Imports PdfSharp.Drawing
Imports PdfSharp.Pdf
Imports System.Diagnostics
Imports ClosedXML.Excel
Imports System.Text
Imports System.Globalization

Public Class Form1
	Private m_WWCaption As String = "Working"
	Private m_WWDescription As String = "working, please wait…"
	Public Property SuppressCloseWarning As Boolean = False
	Private Const save_pdf As String = "PDF File|*.pdf"
	Private Const save_xls As String = "Excel File|*.xlsx"
	Private Const save_csv As String = "CSV File|*.csv"

	Private Const JOB_FAILED As String = "Job failed with following error:" & vbCrLf

	Dim t_start As DateTime = DateTime.Now
	Private src_dir As String = "D:\Test\"
	'Dim connectionString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Path\To\YourDatabase.accdb;"
	'Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
	'gvm.SuspendLayout()
	'gvm.DataSource = GetDataTableFromDB()
	'Dim odsTableAdapter As New YourDataSetTableAdapters.YourTableTableAdapter()
	'Dim ta As New odsTableAdapter()
	'Dim ds As New ods()
	'ta.Fill(ds.Options)
	'gvo.DataSource = ds.Options
	'gvm.ResumeLayout()
	Private Sub ____Form_Load(sender As Object, e As EventArgs) Handles Me.Load

		If Not Me.DesignMode Then
			Try
				If File.Exists("last_dir.txt") Then
					src_dir = File.ReadAllText("last_dir.txt")
				End If
			Catch ex As Exception
			End Try

			oFolderLoc.Text = src_dir
			refreshColumnNames()
			KryptonNavigator1.SelectedPage = KryptonPage1
			' Attach the event handler
			AddHandler gvr.RowPrePaint, AddressOf gvr_RowPrePaint

		End If
	End Sub


	' Event handler
	Private Sub gvr_RowPrePaint(sender As Object, e As DataGridViewRowPrePaintEventArgs)
		Dim row As DataGridViewRow = gvr.Rows(e.RowIndex)

		If Not row.IsNewRow AndAlso row.Cells("Column1").Value IsNot Nothing Then
			Dim colorVal As Integer
			If Integer.TryParse(row.Cells("Column1").Value.ToString(), colorVal) AndAlso colorVal = 1 Then
				row.DefaultCellStyle.BackColor = Color.FromArgb(200, 160, 35)
			End If
		End If
	End Sub

	Private Sub KryptonNavigator1_SelectedPageChanged(sender As Object, e As EventArgs) Handles KryptonNavigator1.SelectedPageChanged
		If KryptonNavigator1.SelectedPage Is KryptonPage2 Then
			oAddButton.Visible = True
			oDeleteButton.Visible = True
		Else
			oAddButton.Visible = False
			oDeleteButton.Visible = False
		End If
	End Sub
	Private Sub oRefreshAllButton_Click(sender As Object, e As EventArgs) Handles oRefreshAllButton.Click
		oRefreshAllButton.Enabled = False
		Dim em As String = ""
		Using cn As New MsAccess
			Try
				cn.Open()
				For Each t As DataTable In ds.Tables
					t.BeginLoadData()
					t.Clear()
				Next
				With cn.NewCommand("select * from rar") 'order by F12 desc")
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
			End Try
		End Using
		If em.Equals("") Then
			refreshColumnNames()
			gvr.Sort(F12DataGridViewTextBoxColumn, System.ComponentModel.ListSortDirection.Descending)
		Else
			KryptonMessageBox.Show(JOB_FAILED & em, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
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
				'gvr.Columns("F3").HeaderText = "RAR " & vbCrLf & dt.Rows.Find("RAR1")("c2")
				F3DataGridViewTextBoxColumn.HeaderText = "RAR " & dt.Rows.Find("RAR1")("c2")
				F4DataGridViewTextBoxColumn.HeaderText = "RAR " & dt.Rows.Find("RAR2")("c2")
				F5DataGridViewTextBoxColumn.HeaderText = "$ ATR[x]".Replace("x", dt.Rows.Find("ATR")("c2"))
				'gvr.Columns("F5").HeaderText = "$ ATR[x]" & vbCrLf & dt.Rows.Find("ATR")("c2")
				oExportButton.Visible = True
			Catch ex As Exception
			End Try
		End Using
	End Sub
	Private Function addBs(p As String) As String
		If p.EndsWith("\") Then Return p
		Return p & "\"
	End Function
	Private Sub oSetFolderButton_Click(sender As Object, e As EventArgs) Handles oSetFolderButton.Click
		fbd.SelectedPath = src_dir
		If fbd.ShowDialog(Me) <> DialogResult.OK Then Exit Sub
		src_dir = addBs(fbd.SelectedPath)
		oFolderLoc.Text = src_dir
		Try
			File.WriteAllText("last_dir.txt", src_dir)
		Catch ex As Exception
		End Try
	End Sub
	Private Sub oRarExport_PDF_Click(sender As Object, e As EventArgs) Handles oRarExport_PDF.Click
		Using sfd As New SaveFileDialog()
			sfd.Filter = "PDF files (*.pdf)|*.pdf"
			sfd.FileName = "Export.pdf"
			If sfd.ShowDialog() = DialogResult.OK Then
				ExportDataGridViewToPdf(gvr, sfd.FileName)
				MessageBox.Show("PDF export complete.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information)
			End If
		End Using
	End Sub

	Private Sub ExportDataGridViewToPdf(dgv As DataGridView, filePath As String)
		Dim document As New PdfDocument()
		document.Info.Title = "Data Export"
		Dim page As PdfPage = document.AddPage()
		Dim gfx As XGraphics = XGraphics.FromPdfPage(page)
		Dim font As XFont = New XFont("Verdana", 10, XFontStyle.Regular)

		Dim x As Double = 40
		Dim y As Double = 40
		Dim rowHeight As Double = 20
		Dim colWidths(dgv.ColumnCount - 1) As Double

		' Measure columns
		For i = 0 To dgv.ColumnCount - 1
			colWidths(i) = 100 ' Fixed width; optionally measure text width
			gfx.DrawString(dgv.Columns(i).HeaderText, font, XBrushes.Black, New XRect(x, y, colWidths(i), rowHeight), XStringFormats.TopLeft)
			x += colWidths(i)
		Next

		y += rowHeight
		x = 40

		' Draw rows
		For Each row As DataGridViewRow In dgv.Rows
			If Not row.IsNewRow Then
				For i = 0 To dgv.ColumnCount - 1
					Dim text = If(row.Cells(i).Value IsNot Nothing, row.Cells(i).Value.ToString(), "")
					gfx.DrawString(text, font, XBrushes.Black, New XRect(x, y, colWidths(i), rowHeight), XStringFormats.TopLeft)
					x += colWidths(i)
				Next
				x = 40
				y += rowHeight
			End If
		Next

		document.Save(filePath)
		Process.Start("explorer.exe", "/select,""" & filePath & """")
	End Sub

	Private Sub oRarExport_Excel_Click(sender As Object, e As EventArgs) Handles oRarExport_Excel.Click
		Using sfd As New SaveFileDialog()
			sfd.Filter = "Excel files (*.xlsx)|*.xlsx"
			sfd.FileName = "Export.xlsx"
			If sfd.ShowDialog() = DialogResult.OK Then
				ExportDataGridViewToExcel(gvr, sfd.FileName)
				MessageBox.Show("Excel export complete.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information)
			End If
		End Using
	End Sub

	Private Sub ExportDataGridViewToExcel(dgv As DataGridView, filePath As String)
		Using wb As New XLWorkbook()
			Dim ws = wb.Worksheets.Add("DataExport")

			' Add headers
			For col = 0 To dgv.ColumnCount - 1
				ws.Cell(1, col + 1).Value = dgv.Columns(col).HeaderText
			Next

			' Add data
			For row = 0 To dgv.RowCount - 1
				If Not dgv.Rows(row).IsNewRow Then
					For col = 0 To dgv.ColumnCount - 1
						Dim cellValue = dgv.Rows(row).Cells(col).Value

						If cellValue Is Nothing OrElse IsDBNull(cellValue) Then
							ws.Cell(row + 2, col + 1).Value = ""
						ElseIf IsNumeric(cellValue) Then
							ws.Cell(row + 2, col + 1).Value = Convert.ToDouble(cellValue)
						Else
							ws.Cell(row + 2, col + 1).Value = cellValue.ToString()
						End If
					Next
				End If
			Next

			' Optional: Format table
			ws.Columns().AdjustToContents()

			wb.SaveAs(filePath)
		End Using

		Process.Start("explorer.exe", "/select,""" & filePath & """")
	End Sub

	Private Sub oRarExport_Csv_Click(sender As Object, e As EventArgs) Handles oRarExport_Csv.Click
		' Prompt user to select save location
		Using sfd As New SaveFileDialog()
			sfd.Filter = "CSV files (*.csv)|*.csv"
			sfd.Title = "Export RAR Data to CSV"
			sfd.FileName = "Export.csv"

			If sfd.ShowDialog() = DialogResult.OK Then
				ExportGridToCsv(gvr, sfd.FileName)
			End If
		End Using
	End Sub

	Private Sub ExportGridToCsv(dgv As DataGridView, filePath As String)
		Try
			Using writer As New StreamWriter(filePath, False, Encoding.UTF8)
				' Write headers
				Dim headers = dgv.Columns.Cast(Of DataGridViewColumn)().
						  Select(Function(c) $"""{c.HeaderText}""").ToArray()
				writer.WriteLine(String.Join(",", headers))

				' Write each row
				For Each row As DataGridViewRow In dgv.Rows
					If Not row.IsNewRow Then
						Dim cells = row.Cells.Cast(Of DataGridViewCell)().
						Select(Function(cell)
								   Dim val = cell.Value
								   If val Is Nothing OrElse IsDBNull(val) Then
									   Return """"""
								   ElseIf IsNumeric(val) Then
									   Return Convert.ToString(val, CultureInfo.InvariantCulture)
								   Else
									   Return $"""{val.ToString().Replace("""", """""")}"""
								   End If
							   End Function).ToArray()

						writer.WriteLine(String.Join(",", cells))
					End If
				Next
			End Using

			MessageBox.Show("Export successful!", "CSV Export", MessageBoxButtons.OK, MessageBoxIcon.Information)
		Catch ex As Exception
			MessageBox.Show("Error during export: " & ex.Message, "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
		End Try
	End Sub

	Private Sub oMktMciUpdateButton_Click(sender As Object, e As EventArgs) Handles oMktMciUpdateButton.Click
		oMktMciUpdateButton.Enabled = False
		t_start = DateTime.Now
		bwWeb.RunWorkerAsync()
	End Sub

	Private Delegate Sub d_writeStatus(f As String, t As String)
	Private writeStatus As New d_writeStatus(AddressOf _writeStatus)
	Private Sub _writeStatus(f As String, t As String)
		Dim x As TimeSpan = DateTime.Now.Subtract(t_start)
		oStatus.Text = x.Hours.ToString().PadLeft(2, "0") &
			":" & x.Minutes.ToString().PadLeft(2, "0") & ":" &
			x.Seconds.ToString().PadLeft(2, "0") & " -> " & f & ", " & t
	End Sub

	Private Function clearText(t As String) As String
		Return Trim(Trim(t).Replace(vbCr, "").Replace(vbLf, "").Replace(vbTab, ""))
	End Function

	Private Function stripHtml(s As String) As String
		Return Trim(HttpUtility.HtmlDecode(Regex.Replace(s, "<.*?>", "", RegexOptions.Singleline Or RegexOptions.IgnoreCase)))
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
					Me.Invoke(Sub() MessageBox.Show(webem, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning))
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
					Me.Invoke(Sub() MessageBox.Show(webem, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning))
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
			'WWHide()
			MessageBox.Show(JOB_FAILED & em, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
		End If
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
				' update big point value from local to USD in MktSpec
				For Each rmkt In x.MktSpec.Rows
					rmkt._fnd = rmkt.c1.Trim()
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
			'WWHide()
			MessageBox.Show(JOB_FAILED & em, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
		End If
	End Sub

	Private Sub _bsCalc_DoWork(sender As Object, e As DoWorkEventArgs) Handles bwCalc.DoWork
		Dim em As String = ""
		Dim mci As Boolean = e.Argument(0)

		Using cn As New MsAccess
			Try
				'Dict in memory, delete when app closed
				Dim lstFile As New Dictionary(Of String, ods.DataDataTable)

				Me.Invoke(writeStatus, "Loading CSVs", "please wait…")

				For Each _f As String In Directory.GetFiles(src_dir, "*.txt", SearchOption.TopDirectoryOnly)
					lstFile.Add(Path.GetFileName(_f).ToLower(), New ods.DataDataTable)
				Next

				Tasks.Parallel.ForEach(
					Directory.GetFiles(src_dir, "*.txt", SearchOption.TopDirectoryOnly),
					Sub(cf)
						Me.Invoke(writeStatus, "Loading CSVs", Path.GetFileName(cf) & ", please wait…")
						Dim _n As Int32 = 0
						Dim s As String() = Nothing
						_n = 0
						'''''''''''''
						'''''import/read txt file into temp db = lstFile
						'''''only col 1 - 7 is imported (ignore unnecessary col)
						'''''''''''''
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
				Dim mktff As Boolean = False


				Dim cmMktUpdate As OleDbCommand = cn.NewCommand("update MktSpec set C22=?,C23=? where rn=?")
				With cmMktUpdate.Parameters
					.Add("@c22", OleDbType.Double)
					.Add("@c23", OleDbType.Double)
					.Add("@rn", OleDbType.Integer)
				End With
				cmMktUpdate.Prepare()

				x.MktSpec.Load(cn.NewCommand("select * from MktSpec").ExecuteReader())
				fileNo = 0

				'loop each file in the directory to calculate info for RAR page
				'read one file, do calculation, put in a row in RAR page (there will be another loop inside)
				For Each f As String In Directory.GetFiles(src_dir, "*.txt", SearchOption.TopDirectoryOnly)
					'initilize new row for the file
					rmkt0 = Nothing
					Me.Invoke(writeStatus, f, "Calculating, please wait…")
					fileNo += 1
					fileName = Path.GetFileName(f)
					mktName = fileName
					mktff = False

					For Each tmp As ods.MktSpecRow In x.MktSpec.Rows
						'once find match exit for loop
						If tmp.c1.Trim.ToLower().Equals(fileName.ToLower()) Then
							mktName = fileName
							rmkt0 = tmp
							mktff = True
							Exit For
						End If
					Next
					rRar = x.RAR.NewRow()
					rRar.rn = fileNo
					rRar.F1 = fileName
					rRar.F2 = ""

					If rmkt0 Is Nothing Then
						x.RAR.Rows.Add(rRar)
						'MessageBox.Show("Cannot find contract specification for " & fileName & ".", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
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
                            If sd = 0 Then sd = 1
                            rRar.F3 = If(r > 0, r / sd, r * sd)
                        End If
                    Else
						'rRar.F3 = Double.NaN
						rRar.SetF3Null()
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
						'rRar.F4 = 0R
						rRar.SetF4Null()
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
							If Not rmkt1.Isc19Null() And rmkt1.c19 <> "" Then

								Dim cmict2 As Int32 = 1
								Dim cmi As Int32 = 0
								Dim necmi As Int32 = 0
								Dim ttdt As Int32 = 0

								If rmkt1.c1 = mktName Then Continue For

								For Each fx In Directory.GetFiles(src_dir, "*.txt", SearchOption.TopDirectoryOnly)
									'MessageBox.Show(rmkt1.c1.ToLower().Substring(0, 2), Path.GetFileNameWithoutExtension(fx).Substring(0, 2).ToLower())
									If Path.GetFileName(fx).ToLower().Equals(rmkt1.c1.Trim().ToLower()) Then
										ff = True
										Exit For
									End If
								Next
								If Not ff Then

									MessageBox.Show($"{rmkt1.c1} has open position, file not found!", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error)
									Continue For
								End If

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
											If rmkt1.c19.Trim().ToLower().StartsWith("b") Then bmktcmi = bmktcmi + cmi / ttdt * rmkt1.c21
											If rmkt1.c19.Trim().ToLower().StartsWith("s") Then smktcmi = smktcmi + cmi / ttdt * rmkt1.c21
										End If
									End If

									If necmi <> 0 Then
										If (necmi / ttdt) > 0.59 Then
											If rmkt1.c19.Trim().ToLower().StartsWith("b") Then smktcmi = smktcmi + necmi / ttdt * rmkt1.c21
											If rmkt1.c19.Trim().ToLower().StartsWith("s") Then bmktcmi = bmktcmi + necmi / ttdt * rmkt1.c21
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
				Dim rnk As Double = 0
				Dim avgRk As Int32 = 0
				Dim preRar As Decimal = 0
				Dim ernk As Int32 = 0

				For Each rRar In x.RAR.Select("", "f3 asc")
					If Not rRar.IsF3Null() Then
						If rnk = 0 Or preRar <> rRar.F3 Then
							rnk = rnk + ernk + 1
							ernk = 0
						Else
							ernk += 1
						End If
						rRar.F9 = rnk
						preRar = rRar.F3
					End If
				Next

				rnk = 0
				preRar = 0
				ernk = 0

				For Each rRar In x.RAR.Select("", "f4 asc")
					If Not rRar.IsF4Null() Then
						If rnk = 0 Or preRar <> rRar.F4 Then
							rnk = rnk + ernk + 1
							ernk = 0
						Else
							ernk += 1
						End If
						rRar.F10 = rnk
						preRar = rRar.F4
					End If
				Next

				For Each rRar In x.RAR.Select("", "f4 desc")
					If rRar.F2.Equals("") Then Continue For
					' F11 = # of rank, F12 = Alloc Wt
					If rRar.IsF4Null() Or rRar.IsF3Null() Then
						'rRar.F11 = 0R
						rRar.SetF11Null()
						rRar.F12 = 0.5
					Else
						rnk = (rRar.F9 + rRar.F10) / 2
						avgRk = ((rnk * 30) \ x.RAR.Rows.Count) + 1
						rRar.F11 = avgRk
						rRar.F12 = (0.0024 * (avgRk) ^ 3 - 0.0715 * (avgRk) ^ 2 + 0.7238 * avgRk + 18.07) / (0.0024 * 30 ^ 3 - 0.0715 * 30 ^ 2 + 0.7238 * 30 + 18.07)

					End If
					'F13 = # of contract
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
								ElseIf c.ColumnName.ToLower().Equals("_color") Then
									.Item("@" & c.ColumnName).Value = -1
								Else
									.Item("@" & c.ColumnName).Value = DBNull.Value
								End If
							Next

						Else
							' if MktSpec is found, insert all 
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
		oRefreshAllButton.Enabled = True
		oMktMciUpdateButton.Enabled = True

		Dim x As TimeSpan = DateTime.Now.Subtract(t_start)
		oStatus.Text = "Job completed at " & x.Hours.ToString().PadLeft(2, "0") &
			":" & x.Minutes.ToString().PadLeft(2, "0") & ":" &
			x.Seconds.ToString().PadLeft(2, "0")

		If em.Equals("") Then
			MessageBox.Show("Job completed successfully.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
			gvr.Refresh()
			oRefreshAllButton.PerformClick()
		Else
			MessageBox.Show(JOB_FAILED & em, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
		End If
	End Sub

	Private Sub oAddButton_Click(sender As Object, e As EventArgs) Handles oAddButton.Click
		Dim em As String = ""
		Using cn As New MsAccess
			Try

				cn.Open()
				cn.NewCommand("insert into MktSpec(rn) select max(rn) + 1 from MktSpec").ExecuteNonQuery()

				'gvm.BeginDataUpdate()
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
				'gvm.EndDataUpdate()

				Try
					gvm.Sort(gvm.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
					'gvm.DefaultCellStyle.SelectionForeColor = Color.White
					For i As Int32 = 0 To gvm.RowCount Step 1

						If IsDBNull(gvm.Rows(i).Cells(0).Value) Then
							gvm.ClearSelection()
							gvm.CurrentCell = gvm.Rows(i).Cells(0)
							gvm.BeginEdit(True)
							Exit For
						End If
					Next
				Catch ex As Exception
				End Try

			End Try
		End Using


		If em.Equals("") Then
		Else
			MessageBox.Show(JOB_FAILED & em, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
		End If

	End Sub

	Private Sub oDeleteButton_Click(sender As Object, e As EventArgs) Handles oDeleteButton.Click
		Dim em As String = ""
		' Get the currently selected row from the grid
		Dim currentRowView As DataRowView = TryCast(gvm.CurrentRow?.DataBoundItem, DataRowView)

		Using cn As New MsAccess
			Try
				cn.Open()
				If currentRowView Is Nothing Then Throw New Exception("No row selected.")
				Dim r As ods.MktSpecRow = TryCast(currentRowView.Row, ods.MktSpecRow)
				If r Is Nothing Then Throw New Exception("Unable to cast to MktSpecRow.")
				' Delete from the database
				With cn.NewCommand("delete from MktSpec where rn = ?")
					.Parameters.Add("@rn", OleDbType.BigInt).Value = r.rn
					.ExecuteNonQuery()
				End With

			Catch ex As Exception
				em = ex.Message
			Finally
				' If DB delete successfully, Delete the row from the DataTable
				currentRowView.Delete()

			End Try
		End Using


		If em.Equals("") Then
		Else
			MessageBox.Show(JOB_FAILED & em, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
		End If
	End Sub

	Private Sub gvm_SelectionChanged(sender As Object, e As EventArgs) Handles gvm.SelectionChanged
		Dim en As Boolean = (gvm.CurrentRow IsNot Nothing AndAlso Not gvm.CurrentRow.IsNewRow)
		oDeleteButton.Enabled = en
	End Sub

	Private Sub gvm_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles gvm.CellValueChanged ' get the row 
		' Get the row from the KryptonDataGridView
		Dim grid As KryptonDataGridView = CType(sender, KryptonDataGridView)
		If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then Exit Sub

		Dim rowView As DataRowView = TryCast(grid.Rows(e.RowIndex).DataBoundItem, DataRowView)
		If rowView Is Nothing Then Exit Sub

		Dim r As ods.MktSpecRow = CType(rowView.Row, ods.MktSpecRow)
		Dim colName As String = grid.Columns(e.ColumnIndex).DataPropertyName
		Dim newValue As Object = grid.Rows(e.RowIndex).Cells(e.ColumnIndex).Value

		Dim em As String = ""
		Using cn As New MsAccess
			Try
				cn.Open()
				Dim w As New System.Text.StringBuilder
				w.Append("update mktspec set ")
				w.Append(colName & " = ")
				If newValue Is DBNull.Value Then
					w.Append("null")
				Else
					Dim c As DataColumn = ds.MktSpec.Columns(colName)
					If c.DataType Is GetType(Double) Then
						Try
							Convert.ToDouble(newValue)
							w.Append(newValue)
						Catch
							w.Append(0)
						End Try
					ElseIf c.DataType.ToString().ToLower().StartsWith("system.int") Then
						Try
							Convert.ToInt32(newValue)
							w.Append(newValue)
						Catch
							w.Append(0)
						End Try
					Else
						w.Append("'" & newValue.ToString().Replace("'", "''") & "'")
					End If
				End If

				w.Append(" where rn = " & r.rn)

				cn.NewCommand(w.ToString()).ExecuteNonQuery()

				' --- NEW: Update c20/c21 if OP or c19 changed ---
				If colName = "c19" Then

					' Find matching RAR record
					Dim rrar As ods.RARRow = Nothing
					'Dim x As New ods()
					'Dim reader As OleDbDataReader = Nothing
					For Each tmp As ods.RARRow In ds.RAR.Rows
						If tmp.F1.Trim().Equals(r.c1.Trim(), StringComparison.OrdinalIgnoreCase) Then
							rrar = tmp
							Exit For
						End If
					Next
					''''''' if delete position, need to delete
					''''''' if add position , need to copy
					''''''' if wrong symbol, error message and delete 
					Dim eval As String = If(newValue IsNot Nothing, newValue.ToString().Trim().ToLower(), "")

					If rrar IsNot Nothing Then

						' if add "b" or "s" position
						If eval = "" OrElse (eval <> "b" AndAlso eval <> "s") Then
							If eval <> "" Then
								MessageBox.Show("Please input 'B' or 'S' values only.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
							End If
							' if delete position
							r.Setc19Null()
							r.Setc20Null()
							r.Setc21Null()
						Else
							' Update MktSpec with values from RAR
							r.c19 = eval.ToUpper()
							r.c20 = If(rrar.IsF12Null(), DBNull.Value, rrar.F13)
							r.c21 = If(rrar.IsF13Null(), DBNull.Value, rrar.F12)

						End If
						' Push changes to database
						' Add parameters safely
						Dim cmd As OleDbCommand = cn.NewCommand("UPDATE mktspec SET c19 = ?, c20 = ?, c21 = ? WHERE rn = ?")
						cmd.Parameters.AddWithValue("@c19", If(r.Isc19Null(), DBNull.Value, r.c19))
						cmd.Parameters.AddWithValue("@c20", If(r.Isc20Null(), DBNull.Value, r.c20))
						cmd.Parameters.AddWithValue("@c21", If(r.Isc21Null(), DBNull.Value, r.c21))
						cmd.Parameters.AddWithValue("@rn", r.rn)
						cmd.ExecuteNonQuery()
						' Refresh grid to show changes
						'gvm.RefreshRow(e.RowHandle)
					Else
						If Not String.IsNullOrEmpty(eval) Then
							r.Setc19Null()
							MessageBox.Show("No AllocWt Value is found in RAR", "AllocWt not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
							Dim cmd As OleDbCommand = cn.NewCommand("UPDATE mktspec SET c19 = ? WHERE rn = ?")
							cmd.Parameters.AddWithValue("@c19", If(r.Isc19Null(), DBNull.Value, r.c19))
							cmd.Parameters.AddWithValue("@rn", r.rn)
							cmd.ExecuteNonQuery()
						End If
					End If

				End If

			Catch ex As Exception
				em = ex.Message
			Finally

			End Try

		End Using

		If Not em.Equals("") Then MessageBox.Show(em, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
	End Sub


	Private Sub _gvo_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles gvo.CellValueChanged
		' Get the row from the KryptonDataGridView
		Dim grid As KryptonDataGridView = CType(sender, KryptonDataGridView)
		If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then Return

		Dim em As String = ""
		Using cn As New MsAccess
			Try
				cn.Open()
				Dim w As New System.Text.StringBuilder
				' Get the row from the grid
				Dim dgvRow As DataRowView = TryCast(grid.Rows(e.RowIndex).DataBoundItem, DataRowView)
				' Get the data item bound to this row, cast to your OptionsRow type
				Dim r As ods.OptionsRow = TryCast(dgvRow.Row, ods.OptionsRow)
				If r Is Nothing Then
					' Could not cast, maybe not bound properly
					Return
				End If

				' Get the column name (DataPropertyName)
				Dim colName As String = gvo.Columns(e.ColumnIndex).DataPropertyName

				' Get the new value from the cell
				'Dim newValue As Object = dgvRow.Cells(e.ColumnIndex).Value
				Dim newValue As Object = grid.Rows(e.RowIndex).Cells(e.ColumnIndex).Value

				w.Append("update [Options] set ")
				w.Append(colName & " = '" & newValue.ToString().Replace("'", "''") & "'") ' Escape single quotes
				w.Append(" where rn = " & r.rn)

				cn.NewCommand(w.ToString()).ExecuteNonQuery()

			Catch ex As Exception
				em = ex.Message
			Finally
				refreshColumnNames()
			End Try

		End Using
	End Sub


End Class
