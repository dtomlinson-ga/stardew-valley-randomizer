﻿using System.Collections.Generic;

namespace Randomizer
{
	public class NameAndDescriptionRandomizer
	{
		public static List<string> GenerateVegetableNames(int numberOfNames)
		{
			List<string> adjectives = new List<string>
			{
				"Juicy",
				"Spicy",
				"Sweet",
				"Hot",
				"Cold",
				"Bright",
				"Moist",
				"Funky",
				"Bok",
				"Ancient",
				"Sour",
				"Miracle",
				"Pelican",
				"Stardew",
				"Prickly",
				"Sunny",
				"Salty",
				"Savory",
				"Wild",
				"Common",
				"Tiny",
				"Giant",
				"Young"
			};

			List<string> prefixes = new List<string>
			{
				"Mc",
				"Joja",
				"Pome",
				"Cauli",
				"Pota",
				"Star",
				"Drago",
				"Vege",
				"Rue",
				"Pyne",
				"Dew",
				"Choco",
				"Coffe",
				"Radi",
				"Cabba",
				"Toma",
				"Aarti",
				"Egg",
				"Pump",
				"Coco",
				"Cucu",
				"Alfa",
				"Carro",
				"Squa",
				"Zucchi",
				"Bana",
				"Apri",
				"Lemo",
				"Passion",
				"Huckle",
				"Kiwi",
				"Lime",
				"Boysen",
				"Crann",
				"Clementi",
				"Honey",
				"Pear",
				"Rasp",
				"Water",
				"Tange"
			};

			List<string> suffixes = new List<string>
			{
				"granite",
				"nana",
				"flour",
				"bean",
				"tato",
				"froot",
				"barb",
				"berry",
				"apple",
				"dew",
				"korn",
				"lait",
				"y",
				"cado",
				"to",
				"ranth",
				"choke",
				"trout",
				"yam",
				"lli",
				"iander",
				"onion",
				"snip",
				"melon",
				"plum",
				"ngo",
				"quat",
				"rind",
				"rillo",
				"rant",
				"pepper",
				"rry",
				"fig",
				"jube",
				"dropp",
				"loupe",
				"paya",
				"pear",
				"rene",
				"root"
			};

			return (CreateNameFromPieces(numberOfNames, adjectives, prefixes, suffixes));
		}

		public static List<string> GenerateFlowerNames(int numberOfNames)
		{
			List<string> adjectives = new List<string>
			{
				"Fragrant",
				"Ugly",
				"Sweet",
				"Fairy",
				"Morning",
				"Creeping",
				"Wild",
				"Giant",
				"Common",
				"Rough",
				"Field",
				"Lesser"
			};

			List<string> prefixes = new List<string>
			{
				"Daffo",
				"Mary",
				"Snap",
				"Vio",
				"Canna",
				"Aza",
				"Hibi",
				"Hya",
				"Cro",
				"Jasmi",
				"Bella",
				"Poi",
				"Olea",
				"Hem",
				"Night",
				"Rhodo",
				"Frangi",
				"Bell",
				"Forget-me-"
			};

			List<string> suffixes = new List<string>
			{
				"ster",
				"hock",
				"fodil",
				"lily",
				"iris",
				"cissus",
				"drop",
				"suckle",
				"mellia",
				"lilac",
				"rose",
				"synth",
				"bane",
				"laurel",
				"weed",
				"dendrite",
				"nettle",
				"flower",
				"wort"
			};

			return (CreateNameFromPieces(numberOfNames, adjectives, prefixes, suffixes));
		}

