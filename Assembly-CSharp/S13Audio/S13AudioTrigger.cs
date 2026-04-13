using System;
using UnityEngine;

namespace S13Audio
{
	// Token: 0x02000007 RID: 7
	[RequireComponent(typeof(Collider), typeof(S13AudioSource))]
	public class S13AudioTrigger : MonoBehaviour
	{
		// Token: 0x06000015 RID: 21 RVA: 0x00021304 File Offset: 0x0001F504
		private void Awake()
		{
			this.audioSources = base.GetComponents<S13AudioSource>();
			if (this.audioSources.Equals(null))
			{
				Debug.LogError("The S13AudioTrigger Can't find any S13AudioSources.", base.gameObject);
			}
			Collider component = base.GetComponent<Collider>();
			if (component.Equals(null))
			{
				Debug.LogError("The S13AudioTrigger Can't find any S13AudioSources.", base.gameObject);
			}
			component.isTrigger = true;
		}

		// Token: 0x06000016 RID: 22 RVA: 0x000024C6 File Offset: 0x000006C6
		private void OnTriggerEnter(Collider other)
		{
			if (!this.MatchConditions(other.gameObject))
			{
				return;
			}
			this.PlayAudio();
		}

		// Token: 0x06000017 RID: 23 RVA: 0x000024C6 File Offset: 0x000006C6
		private void OnTriggerEnter2D(Collider2D other)
		{
			if (!this.MatchConditions(other.gameObject))
			{
				return;
			}
			this.PlayAudio();
		}

		// Token: 0x06000018 RID: 24 RVA: 0x000024E0 File Offset: 0x000006E0
		private void OnTriggerExit(Collider other)
		{
			if (!this.MatchConditions(other.gameObject))
			{
				return;
			}
			this.StopAudio();
		}

		// Token: 0x06000019 RID: 25 RVA: 0x000024E0 File Offset: 0x000006E0
		private void OnTriggerExit2D(Collider2D other)
		{
			if (!this.MatchConditions(other.gameObject))
			{
				return;
			}
			this.StopAudio();
		}

		// Token: 0x0600001A RID: 26 RVA: 0x00021368 File Offset: 0x0001F568
		private bool MatchConditions(GameObject obj)
		{
			return (this.triggerObjectTag != string.Empty && obj.CompareTag(this.triggerObjectTag)) || (this.triggerObjectName != string.Empty && this.triggerObjectName == obj.name) || obj.layer == LayerMask.NameToLayer(this.triggerObjectLayerName);
		}

		// Token: 0x0600001B RID: 27 RVA: 0x000213E4 File Offset: 0x0001F5E4
		private void PlayAudio()
		{
			if (this.triggered && this.triggerOnce)
			{
				return;
			}
			foreach (S13AudioSource s13AudioSource in this.audioSources)
			{
				if (s13AudioSource != null)
				{
					s13AudioSource.Play();
				}
			}
			this.triggered = true;
		}

		// Token: 0x0600001C RID: 28 RVA: 0x00021440 File Offset: 0x0001F640
		private void StopAudio()
		{
			if (!this.triggered)
			{
				return;
			}
			foreach (S13AudioSource s13AudioSource in this.audioSources)
			{
				if (s13AudioSource != null)
				{
					s13AudioSource.Stop(false);
				}
			}
			this.triggered = false;
		}

		// Token: 0x0400001C RID: 28
		public string triggerObjectTag = string.Empty;

		// Token: 0x0400001D RID: 29
		public string triggerObjectName = string.Empty;

		// Token: 0x0400001E RID: 30
		public string triggerObjectLayerName = "Audio";

		// Token: 0x0400001F RID: 31
		public bool triggerOnce;

		// Token: 0x04000020 RID: 32
		private S13AudioSource[] audioSources;

		// Token: 0x04000021 RID: 33
		private bool triggered;
	}
}
