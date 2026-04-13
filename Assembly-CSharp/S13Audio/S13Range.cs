using System;
using UnityEngine;

namespace S13Audio
{
	// Token: 0x0200002B RID: 43
	public class S13Range
	{
		// Token: 0x060000CC RID: 204 RVA: 0x00002AC0 File Offset: 0x00000CC0
		public S13Range(int start, int end)
		{
			this.Set(start, end);
		}

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x060000CD RID: 205 RVA: 0x00002AD0 File Offset: 0x00000CD0
		// (set) Token: 0x060000CE RID: 206 RVA: 0x00002AD8 File Offset: 0x00000CD8
		public int Start
		{
			get
			{
				return this._start;
			}
			set
			{
				this.Set(value, this.End);
			}
		}

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x060000CF RID: 207 RVA: 0x00002AE7 File Offset: 0x00000CE7
		// (set) Token: 0x060000D0 RID: 208 RVA: 0x00002AEF File Offset: 0x00000CEF
		public int End
		{
			get
			{
				return this._end;
			}
			set
			{
				this.Set(this.Start, value);
			}
		}

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x060000D1 RID: 209 RVA: 0x00002AFE File Offset: 0x00000CFE
		public int Length
		{
			get
			{
				return this.End - this.Start + 1;
			}
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x00002B0F File Offset: 0x00000D0F
		public override string ToString()
		{
			return string.Format("[Range: {0} to {1}]", this.Start, this.End);
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x00002B31 File Offset: 0x00000D31
		public void Set(int start, int end)
		{
			if (end - start < 0)
			{
				throw new UnityException("Invalid range.");
			}
			this._start = start;
			this._end = end;
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x00002B55 File Offset: 0x00000D55
		public bool InRange(int value)
		{
			return this.Start <= value && value <= this.End;
		}

		// Token: 0x040000BB RID: 187
		private int _start;

		// Token: 0x040000BC RID: 188
		private int _end;
	}
}
