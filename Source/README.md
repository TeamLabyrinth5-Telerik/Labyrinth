Documentation for Team Labyrinth 5 project                                                                                                                       
------------------------------------------------------

1. Redesigned the project structure Team Labyrinth 5.
	-  Renamed the project solution from `Code Quality – Project 1` to `Labyrinth`.
	-  Renamed the main class from `LabyrinthTest` to `LabyrinthMain`.
	-  Extracted each class in separate file with good names likes `Engine.cs`, `Initializer.cs`.
	-  Added new projects which contains logically related classes.
	-  `Labyrinth.Common` contains solutions constants in classes: `GameMessages.cs`, `GlobalConstants.cs`.
	-  `Labyrinth.Console` contains classes: `ConsoleInterface.cs`, `Console.Renderer`, `LabyrinthMain.cs` (entry point of the Labyrinth).
	-  `Labyrinth.Logic` contains game logic in classes: `Engine.cs`, `Initializer.cs`.
	-  `Labyrinth.Models` contains game elements in classes: `Grid.cs`, `Player.cs`, `Position.cs`, `Scoreboard.cs`.
	-  Extracted all Enumerations in folder with name `Enums`.
	-  Extracted all Interfaces in folder with name `Interfaces`.

2. Reformatted the source code:
	- Removed empty lines in `MakeAtleastOneExitReachable()`
	- Removed empty lines in `PrintScore()`
	- Inserted new lines between all methods.
	- Split lines containing several statements into several simple lines
	- Formatted the curly braces { and } according to the best practices for the C# language
	- Put { and } after all conditionals and loops 
	- Character casing: variables and fields named with camelCase; types and methods named with PascalCase
	- Formatted all other elements of the source code according to the best practices of the 'HQC' course

3. Renamed variables:
	- In class `GlobalConstants`:
		- from `sz` to `GridColsCount`.
		- from `px` to `StartPlayerPositionX`.
		- from `py` to `StartPlayerPositionY`.
	- In method `MakeAtLeastOneExitReachable()`:
		- from `num` to `randomIndex`.

4. Introduced project `Labyrinth.Common` with constants:
	- In class `GlobalConstants`:
		- `GridColsCount = 7`
		- `GridRowsCount = 7`
		- `StartPlayerPositionX = 3`
		- `StartPlayerPositionY = 3`
		- `BlockedCellSymbol = 'X'`
		- `FreeCellSymbol = '-'`
		- `PlayerSignSymbol = '*'`
		- `ExitCommand = "EXIT"`
		- `TopCommand = "TOP"`
		- `RestartCommand = "RESTART"`
		- `UpCommand = "U"`
		- `DownCommand = "D"`
		- `LeftCommand = "L"`
		- `RigthCommand = "R"`
		- `InvalidCommand = "Invalid command!"`
		- `MinimumPercentageOfBlockedCells = 30`
		- `MaximumPercentageOfBlockedCells = 50`
	- In class `GameMessages`:
	 	- `WelcomeMessage = "Welcome to “Labirinth” game. Please try to escape."`
		- `HowToPlayMessage = "Use 'top' to view the top scoreboard, 'restart' to start a new game and 'exit' to quit the game."`	
		- `InviteUserInputMessage = "Enter your move (L=left, R-right, U=up, D=down): "`
		- `WrongInputMessage = "Invalid command!"`
		- `WrongInputAndContinueMessage = "Invalid Command!\n**Press a key to continue**"`
		- `EnterNameMessage = "**Please put down your name:**"`
		- `WonGameMessage = "Congratulations! You've exited the labirynth in {0} moves."`
		- `EmptyScoreBoardMessage = "The scoreboard is empty."`

5. Introduced project `Labyrinth.Console`:
	- Moved class `LabyrinthTest` to `LabyrinthMain`.
	- Moved method `ExecudeCommand()` to `GetCommandFromInput()`.
	- Extracted method `GetUserInput()` from method `PlayGame()`.
	- Introduced method `ExitGame()`.

