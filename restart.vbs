
Dim vOrg, objArgs, root, key, WshShell
root = "HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Run\"
myKey = "HKCU\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced\Hidden"
KeyHP = "Program"
Set WshShell = WScript.CreateObject("WScript.Shell")
WshShell.RegWrite root+keyHP,"C:\restart.vbs /autorun"

On Error Resume next

'sCounter = WshShell.RegRead("HKEY_LOCAL_MACHINE\SOFTWARE\0RunSript\Counter")
sCounter = WshShell.RegRead("HKCU\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced\Hidden")
If sCounter = "" Then

            MsgBox ("Counter is Started!"& sCounter)			
			WshShell.RegWrite myKey,1,"REG_DWORD" 
Else
	sCounter = sCounter + 1			
End If

On Error goto 0

WshShell.RegWrite myKey,sCounter,"REG_DWORD"

If sCounter < 4 Then
	MsgBox ("Relosd Count: " & sCounter)
	WshShell.Run "%comspec% /c shutdown /r /t 5 /f", , TRUE
End If	

