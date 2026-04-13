using System;
using UnityEngine;

namespace S13Audio
{
	// Token: 0x02000011 RID: 17
	public class CrossFade : MonoBehaviour
	{
		// Token: 0x06000042 RID: 66 RVA: 0x00021C94 File Offset: 0x0001FE94
		public void DoCrossFade(float t)
		{
			float num = this.curve.Evaluate(t);
			Debug.Log(num);
			this.zoomIn.volume = S13AudioUtil.Lin2dB(1f - num);
			this.zoomOut.volume = S13AudioUtil.Lin2dB(num);
			this.zoomIn.UpdateParameters();
			this.zoomOut.UpdateParameters();
		}

		// Token: 0x0400004F RID: 79
		public AnimationCurve curve;

		// Token: 0x04000050 RID: 80
		public S13AudioSource zoomIn;

		// Token: 0x04000051 RID: 81
		public S13AudioSource zoomOut;
	}
}
