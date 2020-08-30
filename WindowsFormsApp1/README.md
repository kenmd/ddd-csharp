# DDD sample remix in C#

* this is C# Domain Driven Design simple starter project
  - based on https://anderson02.com/ddd-menu/
* includes 3 app projects and 2 test projects
  - `Domain`: entities, value objects, repository interface, helpers etc.
  - `Infrastructure`: repositories
  - `WindowsFormsApp1`: view models, forms
* using advocated onion structure by one way dependency of each projects


## Setup from dotnet cli

```ps1
# after git clone this repo
dotnet restore
dotnet build
dotnet test
```


## Run App

* open the solution file from Visual Studio (Community is fine)
* push the `Run` button
