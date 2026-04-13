using System;

namespace TMPro
{
	// Token: 0x0200064E RID: 1614
	public struct TMP_LinkInfo
	{
		// Token: 0x06002D97 RID: 11671 RVA: 0x001126B0 File Offset: 0x001108B0
		internal void SetLinkID(char[] text, int startIndex, int length)
		{
			if (this.linkID == null || this.linkID.Length < length)
			{
				this.linkID = new char[length];
			}
			for (int i = 0; i < length; i++)
			{
				this.linkID[i] = text[startIndex + i];
			}
		}

		// Token: 0x06002D98 RID: 11672 RVA: 0x00112704 File Offset: 0x00110904
		public string GetLinkText()
		{
			string text = string.Empty;
			TMP_TextInfo textInfo = this.textComponent.textInfo;
			for (int i = this.linkTextfirstCharacterIndex; i < this.linkTextfirstCharacterIndex + this.linkTextLength; i++)
			{
				text += textInfo.characterInfo[i].character;
			}
			return text;
		}

		// Token: 0x06002D99 RID: 11673 RVA: 0x00020B35 File Offset: 0x0001ED35
		public string GetLinkID()
		{
			if (this.textComponent == null)
			{
				return string.Empty;
			}
			return new string(this.linkID, 0, this.linkIdLength);
		}

		// Token: 0x040031F1 RID: 12785
		public TMP_Text textComponent;

		// Token: 0x040031F2 RID: 12786
		public int hashCode;

		// Token: 0x040031F3 RID: 12787
		public int linkIdFirstCharacterIndex;

		// Token: 0x040031F4 RID: 12788
		public int linkIdLength;

		// Token: 0x040031F5 RID: 12789
		public int linkTextfirstCharacterIndex;

		// Token: 0x040031F6 RID: 12790
		public int linkTextLength;

		// Token: 0x040031F7 RID: 12791
		internal char[] linkID;
	}
}
