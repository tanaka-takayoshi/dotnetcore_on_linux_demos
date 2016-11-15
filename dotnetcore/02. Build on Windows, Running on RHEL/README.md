# Summary
.NET Core can build self-contained app, which can run on the OS without installing the .NET Core Runtime. Moreover, the binaries which is built on Windows can run on RHEL simply with copy files.

# Steps

1. Clone this repo on the Windows. Build with below command in this directory.

 ```
 > dotnet publish -f netcoreapp1.0 -c release -r rhel.7.2.-x64 
 ```
 
 NOTES: the point is runtimes in project.json
 
 ```
 "runtime": {
     "win10-x64": {},
     "rhel.7.2-x64": {}
 }
 ```

 [Dotnet doc](https://docs.microsoft.com/en-us/dotnet/articles/core/rid-catalog) listed all the available runtime Identifiers.

2. Transfer the files under ./bin/Debug/netcoreapp1.0/rhel7.2-x64/publish to RHEL

3. Execute with dotnet command.

 ```
 $ dotnet RHTE2016-self-contained-demo.dll
 ```
