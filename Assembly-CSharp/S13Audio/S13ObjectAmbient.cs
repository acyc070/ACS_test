using System;
using System.Collections;
using UnityEngine;

namespace S13Audio
{
	// Token: 0x02000031 RID: 49
	public class S13ObjectAmbient : S13AudioSource
	{
		// Token: 0x17000025 RID: 37
		// (get) Token: 0x060000E6 RID: 230 RVA: 0x00002C12 File Offset: 0x00000E12
		public override float Length
		{
			get
			{
				return this._audioSource.clip.length;
			}
		}

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x060000E7 RID: 231 RVA: 0x00002C24 File Offset: 0x00000E24
		public override int AudioSourceCount
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x060000E8 RID: 232 RVA: 0x000231BC File Offset: 0x000213BC
		public override bool IsPlaying
		{
			get
			{
				return (!(this._fadeControl != null) || !this._fadeControl.IsFadingOut) && !(this._audioSource == null) && this._audioSource.isPlaying;
			}
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x0002320C File Offset: 0x0002140C
		private void Awake()
		{
			this._audioSource = new AudioSource();
			GameObject gameObject;
			if (this.rolloffTemplate != null)
			{
				gameObject = base._addAudioSourceChild("source " + base.gameObject.name + ", " + this.rolloffTemplate.name, this.rolloffTemplate.gameObject);
				this._audioSource = gameObject.GetComponent<AudioSource>();
				this._audioSource.outputAudioMixerGroup = this.rolloffTemplate.outputAudioMixerGroup;
			}
			else
			{
				gameObject = base._addAudioSourceChild("source " + base.gameObject.name + ", default", null);
				this._audioSource = gameObject.AddComponent<AudioSource>();
			}
			this._fadeControl = gameObject.AddComponent<S13FadeControl>();
			this._fadeControl.Curve = this.fadeCurve;
			this.UpdateParameters();
			if (this.outputOverride != null)
			{
				this._audioSource.outputAudioMixerGroup = this.outputOverride;
			}
			if (this.audioClip != null)
			{
				this._offsetImpl = new S13OffsetImpl((int)(this.offsetTime * (float)this.audioClip.frequency));
			}
		}

		// Token: 0x060000EA RID: 234 RVA: 0x00002C27 File Offset: 0x00000E27
		private void OnEnable()
		{
			this._audioSource.enabled = true;
			if (this.playOnAwake)
			{
				this.Play();
			}
		}

		// Token: 0x060000EB RID: 235 RVA: 0x00002C46 File Offset: 0x00000E46
		private void OnDisable()
		{
			this._audioSource.enabled = false;
		}

		// Token: 0x060000EC RID: 236 RVA: 0x00023338 File Offset: 0x00021538
		public override void Play()
		{
			if (this.IsPlaying)
			{
				return;
			}
			if (!this._audioSource)
			{
				Debug.LogWarning("[S13Audio] - Yo, your audio source is null, you're about to hit some serious errors.");
				return;
			}
			if (this.chanceToPlay < 100)
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
			}
			if (this._isPaused)
			{
				this._isPaused = false;
			}
			if (this.fadeInTime > 0f)
			{
				this._offsetImpl.SetPlayPosition(this._audioSource, this.startRandom);
				this._audioSource.Play();
				this._fadeControl.FadeIn(this._audioSource, this._audioSource.volume, S13AudioUtil.dB2Lin(this.volume), this.fadeInTime, this.ignoreTimeScale, null);
			}
			else
			{
				this._audioSource.volume = S13AudioUtil.dB2Lin(this.volume);
				this._offsetImpl.SetPlayPosition(this._audioSource, this.startRandom);
				if (this.timelineOffset == 0)
				{
					this._audioSource.Play();
				}
				else
				{
					this._audioSource.PlayScheduled(AudioSettings.dspTime + (double)((float)this.timelineOffset / 1000f));
				}
			}
			if (this.retriggerTime > 0)
			{
				base.StartCoroutine(this.TriggerWait());
			}
			if (this.audioEndedHandler != null)
			{
				base.StartCoroutine(this.WaitForAudioEnd());
			}
		}

		// Token: 0x060000ED RID: 237 RVA: 0x000234CC File Offset: 0x000216CC
		public override void Stop(bool ignoreFade)
		{
			if (!this.IsPlaying)
			{
				return;
			}
			this._isPaused = false;
			if (this._audioSource.isPlaying)
			{
				if (this.fadeOutTime > 0f && !ignoreFade)
				{
					this._fadeControl.FadeOut(this._audioSource, this._audioSource.volume, this.fadeOutTime, this.ignoreTimeScale, delegate
					{
						this._audioSource.Stop();
					});
				}
				else
				{
					this._audioSource.Stop();
					this._audioSource.volume = 0f;
				}
			}
			this._isPaused = false;
		}

		// Token: 0x060000EE RID: 238 RVA: 0x00023570 File Offset: 0x00021770
		public override void Pause(bool ignoreFade)
		{
			if (this.IsPlaying)
			{
				if (this.fadeOutTime > 0f && !ignoreFade)
				{
					this._fadeControl.FadeOut(this._audioSource, this._audioSource.volume, this.fadeOutTime, this.ignoreTimeScale, delegate
					{
						this._audioSource.Pause();
					});
				}
				else
				{
					this._audioSource.Pause();
				}
				this._isPaused = true;
			}
		}

