# Stardew Valley Randomizer (More Random Edition)

An update for cTooshi's Stardew Valley Randomizer to fix errors, add new features and make the existing features more random.

## Installation

Make sure you have SMAPI installed (https://stardewvalleywiki.com/Modding:Installing_SMAPI_on_Windows), then download the latest release of the Randomizer and unzip into your Stardew Valley Mods folder.

## Changes from Original Randomizer

* Bundle randomization
  * New bundles for each room with random items selected from themed pools and random number of those items required
  * Some bundles are completely random and select from most items in the game.
* Crafting recipe randomization
  * Recipes are now created based on randomly selected items from a pool (not randomly selected premade recipes)
  * Crafting difficulty is balanced based on necessity of the item and difficulty of crafting the item in vanilla
  * Setting to choose to randomize levels you unlock crafting recipes at - must also randomize the crafting recipes themselves to have it do anything
* Crop randomization
  * Crops, including fruits, vegetables, and flowers, have randomized (made-up) names, descriptions, prices (for both seeds and crops), and attributes (trellises, scythe needed, etc.)
  * This also includes custom images for all seeds and saplings to reduce confusion
* Fish randomization
  * Fish have randomized (made-up) names, difficulty, and behavior
  * Locations, time-of-day, weather, and seasons are swapped as well
* Forageable randomization
  * Forageables for every season and location are now randomly selected from all forageables + fruit (normally from trees)
  * Every forageable appears at least once per year, and some may appear more than once
* Fruit tree randomization
  * Fruit tree saplings are now item saplings that grow a randomly selected item
  * Prices will be randomized and are loosely balanced based on the item they give
* Weapon randomization
  * Weapon stats, types, etc. are randomized
  * Many weapons can now appear in mines containers
  * Setting to rename the Galaxy Sword, since there's a hard-coded check on wilderness farms to spawn a high-level bat if you have an item named "Galaxy Sword" in your inventory
* Boot randomization
  * Stats are randomized
  * Names are randomized
* Monster randomization
  * Stats are randomized: HP / Resilience / Speed / Experience
  * The threshold before a monster moves toward you is randomized
  * The time a monster moves randomly is randomized
  * Up to a 5% chance to be able to miss an attack on a monster
  * Setting to shuffle unique monster drops among all monsters (Slime, Bat Wing, Solar Essence, Bug Meat, Void Essence, and Squid Ink)
  * Each monster can now drop a new random item
* Blueprint randomization
  * Farm buildings that you get from Robin now choose from a more random pool of resources/items instead of a set list
  * This does not yet include anything you don't get from Robin (Obelisks, the Gold Clock, etc.)
* Music randomization
  * Most in-game songs and ambience are now randomly swapped 1 to 1 with another in-game song or ambience
* Quest randomization
  * Quest givers, required items, and rewards are randomly selected.
  * Help Wanted quests are unaffected, but the randomized item names should appear as expected.
* NPC birthday randomization
  * Randomizes the season and day of each NPC's birthday
  * Does not assign birthdays to the same day
  * Does not assign birthdays on the same day of most festivals (excludes night market and the moonlight jellies)
* Spoiler log
  * A spoiler log can be generated to see info about what was randomized
  * You must turn on this option in the settings to generate the log
* Misc
  * Bug fixes to prevent game crashing
  * Different variants of randomized rain can now appear in one playthrough (previously only one type per playthrough)
  * A random item is added to each location's artifact spot pool

## Possible Future Features
* Graphics changes
  * New sprites for crops (item and growing sprites)
  * New sprites for fish
* Palette randomization (if possible)
  * Randomly shift the color of the in-game graphics towards a different hue
* NPC schedule shuffle and/or randomization
* Cooking recipe randomization
* Tea trees and the new items associated with it need to be randomized
* Stables need to be randomized still
* Randomize tailoring recipes
  
## Known Issues
* There are issues with the randomization not being consistent if you load more than one farm in your play session
  * Restart the game before you load each farm, even if it's the same farm
* The original mine floor randomization sometimes causes crashes when using the elevator - recommended to leave this setting off for now
* This mod does not fully support other languages
  * The title screen will use the English title buttons when the game is first loaded
  * Randomly generated names and descriptions are all in English
  * Randomizing crops will result in crop and seed names/descriptions to all be English; additionally, recipes that use these crops will have thier names/descriptions switched to English
  * Randomizing fruit trees will result in their names/descriptions to all be English
