using Microsoft.Xna.Framework;
using StardewValley;
using StardewValley.Locations;
using StardewValley.Objects;
using StardewValley.Tools;
using StardewValley.Menus;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Randomizer
{
	class ShopMenuAdjustments
	{
		static readonly int maxValue = int.MaxValue;

		/// <summary>
		/// Fixes sale price for saplings so that they are based on the randomly generated item they produce.
		/// </summary>
		/// <param name="menu">The ShopMenu passed in from the MenuChanged event fired when opening Pierre's shop</param>
		public static void AdjustPierreShopStock(ShopMenu menu)
		{
			// Fix sapling prices
			foreach (KeyValuePair<ISalable, int[]> stockItem in menu.itemPriceAndStock.Where(keyValuePair => keyValuePair.Key.Name.Contains("Sapling")).ToList())
			{
				menu.itemPriceAndStock[stockItem.Key] = new[] { stockItem.Key.salePrice(), maxValue};
			}

			// Add "Item of the Week"
			// only if Config.RandomizeMainShops is turned on

		}

		/// <summary>
		/// Fixes sale prices for randomized gear so that nothing sells for more than it's worth.
		/// </summary>
		/// <param name="menu">The ShopMenu passed in from the MenuChanged event fired when opening Marlon's shop.</param>
		public static void AdjustAdventureShopStock(ShopMenu menu)
		{
			menu.itemPriceAndStock = menu.itemPriceAndStock.ToDictionary(
						item => item.Key,
						item => new[] { item.Key.salePrice(), maxValue }
				);
		}
	}
}