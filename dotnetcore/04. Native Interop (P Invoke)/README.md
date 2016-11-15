# Summary
P/Invoke enables managed code to call a native function in DLL (Dynamic Link Library). .NET Core have no GUI libary but we can call GUI library such as gtk3 with P/Invoke with .NET Core on Linux. See below posts in detail.

[P/Invoke in .NET Core on Red Hat Enterprise Linux](http://developers.redhat.com/blog/2016/09/14/pinvoke-in-net-core-rhel/)

# Steps
```
$ sudo yum install gtk3-devel
$ dotnet restore
$ dotnet run
```
