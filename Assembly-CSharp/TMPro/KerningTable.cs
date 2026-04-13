using System;
using System.Collections.Generic;
using System.Linq;

namespace TMPro
{
	// Token: 0x02000646 RID: 1606
	[Serializable]
	public class KerningTable
	{
		// Token: 0x06002D89 RID: 11657 RVA: 0x00020A7F File Offset: 0x0001EC7F
		public KerningTable()
		{
			this.kerningPairs = new List<KerningPair>();
		}

		// Token: 0x06002D8A RID: 11658 RVA: 0x00112510 File Offset: 0x00110710
		public void AddKerningPair()
		{
			if (this.kerningPairs.Count == 0)
			{
				this.kerningPairs.Add(new KerningPair(0, 0, 0f));
			}
			else
			{
				int ascII_Left = this.kerningPairs.Last<KerningPair>().AscII_Left;
				int ascII_Right = this.kerningPairs.Last<KerningPair>().AscII_Right;
				float xadvanceOffset = this.kerningPairs.Last<KerningPair>().XadvanceOffset;
				this.kerningPairs.Add(new KerningPair(ascII_Left, ascII_Right, xadvanceOffset));
			}
		}

		// Token: 0x06002D8B RID: 11659 RVA: 0x00112590 File Offset: 0x00110790
		public int AddKerningPair(int left, int right, float offset)
		{
			int num = this.kerningPairs.FindIndex((KerningPair item) => item.AscII_Left == left && item.AscII_Right == right);
			if (num == -1)
			{
				this.kerningPairs.Add(new KerningPair(left, right, offset));
				return 0;
			}
			return -1;
		}

		// Token: 0x06002D8C RID: 11660 RVA: 0x001125F0 File Offset: 0x001107F0
		public void RemoveKerningPair(int left, int right)
		{
			int num = this.kerningPairs.FindIndex((KerningPair item) => item.AscII_Left == left && item.AscII_Right == right);
			if (num != -1)
			{
				this.kerningPairs.RemoveAt(num);
			}
		}

		// Token: 0x06002D8D RID: 11661 RVA: 0x00020A92 File Offset: 0x0001EC92
		public void RemoveKerningPair(int index)
		{
			this.kerningPairs.RemoveAt(index);
		}

		// Token: 0x06002D8E RID: 11662 RVA: 0x0011263C File Offset: 0x0011083C
		public void SortKerningPairs()
		{
			if (this.kerningPairs.Count > 0)
			{
				this.kerningPairs = (from s in this.kerningPairs
					orderby s.AscII_Left, s.AscII_Right
					select s).ToList<KerningPair>();
			}
		}

		// Token: 0x040031B4 RID: 12724
		public List<KerningPair> kerningPairs;
	}
}
