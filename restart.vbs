Dim oShell 
Set oShell = CreateObject("WScript.Shell")

i=0
do until i=3
oShell.Run "%comspec% /c shutdown /r /t 5 /f", , TRUE
i=i+1
loop