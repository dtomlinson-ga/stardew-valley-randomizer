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

				if (Globals.Config.Shops.RandomizePierre && shopMenu.portraitPerson.Name == "Pierre")
				{
					Array objects = ObjectIndexes.GetValues(typeof(ObjectIndexes));
					int objIndex = (int)objects.GetValue(Range.GetRandomValue(0, objects.Length));

					StardewValley.Object obj = new StardewValley.Object(Vector2.Zero, objIndex, 1);
					shopMenu.itemPriceAndStock.Add((ISalable)obj, new int[] {1, 2});
					shopMenu.forSale.Add((ISalable)obj);

					if ((int)Game1.stats.DaysPlayed >= 15)
					{
						objIndex = ItemList.GetRandomItemAtDifficulty(ObtainingDifficulties.EndgameItem).Id;
						obj = new StardewValley.Object(Vector2.Zero, objIndex, 1);

						shopMenu.itemPriceAndStock.Add((ISalable)obj, new int[] { 1, 2 });
						shopMenu.forSale.Add((ISalable)obj);
					}
				}
			}
		}

	}
}
