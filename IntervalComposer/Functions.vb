Module Functions

    Public Declare Function Beep Lib "kernel32" (ByVal dwFreq As Long, ByVal dwDuration As Long) As Long

    Public Sub Speak(txtToSay As String)
        Dim tts = CreateObject("SAPI.spvoice")
        tts.speak(txtToSay)
    End Sub

End Module
