#### Version: 0.0.0.10 Pre-Alpha (18.04.2020 16:00) "Sound System"
- Added Sound System
	- play music
	- walking sound of character
	- play dialog (e.g. the stone)
	- plays environment sounds
	- plays machine sounds
	
#### Version: 0.0.0.9 Pre-Alpha (12.04.2020 15:06) "Inventory"
- Added Inventory System
	- Open Inventory using "I"
	- Pickup Items in the scene with "E"
	- Left click items in the inventory to view details
	- Right click items for context actions (Use, Equip, Drop)
	- Carrying a high weight reduces your speed gradually (shown by weight capacity color turning into red)
	- Use the bottom right corner to sort after name, type and weight (ascending and descending)
- Added Heavy Interactables to test the weight speed reduction
- Added Interactables with different purposes

Minor Improvements:
- Dialogue Lines are now skipable with the space bar
- Dialogue Decisions are now selectable with the number keys ("1" for option 1, "2" for option 2, etc.)
- The time the a dialogue line is show is now scaled to the length of the line

#### Version: 0.0.0.8 Pre-Alpha (05.04.2020 20:22) "Dialogue System"
- Added the possibility to have a dialogue
	- The Dialogue System supports:
		- Presenting single lines
		- Presenting decisions 
		- Reacting differently on the players decisions	
- Added an interactable to start a Test Dialogue
- Also added the Test Dialogue ;-)

#### Version: 0.0.0.7 Pre-Alpha (29.03.2020 01:05) "Player HUD"
- Added Player UI: (HUD)
	- Added Player Health Bar
	- Added Compass and direction display
	- Added Debug Screen (Performance, Coordinates)
- Changed color and style of crosshair and interactor tooltips
- Added the old, updated Test Scene from 0.0.0.4:
	- Added objects for player health modification
	- Added various models
	- Updated the lighting
- Updated Pause Menu:
	- Updated Control Display
	- Added option to exit to main menu
- Overhauled Main Menu:
	- Added possibility to choose a scene to load
	- Updated design

Bug-fixes:
- Fixed that is was possible to jump up trees
- The mousecursor is now properly hidden during the game
- Its not possible anymore to jump underwater
- The game now pauses entirely when the pause menu is openend
- The Escape Key now also closes the menu
- The text that is shown while looking at an interactable is now properbly discarded when the player looks at another object
- The Ground of the Terrain Scene is not labeled as "Test Terrain" anymore

#### Version: 0.0.0.6 Pre-Alpha (17.03.2020 17:38) "Basic Player Model"
- Added a basic player Model
- Fixed all known bugs from the previous version

#### Version: 0.0.0.5 Pre-Alpha (25.11.2019 17:56) "Basic Terrain"
- Added a somewhat detailed demo map

#### Version: 0.0.0.4 Pre-Alpha (11.11.2019 10:59) "Menu"
- Added Basic Start Menu with "Start Game" and "Exit Game" buttons
																				Todo: Background Missing
- Added Game Menu with "Resume", "Controls" and "Exit" buttons
- Player can press key (Default = Escape) to open the game menu
- Added Controls Menu for controls showcase during the game with "Back" button
																				Todo: Options Menu
																				
#### Version: 0.0.0.3 Pre-Alpha (28.10.2019 11:46) "Interactions"
- Added Interaction functionality to world objects
- Player can press key (Default = E) to interact with objects
- Added crosshair to target objects
- When looking at an interactable object its name is shown below the crosshair
- Added two interaction behaviors
	- Texture/Material change on interact
	- Physics action on interact (jump up)

#### Version: 0.0.0.2 Pre-Alpha (15.10.2019 00:31) "Movement"
- Added multiple test objects to the world
	- block to jump on
	- slope bar to walk on
	- ball for physics test
- Added jump mechanics
- Added some fundamental physics
- Rewrote movement system to fit the new physics
- Rewrote cameraangle viewlock
- Removed sprinting
- Decreased walking/running speed
- Vertical movement is no longer faster than horizontal

#### Version: 0.0.0.1 Pre-Alpha (02.07.2019 21:52) "First Setup"
- Added Player Model and Script
	- Movement with Input Manager Keyboard
	- Camera and Body Rotation with Input Manager Mouse
- Added Ground Plane with Chess Texture
- Added toggle between walking/running
- Added sprinting
