# ackbar - GameGuide main server application

<img src="ackbar-small.jpg"
 alt="Picture of Admiral Ackbar" title="Admiral Ackbar"
 align="right" />

> "It's a trap!"   
> Admiral Ackbar

GameGuide is a web platform that suggests games based on the user's liked and disliked games.
Written as the final graduation project in IS school, due to the end of 2018.

Handles GameGuide's Single Page Application [Miek](https://github.com/thiagoandf/Miek)'s API calls, admin pages and database interaction.
Written in C# with ASP.NET Core.

## Usage
```bash
docker-compose up
```

## Todo

### High priority
- Setup deploy
- Finish integration with Miek
- Handle admin scaffolding
- Placeholder algorithm

### Low priority
- Enforce auth in admin
- Setup test project
- Refactor Ackbar into several projects
- Maybe CI pipeline, then? Who knows when I'll get down here
