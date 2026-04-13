using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

namespace S13Audio
{
	// Token: 0x0200003D RID: 61
	public class S13ObjectLoopSwitch : S13AudioSource
	{
		// Token: 0x17000036 RID: 54
		// (get) Token: 0x0600013C RID: 316 RVA: 0x00002E83 File Offset: 0x00001083
		public override float Length
		{
			get
			{
				return (!this.loop) ? this._audioSources[this._currentSegment].clip.length : (-1f);
			}
		}

		// Token: 0x0600013D RID: 317 RVA: 0x00024B4C File Offset: 0x00022D4C
		private void Awake()
		{
			this._audioSources = new AudioSource[this.audioSegments.Length];
			int num = 0;
			foreach (AudioClip audioClip in this.audioSegments)
			{
				GameObject gameObject = base._addAudioSourceChild(string.Format("source{0}", num), null);
				this._audioSources[num] = gameObject.AddComponent<AudioSource>();
				this._audioSources[num].clip = audioClip;
				this._audioSources[num].loop = this.loop;
				this._audioSources[num].outputAudioMixerGroup = this.mixerOutput;
				num++;
			}
			this.UpdateParameters();
			this._resumeOnPlay = new S13ResumeImpl(this.audioSegments.Length);
			if (this.audioSegments[0] != null)
			{
				this._offsetImpl = new S13OffsetImpl((int)(this.offsetTime * (float)this.audioSegments[0].frequency));
			}
			this._currentSegment = 0;
		}

		// Token: 0x0600013E RID: 318 RVA: 0x00024C44 File Offset: 0x00022E44
		public override void Play()
		{
			if (this.resumeOnPlay)
			{
				this._resumeOnPlay.ResumePosition(this._audioSources[this._currentSegment], this._currentSegment);
			}
			else if (this._offsetImpl != null)
			{
				this._offsetImpl.SetPlayPosition(this._audioSources[this._currentSegment], this.startRandom);
			}
			if (this.fadeInTime > 0f)
			{
				this._audioSources[this._currentSegment].Play();
				base.StartCoroutine(S13AudioUtil.FadeIn(this._audioSources[this._currentSegment], this.fadeInTime, S13AudioUtil.dB2Lin(this.volume), this.ignoreTimeScale, null));
			}
			else if (this.timelineOffset == 0)
			{
				this._audioSources[this._currentSegment].Play();
			}
			else
			{
				this._audioSources[this._currentSegment].PlayScheduled(AudioSettings.dspTime + (double)((float)this.timelineOffset / 1000f));
			}
			if (this.audioEndedHandler != null)
			{
				base.StartCoroutine(this.WaitForAudioEnd());
			}
		}

		// Token: 0x0600013F RID: 319 RVA: 0x00024D60 File Offset: 0x00022F60
		public override void Stop(bool ignoreFade)
		{
			base.Stop(ignoreFade);
			if (this.resumeOnPlay)
			{
				this._resumeOnPlay.SavePosition(this._audioSources[this._currentSegment], this._currentSegment);
			}
			AudioSource[] audioSources = this._audioSources;
			for (int i = 0; i < audioSources.Length; i++)
			{
				AudioSource source = audioSources[i];
				S13ObjectLoopSwitch $this = this;
				if (source.isPlaying)
				{
					if (this.fadeOutTime > 0f && !ignoreFade)
					{
						base.StartCoroutine(S13AudioUtil.FadeOut(source, this.fadeOutTime, S13AudioUtil.dB2Lin(this.volume), this.ignoreTimeScale, delegate
						{
							if ($this.resumeOnPlay)
							{
								source.Pause();
							}
							else
							{
								source.Stop();
							}
							source.volume = S13AudioUtil.dB2Lin($this.volume);
						}));
					}
					else if (this.resumeOnPlay)
					{
						source.Pause();
					}
					else
					{
						source.Stop();
					}
				}
			}
		}

