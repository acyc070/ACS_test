using System;
using UnityEngine;

namespace TMPro
{
	// Token: 0x02000620 RID: 1568
	[Serializable]
	public class TMP_Style
	{
		// Token: 0x17000494 RID: 1172
		// (get) Token: 0x06002BEF RID: 11247 RVA: 0x0001F652 File Offset: 0x0001D852
		// (set) Token: 0x06002BF0 RID: 11248 RVA: 0x0001F65A File Offset: 0x0001D85A
		public string name
		{
			get
			{
				return this.m_Name;
			}
			set
			{
				if (value != this.m_Name)
				{
					this.m_Name = value;
				}
			}
		}

		// Token: 0x17000495 RID: 1173
		// (get) Token: 0x06002BF1 RID: 11249 RVA: 0x0001F674 File Offset: 0x0001D874
		// (set) Token: 0x06002BF2 RID: 11250 RVA: 0x0001F67C File Offset: 0x0001D87C
		public int hashCode
		{
			get
			{
				return this.m_HashCode;
			}
			set
			{
				if (value != this.m_HashCode)
				{
					this.m_HashCode = value;
				}
			}
		}

		// Token: 0x17000496 RID: 1174
		// (get) Token: 0x06002BF3 RID: 11251 RVA: 0x0001F691 File Offset: 0x0001D891
		public string styleOpeningDefinition
		{
			get
			{
				return this.m_OpeningDefinition;
			}
		}

		// Token: 0x17000497 RID: 1175
		// (get) Token: 0x06002BF4 RID: 11252 RVA: 0x0001F699 File Offset: 0x0001D899
		public string styleClosingDefinition
		{
			get
			{
				return this.m_ClosingDefinition;
			}
		}

		// Token: 0x17000498 RID: 1176
		// (get) Token: 0x06002BF5 RID: 11253 RVA: 0x0001F6A1 File Offset: 0x0001D8A1
		public int[] styleOpeningTagArray
		{
			get
			{
				return this.m_OpeningTagArray;
			}
		}

		// Token: 0x17000499 RID: 1177
		// (get) Token: 0x06002BF6 RID: 11254 RVA: 0x0001F6A9 File Offset: 0x0001D8A9
		public int[] styleClosingTagArray
		{
			get
			{
				return this.m_ClosingTagArray;
			}
		}

		// Token: 0x06002BF7 RID: 11255 RVA: 0x00106E10 File Offset: 0x00105010
		public void RefreshStyle()
		{
			this.m_HashCode = TMP_TextUtilities.GetSimpleHashCode(this.m_Name);
			this.m_OpeningTagArray = new int[this.m_OpeningDefinition.Length];
			for (int i = 0; i < this.m_OpeningDefinition.Length; i++)
			{
				this.m_OpeningTagArray[i] = (int)this.m_OpeningDefinition[i];
			}
			this.m_ClosingTagArray = new int[this.m_ClosingDefinition.Length];
			for (int j = 0; j < this.m_ClosingDefinition.Length; j++)
			{
				this.m_ClosingTagArray[j] = (int)this.m_ClosingDefinition[j];
			}
		}

		// Token: 0x04003015 RID: 12309
		[SerializeField]
		private string m_Name;

		// Token: 0x04003016 RID: 12310
		[SerializeField]
		private int m_HashCode;

		// Token: 0x04003017 RID: 12311
		[SerializeField]
		private string m_OpeningDefinition;

		// Token: 0x04003018 RID: 12312
		[SerializeField]
		private string m_ClosingDefinition;

		// Token: 0x04003019 RID: 12313
		[SerializeField]
		private int[] m_OpeningTagArray;

		// Token: 0x0400301A RID: 12314
		[SerializeField]
		private int[] m_ClosingTagArray;
	}
}
