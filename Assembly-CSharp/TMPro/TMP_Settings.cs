using System;
using System.Collections.Generic;
using UnityEngine;

namespace TMPro
{
	// Token: 0x0200061C RID: 1564
	[ExecuteInEditMode]
	[Serializable]
	public class TMP_Settings : ScriptableObject
	{
		// Token: 0x1700047E RID: 1150
		// (get) Token: 0x06002BCB RID: 11211 RVA: 0x0001F47A File Offset: 0x0001D67A
		public static bool enableWordWrapping
		{
			get
			{
				return TMP_Settings.instance.m_enableWordWrapping;
			}
		}

		// Token: 0x1700047F RID: 1151
		// (get) Token: 0x06002BCC RID: 11212 RVA: 0x0001F486 File Offset: 0x0001D686
		public static bool enableKerning
		{
			get
			{
				return TMP_Settings.instance.m_enableKerning;
			}
		}

		// Token: 0x17000480 RID: 1152
		// (get) Token: 0x06002BCD RID: 11213 RVA: 0x0001F492 File Offset: 0x0001D692
		public static bool enableExtraPadding
		{
			get
			{
				return TMP_Settings.instance.m_enableExtraPadding;
			}
		}

		// Token: 0x17000481 RID: 1153
		// (get) Token: 0x06002BCE RID: 11214 RVA: 0x0001F49E File Offset: 0x0001D69E
		public static bool enableTintAllSprites
		{
			get
			{
				return TMP_Settings.instance.m_enableTintAllSprites;
			}
		}

		// Token: 0x17000482 RID: 1154
		// (get) Token: 0x06002BCF RID: 11215 RVA: 0x0001F4AA File Offset: 0x0001D6AA
		public static bool enableParseEscapeCharacters
		{
			get
			{
				return TMP_Settings.instance.m_enableParseEscapeCharacters;
			}
		}

		// Token: 0x17000483 RID: 1155
		// (get) Token: 0x06002BD0 RID: 11216 RVA: 0x0001F4B6 File Offset: 0x0001D6B6
		public static int missingGlyphCharacter
		{
			get
			{
				return TMP_Settings.instance.m_missingGlyphCharacter;
			}
		}

		// Token: 0x17000484 RID: 1156
		// (get) Token: 0x06002BD1 RID: 11217 RVA: 0x0001F4C2 File Offset: 0x0001D6C2
		public static bool warningsDisabled
		{
			get
			{
				return TMP_Settings.instance.m_warningsDisabled;
			}
		}

		// Token: 0x17000485 RID: 1157
		// (get) Token: 0x06002BD2 RID: 11218 RVA: 0x0001F4CE File Offset: 0x0001D6CE
		public static TMP_FontAsset defaultFontAsset
		{
			get
			{
				return TMP_Settings.instance.m_defaultFontAsset;
			}
		}

		// Token: 0x17000486 RID: 1158
		// (get) Token: 0x06002BD3 RID: 11219 RVA: 0x0001F4DA File Offset: 0x0001D6DA
		public static string defaultFontAssetPath
		{
			get
			{
				return TMP_Settings.instance.m_defaultFontAssetPath;
			}
		}

		// Token: 0x17000487 RID: 1159
		// (get) Token: 0x06002BD4 RID: 11220 RVA: 0x0001F4E6 File Offset: 0x0001D6E6
		public static float defaultFontSize
		{
			get
			{
				return TMP_Settings.instance.m_defaultFontSize;
			}
		}

		// Token: 0x17000488 RID: 1160
		// (get) Token: 0x06002BD5 RID: 11221 RVA: 0x0001F4F2 File Offset: 0x0001D6F2
		public static float defaultTextContainerWidth
		{
			get
			{
				return TMP_Settings.instance.m_defaultTextContainerWidth;
			}
		}

		// Token: 0x17000489 RID: 1161
		// (get) Token: 0x06002BD6 RID: 11222 RVA: 0x0001F4FE File Offset: 0x0001D6FE
		public static float defaultTextContainerHeight
		{
			get
			{
				return TMP_Settings.instance.m_defaultTextContainerHeight;
			}
		}

		// Token: 0x1700048A RID: 1162
		// (get) Token: 0x06002BD7 RID: 11223 RVA: 0x0001F50A File Offset: 0x0001D70A
		public static List<TMP_FontAsset> fallbackFontAssets
		{
			get
			{
				return TMP_Settings.instance.m_fallbackFontAssets;
			}
		}