		// Token: 0x06000140 RID: 320 RVA: 0x00024E54 File Offset: 0x00023054
		public override void Pause(bool ignoreFadeOut)
		{
			AudioSource source = this._audioSources[this._currentSegment];
			if (source.isPlaying)
			{
				if (this.fadeOutTime > 0f && !ignoreFadeOut)
				{
					base.StartCoroutine(S13AudioUtil.FadeOut(source, this.fadeOutTime, S13AudioUtil.dB2Lin(this.volume), this.ignoreTimeScale, delegate
					{
						source.Pause();
						source.volume = S13AudioUtil.dB2Lin(this.volume);
					}));
				}
				else
				{
					source.Pause();
				}
			}
			this._isPaused = true;
		}

		// Token: 0x06000141 RID: 321 RVA: 0x00024EF4 File Offset: 0x000230F4
		public override void Resume()
		{
			if (!this._isPaused)
			{
				Debug.LogWarning(base.name + ": Sound is not paused; cannot resume.", base.gameObject);
				return;
			}
			base.StopAllCoroutines();
			AudioSource audioSource = this._audioSources[this._currentSegment];
			audioSource.UnPause();
			if (this.fadeInTime > 0f)
			{
				base.StartCoroutine(S13AudioUtil.FadeIn(audioSource, this.fadeInTime, S13AudioUtil.dB2Lin(this.volume), this.ignoreTimeScale, null));
			}
			this._isPaused = false;
			if (this.audioEndedHandler != null)
			{
				base.StartCoroutine(this.WaitForAudioEnd());
			}
		}

		// Token: 0x06000142 RID: 322 RVA: 0x00002EB1 File Offset: 0x000010B1
		public override void SetClip(AudioClip clip, int slotIndex = 0)
		{
			base.SetClip(clip, slotIndex);
			this.audioSegments[slotIndex] = clip;
		}

		// Token: 0x06000143 RID: 323 RVA: 0x00024F98 File Offset: 0x00023198
		public void TransitionToSegment(int toSegment)
		{
			if (this._audioSources[this._currentSegment].isPlaying && this._currentSegment != toSegment)
			{
				if (this.resumeOnPlay)
				{
					this._resumeOnPlay.ResumePosition(this._audioSources[toSegment], toSegment);
					this._resumeOnPlay.SavePosition(this._audioSources[this._currentSegment], this._currentSegment);
				}
				base.StartCoroutine(S13AudioUtil.FadeIn(this._audioSources[toSegment], this.transitionTime, S13AudioUtil.dB2Lin(this.volume), this.ignoreTimeScale, null));
				base.StartCoroutine(S13AudioUtil.FadeOut(this._audioSources[this._currentSegment], this.transitionTime, S13AudioUtil.dB2Lin(this.volume), this.ignoreTimeScale, delegate
				{
					this._currentSegment = toSegment;
				}));
			}
		}

		// Token: 0x06000144 RID: 324 RVA: 0x00025098 File Offset: 0x00023298
		private IEnumerator WaitForAudioEnd()
		{
			AudioSource playingAudio = this._audioSources[this._currentSegment];
			if (playingAudio == null || playingAudio.clip == null)
			{
				yield return null;
			}
			do
			{
				yield return base.StartCoroutine(S13AudioUtil.RealTimeWaitForSeconds(S13AudioSource.WAIT_FOR_AUDIO_END_UPDATE_FREQUENCY));
			}
			while (playingAudio.timeSamples != 0 && playingAudio.timeSamples < playingAudio.clip.samples);
			if (this.audioEndedHandler != null)
			{
				this.audioEndedHandler(this);
			}
			yield break;
		}

		// Token: 0x0400011F RID: 287
		public AudioMixerGroup mixerOutput;

		// Token: 0x04000120 RID: 288
		public AudioClip[] audioSegments;

		// Token: 0x04000121 RID: 289
		[AudioSlider("Fade-in time (s)", 0f, 60f)]
		public float fadeInTime = 1f;

		// Token: 0x04000122 RID: 290
		[AudioSlider("Fade-out time (s)", 0f, 60f)]
		public float fadeOutTime = 1f;

		// Token: 0x04000123 RID: 291
		[AudioSlider("Transition time (s)", 0f, 60f)]
		public float transitionTime = 1f;

		// Token: 0x04000124 RID: 292
		public bool resumeOnPlay;

		// Token: 0x04000125 RID: 293
		private int _currentSegment;
	}
}
