
# bower
install Visual Studio Code Extension https://github.com/DonJayamanne/bowerVSCode
> F1 > bower > init
> F1 > bower > install

# ef

The exsiting migration file is available. If you'd like to reset and create from empty, please execute below command.

```
$ dotnet restore
$ dotnet ef migrations add Second
```

**Note:**
After created migraion file ``YYYYMMDDHHmmSS_initial.cs``,  add Npgsql annotation in Id column. This is the npgsql limitation. See [this issue](https://github.com/npgsql/Npgsql.EntityFrameworkCore.PostgreSQL/issues/86).

```csahrp
Id = table.Column<int>(nullable: false)
    .Annotation("Autoincrement", true)
    .Annotation("Npgsql:ValueGeneratedOnAdd", true), //add thie line
```

# Deploy to OpenShift

```
$ oc new-app --template=postgresql-ephemeral -p DATABASE_SERVICE_NAME=postgresql,POSTGRESQL_USER=user,POSTGRESQL_PASSWORD=p@ssw0rd,POSTGRESQL_DATABASE=todo
$ oc new-app --template=aspnet-s2i -p APPLICATION_NAME=simpletodo,GIT_URI=https://github.com/tanaka-takayoshi/dotnetcore_on_linux_demos.git,GIT_REF=development,GIT_CONTEXT_DIR="OpenShift/03. Working With DB" -l app=simpletodo
$ oc env dc simpletodo ASPNETCORE_ENVIRONMENT=Production
```