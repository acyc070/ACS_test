using System;

namespace TMPro
{
	// Token: 0x0200064F RID: 1615
	public struct TMP_WordInfo
	{
		// Token: 0x06002D9A RID: 11674 RVA: 0x00112764 File Offset: 0x00110964
		public string GetWord()
		{
			string text = string.Empty;
			TMP_CharacterInfo[] characterInfo = this.textComponent.textInfo.characterInfo;
			for (int i = this.firstCharacterIndex; i < this.lastCharacterIndex + 1; i++)
			{
				text += characterInfo[i].character;
			}
			return text;
		}

		// Token: 0x040031F8 RID: 12792
		public TMP_Text textComponent;

		// Token: 0x040031F9 RID: 12793
		public int firstCharacterIndex;

		// Token: 0x040031FA RID: 12794
		public int lastCharacterIndex;

		// Token: 0x040031FB RID: 12795
		public int characterCount;
	}
}
