# Summary
[The Visual Studio MI Debug Engine](https://github.com/Microsoft/MIEngine) provides an open-source Visual Studio Debugger extension that works with MI-enabled debuggers such as gdb, lldb, and clrdbg. We can remote debug from Visual Studio to remote .NET Core process running on Linux or MaxOSX. It's called "offroad debugging". Please see the below posts.

https://github.com/Microsoft/MIEngine/wiki/Offroad-Debugging-of-.NET-Core-on-Linux---OSX-from-Visual-Studio
http://developers.redhat.com/blog/2016/09/06/debugging-net-on-rhel-from-visual-studio/

# Steps
1. Install Visual Studio with 'Cross Platform Mobile Development->Visual C++ Mobile Development->Visual C++ iOS Development'.
2. setup ssh connection from Windows to target Linux machine.
3. build this project with pdb files.
4. Transfer the binaries to target Linux machine.
5. Launch the app. Thr process won't be terminated because it waits for Console input.
 ```
 $ dotnet RemoteDebuggingApp.dll
 $ ps aux | grep dotne[t]
 ```
 
6. On the Windows machine, locate the attachprocess.xml and replace the values as your environment.
7. Start debugging. Open "Command Window" View on the Visual Studio and execute below command.

 ```
 > Debug.MIDebugLaunch /Executable:dotnet /OptionsFile:<attachprocess.xml>
 ```
 
