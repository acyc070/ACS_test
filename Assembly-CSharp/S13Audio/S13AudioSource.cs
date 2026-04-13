using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

namespace S13Audio
{
	// Token: 0x02000051 RID: 81
	public abstract class S13AudioSource : MonoBehaviour, IAudioSource
	{
		// Token: 0x06000316 RID: 790 RVA: 0x00029EF8 File Offset: 0x000280F8
		private void OnEnable()
		{
			foreach (AudioSource audioSource in this._audioSources)
			{
				audioSource.enabled = true;
			}
			if (this.playOnAwake)
			{
				this.Play();
			}
		}

		// Token: 0x06000317 RID: 791 RVA: 0x00029F3C File Offset: 0x0002813C
		private void OnDisable()
		{
			foreach (AudioSource audioSource in this._audioSources)
			{
				audioSource.enabled = false;
			}
		}

		// Token: 0x06000318 RID: 792 RVA: 0x00004F5F File Offset: 0x0000315F
		private void OnDrawGizmosSelected()
		{
			this.DrawGizmos();
		}

		// Token: 0x06000319 RID: 793
		public abstract void Play();

		// Token: 0x0600031A RID: 794
		public abstract void Pause(bool ignoreFade = false);

		// Token: 0x0600031B RID: 795
		public abstract void Resume();

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x0600031C RID: 796
		public abstract float Length { get; }

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x0600031D RID: 797 RVA: 0x00004F67 File Offset: 0x00003167
		public virtual int AudioSourceCount
		{
			get
			{
				return this._audioSources.Length;
			}
		}

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x0600031E RID: 798 RVA: 0x00029F70 File Offset: 0x00028170
		public virtual bool IsPlaying
		{
			get
			{
				foreach (AudioSource audioSource in this._audioSources)
				{
					if (audioSource.isPlaying)
					{
						return true;
					}
				}
				return false;
			}
		}

		// Token: 0x0600031F RID: 799 RVA: 0x00029FAC File Offset: 0x000281AC
		public virtual void UpdateParameters()
		{
			foreach (AudioSource audioSource in this._audioSources)
			{
				audioSource.mute = this.mute;
				audioSource.volume = S13AudioUtil.dB2Lin(this.volume);
				audioSource.pitch = S13AudioUtil.SemitoneToPitch(this.pitch);
				audioSource.panStereo = this.pan;
			}
		}

		// Token: 0x06000320 RID: 800 RVA: 0x00004F71 File Offset: 0x00003171
		public virtual void Play(float duration)
		{
			this.Play();
			base.StartCoroutine(S13AudioUtil.WaitForDuration(duration, this.ignoreTimeScale, delegate
			{
				this.Stop(false);
			}));
		}

		// Token: 0x06000321 RID: 801 RVA: 0x00004F98 File Offset: 0x00003198
		public virtual void PlayDelayed(float delayTime)
		{
			this._delayCoroutine = S13AudioUtil.WaitForDuration(delayTime, this.ignoreTimeScale, delegate
			{
				this.Play();
			});
			base.StartCoroutine(this._delayCoroutine);
		}

		// Token: 0x06000322 RID: 802 RVA: 0x00004FC5 File Offset: 0x000031C5
		public virtual void Stop(bool ignoreFade = false)
		{
			if (this._delayCoroutine != null)
			{
				base.StopCoroutine(this._delayCoroutine);
				this._delayCoroutine = null;
			}
		}

		// Token: 0x06000323 RID: 803 RVA: 0x0002A014 File Offset: 0x00028214
		public virtual void StopDelayed(float delayTime, bool ignoreFade = false)
		{
			base.StartCoroutine(S13AudioUtil.WaitForDuration(delayTime, this.ignoreTimeScale, delegate
			{
				this.Stop(ignoreFade);
			}));
		}

		// Token: 0x06000324 RID: 804 RVA: 0x0002A054 File Offset: 0x00028254
		public virtual void SetMuting(bool muting)
		{
			if (muting == !this.mute)
			{
				return;
			}
			this.mute = !muting;
			foreach (AudioSource audioSource in this._audioSources)
			{
				audioSource.mute = this.mute;
			}
		}

