﻿using System;
using System.Collections.Generic;

namespace Randomizer
{
	/// <summary>
	/// Modifies weapons
	/// </summary>
	public class WeaponRandomizer
	{
		/// <summary>
		/// Returns the object use to modify the weapons
		/// </summary>
		/// <returns />
		public static Dictionary<int, string> Randomize()
		{
			Dictionary<int, WeaponItem> weaponDictionary = WeaponData.Items();
			Dictionary<int, string> stringReplacements = new Dictionary<int, string>();
			foreach (WeaponItem weapon in weaponDictionary.Values)
			{
				RandomizeWeapon(weapon);
				stringReplacements.Add(weapon.Id, weapon.ToString());
			}

			WriteToSpoilerLog(weaponDictionary);
			return stringReplacements;
		}

		/// <summary>
		/// Randomizes the values on the given weapon
		/// </summary>
		/// <param name="weapon">The weapon to randomize</param>
		private static void RandomizeWeapon(WeaponItem weapon)
		{
			if (weapon.Type == WeaponType.Slingshot)
			{
				// The ONLY thing that matters for slingshots is where you get them, so
				// randomizing them won't really do anything...
				return;
			}

			RandomizeWeaponType(weapon);
			RandomizeWeaponDamage(weapon);
			RandomizeWeaponCrits(weapon);
			RandomizeWeaponKnockback(weapon);
			RandomizeWeaponSpeed(weapon);
			RandomizeWeaponAOE(weapon);
			RandomizeWeaponPrecision(weapon);
			RandomizeWeaponDefense(weapon);
			RandomizeWeaponDropInfo(weapon);
			SetWeaponDescription(weapon);

			//TODO: Randomize weapon name
		}

		/// <summary>
		/// Randomizes the weapon type
		/// - 1/4 chance of each type that isn't a slingshot
		/// </summary>
		/// <param name="weapon">The weapon to randomize</param>
		private static void RandomizeWeaponType(WeaponItem weapon)
		{
			weapon.Type = (WeaponType)Range.GetRandomValue(0, 3);
		}

		/// <summary>
		/// Randomizes weapon damage based on the original max damage
		/// - if the max damage is under 10 - has a 50% variance
		/// - if the max damage is under 50 - has a 30% variance
		/// - if the max damage is over 50,- has a 20% variance
		/// </summary>
		/// <param name="weapon">The weapon to randomize</param>
		private static void RandomizeWeaponDamage(WeaponItem weapon)
		{
			const int percentageUnder10 = 50;
			const int percentageUnder50 = 30;
			const int percentageOver50 = 20;

			int minDamage = weapon.Damage.MinValue;
			int maxDamage = weapon.Damage.MaxValue;
			int percentage = 0;

			if (maxDamage < 10) { percentage = percentageUnder10; }
			else if (maxDamage < 50) { percentage = percentageUnder50; }
			else { percentage = percentageOver50; }

			int minValueToUse = Globals.RNGGetIntWithinPercentage(minDamage, percentage);
			int maxValueToUse = Globals.RNGGetIntWithinPercentage(maxDamage, percentage);

			weapon.Damage = new Range(minValueToUse, maxValueToUse);
		}

		/// <summary>
		/// Randomize the weapon crit stats
		/// - 1% chance of a 0.1% crit with a multiplier of 100
		/// - 4% chance of 8-12% crit with a multiplier of 1.5-2.5
		/// - Else, 1.5-3% crit with a multiplier of 2-3.5%
		/// </summary>
		/// <param name="weapon">The weapon to randomize</param>
		private static void RandomizeWeaponCrits(WeaponItem weapon)
		{
			if (Globals.RNGGetNextBoolean(1))
			{
				weapon.CritChance = 0.001;
				weapon.CritMultiplier = 100;
			}

			else if (Globals.RNGGetNextBoolean(4))
			{
				weapon.CritChance = Range.GetRandomValue(8, 12) / 100;
				weapon.CritMultiplier = Range.GetRandomValue(15, 25) / 1000; // This should be 1.5% - 2.5%
			}

			else
			{
				weapon.CritChance = Range.GetRandomValue(15, 30) / 1000;
				weapon.CritMultiplier = Range.GetRandomValue(20, 35) / 1000;
			}
		}

