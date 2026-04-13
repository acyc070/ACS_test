using System;
using System.Collections.Generic;
using UnityEngine;

namespace S13Audio
{
	// Token: 0x0200002F RID: 47
	public class S13VoicesImpl
	{
		// Token: 0x060000DB RID: 219 RVA: 0x00002B92 File Offset: 0x00000D92
		public S13VoicesImpl(VoiceMode voiceMode, AudioSource[] audioSources, int maxVoices)
		{
			this._audioSources = audioSources;
			this.VoiceMode = voiceMode;
			this._maxVoices = maxVoices;
			this._clipVoices = Mathf.CeilToInt((float)maxVoices / (float)audioSources.Length);
			this._activeSounds = new List<AudioSource>(maxVoices);
		}

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x060000DC RID: 220 RVA: 0x00002BCD File Offset: 0x00000DCD
		// (set) Token: 0x060000DD RID: 221 RVA: 0x00002BD5 File Offset: 0x00000DD5
		public VoiceMode VoiceMode { get; set; }

		// Token: 0x060000DE RID: 222 RVA: 0x00022FCC File Offset: 0x000211CC
		public void Play(int soundIndex, S13VoicesImpl.PlayDelegate play)
		{
			if (this._audioSources == null || this._audioSources.Length == 0)
			{
				Debug.LogWarning("VoicesImpl: Reference to audio sources is null or empty; cannot play.");
				return;
			}
			VoiceMode voiceMode = this.VoiceMode;
			if (voiceMode != VoiceMode.KillOld)
			{
				if (voiceMode == VoiceMode.IgnoreNew)
				{
					if (this._activeSounds.Count < this._maxVoices)
					{
						int num = soundIndex * this._clipVoices + Mathf.FloorToInt((float)(this._activeSounds.Count / this._audioSources.Length));
						play(num);
						this._activeSounds.Add(this._audioSources[num]);
					}
				}
			}
			else
			{
				if (this._activeSounds.Count >= this._maxVoices)
				{
					AudioSource audioSource = this._activeSounds[0];
					this._activeSounds.RemoveAt(0);
					audioSource.Stop();
				}
				int num = soundIndex * this._clipVoices + Mathf.FloorToInt((float)(this._activeSounds.Count / this._audioSources.Length));
				play(num);
				this._activeSounds.Add(this._audioSources[num]);
			}
		}

		// Token: 0x060000DF RID: 223 RVA: 0x000230E8 File Offset: 0x000212E8
		public void Update()
		{
			for (int i = 0; i < this._activeSounds.Count; i++)
			{
				if (!this._activeSounds[i].isPlaying)
				{
					this._activeSounds.RemoveAt(i);
				}
			}
		}

		// Token: 0x060000E0 RID: 224 RVA: 0x00023134 File Offset: 0x00021334
		private void LogActiveSounds()
		{
			Debug.Log("** Active sounds list:");
			foreach (AudioSource audioSource in this._activeSounds)
			{
				Debug.Log(audioSource.name + " at index " + this._activeSounds.IndexOf(audioSource));
			}
		}

		// Token: 0x040000C5 RID: 197
		private AudioSource[] _audioSources;

		// Token: 0x040000C6 RID: 198
		private List<AudioSource> _activeSounds;

		// Token: 0x040000C7 RID: 199
		private int _maxVoices;

		// Token: 0x040000C8 RID: 200
		private int _clipVoices;

		// Token: 0x02000030 RID: 48
		// (Invoke) Token: 0x060000E2 RID: 226
		public delegate void PlayDelegate(int voiceIndex);
	}
}
