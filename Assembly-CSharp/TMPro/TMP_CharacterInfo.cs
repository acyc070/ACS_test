using System;
using UnityEngine;

namespace TMPro
{
	// Token: 0x0200064A RID: 1610
	public struct TMP_CharacterInfo
	{
		// Token: 0x040031C3 RID: 12739
		public char character;

		// Token: 0x040031C4 RID: 12740
		public short index;

		// Token: 0x040031C5 RID: 12741
		public TMP_TextElementType elementType;

		// Token: 0x040031C6 RID: 12742
		public TMP_TextElement textElement;

		// Token: 0x040031C7 RID: 12743
		public TMP_FontAsset fontAsset;

		// Token: 0x040031C8 RID: 12744
		public TMP_SpriteAsset spriteAsset;

		// Token: 0x040031C9 RID: 12745
		public int spriteIndex;

		// Token: 0x040031CA RID: 12746
		public Material material;

		// Token: 0x040031CB RID: 12747
		public int materialReferenceIndex;

		// Token: 0x040031CC RID: 12748
		public bool isUsingAlternateTypeface;

		// Token: 0x040031CD RID: 12749
		public float pointSize;

		// Token: 0x040031CE RID: 12750
		public short lineNumber;

		// Token: 0x040031CF RID: 12751
		public short pageNumber;

		// Token: 0x040031D0 RID: 12752
		public int vertexIndex;

		// Token: 0x040031D1 RID: 12753
		public TMP_Vertex vertex_TL;

		// Token: 0x040031D2 RID: 12754
		public TMP_Vertex vertex_BL;

		// Token: 0x040031D3 RID: 12755
		public TMP_Vertex vertex_TR;

		// Token: 0x040031D4 RID: 12756
		public TMP_Vertex vertex_BR;

		// Token: 0x040031D5 RID: 12757
		public Vector3 topLeft;

		// Token: 0x040031D6 RID: 12758
		public Vector3 bottomLeft;

		// Token: 0x040031D7 RID: 12759
		public Vector3 topRight;

		// Token: 0x040031D8 RID: 12760
		public Vector3 bottomRight;

		// Token: 0x040031D9 RID: 12761
		public float origin;

		// Token: 0x040031DA RID: 12762
		public float ascender;

		// Token: 0x040031DB RID: 12763
		public float baseLine;

		// Token: 0x040031DC RID: 12764
		public float descender;

		// Token: 0x040031DD RID: 12765
		public float xAdvance;

		// Token: 0x040031DE RID: 12766
		public float aspectRatio;

		// Token: 0x040031DF RID: 12767
		public float scale;

		// Token: 0x040031E0 RID: 12768
		public Color32 color;

		// Token: 0x040031E1 RID: 12769
		public FontStyles style;

		// Token: 0x040031E2 RID: 12770
		public bool isVisible;
	}
}