		/// <summary>
		/// Assigns a random weapon knockback
		/// - 5% chance of 1.6 - 2.0
		/// - else 0.5 - 1.6
		/// </summary>
		/// <param name="weapon">The weapon to set the knockback for</param>
		private static void RandomizeWeaponKnockback(WeaponItem weapon)
		{
			if (Globals.RNGGetNextBoolean(5))
			{
				weapon.Knockback = Range.GetRandomValue(16, 20) / 10;
			}

			else
			{
				weapon.Knockback = Range.GetRandomValue(5, 16) / 10;
			}
		}

		/// <summary>
		/// Assigns the weapon's speed
		/// - 5% chance of max speed
		/// - 10% chance of slow speed (-16 to -1)
		/// - 50% chance of 0
		/// - Else, value from -8 to 8
		/// </summary>
		/// <param name="weapon">The weapon to set the speed for</param>
		private static void RandomizeWeaponSpeed(WeaponItem weapon)
		{
			if (Globals.RNGGetNextBoolean(5))
			{
				weapon.Speed = 308;
			}

			else if (Globals.RNGGetNextBoolean(10))
			{
				weapon.Speed = Range.GetRandomValue(-16, -1);
			}

			else if (Globals.RNGGetNextBoolean())
			{
				weapon.Speed = 0;
			}

			else
			{
				weapon.Speed = Range.GetRandomValue(-8, 8);
			}
		}

		/// <summary>
		/// Assigns a random AOE value to the weapon
		/// - 80% chance of 0
		/// - Else, value from 0.1 - 3.5
		/// </summary>
		/// <param name="weapon">The weapon to assign the AOE to</param>
		private static void RandomizeWeaponAOE(WeaponItem weapon)
		{
			if (Globals.RNGGetNextBoolean(80))
			{
				weapon.AddedAOE = 0;
			}

			else
			{
				weapon.AddedAOE = Range.GetRandomValue(1, 35) / 10;
			}
		}

		/// <summary>
		/// Assigns a random precision value to the weapon
		/// - 80% chance of 0
		/// - else 1 - 10
		/// </summary>
		/// <param name="weapon">The weapon to assign the precision value</param>
		private static void RandomizeWeaponPrecision(WeaponItem weapon)
		{
			if (Globals.RNGGetNextBoolean(80))
			{
				weapon.AddedPrecision = 0;
			}

			else
			{
				weapon.AddedPrecision = Range.GetRandomValue(1, 10);
			}
		}

		/// <summary>
		/// Assigns a random defense value to the weapon
		/// - 95% chance of 0
		/// - else 1-5
		/// </summary>
		/// <param name="weapon">The weapon to add the defense value</param>
		private static void RandomizeWeaponDefense(WeaponItem weapon)
		{
			if (Globals.RNGGetNextBoolean(95))
			{
				weapon.AddedDefense = 0;
			}

			else
			{
				weapon.AddedDefense = Range.GetRandomValue(1, 5);
			}
		}

		/// <summary>
		/// Randomizes the weapon drop info (where you receive weapons in mine containers).
		/// This does not affect galaxy items.
		/// - If you currently can't receive the weapon in the mines, set its base floor based on its max damage
		///   - less than 10: floor between 1 and 20
		///   - less than 30: floor between 21 and 60
		///   - less than 50: floor between 61 and 100
		///   - else: floor between 110 and 110
		/// - else, set the base floor to be + or - 10 floors of the original value
		/// 
		/// In either case, set the min floor to be between 10 and 30 floors lower than the base
		/// </summary>
		/// <param name="weapon">The weapon to set drop info for</param>
		private static void RandomizeWeaponDropInfo(WeaponItem weapon)
		{
			if (!weapon.ShouldRandomizeDropInfo()) { return; }

			int baseMineLevel = weapon.BaseMineLevelDrop;
			if (baseMineLevel == -1)
			{
				int maxDamage = weapon.Damage.MaxValue;
				if (maxDamage < 10) { baseMineLevel = Range.GetRandomValue(1, 20); }
				if (maxDamage < 30) { baseMineLevel = Range.GetRandomValue(21, 60); }
				if (maxDamage < 50) { baseMineLevel = Range.GetRandomValue(61, 100); }
				else { baseMineLevel = Range.GetRandomValue(101, 110); }
			}

			else
			{
				baseMineLevel = FixMineLevelValue(baseMineLevel + Range.GetRandomValue(-10, 10));
			}

			weapon.BaseMineLevelDrop = baseMineLevel;
			weapon.MinMineLevelDrop = FixMineLevelValue(baseMineLevel - Range.GetRandomValue(10, 30), true);
		}

