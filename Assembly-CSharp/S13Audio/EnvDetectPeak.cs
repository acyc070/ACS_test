using System;
using UnityEngine;

namespace S13Audio
{
	// Token: 0x02000019 RID: 25
	public class EnvDetectPeak : IEnvelopeDetection
	{
		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000062 RID: 98 RVA: 0x000027C4 File Offset: 0x000009C4
		// (set) Token: 0x06000061 RID: 97 RVA: 0x000027BB File Offset: 0x000009BB
		public float[] Buffer
		{
			get
			{
				return this._buffer;
			}
			set
			{
				this._buffer = value;
			}
		}

		// Token: 0x17000008 RID: 8
		public float this[int index]
		{
			get
			{
				return Mathf.Abs(this._buffer[index]);
			}
		}

		// Token: 0x06000064 RID: 100 RVA: 0x00002482 File Offset: 0x00000682
		public void Reset()
		{
		}

		// Token: 0x0400006E RID: 110
		private float[] _buffer;
	}
}
