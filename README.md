# webApiNetCore3

``` 
 mkdir webApiNetCore3
 cd ./webApiNetCore3
 dotnet new webapi -o WebApi --no-https true --auth None
 dotnet new xunit -o UnitTests
 dotnet new xunit -o IntegrationTests
```


``` 
 cd ./UnitTests
 dotnet build
 dotnet add package Microsoft.EntityFrameworkCore.InMemory --version 3.0.0
 dotnet add package Microsoft.AspNetCore.Mvc.Core --version 2.2.5
 dotnet add reference ../WebApi/WebApi.csproj
 dotnet build
```

``` 
 cd ../IntegrationTests
 dotnet build
 dotnet add package Microsoft.AspNetCore.Diagnostics --version 2.2.0
 dotnet add package Microsoft.AspNetCore.Mvc --version 2.2.0
 dotnet add package Microsoft.AspNetCore.Mvc.Core --version 2.2.5
 dotnet add package Microsoft.AspNetCore.TestHost --version 3.0.0
 dotnet add package Microsoft.Extensions.Configuration.Json --version 3.0.0
 dotnet add reference ../WebApi/WebApi.csproj
 dotnet build
```

``` 
 cd ../WebApi
 dotnet add package Microsoft.EntityFrameworkCore --version 3.0.0
 dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL --version 3.0.1
 dotnet add package Microsoft.EntityFrameworkCore.Design
```

after created models and dbContext execute commands below
``` 
 dotnet tool install --global dotnet-ef (if needed)
 dotnet ef migrations add InitialCreate
 dotnet ef database update
```