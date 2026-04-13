using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace S13Audio
{
	// Token: 0x0200005A RID: 90
	public class SoundTest : MonoBehaviour
	{
		// Token: 0x0600034B RID: 843 RVA: 0x0002A74C File Offset: 0x0002894C
		private void Awake()
		{
			try
			{
				this.audioManager = S13AudioManager.Instance;
			}
			catch (Exception ex)
			{
				Debug.LogError("No instance of S13AudioManager found in scene: " + ex, base.gameObject);
				throw;
			}
			if (this.audioManager == null)
			{
				Debug.LogError(base.name + ": Could not find S13AudioManager component attached to Sound Test.", base.gameObject);
			}
			this.eventDropDown.ClearOptions();
			this.soundDropDown.ClearOptions();
		}

		// Token: 0x0600034C RID: 844 RVA: 0x0002A7D4 File Offset: 0x000289D4
		private void Start()
		{
			this.eventDropDown.AddOptions(S13EventList.GetList());
			S13AudioSource[] componentsInChildren = this.audioManager.GetComponentsInChildren<S13AudioSource>();
			List<string> list = new List<string>(componentsInChildren.Length);
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				list.Add(componentsInChildren[i].gameObject.name);
			}
			this.soundDropDown.AddOptions(list);
		}

		// Token: 0x0600034D RID: 845 RVA: 0x0002A83C File Offset: 0x00028A3C
		public void InvokeEvent()
		{
			if (this.eventIDInputField.text != string.Empty)
			{
				this.audioManager.InvokeEvent(this.eventIDInputField.text, 0f);
			}
			else
			{
				this.audioManager.InvokeEvent(this.eventDropDown.captionText.text, 0f);
			}
		}

		// Token: 0x0600034E RID: 846 RVA: 0x00005178 File Offset: 0x00003378
		public void PlayAudio()
		{
			this.audioManager.PlayAudio(this.soundDropDown.captionText.text);
		}

		// Token: 0x0600034F RID: 847 RVA: 0x00005195 File Offset: 0x00003395
		public void StopAudio()
		{
			this.audioManager.StopAudio(this.soundDropDown.captionText.text, this.ignoreFadeToggle);
		}

		// Token: 0x06000350 RID: 848 RVA: 0x000051BD File Offset: 0x000033BD
		public void StopAllAudio()
		{
			Debug.Log("Stopping all audio playback");
			this.audioManager.StopAllAudio(this.ignoreFadeToggle);
		}

		// Token: 0x040001C0 RID: 448
		public Dropdown eventDropDown;

		// Token: 0x040001C1 RID: 449
		public Dropdown soundDropDown;

		// Token: 0x040001C2 RID: 450
		public InputField eventIDInputField;

		// Token: 0x040001C3 RID: 451
		public Button startEventButton;

		// Token: 0x040001C4 RID: 452
		public Button stopEventButton;

		// Token: 0x040001C5 RID: 453
		public Button stopAllAudioButton;

		// Token: 0x040001C6 RID: 454
		public Toggle ignoreFadeToggle;

		// Token: 0x040001C7 RID: 455
		[Space]
		[Header("Make sure to drag in the S13AudioManager before use.")]
		public S13AudioManager audioManager;
	}
}