		// Token: 0x1700048B RID: 1163
		// (get) Token: 0x06002BD8 RID: 11224 RVA: 0x0001F516 File Offset: 0x0001D716
		public static bool matchMaterialPreset
		{
			get
			{
				return TMP_Settings.instance.m_matchMaterialPreset;
			}
		}

		// Token: 0x1700048C RID: 1164
		// (get) Token: 0x06002BD9 RID: 11225 RVA: 0x0001F522 File Offset: 0x0001D722
		public static TMP_SpriteAsset defaultSpriteAsset
		{
			get
			{
				return TMP_Settings.instance.m_defaultSpriteAsset;
			}
		}

		// Token: 0x1700048D RID: 1165
		// (get) Token: 0x06002BDA RID: 11226 RVA: 0x0001F52E File Offset: 0x0001D72E
		public static string defaultSpriteAssetPath
		{
			get
			{
				return TMP_Settings.instance.m_defaultSpriteAssetPath;
			}
		}

		// Token: 0x1700048E RID: 1166
		// (get) Token: 0x06002BDB RID: 11227 RVA: 0x0001F53A File Offset: 0x0001D73A
		public static TMP_StyleSheet defaultStyleSheet
		{
			get
			{
				return TMP_Settings.instance.m_defaultStyleSheet;
			}
		}

		// Token: 0x1700048F RID: 1167
		// (get) Token: 0x06002BDC RID: 11228 RVA: 0x0001F546 File Offset: 0x0001D746
		public static TextAsset leadingCharacters
		{
			get
			{
				return TMP_Settings.instance.m_leadingCharacters;
			}
		}

		// Token: 0x17000490 RID: 1168
		// (get) Token: 0x06002BDD RID: 11229 RVA: 0x0001F552 File Offset: 0x0001D752
		public static TextAsset followingCharacters
		{
			get
			{
				return TMP_Settings.instance.m_followingCharacters;
			}
		}

		// Token: 0x17000491 RID: 1169
		// (get) Token: 0x06002BDE RID: 11230 RVA: 0x0001F55E File Offset: 0x0001D75E
		public static TMP_Settings.LineBreakingTable linebreakingRules
		{
			get
			{
				if (TMP_Settings.instance.m_linebreakingRules == null)
				{
					TMP_Settings.LoadLinebreakingRules();
				}
				return TMP_Settings.instance.m_linebreakingRules;
			}
		}

		// Token: 0x17000492 RID: 1170
		// (get) Token: 0x06002BDF RID: 11231 RVA: 0x0001F57E File Offset: 0x0001D77E
		public static TMP_Settings instance
		{
			get
			{
				if (TMP_Settings.s_Instance == null)
				{
					TMP_Settings.s_Instance = Resources.Load("TMP Settings") as TMP_Settings;
				}
				return TMP_Settings.s_Instance;
			}
		}

		// Token: 0x06002BE0 RID: 11232 RVA: 0x00106C80 File Offset: 0x00104E80
		public static TMP_Settings LoadDefaultSettings()
		{
			if (TMP_Settings.s_Instance == null)
			{
				TMP_Settings tmp_Settings = Resources.Load("TMP Settings") as TMP_Settings;
				if (tmp_Settings != null)
				{
					TMP_Settings.s_Instance = tmp_Settings;
				}
			}
			return TMP_Settings.s_Instance;
		}

		// Token: 0x06002BE1 RID: 11233 RVA: 0x0001F5A9 File Offset: 0x0001D7A9
		public static TMP_Settings GetSettings()
		{
			if (TMP_Settings.instance == null)
			{
				return null;
			}
			return TMP_Settings.instance;
		}

		// Token: 0x06002BE2 RID: 11234 RVA: 0x0001F5C2 File Offset: 0x0001D7C2
		public static TMP_FontAsset GetFontAsset()
		{
			if (TMP_Settings.instance == null)
			{
				return null;
			}
			return TMP_Settings.instance.m_defaultFontAsset;
		}

		// Token: 0x06002BE3 RID: 11235 RVA: 0x0001F5E0 File Offset: 0x0001D7E0
		public static TMP_SpriteAsset GetSpriteAsset()
		{
			if (TMP_Settings.instance == null)
			{
				return null;
			}
			return TMP_Settings.instance.m_defaultSpriteAsset;
		}

