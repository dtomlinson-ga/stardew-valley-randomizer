﻿using System.Collections.Generic;
using System.Linq;

namespace Randomizer
{
	public class CraftableItem : Item
	{
		public List<CraftingMaterialItem> RequiredItemsToCraft { get; } = new List<CraftingMaterialItem>();
		public string Path { get; set; }
		public string SkillString { get; set; }
		public Range LearnableLevels { get; set; } = new Range(1, 1);
		public bool IsLearnedOnLevelup
		{
			get { return SkillString.Length > 0; }
		}
		public CraftableCategories Category { get; set; }

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="id">The id of the item</param>
		/// <param name="path">The hard-coded path for this craftable item</param>
		/// <param name="skillString">The name of the skill you need to level up to learn the recipe</param>
		public CraftableItem(int id, string path, CraftableCategories category, string skillString = "") : base(id)
		{
			IsCraftable = true;
			Path = path;
			Category = category;
			SkillString = skillString;
		}

		/// <summary>
		/// Adds the given crafting material information to the items required to craft this item
		/// </summary>
		/// <param name="item">The item required</param>
		/// <param name="minValue">The minimum amount required</param>
		/// <param name="maxValue">The maximum amount required</param>
		public void AddCraftingMaterial(Item item, int minValue, int maxValue)
		{
			RequiredItemsToCraft.Add(new CraftingMaterialItem(item, minValue, maxValue));
		}

		/// <summary>
		/// Gets the level you learn this skill at
		/// </summary>
		/// <returns>
		/// Any value in the given range. Excludes 0, 5, and 10.
		/// Returns 9 if it's 10; returns 1 if it's 0; returns 4 or 6 if it's 5
		/// </returns>
		public int GetLevelLearnedAt()
		{
			int generatedLevel = LearnableLevels.GetRandomValue();
			if (generatedLevel > 8) { return 9; }
			if (generatedLevel < 1) { return 1; }
			if (generatedLevel == 5)
			{
				return Globals.RNGGetNextBoolean() ? 4 : 6;
			}

			return generatedLevel;
		}

		/// <summary>
		/// Gets the string to be used for the crafting recipe
		/// </summary>
		/// <returns></returns>
		public string GetCraftingString()
		{
			string itemsRequiredString = GetItemsRequired();
			string stringSuffix = IsLearnedOnLevelup ? $"{SkillString} {GetLevelLearnedAt()}" : "";
			string craftingString = $"{itemsRequiredString}{Path}{stringSuffix}";

			Globals.ConsoleWrite($"{Name} crafting string: {craftingString}");
			return craftingString;
		}

		/// <summary>
		/// Generates a string consisting of the items required to craft this item
		/// This will NOT return the same value each time it's called!
		/// </summary>
		/// <returns>
		/// A string consisting of the following format:
		/// itemId numberOfItemsRequired (repeat this x times)
		/// </returns>
		private string GetItemsRequired()
		{
			switch (Category)
			{
				case CraftableCategories.EasyAndNeedMany:
					return GetStringForEasyAndNeedMany();

				case CraftableCategories.Easy:
					return GetStringForEasy();

				case CraftableCategories.ModerateAndNeedMany:
					return GetStringForModerateAndNeedMany();

				case CraftableCategories.Moderate:
					return GetStringForModerate();

				case CraftableCategories.DifficultAndNeedMany:
					return GetStringForDifficultAndNeedMany();

				case CraftableCategories.Difficult:
					return GetStringForDifficult();

				case CraftableCategories.Endgame:
					return GetStringForEndgame();

				default:
					Globals.ConsoleWrite($"ERROR: invalid category when generating recipe for {Name}!");
					return "18 9"; // just a random value for now
			}
		}

		private string GetStringForEasyAndNeedMany()
		{
			Item item = ItemList.GetRandomCraftableItem(
				new List<ObtainingDifficulties> { ObtainingDifficulties.NoRequirements },
				this,
				null,
				true
			);

			return $"{item.Id} 1";
		}

		/// <summary>
		/// Uses either two really easy to get items (one being a resource), or one slightly harder to get item		
		/// /// </summary>
		/// <returns>The item string</returns>
		private string GetStringForEasy()
		{
			bool useHarderItem = Globals.RNGGetNextBoolean();
			if (useHarderItem)
			{
				return ItemList.GetRandomCraftableItem(
					new List<ObtainingDifficulties> { ObtainingDifficulties.SmallTimeRequirements },
					this
				).GetStringForCrafting();
			}

			Item resourceItem = ItemList.GetRandomCraftableItem(
				new List<ObtainingDifficulties> { ObtainingDifficulties.NoRequirements },
				this,
				null,
				true
			);
			Item otherItem = ItemList.GetRandomCraftableItem(
				new List<ObtainingDifficulties> { ObtainingDifficulties.NoRequirements },
				this,
				new List<int> { Id, resourceItem.Id }
			);

			return $"{resourceItem.GetStringForCrafting()} {otherItem.GetStringForCrafting()}";
		}