		// Token: 0x06000325 RID: 805 RVA: 0x0002A0A8 File Offset: 0x000282A8
		public virtual void SetClip(AudioClip clip, int slotIndex = 0)
		{
			if (slotIndex >= this._audioSources.Length)
			{
				Debug.LogError(base.name + ": Slot index exceeds the number of AudioSources.");
				return;
			}
			if (this._audioSources[slotIndex].isPlaying)
			{
				this._audioSources[slotIndex].time = 0f;
			}
			this._audioSources[slotIndex].clip = clip;
			this._offsetImpl = new S13OffsetImpl((int)(this.offsetTime * (float)clip.frequency));
		}

		// Token: 0x06000326 RID: 806 RVA: 0x00004FE5 File Offset: 0x000031E5
		public AudioSource UnitySource(int index)
		{
			if (index >= 0 && index < this._audioSources.Length)
			{
				return this._audioSources[index];
			}
			return null;
		}

		// Token: 0x06000327 RID: 807 RVA: 0x00002482 File Offset: 0x00000682
		public virtual void DrawGizmos()
		{
		}

		// Token: 0x06000328 RID: 808 RVA: 0x0002A128 File Offset: 0x00028328
		protected GameObject _addAudioSourceChild(string name, GameObject template = null)
		{
			GameObject gameObject;
			if (template != null)
			{
				gameObject = global::UnityEngine.Object.Instantiate<GameObject>(template);
				gameObject.name = name;
			}
			else
			{
				gameObject = new GameObject(name);
			}
			gameObject.transform.parent = base.transform;
			gameObject.transform.position = base.transform.position;
			gameObject.transform.rotation = base.transform.rotation;
			return gameObject;
		}

		// Token: 0x04000194 RID: 404
		public S13AudioGroup group;

		// Token: 0x04000195 RID: 405
		public AudioMixerGroup outputOverride;

		// Token: 0x04000196 RID: 406
		public bool mute;

		// Token: 0x04000197 RID: 407
		public bool loop;

		// Token: 0x04000198 RID: 408
		public bool playOnAwake;

		// Token: 0x04000199 RID: 409
		public bool gamePauseEnabled = true;

		// Token: 0x0400019A RID: 410
		public bool ignoreTimeScale = true;

		// Token: 0x0400019B RID: 411
		[AudioSlider("Volume (dB)", -60f, 0f)]
		public float volume;

		// Token: 0x0400019C RID: 412
		[AudioSlider("Pitch (semitones)", -12f, 12f)]
		public float pitch;

		// Token: 0x0400019D RID: 413
		[AudioSlider("Stereo Pan", -1f, 1f)]
		public float pan;

		// Token: 0x0400019E RID: 414
		[AudioField("Start Position (s)", 0f, 3600f)]
		public float offsetTime;

		// Token: 0x0400019F RID: 415
		public bool startRandom;

		// Token: 0x040001A0 RID: 416
		[AudioSlider("Start Delay Time (ms)", 0, 5000)]
		public int timelineOffset;

		// Token: 0x040001A1 RID: 417
		protected AudioSource[] _audioSources;

		// Token: 0x040001A2 RID: 418
		protected S13OffsetImpl _offsetImpl;

		// Token: 0x040001A3 RID: 419
		protected S13ResumeImpl _resumeOnPlay;

		// Token: 0x040001A4 RID: 420
		protected bool _isPaused;

		// Token: 0x040001A5 RID: 421
		private IEnumerator _delayCoroutine;

		// Token: 0x040001A6 RID: 422
		public S13AudioSource.AudioEndedHandler audioEndedHandler;

		// Token: 0x040001A7 RID: 423
		protected static float WAIT_FOR_AUDIO_END_UPDATE_FREQUENCY = 0.25f;

		// Token: 0x040001A8 RID: 424
		protected static Color DEFAULT_GIZMO_COLOR = new Color(0.49803922f, 0.69803923f, 0.99607843f, 0.62f);

		// Token: 0x02000052 RID: 82
		// (Invoke) Token: 0x0600032D RID: 813
		public delegate void AudioEndedHandler(S13AudioSource audioSource);
	}
}
