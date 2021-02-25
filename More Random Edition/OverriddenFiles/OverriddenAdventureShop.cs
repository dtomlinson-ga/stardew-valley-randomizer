using StardewValley;
using StardewValley.Locations;
using StardewValley.Objects;
using StardewValley.Tools;
using System.Collections.Generic;
using System.Reflection;

namespace Randomizer
{
	/// <summary>
	/// Fixes the buy prices of the items in the adventure shop
	/// </summary>
	public class OverriddenAdventureShop
	{
		/// <summary>
		/// A copy of the original "getAdventureShopStock" function in Utility.cs, which changes
		/// the prices to be dynamic such that it can't sell for more than you can buy it for
		/// </summary>
		/// <returns />
		public static Dictionary<ISalable, int[]> NewGetAdventureShopStock()
		{
			Dictionary<ISalable, int[]> dictionary = new Dictionary<ISalable, int[]>();
			int maxValue = int.MaxValue;

			// Weapons
			dictionary.Add(new MeleeWeapon(12), new[] {WeaponRandomizer.Weapons[12].GetBuyPrice(), maxValue});

			if (MineShaft.lowestLevelReached >= 15)
				dictionary.Add(new MeleeWeapon(17), new[] {WeaponRandomizer.Weapons[17].GetBuyPrice(), maxValue});

			if (MineShaft.lowestLevelReached >= 20)
				dictionary.Add(new MeleeWeapon(1), new[] {WeaponRandomizer.Weapons[1].GetBuyPrice(), maxValue});
			
			if (MineShaft.lowestLevelReached >= 25)
			{
				dictionary.Add(new MeleeWeapon(43), new[] {WeaponRandomizer.Weapons[43].GetBuyPrice(), maxValue});
				dictionary.Add(new MeleeWeapon(44), new[] {WeaponRandomizer.Weapons[44].GetBuyPrice(), maxValue});
			}

			if (MineShaft.lowestLevelReached >= 40)
				dictionary.Add(new MeleeWeapon(27), new[] {WeaponRandomizer.Weapons[27].GetBuyPrice(), maxValue});
			
			if (MineShaft.lowestLevelReached >= 45)
				dictionary.Add(new MeleeWeapon(10), new[] {WeaponRandomizer.Weapons[10].GetBuyPrice(), maxValue});
			
			if (MineShaft.lowestLevelReached >= 55)
				dictionary.Add(new MeleeWeapon(7), new[] {WeaponRandomizer.Weapons[7].GetBuyPrice(), maxValue});
			
			if (MineShaft.lowestLevelReached >= 75)
				dictionary.Add(new MeleeWeapon(5), new[] {WeaponRandomizer.Weapons[5].GetBuyPrice(), maxValue});

			if (MineShaft.lowestLevelReached >= 90)
				dictionary.Add(new MeleeWeapon(50), new[] {WeaponRandomizer.Weapons[50].GetBuyPrice(), maxValue});
			
			if (MineShaft.lowestLevelReached >= 120)
				dictionary.Add(new MeleeWeapon(9), new[] {WeaponRandomizer.Weapons[9].GetBuyPrice(), maxValue});

			// Player has obtained Galaxy Sword
			if (Game1.player.mailReceived.Contains("galaxySword"))
			{
				dictionary.Add(new MeleeWeapon(4), new[] {WeaponRandomizer.Weapons[4].GetBuyPrice(), maxValue});
				dictionary.Add(new MeleeWeapon(23), new[] {WeaponRandomizer.Weapons[23].GetBuyPrice(), maxValue});
				dictionary.Add(new MeleeWeapon(29), new[] {WeaponRandomizer.Weapons[29].GetBuyPrice(), maxValue});
			}

			// Boots
			dictionary.Add(new Boots(504), new[] {BootRandomizer.Boots[504].GetBuyPrice(), maxValue});
			
			if (MineShaft.lowestLevelReached >= 10)
				dictionary.Add(new Boots(506), new[] {BootRandomizer.Boots[506].GetBuyPrice(), maxValue});

			if (MineShaft.lowestLevelReached >= 50)
				dictionary.Add(new Boots(509), new[] {BootRandomizer.Boots[509].GetBuyPrice(), maxValue});
			
			if (MineShaft.lowestLevelReached >= 40)
				dictionary.Add(new Boots(508), new[] {BootRandomizer.Boots[508].GetBuyPrice(), maxValue});

			if (MineShaft.lowestLevelReached >= 80)
			{
				dictionary.Add(new Boots(512), new[] {BootRandomizer.Boots[512].GetBuyPrice(), maxValue});
				dictionary.Add(new Boots(511), new[] {BootRandomizer.Boots[511].GetBuyPrice(), maxValue});
			}

			if (MineShaft.lowestLevelReached >= 110)
				dictionary.Add(new Boots(514), new[] {BootRandomizer.Boots[514].GetBuyPrice(), maxValue});
			
			// Rings
			dictionary.Add(new Ring(529), new[] {1000, maxValue});
			dictionary.Add(new Ring(530), new[] {1000, maxValue});
			if (MineShaft.lowestLevelReached >= 40)
			{
				dictionary.Add(new Ring(531), new[] {2500, maxValue});
				dictionary.Add(new Ring(532), new[] {2500, maxValue});
			}

			if (MineShaft.lowestLevelReached >= 80)
			{
				dictionary.Add(new Ring(533), new[] {5000, maxValue});
				dictionary.Add(new Ring(534), new[] {5000, maxValue});
			}

			// Slingshots
			if (MineShaft.lowestLevelReached >= 40)
				dictionary.Add(new Slingshot(32), new[] {500, maxValue});

			if (MineShaft.lowestLevelReached >= 70)
				dictionary.Add(new Slingshot(33), new[] {1000, maxValue});
			
			// Unlocked Recipes
			if (Game1.player.craftingRecipes.ContainsKey("Explosive Ammo"))
				dictionary.Add(new Object(441, int.MaxValue, false, -1, 0), new[] {300, maxValue});
			
			if (Game1.player.mailReceived.Contains("Gil_Slime Charmer Ring"))
				dictionary.Add(new Ring(520), new[] {25000, maxValue});
			
			if (Game1.player.mailReceived.Contains("Gil_Savage Ring"))
				dictionary.Add(new Ring(523), new[] {25000, maxValue});
			
			if (Game1.player.mailReceived.Contains("Gil_Burglar's Ring"))
				dictionary.Add(new Ring(526), new[] {20000, maxValue});
			
			if (Game1.player.mailReceived.Contains("Gil_Vampire Ring"))
				dictionary.Add(new Ring(522), new[] {15000, maxValue});
			
			if (Game1.player.mailReceived.Contains("Gil_Crabshell Ring"))
				dictionary.Add(new Ring(810), new[] {15000, maxValue});
			
			if (Game1.player.mailReceived.Contains("Gil_Napalm Ring"))
				dictionary.Add(new Ring(811), new[] {30000, maxValue});
			
			if (Game1.player.mailReceived.Contains("Gil_Skeleton Mask"))
				dictionary.Add(new Hat(8), new[] {20000, maxValue});
			
			if (Game1.player.mailReceived.Contains("Gil_Hard Hat"))
				dictionary.Add(new Hat(27), new[] {20000, maxValue});
			
			if (Game1.player.mailReceived.Contains("Gil_Arcane Hat"))
				dictionary.Add(new Hat(60), new[] {20000, maxValue});
			
			if (Game1.player.mailReceived.Contains("Gil_Knight's Helmet"))
				dictionary.Add(new Hat(50), new[] {20000, maxValue});

			if (Game1.player.mailReceived.Contains("Gil_Insect Head"))
				dictionary.Add(new MeleeWeapon(13), new[] {WeaponRandomizer.Weapons[13].GetBuyPrice(), maxValue});
			
			return dictionary;
		}

		/// <summary>
		/// Replaces the getAdventureShopStock method in Utility.cs with this file's NewGetAdventureShopStock method
		/// and the getItemlevel method in MeleeWeapon.cs with this file's NewGetItemLevel method
		/// NOTE: THIS IS UNSAFE CODE, CHANGE WITH EXTREME CAUTION
		/// </summary>
		public static void FixAdventureShopBuyAndSellPrices()
		{
			if (Globals.Config.Weapons.Randomize || Globals.Config.Boots.Randomize)
			{
				MethodInfo methodToReplace = typeof(Utility).GetMethod("getAdventureShopStock");
				MethodInfo methodToInject = typeof(OverriddenAdventureShop).GetMethod("NewGetAdventureShopStock");
				Globals.RepointMethod(methodToReplace, methodToInject);
			}
		}
	}
}
