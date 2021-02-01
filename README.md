# Overview

This repository contains a demo service that acts as a sub-domain for content management. It is built to illustrate how Clean Architecture and Domain Driven Design can produce highly testable, highly maintainable code.

# Driving Principles

## Clean Architecture

[Microsoft Documentation|https://docs.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/common-web-application-architectures#clean-architecture]
[Jason Taylor Presentation|https://www.youtube.com/watch?v=dK4Yb6-LxAk]

## Domain Driven Design

[Microsoft Documentation|https://docs.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/]
[A Great Intro to DDD by Eric Evans|https://www.youtube.com/watch?v=pMuiVlnGqjk]
[Domain Language|https://www.domainlanguage.com/]

# Further Reading

[Mediatr|https://github.com/jbogard/MediatR] is used heavily to facilitate CQRS within the code. It's recommended that you are familiar with the library before diving into the code.

# Future Ideas / Possible Improvements

- Configure the service to use Service Foundation
- Setup a SQLite database, along with a starting migration script, so that we can run the server
- We still need to bootstrap the API (i.e. configure DI for mediatr)
- Setup a worker project to demo asynchronous jobs
- Add integration tests, once the above is complete
