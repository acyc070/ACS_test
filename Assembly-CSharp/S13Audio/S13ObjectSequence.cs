using System;
using System.Collections;
using UnityEngine;

namespace S13Audio
{
	// Token: 0x02000042 RID: 66
	public class S13ObjectSequence : S13AudioSource
	{
		// Token: 0x17000039 RID: 57
		// (get) Token: 0x06000152 RID: 338 RVA: 0x00025234 File Offset: 0x00023434
		public override float Length
		{
			get
			{
				float num = 0f;
				for (int i = 0; i < this._audioSources.Length; i++)
				{
					num += this._audioSources[i].clip.length + ((i >= this.gapTimes.Length) ? 0f : this.gapTimes[i]);
				}
				return num;
			}
		}

		// Token: 0x06000153 RID: 339 RVA: 0x00025298 File Offset: 0x00023498
		private void Awake()
		{
			this._audioSources = new AudioSource[this.audioClips.Length];
			int num = 0;
			foreach (AudioClip audioClip in this.audioClips)
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
			this.UpdateParameters();
			this._offsetImpl = new S13OffsetImpl((int)(this.offsetTime * (float)this.audioClips[0].frequency));
			this._isSequenceClipPaused = new bool[this.audioClips.Length];
		}

		// Token: 0x06000154 RID: 340 RVA: 0x000253E0 File Offset: 0x000235E0
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
			if (!this.loop)
			{
				if (this.fadeInTime <= 0f)
				{
					this._startTime = AudioSettings.dspTime;
					double num2 = this._startTime;
					this._audioSources[0].Play();
					for (int i = 1; i < this._audioSources.Length; i++)
					{
						num2 += (double)this._audioSources[i - 1].clip.length;
						if (i <= this.gapTimes.Length)
						{
							num2 += (double)this.gapTimes[i - 1];
						}
						this._audioSources[i].PlayScheduled(num2);
					}
				}
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

		// Token: 0x06000155 RID: 341 RVA: 0x000254FC File Offset: 0x000236FC
		public override void Stop(bool ignoreFade)
		{
			base.Stop(ignoreFade);
			this._isPlaying = false;
			if (!this.loop)
			{
				if (this.fadeOutTime <= 0f || ignoreFade)
				{
					foreach (AudioSource audioSource in this._audioSources)
					{
						audioSource.Stop();
					}
				}
			}
			if (this._isPaused)
			{
				this._isPaused = false;
			}
		}

		// Token: 0x06000156 RID: 342 RVA: 0x0002557C File Offset: 0x0002377C
		public override void Pause(bool ignoreFade)
		{
			if (!this._isPlaying)
			{
				return;
			}
			this._isPaused = true;
			if (this.loop)
			{
				if (this.fadeOutTime <= 0f || ignoreFade)
				{
					if (ignoreFade)
					{
					}
				}
			}
			else
			{
				this._pausedTime = AudioSettings.dspTime - this._startTime;
				int num = 0;
				foreach (AudioSource audioSource in this._audioSources)
				{
					if (audioSource.isPlaying)
					{
						audioSource.Pause();
						this._isSequenceClipPaused[num] = true;
					}
					else
					{
						this._isSequenceClipPaused[num] = false;
					}
					num++;
				}
			}
		}

		// Token: 0x06000157 RID: 343 RVA: 0x0002562C File Offset: 0x0002382C
		public override void Resume()
		{
			if (!this._isPaused)
			{
				Debug.LogWarning(base.name + ": Sound is not paused; cannot resume.", base.gameObject);
				return;
			}
			this._isPaused = false;
			this._startTime = AudioSettings.dspTime;
			int num = 0;
			double num2 = 0.0;
			double dspTime = AudioSettings.dspTime;
			foreach (AudioSource audioSource in this._audioSources)
			{
				if (this._isSequenceClipPaused[num])
				{
					if (this._pausedTime < num2)
					{
						audioSource.Stop();
						audioSource.PlayScheduled(dspTime + num2 - this._pausedTime);
					}
					else
					{
						audioSource.UnPause();
					}
					float num3 = ((num >= this.gapTimes.Length) ? 0f : this.gapTimes[num]);
					num2 += (double)(audioSource.clip.length + num3);
					this._isSequenceClipPaused[num] = false;
				}
				num++;
			}
		}

		// Token: 0x06000158 RID: 344 RVA: 0x00025730 File Offset: 0x00023930
		public override void UpdateParameters()
		{
			base.UpdateParameters();
			foreach (AudioSource audioSource in this._audioSources)
			{
				audioSource.velocityUpdateMode = this.velocityUpdateMode;
			}
		}

		// Token: 0x06000159 RID: 345 RVA: 0x00002F2E File Offset: 0x0000112E
		public override void SetClip(AudioClip clip, int slotIndex = 0)
		{
			base.SetClip(clip, slotIndex);
			this.audioClips[slotIndex] = clip;
		}

		// Token: 0x0600015A RID: 346 RVA: 0x00002F41 File Offset: 0x00001141
		public override void DrawGizmos()
		{
			if (this.rolloffTemplate != null)
			{
				Gizmos.color = S13AudioSource.DEFAULT_GIZMO_COLOR;
				Gizmos.DrawWireSphere(base.transform.position, this.rolloffTemplate.maxDistance);
			}
		}

		// Token: 0x0600015B RID: 347 RVA: 0x00025770 File Offset: 0x00023970
		private IEnumerator WaitForAudioEnd()
		{
			int sequenceIndex = 0;
			AudioSource playingAudio = this._audioSources[sequenceIndex];
			if (playingAudio == null || playingAudio.clip == null)
			{
				yield return null;
			}
			for (;;)
			{
				yield return base.StartCoroutine(S13AudioUtil.RealTimeWaitForSeconds(S13AudioSource.WAIT_FOR_AUDIO_END_UPDATE_FREQUENCY));
				if (playingAudio.timeSamples == 0 || playingAudio.timeSamples >= playingAudio.clip.samples)
				{
					if (sequenceIndex == this._audioSources.Length - 1)
					{
						break;
					}
					playingAudio = this._audioSources[++sequenceIndex];
				}
			}
			if (this.audioEndedHandler != null)
			{
				this.audioEndedHandler(this);
			}
			yield break;
		}

		// Token: 0x04000131 RID: 305
		public AudioClip[] audioClips;

		// Token: 0x04000132 RID: 306
		public float[] gapTimes;

		// Token: 0x04000133 RID: 307
		public AudioSource rolloffTemplate;

		// Token: 0x04000134 RID: 308
		public AudioVelocityUpdateMode velocityUpdateMode;

		// Token: 0x04000135 RID: 309
		[AudioSlider("Fade-in time (s)", 0f, 60f)]
		public float fadeInTime;

		// Token: 0x04000136 RID: 310
		[AudioSlider("Fade-out time (s)", 0f, 60f)]
		public float fadeOutTime;

		// Token: 0x04000137 RID: 311
		[AudioSlider("Chance To Play (%)", 0, 100)]
		public int chanceToPlay = 100;

		// Token: 0x04000138 RID: 312
		private bool _isPlaying;

		// Token: 0x04000139 RID: 313
		private bool _canPlay = true;

		// Token: 0x0400013A RID: 314
		private double _startTime;

		// Token: 0x0400013B RID: 315
		private double _pausedTime;

		// Token: 0x0400013C RID: 316
		private bool[] _isSequenceClipPaused;
	}
}
