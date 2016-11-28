Imports System.IO

Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim acc As Acc2 = New Acc2

        acc.readAccFile()
        acc.readTRANSFile()
        acc.calculateAndWrite()


    End Sub
End Class

Class Acc
    Public accNum As Integer
    Public name As String
    Public bal As Integer
End Class



Class Acc2
    Private arrSize As Integer = 10
    Public accntArray(arrSize) As Acc

    Private tempArr() As String


    Sub readAccFile()

        Dim count As Integer = 0




        If File.Exists("myfile.txt") Then
            Dim sr As StreamReader = File.OpenText("myfile.txt")



            While sr.Peek <> -1
                tempArr = Split(sr.ReadLine(), " ")
                accntArray(count) = New Acc()

                accntArray(count).accNum = tempArr(0)
                accntArray(count).name = tempArr(1)
                accntArray(count).bal = tempArr(2)
                count += 1

                If count = arrSize Then
                    ReDim Preserve accntArray(arrSize + 10)
                    arrSize += 10
                End If

            End While

            sr.Close()
        End If
    End Sub

    Sub readTRANSFile()



        Dim count As Integer = 0
        Dim deposit As Integer
        Dim withd As Integer
        Dim tempArr() As String


        If File.Exists("trans.txt") And File.Exists("myfile.txt") Then


            For Each acc As Acc In accntArray
                deposit = 0
                withd = 0

                If acc Is Nothing Then

                    Exit For
                End If
                Dim sr As StreamReader = File.OpenText("trans.txt")
                While sr.Peek <> -1

                    tempArr = Split(sr.ReadLine(), " ")

                    If acc.accNum = tempArr(0) Then
                        deposit += tempArr(1)
                        withd += tempArr(2)
                    Else
                        'Exit While

                    End If

                End While

                acc.bal += deposit - withd
                sr.Close()
            Next

        End If

    End Sub

    Sub calculateAndWrite()

        If File.Exists("temp.txt") Then

            File.Delete("temp.txt")

            Dim sw As StreamWriter = File.AppendText("temp.txt")

            For Each item As Acc In accntArray
                If item Is Nothing Then
                    Exit For
                Else
                    sw.WriteLine(CStr(item.accNum) + " " + item.name + " " + CStr(item.bal))

                End If

            Next

            File.Delete("myfile.txt")
            File.Move("temp.txt", "myfile.txt")


        End If


    End Sub

End Class






