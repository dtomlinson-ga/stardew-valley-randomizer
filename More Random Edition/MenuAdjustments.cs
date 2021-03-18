using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StardewModdingAPI.Events;
using StardewValley.Menus;
using StardewValley;
using Microsoft.Xna.Framework;

namespace Randomizer
{
	class MenuAdjustments
	{

		public static void TryAdjustMenu(object sender, MenuChangedEventArgs e)
		{
			// Bundle menu - fix ring deposit
			if (Globals.Config.Bundles.Randomize && (e.NewMenu is JunimoNoteMenu))
			{
				BundleMenuAdjustments.FixRingSelection(sender, e);
			}
			// Shop menu - inject stock
			else if (Globals.Config.Shops.Randomize && (e.NewMenu is ShopMenu))
			{
				ShopMenu shopMenu = (ShopMenu)e.NewMenu;

				switch(shopMenu.portraitPerson.Name)
				{
					case "Pierre":
						ShopMenuAdjustments.AdjustPierreShopStock(shopMenu);
						break;

					case "Marlon":
						ShopMenuAdjustments.AdjustAdventureShopStock(shopMenu);
						break;

					default:
						break;
				}
			}
		}


		/// <summary>
		/// Fixes the item name that you get at the start of the game
		/// </summary>
		public static void FixParsnipSeedBox()
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

	}
}
