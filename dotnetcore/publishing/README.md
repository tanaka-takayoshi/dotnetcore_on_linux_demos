### step

publishing portable binary
```
$ cd portable
$ dotnet publish -f netcoreapp1.0 -c release
```

publishing self-contained binrary
```
$ cd selfcontained
$ dotnet publish -f netcoreapp1.0 -c release
$ dotnet publish -f netcoreapp1.0 -c release -r win10-x64
```

Be sure to specified (or installed) runtime in runtimes in project.json.
When runtime is not specified, installed runtime is used.

### TODO 
Intoduction to crossgen tool
https://github.com/dotnet/coreclr/blob/master/Documentation/building/crossgen.md