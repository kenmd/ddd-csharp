# DDD Overview

__Basic 3 Key Words__

* __Business objects__: Domain Model with some methods (not DTO)
  - `Entities`: mutable class with ID
  - `Value Objects`: immutable class without ID
* `Repositories`: retrieve and store __Business objects__ with DB
  - service use repository (not __Business objects__ use repository)
* `Services`: class to hold logic which doesn't belong to __Business objects__
  - __stateless__ business operation (not business objects)

__Additional Key Words__

* `Factories`: helper to create __Business objects__
* `Aggregates`: class to bind __Business objects__ when complex
* `Domain Events`: to communicate some business changes

__Example__

* `Entities`: snack machine (use money), customer (have address)
* `Value Objects`: money, point (x, y), address (state, city, street), date (ymd)
* `Services`: calc combining Business objects, save to DB/file using repository

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
  - No ID field (do not have its own table) => column in parent entity table
  - Immutable
  - life time belong to Entity - Money cannot live without SnackMachine

__Tips__

* if it looks like Integers, then it is Value Object
  - compared by each field values, treated interchangeably
* prefer Value Object to entity
  - try moving logic to Value Object as much as possible


## MVVM (Model View ViewModel)

* Model > `Domain layer` (Entity, Value Object), `Repositories`
* ViewModel > `Application Service layer` = Controller
  - wrapper of UI (transform Domain model for UI) => No business logic
* View > `UI layer` (by events and data binding)


## Repository

* Repositories encapsulate all communication with external storage
* here use Data Mapper pattern to map Domain Entity to database table
* suggestion from Martin Fowler (Patterns of Enterprise Application Architecture)
  - one repository per one aggregate
  - public API works with aggregate root only


## Problem Description

* 3 slots of snacks
* return the change
* check if inserted money is enough and the slot isn't empty
* check if there's enough change
