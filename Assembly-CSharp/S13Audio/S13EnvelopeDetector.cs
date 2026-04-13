using System;
using UnityEngine;

namespace S13Audio
{
	// Token: 0x0200001B RID: 27
	public class S13EnvelopeDetector
	{
		// Token: 0x0600006A RID: 106 RVA: 0x0000283A File Offset: 0x00000A3A
		public S13EnvelopeDetector(float attackTime, float releaseTime, EnvDetectMode detectMode, float sampleRate = 44100f)
		{
			this._sampleRate = sampleRate;
			this.AttackTime = attackTime;
			this.ReleaseTime = releaseTime;
			this.DetectMode = detectMode;
			this.Reset();
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x0600006B RID: 107 RVA: 0x00002865 File Offset: 0x00000A65
		// (set) Token: 0x0600006C RID: 108 RVA: 0x0000286D File Offset: 0x00000A6D
		public float AttackTime
		{
			get
			{
				return this._attackTime;
			}
			set
			{
				this._attackTime = value;
				this._attackGain = this.CalculateTimeConstant(this._attackTime);
			}
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x0600006D RID: 109 RVA: 0x00002888 File Offset: 0x00000A88
		// (set) Token: 0x0600006E RID: 110 RVA: 0x00002890 File Offset: 0x00000A90
		public float ReleaseTime
		{
			get
			{
				return this._releaseTime;
			}
			set
			{
				this._releaseTime = value;
				this._releaseGain = this.CalculateTimeConstant(this._releaseTime);
			}
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x0600006F RID: 111 RVA: 0x000028AB File Offset: 0x00000AAB
		// (set) Token: 0x06000070 RID: 112 RVA: 0x00022384 File Offset: 0x00020584
		public EnvDetectMode DetectMode
		{
			get
			{
				return this._detectMode;
			}
			set
			{
				EnvDetectMode detectMode = this._detectMode;
				if (detectMode != EnvDetectMode.Peak)
				{
					if (detectMode == EnvDetectMode.Rms)
					{
						this._detector = new EnvDetectRms();
					}
				}
				else
				{
					this._detector = new EnvDetectPeak();
				}
			}
		}

		// Token: 0x06000071 RID: 113 RVA: 0x000223CC File Offset: 0x000205CC
		public void GetEnvelope(float[] audioData, out float[] envelope)
		{
			envelope = new float[audioData.Length];
			this._detector.Buffer = audioData;
			for (int i = 0; i < audioData.Length; i++)
			{
				float num = this._detector[i];
				if (this._envelopeSample < num)
				{
					this._envelopeSample = num + this._attackGain * (this._envelopeSample - num);
				}
				else
				{
					this._envelopeSample = num + this._releaseGain * (this._envelopeSample - num);
				}
				envelope[i] = this._envelopeSample;
			}
		}

		// Token: 0x06000072 RID: 114 RVA: 0x000028B3 File Offset: 0x00000AB3
		public void Reset()
		{
			this._envelopeSample = 0f;
			this._detector.Reset();
		}

		// Token: 0x06000073 RID: 115 RVA: 0x000028CB File Offset: 0x00000ACB
		private float CalculateTimeConstant(float time)
		{
			return Mathf.Exp(-1f / (time * this._sampleRate));
		}

		// Token: 0x04000073 RID: 115
		protected float _attackTime;

		// Token: 0x04000074 RID: 116
		protected float _releaseTime;

		// Token: 0x04000075 RID: 117
		protected float _attackGain;

		// Token: 0x04000076 RID: 118
		protected float _releaseGain;

		// Token: 0x04000077 RID: 119
		protected float _sampleRate;

		// Token: 0x04000078 RID: 120
		protected float _envelopeSample;

		// Token: 0x04000079 RID: 121
		protected EnvDetectMode _detectMode;

		// Token: 0x0400007A RID: 122
		protected IEnvelopeDetection _detector;
	}
}
