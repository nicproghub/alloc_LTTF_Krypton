
Imports System.ComponentModel
Imports System.Data.OleDb
Imports System.IO
Imports System.Net
Imports DevExpress
Imports DevExpress.XtraEditors
Imports System.Threading
Imports System.Text.RegularExpressions
Imports System.Web
Imports ComponentFactory.Krypton.Toolkit
Public Class Form1
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
	'Dim connectionString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Path\To\YourDatabase.accdb;"
	Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		'gvm.SuspendLayout()
		'gvm.DataSource = GetDataTableFromDB()
		'Dim odsTableAdapter As New YourDataSetTableAdapters.YourTableTableAdapter()
		'Dim ta As New odsTableAdapter()
		'Dim ds As New ods()
		'ta.Fill(ds.Options)
		'gvo.DataSource = ds.Options
		'gvm.ResumeLayout()

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
			End Try

		End Using
		If em.Equals("") Then
			refreshColumnNames()
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
				'colF3.Caption = "RAR " & vbCrLf & dt.Rows.Find("RAR1")("c2")
				'colF4.Caption = "RAR " & vbCrLf & dt.Rows.Find("RAR2")("c2")
				'colF5.Caption = "$ ATR[x]" & vbCrLf & dt.Rows.Find("ATR")("c2")
			Catch ex As Exception
			End Try
		End Using
	End Sub


End Class