		// Token: 0x060000EF RID: 239 RVA: 0x000235EC File Offset: 0x000217EC
		public override void Resume()
		{
			if (!this._isPaused)
			{
				Debug.LogWarning(base.name + ": Sound is not paused; cannot resume.", base.gameObject);
				return;
			}
			base.StopAllCoroutines();
			if (this._isPaused)
			{
				this._audioSource.UnPause();
				if (this.fadeInTime > 0f)
				{
					this._fadeControl.FadeIn(this._audioSource, 0f, S13AudioUtil.dB2Lin(this.volume), this.fadeInTime, this.ignoreTimeScale, null);
				}
				this._isPaused = false;
			}
			if (this.audioEndedHandler != null)
			{
				base.StartCoroutine(this.WaitForAudioEnd());
			}
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x0002369C File Offset: 0x0002189C
		public override void SetClip(AudioClip clip, int slotIndex = 0)
		{
			if (this._audioSource.isPlaying)
			{
				this._audioSource.time = 0f;
			}
			this._audioSource.clip = clip;
			this._offsetImpl = new S13OffsetImpl((int)(this.offsetTime * (float)clip.frequency));
			this.audioClip = clip;
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x00002C54 File Offset: 0x00000E54
		public override void SetMuting(bool muting)
		{
			if (muting == !this.mute)
			{
				return;
			}
			this.mute = !muting;
			this._audioSource.mute = this.mute;
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x000236F8 File Offset: 0x000218F8
		public override void UpdateParameters()
		{
			this._audioSource.playOnAwake = false;
			this._audioSource.clip = this.audioClip;
			this._audioSource.loop = this.loop;
			this._audioSource.volume = 0f;
			this._audioSource.mute = this.mute;
			this._audioSource.panStereo = this.pan;
			this._audioSource.velocityUpdateMode = AudioVelocityUpdateMode.Auto;
			if (this.enableRandomPitch)
			{
				this._audioSource.pitch = S13AudioUtil.SemitoneToPitch((float)global::UnityEngine.Random.Range(this.pitchMin, this.pitchMax));
			}
			else
			{
				this._audioSource.pitch = S13AudioUtil.SemitoneToPitch(this.pitch);
			}
		}

		// Token: 0x060000F3 RID: 243 RVA: 0x00002C81 File Offset: 0x00000E81
		public override void DrawGizmos()
		{
			if (this.rolloffTemplate != null)
			{
				Gizmos.color = S13AudioSource.DEFAULT_GIZMO_COLOR;
				Gizmos.DrawWireSphere(base.transform.position, this.rolloffTemplate.maxDistance);
			}
		}

		// Token: 0x060000F4 RID: 244 RVA: 0x000237BC File Offset: 0x000219BC
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

		// Token: 0x060000F5 RID: 245 RVA: 0x000237D8 File Offset: 0x000219D8
		private IEnumerator WaitForAudioEnd()
		{
			if (this._audioSource == null || this._audioSource.clip == null)
			{
				yield return null;
			}
			do
			{
				yield return base.StartCoroutine(S13AudioUtil.RealTimeWaitForSeconds(S13AudioSource.WAIT_FOR_AUDIO_END_UPDATE_FREQUENCY));
			}
			while (this._audioSource.timeSamples != 0 && this._audioSource.timeSamples < this._audioSource.clip.samples);
			if (this.audioEndedHandler != null)
			{
				this.audioEndedHandler(this);
			}
			yield break;
		}

		// Token: 0x040000C9 RID: 201
		public AudioClip audioClip;

		// Token: 0x040000CA RID: 202
		public AudioSource rolloffTemplate;

		// Token: 0x040000CB RID: 203
		[AudioSlider("Fade-in time (s)", 0f, 60f)]
		public float fadeInTime = 1f;

		// Token: 0x040000CC RID: 204
		[AudioSlider("Fade-out time (s)", 0f, 60f)]
		public float fadeOutTime = 1f;

		// Token: 0x040000CD RID: 205
		public AnimationCurve fadeCurve;

		// Token: 0x040000CE RID: 206
		public bool enableRandomPitch = true;

		// Token: 0x040000CF RID: 207
		[AudioSlider("Random Pitch Min (semi)", -12, 12)]
		public int pitchMin;

		// Token: 0x040000D0 RID: 208
		[AudioSlider("Random Pitch Max (semi)", -12, 12)]
		public int pitchMax;

		// Token: 0x040000D1 RID: 209
		[AudioSlider("Replay Gate Time (ms)", 0, 1000)]
		public int retriggerTime;

		// Token: 0x040000D2 RID: 210
		[AudioSlider("Chance To Play (%)", 0, 100)]
		public int chanceToPlay = 100;

		// Token: 0x040000D3 RID: 211
		private AudioSource _audioSource;

		// Token: 0x040000D4 RID: 212
		private S13FadeControl _fadeControl;

		// Token: 0x040000D5 RID: 213
		private bool _canPlay = true;
	}
}
