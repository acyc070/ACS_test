using System;
using UnityEngine;

namespace S13Audio
{
	// Token: 0x02000012 RID: 18
	public abstract class AudioEffectBase : MonoBehaviour
	{
		// Token: 0x06000044 RID: 68
		public abstract void Attach<T>(T unityFilter);

		// Token: 0x06000045 RID: 69
		public abstract void UpdateParameters();

		// Token: 0x04000052 RID: 82
		[AudioSlider("Cutoff Frequency (Hz)", 10f, 22000f)]
		public float cutoffFrequency = 5000f;

		// Token: 0x04000053 RID: 83
		[AudioSlider("Resonance", 1f, 10f)]
		public float resonance = 1f;
	}
}
