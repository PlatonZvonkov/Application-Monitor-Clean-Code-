# Application-Monitor-Clean-Code-
My Windows util. that i use to monitor target apps and terminates it after appointed time.

Console app is to be launch through windows Task's with arguments: 1) target application "-name.exe" 2) termination timer in -minutes 3) frequency in -minutes

Arguments of name, process lifetime, and check frequency can be passed through creating shortcuts and adding 3 lines after "monitor.exe" in "Target" field.

Application logs information in /logs folder about the activity of the targeted process.

Code convention is according to Microsoft guidelines.
