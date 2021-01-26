﻿using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Utilities;
using StardewValley;
using StardewValley.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Randomizer
{
	/// <summary>The mod entry point</summary>
	public class ModEntry : Mod
	{
		public PossibleSwap[] PossibleSwaps = {
			new PossibleSwap("Pierre", "Lewis"),
			new PossibleSwap("Wizard", "Sandy"),
			new PossibleSwap("Willy", "Pam"),
			new PossibleSwap("Abigail", "Marnie"),
			new PossibleSwap("MrQi", "Gunther"),
			new PossibleSwap("Marlon", "Governor"),
			new PossibleSwap("Caroline", "Evelyn"),
			new PossibleSwap("Pam", "Haley"),
			new PossibleSwap("Morris", "Krobus"),
			new PossibleSwap("Gus", "Elliott"),
			new PossibleSwap("Linus", "Pam"),
			new PossibleSwap("Kent", "Pierre"),
			new PossibleSwap("Sandy", "Maru"),
			new PossibleSwap("Sebastian", "Wizard"),
			new PossibleSwap("Jas", "Vincent"),
			new PossibleSwap("Krobus", "Dwarf"),
			new PossibleSwap("Leah", "Marnie"),
			new PossibleSwap("Henchman", "Bouncer"),
			new PossibleSwap("Harvey", "Gus"),
			new PossibleSwap("Bouncer", "Gunther"),
			new PossibleSwap("Gunther", "Governor"),
			new PossibleSwap("Evelyn", "Jodi"),
			new PossibleSwap("George", "Wizard"),
			new PossibleSwap("Emily", "Marnie"),
			new PossibleSwap("Sam", "Linus"),
			new PossibleSwap("Alex", "Gus"),
			new PossibleSwap("Penny", "Sandy"),
			new PossibleSwap("Morris", "Governor"),
			new PossibleSwap("Haley", "Alex"),
			new PossibleSwap("Harvey", "Maru"),
			new PossibleSwap("Abigail", "Sebastian"),
			new PossibleSwap("Penny", "Sam"),
			new PossibleSwap("Leah", "Elliott"),
			new PossibleSwap("Shane", "Emily"),
			new PossibleSwap("Shane", "Pam")
		};

		private AssetLoader _modAssetLoader;
		private AssetEditor _modAssetEditor;

		private IModHelper _helper;

		static IGenericModConfigMenuAPI api;

		/// <summary>The mod entry point, called after the mod is first loaded</summary>
		/// <param name="helper">Provides simplified APIs for writing mods</param>
		public override void Entry(IModHelper helper)
		{
			ImageBuilder.CleanUpReplacementFiles();

			_helper = helper;
			Globals.ModRef = this;
			Globals.Config = Helper.ReadConfig<ModConfig>();

			this._modAssetLoader = new AssetLoader(this);
			this._modAssetEditor = new AssetEditor(this);
			helper.Content.AssetLoaders.Add(this._modAssetLoader);
			helper.Content.AssetEditors.Add(this._modAssetEditor);

			this.PreLoadReplacments();
			helper.Events.GameLoop.GameLaunched += (sender, args) => this.onLaunched();
			helper.Events.GameLoop.SaveLoaded += (sender, args) => this.CalculateAllReplacements();
			helper.Events.Display.RenderingActiveMenu += (sender, args) => _modAssetLoader.TryReplaceTitleScreen();
			helper.Events.GameLoop.ReturnedToTitle += (sender, args) => _modAssetLoader.ReplaceTitleScreenAfterReturning();

			if (Globals.Config.RandomizeMusic) { helper.Events.GameLoop.UpdateTicked += (sender, args) => this.TryReplaceSong(); }
			if (Globals.Config.RandomizeRain) { helper.Events.GameLoop.DayEnding += _modAssetLoader.ReplaceRain; }

			if (Globals.Config.Crops.Randomize)
			{
				helper.Events.Multiplayer.PeerContextReceived += (sender, args) => FixParsnipSeedBox();
			}

			if (Globals.Config.Crops.Randomize || Globals.Config.Fish.Randomize)
			{
				helper.Events.Display.RenderingActiveMenu += (sender, args) => CraftingRecipeAdjustments.HandleCraftingMenus();

				// Fix for the Special Orders causing crashes
				// Re-instate the object info when the save is first loaded for the session, and when saving so that the
				// items have the correct names on the items sold summary screen
				helper.Events.GameLoop.DayEnding += (sender, args) => _modAssetEditor.UndoObjectInformationReplacements();
				helper.Events.GameLoop.SaveLoaded += (sender, args) => _modAssetEditor.RedoObjectInformationReplacements();
				helper.Events.GameLoop.Saving += (sender, args) => _modAssetEditor.RedoObjectInformationReplacements();
			}

			if (Globals.Config.RandomizeForagables)
			{
				helper.Events.GameLoop.GameLaunched += (sender, args) => WildSeedAdjustments.ReplaceGetRandomWildCropForSeason();
			}

			if (Globals.Config.Fish.Randomize)
			{
				helper.Events.GameLoop.DayStarted += (sender, args) => OverriddenSubmarine.UseOverriddenSubmarine();
				helper.Events.GameLoop.DayEnding += (sender, args) => OverriddenSubmarine.RestoreSubmarineLocation();
			}

			if (Globals.Config.Bundles.Randomize)
			{
				helper.Events.Display.MenuChanged += BundleMenuAdjustments.FixRingSelection;
				helper.Events.Display.RenderingActiveMenu += (sender, args) => BundleMenuAdjustments.FixRingDeposits();

				if (Globals.Config.Bundles.ShowDescriptionsInBundleTooltips)
				{
					helper.Events.Display.RenderedActiveMenu += (sender, args) => BundleMenuAdjustments.AddDescriptionsToBundleTooltips();
				}
			}
		}

		private void onLaunched()
		{
			// Check to see if Generic Mod Config Menu is installed
			if (!Helper.ModRegistry.IsLoaded("spacechase0.GenericModConfigMenu"))
            {
				Globals.ConsoleTrace("GenericModConfigMenu not present");
				return;
            }

			api = Helper.ModRegistry.GetApi<IGenericModConfigMenuAPI>("spacechase0.GenericModConfigMenu");
			api.RegisterModConfig(ModManifest, () => Globals.Config = new ModConfig(), () => Helper.WriteConfig(Globals.Config));
			api.RegisterLabel(ModManifest, "Randomization Options", "Toggle on or off the various aspects of the game which can be randomized.");

			RegisterModOptions();

		}

		private void RegisterModOptions()
        {
			// Need to clean this up somehow
			// Maybe a Settings object which has a name, description, and value
			AddLabel("Bundle Options");
			AddCheckbox("Community Center Bundles", Globals.Config.Bundles.Randomize, "Generate new bundles for each room which select a random number of items from a themed pool.");
			AddCheckbox("Show Helpful Tooltips", Globals.Config.Bundles.ShowDescriptionsInBundleTooltips, "When this option is enabled, mouse over the items in a bundle to get a helpful description of where to locate them.");

			AddLabel("Crafting Recipe Options");
			AddCheckbox("Crafting Recipes", Globals.Config.CraftingRecipies.Randomize, "Create recipes using randomly selected items from a pool. Uses rules for balanced difficulty.");
			AddCheckbox("Skill Level Requirements", Globals.Config.CraftingRecipies.RandomizeLevels, "Randomize levels at which the recipes are learned. Recipe randomization must be turned on for this to take effect.") ;

			AddLabel("NPC Options");
			AddCheckbox("Swap NPC Skins", Globals.Config.NPCs.RandomizeSkins, "Switch NPC's skins arounds. Does not change names or schedules.");
			AddCheckbox("NPC Birthdays", Globals.Config.NPCs.RandomizeBirthdays, "Moves each NPC's birthday to a random day in the year.");
			AddCheckbox("Individual Item Preferences", Globals.Config.NPCs.RandomizePreferences, "Generates a new set of loved items, hated items, and so on for each NPC.");
			AddCheckbox("Universal Item Preferences", Globals.Config.NPCs.RandomizeUniversalPreferences, "Generates a new set of universally loved items, universally hated items and so on.");

			AddLabel("Crop Options");
			AddCheckbox("Crops", Globals.Config.Crops.Randomize, "Randomize crop names, growing schedules, and attributes (trellis, scythe needed, etc.).");
			AddCheckbox("Use Custom Crop Images",  Globals.Config.Crops.UseCustomImages, "Use custom images for seeds and crops at each growth stage.");
			AddCheckbox("Fruit Trees", Globals.Config.RandomizeFruitTrees, "Generates Item saplings that grow a random item. Prices are loosely balanced based on the item grown.");

			AddLabel("Fish Options");
			AddCheckbox("Fish", Globals.Config.Fish.Randomize, "Randomize fish names, difficulty and behaviors, as well as locations, times of days and seasons.");
			AddCheckbox("Use Custom Fish Images", Globals.Config.Fish.UseCustomImages, "Use custom images for the fish.");

			AddLabel("Monster Options");
			AddCheckbox("Monster Stats", Globals.Config.Monsters.Randomize, "Randomize monster stats, behaviors, and non-unique item drops.");
			AddCheckbox("Shuffle Monster Drops", Globals.Config.Monsters.SwapUniqueDrops, "Shuffle unique monster drops between all monsters.");

			AddLabel("Weapon Options");
			AddCheckbox("Weapons", Globals.Config.Weapons.Randomize, "Randomize weapon stats, types, and drop locations.");
			AddCheckbox("Use Custom Weapon Images", Globals.Config.Weapons.UseCustomImages, "Use custom images for weapons.");
			AddCheckbox("Galaxy Sword Name", Globals.Config.Weapons.RandomizeGalaxySwordName, "Disable to have the Galaxy Sword keep its name. There is a hard-coded check to spawn a high level bat on Wilderness Farm at night if the player has a Galaxy Sword in their inventory.");

			AddLabel("Boot Options");
			AddCheckbox("Boots", Globals.Config.Boots.Randomize, "Randomize boots stats, names, descriptions.");
			AddCheckbox("Use Custom Boot Images", Globals.Config.Boots.UseCustomImages, "Use custom images for boots.");

			AddLabel("Misc Options");
			AddCheckbox("Building Costs", Globals.Config.RandomizeBuildingCosts, "Farm buildings that Robin can build for the player choose from a random pool of resources.");
			AddCheckbox("Animal Skins", Globals.Config.RandomizeAnimalSkins, "You might get a surprise from Marnie.");
			AddCheckbox("Forageables", Globals.Config.RandomizeForagables, "Forageables for every season and location are now randomly selected. Every forageable appears at least once per year.");
			AddCheckbox("Intro Text", Globals.Config.RandomizeIntroStory, "Replace portions of the intro cutscene with Mad Libs style text.");
			AddCheckbox("Quests", Globals.Config.RandomizeQuests, "Randomly select quest givers, required items, and rewards.");
			AddCheckbox("Music", Globals.Config.RandomizeMusic, "Shuffle most songs and ambience.");
			AddCheckbox("Rain", Globals.Config.RandomizeRain, "Replace rain with a variant (Skulls/Junimos/Cats and Dogs/etc).");

        }

		private void AddCheckbox(string name, bool config, string desc = "")
        {
			api.RegisterSimpleOption(ModManifest, name, desc, () => config, (bool val) => config = val);
        }

		private void AddLabel(string name, string desc = "")
        {
			api.RegisterLabel(ModManifest, name, desc);
        }

		/// <summary>
		/// Loads the replacements that can be loaded before a game is selected
		/// </summary>
		public void PreLoadReplacments()
		{
			_modAssetLoader.CalculateReplacementsBeforeLoad();
			_modAssetEditor.CalculateEditsBeforeLoad();
		}

		/// <summary>
		/// Does all the randomizer replacements that take place after a game is loaded
		/// </summary>
		public void CalculateAllReplacements()
		{
			//Seed is pulled from farm name
			byte[] seedvar = (new SHA1Managed()).ComputeHash(Encoding.UTF8.GetBytes(Game1.player.farmName.Value));
			int seed = BitConverter.ToInt32(seedvar, 0);

			this.Monitor.Log($"Seed Set: {seed}");

			Globals.RNG = new Random(seed);
			Globals.SpoilerLog = new SpoilerLogger(Game1.player.farmName.Value);

			// Make replacements and edits
			_modAssetLoader.CalculateReplacements();
			_modAssetEditor.CalculateEdits();
			_modAssetLoader.RandomizeImages();
			Globals.SpoilerLog.WriteFile();

			// Invalidate all replaced and edited assets so they are reloaded
			_modAssetLoader.InvalidateCache();
			_modAssetEditor.InvalidateCache();

			// Use when debugging to ensure that the bundles get changed if they're meant to
			//Game1.GenerateBundles(Game1.bundleType, true);

			ChangeDayOneForagables();
			FixParsnipSeedBox();
			OverriddenSeedShop.ReplaceShopStockMethod();
			OverriddenAdventureShop.FixAdventureShopBuyAndSellPrices();
		}

		/// <summary>
		/// A passthrough to calculate adn invalidate UI edits
		/// Used when the lanauage is changed
		/// </summary>
		public void CalculateAndInvalidateUIEdits()
		{
			_modAssetEditor.CalculateAndInvalidateUIEdits();
		}

		/// <summary>
		/// Fixes the foragables on day 1 - the save file is created too quickly for it to be
		/// randomized right away, so we'll change them on the spot on the first day
		/// </summary>
		public void ChangeDayOneForagables()
		{
			SDate currentDate = SDate.Now();
			if (currentDate.DaysSinceStart < 2)
			{
				List<GameLocation> locations = Game1.locations
					.Concat(
						from location in Game1.locations.OfType<BuildableGameLocation>()
						from building in location.buildings
						where building.indoors.Value != null
						select building.indoors.Value
					).ToList();

				List<Item> newForagables =
					ItemList.GetForagables(Seasons.Spring)
						.Where(x => x.ShouldBeForagable) // Removes the 1/1000 items
						.Cast<Item>().ToList();

				foreach (GameLocation location in locations)
				{
					List<int> foragableIds = ItemList.GetForagables().Select(x => x.Id).ToList();
					List<Vector2> tiles = location.Objects.Pairs
						.Where(x => foragableIds.Contains(x.Value.ParentSheetIndex))
						.Select(x => x.Key)
						.ToList();

					foreach (Vector2 oldForagableKey in tiles)
					{
						Item newForagable = Globals.RNGGetRandomValueFromList(newForagables, true);
						location.Objects[oldForagableKey].ParentSheetIndex = newForagable.Id;
						location.Objects[oldForagableKey].Name = newForagable.Name;
					}
				}
			}
		}

		/// <summary>
		/// Fixes the item name that you get at the start of the game
		/// </summary>
		public void FixParsnipSeedBox()
		{
			GameLocation farmHouse = Game1.locations.Where(x => x.Name == "FarmHouse").First();

			List<StardewValley.Objects.Chest> chestsInRoom =
				farmHouse.Objects.Values.Where(x =>
					x.DisplayName == "Chest")
					.Cast<StardewValley.Objects.Chest>()
					.Where(x => x.giftbox.Value)
				.ToList();

			if (chestsInRoom.Count > 0)
			{
				string parsnipSeedsName = ItemList.GetItemName((int)ObjectIndexes.ParsnipSeeds);
				StardewValley.Item itemInChest = chestsInRoom[0].items[0];
				if (itemInChest.Name == "Parsnip Seeds")
				{
					itemInChest.Name = parsnipSeedsName;
					itemInChest.DisplayName = parsnipSeedsName;
				}
			}
		}

		/// <summary>
		/// The last song that played/is playing
		/// </summary>
		private string _lastCurrentSong { get; set; }

		/// <summary>
		/// Attempts to replace the current song with a different one
		/// If the song was barely replaced, it doesn't do anything
		/// </summary>
		public void TryReplaceSong()
		{
			string currentSong = Game1.currentSong?.Name;
			if (this._modAssetEditor.MusicReplacements.TryGetValue(currentSong?.ToLower() ?? "", out string value) && _lastCurrentSong != currentSong)
			{
				if (value == "Volcano_Ambient") //TODO: get rid of this in the next major release (includes removing it from the Music Randomizer)
				{
					value = this._modAssetEditor.MusicReplacements["volcano_ambient"];
				}

				_lastCurrentSong = value;
				Game1.changeMusicTrack(value);

				//Game1.addHUDMessage(new HUDMessage($"Song: {currentSong} | Replaced with: {value}"));
			}
		}
	}
}