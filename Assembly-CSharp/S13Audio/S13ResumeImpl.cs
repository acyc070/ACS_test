using System;
using UnityEngine;

namespace S13Audio
{
	// Token: 0x0200002C RID: 44
	public class S13ResumeImpl
	{
		// Token: 0x060000D5 RID: 213 RVA: 0x00022E28 File Offset: 0x00021028
		public S13ResumeImpl(int count)
		{
			this._positions = new int[count];
			for (int i = 0; i < this._positions.Length; i++)
			{
				this._positions[i] = 0;
			}
		}

		// Token: 0x060000D6 RID: 214 RVA: 0x00002B72 File Offset: 0x00000D72
		public void ResumePosition(AudioSource audioSource, int soundIndex)
		{
			audioSource.timeSamples = this._positions[soundIndex];
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x00002B82 File Offset: 0x00000D82
		public void SavePosition(AudioSource audioSource, int soundIndex)
		{
			this._positions[soundIndex] = audioSource.timeSamples;
		}

		// Token: 0x040000BD RID: 189
		private int[] _positions;
	}
}