		/// <summary>
		/// Ensures the mine level is a value from 1 to 110
		/// </summary>
		/// <param name="mineLevel">The mine level</param>
		/// <param name="allowMinusOne">Whether to set values less than 1 to -1</param>
		/// <returns>If less than 1, 1 or -1; if greater than 110, 110; else, the value given</returns>
		private static int FixMineLevelValue(int mineLevel, bool allowMinusOne = false)
		{
			if (mineLevel < 1)
			{
				return allowMinusOne ? -1 : 1;
			}
			else if (mineLevel > 110) { return 110; }
			else { return mineLevel; }
		}

		/// <summary>
		/// Sets a weapon's description based on its attributes
		/// </summary>
		/// <param name="weapon">The weapon to set the description for</param>
		private static void SetWeaponDescription(WeaponItem weapon)
		{
			string description = "";
			switch (weapon.Type)
			{
				case WeaponType.Dagger:
				case WeaponType.StabbingSword:
					description = "Does stabbing damage.";
					break;
				case WeaponType.SlashingSword:
					description = "Does slashing damage.";
					break;
				case WeaponType.ClubOrHammer:
					description = "Does crushing damage.";
					break;
				default:
					Globals.ConsoleWrite($"ERROR: Assigning description to an invalid weapon type: {weapon.ToString()}");
					break;
			}

			if (weapon.CritMultiplier == 100)
			{
				description += " Crits for lethal damage very infrequently.";
			}

			else if (weapon.CritChance >= 8)
			{
				description += " Crits very often!";
			}

			if (weapon.Knockback >= 15)
			{
				description += " Makes enemies fly!";
			}

			if (weapon.Speed > 100)
			{
				description += " Fires as fast as you can pull the trigger.";
			}

			if (weapon.AddedPrecision > 4)
			{
				description += " Very accurate.";
			}

			if (weapon.AddedDefense > 0)
			{
				description += " Provides defense.";
			}

			if (weapon.Id == (int)WeaponIndexes.DarkSword)
			{
				description += " Heals when dealing damage.";
			}

			weapon.Description = description;
		}

		/// <summary>
		/// Writes the changed weapon info to the spoiler log
		/// </summary>
		/// <param name="modifiedWeaponDictionary">The dictionary with changed info</param>
		private static void WriteToSpoilerLog(Dictionary<int, WeaponItem> modifiedWeaponDictionary)
		{
			Globals.SpoilerWrite("==== WEAPONS ====");
			foreach (int id in modifiedWeaponDictionary.Keys)
			{
				WeaponItem weapon = modifiedWeaponDictionary[id];

				Globals.SpoilerWrite($"{id}: {weapon.OverrideName}");
				Globals.SpoilerWrite($"Type: {Enum.GetName(typeof(WeaponType), weapon.Type)}");
				Globals.SpoilerWrite($"Damage: {weapon.Damage.MinValue} - {weapon.Damage.MaxValue}");
				Globals.SpoilerWrite($"Crit Chance / Multiplier: {weapon.CritChance} / {weapon.CritMultiplier}");
				Globals.SpoilerWrite($"Knockback / Speed / AOE: {weapon.Knockback} / {weapon.Speed} / {weapon.AddedAOE}");
				Globals.SpoilerWrite($"Added Precision / Defense: {weapon.AddedPrecision} / {weapon.AddedDefense}");
				Globals.SpoilerWrite($"Base / Min Mine Level Drop: {weapon.BaseMineLevelDrop} / {weapon.MinMineLevelDrop}");
				Globals.SpoilerWrite("---");
			}
			Globals.SpoilerWrite("");
		}
	}
}