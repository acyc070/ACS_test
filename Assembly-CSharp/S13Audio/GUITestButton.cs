using System;
using UnityEngine;

namespace S13Audio
{
	// Token: 0x02000059 RID: 89
	public class GUITestButton : MonoBehaviour
	{
		// Token: 0x06000347 RID: 839 RVA: 0x0002A68C File Offset: 0x0002888C
		private void Start()
		{
			this._audioManager = global::UnityEngine.Object.FindObjectOfType<S13AudioManager>();
			if (this._audioManager == null)
			{
				Debug.LogError(base.name + ": AudioManager not found.");
			}
			this._audioSource = this.audioSourceOrEvent.GetComponent<S13AudioSource>();
		}

		// Token: 0x06000348 RID: 840 RVA: 0x0002A6DC File Offset: 0x000288DC
		private void OnGUI()
		{
			if (GUI.Button(this.buttonRect, this.audioSourceOrEvent.name))
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
		}

		// Token: 0x06000349 RID: 841 RVA: 0x00002482 File Offset: 0x00000682
		private void OnDrawGizmosSelected()
		{
		}

		// Token: 0x040001BC RID: 444
		public GameObject audioSourceOrEvent;

		// Token: 0x040001BD RID: 445
		public Rect buttonRect = new Rect(40f, 40f, 200f, 40f);

		// Token: 0x040001BE RID: 446
		private S13AudioManager _audioManager;

		// Token: 0x040001BF RID: 447
		private S13AudioSource _audioSource;
	}
}
