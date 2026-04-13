using System;
using UnityEngine;

namespace S13Audio
{
	// Token: 0x02000057 RID: 87
	[RequireComponent(typeof(Collider))]
	public class ENVTestTrigger : MonoBehaviour
	{
		// Token: 0x06000341 RID: 833 RVA: 0x0002A428 File Offset: 0x00028628
		private void Start()
		{
			this._audioManager = global::UnityEngine.Object.FindObjectOfType<S13AudioManager>();
			if (this._audioManager == null)
			{
				Debug.LogError(base.name + ": AudioManager not found.");
			}
			this._audioSource = this.audioSourceOrEvent.GetComponent<S13AudioSource>();
		}

		// Token: 0x06000342 RID: 834 RVA: 0x0002A478 File Offset: 0x00028678
		private void OnTriggerEnter(Collider other)
		{
			if (this._audioSource != null)
			{
				this._audioManager.PlayAudio(this._audioSource.name);
			}
			else
			{
				this._audioManager.InvokeEvent(this.audioSourceOrEvent.name, 0f);
			}
		}

		// Token: 0x040001B2 RID: 434
		public GameObject audioSourceOrEvent;

		// Token: 0x040001B3 RID: 435
		private S13AudioManager _audioManager;

		// Token: 0x040001B4 RID: 436
		private S13AudioSource _audioSource;
	}
}
