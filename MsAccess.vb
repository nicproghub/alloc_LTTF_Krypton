Imports System.Data.OleDb

Public NotInheritable Class MsAccess
	Implements IDisposable

#Region "IDisposable Support"
	Private disposedValue As Boolean ' To detect redundant calls

	' IDisposable
	Protected Sub Dispose(ByVal disposing As Boolean)
		If Not Me.disposedValue Then
			If disposing Then
				Rollback()
				If cn.State <> ConnectionState.Closed Then cn.Close()
				cn.Dispose()
				cn = Nothing
			End If
		End If
		Me.disposedValue = True
	End Sub


	'Protected Overrides Sub Finalize()
	'    ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
	'    Dispose(False)
	'    MyBase.Finalize()
	'End Sub

	' This code added by Visual Basic to correctly implement the disposable pattern.
	Public Sub Dispose() Implements IDisposable.Dispose
		' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
		Dispose(True)
		GC.SuppressFinalize(Me)
	End Sub
#End Region

	Private cn As OleDbConnection = Nothing
	Private tx As OleDbTransaction = Nothing

	Friend ReadOnly Property ConnectionString
		Get
			Return cn.ConnectionString
		End Get
	End Property

	Public Sub New()
		cn = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=app.mdb;")
	End Sub


	Public Sub Open()
		If cn.State <> ConnectionState.Open Then cn.Open()
	End Sub

	Public Sub Close()
		If cn.State <> ConnectionState.Closed Then cn.Close()
	End Sub

	Public Sub BeginTransaction()
		If tx Is Nothing Then tx = cn.BeginTransaction()
	End Sub
	Public Sub Commit()
		If tx IsNot Nothing Then
			tx.Commit()
			tx.Dispose()
			tx = Nothing
		End If
	End Sub
	Public Sub Rollback()
		If tx IsNot Nothing Then
			tx.Rollback()
			tx.Dispose()
			tx = Nothing
		End If
	End Sub

	Public Function NewCommand() As OleDbCommand
		Return NewCommand("")
	End Function
	Public Function NewCommand(ByVal tSql As String) As OleDbCommand
		Return New OleDbCommand(tSql, cn, tx)
	End Function


End Class
