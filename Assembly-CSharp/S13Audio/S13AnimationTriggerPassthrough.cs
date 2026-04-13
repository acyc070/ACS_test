using System;
using UnityEngine;

namespace S13Audio
{
	// Token: 0x02000060 RID: 96
	public class S13AnimationTriggerPassthrough : MonoBehaviour
	{
		// Token: 0x06000365 RID: 869 RVA: 0x000052AD File Offset: 0x000034AD
		private void Start()
		{
			this.animationSwitch = base.GetComponentInChildren<S13AnimationSwitch>();
			if (this.animationSwitch == null)
			{
				Debug.LogError("S13AnimationTriggerPassthrough cannot find an S13AnimationSwitch in child objects.");
			}
		}

		// Token: 0x06000366 RID: 870 RVA: 0x000052D6 File Offset: 0x000034D6
		public void PlaySwitch(string id)
		{
			if (this.animationSwitch == null)
			{
				return;
			}
			this.animationSwitch.PlaySwitch(id);
		}

		// Token: 0x06000367 RID: 871 RVA: 0x000052F6 File Offset: 0x000034F6
		public void StopSwitch(string id)
		{
			if (this.animationSwitch == null)
			{
				return;
			}
			this.animationSwitch.StopSwitch(id);
		}

		// Token: 0x06000368 RID: 872 RVA: 0x00005316 File Offset: 0x00003516
		public void PlayLoadedSound(string id)
		{
			if (this.animationSwitch == null)
			{
				return;
			}
			this.animationSwitch.PlayLoadedSound(id);
		}

		// Token: 0x06000369 RID: 873 RVA: 0x00005336 File Offset: 0x00003536
		public void StopLoadedSound(string id)
		{
			if (this.animationSwitch == null)
			{
				return;
			}
			this.animationSwitch.StopLoadedSound(id);
		}

		// Token: 0x0600036A RID: 874 RVA: 0x00005356 File Offset: 0x00003556
		public void TriggerAudioEvent(string id)
		{
			if (this.animationSwitch == null)
			{
				return;
			}
			this.animationSwitch.TriggerAudioEvent(id);
		}

		// Token: 0x040001DC RID: 476
		private S13AnimationSwitch animationSwitch;
	}
}
