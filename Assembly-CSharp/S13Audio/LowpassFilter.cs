using System;
using UnityEngine;

namespace S13Audio
{
	// Token: 0x0200001E RID: 30
	public class LowpassFilter : AudioEffectBase
	{
		// Token: 0x0600007F RID: 127 RVA: 0x000225A8 File Offset: 0x000207A8
		public override void Attach<T>(T unityFilter)
		{
			object obj = unityFilter;
			if (obj is AudioLowPassFilter)
			{
				this._unityFilter = (AudioLowPassFilter)obj;
				this.UpdateParameters();
			}
		}

		// Token: 0x06000080 RID: 128 RVA: 0x00002955 File Offset: 0x00000B55
		public override void UpdateParameters()
		{
			this._unityFilter.cutoffFrequency = this.cutoffFrequency;
			this._unityFilter.lowpassResonanceQ = this.resonance;
		}

		// Token: 0x04000081 RID: 129
		private AudioLowPassFilter _unityFilter;
	}
}
