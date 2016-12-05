Imports System.IO

Public Class Form1

    Public filename As String

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        filename = InputBox("Enter file name ",)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim line As String
        Dim sw As StreamWriter = File.AppendText(Path.Combine("F:\2nd sem\VB.Net\151019V_Lab8\ex2\", filename + ".txt"))

        Static lineNum As Integer = 1

        If TextBox1.Text = "" Then
            line = vbNewLine

            sw.WriteLine(line)
            ListBox1.Items.Add(line)

            lineNum += 1
            lblLineNum.Text = "Enter line " + CStr(lineNum)
        ElseIf TextBox1.Text.Length <= 60 Then
            line = TextBox1.Text

            sw.WriteLine(line)
            ListBox1.Items.Add(line)

            lineNum += 1
            lblLineNum.Text = "Enter line " + CStr(lineNum)
        Else
            MessageBox.Show("invalid entry")
            TextBox1.Focus()
        End If



        sw.Close()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Close()
    End Sub




End Class
