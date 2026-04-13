using System;
using System.Collections;
using UnityEngine;

namespace S13Audio
{
	// Token: 0x02000044 RID: 68
	public class S13ObjectSimple : S13AudioSource
	{
		// Token: 0x1700003C RID: 60
		// (get) Token: 0x06000163 RID: 355 RVA: 0x00002FCC File Offset: 0x000011CC
		public override float Length
		{
			get
			{
				return (!this.loop) ? this._audioSources[0].clip.length : (-1f);
			}
		}

		// Token: 0x06000164 RID: 356 RVA: 0x000258F8 File Offset: 0x00023AF8
		private void Awake()
		{
			this._audioSources = new AudioSource[this.voices];
			this._isVoicePaused = new bool[this.voices];
			for (int i = 0; i < this.voices; i++)
			{
				if (this.rolloffTemplate != null)
				{
					GameObject gameObject = base._addAudioSourceChild(string.Format("source{0}", i), this.rolloffTemplate.gameObject);
					this._audioSources[i] = gameObject.GetComponent<AudioSource>();
					this._audioSources[i].outputAudioMixerGroup = this.rolloffTemplate.outputAudioMixerGroup;
				}
				else
				{
					GameObject gameObject = base._addAudioSourceChild(string.Format("source{0}", i), null);
					this._audioSources[i] = gameObject.AddComponent<AudioSource>();
				}
				this._audioSources[i].playOnAwake = false;
				this._audioSources[i].clip = this.audioClip;
				this._audioSources[i].loop = this.loop;
				if (this.outputOverride != null)
				{
					this._audioSources[i].outputAudioMixerGroup = this.outputOverride;
				}
				this._isVoicePaused[i] = false;
			}
			this.UpdateParameters();
			if (this.audioClip != null)
			{
				this._offsetImpl = new S13OffsetImpl((int)(this.offsetTime * (float)this.audioClip.frequency));
			}
			this._voicesImpl = new S13VoicesImpl(this.voiceMode, this._audioSources, this.voices);
			this._soundIndex = 0;
		}

		// Token: 0x06000165 RID: 357 RVA: 0x00002FF5 File Offset: 0x000011F5
		private void LateUpdate()
		{
			this._voicesImpl.Update();
		}

		// Token: 0x06000166 RID: 358 RVA: 0x00025A80 File Offset: 0x00023C80
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
			if (this._isPaused)
			{
				this._isPaused = false;
				for (int i = 0; i < this._audioSources.Length; i++)
				{
					this._isVoicePaused[i] = false;
				}
			}
			if (this.fadeInTime > 0f)
			{
				this._voicesImpl.Play(this._soundIndex, delegate(int voiceIndex)
				{
					AudioSource audioSource = this._audioSources[voiceIndex];
					if (this.enableRandomPitch)
					{
						audioSource.pitch = S13AudioUtil.SemitoneToPitch((float)global::UnityEngine.Random.Range(this.pitchMin, this.pitchMax));
					}
					this._offsetImpl.SetPlayPosition(audioSource, this.startRandom);
					audioSource.Play();
					base.StartCoroutine(S13AudioUtil.FadeIn(audioSource, this.fadeInTime, S13AudioUtil.dB2Lin(this.volume), this.ignoreTimeScale, null));
				});
			}
			else
			{
				if (this._voicesImpl == null)
				{
					Debug.LogWarning("Missing Audio Reference.", base.gameObject);
					return;
				}
				this._voicesImpl.Play(this._soundIndex, delegate(int voiceIndex)
				{
					AudioSource audioSource2 = this._audioSources[voiceIndex];
					if (this.enableRandomPitch)
					{
						audioSource2.pitch = S13AudioUtil.SemitoneToPitch((float)global::UnityEngine.Random.Range(this.pitchMin, this.pitchMax));
					}
					if (!this.usesExternalVolume)
					{
						audioSource2.volume = S13AudioUtil.dB2Lin(this.volume);
					}
					this._offsetImpl.SetPlayPosition(audioSource2, this.startRandom);
					if (this.timelineOffset == 0)
					{
						audioSource2.Play();
					}
					else
					{
						audioSource2.PlayScheduled(AudioSettings.dspTime + (double)((float)this.timelineOffset / 1000f));
					}
				});
			}
			this._soundIndex = ((++this._soundIndex < this.voices) ? this._soundIndex : 0);
			if (this.retriggerTime > 0)
			{
				base.StartCoroutine(this.TriggerWait());
			}
			if (this.audioEndedHandler != null)
			{
				base.StartCoroutine(this.WaitForAudioEnd());
			}
		}

		// Token: 0x06000167 RID: 359 RVA: 0x00025BC8 File Offset: 0x00023DC8
		public override void Stop(bool ignoreFade)
		{
			base.Stop(ignoreFade);
			this._isPaused = false;
			for (int i = 0; i < this._audioSources.Length; i++)
			{
				AudioSource source = this._audioSources[i];
				if (source.isPlaying)
				{
					if (this.fadeOutTime > 0f && !ignoreFade)
					{
						base.StartCoroutine(S13AudioUtil.FadeOut(source, this.fadeOutTime, S13AudioUtil.dB2Lin(this.volume), this.ignoreTimeScale, delegate
						{
							source.Stop();
							source.volume = S13AudioUtil.dB2Lin(this.volume);
						}));
					}
					else
					{
						source.Stop();
					}
				}
				this._isVoicePaused[i] = false;
			}
		}

