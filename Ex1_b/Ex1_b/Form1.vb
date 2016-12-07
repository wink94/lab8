
Imports Microsoft.VisualBasic.FileIO


Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim title, author, dates As String

        If TextBox1.Text <> "" And TextBox2.Text <> "" And TextBox3.Text <> "" Then

            title = TextBox1.Text
            author = TextBox2.Text
            dates = TextBox3.Text

            FileSystem.WriteAllText("myfile.txt", title + " " + author + " " + dates + vbNewLine, True)


            TextBox1.Clear()
            TextBox2.Clear()
            TextBox3.Clear()

        Else
            MessageBox.Show("empty input")

        End If



    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim arrSize As Integer = 10
        Dim arr(arrSize) As String
        Dim temp() As String
        Dim count As Integer = 0

        Dim source As TextFieldParser

        source = FileSystem.OpenTextFieldParser("myfile.txt", vbTab)

        While Not source.EndOfData
            arr(count) = source.ReadLine()
            count += 1

            If count = arr.GetUpperBound(0) Then
                ReDim Preserve arr(arr.Length + 5)
            End If

        End While



        Array.Sort(arr)

        'Dim sw As StreamWriter = File.CreateText("newfile.txt")

        For Each item As String In arr

            If String.IsNullOrEmpty(item) <> True Then
                FileSystem.WriteAllText("newfile.txt", item + vbNewLine, True)
            End If

        Next

        'sw.Close()
    End Sub




End Class
