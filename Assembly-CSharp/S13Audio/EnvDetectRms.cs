using System;
using UnityEngine;

namespace S13Audio
{
	// Token: 0x0200001A RID: 26
	public class EnvDetectRms : IEnvelopeDetection
	{
		// Token: 0x06000065 RID: 101 RVA: 0x000027DB File Offset: 0x000009DB
		public EnvDetectRms()
		{
			this._iter = 0;
			this._lastTotal = 0f;
			this._rmsWindow = new S13RingBuffer<float>(128);
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000067 RID: 103 RVA: 0x0000280E File Offset: 0x00000A0E
		// (set) Token: 0x06000066 RID: 102 RVA: 0x00002805 File Offset: 0x00000A05
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

		// Token: 0x1700000A RID: 10
		public float this[int index]
		{
			get
			{
				float num = this._buffer[index] * this._buffer[index];
				float num2;
				float num3;
				if (this._iter < this._rmsWindow.Length - 1)
				{
					num2 = this._lastTotal + num;
					num3 = Mathf.Sqrt(1f / (float)(index + 1) * num2);
				}
				else
				{
					num2 = this._lastTotal + num - this._rmsWindow.Read();
					num3 = Mathf.Sqrt(1f / (float)this._rmsWindow.Length * num2);
				}
				this._rmsWindow.Write(num);
				this._lastTotal = num2;
				this._iter++;
				return num3;
			}
		}

		// Token: 0x06000069 RID: 105 RVA: 0x00002816 File Offset: 0x00000A16
		public void Reset()
		{
			this._iter = 0;
			this._lastTotal = 0f;
			this._rmsWindow.Clear(0f);
		}

		// Token: 0x0400006F RID: 111
		private int _iter;

		// Token: 0x04000070 RID: 112
		private float _lastTotal;

		// Token: 0x04000071 RID: 113
		private float[] _buffer;

		// Token: 0x04000072 RID: 114
		private S13RingBuffer<float> _rmsWindow;
	}
}
