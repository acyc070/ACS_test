using System;
using System.Collections;
using UnityEngine;

namespace S13Audio
{
	// Token: 0x02000049 RID: 73
	public class S13ObjectStartLoopStop : S13AudioSource
	{
		// Token: 0x17000041 RID: 65
		// (get) Token: 0x06000182 RID: 386 RVA: 0x0000246D File Offset: 0x0000066D
		public override float Length
		{
			get
			{
				return -1f;
			}
		}

		// Token: 0x06000183 RID: 387 RVA: 0x000261CC File Offset: 0x000243CC
		private void Awake()
		{
			this._audioSources = new AudioSource[3];
			AudioClip[] array = new AudioClip[] { this.startClip, this.loopClip, this.stopClip };
			int num = 0;
			foreach (AudioClip audioClip in array)
			{
				if (this.rolloffTemplate != null)
				{
					GameObject gameObject = base._addAudioSourceChild(string.Format("source{0}", num), this.rolloffTemplate.gameObject);
					this._audioSources[num] = gameObject.GetComponent<AudioSource>();
					this._audioSources[num].outputAudioMixerGroup = this.rolloffTemplate.outputAudioMixerGroup;
				}
				else
				{
					GameObject gameObject = base._addAudioSourceChild(string.Format("source{0}", num), null);
					this._audioSources[num] = gameObject.AddComponent<AudioSource>();
				}
				this._audioSources[num].clip = audioClip;
				this._audioSources[num].loop = false;
				if (this.outputOverride != null)
				{
					this._audioSources[num].outputAudioMixerGroup = this.outputOverride;
				}
				num++;
			}
			this._audioSources[1].loop = true;
			this.UpdateParameters();
		}

		// Token: 0x06000184 RID: 388 RVA: 0x00026308 File Offset: 0x00024508
		public override void Play()
		{
			float num = (float)this.chanceToPlay / 100f;
			if (!this._canPlay || global::UnityEngine.Random.value > num)
			{
				if (this.audioEndedHandler != null)
				{
					this.audioEndedHandler(this);
				}
				return;
			}
			this._isPlaying = true;
			if (this.fadeInTime <= 0f)
			{
				this._audioSources[0].Play();
				double num2 = AudioSettings.dspTime + (double)this._audioSources[0].clip.length;
				this._audioSources[1].PlayScheduled(num2);
				this._audioSources[1].SetScheduledStartTime(num2);
			}
			if (this._isPaused)
			{
				this._isPaused = false;
			}
			if (this.audioEndedHandler != null)
			{
				base.StartCoroutine(this.WaitForAudioEnd());
			}
		}

		// Token: 0x06000185 RID: 389 RVA: 0x000263DC File Offset: 0x000245DC
		public override void Stop(bool ignoreFade)
		{
			base.Stop(ignoreFade);
			this._isPlaying = false;
			if (this.fadeOutTime <= 0f || ignoreFade)
			{
				if (this._audioSources[0].isPlaying)
				{
					this._audioSources[1].Stop();
				}
				else if (this._audioSources[1].isPlaying)
				{
					this._audioSources[1].Stop();
					this._audioSources[2].Play();
				}
				else if (this._audioSources[2].isPlaying)
				{
					this._audioSources[2].Stop();
				}
			}
			if (this._isPaused)
			{
				this._isPaused = false;
			}
		}

		// Token: 0x06000186 RID: 390 RVA: 0x00026498 File Offset: 0x00024698
		public override void Pause(bool ignoreFade)
		{
			if (!this._isPlaying)
			{
				return;
			}
			this._isPaused = true;
			int num = 0;
			foreach (AudioSource audioSource in this._audioSources)
			{
				if (audioSource.isPlaying)
				{
					audioSource.Pause();
					this._pausedState = num;
					break;
				}
				num++;
			}
		}

