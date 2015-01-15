#Best Practices Sample Project

This sample project aims to showcase some best practices when designing and unit testing a Visual Studio web application.

1. [Repository/Service Pattern](#repositoryServicePattern)
2. [Unit Testing With Moq](#unitTestingWithMoq)

## <a name="repositoryServicePattern"></a>Repository/Service Pattern

The repository/service pattern helps adds a layer of abstraction between the controllers and the database contexts. The repository creates a generic storage interface so you can easily swap out a SQL database with a MongoDB database. The service layer defines how your application will actually interact with the repository. A service layer may not even reference the repository directly; n-tier architecures benefit from the service layer by allowing you to swap out a repository with a web service (which would then use the repository service).

## <a name="unitTestingWithMoq"></a>Unit Testing With Moq

Unit testing serves several purposes, only some of which can be covered in here. Ensuring the code works is only one part. If you have a hard time creating tests for a certain piece of code, then there is a good chance it isn't adhering to the single responsibility principle, or it may have a very high level of dependency on other parts of the code. 

Code that invokes network, file, or database calls should not be unit tested; that would be integration testing, which can be seen as the opposite of unit testing. Unit tests ensure proper behavior in isolation, while integration tests ensure proper behavior as it interacts with other components.