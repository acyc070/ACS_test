using System;
using UnityEngine;

namespace S13Audio
{
	// Token: 0x02000062 RID: 98
	public class S13AudioEventTrigger : MonoBehaviour
	{
		// Token: 0x0600036C RID: 876 RVA: 0x000053A2 File Offset: 0x000035A2
		private void Awake()
		{
			this.am = S13AudioManager.Instance;
			if (this.am.Equals(null))
			{
				Debug.LogError("S13 Audio Event Trigger cannot find instance of S13AudioManager in scene", base.gameObject);
			}
		}

		// Token: 0x0600036D RID: 877 RVA: 0x000053D0 File Offset: 0x000035D0
		private void OnTriggerEnter(Collider other)
		{
			if (!this.triggerOnEnter)
			{
				return;
			}
			this.am.InvokeEvent(this.onEnterEventName, this.onEnterDelayTime);
		}

		// Token: 0x0600036E RID: 878 RVA: 0x000053F5 File Offset: 0x000035F5
		private void OnTriggerExit(Collider other)
		{
			if (!this.triggerOnExit)
			{
				return;
			}
			this.am.InvokeEvent(this.onExitEventName, this.onEnterDelayTime);
		}

		// Token: 0x040001DF RID: 479
		public bool triggerOnEnter = true;

		// Token: 0x040001E0 RID: 480
		public bool triggerOnExit = true;

		// Token: 0x040001E1 RID: 481
		public string onEnterEventName = string.Empty;

		// Token: 0x040001E2 RID: 482
		public string onExitEventName = string.Empty;

		// Token: 0x040001E3 RID: 483
		[Space]
		public float onEnterDelayTime;

		// Token: 0x040001E4 RID: 484
		public float onExitDelayTime;

		// Token: 0x040001E5 RID: 485
		public bool useDelayTimes;

		// Token: 0x040001E6 RID: 486
		private S13AudioManager am;
	}
}
