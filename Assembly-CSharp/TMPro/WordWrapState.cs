using System;
using UnityEngine;

namespace TMPro
{
	// Token: 0x02000653 RID: 1619
	public struct WordWrapState
	{
		// Token: 0x04003203 RID: 12803
		public int previous_WordBreak;

		// Token: 0x04003204 RID: 12804
		public int total_CharacterCount;

		// Token: 0x04003205 RID: 12805
		public int visible_CharacterCount;

		// Token: 0x04003206 RID: 12806
		public int visible_SpriteCount;

		// Token: 0x04003207 RID: 12807
		public int visible_LinkCount;

		// Token: 0x04003208 RID: 12808
		public int firstCharacterIndex;

		// Token: 0x04003209 RID: 12809
		public int firstVisibleCharacterIndex;

		// Token: 0x0400320A RID: 12810
		public int lastCharacterIndex;

		// Token: 0x0400320B RID: 12811
		public int lastVisibleCharIndex;

		// Token: 0x0400320C RID: 12812
		public int lineNumber;

		// Token: 0x0400320D RID: 12813
		public float maxCapHeight;

		// Token: 0x0400320E RID: 12814
		public float maxAscender;

		// Token: 0x0400320F RID: 12815
		public float maxDescender;

		// Token: 0x04003210 RID: 12816
		public float maxLineAscender;

		// Token: 0x04003211 RID: 12817
		public float maxLineDescender;

		// Token: 0x04003212 RID: 12818
		public float previousLineAscender;

		// Token: 0x04003213 RID: 12819
		public float xAdvance;

		// Token: 0x04003214 RID: 12820
		public float preferredWidth;

		// Token: 0x04003215 RID: 12821
		public float preferredHeight;

		// Token: 0x04003216 RID: 12822
		public float previousLineScale;

		// Token: 0x04003217 RID: 12823
		public int wordCount;

		// Token: 0x04003218 RID: 12824
		public FontStyles fontStyle;

		// Token: 0x04003219 RID: 12825
		public float fontScale;

		// Token: 0x0400321A RID: 12826
		public float fontScaleMultiplier;

		// Token: 0x0400321B RID: 12827
		public float currentFontSize;

		// Token: 0x0400321C RID: 12828
		public float baselineOffset;

		// Token: 0x0400321D RID: 12829
		public float lineOffset;

		// Token: 0x0400321E RID: 12830
		public TMP_TextInfo textInfo;

		// Token: 0x0400321F RID: 12831
		public TMP_LineInfo lineInfo;

		// Token: 0x04003220 RID: 12832
		public Color32 vertexColor;

		// Token: 0x04003221 RID: 12833
		public TMP_XmlTagStack<Color32> colorStack;

		// Token: 0x04003222 RID: 12834
		public TMP_XmlTagStack<float> sizeStack;

		// Token: 0x04003223 RID: 12835
		public TMP_XmlTagStack<int> fontWeightStack;

		// Token: 0x04003224 RID: 12836
		public TMP_XmlTagStack<int> styleStack;

		// Token: 0x04003225 RID: 12837
		public TMP_XmlTagStack<int> actionStack;

		// Token: 0x04003226 RID: 12838
		public TMP_XmlTagStack<MaterialReference> materialReferenceStack;

		// Token: 0x04003227 RID: 12839
		public TMP_FontAsset currentFontAsset;

		// Token: 0x04003228 RID: 12840
		public TMP_SpriteAsset currentSpriteAsset;

		// Token: 0x04003229 RID: 12841
		public Material currentMaterial;

		// Token: 0x0400322A RID: 12842
		public int currentMaterialIndex;

		// Token: 0x0400322B RID: 12843
		public Extents meshExtents;

		// Token: 0x0400322C RID: 12844
		public bool tagNoParsing;
	}
}
