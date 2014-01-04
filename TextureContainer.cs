using BrawlLib.SSBB.ResourceNodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrawlManagerLib {
	public class TextureContainer : IEnumerable<TEX0Node> {
		public TEX0Node prevbase_tex0;
		public TEX0Node icon_tex0;
		public TEX0Node frontstname_tex0;
		public TEX0Node seriesicon_tex0;
		public TEX0Node selmap_mark_tex0;

		public PAT0TextureEntryNode prevbase_pat0;
		public PAT0TextureEntryNode icon_pat0;
		public PAT0TextureEntryNode frontstname_pat0;
		public PAT0TextureEntryNode seriesicon_pat0;
		public PAT0TextureEntryNode selmap_mark_pat0;

		public ResourceNode TEX0Folder {get; private set;}
		private ResourceNode PAT0Folder;
		private int iconNum;

		public IEnumerator<TEX0Node> GetEnumerator() {
			return new List<TEX0Node> { prevbase_tex0, icon_tex0, frontstname_tex0, seriesicon_tex0, selmap_mark_tex0 }.GetEnumerator();
		}
		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
			return GetEnumerator();
		}

		public TextureContainer() {}

		/// <summary>
		/// Finds the textures through their PAT0 entries, given an icon number and a ResourceNode
		/// </summary>
		/// <param name="sc_selmap">The sc_selmap *or* MiscData[80] node.</param>
		/// <param name="iconNum">The icon index (also used in the third part of the Custom SSS code.)</param>
		public TextureContainer(ResourceNode node, int iconNum) {
			TEX0Folder = node.FindChild("MiscData[80]/Textures(NW4R)", false)
					  ?? node.FindChild("Textures(NW4R)", false);
			PAT0Folder = node.FindChild("MiscData[80]/AnmTexPat(NW4R)", false)
					  ?? node.FindChild("AnmTexPat(NW4R)", false);
			this.iconNum = iconNum;

			populate(out prevbase_tex0, out prevbase_pat0, "MenSelmapPreview/basebgM");
			populate(out icon_tex0, out icon_pat0, "MenSelmapIcon/iconM");
			populate(out frontstname_tex0, out frontstname_pat0, "MenSelmapPreview/pasted__stnameM"); // the name shadow has a separate pat0 list
			populate(out seriesicon_tex0, out seriesicon_pat0, "MenSelmapPreview/lambert113");
			populate(out selmap_mark_tex0, out selmap_mark_pat0, "MenSelmapPreview/pasted__stnamelogoM");
		}

		private void populate(out TEX0Node tex0node, out PAT0TextureEntryNode pat0node, string path) {
			var query = (from n in PAT0Folder.FindChild(path, false).Children[0].Children
						 where n is PAT0TextureEntryNode
						 && ((PAT0TextureEntryNode)n).FrameIndex == iconNum
						 select ((PAT0TextureEntryNode)n));
			if (!query.Any()) {
				pat0node = null;
				tex0node = null;
			} else {
				pat0node = query.First();
				tex0node = TEX0Folder.FindChild(pat0node.Name, false) as TEX0Node;
			}
		}
	}
}
