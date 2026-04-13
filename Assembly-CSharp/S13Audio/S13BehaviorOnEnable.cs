using System;
using UnityEngine;

namespace S13Audio
{
	// Token: 0x02000009 RID: 9
	public class S13BehaviorOnEnable : MonoBehaviour
	{
		// Token: 0x06000021 RID: 33 RVA: 0x0000255B File Offset: 0x0000075B
		private void Awake()
		{
			this._audioManager = global::UnityEngine.Object.FindObjectOfType<S13AudioManager>();
			if (this._audioManager == null)
			{
				Debug.LogError(base.name + ": No instance of AudioManager found in scene.");
			}
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00021494 File Offset: 0x0001F694
		private void OnEnable()
		{
			if (!this._audioManager || this.onEnable == string.Empty)
			{
				return;
			}
			if (this.onEnable.StartsWith("evt_"))
			{
				this._audioManager.InvokeEvent(this.onEnable, this.delayEnable);
			}
			else if (this.onEnable.StartsWith("mxs_"))
			{
				this._audioManager.ToSnapshot(this.mixerName, this.onEnable, this.delayEnable);
			}
			else if (this.delayEnable > 0f)
			{
				this._audioManager.PlayAudioDelayed(this.onEnable, this.delayEnable);
			}
			else
			{
				this._audioManager.PlayAudio(this.onEnable);
			}
		}

		// Token: 0x06000023 RID: 35 RVA: 0x0002156C File Offset: 0x0001F76C
		private void OnDisable()
		{
			if (!this._audioManager || this.onDisable == string.Empty)
			{
				return;
			}
			if (this.onDisable.StartsWith("evt_"))
			{
				this._audioManager.InvokeEvent(this.onDisable, this.delayDisable);
			}
			else if (this.onDisable.StartsWith("mxs_"))
			{
				this._audioManager.ToSnapshot(this.mixerName, this.onDisable, this.delayDisable);
			}
			else if (this.delayDisable > 0f)
			{
				this._audioManager.StopAudioDelayed(this.onDisable, this.delayDisable, false);
			}
			else
			{
				this._audioManager.StopAudio(this.onDisable, false);
			}
		}

		// Token: 0x04000023 RID: 35
		[Tooltip("Sends message when this script, object or parent is Enabled or Added to the Scene")]
		public string onEnable;

		// Token: 0x04000024 RID: 36
		[Tooltip("Waits for 'X' seconds to send the message")]
		public float delayEnable;

		// Token: 0x04000025 RID: 37
		[Tooltip("Sends message when this script, object or parent is Disabled or Removed from the Scene")]
		public string onDisable;

		// Token: 0x04000026 RID: 38
		[Tooltip("Waits for 'X' seconds to send the message")]
		public float delayDisable;

		// Token: 0x04000027 RID: 39
		[Tooltip("Only one common mixer name possible")]
		public string mixerName;

		// Token: 0x04000028 RID: 40
		private S13AudioManager _audioManager;
	}
}
