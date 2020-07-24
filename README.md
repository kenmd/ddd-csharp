# DDD in C#

* Domain-Driven Design in Practice
  - https://www.pluralsight.com/courses/domain-driven-design-in-practice


## DDD Overview

__Main Concepts of DDD__

* `Ubiquitous language`: bridges the gap between experts and developers
* `Bounded context`: clear boundaries between different parts of the system
* `Core domain`: focus on the most important part of the system

__DDD Layers__

1. Entities, Value Object, Domain Events and Aggregates
2. Repositories, Factories and Domain Service
3. Application Service
4. UI

__Entity vs Value Object__

* Entity (SnackMachine) : Identifier equality (and Reference equality)
  - Have ID field (have table)
  - Mutable
  - act as a wrapper of Value Object
* Value Object (Money): Structural equality (and Reference equality)
  - No ID field (do not have its own table)
  - Immutable
  - belong to Entity - Money cannot live without SnackMachine

__Tips__

* if it looks like Integers, then it is Value Object
  - compared by each field values, treated interchangeably
* prefer Value Object to entity
  - try moving logic to Value Object as much as possible


## Build and Run

```bash
dotnet restore
dotnet build
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
