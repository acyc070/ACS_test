using System;
using UnityEngine;

namespace S13Audio
{
	// Token: 0x0200002A RID: 42
	public class S13OffsetImpl
	{
		// Token: 0x060000CA RID: 202 RVA: 0x00002A96 File Offset: 0x00000C96
		public S13OffsetImpl(int sampleOffset)
		{
			sampleOffset = ((sampleOffset >= 0) ? sampleOffset : 0);
			this._offsetSamples = sampleOffset;
		}

		// Token: 0x060000CB RID: 203 RVA: 0x00022D78 File Offset: 0x00020F78
		public void SetPlayPosition(AudioSource audioSource, bool randomOffset = false)
		{
			int i = this._offsetSamples;
			if (randomOffset)
			{
				float num = global::UnityEngine.Random.value;
				if (Mathf.Abs(num - this._lastRandom) < 0.1f)
				{
					num += this._lastRandom + global::UnityEngine.Random.Range(-0.5f, 0.5f);
				}
				i += (int)((float)audioSource.clip.samples * num);
				this._lastRandom = num;
			}
			while (i < 0)
			{
				i += audioSource.clip.samples;
			}
			while (i > audioSource.clip.samples)
			{
				i -= audioSource.clip.samples;
			}
			audioSource.timeSamples = i;
		}

		// Token: 0x040000B9 RID: 185
		private int _offsetSamples;

		// Token: 0x040000BA RID: 186
		private float _lastRandom = -1f;
	}
}
