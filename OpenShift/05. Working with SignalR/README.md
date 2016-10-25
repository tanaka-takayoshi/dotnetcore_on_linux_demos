**NOTE:**

This sample doesn't work due to upstream SignalR-Server issue. It has been already discussed by below issues.

- https://github.com/aspnet/SignalR-Server/issues/237
- https://github.com/dotnet/corefx/issues/12517
- https://github.com/dotnet/corefx/pull/12890
- https://github.com/dotnet/corefx/issues/9855

# Summary
SignalR is the Web Application framework for real time communication on ASP.NET Core. The original version is based on ASP.NET, but now ASP.NET Core version is available as preview version.

# Steps
deploy this repository to OpenShift.
```
$ oc new-app --template=aspnet-s2i -p GIT_URI=https://github.com/tanaka-takayoshi/rhte2016-apac-demo-dotnetcore -p GIT_CONTEXT_DIR="05. Working with SignalR" -p APPLICATION_NAME=<Your_Favorite_Name>
```