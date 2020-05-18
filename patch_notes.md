#### Version 0.0.0.11.2 Pre-Alpha (18.05.2020 16:38) "Combat System Setup"
- Added a basic setup for the combat system with some features still missing
- Added Hitboxes and the possibility to hit them
	- With a Left Mouse Click you can hit the different areas on the TestDolls 
		- The Hitboxes are: Head, Torso, Arm, Leg
	- A hit deals a different amount of damage depending on which hitbox you hit
	- There are combos. If you hit a certain combo, there will be additional damage
		- The Test Combos are: (Head, Head, Head), (Arm, Torso, Arm), (Head, Torso, Leg)
- Added an individual Healthbar for every Character in the game
	- Healthbars track the damage that is dealt to the character
	- Healthbars disappear after a certain amount of time (10 Seconds) after not getting hit
	- They reappear after receiving damage again
- Added two TestDolls (Red & Blue) to test the attacks on
- Added a "Turret" that stands between to Testdolls and fires at the upper end in the direction the dolls face
	- The "Shots" will hit the player
	
Future Combat System Updates:
- Characters will die after having 0 healthpoints left
- Armor and different weapons will affect the amount of damage character receive
- Status effects (like poison) will be used with the combat system 
	- f.E. as a result of a combo
- (Bows and other ranged weapons will be introduced)


#### Version: 0.0.0.11.1 Pre-Alpha (03.05.2020 13:16) "Improvements"
- Added an object that you can carry around with you and place down again
-  Re-Added the functionality that you can not walk up angles that are steeper than 45 Degrees
- Added some fixes for the Inventory
	- The context menu no longer stays open when klicking on other items
	- Hovering over an item now changes the items color
	- Fixed the Scrollbar in the inventory to a proper one
- Trees in the terrain Scene now don't change back to 2D Objects as far as they did before
- Added a Theme Manager that helps us a lot in the background with color schemes
- Added full functioning stati
	- The "overloaded" status from the Inventory is now a proper status and handled through the right system
	- For test purposes there is an interactable to poison yourself with
- Added our logo as Splash Screen
- Added the functionality to change the visual quality of the game with the x and y key

#### Version: 0.0.0.11 Pre-Alpha (26.04.2020 18:54) "Quest System"
	- Added a System that can start, proceed and end quests
	- Its possible to make decisions how to proceed the quests
	- Quests are collected in the Questjournal (Open with "J")
		- Quests are split by done and in progress
		- Its possible to look up quest states
		- Its possible to switch the currently active quest
	- Added notifications when a the Queststage updates
	- Added Questmarkers that are visible on the compass
- Added a bunch of test boxes to test all functionalities of the new quest system
- Fixed some Bugs that were reported from the last version, and made some minor improvements

#### Version: 0.0.0.10 Pre-Alpha (18.04.2020 16:00) "Sound System"
- Added Sound System
	- Play music
	- Walking sound of character
	- Play dialog (e.g. the stone)
	- Plays environment sounds
	- Plays machine sounds
	
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
