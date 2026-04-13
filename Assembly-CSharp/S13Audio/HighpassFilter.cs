using System;
using UnityEngine;

namespace S13Audio
{
	// Token: 0x0200001D RID: 29
	public class HighpassFilter : AudioEffectBase
	{
		// Token: 0x0600007C RID: 124 RVA: 0x00022574 File Offset: 0x00020774
		public override void Attach<T>(T unityFilter)
		{
			object obj = unityFilter;
			if (obj is AudioHighPassFilter)
			{
				this._unityFilter = (AudioHighPassFilter)obj;
				this.UpdateParameters();
			}
		}

		// Token: 0x0600007D RID: 125 RVA: 0x00002931 File Offset: 0x00000B31
		public override void UpdateParameters()
		{
			this._unityFilter.cutoffFrequency = this.cutoffFrequency;
			this._unityFilter.highpassResonanceQ = this.resonance;
		}

		// Token: 0x04000080 RID: 128
		private AudioHighPassFilter _unityFilter;
	}
}