		/// <summary>
		/// One of the following, limited to one item needed
		/// - Three sets of SmallTime
		/// - One MediumTime, one SmallTime/No, one No
		/// - One MediumTime, one SmallTime
		/// </summary>
		/// <returns>The item string</returns>
		private string GetStringForModerateAndNeedMany()
		{
			string output = string.Empty;
			foreach (Item item in GetListOfItemsForModerate())
			{
				output += $"{item.Id} 1 ";
			}
			return output.Trim();
		}

		/// <summary>
		/// One of the following
		/// - Three sets of SmallTime
		/// - One MediumTime, one SmallTime/No, one No
		/// - One MediumTime, one SmallTime
		/// </summary>
		/// <returns>The item string</returns>
		private string GetStringForModerate()
		{
			string output = string.Empty;
			foreach (Item item in GetListOfItemsForModerate())
			{
				output += $"{item.GetStringForCrafting()} ";
			}
			return output.Trim();
		}

		/// <summary>
		/// Gets the list of items for any of the moderate cases
		/// </summary>
		/// <returns />
		private List<Item> GetListOfItemsForModerate()
		{
			List<Item> possibleItems = ItemList.Items.Values.ToList();
			Item item1, item2, item3;
			switch (Globals.RNG.Next(0, 3))
			{
				case 0:
					item1 = ItemList.GetRandomCraftableItem(
						new List<ObtainingDifficulties> { ObtainingDifficulties.SmallTimeRequirements },
						this
					);
					item2 = ItemList.GetRandomCraftableItem(
						new List<ObtainingDifficulties> { ObtainingDifficulties.SmallTimeRequirements },
						this,
						new List<int> { item1.Id }
					);
					item3 = ItemList.GetRandomCraftableItem(
						new List<ObtainingDifficulties> { ObtainingDifficulties.SmallTimeRequirements },
						this,
						new List<int> { item1.Id, item2.Id }
					);
					return new List<Item> { item1, item2, item3 };
				case 1:
					item1 = ItemList.GetRandomCraftableItem(
						new List<ObtainingDifficulties> { ObtainingDifficulties.MediumTimeRequirements },
						this
					);
					item2 = ItemList.GetRandomCraftableItem(
						new List<ObtainingDifficulties> { ObtainingDifficulties.SmallTimeRequirements, ObtainingDifficulties.NoRequirements },
						this,
						new List<int> { item1.Id }
					);
					item3 = ItemList.GetRandomCraftableItem(
						new List<ObtainingDifficulties> { ObtainingDifficulties.NoRequirements },
						this,
						new List<int> { item1.Id, item2.Id }
					);
					return new List<Item> { item1, item2, item3 };
				default:
					item1 = ItemList.GetRandomCraftableItem(
						new List<ObtainingDifficulties> { ObtainingDifficulties.MediumTimeRequirements },
						this
					);
					item2 = ItemList.GetRandomCraftableItem(
						new List<ObtainingDifficulties> { ObtainingDifficulties.SmallTimeRequirements },
						this,
						new List<int> { item1.Id }
					);
					return new List<Item> { item1, item2 };
			}
		}

		/// <summary>
		/// One of the following
		/// - Three sets of MediumTime
		/// - One LongTime, one MediumTime/SmallTime, MediumTime/SmallTime/No
		/// - Two sets of LongTime
		/// </summary>
		/// <returns>The item string</returns>
		private string GetStringForDifficultAndNeedMany()
		{
			string output = string.Empty;
			foreach (Item item in GetListOfItemsForDifficult())
			{
				output += $"{item.Id} 1 ";
			}
			return output.Trim();
		}

		/// <summary>
		/// One of the following, limited to one item needed
		/// - Three sets of MediumTime
		/// - One LongTime, one MediumTime/SmallTime, MediumTime/SmallTime/No
		/// - Two sets of LongTime
		/// </summary>
		/// <returns>The item string</returns>
		private string GetStringForDifficult()
		{
			string output = string.Empty;
			foreach (Item item in GetListOfItemsForDifficult())
			{
				output += $"{item.GetStringForCrafting()} ";
			}
			return output.Trim();
		}