		public static List<string> GenerateFishNames(int numberOfNames)
		{
			List<string> adjectives = new List<string>
			{
				"Largemouth",
				"Smallmouth",
				"Rainbow",
				"Jumping",
				"Salty",
				"Fresh",
				"Super",
				"Ice",
				"Lava",
				"Sandy",
				"Void",
				"Armored",
				"Atlantic",
				"Bristlemouth",
				"Bigeye",
				"Cutthroat",
				"Deepwater",
				"Dwarf",
				"Electric",
				"Flathead",
				"Glass",
				"Round",
				"Ribbon",
				"Fat",
				"Sabertooth",
				"Toxic",
				"Whale",
				"Whitetip",
				"Thorn",
				"Sixgill",
				"Southern",
				"Pacific"
			};

			List<string> prefixes = new List<string>
			{
				"Puffer",
				"Tu",
				"Brea",
				"Trou",
				"Sal",
				"Wal",
				"Per",
				"Car",
				"Dog",
				"Pi",
				"Son",
				"Ee",
				"Un",
				"Octop",
				"Squi",
				"Gost",
				"Bull",
				"Chu",
				"Dour",
				"Alba",
				"Sha",
				"Linc",
				"Halli",
				"Wo",
				"Ange",
				"Ancho",
				"Drago",
				"Bara",
				"Ba",
				"Bram",
				"Bone",
				"Box",
				"Bri",
				"Can",
				"Lem",
				"Dab",
				"Dart",
				"Floun",
				"Mor",
				"Gob",
				"Grou",
				"Had",
				"Ho",
				"Ma",
				"Ina",
				"Koi",
				"Kelp",
				"Moon",
				"Mar",
				"Milk",
				"Mul",
				"Mud",
				"Pol",
				"Piran",
				"Quill",
				"Rock",
				"Sol",
				"Lun",
				"Sting",
				"Star",
				"Squea",
				"Vel",
				"Tilla"
			};

			List<string> suffixes = new List<string>
			{
				"phish",
				"dine",
				"t",
				"m",
				"eye",
				"ch",
				"arp",
				"let",
				"rring",
				"opus",
				"apper",
				"umber",
				"ion",
				"geon",
				"out",
				"ub",
				"ado",
				"chore",
				"ad",
				"cod",
				"bu",
				"skip",
				"jack",
				"ling",
				"ish",
				"ma",
				"ovy",
				"shark",
				"cuda",
				"ass",
				"luga",
				"fin",
				"tongue",
				"diru",
				"sucker",
				"oach",
				"ray",
				"now",
				"kerel",
				"ail",
				"ag",
				"k",
				"g",
				"et",
				"b",
				"sh",
				"ock",
				"ki",
				"d",
				"f",
				"h",
				"m",
				"enn",
				"skipper",
				"ha",
				"le",
				"ng",
				"ley",
				"ace",
				"apia",
				"io",
				"gel",
				"ghoti"
			};

			return (CreateNameFromPieces(numberOfNames, adjectives, prefixes, suffixes));

		}

