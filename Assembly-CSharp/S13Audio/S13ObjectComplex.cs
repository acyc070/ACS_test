using System;
using System.Collections;
using UnityEngine;

namespace S13Audio
{
	// Token: 0x02000034 RID: 52
	public class S13ObjectComplex : S13AudioSource
	{
		// Token: 0x1700002C RID: 44
		// (get) Token: 0x06000105 RID: 261 RVA: 0x0000246D File Offset: 0x0000066D
		public override float Length
		{
			get
			{
				return -1f;
			}
		}

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x06000106 RID: 262 RVA: 0x00002D3E File Offset: 0x00000F3E
		public override bool IsPlaying
		{
			get
			{
				return base.IsPlaying || (this._isPlaying && this._isLooping) || this._isFadingOut;
			}
		}

		// Token: 0x06000107 RID: 263 RVA: 0x000239F4 File Offset: 0x00021BF4
		private void Awake()
		{
			int num = this.voices / this.audioClips.Length + 1;
			this._audioSources = new AudioSource[this.audioClips.Length * num];
			this._isVoicePaused = new bool[this._audioSources.Length];
			int num2 = 0;
			foreach (AudioClip audioClip in this.audioClips)
			{
				for (int j = 0; j < num; j++)
				{
					int num3 = num2 * num + j;
					if (this.rolloffTemplate != null)
					{
						GameObject gameObject = base._addAudioSourceChild(string.Format("source{0}-{1}", num2, j), this.rolloffTemplate.gameObject);
						this._audioSources[num3] = gameObject.GetComponent<AudioSource>();
						this._audioSources[num3].outputAudioMixerGroup = this.rolloffTemplate.outputAudioMixerGroup;
					}
					else
					{
						GameObject gameObject = base._addAudioSourceChild(string.Format("source{0}-{1}", num2, j), null);
						this._audioSources[num3] = gameObject.AddComponent<AudioSource>();
					}
					this._audioSources[num3].clip = audioClip;
					this._audioSources[num3].loop = false;
					if (this.outputOverride != null)
					{
						this._audioSources[num3].outputAudioMixerGroup = this.outputOverride;
					}
					this._isVoicePaused[num3] = false;
				}
				num2++;
			}
			this.UpdateParameters();
			if (this.audioClips[0] != null)
			{
				this._offsetImpl = new S13OffsetImpl((int)(this.offsetTime * (float)this.audioClips[0].frequency));
			}
			this._voicesImpl = new S13VoicesImpl(this.voiceMode, this._audioSources, this.voices);
			this._shuffleImpl = new S13ShuffleImpl(new S13Range(0, this.audioClips.Length - 1), true, true);
		}

		// Token: 0x06000108 RID: 264 RVA: 0x00002D6A File Offset: 0x00000F6A
		private void LateUpdate()
		{
			this._voicesImpl.Update();
		}

