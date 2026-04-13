using System;
using UnityEngine;

namespace S13Audio
{
	// Token: 0x0200000A RID: 10
	public class S13BehaviorOnStart : MonoBehaviour
	{
		// Token: 0x06000025 RID: 37 RVA: 0x0000258E File Offset: 0x0000078E
		private void Awake()
		{
			this._audioManager = global::UnityEngine.Object.FindObjectOfType<S13AudioManager>();
			if (this._audioManager == null)
			{
				Debug.LogError(base.name + ": No instance of AudioManager found in scene.");
			}
		}

		// Token: 0x06000026 RID: 38 RVA: 0x00021648 File Offset: 0x0001F848
		private void Start()
		{
			if (!this._audioManager || this.onStart == string.Empty)
			{
				return;
			}
			if (this.onStart.StartsWith("evt_"))
			{
				this._audioManager.InvokeEvent(this.onStart, this.delayStart);
			}
			else if (this.onStart.StartsWith("mxs_"))
			{
				this._audioManager.ToSnapshot(this.mixerName, this.onStart, this.delayStart);
			}
			else if (this.delayStart > 0f)
			{
				this._audioManager.PlayAudioDelayed(this.onStart, this.delayStart);
			}
			else
			{
				this._audioManager.PlayAudio(this.onStart);
			}
		}

		// Token: 0x04000029 RID: 41
		public string onStart;

		// Token: 0x0400002A RID: 42
		public float delayStart;

		// Token: 0x0400002B RID: 43
		public string mixerName;

		// Token: 0x0400002C RID: 44
		private S13AudioManager _audioManager;
	}
}
