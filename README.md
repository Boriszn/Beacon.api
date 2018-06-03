# Beacon.Api

Solution demonstrate usage of [CQRS](https://martinfowler.com/bliki/CQRS.html) pattern.

Also demonstrate how to:

- Connect different application layers (in current example connected Business Layer and Data Access Layer)
- Overall usage of ([Mediator Pattern](http://www.dofactory.com/net/mediator-design-pattern))

## Future plans

The example will grow to full CQRS architecture based system

#### Architecture

![alt text](https://raw.githubusercontent.com/Boriszn/Beacon.api/feature/BA-4-add-mongodb-integration/assets/img/architecture-diagramm.png "Logo Title Text 1")

## Installation

1. Clone repository
2. Run UnitTests. (tests in progress)
3. Build / Run.

## Contributing

1. Fork it!
2. Create your feature branch: `git checkout -b my-new-feature`
3. Commit your changes: `git commit -am 'Add some feature'`
4. Push to the branch: `git push origin my-new-feature`
5. Submit a pull request

## Dependencies

- [MediatR component](https://github.com/jbogard/MediatR)
- [Mongo .net core driver](https://mongodb.github.io/mongo-csharp-driver/)
- [Swagger Swashbuckle](https://github.com/domaindrivendev/Swashbuckle)

## History

All changes can be easily found in [RELEASENOTES](ReleaseNotes.md)

## License

This project is licensed under the MIT License
