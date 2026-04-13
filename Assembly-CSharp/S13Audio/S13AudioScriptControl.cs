using System;
using UnityEngine;

namespace S13Audio
{
	// Token: 0x02000006 RID: 6
	public class S13AudioScriptControl : S13AudioSource
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x0600000D RID: 13 RVA: 0x0000246D File Offset: 0x0000066D
		public override float Length
		{
			get
			{
				return -1f;
			}
		}

		// Token: 0x0600000E RID: 14 RVA: 0x00002474 File Offset: 0x00000674
		private void Awake()
		{
			this._audioSources = new AudioSource[0];
		}

		// Token: 0x0600000F RID: 15 RVA: 0x0002120C File Offset: 0x0001F40C
		public override void Play()
		{
			this.startScript.UnitySource(0).pitch = S13AudioUtil.SemitoneToPitch(global::UnityEngine.Random.Range(this.pitchMin, this.pitchMax));
			this.startScript.Play();
			this._randomLoop = global::UnityEngine.Random.Range(0, this.loopScripts.Length);
			S13AudioSource s13AudioSource = this.loopScripts[this._randomLoop];
			s13AudioSource.UnitySource(0).pitch = S13AudioUtil.SemitoneToPitch(global::UnityEngine.Random.Range(this.pitchMin, this.pitchMax));
			s13AudioSource.Play();
		}

		// Token: 0x06000010 RID: 16 RVA: 0x00021298 File Offset: 0x0001F498
		public override void Stop(bool ignoreFade)
		{
			this.loopScripts[this._randomLoop].Stop(ignoreFade);
			this.endScript.UnitySource(0).pitch = S13AudioUtil.SemitoneToPitch(global::UnityEngine.Random.Range(this.pitchMin, this.pitchMax));
			this.endScript.audioEndedHandler = delegate(S13AudioSource audioSource)
			{
				if (this.audioEndedHandler != null)
				{
					this.audioEndedHandler(this);
				}
			};
			this.endScript.Play();
		}

		// Token: 0x06000011 RID: 17 RVA: 0x00002482 File Offset: 0x00000682
		public override void Pause(bool ignoreFade)
		{
		}

		// Token: 0x06000012 RID: 18 RVA: 0x00002482 File Offset: 0x00000682
		public override void Resume()
		{
		}

		// Token: 0x04000016 RID: 22
		public S13AudioSource startScript;

		// Token: 0x04000017 RID: 23
		public S13AudioSource[] loopScripts;

		// Token: 0x04000018 RID: 24
		public S13AudioSource endScript;

		// Token: 0x04000019 RID: 25
		[AudioSlider("Pitch min (semitones)", -12f, 12f)]
		public float pitchMin;

		// Token: 0x0400001A RID: 26
		[AudioSlider("Pitch max (semitones)", -12f, 12f)]
		public float pitchMax;

		// Token: 0x0400001B RID: 27
		private int _randomLoop;
	}
}
