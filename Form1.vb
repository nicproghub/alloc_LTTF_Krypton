
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
	Private Const save_html As String = "HTML File|*.html"

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


End Class