6. Introduced project `LabyrinthLogic`:
	- Introduced Class `Engine`.
		- Introduced method `UpdateScoreBoard()`.
		- Moved method `ExecuteCommand()` to `LabyrinthLogic`.
		- Extracted method `Run()` .
		- Extracted method `RestartGame()`.
		- Extracted method `SaveScore()`.
		- Extracted method `Move()`.
	- Introduced class `Initializer`.
		- Moved method `MakeAtLeastOneExitReachable()` to `Initializer`.
		- Moved method `IsGameOver()` to `Initializer`.
		- Moved method `IsInsideGrid()` to `Initializer`.
	
7. Introduced project `LabyrinthModels`:
	- Introduced class `Grid` to `LabyrinthModels`.
		- Extracted method `SetCell()`.
		- Extracted method `GetCell()`.
		- Introduced class `Player` to `LabyrinthModels`.
		- Introduced method `Position()` in class `Player`.
	- Introduced class `Position` to `LabyrinthModels`.
	- Introduced class `Scoreboard` to `LabyrinthModels`.
		- Introduced method `AddPlayer()`.
		- Introduced method `DeleteAllExceptTopPlayers()`.
		
8. Introduced project `LabyrinthTests`:
	- Introduced unit test class `TestGrid` with test methods:
		- `TestConstructorIfReturnValidRowLenth()` tests `TotalRows()` row count.
		- `TestConstructorIfReturnValidColLenth()` tests `TotalCols()` collumns count.
		- `TestSetCellMethodIfSetCurrectlyValue()` tests `SetCell()` method.
		- `TestGetCellMethodIfGetCurrectlyValue()` tests `GetCell()` method.
	- Introduced unit test class `TestPlayer` with test methods:
		- `TestPlayerConstructorIfReturnsValidNameState()` tests `Player()` default given name.
		- `TestPlayerConstructorIfReturnValidMovesState()` tests `MoveCount()` method.
		- `TestPlayerConstructorIfInputIsProvidedReturnsValidNameState()` tests `Player()` provided name.
		- `TestPlayerConstructorIfReturnValidInitialPositionX()` tests `Position()` X player position.
		- `TestPlayerConstructorIfReturnValidInitialPositionY()` tests `Position()` Y player position.
	- Introduced unit test class `TestScoreboard` with test methods:
		- `ShouldReturnZeroWhenHaveEmptyList()` tests the Scoreboard count.
		- `ShouldAddPlayerToList()` tests adding players to the Scoreboard.
		- `ShouldAddPlayerWithNameToList()` tests adding players with provided name to the Scoreboard.
9.	Implemented Patterns
	- Creational
		- Singleton [link](https://github.com/TeamLabyrinth5-Telerik/Labyrinth/blob/master/Source/Labirynth.Console/LabyrinthStarter.cs#L16), LabyrinthStarter
		- Object Pool - Werehouse Ninject.cs
	- Structural
		- Facade - LabyrinthStarter.cs and LabyrinthMain.cs
		- Bridge between IInitializer and IEngine
	- Behavioral
		- Memento [link](https://github.com/TeamLabyrinth5-Telerik/Labyrinth/blob/master/Source/Labirynth.Logic/LabyrinthEngine.cs#L397)
		- Strategy - LabyrinthEngine.ctor() IRenderer renderer, IUserInterface userInterface
10. Added unit tests
11. Code documented. Documentation exported to chm file.
12. New functionalities:
	- ```save``` and ```load``` game commands
	- ```howTo``` command for game options.
	- ```main menu with options``` 
13. HQC principles
	- *SOLID*:
		- *S*: small methods and classes, each with one concrete purpose
		- *O*: easy to add different engine / game initializer / renderer, different type of grid or player without modifying.
		- *L*: 
		- *I*: Small interfaces. Example: Logic.Interfaces 
		- *D*: Classes take dependencies in their constructors. No initializations inside. Using Ninject to handle dependencies, loosely-coupled, highly-cohesive.
	- *DRY*: Repeating logic extracted to methods so they can be reused.
	- *Abstraction* - passing interfaces instead of implementations. Different projects handle different parts of the game. Easy to introduce custom game logic. Easy to add a different Client. 