		/// <summary>
		/// Gets the list of items for any of the moderate cases
		/// </summary>
		/// <returns />
		private List<Item> GetListOfItemsForDifficult()
		{
			List<Item> possibleItems = ItemList.Items.Values.ToList();
			Item item1, item2, item3;
			switch (Globals.RNG.Next(0, 3))
			{
				case 0:
					item1 = ItemList.GetRandomCraftableItem(
						new List<ObtainingDifficulties> { ObtainingDifficulties.MediumTimeRequirements },
						this
					);
					item2 = ItemList.GetRandomCraftableItem(
						new List<ObtainingDifficulties> { ObtainingDifficulties.MediumTimeRequirements },
						this,
						new List<int> { item1.Id }
					);
					item3 = ItemList.GetRandomCraftableItem(
						new List<ObtainingDifficulties> { ObtainingDifficulties.MediumTimeRequirements },
						this,
						new List<int> { item1.Id, item2.Id }
					);
					return new List<Item> { item1, item2, item3 };
				case 1:
					item1 = ItemList.GetRandomCraftableItem(
						new List<ObtainingDifficulties> { ObtainingDifficulties.LargeTimeRequirements },
						this
					);
					item2 = ItemList.GetRandomCraftableItem(
						new List<ObtainingDifficulties> { ObtainingDifficulties.MediumTimeRequirements, ObtainingDifficulties.SmallTimeRequirements },
						this,
						new List<int> { item1.Id }
					);
					item3 = ItemList.GetRandomCraftableItem(
						new List<ObtainingDifficulties> { ObtainingDifficulties.MediumTimeRequirements, ObtainingDifficulties.SmallTimeRequirements, ObtainingDifficulties.NoRequirements },
						this,
						new List<int> { item1.Id, item2.Id }
					);
					return new List<Item> { item1, item2, item3 };
				default:
					item1 = ItemList.GetRandomCraftableItem(
						new List<ObtainingDifficulties> { ObtainingDifficulties.LargeTimeRequirements },
						this
					);
					item2 = ItemList.GetRandomCraftableItem(
						new List<ObtainingDifficulties> { ObtainingDifficulties.LargeTimeRequirements },
						this,
						new List<int> { item1.Id }
					);
					return new List<Item> { item1, item2 };
			}
		}

		/// <summary>
		/// - Three sets of LongTime
		/// - Two sets of LongTime, one SmallTime or less
		/// - One set of Longtime, two MediumTime or less
		/// </summary>
		/// <returns>The item string</returns>
		private string GetStringForEndgame()
		{
			List<Item> possibleItems = ItemList.Items.Values.ToList();
			Item item1, item2, item3;
			switch (Globals.RNG.Next(0, 3))
			{
				case 0:
					item1 = ItemList.GetRandomCraftableItem(
						new List<ObtainingDifficulties> { ObtainingDifficulties.LargeTimeRequirements },
						this
					);
					item2 = ItemList.GetRandomCraftableItem(
						new List<ObtainingDifficulties> { ObtainingDifficulties.LargeTimeRequirements },
						this,
						new List<int> { item1.Id }
					);
					item3 = ItemList.GetRandomCraftableItem(
						new List<ObtainingDifficulties> { ObtainingDifficulties.LargeTimeRequirements },
						this,
						new List<int> { item1.Id, item2.Id }
					);
					break;
				case 1:
					item1 = ItemList.GetRandomCraftableItem(
						new List<ObtainingDifficulties> { ObtainingDifficulties.LargeTimeRequirements },
						this
					);
					item2 = ItemList.GetRandomCraftableItem(
						new List<ObtainingDifficulties> { ObtainingDifficulties.LargeTimeRequirements },
						this,
						new List<int> { item1.Id }
					);
					item3 = ItemList.GetRandomCraftableItem(
						new List<ObtainingDifficulties> { ObtainingDifficulties.SmallTimeRequirements, ObtainingDifficulties.NoRequirements },
						this,
						new List<int> { item1.Id, item2.Id }
					);
					break;
				default:
					var mediumOrLess = new List<ObtainingDifficulties> {
						ObtainingDifficulties.MediumTimeRequirements, ObtainingDifficulties.SmallTimeRequirements, ObtainingDifficulties.NoRequirements
					};
					item1 = ItemList.GetRandomCraftableItem(
						new List<ObtainingDifficulties> { ObtainingDifficulties.LargeTimeRequirements },
						this
					);
					item2 = ItemList.GetRandomCraftableItem(mediumOrLess, this, new List<int> { item1.Id });
					item3 = ItemList.GetRandomCraftableItem(mediumOrLess, this, new List<int> { item1.Id, item2.Id });
					break;
			}

			return $"{item1.GetStringForCrafting()} {item2.GetStringForCrafting()} {item3.GetStringForCrafting()}";
		}
	}
}