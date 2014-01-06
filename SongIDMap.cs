﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrawlManagerLib {
	public static class SongIDMap {
		public class Song {
			public string DefaultName { get; private set; }
			public string Filename { get; private set; }
			public int? InfoPacIndex { get; private set; }
			public ushort ID { get; private set; }

			public Song(string name, string filename, int id, int? infoPacIndex) {
				DefaultName = name;
				Filename = filename;
				InfoPacIndex = infoPacIndex;
				ID = (ushort)id;
			}
		}

		public static IEnumerable<Song> Songs {
			get {
				return from s in arr
					   select s;
			}
		}

		private static Song[] arr = {
			new Song("", "", 0xFFFF, null),
			new Song("Super Smash Bros. Brawl Main Theme", "X01", 0x26F9, 0),
			new Song("Menu 1", "X02", 0x26FA, 111),
			new Song("Menu 2", "X03", 0x26FB, 188),
			new Song("Battlefield", "X04", 0x26FC, 199),
			new Song("Final Destination", "X05", 0x26FD, 221),
			new Song("Classic mode clear [NAMELESS]", "X06", 0x26FE, null),
			new Song("Online Practice Stage", "X07", 0x26FF, 232),
			new Song("Results Display Screen", "X08", 0x2700, 243),
			new Song("Tournament Registration", "X09", 0x2701, 254),
			new Song("Tournament Grid", "X10", 0x2702, 1),
			new Song("Tournament Match End", "X11", 0x2703, 12),
			new Song("Classic: Results Screen", "X13", 0x2705, 23),
			new Song("All-Star Rest Area", "X15", 0x2707, 34),
			new Song("Home-Run Contest", "X16", 0x2708, 45),
			new Song("Cruel Brawl", "X17", 0x2709, 184),
			new Song("Boss Battle", "X18", 0x270A, 56),
			new Song("Trophy Gallery", "X19", 0x270B, 67),
			new Song("Sticker Album / Album / Chronicle", "X20", 0x270C, 78),
			new Song("Coin Launcher", "X21", 0x270D, 89),
			new Song("Classic mode clear - trophy [NAMELESS]", "X22", 0x270E, null),
			new Song("Stage Builder", "X23", 0x270F, 100),
			new Song("Battlefield Ver. 2", "X25", 0x2711, 210),
			new Song("Target Smash!!", "X26", 0x2712, 112),
			new Song("Credits", "X27", 0x2713, 189),
			new Song("Ground Theme (Super Mario Bros.)", "A01", 0x2714, 231),
			new Song("Underground Theme (Super Mario Bros.)", "A02", 0x2715, 235),
			new Song("Underwater Theme (Super Mario Bros.)", "A03", 0x2716, 236),
			new Song("Underground Theme (Super Mario Land)", "A04", 0x2717, 237),
			new Song("Airship Theme (Super Mario Bros. 3)", "A05", 0x2718, 240),
			new Song("Castle / Boss Fortress (Super Mario World / SMB 3)", "A06", 0x2719, 239),
			new Song("Title / Ending (Super Mario World)", "A07", 0x271A, 227),
			new Song("Main Theme (New Super Mario Bros.)", "A08", 0x271B, 228),
			new Song("Luigi's Mansion Theme", "A09", 0x271C, 238),
			new Song("Gritzy Desert", "A10", 0x271D, 234),
			new Song("Delfino Plaza", "A13", 0x2720, 226),
			new Song("Ricco Harbor", "A14", 0x2721, 229),
			new Song("Main Theme (Super Mario 64)", "A15", 0x2722, 230),
			new Song("Ground Theme 2 (Super Mario Bros.)", "A16", 0x2723, 233),
			new Song("Mario Bros.", "A17", 0x2724, 127),
			new Song("Mario Circuit", "A20", 0x2725, 241),
			new Song("Luigi Circuit", "A21", 0x2726, 242),
			new Song("Waluigi Pinball", "A22", 0x2727, 244),
			new Song("Rainbow Road", "A23", 0x2728, 245),
			new Song("Jungle Level Ver.2", "B01", 0x2729, 246),
			new Song("The Map Page / Bonus Level", "B02", 0x272A, 252),
			new Song("Opening (Donkey Kong)", "B03", 0x272B, 255),
			new Song("Donkey Kong", "B04", 0x272C, 253),
			new Song("King K.Rool / Ship Deck 2", "B05", 0x272D, 248),
			new Song("Bramble Blast", "B06", 0x272E, 249),
			new Song("Battle for Storm Hill", "B07", 0x272F, 250),
			new Song("Jungle Level", "B08", 0x2730, 247),
			new Song("25m BGM", "B09", 0x2731, 256),
			new Song("DK Jungle 1 Theme (Barrel Blast)", "B10", 0x2732, 251),
			new Song("Title (The Legend of Zelda)", "C01", 0x2733, 259),
			new Song("Main Theme (The Legend of Zelda)", "C02", 0x2734, 257),
			new Song("Great Temple / Temple", "C03", 0x2735, 3),
			new Song("The Dark World", "C04", 0x2736, 260),
			new Song("Hidden Mountain & Forest", "C05", 0x2737, 261),
			new Song("Tal Tal Heights", "C07", 0x2739, 6),
			new Song("Hyrule Field Theme", "C08", 0x273A, 262),
			new Song("Ocarina of Time Medley", "C09", 0x273B, 258),
			new Song("Song of Storms", "C10", 0x273C, 7),
			new Song("Molgera Battle", "C11", 0x273D, 9),
			new Song("Village of the Blue Maiden", "C12", 0x273E, 10),
			new Song("Gerudo Valley", "C13", 0x273F, 8),
			new Song("Termina Field", "C14", 0x2740, 11),
			new Song("Dragon Roost Island", "C15", 0x2741, 4),
			new Song("The Great Sea", "C16", 0x2742, 5),
			new Song("Main Theme (Twilight Princess)", "C17", 0x2743, 263),
			new Song("The Hidden Village", "C18", 0x2744, 264),
			new Song("Midna's Lament", "C19", 0x2745, 2),
			new Song("Main Theme (Metroid)", "D01", 0x2746, 13),
			new Song("Norfair", "D02", 0x2747, 15),
			new Song("Ending (Metroid)", "D03", 0x2748, 14),
			new Song("Vs. Ridley", "D04", 0x2749, 17),
			new Song("Theme of Samus Aran, Space Warrior", "D05", 0x274A, 16),
			new Song("Sector 1", "D06", 0x274B, 20),
			new Song("Opening / Menu (Metroid Prime)", "D07", 0x274C, 19),
			new Song("Vs. Parasite Queen", "D08", 0x274D, 18),
			new Song("Vs. Meta Ridley", "D09", 0x274E, 21),
			new Song("Multiplayer (Metroid Prime 2)", "D10", 0x274F, 22),
			new Song("Ending (Yoshi's Story)", "E01", 0x2750, 25),
			new Song("Obstacle Course", "E02", 0x2751, 24),
			new Song("Yoshi's Island", "E03", 0x2752, 26),
			new Song("Flower Field", "E05", 0x2754, 27),
			new Song("Wildlands", "E06", 0x2755, 28),
			new Song("The Legendary Air Ride Machine", "F01", 0x2757, 30),
			new Song("King Dedede's Theme", "F02", 0x2758, 33),
			new Song("Boss Theme Medley", "F03", 0x2759, 38),
			new Song("Butter Building", "F04", 0x275A, 32),
			new Song("Gourmet Race", "F05", 0x275B, 31),
			new Song("Meta Knight's Revenge", "F06", 0x275C, 29),
			new Song("Vs. Marx", "F07", 0x275D, 36),
			new Song("02 Battle", "F08", 0x275E, 37),
			new Song("Forest / Nature Area", "F09", 0x275F, 40),
			new Song("Checker Knights", "F10", 0x2760, 39),
			new Song("Frozen Hillside", "F11", 0x2761, 41),
			new Song("Squeak Squad Theme", "F12", 0x2762, 35),
			new Song("Main Theme (Star Fox)", "G01", 0x2763, 44),
			new Song("Corneria", "G02", 0x2764, 43),
			new Song("Main Theme (Star Fox 64)", "G03", 0x2765, 46),
			new Song("Area 6", "G04", 0x2766, 47),
			new Song("Star Wolf", "G05", 0x2767, 49),
			new Song("Space Battleground", "G07", 0x2769, 51),
			new Song("Break Through the Ice", "G08", 0x276A, 52),
			new Song("Star Wolf (Star Fox: Assault)", "G09", 0x276B, 50),
			new Song("Space Armada", "G10", 0x276C, 42),
			new Song("Area 6 Ver. 2", "G11", 0x276D, 48),
			new Song("Pokémon Main Theme", "H01", 0x276E, 53),
			new Song("Pokémon Center", "H02", 0x276F, 55),
			new Song("Road to Viridian City (From Pallet Town / Pewter City)", "H03", 0x2770, 54),
			new Song("Pokémon Gym / Evolution", "H04", 0x2771, 57),
			new Song("Wild Pokémon Battle! (Ruby / Sapphire)", "H05", 0x2772, 58),
			new Song("Victory Road", "H06", 0x2773, 59),
			new Song("Wild Pokémon Battle! (Diamond / Pearl)", "H07", 0x2774, 61),
			new Song("Dialga / Palkia Battle at Spear Pillar!", "H08", 0x2775, 60),
			new Song("Team Galactic Battle!", "H09", 0x2776, 62),
			new Song("Route 209", "H10", 0x2777, 63),
			new Song("Mute City", "I01", 0x2778, 64),
			new Song("White Land", "I02", 0x2779, 66),
			new Song("Fire Field", "I03", 0x277A, 65),
			new Song("Car Select", "I04", 0x277B, 68),
			new Song("Dream Chaser", "I05", 0x277C, 69),
			new Song("Devil's Call in Your Heart", "I06", 0x277D, 70),
			new Song("Climb Up! And Get The Last Chance!", "I07", 0x277E, 71),
			new Song("Brain Cleaner", "I08", 0x277F, 72),
			new Song("Shotgun Kiss", "I09", 0x2780, 73),
			new Song("Planet Colors", "I10", 0x2781, 74),
			new Song("Fire Emblem Theme", "J02", 0x2783, 82),
			new Song("Shadow Dragon Medley", "J03", 0x2784, 87),
			new Song("With Mila's Divine Protection (Celica Map 1)", "J04", 0x2785, 83),
			new Song("Preparing to Advance", "J06", 0x2787, 85),
			new Song("Winning Road - Roy's Hope", "J07", 0x2788, 86),
			new Song("Attack", "J08", 0x2789, 84),
			new Song("Against the Dark Knight", "J09", 0x278A, 90),
			new Song("Crimean Army Sortie", "J10", 0x278B, 91),
			new Song("Power-Hungry Fool", "J11", 0x278C, 92),
			new Song("Victory Is Near", "J12", 0x278D, 93),
			new Song("Ike's Theme", "J13", 0x278E, 88),
			new Song("Snowman", "K01", 0x278F, 81),
			new Song("Humoresque of a Little Dog", "K05", 0x2793, 80),
			new Song("Porky's Theme", "K07", 0x2795, 75),
			new Song("Mother 3 Love Theme", "K08", 0x2796, 77),
			new Song("Unfounded Revenge / Smashing Song of Praise", "K09", 0x2797, 76),
			new Song("You Call This a Utopia?!", "K10", 0x2798, 79),
			new Song("World Map (Pikmin 2)", "L01", 0x2799, 108),
			new Song("Forest of Hope", "L02", 0x279A, 110),
			new Song("Environmental Noises", "L03", 0x279B, 116),
			new Song("Ai no Uta", "L04", 0x279C, 113),
			new Song("Tane no Uta", "L05", 0x279D, 115),
			new Song("Main Theme (Pikmin)", "L06", 0x279E, 107),
			new Song("Stage Clear / Title (Pikmin)", "L07", 0x279F, 109),
			new Song("Ai no Uta (French Version)", "L08", 0x27A0, 114),
			new Song("WarioWare, Inc.", "M01", 0x27A1, 98),
			new Song("WarioWare, Inc. Medley", "M02", 0x27A2, 99),
			new Song("Mona Pizza's Song (Japanese Version)", "M03", 0x27A3, 106),
			new Song("Mona Pizza's Song (English Version)", "M04", 0x27A4, 105),
			new Song("Mike's Song (Japanese Version)", "M05", 0x27A5, 104),
			new Song("Mike's Song (English Version)", "M06", 0x27A6, 103),
			new Song("Ashley's Song (Japanese Version)", "M07", 0x27A7, 102),
			new Song("Ashley's Song (English Version)", "M08", 0x27A8, 101),
			new Song("Title (Animal Crossing)", "N01", 0x27B3, 117),
			new Song("Go K.K. Rider!", "N02", 0x27B4, 118),
			new Song("2:00 a.m.", "N03", 0x27B5, 119),
			new Song("The Roost", "N05", 0x27B7, 121),
			new Song("Town Hall and Tom Nook's Store", "N06", 0x27B8, 120),
			new Song("K.K. Crusin'", "N07", 0x27B9, 177),
			new Song("K.K. Western", "N08", 0x27BA, 179),
			new Song("K.K. Gumbo", "N09", 0x27BB, 180),
			new Song("Rockin' K.K.", "N10", 0x27BC, 181),
			new Song("DJ K.K.", "N11", 0x27BD, 182),
			new Song("K.K. Condor", "N12", 0x27BE, 183),
			new Song("Underworld", "P01", 0x27BF, 94),
			new Song("Title (Kid Icarus)", "P02", 0x27C0, 96),
			new Song("Skyworld", "P03", 0x27C1, 95),
			new Song("Kid Icarus Original Medley", "P04", 0x27C2, 97),
			new Song("Famicom Medley", "Q01", 0x27C3, 129),
			new Song("Gyromite", "Q02", 0x27C4, 128),
			new Song("Chill (Dr. Mario)", "Q04", 0x27C6, 133),
			new Song("Clu Clu Land", "Q05", 0x27C7, 126),
			new Song("Balloon Trip", "Q06", 0x27C8, 124),
			new Song("Ice Climber", "Q07", 0x27C9, 122),
			new Song("Shin Onigashima", "Q08", 0x27CA, 125),
			new Song("Title (3D Hot Rally)", "Q09", 0x27CB, 146),
			new Song("Tetris: Type A", "Q10", 0x27CC, 143),
			new Song("Tetris: Type B", "Q11", 0x27CD, 144),
			new Song("Tunnel Scene (X)", "Q12", 0x27CE, 147),
			new Song("Power-Up Music", "Q13", 0x27CF, 130),
			new Song("Douchuumen (Nazo no Murasamejo)", "Q14", 0x27D0, 131),
			new Song("PictoChat", "R02", 0x27D2, 135),
			new Song("Hanenbow [NAMELESS]", "R03", 0x27D3, null),
			new Song("Flat Zone 2", "R04", 0x27D4, 132),
			new Song("Mario Tennis / Mario Golf", "R05", 0x27D5, 148),
			new Song("Lip's Theme (Panel de Pon)", "R06", 0x27D6, 142),
			new Song("Marionation Gear", "R07", 0x27D7, 149),
			new Song("Title (Big Brain Academy)", "R08", 0x27D8, 150),
			new Song("Golden Forest (1080Snowboarding)", "R09", 0x27D9, 151),
			new Song("Mii Channel", "R10", 0x27DA, 136),
			new Song("Wii Shop Channel", "R11", 0x27DB, 137),
			new Song("Battle Scene / Final Boss (Golden Sun)", "R12", 0x27DC, 152),
			new Song("Shaberu! DS Cooking Navi", "R13", 0x27DD, 138),
			new Song("Excite Truck", "R14", 0x27DE, 153),
			new Song("Brain Age: Train Your Brain in Minutes a Day", "R15", 0x27DF, 139),
			new Song("Opening Theme (Wii Sports)", "R16", 0x27E0, 140),
			new Song("Charge! (Wii Play)", "R17", 0x27E1, 141),
			new Song("Encounter", "S02", 0x27E3, 155),
			new Song("Theme of Tara", "S03", 0x27E4, 157),
			new Song("Yell \"Dead Cell\"", "S04", 0x27E5, 159),
			new Song("Snake Eater (Instrumental)", "S05", 0x27E6, 161),
			new Song("MGS4 Theme of Love Smash Bros. Brawl Version", "S06", 0x27E7, 154),
			new Song("Cavern", "S07", 0x27E8, 160),
			new Song("Battle in the Base", "S08", 0x27E9, 158),
			new Song("Theme of Solid Snake", "S10", 0x27EB, 162),
			new Song("Calling to the Night", "S11", 0x27EC, 163),
			new Song("Credits (Super Smash Bros.)", "T01", 0x27ED, 191),
			new Song("Menu (Super Smash Bros. Melee)", "T02", 0x27EE, 190),
			new Song("Opening (Super Smash Bros. Melee)", "T03", 0x27EF, 192),
			new Song("{FD: Classic Mode Master Hand} [NAMELESS]", "T05", 0x27F1, null),
			new Song("Green Hill Zone", "U01", 0x27F2, 164),
			new Song("Scrap Brain Zone", "U02", 0x27F3, 166),
			new Song("Emerald Hill Zone", "U03", 0x27F4, 168),
			new Song("Angel Island Zone", "U04", 0x27F5, 165),
			new Song("Sonic Boom", "U06", 0x27F7, 169),
			new Song("Super Sonic Racing", "U07", 0x27F8, 170),
			new Song("Open Your Heart", "U08", 0x27F9, 171),
			new Song("Live & Learn", "U09", 0x27FA, 172),
			new Song("Sonic Heroes", "U10", 0x27FB, 173),
			new Song("Right There, Ride On", "U11", 0x27FC, 174),
			new Song("HIS WORLD (Instrumental)", "U12", 0x27FD, 175),
			new Song("Seven Rings In Hand", "U13", 0x27FE, 176),
			new Song("Princess Peach's Castle (Melee)", "W01", 0x27FF, 193),
			new Song("Rainbow Cruise (Melee)", "W02", 0x2800, 194),
			new Song("Jungle Japes (Melee)", "W03", 0x2801, 196),
			new Song("Brinstar Depths (Melee)", "W04", 0x2802, 200),
			new Song("Yoshi's Island (Melee)", "W05", 0x2803, 201),
			new Song("Fountain of Dreams (Melee)", "W06", 0x2804, 202),
			new Song("Green Greens (Melee)", "W07", 0x2805, 203),
			new Song("Corneria (Melee)", "W08", 0x2806, 204),
			new Song("Pokémon Stadium (Melee)", "W09", 0x2807, 206),
			new Song("Poké Floats (Melee)", "W10", 0x2808, 207),
			new Song("Big Blue (Melee)", "W11", 0x2809, 209),
			new Song("Mother (Melee)", "W12", 0x280A, 211),
			new Song("Icicle Mountain (Melee)", "W13", 0x280B, 212),
			new Song("Flat Zone (Melee)", "W14", 0x280C, 213),
			new Song("Super Mario Bros. 3 (Melee)", "W15", 0x280D, 214),
			new Song("Battle Theme (Melee)", "W16", 0x280E, 215),
			new Song("Fire Emblem (Melee)", "W17", 0x280F, 216),
			new Song("Mach Rider (Melee)", "W18", 0x2810, 217),
			new Song("Mother 2 (Melee)", "W19", 0x2811, 218),
			new Song("Dr. Mario (Melee)", "W20", 0x2812, 219),
			new Song("Battlefield (Melee)", "W21", 0x2813, 220),
			new Song("Multi-Man Melee 1 (Melee)", "W23", 0x2815, 223),
			new Song("Temple (Melee)", "W24", 0x2816, 197),
			new Song("Final Destination (Melee)", "W25", 0x2817, 224),
			new Song("Kong Jungle (Melee)", "W26", 0x2818, 195),
			new Song("Brinstar (Melee)", "W27", 0x2819, 198),
			new Song("Venom (Melee)", "W28", 0x281A, 205),
			new Song("Mute City (Melee)", "W29", 0x281B, 208),
			new Song("Menu (Melee)", "W30", 0x281C, 222),
			new Song("Giga Bowser (Melee)", "W31", 0x281D, 225),
			new Song("Adventure Map", "Y01", 0x281F, 123),
			new Song("Step: The Plain", "Y02", 0x2820, 134),
			new Song("Step: The Cave", "Y03", 0x2821, 145),
			new Song("Step: Subspace", "Y04", 0x2822, 156),
			new Song("Boss Battle Song 1", "Y05", 0x2823, 185),
			new Song("{SSE Results} [NAMELESS]", "???", 0x2824, null),
			new Song("Boss Battle Song 2", "Y07", 0x2825, 186),
			new Song("Save Point", "Y08", 0x2826, 187),
			new Song("{SSE DK Jungle} [NAMELESS]", "Y09", 0x2827, null),
			new Song("{SSE Luigi Mansion} [NAMELESS]", "Y10", 0x2828, null),
			new Song("{Halberd Interior} [NAMELESS]", "Y11", 0x2829, null),
			new Song("{SSE Data Select} [NAMELESS]", "Y12", 0x282A, null),
			new Song("{SSE Brinstar} [NAMELESS]", "Y13", 0x282B, null),
			new Song("Step: Subspace Ver.2", "Y14", 0x282C, 167),
			new Song("Step: Subspace Ver.3", "Y15", 0x282D, 178),
			new Song("{Halberd Moving} [NAMELESS]", "Y16", 0x282E, null),
			new Song("???", "Y17", 0x282F, null),
			new Song("???", "Z50", 0x2863, null),
			new Song("???", "Z51", 0x2864, null),
			new Song("???", "Z54", 0x2867, null),
			new Song("???", "Z55", 0x2868, null),
			new Song("???", "Z56", 0x2869, null),
			new Song("???", "Z57", 0x286A, null),
			new Song("???", "Z58", 0x286B, null),
		};
	}
}
