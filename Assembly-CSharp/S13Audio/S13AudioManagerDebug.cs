using System;
using UnityEngine;

namespace S13Audio
{
	// Token: 0x02000056 RID: 86
	public class S13AudioManagerDebug : MonoBehaviour
	{
		// Token: 0x0600033D RID: 829 RVA: 0x000050D5 File Offset: 0x000032D5
		private void Awake()
		{
			this.controlsArea = new Rect(20f, 20f, 400f, 280f);
		}

		// Token: 0x0600033E RID: 830 RVA: 0x000050F6 File Offset: 0x000032F6
		private void Start()
		{
			this.audioManager = base.GetComponentInParent<S13AudioManager>();
			if (this.audioManager == null)
			{
				Debug.LogError(base.name + ": Could not find AudioManager component on parent game object.");
			}
		}

		// Token: 0x0600033F RID: 831 RVA: 0x0002A324 File Offset: 0x00028524
		private void OnGUI()
		{
			GUILayout.BeginArea(this.controlsArea, "Audio Manager Debug");
			GUILayout.Space(40f);
			GUILayout.Label("Sound ID or Event name:", new GUILayoutOption[0]);
			this.soundId = GUILayout.TextField(this.soundId, 128, new GUILayoutOption[0]);
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			if (GUILayout.Button("Play Audio", new GUILayoutOption[0]))
			{
				this.audioManager.PlayAudio(this.soundId);
			}
			if (GUILayout.Button("Stop Audio", new GUILayoutOption[0]))
			{
				this.audioManager.StopAudio(this.soundId, false);
			}
			GUILayout.EndHorizontal();
			if (GUILayout.Button("Invoke Event", new GUILayoutOption[0]))
			{
				this.audioManager.InvokeEvent(this.soundId, 0f);
			}
			if (GUILayout.Button("Stop All Audio", new GUILayoutOption[0]))
			{
				this.audioManager.StopAllAudio(false);
			}
			GUILayout.EndArea();
		}

		// Token: 0x040001AF RID: 431
		private S13AudioManager audioManager;

		// Token: 0x040001B0 RID: 432
		private string soundId = string.Empty;

		// Token: 0x040001B1 RID: 433
		private Rect controlsArea;
	}
}
