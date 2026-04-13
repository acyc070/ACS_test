using System;

namespace TMPro
{
	// Token: 0x02000641 RID: 1601
	[Serializable]
	public class TMP_Glyph : TMP_TextElement
	{
		// Token: 0x06002D85 RID: 11653 RVA: 0x00112490 File Offset: 0x00110690
		public static TMP_Glyph Clone(TMP_Glyph source)
		{
			return new TMP_Glyph
			{
				id = source.id,
				x = source.x,
				y = source.y,
				width = source.width,
				height = source.height,
				xOffset = source.xOffset,
				yOffset = source.yOffset,
				xAdvance = source.xAdvance,
				scale = source.scale
			};
		}
	}
}