		public static List<string> GenerateCropDescriptions(int numberOfDescriptions)
		{
			List<string> descriptionBases = new List<string>
			{
				"Loved by Lord [name] for its [adjective] taste.",
				"The favorite food of the Marquis de [noun].",
				"Tastes like [noun].",
				"Very [adjective], but not [adjective2].",
				"Like [noun], not wholly unpleasant.",
				"First cultivated by the [adjective] Dr. [name].",
				"Would be great with slices of [noun].",
				"Part of a [adjective] breakfast!",
				"Your Aunt [name]'s favorite as a child.",
				"Back in 1945, these were called [noun].",
				"It reeks of [adjective]!",
				"A staple food of the Isle of [noun].",
				"Tastes like [noun] mixed with [noun2].",
				"Also sold at [name]'s Grocery.",
				"Like licking [adjective] plastic.",
				"Mc[name]'s new burger uses these as a topping.",
				"An amazing topping for [noun]!",
				"A popular frosting for [name] Cake.",
				"Adds a [adjective] flavor to dishes.",
				"Closely related to [noun].",
				"Makes a great side to entrees of [noun].",
				"Popular with [name], Ruler of Parsnandia.",
				"It's [adjective] with a hint of sweetness.",
				"The popular alcohol, [name]'s [noun], is fermented from this crop.",
				"Its [adjective] flavor may make some go blind when tasted.",
				"Can be used medicinally to cure [adjective] [noun] disease.",
				"It's [noun]-licking good!",
				"Often used in [adjective] desserts.",
				"An extremely [adjective] crop that loves to be watered.",
				"Slightly [adjective] with an aftertaste of [noun]",
				"Your friend [name] is allergic to these.",
				"Nobody knows whether it's a fruit, vegetable, or none of the above.",
				"Professional chefs never cook this with [noun].",
				"The renowned chef, [name] Ramsay, always eats it fresh.",
				"Its sweet aroma may attract [noun].",
				"Can be carved into a festive decoration for St. [name]'s Day.",
				"One of the most [adjective] things you've ever smelled.",
				"The skin has a high concentration of [noun].",
				"Discovered falling from the sky during Hurricane [name].",
				"If your name is [name] you will love this crop!",
				"A key ingredient in [name] brand energy drinks.",
				"Beloved by the masses.",
				"Always served at the [name] Fan Club's annual conventions.",
				"It's a mystery to everyone.",
				"Hated by lovers of [noun] everywhere.",
				"Some people find it too [adjective] for them.",
				"Tastes [adjective] when steeped into tea.",
				"Karate master [name] Lee first cultivated this crop.",
				"Perfect for tea with Queen [name]."
			};
			List<string> nouns = new List<string>
			{
				"belts",
				"tongues",
				"oranges",
				"palms",
				"stairs",
				"suits",
				"vests",
				"lighters",
				"backs",
				"trousers",
				"hairs",
				"hands",
				"pocket watches",
				"crows",
				"turkeys",
				"shirts",
				"balloons",
				"brains",
				"noses",
				"ostriches",
				"peacocks",
				"pen drives",
				"boxer shorts",
				"stoves",
				"guavas",
				"beans",
				"sharks",
				"eyes",
				"whales",
				"desks",
				"toes",
				"wolves",
				"ribs",
				"cheeks",
				"lips",
				"watermelons",
				"iron boxes",
				"wrists",
				"rice",
				"ginger",
				"music players",
				"parrots",
				"panthers",
				"freezers",
				"earrings",
				"spoons",
				"butter",
				"grapes",
				"koel birds",
				"jackets",
				"grains",
				"tables",
				"gowns",
				"sweaters",
				"sheep",
				"bermudas",
				"ears",
				"necks",
				"brinjals",
				"foxes",
				"pandas",
				"blackboards",
				"ties",
				"dogs",
				"underarms",
				"chairs",
				"mice",
				"ovens",
				"legs",
				"pasta",
				"bears",
				"aprons",
				"sandals",
				"bulbs",
				"chests",
				"hats",
				"frocks",
				"cats",
				"fans",
				"mangoes",
				"buckles",
				"bread",
				"swans",
				"jaws",
				"tigers",
				"pigeons",
				"ladyfingers",
				"pencils",
				"feet",
				"drumsticks",
				"monkeys",
				"frogs",
				"goats",
				"cauliflowers",
				"pomegranates",
				"leggings",
				"milk",
				"earbuds",
				"eggs",
				"tailor birds",
				"lungs",
			};
			List<string> adjectives = new List<string>
			{
				"caring",
				"first",
				"loving",
				"wandering",
				"deep",
				"curious",
				"youthful",
				"evasive",
				"quickest",
				"cruel",
				"fluffy",
				"faint",
				"enchanting",
				"rude",
				"fair",
				"temporary",
				"healthy",
				"earthy",
				"domineering",
				"plain",
				"whispering",
				"delicate",
				"muddled",
				"evanescent",
				"wretched",
				"general",
				"eatable",
				"nippy",
				"available",
				"nostalgic",
				"romantic",
				"reflective",
				"squealing",
				"toothsome",
				"economic",
				"square",
				"holistic",
				"worried",
				"warlike",
				"cowardly",
				"woozy",
				"witty",
				"old",
				"blue",
				"unnatural",
				"rebel",
				"dusty",
				"succinct",
				"psychotic",
				"lucky",
				"possessive",
				"watery",
				"silent",
				"inquisitive",
				"public",
				"acid",
				"astonishing",
				"cold",
				"quiet",
				"wooden",
				"lewd",
				"bumpy",
				"real",
				"careless",
				"striped",
				"scientific",
				"synonymous",
				"jobless",
				"bright",
				"kaput",
				"encouraging",
				"abject",
				"useless",
				"defective",
				"chivalrous",
				"ill-informed",
				"common",
				"tiresome",
				"insidious",
				"blue-eyed",
				"wry",
				"tough",
				"hungry",
				"gleaming",
				"acidic",
				"chunky",
				"marvelous",
				"friendly",
				"alcoholic",
				"abashed",
				"defeated",
				"relieved",
				"silky",
				"spooky",
				"debonair",
				"gentle",
				"receptive",
				"festive",
				"angry",
				"mundane"
			};
			List<string> names = new List<string>
			{
				"Lourdes",
				"Barney",
				"Juana",
				"Julia",
				"Matt",
				"Jean",
				"Michelle",
				"Rene",
				"Moises",
				"Zelma",
				"Nigel",
				"Mattie",
				"Maximo",
				"Joanna",
				"Edwina",
				"Hong",
				"Cara",
				"Chester",
				"Gerardo",
				"Fannie",
				"Kara",
				"Reed",
				"Hollie",
				"Kip",
				"Lillian",
				"Saundra",
				"Loretta",
				"Antonio",
				"Benita",
				"Jerome",
				"Enrique",
				"Nicky",
				"Bradley",
				"Gay",
				"Cameron",
				"Norma",
				"Wilmer",
				"Alison",
				"Armando",
				"Rhoda",
				"Maryanne",
				"Lillie",
				"Lydia",
				"Joesph",
				"Clare",
				"Ramiro",
				"Alex",
				"Daphne",
				"Shelton",
				"David",
				"Robt",
				"Colin",
				"Freddy",
				"Adele",
				"Lara",
				"Jerri",
				"Brock",
				"Rickie",
				"Ezra",
				"Fritz",
				"Walker",
				"Alberto",
				"Alden",
				"Amanda",
				"Normand",
				"Nicholas",
				"Harold",
				"Helene",
				"Lola",
				"Shana",
				"Jesse",
				"Rosanna",
				"Leif",
				"Cornell",
				"Ava",
				"Elvin",
				"Raymond",
				"Hunter",
				"Roberta",
				"Pete",
				"Barry",
				"Fran",
				"Patsy",
				"Selma",
				"Dorthy",
				"Wayne",
				"Caroline",
				"Lavern",
				"Myrna",
				"Morris",
				"Mariano",
				"Leonardo",
				"Reva",
				"Deanne",
				"Wiley",
				"Lionel",
				"Howard",
				"Karin",
				"Miranda",
				"Alvin",
			};

			return CreateDescriptionFromPieces(numberOfDescriptions, descriptionBases, nouns, adjectives, names);
		}

