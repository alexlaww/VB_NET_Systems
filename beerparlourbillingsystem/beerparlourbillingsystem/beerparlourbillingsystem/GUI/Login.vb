Imports System.Data.OleDb

Public Class Login
    Private Sub Login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Left = (Screen.PrimaryScreen.WorkingArea.Width - Me.Width) / 2
        Me.Top = (Screen.PrimaryScreen.WorkingArea.Height - Me.Height) / 2
    End Sub
    Private Sub login()
        Try
            sqL = "SELECT * FROM staff WHERE username = '" & txtUsername.Text & "' AND password ='" & txtPassword.Text & "'"
            ConnDB()
            cmd = New OleDbCommand(Sql, conn)
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)

            If dr.Read = True Then
                Me.Close()
                main.Show()
                MsgBox("Welcome", MsgBoxStyle.Information, "Login Report")
                main.menuExit.Enabled = True
                main.menuTool.Enabled = True
                main.menuTransactions.Enabled = True
                main.menuuser.Enabled = True
                main.menuview.Enabled = True
                main.toolmenuexit.Enabled = True
                main.toolmenulogout.Enabled = True
            Else
                MsgBox("Incorrect Username or Password", MsgBoxStyle.Exclamation, "Login")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cmd.Dispose()
            conn.Close()
        End Try
    End Sub
    Private Sub btnlogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnlogin.Click
        login()
    End Sub
End Class