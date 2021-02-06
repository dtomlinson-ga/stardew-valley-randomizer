using Microsoft.Xna.Framework;
using StardewValley;
using StardewValley.Locations;
using StardewValley.Objects;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Randomizer
{
	/// <summary>
	/// Represents an overridden seed shop - it's used to override the normal
	/// things the shop can sell. In this case, it will make the fruit tree
	/// prices NOT hard-coded
	/// </summary>
	public class OverriddenSeedShop
	{
		/// <summary>
		/// A copy of the original "shopStock" function in SeedShop.cs, with the fruit tree
		/// prices not hard-coded. There was a code snippet that was likely intended to be used
		/// as a buyback feature, but it didn't seem to work, so it's been taken out for now.
		/// </summary>
		/// <returns></returns>
		public static Dictionary<ISalable, int[]> NewShopStock()
		{
			Dictionary<ISalable, int[]> stock = new Dictionary<ISalable, int[]>();

			// Spring stock
			AddStock(stock, (int)ObjectIndexes.ParsnipSeeds, itemSeason: "spring");
			AddStock(stock, (int)ObjectIndexes.BeanStarter, itemSeason: "spring");
			AddStock(stock, (int)ObjectIndexes.CauliflowerSeeds, itemSeason: "spring");
			AddStock(stock, (int)ObjectIndexes.PotatoSeeds, itemSeason: "spring");
			AddStock(stock, (int)ObjectIndexes.TulipBulb, itemSeason: "spring");
			AddStock(stock, (int)ObjectIndexes.KaleSeeds, itemSeason: "spring");
			AddStock(stock, (int)ObjectIndexes.JazzSeeds, itemSeason: "spring");
			if (Game1.year > 1)
			{
				AddStock(stock, (int)ObjectIndexes.GarlicSeeds, itemSeason: "spring");
				AddStock(stock, (int)ObjectIndexes.RiceShoot, itemSeason: "spring");
			}

			// Summer stock
			AddStock(stock, (int)ObjectIndexes.MelonSeeds, itemSeason: "summer");
			AddStock(stock, (int)ObjectIndexes.TomatoSeeds, itemSeason: "summer");
			AddStock(stock, (int)ObjectIndexes.BlueberrySeeds, itemSeason: "summer");
			AddStock(stock, (int)ObjectIndexes.PepperSeeds, itemSeason: "summer");
			AddStock(stock, (int)ObjectIndexes.WheatSeeds, itemSeason: "summer");
			AddStock(stock, (int)ObjectIndexes.RadishSeeds, itemSeason: "summer");
			AddStock(stock, (int)ObjectIndexes.PoppySeeds, itemSeason: "summer");
			AddStock(stock, (int)ObjectIndexes.SpangleSeeds, itemSeason: "summer");
			AddStock(stock, (int)ObjectIndexes.HopsStarter, itemSeason: "summer");
			AddStock(stock, (int)ObjectIndexes.CornSeeds, itemSeason: "summer");
			AddStock(stock, (int)ObjectIndexes.SunflowerSeeds, buyPrice: 100, itemSeason: "summer");
			if (Game1.year > 1)
				AddStock(stock, (int)ObjectIndexes.RedCabbageSeeds, itemSeason: "summer");

			// Fall stock
			AddStock(stock, (int)ObjectIndexes.PumpkinSeeds, itemSeason: "fall");
			AddStock(stock, (int)ObjectIndexes.CornSeeds, itemSeason: "fall");
			AddStock(stock, (int)ObjectIndexes.EggplantSeeds, itemSeason: "fall");
			AddStock(stock, (int)ObjectIndexes.BokChoySeeds, itemSeason: "fall");
			AddStock(stock, (int)ObjectIndexes.YamSeeds, itemSeason: "fall");
			AddStock(stock, (int)ObjectIndexes.CranberrySeeds, itemSeason: "fall");
			AddStock(stock, (int)ObjectIndexes.WheatSeeds, itemSeason: "fall");
			AddStock(stock, (int)ObjectIndexes.SunflowerSeeds, buyPrice: 100, itemSeason: "fall");
			AddStock(stock, (int)ObjectIndexes.FairySeeds, itemSeason: "fall");
			AddStock(stock, (int)ObjectIndexes.AmaranthSeeds, itemSeason: "fall");
			AddStock(stock, (int)ObjectIndexes.GrapeStarter, itemSeason: "fall");
			if (Game1.year > 1)
				AddStock(stock, (int)ObjectIndexes.ArtichokeSeeds, itemSeason: "fall");

			// Year-round stock
			AddStock(stock, (int)ObjectIndexes.GrassStarter);

			// If player doesn't have Grass Starter recipe, add it to stock
			if (!Game1.player.craftingRecipes.ContainsKey("Grass Starter"))
				stock.Add((ISalable)new StardewValley.Object((int)ObjectIndexes.GrassStarter, initialStack: 1, isRecipe: true), new[] {1000, 1});

			// Cooking stock
			AddStock(stock, (int)ObjectIndexes.Sugar);
			AddStock(stock, (int)ObjectIndexes.WheatFlour);
			AddStock(stock, (int)ObjectIndexes.Rice);
			AddStock(stock, (int)ObjectIndexes.Oil);
			AddStock(stock, (int)ObjectIndexes.Vinegar);

			// After 15 days, add basic crop boost items
			if ((int)Game1.stats.DaysPlayed >= 15)
			{
				AddStock(stock, (int)ObjectIndexes.BasicFertilizer, buyPrice: 50);
				AddStock(stock, (int)ObjectIndexes.BasicRetainingSoil, buyPrice: 50);
				AddStock(stock, (int)ObjectIndexes.SpeedGro, buyPrice: 50);
			}

			// After 1 year, add better quality crop boost items
			if (Game1.year > 1)
			{
				AddStock(stock, (int)ObjectIndexes.QualityFertilizer, buyPrice: 75);
				AddStock(stock, (int)ObjectIndexes.QualityRetainingSoil, buyPrice: 75);
				AddStock(stock, (int)ObjectIndexes.DeluxeSpeedGro, buyPrice: 75);
			}

			// Wallpaper stock - generate random wallpaper IDs based on in-game day
			Random random = new Random((int)Game1.stats.DaysPlayed + (int)Game1.uniqueIDForThisGame / 2);
			int which = random.Next(112);
			if (which == 21)
				which = 36;

			Wallpaper wallpaper1 = new Wallpaper(which, false);
			stock.Add((ISalable)wallpaper1, new[] {wallpaper1.salePrice(), int.MaxValue});

			Wallpaper wallpaper2 = new Wallpaper(random.Next(56), true);
			stock.Add((ISalable)wallpaper2, new[] {wallpaper2.salePrice(), int.MaxValue});

			// Furniture stock
			Furniture furniture = new Furniture(1308, Vector2.Zero);
			stock.Add((ISalable)furniture, new[] {furniture.salePrice(), int.MaxValue});

			// Sapling stock -- begin replaced code
			AddStock(stock, (int)ObjectIndexes.CherrySapling);
			AddStock(stock, (int)ObjectIndexes.ApricotSapling);
			AddStock(stock, (int)ObjectIndexes.OrangeSapling);
			AddStock(stock, (int)ObjectIndexes.PeachSapling);
			AddStock(stock, (int)ObjectIndexes.PomegranateSapling);
			AddStock(stock, (int)ObjectIndexes.AppleSapling);
			// -- End replaced code

			// Add bouquet to shop if player has high enough heart level with eligible NPC
			if (Game1.player.hasAFriendWithHeartLevel(8, true))
				AddStock(stock, (int)ObjectIndexes.Bouquet);

			// There is also a reselling feature that we're removing for simplicity
			// We potentially should add this back in at some point

			return stock;
		}


		/// <summary>
		/// Part of the replaced code - taken from the original code called addStock in SeedShop.cs
		/// </summary>
		/// <param name="stock"></param>
		/// <param name="parentSheetIndex"></param>
		/// <param name="buyPrice"></param>
		private static void AddStock(Dictionary<ISalable, int[]> stock, int parentSheetIndex, int buyPrice = -1, string itemSeason = null)
		{
			float num1 = 2f;		// Price multiplier
			int num2 = buyPrice;	// Override sale price - use salePrice() if not specified
			StardewValley.Object @object = new StardewValley.Object(Vector2.Zero, parentSheetIndex, 1);

			if (buyPrice == -1)
			{
				num2 = @object.salePrice();
				num1 = 1f;
			}
			else if (@object.isSapling())
				num1 *= Game1.MasterPlayer.difficultyModifier;

			// If item is not year-round or item is out-of-season
			if (itemSeason != null && itemSeason != Game1.currentSeason)
			{
				// If Pierre isn't yet stocking crops year-round, don't add it to stock
				if (!Game1.MasterPlayer.hasOrWillReceiveMail("PierreStocklist"))
					return;
				// If he is, raise the price on out-of-season goods
				num1 *= 1.5f;
			}

			int num3 = (int)(num2 * num1);

			if (itemSeason != null)
			{
				foreach (KeyValuePair<ISalable, int[]> keyValuePair in stock)
				{
					if (keyValuePair.Key != null && keyValuePair.Key is StardewValley.Object)
					{
						StardewValley.Object key = keyValuePair.Key as StardewValley.Object;
						if (Utility.IsNormalObjectAtParentSheetIndex(key, parentSheetIndex))
						{
							if (keyValuePair.Value.Length == 0 || num3 >= keyValuePair.Value[0])
								return;
							keyValuePair.Value[0] = num3;
							stock[(ISalable)key] = keyValuePair.Value;
							return;
						}
					}
				}
			}
			stock.Add((ISalable)@object, new[] {num3, int.MaxValue});
		}

		/// <summary>
		/// Replaces the shopStock method in SeedShop.cs with this file's NewShopStock method
		/// NOTE: THIS IS UNSAFE CODE, CHANGE WITH EXTREME CAUTION
		/// </summary>
		public static void ReplaceShopStockMethod()
		{
			if (Globals.Config.RandomizeFruitTrees)
			{
				MethodInfo methodToReplace = typeof(SeedShop).GetMethod("shopStock");
				MethodInfo methodToInject = typeof(OverriddenSeedShop).GetMethod("NewShopStock");
				Globals.RepointMethod(methodToReplace, methodToInject);
			}
		}
	}
}