		public static List<string> GenerateBootDescriptions(int numberOfDescriptions)
		{
			List<string> descriptionBases = new List<string>
			{
				"A little [adjective]... but [adjective2]!",
				"Protection from the [noun].",
				"The [noun] are very [adjective].",
				"They're [adjective] for extra [noun].",
				"Reinforced with [adjective] [noun].",
				"The [adjective] lining keeps your [noun] so [adjective2].",
				"Designed with extreme [noun] in mind.",
				"Made from [adjective] black [noun].",
				"It's said these can withstand the [adjective] [noun].",
				"The [adjective] [noun] permeate the fabric.",
				"The [adjective] [noun] give them a [adjective2] sheen.",
				"It's the height of country [noun].",
				"Made with [noun] by [name]. 100% [adjective]!",
				"The [noun] are made of [adjective] [noun2].",

				"Worn by people who like [noun].",
				"The [noun] are easy to tie.",
				"Some [adjective] people say you should never wear these while it's raining.",
				"In ancient times, these were made out of [noun].",
				"King [name] liked to wear these while sitting on his [noun].",
				"They're [adjective] and [adjective2] to wear.",
				"They cost as much as 5 [noun]!",
				"Made in [noun].",
				"Renowned by the famous [adjective] musician, [name].",
				"Reminiscent of the color of [noun].",
				"Best when worn with [adjective] socks.",
				"Worn by [noun] everywehre.",
				"Great for walking in the [noun].",
				"The [noun] agree! These shoes are [adjective]!"

			};
			List<string> nouns = new List<string>
			{
				"belts",
				"tongues",
				"oranges",
				"palms",
				"stairs",
				"suits",
				"vests",
				"lighters",
				"backs",
				"trousers",
				"hairs",
				"hands",
				"pocket watches",
				"crows",
				"turkeys",
				"shirts",
				"balloons",
				"brains",
				"noses",
				"ostriches",
				"peacocks",
				"pen drives",
				"boxer shorts",
				"stoves",
				"guavas",
				"beans",
				"sharks",
				"eyes",
				"whales",
				"desks",
				"toes",
				"wolves",
				"ribs",
				"cheeks",
				"lips",
				"watermelons",
				"iron boxes",
				"wrists",
				"rice",
				"ginger",
				"music players",
				"parrots",
				"panthers",
				"freezers",
				"earrings",
				"spoons",
				"butter",
				"grapes",
				"koel birds",
				"jackets",
				"grains",
				"tables",
				"gowns",
				"sweaters",
				"sheep",
				"bermudas",
				"ears",
				"necks",
				"brinjals",
				"foxes",
				"pandas",
				"blackboards",
				"ties",
				"dogs",
				"underarms",
				"chairs",
				"mice",
				"ovens",
				"legs",
				"pasta",
				"bears",
				"aprons",
				"sandals",
				"bulbs",
				"chests",
				"hats",
				"frocks",
				"cats",
				"fans",
				"mangoes",
				"buckles",
				"bread",
				"swans",
				"jaws",
				"tigers",
				"pigeons",
				"ladyfingers",
				"pencils",
				"feet",
				"drumsticks",
				"monkeys",
				"frogs",
				"goats",
				"cauliflowers",
				"pomegranates",
				"leggings",
				"milk",
				"earbuds",
				"eggs",
				"tailor birds",
				"lungs",
			};
			List<string> adjectives = new List<string>
			{
				"caring",
				"first",
				"loving",
				"wandering",
				"deep",
				"curious",
				"youthful",
				"evasive",
				"quickest",
				"cruel",
				"fluffy",
				"faint",
				"enchanting",
				"rude",
				"fair",
				"temporary",
				"healthy",
				"earthy",
				"domineering",
				"plain",
				"whispering",
				"delicate",
				"muddled",
				"evanescent",
				"wretched",
				"general",
				"eatable",
				"nippy",
				"available",
				"nostalgic",
				"romantic",
				"reflective",
				"squealing",
				"toothsome",
				"economic",
				"square",
				"holistic",
				"worried",
				"warlike",
				"cowardly",
				"woozy",
				"witty",
				"old",
				"blue",
				"unnatural",
				"rebel",
				"dusty",
				"succinct",
				"psychotic",
				"lucky",
				"possessive",
				"watery",
				"silent",
				"inquisitive",
				"public",
				"acid",
				"astonishing",
				"cold",
				"quiet",
				"wooden",
				"lewd",
				"bumpy",
				"real",
				"careless",
				"striped",
				"scientific",
				"synonymous",
				"jobless",
				"bright",
				"kaput",
				"encouraging",
				"abject",
				"useless",
				"defective",
				"chivalrous",
				"ill-informed",
				"common",
				"tiresome",
				"insidious",
				"blue-eyed",
				"wry",
				"tough",
				"hungry",
				"gleaming",
				"acidic",
				"chunky",
				"marvelous",
				"friendly",
				"alcoholic",
				"abashed",
				"defeated",
				"relieved",
				"silky",
				"spooky",
				"debonair",
				"gentle",
				"receptive",
				"festive",
				"angry",
				"mundane"
			};
			List<string> names = new List<string>
			{
				"Lourdes",
				"Barney",
				"Juana",
				"Julia",
				"Matt",
				"Jean",
				"Michelle",
				"Rene",
				"Moises",
				"Zelma",
				"Nigel",
				"Mattie",
				"Maximo",
				"Joanna",
				"Edwina",
				"Hong",
				"Cara",
				"Chester",
				"Gerardo",
				"Fannie",
				"Kara",
				"Reed",
				"Hollie",
				"Kip",
				"Lillian",
				"Saundra",
				"Loretta",
				"Antonio",
				"Benita",
				"Jerome",
				"Enrique",
				"Nicky",
				"Bradley",
				"Gay",
				"Cameron",
				"Norma",
				"Wilmer",
				"Alison",
				"Armando",
				"Rhoda",
				"Maryanne",
				"Lillie",
				"Lydia",
				"Joesph",
				"Clare",
				"Ramiro",
				"Alex",
				"Daphne",
				"Shelton",
				"David",
				"Robt",
				"Colin",
				"Freddy",
				"Adele",
				"Lara",
				"Jerri",
				"Brock",
				"Rickie",
				"Ezra",
				"Fritz",
				"Walker",
				"Alberto",
				"Alden",
				"Amanda",
				"Normand",
				"Nicholas",
				"Harold",
				"Helene",
				"Lola",
				"Shana",
				"Jesse",
				"Rosanna",
				"Leif",
				"Cornell",
				"Ava",
				"Elvin",
				"Raymond",
				"Hunter",
				"Roberta",
				"Pete",
				"Barry",
				"Fran",
				"Patsy",
				"Selma",
				"Dorthy",
				"Wayne",
				"Caroline",
				"Lavern",
				"Myrna",
				"Morris",
				"Mariano",
				"Leonardo",
				"Reva",
				"Deanne",
				"Wiley",
				"Lionel",
				"Howard",
				"Karin",
				"Miranda",
				"Alvin",
			};

			return CreateDescriptionFromPieces(numberOfDescriptions, descriptionBases, nouns, adjectives, names);
		}

