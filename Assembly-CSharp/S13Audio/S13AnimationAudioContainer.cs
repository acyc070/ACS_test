using System;
using UnityEngine;

namespace S13Audio
{
	// Token: 0x0200005E RID: 94
	[Serializable]
	public struct S13AnimationAudioContainer
	{
		// Token: 0x040001D1 RID: 465
		public string id;

		// Token: 0x040001D2 RID: 466
		[Tooltip("Name of the animation clip")]
		public string animationClipName;

		// Token: 0x040001D3 RID: 467
		public ContainerFunction functionType;

		// Token: 0x040001D4 RID: 468
		[Tooltip("The Game Object which contains the audiosource to play")]
		public GameObject audioSourceObject;

		// Token: 0x040001D5 RID: 469
		[Tooltip("Which frame(s) of the animation clip to trigger the event on.")]
		[AudioSlider("Frame", 0, 10000)]
		public int[] frame;
	}
}
