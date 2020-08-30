# DDD in C# Starter

Illustrative prototype of basic DDD pattern using C#

* based on "Domain-Driven Design in Practice"
  - https://www.pluralsight.com/courses/domain-driven-design-in-practice
* Changed above to use Data Mapper pattern instead of Hibernate
* combined "Data Mapper (C#) - PATTERNS OF ENTERPRISE ARCHITECTURE"
  - https://www.youtube.com/watch?v=7noMLStHcTE&list=PLA8ZIAm2I03iN7WAz5DFRMiq5VEYWBhyB&index=7


## Build and Run

```bash
dotnet restore
dotnet build

# checkout local-database repository
# start local db in local-mssql
# and run flyway migrate in flyway-mssql
dotnet test
```


## Initial Project Setup

* install Visual Studio for Mac Community
* File > New Solution > Multiplatform > .Net Standard Library
  - Target Framework: .Net Standard __2.0__
  - note __2.0__ is important to be compatible with core 3.1
* right click solution (master) > Add > New Project
  - select Web and Console > Tests > xUnit Test Project
  - this will use .Net Core 3.1
* right click test project > Add > Reference...
  - select main project
* Build > Build All


## Reference

* difference between .NET Core and .NET Standard Class Library
  - https://stackoverflow.com/questions/42939454
* .NET Standard versions (shows .Net Standard 2.0 have good coverage)
  - https://dotnet.microsoft.com/platform/dotnet-standard#versions
* How to create .NET Standard class library
  - https://www.buildinsider.net/language/dotnetcore/05
