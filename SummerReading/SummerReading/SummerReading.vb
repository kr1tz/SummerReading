Public Class MainForm

    Private TotalReadersInteger As Integer
    Private TotalBooksInteger As Integer

    Private Function BonusFunction(ByVal NumOfBooksInteger As Integer) As Integer
        'Calculating the bonus points for the books.

        Select Case NumOfBooksInteger
            Case 1 To 3
                BonusFunction = 10 * NumOfBooksInteger
            Case 4 To 6
                BonusFunction = 30 + 15 * (NumOfBooksInteger - 3)
            Case Is >= 7
                BonusFunction = 75 + 20 * (NumOfBooksInteger - 6)
        End Select


    End Function



    

    Private Sub PointsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PointsToolStripMenuItem.Click

        Dim NumOfBooksInteger As Integer
        Dim MessageString As String



        Try
            NumOfBooksInteger = Integer.Parse(NumBooksTextBox.Text)

            If NumOfBooksInteger > 0 Then
                'Calculate the bonus
                BonusTextBox.Text = BonusFunction(NumOfBooksInteger).ToString()

                TotalBooksInteger += NumOfBooksInteger
                TotalReadersInteger += 1
            Else
                MessageString = "The number of books must be greater than zero."
                MessageBox.Show(MessageString, "Input Error", MessageBoxButtons.OK)

                With NumBooksTextBox
                    .SelectAll()
                    .Focus()
                End With

            End If

        Catch BooksException As FormatException
            MessageString = "You must input a number for the number of books read."
            MessageBox.Show(MessageString, "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            With NumBooksTextBox
                .SelectAll()
                .Focus()
            End With

        Catch AnException As Exception
            MessageBox.Show("Error: " & AnException.Message)
        End Try






    End Sub

    Private Sub SummaryToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SummaryToolStripMenuItem.Click

        'Find the average number of books read
        Dim MessageString As String
        Dim AvgBooksDecimal As Decimal

        If TotalBooksInteger > 0 Then
            AvgBooksDecimal = Convert.ToDecimal(TotalBooksInteger / TotalReadersInteger)
            MessageString = "Average Number of Books Read: " & AvgBooksDecimal.ToString("N2")
            MessageBox.Show(MessageString, "Summary", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else

            MessageString = "No data to summarize"
            MessageBox.Show(MessageString, "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If


    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ExitToolStripMenuItem.Click

        Me.Close()

    End Sub



    Private Sub ClearToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ClearToolStripMenuItem.Click

        NameTextBox.Clear()
        NumBooksTextBox.Clear()
        BonusTextBox.Clear()

    End Sub

    Private Sub FontToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles FontToolStripMenuItem.Click

        With FontDialog
            .ShowDialog()
            NameTextBox.Font = .Font
        End With

        With FontDialog
            .ShowDialog()
            NumBooksTextBox.Font = .Font
        End With




    End Sub

    Private Sub ColorToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ColorToolStripMenuItem.Click

        With ColorDialog
            .ShowDialog()
            NameTextBox.ForeColor = .Color
        End With

        With ColorDialog
            .ShowDialog()
            NumBooksTextBox.ForeColor = .Color
        End With


    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AboutToolStripMenuItem.Click

        MessageBox.Show("Programmed By: Kris Trinidad", "Summer Reading Program", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub
End Class
