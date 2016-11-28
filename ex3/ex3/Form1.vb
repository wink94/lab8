Imports System.IO
Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim sale As Sales = New Sales
        sale.getZipcodes_And_name()


    End Sub

    Class Sales

        Public zipcodes As List(Of String)
        Public names As List(Of String)

        Sub getZipcodes_And_name()

            Dim tempArr() As String

            If File.Exists("myfile.txt") Then
                Dim sr As StreamReader = File.OpenText("myfile.txt")

                While sr.Peek <> -1
                    tempArr = Split(sr.ReadLine(), " ")
                    If checkIfExist(zipcodes, tempArr(0)) = False Then
                        zipcodes.Add(tempArr(0))
                    End If
                    If checkIfExist(names, tempArr(1)) = False Then
                        zipcodes.Add(tempArr(1))
                    End If

                End While

            End If

        End Sub

        Sub byName()
            Dim total As Integer
            Dim tempArr() As String
            Dim tempstr As String
            If File.Exists("myfile.txt") Then
                total = 0
                For Each item As String In zipcodes
                    Dim sr As StreamReader = File.OpenText("myfile.txt")

                    While sr.Peek <> -1
                        tempArr = Split(sr.ReadLine(), " ")
                        If item = tempArr(0) Then
                            total += tempArr(2)
                        End If
                    End While


                Next

                tempstr = tempArr + " " + total
                ListBox1.Items.Add(tempstr)

            End If
        End Sub

        Function checkIfExist(temp As List(Of String), value As String) As Boolean

            If temp Is Nothing Then
                Return False
            End If

            For Each item As String In temp
                If item = value Then
                    Return True
                End If
            Next

            Return False

        End Function


    End Class

End Class
