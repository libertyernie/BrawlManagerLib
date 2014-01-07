﻿using BrawlManagerLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace BrawlManagerLib {
	public static class SDSLScanner {
		private static byte[] SDSL_HEADER = { 0x28, 0x70, 0x8c, 0xeb, 0x00, 0x00, 0x00 };
		public static Dictionary<byte, Tuple<string, ushort>> SongsByStage(CustomSSS sss) {
			return SongsByStage(sss.DataBefore.Concat(sss.DataAfter).ToArray());
		}
		public static Dictionary<byte, Tuple<string, ushort>> SongsByStage(byte[] data) {
			Dictionary<byte, Tuple<string, ushort>> dict = new Dictionary<byte, Tuple<string, ushort>>();
			for (int line = 0; line < data.Length; line += 8) {
				if (ByteUtilities.ByteArrayEquals(data, line, SDSL_HEADER, 0, SDSL_HEADER.Length)) {
					byte stageID = data[line + 7];
					byte songID1 = data[line + 22];
					byte songID2 = data[line + 23];
					ushort songID = (ushort)(0x100 * songID1 + songID2);
					string n = (from s in SongIDMap.Songs
								where s.ID == songID
								select s.Filename).First();
					if (dict.ContainsKey(stageID)) {
						Console.WriteLine(String.Format("WARNING: code mapping stage {0} to song {1} will not " +
							"take effect, since a later code maps it to song {2}", stageID, dict[stageID], n));
						dict.Remove(stageID);
					}
					dict.Add(stageID, new Tuple<string, ushort>(n, songID));
					line += 24;
				}
			}
			return dict;
		}
	}
}