		// Token: 0x06000168 RID: 360 RVA: 0x00025C8C File Offset: 0x00023E8C
		public override void Pause(bool ignoreFade)
		{
			for (int i = 0; i < this._audioSources.Length; i++)
			{
				AudioSource source = this._audioSources[i];
				if (source.isPlaying)
				{
					if (this.fadeOutTime > 0f && !ignoreFade)
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
					this._isVoicePaused[i] = true;
					this._isPaused = true;
				}
			}
		}

		// Token: 0x06000169 RID: 361 RVA: 0x00025D48 File Offset: 0x00023F48
		public override void Resume()
		{
			if (!this._isPaused)
			{
				Debug.LogWarning(base.name + ": Sound is not paused; cannot resume.", base.gameObject);
				return;
			}
			base.StopAllCoroutines();
			for (int i = 0; i < this._audioSources.Length; i++)
			{
				AudioSource audioSource = this._audioSources[i];
				if (this._isVoicePaused[i])
				{
					audioSource.UnPause();
					if (this.fadeInTime > 0f)
					{
						base.StartCoroutine(S13AudioUtil.FadeIn(audioSource, this.fadeInTime, S13AudioUtil.dB2Lin(this.volume), this.ignoreTimeScale, null));
					}
					this._isPaused = false;
					this._isVoicePaused[i] = false;
				}
			}
			if (this.audioEndedHandler != null)
			{
				base.StartCoroutine(this.WaitForAudioEnd());
			}
		}

		// Token: 0x0600016A RID: 362 RVA: 0x00025E14 File Offset: 0x00024014
		public override void UpdateParameters()
		{
			base.UpdateParameters();
			foreach (AudioSource audioSource in this._audioSources)
			{
				audioSource.velocityUpdateMode = this.velocityUpdateMode;
			}
		}

		// Token: 0x0600016B RID: 363 RVA: 0x00003002 File Offset: 0x00001202
		public override void SetClip(AudioClip clip, int slotIndex = 0)
		{
			base.SetClip(clip, slotIndex);
			this.audioClip = clip;
		}

		// Token: 0x0600016C RID: 364 RVA: 0x00003013 File Offset: 0x00001213
		public override void DrawGizmos()
		{
			if (this.rolloffTemplate != null)
			{
				Gizmos.color = S13AudioSource.DEFAULT_GIZMO_COLOR;
				Gizmos.DrawWireSphere(base.transform.position, this.rolloffTemplate.maxDistance);
			}
		}

		// Token: 0x0600016D RID: 365 RVA: 0x00025E54 File Offset: 0x00024054
		private IEnumerator TriggerWait()
		{
			this._canPlay = false;
			if (this.ignoreTimeScale)
			{
				yield return base.StartCoroutine(S13AudioUtil.RealTimeWaitForSeconds((float)this.retriggerTime / 1000f));
			}
			else
			{
				yield return new WaitForSeconds((float)this.retriggerTime / 1000f);
			}
			this._canPlay = true;
			yield break;
		}

		// Token: 0x0600016E RID: 366 RVA: 0x00025E70 File Offset: 0x00024070
		private IEnumerator WaitForAudioEnd()
		{
			if (this._audioSources.Length > 1)
			{
				Debug.LogError(base.name + ": Assigning callback to audio source with more than one voice has undefined behavior.");
			}
			AudioSource playingAudio = this._audioSources[0];
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

		// Token: 0x04000143 RID: 323
		public AudioClip audioClip;

		// Token: 0x04000144 RID: 324
		[AudioField("Voice Max", 1, 50)]
		public int voices = 1;

		// Token: 0x04000145 RID: 325
		public VoiceMode voiceMode;

		// Token: 0x04000146 RID: 326
		public AudioSource rolloffTemplate;

		// Token: 0x04000147 RID: 327
		public AudioVelocityUpdateMode velocityUpdateMode;

		// Token: 0x04000148 RID: 328
		public bool usesExternalVolume;

		// Token: 0x04000149 RID: 329
		[AudioSlider("Fade-in time (s)", 0f, 60f)]
		public float fadeInTime = 1f;

		// Token: 0x0400014A RID: 330
		[AudioSlider("Fade-out time (s)", 0f, 60f)]
		public float fadeOutTime = 1f;

		// Token: 0x0400014B RID: 331
		public bool enableRandomPitch = true;

		// Token: 0x0400014C RID: 332
		[AudioSlider("Random Pitch Min (semi)", -12, 12)]
		public int pitchMin;

		// Token: 0x0400014D RID: 333
		[AudioSlider("Random Pitch Max (semi)", -12, 12)]
		public int pitchMax;

		// Token: 0x0400014E RID: 334
		[AudioSlider("Replay Gate Time (ms)", 0, 1000)]
		public int retriggerTime;

		// Token: 0x0400014F RID: 335
		[AudioSlider("Chance To Play (%)", 0, 100)]
		public int chanceToPlay = 100;

		// Token: 0x04000150 RID: 336
		private S13VoicesImpl _voicesImpl;

		// Token: 0x04000151 RID: 337
		private int _soundIndex;

		// Token: 0x04000152 RID: 338
		private bool _canPlay = true;

		// Token: 0x04000153 RID: 339
		private bool[] _isVoicePaused;
	}
}
