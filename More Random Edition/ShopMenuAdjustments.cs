using Microsoft.Xna.Framework;
using StardewValley;
using StardewValley.Menus;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Randomizer
{
	internal class ShopMenuAdjustments
	{
		internal static void AdjustPierreShopStock(ShopMenu menu)
		{
			// Remove saplings from shop
			menu.forSale.RemoveAll(x => x.Name.Contains("Sapling"));
			foreach (var item in menu.itemPriceAndStock.Where(keyValuePair => keyValuePair.Key.Name.Contains("Sapling")).ToList())
			{
				menu.itemPriceAndStock.Remove(item.Key);
			}

			Dictionary<ISalable, int[]> stock = menu.itemPriceAndStock;
			List<ISalable> forSale = menu.forSale;

			// Re-add saplings with adjusted prices
			AddItemToStockAtSalePrice(stock, forSale, (int)ObjectIndexes.CherrySapling);
			AddItemToStockAtSalePrice(stock, forSale, (int)ObjectIndexes.ApricotSapling);
			AddItemToStockAtSalePrice(stock, forSale, (int)ObjectIndexes.OrangeSapling);
			AddItemToStockAtSalePrice(stock, forSale, (int)ObjectIndexes.PeachSapling);
			AddItemToStockAtSalePrice(stock, forSale, (int)ObjectIndexes.PomegranateSapling);
			AddItemToStockAtSalePrice(stock, forSale, (int)ObjectIndexes.AppleSapling);


			// Add "Item of the Week"
			Array objects = Enum.GetValues(typeof(ObjectIndexes));
			int objIndex = (int)objects.GetValue(Range.GetRandomValue(0, objects.Length));
			AddItemToStockAtSalePrice(stock, forSale, objIndex);
		}

		AdjustAdventureShopStock(ShopMenu sh)

		private static void AddItemToStockAtSalePrice(Dictionary<ISalable, int[]> stock, List<ISalable> forSale, int parentSheetIndex)
		{
			StardewValley.Object obj = new StardewValley.Object(Vector2.Zero, parentSheetIndex, 1);
			int price = obj.salePrice();

			stock.Add(obj, new[] { price, int.MaxValue });
			forSale.Add(obj);
		}
	}
}