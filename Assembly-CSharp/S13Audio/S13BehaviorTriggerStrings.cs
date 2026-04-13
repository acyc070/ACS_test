using System;
using UnityEngine;

namespace S13Audio
{
	// Token: 0x0200000B RID: 11
	[RequireComponent(typeof(Collider))]
	public class S13BehaviorTriggerStrings : MonoBehaviour
	{
		// Token: 0x06000028 RID: 40 RVA: 0x000025D4 File Offset: 0x000007D4
		private void Awake()
		{
			this._audioManager = global::UnityEngine.Object.FindObjectOfType<S13AudioManager>();
			if (this._audioManager == null)
			{
				Debug.LogError(base.name + ": No instance of AudioManager found in scene.", base.gameObject);
			}
		}

		// Token: 0x06000029 RID: 41 RVA: 0x0000260D File Offset: 0x0000080D
		private void OnTriggerEnter(Collider other)
		{
			if (!this.MatchConditions(other.gameObject))
			{
				return;
			}
			this.EnterHandler();
		}

		// Token: 0x0600002A RID: 42 RVA: 0x0000260D File Offset: 0x0000080D
		private void OnTriggerEnter2D(Collider2D other)
		{
			if (!this.MatchConditions(other.gameObject))
			{
				return;
			}
			this.EnterHandler();
		}

		// Token: 0x0600002B RID: 43 RVA: 0x00002627 File Offset: 0x00000827
		private void OnTriggerExit(Collider other)
		{
			if (!this.MatchConditions(other.gameObject))
			{
				return;
			}
			this.ExitHandler();
		}

		// Token: 0x0600002C RID: 44 RVA: 0x00002627 File Offset: 0x00000827
		private void OnTriggerExit2D(Collider2D other)
		{
			if (!this.MatchConditions(other.gameObject))
			{
				return;
			}
			this.ExitHandler();
		}

		// Token: 0x0600002D RID: 45 RVA: 0x00021720 File Offset: 0x0001F920
		private bool MatchConditions(GameObject obj)
		{
			return (this.triggerObjectTag != string.Empty && obj.CompareTag(this.triggerObjectTag)) || (this.triggerObjectName != string.Empty && this.triggerObjectName == obj.name) || obj.layer == LayerMask.NameToLayer(this.triggerObjectLayerName);
		}

		// Token: 0x0600002E RID: 46 RVA: 0x0002179C File Offset: 0x0001F99C
		private void EnterHandler()
		{
			if (!this._audioManager || this.stringIDEnter == string.Empty)
			{
				return;
			}
			S13BehaviorTriggerStrings.EventType eventType = this.eventType;
			if (eventType != S13BehaviorTriggerStrings.EventType.InvokeEvent)
			{
				if (eventType != S13BehaviorTriggerStrings.EventType.MixerSnapshot)
				{
					if (eventType == S13BehaviorTriggerStrings.EventType.PlayAndStop)
					{
						if (this.enterTiming > 0f)
						{
							this._audioManager.PlayAudioDelayed(this.stringIDEnter, this.enterTiming);
						}
						else
						{
							this._audioManager.PlayAudio(this.stringIDEnter);
						}
					}
				}
				else
				{
					if (this.mixerName == string.Empty)
					{
						Debug.LogWarning("Must enter a mixer name to change a snapshot", base.gameObject);
						return;
					}
					this._audioManager.ToSnapshot(this.mixerName, this.stringIDEnter, this.enterTiming);
				}
			}
			else
			{
				this._audioManager.InvokeEvent(this.stringIDEnter, this.enterTiming);
			}
		}

		// Token: 0x0600002F RID: 47 RVA: 0x00021898 File Offset: 0x0001FA98
		private void ExitHandler()
		{
			if (!this._audioManager || this.stringIDExit == string.Empty)
			{
				return;
			}
			S13BehaviorTriggerStrings.EventType eventType = this.eventType;
			if (eventType != S13BehaviorTriggerStrings.EventType.InvokeEvent)
			{
				if (eventType != S13BehaviorTriggerStrings.EventType.MixerSnapshot)
				{
					if (eventType == S13BehaviorTriggerStrings.EventType.PlayAndStop)
					{
						if (this.exitTiming > 0f)
						{
							this._audioManager.StopAudioDelayed(this.stringIDExit, this.exitTiming, false);
						}
						else
						{
							this._audioManager.StopAudio(this.stringIDExit, false);
						}
					}
				}
				else
				{
					if (this.mixerName == string.Empty)
					{
						Debug.LogWarning("Must enter a mixer name to change a snapshot", base.gameObject);
						return;
					}
					this._audioManager.ToSnapshot(this.mixerName, this.stringIDExit, this.exitTiming);
				}
			}
			else
			{
				this._audioManager.InvokeEvent(this.stringIDExit, this.exitTiming);
			}
		}

		// Token: 0x0400002D RID: 45
		[SerializeField]
		private S13BehaviorTriggerStrings.EventType eventType;

		// Token: 0x0400002E RID: 46
		[SerializeField]
		private string stringIDEnter;

		// Token: 0x0400002F RID: 47
		[AudioSlider("Delay/Transition Time", 0f, 1000f)]
		[SerializeField]
		private float enterTiming;

		// Token: 0x04000030 RID: 48
		[SerializeField]
		private string stringIDExit;

		// Token: 0x04000031 RID: 49
		[AudioSlider("Delay/Transition Time", 0f, 1000f)]
		[SerializeField]
		private float exitTiming;

		// Token: 0x04000032 RID: 50
		[Space]
		[SerializeField]
		private string mixerName;

		// Token: 0x04000033 RID: 51
		[Header("Trigger Conditions")]
		[SerializeField]
		private string triggerObjectTag;

		// Token: 0x04000034 RID: 52
		[SerializeField]
		private string triggerObjectName;

		// Token: 0x04000035 RID: 53
		[SerializeField]
		private string triggerObjectLayerName = "Audio";

		// Token: 0x04000036 RID: 54
		private S13AudioManager _audioManager;

		// Token: 0x0200000C RID: 12
		private enum EventType
		{
			// Token: 0x04000038 RID: 56
			InvokeEvent,
			// Token: 0x04000039 RID: 57
			MixerSnapshot,
			// Token: 0x0400003A RID: 58
			PlayAndStop
		}
	}
}
