using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TMPro
{
	// Token: 0x02000602 RID: 1538
	[Serializable]
	public class TMP_FontAsset : TMP_Asset
	{
		// Token: 0x1700044D RID: 1101
		// (get) Token: 0x06002ADE RID: 10974 RVA: 0x0001EA5C File Offset: 0x0001CC5C
		public static TMP_FontAsset defaultFontAsset
		{
			get
			{
				if (TMP_FontAsset.s_defaultFontAsset == null)
				{
					TMP_FontAsset.s_defaultFontAsset = Resources.Load<TMP_FontAsset>("Fonts & Materials/ARIAL SDF");
				}
				return TMP_FontAsset.s_defaultFontAsset;
			}
		}

		// Token: 0x1700044E RID: 1102
		// (get) Token: 0x06002ADF RID: 10975 RVA: 0x0001EA82 File Offset: 0x0001CC82
		public FaceInfo fontInfo
		{
			get
			{
				return this.m_fontInfo;
			}
		}

		// Token: 0x1700044F RID: 1103
		// (get) Token: 0x06002AE0 RID: 10976 RVA: 0x0001EA8A File Offset: 0x0001CC8A
		public Dictionary<int, TMP_Glyph> characterDictionary
		{
			get
			{
				if (this.m_characterDictionary == null)
				{
					this.ReadFontDefinition();
				}
				return this.m_characterDictionary;
			}
		}

		// Token: 0x17000450 RID: 1104
		// (get) Token: 0x06002AE1 RID: 10977 RVA: 0x0001EAA3 File Offset: 0x0001CCA3
		public Dictionary<int, KerningPair> kerningDictionary
		{
			get
			{
				return this.m_kerningDictionary;
			}
		}

		// Token: 0x17000451 RID: 1105
		// (get) Token: 0x06002AE2 RID: 10978 RVA: 0x0001EAAB File Offset: 0x0001CCAB
		public KerningTable kerningInfo
		{
			get
			{
				return this.m_kerningInfo;
			}
		}

		// Token: 0x06002AE3 RID: 10979 RVA: 0x00002482 File Offset: 0x00000682
		private void OnEnable()
		{
		}

		// Token: 0x06002AE4 RID: 10980 RVA: 0x00002482 File Offset: 0x00000682
		private void OnDisable()
		{
		}

		// Token: 0x06002AE5 RID: 10981 RVA: 0x0001EAB3 File Offset: 0x0001CCB3
		public void AddFaceInfo(FaceInfo faceInfo)
		{
			this.m_fontInfo = faceInfo;
		}

		// Token: 0x06002AE6 RID: 10982 RVA: 0x00101384 File Offset: 0x000FF584
		public void AddGlyphInfo(TMP_Glyph[] glyphInfo)
		{
			this.m_glyphInfoList = new List<TMP_Glyph>();
			int num = glyphInfo.Length;
			this.m_fontInfo.CharacterCount = num;
			this.m_characterSet = new int[num];
			for (int i = 0; i < num; i++)
			{
				TMP_Glyph tmp_Glyph = new TMP_Glyph();
				tmp_Glyph.id = glyphInfo[i].id;
				tmp_Glyph.x = glyphInfo[i].x;
				tmp_Glyph.y = glyphInfo[i].y;
				tmp_Glyph.width = glyphInfo[i].width;
				tmp_Glyph.height = glyphInfo[i].height;
				tmp_Glyph.xOffset = glyphInfo[i].xOffset;
				tmp_Glyph.yOffset = glyphInfo[i].yOffset;
				tmp_Glyph.xAdvance = glyphInfo[i].xAdvance;
				tmp_Glyph.scale = 1f;
				this.m_glyphInfoList.Add(tmp_Glyph);
				this.m_characterSet[i] = tmp_Glyph.id;
			}
			this.m_glyphInfoList = this.m_glyphInfoList.OrderBy<TMP_Glyph, int>((TMP_Glyph s) => s.id).ToList<TMP_Glyph>();
		}

		// Token: 0x06002AE7 RID: 10983 RVA: 0x0001EABC File Offset: 0x0001CCBC
		public void AddKerningInfo(KerningTable kerningTable)
		{
			this.m_kerningInfo = kerningTable;
		}

		// Token: 0x06002AE8 RID: 10984 RVA: 0x00101498 File Offset: 0x000FF698
		public void ReadFontDefinition()
		{
			if (this.m_fontInfo == null)
			{
				return;
			}
			this.m_characterDictionary = new Dictionary<int, TMP_Glyph>();
			for (int i = 0; i < this.m_glyphInfoList.Count; i++)
			{
				TMP_Glyph tmp_Glyph = this.m_glyphInfoList[i];
				if (!this.m_characterDictionary.ContainsKey(tmp_Glyph.id))
				{
					this.m_characterDictionary.Add(tmp_Glyph.id, tmp_Glyph);
				}
				if (tmp_Glyph.scale == 0f)
				{
					tmp_Glyph.scale = 1f;
				}
			}
			TMP_Glyph tmp_Glyph2 = new TMP_Glyph();
			if (this.m_characterDictionary.ContainsKey(32))
			{
				this.m_characterDictionary[32].width = this.m_characterDictionary[32].xAdvance;
				this.m_characterDictionary[32].height = this.m_fontInfo.Ascender - this.m_fontInfo.Descender;
				this.m_characterDictionary[32].yOffset = this.m_fontInfo.Ascender;
				this.m_characterDictionary[32].scale = 1f;
			}
			else
			{
				tmp_Glyph2 = new TMP_Glyph();
				tmp_Glyph2.id = 32;
				tmp_Glyph2.x = 0f;
				tmp_Glyph2.y = 0f;
				tmp_Glyph2.width = this.m_fontInfo.Ascender / 5f;
				tmp_Glyph2.height = this.m_fontInfo.Ascender - this.m_fontInfo.Descender;
				tmp_Glyph2.xOffset = 0f;
				tmp_Glyph2.yOffset = this.m_fontInfo.Ascender;
				tmp_Glyph2.xAdvance = this.m_fontInfo.PointSize / 4f;
				tmp_Glyph2.scale = 1f;
				this.m_characterDictionary.Add(32, tmp_Glyph2);
			}
			if (!this.m_characterDictionary.ContainsKey(160))
			{
				tmp_Glyph2 = TMP_Glyph.Clone(this.m_characterDictionary[32]);
				this.m_characterDictionary.Add(160, tmp_Glyph2);
			}
			if (!this.m_characterDictionary.ContainsKey(8203))
			{
				tmp_Glyph2 = TMP_Glyph.Clone(this.m_characterDictionary[32]);
				tmp_Glyph2.width = 0f;
				tmp_Glyph2.xAdvance = 0f;
				this.m_characterDictionary.Add(8203, tmp_Glyph2);
			}
			if (!this.m_characterDictionary.ContainsKey(8288))
			{
				tmp_Glyph2 = TMP_Glyph.Clone(this.m_characterDictionary[32]);
				tmp_Glyph2.width = 0f;
				tmp_Glyph2.xAdvance = 0f;
				this.m_characterDictionary.Add(8288, tmp_Glyph2);
			}
			if (!this.m_characterDictionary.ContainsKey(10))
			{
				tmp_Glyph2 = new TMP_Glyph();
				tmp_Glyph2.id = 10;
				tmp_Glyph2.x = 0f;
				tmp_Glyph2.y = 0f;
				tmp_Glyph2.width = 10f;
				tmp_Glyph2.height = this.m_characterDictionary[32].height;
				tmp_Glyph2.xOffset = 0f;
				tmp_Glyph2.yOffset = this.m_characterDictionary[32].yOffset;
				tmp_Glyph2.xAdvance = 0f;
				tmp_Glyph2.scale = 1f;
				this.m_characterDictionary.Add(10, tmp_Glyph2);
				if (!this.m_characterDictionary.ContainsKey(13))
				{
					this.m_characterDictionary.Add(13, tmp_Glyph2);
				}
			}
			if (!this.m_characterDictionary.ContainsKey(9))
			{
				tmp_Glyph2 = new TMP_Glyph();
				tmp_Glyph2.id = 9;
				tmp_Glyph2.x = this.m_characterDictionary[32].x;
				tmp_Glyph2.y = this.m_characterDictionary[32].y;
				tmp_Glyph2.width = this.m_characterDictionary[32].width * (float)this.tabSize + (this.m_characterDictionary[32].xAdvance - this.m_characterDictionary[32].width) * (float)(this.tabSize - 1);
				tmp_Glyph2.height = this.m_characterDictionary[32].height;
				tmp_Glyph2.xOffset = this.m_characterDictionary[32].xOffset;
				tmp_Glyph2.yOffset = this.m_characterDictionary[32].yOffset;
				tmp_Glyph2.xAdvance = this.m_characterDictionary[32].xAdvance * (float)this.tabSize;
				tmp_Glyph2.scale = 1f;
				this.m_characterDictionary.Add(9, tmp_Glyph2);
			}
			this.m_fontInfo.TabWidth = this.m_characterDictionary[9].xAdvance;
			if (this.m_fontInfo.CapHeight == 0f && this.m_characterDictionary.ContainsKey(65))
			{
				this.m_fontInfo.CapHeight = this.m_characterDictionary[65].yOffset;
			}
			if (this.m_fontInfo.Scale == 0f)
			{
				this.m_fontInfo.Scale = 1f;
			}
			this.m_kerningDictionary = new Dictionary<int, KerningPair>();
			List<KerningPair> kerningPairs = this.m_kerningInfo.kerningPairs;
			for (int j = 0; j < kerningPairs.Count; j++)
			{
				KerningPair kerningPair = kerningPairs[j];
				KerningPairKey kerningPairKey = new KerningPairKey(kerningPair.AscII_Left, kerningPair.AscII_Right);
				if (!this.m_kerningDictionary.ContainsKey(kerningPairKey.key))
				{
					this.m_kerningDictionary.Add(kerningPairKey.key, kerningPair);
				}
				else if (!TMP_Settings.warningsDisabled)
				{
					Debug.LogWarning(string.Concat(new object[] { "Kerning Key for [", kerningPairKey.ascii_Left, "] and [", kerningPairKey.ascii_Right, "] already exists." }));
				}
			}
			this.hashCode = TMP_TextUtilities.GetSimpleHashCode(base.name);
			this.materialHashCode = TMP_TextUtilities.GetSimpleHashCode(this.material.name);
		}

		// Token: 0x06002AE9 RID: 10985 RVA: 0x0001EAC5 File Offset: 0x0001CCC5
		public bool HasCharacter(int character)
		{
			return this.m_characterDictionary != null && this.m_characterDictionary.ContainsKey(character);
		}

		// Token: 0x06002AEA RID: 10986 RVA: 0x0001EAC5 File Offset: 0x0001CCC5
		public bool HasCharacter(char character)
		{
			return this.m_characterDictionary != null && this.m_characterDictionary.ContainsKey((int)character);
		}

		// Token: 0x06002AEB RID: 10987 RVA: 0x00101AA0 File Offset: 0x000FFCA0
		public bool HasCharacter(char character, bool searchFallbacks)
		{
			if (this.m_characterDictionary == null)
			{
				return false;
			}
			if (this.m_characterDictionary.ContainsKey((int)character))
			{
				return true;
			}
			if (searchFallbacks)
			{
				if (this.fallbackFontAssets != null && this.fallbackFontAssets.Count > 0)
				{
					for (int i = 0; i < this.fallbackFontAssets.Count; i++)
					{
						if (this.fallbackFontAssets[i].characterDictionary != null && this.fallbackFontAssets[i].characterDictionary.ContainsKey((int)character))
						{
							return true;
						}
					}
				}
				if (TMP_Settings.fallbackFontAssets != null && TMP_Settings.fallbackFontAssets.Count > 0)
				{
					for (int j = 0; j < TMP_Settings.fallbackFontAssets.Count; j++)
					{
						if (TMP_Settings.fallbackFontAssets[j].characterDictionary != null && TMP_Settings.fallbackFontAssets[j].characterDictionary.ContainsKey((int)character))
						{
							return true;
						}
					}
				}
			}
			return false;
		}

		// Token: 0x06002AEC RID: 10988 RVA: 0x00101BA8 File Offset: 0x000FFDA8
		public bool HasCharacters(string text, out List<char> missingCharacters)
		{
			if (this.m_characterDictionary == null)
			{
				missingCharacters = null;
				return false;
			}
			missingCharacters = new List<char>();
			for (int i = 0; i < text.Length; i++)
			{
				if (!this.m_characterDictionary.ContainsKey((int)text[i]))
				{
					missingCharacters.Add(text[i]);
				}
			}
			return missingCharacters.Count == 0;
		}

		// Token: 0x06002AED RID: 10989 RVA: 0x00101C18 File Offset: 0x000FFE18
		public static string GetCharacters(TMP_FontAsset fontAsset)
		{
			string text = string.Empty;
			for (int i = 0; i < fontAsset.m_glyphInfoList.Count; i++)
			{
				text += (char)fontAsset.m_glyphInfoList[i].id;
			}
			return text;
		}

		// Token: 0x06002AEE RID: 10990 RVA: 0x00101C68 File Offset: 0x000FFE68
		public static int[] GetCharactersArray(TMP_FontAsset fontAsset)
		{
			int[] array = new int[fontAsset.m_glyphInfoList.Count];
			for (int i = 0; i < fontAsset.m_glyphInfoList.Count; i++)
			{
				array[i] = fontAsset.m_glyphInfoList[i].id;
			}
			return array;
		}

		// Token: 0x04002F43 RID: 12099
		private static TMP_FontAsset s_defaultFontAsset;

		// Token: 0x04002F44 RID: 12100
		public TMP_FontAsset.FontAssetTypes fontAssetType;

		// Token: 0x04002F45 RID: 12101
		[SerializeField]
		private FaceInfo m_fontInfo;

		// Token: 0x04002F46 RID: 12102
		[SerializeField]
		public Texture2D atlas;

		// Token: 0x04002F47 RID: 12103
		[SerializeField]
		private List<TMP_Glyph> m_glyphInfoList;

		// Token: 0x04002F48 RID: 12104
		private Dictionary<int, TMP_Glyph> m_characterDictionary;

		// Token: 0x04002F49 RID: 12105
		private Dictionary<int, KerningPair> m_kerningDictionary;

		// Token: 0x04002F4A RID: 12106
		[SerializeField]
		private KerningTable m_kerningInfo;

		// Token: 0x04002F4B RID: 12107
		[SerializeField]
		private KerningPair m_kerningPair;

		// Token: 0x04002F4C RID: 12108
		[SerializeField]
		public List<TMP_FontAsset> fallbackFontAssets;

		// Token: 0x04002F4D RID: 12109
		[SerializeField]
		public FontCreationSetting fontCreationSettings;

		// Token: 0x04002F4E RID: 12110
		[SerializeField]
		public TMP_FontWeights[] fontWeights = new TMP_FontWeights[10];

		// Token: 0x04002F4F RID: 12111
		private int[] m_characterSet;

		// Token: 0x04002F50 RID: 12112
		public float normalStyle;

		// Token: 0x04002F51 RID: 12113
		public float normalSpacingOffset;

		// Token: 0x04002F52 RID: 12114
		public float boldStyle = 0.75f;

		// Token: 0x04002F53 RID: 12115
		public float boldSpacing = 7f;

		// Token: 0x04002F54 RID: 12116
		public byte italicStyle = 35;

		// Token: 0x04002F55 RID: 12117
		public byte tabSize = 10;

		// Token: 0x04002F56 RID: 12118
		private byte m_oldTabSize;

		// Token: 0x02000603 RID: 1539
		public enum FontAssetTypes
		{
			// Token: 0x04002F59 RID: 12121
			None,
			// Token: 0x04002F5A RID: 12122
			SDF,
			// Token: 0x04002F5B RID: 12123
			Bitmap
		}
	}
}
