Imports System.IO

Structure Account
    Public accNum As Integer
    Public name As String
    Public balance As Integer

    Public Function isNull() As Boolean

    End Function

End Structure

Public Class Form1

    Private arrSize As Integer = 5
    Private accntArray(arrSize) As Account

    Private tempArr() As String


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click



        readAccFile()
        readTRANSFileAndWrite()
        Write()


    End Sub


    Sub readAccFile()

        Dim count As Integer = 0




        If File.Exists("myfile.txt") Then

            Dim sr As StreamReader = File.OpenText("myfile.txt")



            While sr.Peek <> -1
                tempArr = Split(sr.ReadLine(), " ")
                accntArray(count) = New Account()

                accntArray(count).accNum = tempArr(0)
                accntArray(count).name = tempArr(1)
                accntArray(count).balance = tempArr(2)
                count += 1

                If count = arrSize Then
                    ReDim Preserve accntArray(arrSize + 10)
                    arrSize += 10
                End If

            End While

            sr.Close()

        Else
            MessageBox.Show("File doesnt exist")


        End If


    End Sub

    Sub readTRANSFileAndWrite()



        Dim count As Integer = 0
        Dim deposit As Integer
        Dim withd As Integer
        Dim tempArr() As String


        If File.Exists("trans.txt") And File.Exists("myfile.txt") Then


            For count = 0 To accntArray.GetUpperBound(0)
                deposit = 0
                withd = 0

                If accntArray(count).name Is Nothing Then

                    Exit For

                End If

                Dim sr As StreamReader = File.OpenText("trans.txt")

                While sr.Peek <> -1

                    tempArr = Split(sr.ReadLine(), " ")

                    If accntArray(count).accNum = tempArr(0) Then
                        deposit += tempArr(1)
                        withd += tempArr(2)
                    Else
                        'Exit While

                    End If

                End While

                accntArray(count).balance += (deposit - withd)
                sr.Close()

            Next

        End If

    End Sub

    Sub Write()

        If File.Exists("myfile.txt") Then

            File.Delete("temp.txt")

            Dim sw As StreamWriter = File.AppendText("temp.txt")


            For count As Integer = 0 To accntArray.GetUpperBound(0)

                If accntArray(count).name Is Nothing Then
                    Exit For
                Else
                    sw.WriteLine(CStr(accntArray(count).accNum) + " " + accntArray(count).name + " " + CStr(accntArray(count).balance))

                End If

            Next

            sw.Close()

            File.Delete("myfile.txt")
            File.Move("temp.txt", "myfile.txt")


        End If


    End Sub

End Class






