# ackbar - GameGuide main server application

<img src="ackbar-small.jpg"
 alt="Picture of Admiral Ackbar" title="Admiral Ackbar"
 align="right" />

> "It's a trap!"   
> Admiral Ackbar

GameGuide is a web platform that suggests games based on the user's liked and disliked games.
Written as the final graduation project in IS school, due to the end of 2018.

Handles GameGuide's Single Page Application, [Miek](https://github.com/thiagoandf/Miek)'s API calls and database interaction.
Written in C# with ASP.NET Core. Architecture freely based on Uncle Bob's [Clean Architecture](http://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html).

## Usage
```bash
docker-compose up
```

## Todo

- Get SQL Server up and running
- Add first game, user and player interactions for MVP
- Setup test project
- Setup CI and CD with Azure