		// Token: 0x06000187 RID: 391 RVA: 0x000264FC File Offset: 0x000246FC
		public override void Resume()
		{
			if (!this._isPaused)
			{
				Debug.LogWarning(base.name + ": Sound is not paused; cannot resume.", base.gameObject);
				return;
			}
			this._isPaused = false;
			int pausedState = this._pausedState;
			if (pausedState != 0)
			{
				if (pausedState != 1)
				{
					if (pausedState == 2)
					{
						this._audioSources[2].UnPause();
					}
				}
				else
				{
					this._audioSources[1].UnPause();
				}
			}
			else
			{
				double num = AudioSettings.dspTime + (double)this._audioSources[0].clip.length - (double)this._audioSources[0].time;
				this._audioSources[0].UnPause();
				this._audioSources[1].PlayScheduled(num);
				this._audioSources[1].SetScheduledStartTime(num);
			}
		}

		// Token: 0x06000188 RID: 392 RVA: 0x000265D4 File Offset: 0x000247D4
		public override void UpdateParameters()
		{
			base.UpdateParameters();
			foreach (AudioSource audioSource in this._audioSources)
			{
				audioSource.velocityUpdateMode = this.velocityUpdateMode;
			}
		}

		// Token: 0x06000189 RID: 393 RVA: 0x000030E2 File Offset: 0x000012E2
		public override void SetClip(AudioClip clip, int slotIndex = 0)
		{
			base.SetClip(clip, slotIndex);
			if (slotIndex == 0)
			{
				this.startClip = clip;
			}
			else if (slotIndex == 1)
			{
				this.loopClip = clip;
			}
			else if (slotIndex == 2)
			{
				this.stopClip = clip;
			}
		}

		// Token: 0x0600018A RID: 394 RVA: 0x0000311F File Offset: 0x0000131F
		public override void DrawGizmos()
		{
			if (this.rolloffTemplate != null)
			{
				Gizmos.color = S13AudioSource.DEFAULT_GIZMO_COLOR;
				Gizmos.DrawWireSphere(base.transform.position, this.rolloffTemplate.maxDistance);
			}
		}

		// Token: 0x0600018B RID: 395 RVA: 0x00026614 File Offset: 0x00024814
		private IEnumerator WaitForAudioEnd()
		{
			int clipIndex = 0;
			AudioSource playingAudio = this._audioSources[clipIndex];
			if (playingAudio == null || playingAudio.clip == null)
			{
				yield return null;
			}
			for (;;)
			{
				yield return base.StartCoroutine(S13AudioUtil.RealTimeWaitForSeconds(S13AudioSource.WAIT_FOR_AUDIO_END_UPDATE_FREQUENCY));
				if (playingAudio.timeSamples == 0 || playingAudio.timeSamples >= playingAudio.clip.samples)
				{
					if (clipIndex == this._audioSources.Length - 1)
					{
						break;
					}
					playingAudio = this._audioSources[++clipIndex];
				}
			}
			if (this.audioEndedHandler != null)
			{
				this.audioEndedHandler(this);
			}
			yield break;
		}

		// Token: 0x04000161 RID: 353
		public AudioClip startClip;

		// Token: 0x04000162 RID: 354
		public AudioClip loopClip;

		// Token: 0x04000163 RID: 355
		public AudioClip stopClip;

		// Token: 0x04000164 RID: 356
		public AudioSource rolloffTemplate;

		// Token: 0x04000165 RID: 357
		public AudioVelocityUpdateMode velocityUpdateMode;

		// Token: 0x04000166 RID: 358
		[AudioSlider("Fade-in time (s)", 0f, 60f)]
		public float fadeInTime;

		// Token: 0x04000167 RID: 359
		[AudioSlider("Fade-out time (s)", 0f, 60f)]
		public float fadeOutTime;

		// Token: 0x04000168 RID: 360
		[AudioSlider("Chance To Play (%)", 0, 100)]
		public int chanceToPlay = 100;

		// Token: 0x04000169 RID: 361
		private bool _isPlaying;

		// Token: 0x0400016A RID: 362
		private bool _canPlay = true;

		// Token: 0x0400016B RID: 363
		private int _pausedState;
	}
}
