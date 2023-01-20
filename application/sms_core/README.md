# SMS Core
- Core.api
    this is where we will be programming our API and giving it function.
- Core.lib
    this is the class library where our business logic will be programmed
    - DAL this folder will contain code relating to the data access layer
    - JWT this folder will contain our JWT Middleware 
    - mapper this folder will contain code relating to our mapper(s) which will relate our database entities and data transfer objects (DTO)
    - models this folder will contain all models we require
    - Services this folder will contain the code that will interact will the DBContext.
- Core.tests
    this is where we will test our business logic on a dummy db to make sure our logic is working and is sound