		// Token: 0x06002BE4 RID: 11236 RVA: 0x0001F5FE File Offset: 0x0001D7FE
		public static TMP_StyleSheet GetStyleSheet()
		{
			if (TMP_Settings.instance == null)
			{
				return null;
			}
			return TMP_Settings.instance.m_defaultStyleSheet;
		}

		// Token: 0x06002BE5 RID: 11237 RVA: 0x00106CC4 File Offset: 0x00104EC4
		public static void LoadLinebreakingRules()
		{
			if (TMP_Settings.instance == null)
			{
				return;
			}
			if (TMP_Settings.s_Instance.m_linebreakingRules == null)
			{
				TMP_Settings.s_Instance.m_linebreakingRules = new TMP_Settings.LineBreakingTable();
			}
			TMP_Settings.s_Instance.m_linebreakingRules.leadingCharacters = TMP_Settings.GetCharacters(TMP_Settings.s_Instance.m_leadingCharacters);
			TMP_Settings.s_Instance.m_linebreakingRules.followingCharacters = TMP_Settings.GetCharacters(TMP_Settings.s_Instance.m_followingCharacters);
		}

		// Token: 0x06002BE6 RID: 11238 RVA: 0x00106D3C File Offset: 0x00104F3C
		private static Dictionary<int, char> GetCharacters(TextAsset file)
		{
			Dictionary<int, char> dictionary = new Dictionary<int, char>();
			foreach (char c in file.text)
			{
				if (!dictionary.ContainsKey((int)c))
				{
					dictionary.Add((int)c, c);
				}
			}
			return dictionary;
		}

		// Token: 0x04002FF6 RID: 12278
		private static TMP_Settings s_Instance;

		// Token: 0x04002FF7 RID: 12279
		[SerializeField]
		private bool m_enableWordWrapping;

		// Token: 0x04002FF8 RID: 12280
		[SerializeField]
		private bool m_enableKerning;

		// Token: 0x04002FF9 RID: 12281
		[SerializeField]
		private bool m_enableExtraPadding;

		// Token: 0x04002FFA RID: 12282
		[SerializeField]
		private bool m_enableTintAllSprites;

		// Token: 0x04002FFB RID: 12283
		[SerializeField]
		private bool m_enableParseEscapeCharacters;

		// Token: 0x04002FFC RID: 12284
		[SerializeField]
		private int m_missingGlyphCharacter;

		// Token: 0x04002FFD RID: 12285
		[SerializeField]
		private bool m_warningsDisabled;

		// Token: 0x04002FFE RID: 12286
		[SerializeField]
		private TMP_FontAsset m_defaultFontAsset;

		// Token: 0x04002FFF RID: 12287
		[SerializeField]
		private string m_defaultFontAssetPath;

		// Token: 0x04003000 RID: 12288
		[SerializeField]
		private float m_defaultFontSize;

		// Token: 0x04003001 RID: 12289
		[SerializeField]
		private float m_defaultTextContainerWidth;

		// Token: 0x04003002 RID: 12290
		[SerializeField]
		private float m_defaultTextContainerHeight;

		// Token: 0x04003003 RID: 12291
		[SerializeField]
		private List<TMP_FontAsset> m_fallbackFontAssets;

		// Token: 0x04003004 RID: 12292
		[SerializeField]
		private bool m_matchMaterialPreset;

		// Token: 0x04003005 RID: 12293
		[SerializeField]
		private TMP_SpriteAsset m_defaultSpriteAsset;

		// Token: 0x04003006 RID: 12294
		[SerializeField]
		private string m_defaultSpriteAssetPath;

		// Token: 0x04003007 RID: 12295
		[SerializeField]
		private TMP_StyleSheet m_defaultStyleSheet;

		// Token: 0x04003008 RID: 12296
		[SerializeField]
		private TextAsset m_leadingCharacters;

		// Token: 0x04003009 RID: 12297
		[SerializeField]
		private TextAsset m_followingCharacters;

		// Token: 0x0400300A RID: 12298
		[SerializeField]
		private TMP_Settings.LineBreakingTable m_linebreakingRules;

		// Token: 0x0200061D RID: 1565
		public class LineBreakingTable
		{
			// Token: 0x0400300B RID: 12299
			public Dictionary<int, char> leadingCharacters;

			// Token: 0x0400300C RID: 12300
			public Dictionary<int, char> followingCharacters;
		}
	}
}