		// Token: 0x06000109 RID: 265 RVA: 0x00023BE0 File Offset: 0x00021DE0
		public override void Play()
		{
			if (!this._canPlay)
			{
				if (this.audioEndedHandler != null)
				{
					this.audioEndedHandler(this);
				}
				return;
			}
			this._isPlaying = true;
			if (this.loop)
			{
				if (this._isFadingOut)
				{
					base.StopAllCoroutines();
				}
				if (base.transform.parent.gameObject && !base.transform.parent.gameObject.activeSelf)
				{
					base.transform.parent.gameObject.SetActive(true);
				}
				base.StartCoroutine(this.RandomLoop());
				if (this.fadeInTime > 0f)
				{
					base.StartCoroutine(this.FadeAudioSources(this.fadeInTime, 0f, S13AudioUtil.dB2Lin(this.volume), null));
				}
			}
			else
			{
				float num = (float)this.chanceToPlay / 100f;
				if (global::UnityEngine.Random.value > num)
				{
					if (this.audioEndedHandler != null)
					{
						this.audioEndedHandler(this);
					}
					return;
				}
				int num2 = this._shuffleImpl.Next(true);
				if (this.fadeInTime > 0f)
				{
					this._voicesImpl.Play(num2, delegate(int voiceIndex)
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
					this._voicesImpl.Play(num2, delegate(int voiceIndex)
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
						this._offsetImpl.SetPlayPosition(this._audioSources[voiceIndex], this.startRandom);
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
			}
			if (this.retriggerTime > 0)
			{
				base.StartCoroutine(this.TriggerWait());
			}
			if (this.audioEndedHandler != null && !this._waitForAudioEndLock)
			{
				base.StartCoroutine(this.WaitForAudioEnd());
			}
			if (this._isPaused)
			{
				this._isPaused = false;
				for (int i = 0; i < this._audioSources.Length; i++)
				{
					this._isVoicePaused[i] = false;
				}
			}
		}

		// Token: 0x0600010A RID: 266 RVA: 0x00023DB8 File Offset: 0x00021FB8
		public override void Stop(bool ignoreFade)
		{
			base.Stop(ignoreFade);
			this._isPlaying = false;
			if (this.loop)
			{
				if (this.fadeOutTime > 0f && !ignoreFade)
				{
					this._isFadingOut = true;
					base.StartCoroutine(this.FadeAudioSources(this.fadeOutTime, S13AudioUtil.dB2Lin(this.volume), 0f, delegate
					{
						this._isFadingOut = false;
						foreach (AudioSource audioSource3 in this._audioSources)
						{
							audioSource3.volume = S13AudioUtil.dB2Lin(this.volume);
						}
					}));
				}
				else
				{
					base.StopCoroutine(this.RandomLoop());
					this._isLooping = false;
					if (ignoreFade)
					{
						foreach (AudioSource audioSource in this._audioSources)
						{
							audioSource.Stop();
						}
					}
				}
			}
			else if (this.fadeOutTime > 0f && !ignoreFade)
			{
				AudioSource[] audioSources2 = this._audioSources;
				for (int j = 0; j < audioSources2.Length; j++)
				{
					AudioSource source = audioSources2[j];
					S13ObjectComplex $this = this;
					if (source.isPlaying)
					{
						base.StartCoroutine(S13AudioUtil.FadeOut(source, this.fadeOutTime, S13AudioUtil.dB2Lin(this.volume), this.ignoreTimeScale, delegate
						{
							source.Stop();
							source.volume = S13AudioUtil.dB2Lin($this.volume);
						}));
					}
				}
			}
			else
			{
				foreach (AudioSource audioSource2 in this._audioSources)
				{
					audioSource2.Stop();
				}
			}
			if (this._isPaused)
			{
				this._isPaused = false;
				for (int l = 0; l < this._audioSources.Length; l++)
				{
					this._isVoicePaused[l] = false;
				}
			}
		}

		// Token: 0x0600010B RID: 267 RVA: 0x00023F78 File Offset: 0x00022178
		public override void Pause(bool ignoreFade)
		{
			if (!this._isPlaying)
			{
				return;
			}
			this._isPaused = true;
			this._waitForAudioEndLock = false;
			if (this.loop)
			{
				if (this.fadeOutTime > 0f && !ignoreFade)
				{
					this._isFadingOut = true;
					base.StartCoroutine(this.FadeAudioSources(this.fadeOutTime, S13AudioUtil.dB2Lin(this.volume), 0f, delegate
					{
						this._isFadingOut = false;
						foreach (AudioSource audioSource2 in this._audioSources)
						{
							audioSource2.volume = S13AudioUtil.dB2Lin(this.volume);
						}
					}));
				}
				else if (ignoreFade)
				{
					for (int i = 0; i < this._audioSources.Length; i++)
					{
						AudioSource audioSource = this._audioSources[i];
						if (audioSource.isPlaying)
						{
							audioSource.Pause();
							this._isVoicePaused[i] = true;
						}
					}
				}
			}
			else
			{
				for (int j = 0; j < this._audioSources.Length; j++)
				{
					AudioSource source = this._audioSources[j];
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
						this._isVoicePaused[j] = true;
					}
				}
			}
		}

		// Token: 0x0600010C RID: 268 RVA: 0x000240EC File Offset: 0x000222EC
		public override void Resume()
		{
			if (!this._isPaused)
			{
				Debug.LogWarning(base.name + ": Sound is not paused; cannot resume.", base.gameObject);
				return;
			}
			this._isPaused = false;
			if (this.loop)
			{
				if (this._isFadingOut)
				{
					base.StopAllCoroutines();
					base.StartCoroutine(this.RandomLoop());
				}
				if (this.fadeInTime > 0f)
				{
					base.StartCoroutine(this.FadeAudioSources(this.fadeInTime, 0f, S13AudioUtil.dB2Lin(this.volume), null));
				}
			}
			for (int i = 0; i < this._audioSources.Length; i++)
			{
				AudioSource audioSource = this._audioSources[i];
				if (this._isVoicePaused[i])
				{
					audioSource.UnPause();
					if (this.fadeInTime > 0f && !this.loop)
					{
						base.StartCoroutine(S13AudioUtil.FadeIn(audioSource, this.fadeInTime, S13AudioUtil.dB2Lin(this.volume), this.ignoreTimeScale, null));
					}
					this._isVoicePaused[i] = false;
				}
			}
			if (this.audioEndedHandler != null && !this._waitForAudioEndLock)
			{
				base.StartCoroutine(this.WaitForAudioEnd());
			}
		}

		// Token: 0x0600010D RID: 269 RVA: 0x00024228 File Offset: 0x00022428
		public override void UpdateParameters()
		{
			base.UpdateParameters();
			foreach (AudioSource audioSource in this._audioSources)
			{
				audioSource.velocityUpdateMode = this.velocityUpdateMode;
			}
		}

		// Token: 0x0600010E RID: 270 RVA: 0x00002D77 File Offset: 0x00000F77
		public override void SetClip(AudioClip clip, int slotIndex = 0)
		{
			base.SetClip(clip, slotIndex);
			this.audioClips[slotIndex] = clip;
		}

		// Token: 0x0600010F RID: 271 RVA: 0x00024268 File Offset: 0x00022468
		private IEnumerator RandomLoop()
		{
			float timer = 0f;
			float lastTime = Time.realtimeSinceStartup;
			float timeDelay = global::UnityEngine.Random.Range(this.delayMin, this.delayMax);
			float chance = (float)this.chanceToPlay / 100f;
			this._isLooping = true;
			Vector3 soundPos = Vector3.zero;
			while (this._isPlaying || this._isFadingOut)
			{
				if (timer >= timeDelay && !this._isPaused)
				{
					timer = 0f;
					timeDelay = global::UnityEngine.Random.Range(this.delayMin, this.delayMax);
					if (global::UnityEngine.Random.value < chance)
					{
						soundPos.x = global::UnityEngine.Random.Range(-this.distanceVariance, this.distanceVariance);
						soundPos.y = global::UnityEngine.Random.Range(-this.distanceVariance, this.distanceVariance);
						soundPos.z = global::UnityEngine.Random.Range(-this.distanceVariance, this.distanceVariance);
						int soundIndex = this._shuffleImpl.Next(true);
						this._voicesImpl.Play(soundIndex, delegate(int voiceIndex)
						{
							this._audioSources[voiceIndex].transform.localPosition = Vector3.ClampMagnitude(soundPos, this.distanceVariance);
							this._audioSources[voiceIndex].pitch = S13AudioUtil.SemitoneToPitch((float)global::UnityEngine.Random.Range(this.pitchMin, this.pitchMax));
							this._audioSources[voiceIndex].Play();
						});
					}
				}
				if (this.ignoreTimeScale)
				{
					timer += Time.realtimeSinceStartup - lastTime;
					lastTime = Time.realtimeSinceStartup;
				}
				else
				{
					timer += Time.deltaTime;
				}
				yield return null;
			}
			this._isLooping = false;
			yield break;
		}

		// Token: 0x06000110 RID: 272 RVA: 0x00024284 File Offset: 0x00022484
		private IEnumerator FadeAudioSources(float fadeTime, float from, float to, S13ObjectComplex.FadeCompletionHandler handler)
		{
			float timeElapsed = 0f;
			float lastTime = Time.realtimeSinceStartup;
			while (timeElapsed < fadeTime)
			{
				float t = timeElapsed / fadeTime;
				foreach (AudioSource audioSource in this._audioSources)
				{
					audioSource.volume = Mathf.Lerp(from, to, t);
				}
				if (this.ignoreTimeScale)
				{
					timeElapsed += Time.realtimeSinceStartup - lastTime;
					lastTime = Time.realtimeSinceStartup;
				}
				else
				{
					timeElapsed += Time.deltaTime;
				}
				yield return null;
			}
			if (handler != null)
			{
				handler();
			}
			yield break;
		}

		// Token: 0x06000111 RID: 273 RVA: 0x000242BC File Offset: 0x000224BC
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

		// Token: 0x06000112 RID: 274 RVA: 0x000242D8 File Offset: 0x000224D8
		private IEnumerator WaitForAudioEnd()
		{
			this._waitForAudioEndLock = true;
			bool allStopped;
			do
			{
				yield return base.StartCoroutine(S13AudioUtil.RealTimeWaitForSeconds(S13AudioSource.WAIT_FOR_AUDIO_END_UPDATE_FREQUENCY));
				allStopped = true;
				foreach (AudioSource audioSource in this._audioSources)
				{
					if (audioSource.timeSamples > 0 && audioSource.timeSamples < audioSource.clip.samples)
					{
						allStopped = false;
						break;
					}
				}
			}
			while (!allStopped || this._isLooping);
			this._waitForAudioEndLock = false;
			if (this.audioEndedHandler != null)
			{
				this.audioEndedHandler(this);
			}
			yield break;
		}

		// Token: 0x06000113 RID: 275 RVA: 0x000242F4 File Offset: 0x000224F4
		public override void DrawGizmos()
		{
			if (this.rolloffTemplate != null)
			{
				Gizmos.color = S13AudioSource.DEFAULT_GIZMO_COLOR;
				Gizmos.DrawWireSphere(base.transform.position, this.rolloffTemplate.maxDistance);
			}
			Gizmos.color = S13ObjectComplex.DISTANCE_VARIANCE_GIZMO_COLOR;
			Gizmos.DrawWireSphere(base.transform.position, this.distanceVariance);
		}

		// Token: 0x040000DE RID: 222
		public AudioClip[] audioClips;

		// Token: 0x040000DF RID: 223
		[AudioField("Voice Max", 1, 50)]
		public int voices = 1;

		// Token: 0x040000E0 RID: 224
		public VoiceMode voiceMode;

		// Token: 0x040000E1 RID: 225
		public AudioSource rolloffTemplate;

		// Token: 0x040000E2 RID: 226
		public AudioVelocityUpdateMode velocityUpdateMode;

		// Token: 0x040000E3 RID: 227
		public bool usesExternalVolume;

		// Token: 0x040000E4 RID: 228
		[AudioSlider("Spawn Time Min (s)", 0f, 30f)]
		public float delayMin;

		// Token: 0x040000E5 RID: 229
		[AudioSlider("Spawn Time Max (s)", 0f, 30f)]
		public float delayMax = 1f;

		// Token: 0x040000E6 RID: 230
		public bool enableRandomPitch = true;

		// Token: 0x040000E7 RID: 231
		[AudioSlider("Random Pitch Min (semi)", -12, 12)]
		public int pitchMin;

		// Token: 0x040000E8 RID: 232
		[AudioSlider("Random Pitch Max (semi)", -12, 12)]
		public int pitchMax;

		// Token: 0x040000E9 RID: 233
		[AudioSlider("Random 3D Position (units)", 0f, 100f)]
		public float distanceVariance = 1f;

		// Token: 0x040000EA RID: 234
		[AudioSlider("Fade-in time (s)", 0f, 60f)]
		public float fadeInTime;

		// Token: 0x040000EB RID: 235
		[AudioSlider("Fade-out time (s)", 0f, 60f)]
		public float fadeOutTime;

		// Token: 0x040000EC RID: 236
		[AudioSlider("Replay Gate Time (ms)", 0, 1000)]
		public int retriggerTime;

		// Token: 0x040000ED RID: 237
		[AudioSlider("Chance To Play (%)", 0, 100)]
		public int chanceToPlay = 100;

		// Token: 0x040000EE RID: 238
		private bool _isPlaying;

		// Token: 0x040000EF RID: 239
		private bool _isFadingOut;

		// Token: 0x040000F0 RID: 240
		private bool _isLooping;

		// Token: 0x040000F1 RID: 241
		private bool _canPlay = true;

		// Token: 0x040000F2 RID: 242
		private bool _waitForAudioEndLock;

		// Token: 0x040000F3 RID: 243
		private bool[] _isVoicePaused;

		// Token: 0x040000F4 RID: 244
		private S13VoicesImpl _voicesImpl;

		// Token: 0x040000F5 RID: 245
		private S13ShuffleImpl _shuffleImpl;

		// Token: 0x040000F6 RID: 246
		private static Color DISTANCE_VARIANCE_GIZMO_COLOR = new Color(0.98039216f, 0.99607843f, 0.49803922f, 0.62f);

		// Token: 0x02000035 RID: 53
		// (Invoke) Token: 0x0600011A RID: 282
		private delegate void FadeCompletionHandler();
	}
}