		private static List<string> CreateDescriptionFromPieces(int numberOfDescriptions, List<string> descriptionBases, List<string> nouns, List<string> adjectives, List<string> names)
		{
			List<string> createdDescriptions = new List<string>();
			string newDescription = "default description";
			for (int i = 0; i < numberOfDescriptions; i++)
			{
				if (descriptionBases.Count > 0 && adjectives.Count > 1 && nouns.Count > 1 && names.Count > 0)
				{
					newDescription = Globals.RNGGetAndRemoveRandomValueFromList(descriptionBases);
					newDescription = newDescription.Replace("[noun]", Globals.RNGGetAndRemoveRandomValueFromList(nouns));
					newDescription = newDescription.Replace("[noun2]", Globals.RNGGetAndRemoveRandomValueFromList(nouns));
					newDescription = newDescription.Replace("[adjective]", Globals.RNGGetAndRemoveRandomValueFromList(adjectives));
					newDescription = newDescription.Replace("[adjective2]", Globals.RNGGetAndRemoveRandomValueFromList(adjectives));
					newDescription = newDescription.Replace("[name]", Globals.RNGGetAndRemoveRandomValueFromList(names));
					createdDescriptions.Add(newDescription);
				}
				else
				{
					Globals.ConsoleError("Error generating new description: not enough descriptions or string replacements in lists.");
				}
			}

			return createdDescriptions;
		}

		private static List<string> CreateNameFromPieces(int numberOfNames, List<string> adjectives, List<string> prefixes, List<string> suffixes)
		{
			List<string> createdNames = new List<string>();
			string newName = "default name";

			for (int i = 0; i < numberOfNames; i++)
			{
				if (prefixes.Count > 0 && suffixes.Count > 0)
				{
					newName = $"{Globals.RNGGetAndRemoveRandomValueFromList(prefixes)}{Globals.RNGGetAndRemoveRandomValueFromList(suffixes)}";
					if (newName.StartsWith("Mc")) newName = $"Mc{newName.Substring(2, 1).ToUpper()}{newName.Substring(3)}";

					if (Globals.RNGGetNextBoolean(10) && adjectives.Count > 0) newName = $"{Globals.RNGGetAndRemoveRandomValueFromList(adjectives)} {newName}";
					createdNames.Add(newName);
				}
				else
				{
					Globals.ConsoleError("Error generating new name: not enough prefixes/suffixes in lists");
				}
			}

			return createdNames;
		}

	}
}
