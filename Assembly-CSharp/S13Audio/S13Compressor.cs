using System;
using System.IO;
using UnityEngine;

namespace S13Audio
{
	// Token: 0x02000014 RID: 20
	public class S13Compressor : MonoBehaviour
	{
		// Token: 0x06000047 RID: 71 RVA: 0x00021CF8 File Offset: 0x0001FEF8
		private void Awake()
		{
			if (this.processType == ProcessType.Compressor)
			{
				this._slopeFunc = new S13Compressor.SlopeCalculation(this.CompressorSlope);
			}
			else if (this.processType == ProcessType.Limiter)
			{
				this._slopeFunc = new S13Compressor.SlopeCalculation(this.LimiterSlope);
			}
			this.attackTime /= 1000f;
			this.releaseTime /= 1000f;
			this._sampleRate = (float)AudioSettings.outputSampleRate;
			this._envelopeDetector = new S13EnvelopeDetector[2];
			this._envelopeDetector[0] = new S13EnvelopeDetector(this.attackTime, this.releaseTime, this.detectMode, this._sampleRate);
			this._envelopeDetector[1] = new S13EnvelopeDetector(this.attackTime, this.releaseTime, this.detectMode, this._sampleRate);
			this._lookaheadDelay = new S13Delay(0.2f, 0f, this._sampleRate, 2);
			this._lookaheadDelay.SetDelayTime(this.lookaheadTime, this._sampleRate);
			this._lookaheadDelay.DryMix = 0f;
		}

		// Token: 0x06000048 RID: 72 RVA: 0x00002482 File Offset: 0x00000682
		private void Start()
		{
		}

		// Token: 0x06000049 RID: 73 RVA: 0x00021E10 File Offset: 0x00020010
		private void OnAudioFilterRead(float[] data, int numChannels)
		{
			float num = S13AudioUtil.dB2Lin(this.postGain);
			float num2 = this.threshold * this.knee * -1f;
			float num3 = this.threshold - num2 / 2f;
			float num4 = this.threshold + num2 / 2f;
			if (this.preGain != 0f)
			{
				float num5 = S13AudioUtil.dB2Lin(this.preGain);
				for (int i = 0; i < data.Length; i++)
				{
					data[i] *= num5;
				}
			}
			float[][] array = new float[numChannels][];
			if (numChannels == 2)
			{
				float[][] array2;
				S13AudioUtil.DeinterleaveBuffer(data, out array2, numChannels);
				this._envelopeDetector[0].GetEnvelope(array2[0], out array[0]);
				this._envelopeDetector[1].GetEnvelope(array2[1], out array[1]);
				for (int j = 0; j < array[0].Length; j++)
				{
					array[0][j] = Mathf.Max(array[0][j], array[1][j]);
				}
			}
			else if (numChannels == 1)
			{
				this._envelopeDetector[0].GetEnvelope(data, out array[0]);
			}
			else
			{
				Debug.LogError(base.name + ": Only mono or stereo audio source supported.");
				Debug.Break();
			}
			if (this.lookaheadTime > 0f)
			{
				this._lookaheadDelay.SetDelayTime(this.lookaheadTime, this._sampleRate);
				this._lookaheadDelay.Process(data, numChannels);
			}
			int k = 0;
			int num6 = 0;
			while (k < data.Length)
			{
				float num7 = S13AudioUtil.Lin2dB(array[0][num6]);
				float num8 = this._slopeFunc(this.ratio);
				float num9;
				if (num2 > 0f && num7 > num3 && num7 < num4)
				{
					num8 *= (num7 - num3) / num2 * 0.5f;
					num9 = num8 * (num3 - num7);
				}
				else
				{
					num9 = num8 * (this.threshold - num7);
					num9 = Mathf.Min(0f, num9);
				}
				num9 = S13AudioUtil.dB2Lin(num9);
				for (int l = 0; l < numChannels; l++)
				{
					data[k + l] *= num9 * num;
				}
				k += numChannels;
				num6++;
			}
		}

		// Token: 0x0600004A RID: 74 RVA: 0x00002738 File Offset: 0x00000938
		private float CompressorSlope(float ratio)
		{
			return 1f - 1f / ratio;
		}

		// Token: 0x0600004B RID: 75 RVA: 0x00002747 File Offset: 0x00000947
		private float LimiterSlope(float ratio)
		{
			return 1f;
		}

		// Token: 0x0600004C RID: 76 RVA: 0x0002205C File Offset: 0x0002025C
		private void Plot()
		{
			string text = Environment.CurrentDirectory + "/Data/compressor_plot.txt";
			StreamWriter streamWriter = File.CreateText(text);
			float num = this.threshold * this.knee * -1f;
			float num2 = this.threshold - num / 2f;
			float num3 = this.threshold + num / 2f;
			float num4 = 0.17578125f;
			float num5 = -90f;
			for (int i = 0; i < 512; i++)
			{
				float num6 = this._slopeFunc(this.ratio);
				float num7;
				if (num > 0f && num5 > num2 && num5 < num3)
				{
					num6 = num6 * ((num5 - num2) / num) * 0.5f;
					num7 = num6 * (num2 - num5);
				}
				else
				{
					num7 = num6 * (this.threshold - num5);
					num7 = Mathf.Min(0f, num7);
				}
				num7 = S13AudioUtil.dB2Lin(num7);
				float num8 = S13AudioUtil.dB2Lin(num5) * num7;
				streamWriter.WriteLine("{0}\t{1}", num5, S13AudioUtil.Lin2dB(num8));
				num5 += num4;
			}
			streamWriter.Close();
			Debug.Log("compressor plotted");
		}

		// Token: 0x04000057 RID: 87
		[AudioSlider("Threshold (dB)", -60f, 0f)]
		public float threshold;

		// Token: 0x04000058 RID: 88
		[AudioSlider("Ratio (x:1)", 1f, 20f)]
		public float ratio = 1f;

		// Token: 0x04000059 RID: 89
		[AudioSlider("Knee", 0f, 1f)]
		public float knee = 0.2f;

		// Token: 0x0400005A RID: 90
		[AudioSlider("Pre-gain (dB)", -12f, 24f)]
		public float preGain;

		// Token: 0x0400005B RID: 91
		[AudioSlider("Post-gain (dB)", -12f, 24f)]
		public float postGain;

		// Token: 0x0400005C RID: 92
		[AudioSlider("Attack time (ms)", 0f, 200f)]
		public float attackTime = 10f;

		// Token: 0x0400005D RID: 93
		[AudioSlider("Release time (ms)", 10f, 3000f)]
		public float releaseTime = 50f;

		// Token: 0x0400005E RID: 94
		[AudioSlider("Lookahead time (ms)", 0f, 200f)]
		public float lookaheadTime;

		// Token: 0x0400005F RID: 95
		public ProcessType processType;

		// Token: 0x04000060 RID: 96
		public EnvDetectMode detectMode;

		// Token: 0x04000061 RID: 97
		private S13EnvelopeDetector[] _envelopeDetector;

		// Token: 0x04000062 RID: 98
		private S13Delay _lookaheadDelay;

		// Token: 0x04000063 RID: 99
		private S13Compressor.SlopeCalculation _slopeFunc;

		// Token: 0x04000064 RID: 100
		private float _sampleRate;

		// Token: 0x02000015 RID: 21
		// (Invoke) Token: 0x0600004E RID: 78
		private delegate float SlopeCalculation(float ratio);
	}
}
