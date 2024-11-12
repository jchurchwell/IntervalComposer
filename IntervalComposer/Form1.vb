
Imports System.ComponentModel

Public Class Form1

    Dim threadStartEndSound As Threading.Thread
    Dim threadRunRecipe As Threading.Thread
    Dim threadSpeak As Threading.Thread

    Private Const MAX_TONES As Integer = 6
    Private Const SHORT_SOUND_TIME As Integer = 100
    Private Const LONG_SOUND_TIME As Integer = 750

    Private Const SHORT_SOUND_FREQ As Integer = 700
    Private Const LONG_SOUND_FREQ As Integer = 1400

    Private Const SLEEP_BETWEEN_DURATION As Integer = 1000

    Private Sub StartEndSound()

        Dim sTime As New Stopwatch

        sTime.Start()

        For i As Integer = 1 To MAX_TONES - 1
            Beep(SHORT_SOUND_FREQ, SHORT_SOUND_TIME)
            Threading.Thread.Sleep(SLEEP_BETWEEN_DURATION - SHORT_SOUND_TIME)
        Next

        Beep(LONG_SOUND_FREQ, LONG_SOUND_TIME)

        sTime.Stop()

    End Sub

    Public Sub RunRecipe()

        If recipeDict.Count = 0 Then Exit Sub

        Dim currentSet As NameValuePair
        Dim iTime As New Stopwatch
        Dim totalTime As New Stopwatch
        Dim startedSound As Boolean = False

        Dim iCounter As Long = 0

        totalTime.Start()

        ' Loop through all elements
        While recipeDict.Count > 0

            ' Get the next element
            currentSet = recipeDict.Dequeue()

            UpdateGridSelRow(Me.DataGridView1, iCounter)
            iCounter += 1

            ' Let the user know what exercise in an auditory way
            threadSpeak = New Threading.Thread(AddressOf Speak)
            threadSpeak.Start(currentSet.name)

            If currentSet.value <> 0 Then

                ' Update the label name
                UpdateLabel(Me.LabelName, currentSet.name)

                ' Make the progress bar max equal to the set wait time
                SetProgressMax(Me.ProgressBarSetTime, currentSet.value)

                ' Make sure we start the progress from zero
                UpdateProgress(Me.ProgressBarSetTime, currentSet.value)

                startedSound = False

                ' Count down the value
                iTime.Start()
                While iTime.ElapsedMilliseconds < (currentSet.value * 1000)
                    Threading.Thread.Sleep(10) ' Quarter of a second sleep

                    Dim timeRemain As Integer = currentSet.value - Fix(iTime.ElapsedMilliseconds / 1000) - 1
                    If timeRemain < 0 Then timeRemain = 0
                    UpdateLabel(Me.LabelTimeRemaining, timeRemain)
                    UpdateProgress(Me.ProgressBarSetTime, timeRemain)
                    UpdateProgress(Me.ProgressBarOverall, Int(totalTime.ElapsedMilliseconds / 1000) + 1)
                    ' If we have 5 seconds or less left play the sound
                    If (currentSet.value * 1000) - iTime.ElapsedMilliseconds <= MAX_TONES * 1000 AndAlso startedSound = False Then
                        startedSound = True
                        threadStartEndSound = New Threading.Thread(AddressOf StartEndSound)
                        threadStartEndSound.Start()
                    End If

                End While

            End If

            iTime.Stop()
            iTime.Reset()
        End While

    End Sub

    Public Sub UpdateLabel(lblBox As Label, lblValue As String)

        If lblBox.InvokeRequired Then
            lblBox.Invoke(Sub() UpdateLabel(lblBox, lblValue))
        Else
            lblBox.Text = lblValue
        End If

    End Sub

    Public Sub SetProgressMax(pBar As ProgressBar, max_val As Integer)

        If pBar.InvokeRequired Then
            pBar.Invoke(Sub() SetProgressMax(pBar, max_val))
        Else
            pBar.Maximum = max_val
        End If

    End Sub

    Public Sub UpdateProgress(pBar As ProgressBar, valProgress As Integer)

        If pBar.InvokeRequired Then
            pBar.Invoke(Sub() UpdateProgress(pBar, valProgress))
        Else
            If valProgress <= pBar.Maximum AndAlso valProgress >= pBar.Minimum Then pBar.Value = valProgress
        End If

    End Sub

    Public Sub UpdateGridSelRow(grd As DataGridView, rowSelect As Long)
        If grd.InvokeRequired Then
            grd.Invoke(Sub() UpdateGridSelRow(grd, rowSelect))
        Else
            If rowSelect >= 0 AndAlso grd.Rows.Count >= rowSelect Then
                grd.Rows(rowSelect).Selected = True
                grd.Rows(rowSelect).Visible = True
                grd.FirstDisplayedScrollingRowIndex = grd.SelectedRows(0).Index
            End If
        End If
    End Sub




    Dim timeStart As DateTime
    Private Sub ButtonStart_Click(sender As Object, e As EventArgs) Handles ButtonStart.Click

        If recipeToDictionary() = False Then Exit Sub

        ' Re-Set the progress bars
        Me.ProgressBarOverall.Value = 0
        Me.ProgressBarSetTime.Value = 0

        threadRunRecipe = New Threading.Thread(AddressOf RunRecipe)
        threadRunRecipe.Start()

        Me.ButtonStart.Visible = False
        Me.LabelName.Visible = True
        Me.LabelTimeRemaining.Visible = True

        'Me.GroupBoxRecipe.Enabled = False
        Me.DataGridView1.ReadOnly = True

        Me.ProgressBarOverall.Value = 0
        Me.ProgressBarOverall.Maximum = totalTime

        Me.Timer1.Enabled = True

    End Sub

    Public Sub ReSet()

        Me.DataGridView1.ReadOnly = False

        Me.ButtonStart.Visible = True

        Me.LabelName.Visible = False
        Me.LabelName.Text = ""

        Me.ProgressBarOverall.Value = 0
        Me.ProgressBarSetTime.Value = 0

    End Sub


    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        End
    End Sub

    Private Sub LoadRecipeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoadRecipeToolStripMenuItem.Click

        Me.OpenFileDialog1.Multiselect = False
        Me.OpenFileDialog1.InitialDirectory = Application.StartupPath
        Me.OpenFileDialog1.Filter = "Recipe Files|*.rec"
        Me.OpenFileDialog1.FileName = ""
        Me.OpenFileDialog1.ShowDialog()

        If Me.OpenFileDialog1.FileName = "" Then
            Exit Sub
        ElseIf Me.OpenFileDialog1.CheckFileExists() Then
            Load_Recipe(Me.OpenFileDialog1.FileName)
        End If

    End Sub

    Public recipeDict As Queue(Of NameValuePair)
    Public totalTime As ULong
    Public Class NameValuePair
        Public name As String
        Public value As Integer
    End Class

    ''' <summary>
    ''' Create a queue from the recipe
    ''' </summary>
    ''' <returns></returns>
    Private Function recipeToDictionary() As Boolean

        Dim iRow As DataGridViewRow
        Dim iNVP As NameValuePair

        recipeDict = New Queue(Of NameValuePair)

        totalTime = 0

        Try
            For Each iRow In Me.DataGridView1.Rows

                If iRow.Cells.Item(0).Value = Nothing Then Exit For

                iNVP = New NameValuePair
                iNVP.name = iRow.Cells.Item(0).Value.ToString
                iNVP.value = Int(iRow.Cells.Item(1).Value)

                If iNVP.name.ToUpper <> "REPS" Then
                    totalTime += iNVP.value
                Else
                    totalTime *= iNVP.value
                End If

                recipeDict.Enqueue(iNVP)

            Next
        Catch ex As Exception
            Return False
        End Try

        Return True

    End Function

    ''' <summary>
    ''' This will load a recipe from a *.rec file to the data grid
    ''' </summary>
    ''' <param name="strFilePath">This is the path to the recipe to load in</param>
    Private Sub Load_Recipe(strFilePath As String)

        Dim fileReader As New System.IO.StreamReader(strFilePath)
        Dim fileLine As String

        Dim iRow As DataGridViewRow
        Dim iCellName As DataGridViewCell
        Dim iCellValue As DataGridViewCell
        Dim arrSplit() As String

        ' Get the name of the file
        Dim fName As String = Strings.Mid(strFilePath, InStrRev(strFilePath, "\") + 1)
        Me.GroupBoxRecipe.Text = "Recipe - " + fName

        ' Make sure we clear out what was already there
        Me.DataGridView1.Rows.Clear()

        ' Loop through all the lines of the file
        While fileReader.EndOfStream = False

            ' Read the next line of the file
            fileLine = fileReader.ReadLine

            ' Split the line by comma delimiter
            arrSplit = fileLine.Split(",")

            ' Make sure we are looking at two elements since there are only 2 columns to import to
            If arrSplit.Length = 2 Then

                iRow = New DataGridViewRow ' Create a new row for the data

                ' Create a name cell as specified by the first element vallue
                iCellName = New DataGridViewTextBoxCell
                iCellName.Value = arrSplit(0)
                iRow.Cells.Add(iCellName)

                ' Create a value cell as specified by the second element value
                iCellValue = New DataGridViewTextBoxCell
                iCellValue.Value = arrSplit(1)
                iRow.Cells.Add(iCellValue)

                ' Add the row into the data grid view
                Me.DataGridView1.Rows.Add(iRow)

            End If

        End While

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        If threadRunRecipe.IsAlive = False Then
            ReSet()
            Me.Timer1.Enabled = False
        End If

    End Sub

    Private Sub Form1_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        End
    End Sub
End Class
