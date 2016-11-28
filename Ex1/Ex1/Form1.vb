Imports System.IO

Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim title, author, dates, temp As String

        If TextBox1.Text <> "" And TextBox2.Text <> "" And TextBox3.Text <> "" Then

            title = TextBox1.Text
            author = TextBox2.Text
            dates = TextBox3.Text

            If File.Exists("myfile.txt") Then

                Dim sw As StreamWriter = File.AppendText("myfile.txt")
                temp = title + " " + author + " " + dates
                sw.WriteLine(temp)
                sw.Close()

                TextBox1.Clear()
                TextBox2.Clear()
                TextBox3.Clear()

            Else

                Dim sw As StreamWriter = File.CreateText("myfile.txt")
                temp = title + " " + author + " " + dates
                sw.WriteLine(temp)
                sw.Close()

                TextBox1.Clear()
                TextBox2.Clear()
                TextBox3.Clear()

            End If

        Else
            MessageBox.Show("empty input")

        End If



    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim arrSize As Integer = 10
        Dim arr(arrSize) As String

        If File.Exists("myfile.txt") Then

            Dim count As Integer = 0

            Dim sr As StreamReader = File.OpenText("myfile.txt")

            While sr.Peek <> -1
                arr(count) = sr.ReadLine()
                count += 1

                If count = arrSize Then
                    ReDim Preserve arr(arrSize + 10)
                    arrSize += 10
                End If

            End While

        End If

        Array.Sort(arr)
        Dim sw As StreamWriter = File.CreateText("newfile.txt")
        For Each item As String In arr

            If String.IsNullOrEmpty(item) <> True Then
                sw.WriteLine(item)
            End If

        Next
        sw.Close()
    End Sub

    Sub sortNwrite(ByRef array() As String)



    End Sub


End Class
