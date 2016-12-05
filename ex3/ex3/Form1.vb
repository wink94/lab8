Imports System.IO
Public Class Form1

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Dim sale As Sales = New Sales
        'sale.getZipcodes_And_name()

        getDetailsByZipcodes()



    End Sub



    Public zipcodes(5) As String
    Public names(5) As String

    Function getDetailsByZipcodes() As Single

        Dim tempArr() As String
        Dim countCodes As Integer : countCodes = 0
        Dim codeTotal As Single

        ListBox1.Items.Clear()

        If File.Exists("myfile.txt") Then
            Dim sr As StreamReader = File.OpenText("myfile.txt")

            While sr.Peek <> -1

                tempArr = Split(sr.ReadLine(), " ")

                If countCodes = zipcodes.GetUpperBound(0) Then

                    ReDim Preserve zipcodes(zipcodes.Length + 5)

                Else

                    If checkIfExist(zipcodes, tempArr(0)) = False Then
                        zipcodes(countCodes) = tempArr(0)
                        countCodes += 1
                    End If

                End If


            End While

            sr.Close()

            For Each item As String In zipcodes

                If item Is Nothing Then
                    Exit For
                End If

                sr = File.OpenText("myfile.txt")
                codeTotal = 0

                While sr.Peek <> -1
                    tempArr = Split(sr.ReadLine(), " ")

                    If item = tempArr(0) Then
                        codeTotal += tempArr(2)
                    End If

                End While

                sr.Close()
                ListBox1.Items.Add(item + " " + CStr(codeTotal))

            Next


            Return codeTotal

        Else
            MessageBox.Show("file doesnt exist")
            Return -1
        End If

    End Function

    Function getDetailsByName() As Single

        Dim tempArr() As String
        Dim countNames As Integer : countNames = 0
        Dim nameTotal As Single = 0

        ListBox1.Items.Clear()

        If File.Exists("myfile.txt") Then
            Dim sr As StreamReader = File.OpenText("myfile.txt")

            While sr.Peek <> -1

                tempArr = Split(sr.ReadLine(), " ")



                If countNames = names.GetUpperBound(0) Then

                    ReDim Preserve names(names.Length + 5)

                Else
                    If checkIfExist(names, tempArr(1)) = False Then
                        names(countNames) = tempArr(1)
                        countNames += 1
                    End If

                End If

            End While

            sr.Close()

            For Each item As String In names

                If item Is Nothing Then
                    Exit For
                End If

                sr = File.OpenText("myfile.txt")
                nameTotal = 0

                While sr.Peek <> -1
                    tempArr = Split(sr.ReadLine(), " ")

                    If item = tempArr(1) Then
                        nameTotal += tempArr(2)
                    End If

                End While

                sr.Close()
                ListBox1.Items.Add(item + " " + CStr(nameTotal))

            Next

            Return nameTotal

        Else

            MessageBox.Show("file doesnt exist")
            Return -1

        End If

    End Function

    Function checkIfExist(temp() As String, value As String) As Boolean

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

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        getDetailsByName()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        If File.Exists("myfile.txt") Then

            Dim sr As StreamReader = File.OpenText("myfile.txt")
            Dim tempArr() As String
            Dim total As Single


            While sr.Peek <> -1

                tempArr = Split(sr.ReadLine(), " ")

                total += tempArr(2)

            End While

            MessageBox.Show("Total " + CStr(total))

        End If

    End Sub
End Class
