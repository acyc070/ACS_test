using System;

namespace TMPro
{
	// Token: 0x0200063A RID: 1594
	public struct TMP_XmlTagStack<T>
	{
		// Token: 0x06002D61 RID: 11617 RVA: 0x00020826 File Offset: 0x0001EA26
		public TMP_XmlTagStack(T[] tagStack)
		{
			this.itemStack = tagStack;
			this.index = 0;
		}

		// Token: 0x06002D62 RID: 11618 RVA: 0x00020836 File Offset: 0x0001EA36
		public void Clear()
		{
			this.index = 0;
		}

		// Token: 0x06002D63 RID: 11619 RVA: 0x0002083F File Offset: 0x0001EA3F
		public void SetDefault(T item)
		{
			this.itemStack[0] = item;
			this.index = 1;
		}

		// Token: 0x06002D64 RID: 11620 RVA: 0x00020855 File Offset: 0x0001EA55
		public void Add(T item)
		{
			if (this.index < this.itemStack.Length)
			{
				this.itemStack[this.index] = item;
				this.index++;
			}
		}

		// Token: 0x06002D65 RID: 11621 RVA: 0x00112020 File Offset: 0x00110220
		public T Remove()
		{
			this.index--;
			if (this.index <= 0)
			{
				this.index = 0;
				return this.itemStack[0];
			}
			return this.itemStack[this.index - 1];
		}

		// Token: 0x06002D66 RID: 11622 RVA: 0x0002088A File Offset: 0x0001EA8A
		public T CurrentItem()
		{
			if (this.index > 0)
			{
				return this.itemStack[this.index - 1];
			}
			return this.itemStack[0];
		}

		// Token: 0x06002D67 RID: 11623 RVA: 0x000208B8 File Offset: 0x0001EAB8
		public T PreviousItem()
		{
			if (this.index > 1)
			{
				return this.itemStack[this.index - 2];
			}
			return this.itemStack[0];
		}

		// Token: 0x0400316F RID: 12655
		public T[] itemStack;

		// Token: 0x04003170 RID: 12656
		public int index;
	}
}
