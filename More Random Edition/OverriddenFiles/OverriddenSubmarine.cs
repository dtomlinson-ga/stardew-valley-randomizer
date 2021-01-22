﻿using Microsoft.Xna.Framework;
using StardewValley;
using StardewValley.Locations;
using System.Collections.Generic;
using System.Linq;
using SVOBject = StardewValley.Object;

namespace Randomizer
{
	/// <summary>
	/// The submarine GameLocation - identical to the original Submarine.cs file, but with a
	/// different getFish function to include our randomized fish instead of their fish
	/// </summary>
	public class OverriddenSubmarine : Submarine
	{
		public OverriddenSubmarine() : base("Maps\\Submarine", "Submarine") { }

		/// <summary>
		/// The old submarine location
		/// </summary>
		private static Submarine NormalSubmarineLocation { get; set; }

		/// <summary>
		/// Replaces the submarine location with an overridden one so that the fish that
		/// appear there are correct
		/// </summary>
		public static void UseOverriddenSubmarine()
		{
			int submarineIndex;
			foreach (GameLocation location in Game1.locations)
			{
				if (location.Name == "Submarine")
				{
					if (location.GetType() != typeof(OverriddenSubmarine))
					{
						NormalSubmarineLocation = (Submarine)location;
					}

					submarineIndex = Game1.locations.IndexOf(location);
					Game1.locations[submarineIndex] = new OverriddenSubmarine();
					break;
				}
			}
		}

		/// <summary>
		/// Restores the submarine location - this should be done before saving the game
		/// to avoid a crash
		/// </summary>
		public static void RestoreSubmarineLocation()
		{
			if (NormalSubmarineLocation == null) { return; }

			int submarineIndex;
			foreach (GameLocation location in Game1.locations)
			{
				if (location.Name == "Submarine")
				{
					submarineIndex = Game1.locations.IndexOf(location);
					Game1.locations[submarineIndex] = NormalSubmarineLocation;
					break;
				}
			}
		}

		/// <summary>
		/// Gets the fish that can be found on the submarine
		/// </summary>
		/// <param name="millisecondsAfterNibble"></param>
		/// <param name="bait"></param>
		/// <param name="waterDepth"></param>
		/// <param name="who"></param>
		/// <param name="baitPotency"></param>
		/// <returns />
		public override SVOBject getFish(
			float millisecondsAfterNibble,
			int bait,
			int waterDepth,
			Farmer who,
			double baitPotency,
			Vector2 bobberTile,
			string locationName)
		{
			List<int> nightMarketFish = FishItem.Get(Locations.NightMarket).Select(x => x.Id).ToList();

			if (Game1.random.NextDouble() < 0.15)
				return new SVOBject(nightMarketFish[0], 1, false, -1, 0);
			if (Game1.random.NextDouble() < 0.23)
				return new SVOBject(nightMarketFish[1], 1, false, -1, 0);
			if (Game1.random.NextDouble() < 0.30)
				return new SVOBject(nightMarketFish[2], 1, false, -1, 0);
			if (Game1.random.NextDouble() < 0.01)
				return new SVOBject(797, 1, false, -1, 0);

			return new SVOBject(152, 1, false, -1, 0);
		}
	}
}
