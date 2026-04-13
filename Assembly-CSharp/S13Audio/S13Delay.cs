using System;
using UnityEngine;

namespace S13Audio
{
	// Token: 0x02000016 RID: 22
	public class S13Delay
	{
		// Token: 0x06000051 RID: 81 RVA: 0x00022190 File Offset: 0x00020390
		public S13Delay(float delayTime, float delayFeedback, float sampleRate, int numChannels)
		{
			this._delayFeedback = delayFeedback;
			this._numChannels = numChannels;
			this._delaySampleLength = Mathf.RoundToInt(delayTime * sampleRate);
			this._delayBuffer = new S13RingBuffer<float>(this._delaySampleLength * this._numChannels);
			float num = 1f;
			this.WetMix = num;
			this.DryMix = num;
			this.Reset();
		}

		// Token: 0x06000052 RID: 82 RVA: 0x000221F4 File Offset: 0x000203F4
		public S13Delay(int delaySamples, float delayFeedback, int numChannels)
		{
			this._delayFeedback = delayFeedback;
			this._numChannels = numChannels;
			this._delaySampleLength = delaySamples;
			this._delayBuffer = new S13RingBuffer<float>(this._delaySampleLength * this._numChannels);
			float num = 1f;
			this.WetMix = num;
			this.DryMix = num;
			this.Reset();
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000053 RID: 83 RVA: 0x0000274E File Offset: 0x0000094E
		// (set) Token: 0x06000054 RID: 84 RVA: 0x00002756 File Offset: 0x00000956
		public float Feedback
		{
			get
			{
				return this._delayFeedback;
			}
			set
			{
				this._delayFeedback = value;
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000055 RID: 85 RVA: 0x0000275F File Offset: 0x0000095F
		// (set) Token: 0x06000056 RID: 86 RVA: 0x00002767 File Offset: 0x00000967
		public float DryMix
		{
			get
			{
				return this._dryMix;
			}
			set
			{
				this._dryMix = value;
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000057 RID: 87 RVA: 0x00002770 File Offset: 0x00000970
		// (set) Token: 0x06000058 RID: 88 RVA: 0x00002778 File Offset: 0x00000978
		public float WetMix
		{
			get
			{
				return this._wetMix;
			}
			set
			{
				this._wetMix = value;
			}
		}

		// Token: 0x06000059 RID: 89 RVA: 0x00002781 File Offset: 0x00000981
		public void SetDelayTime(float delayTime, float sampleRate)
		{
			this._delaySampleLength = Mathf.RoundToInt(delayTime * sampleRate);
			this._delayBuffer.Length = this._delaySampleLength * this._numChannels;
		}

		// Token: 0x0600005A RID: 90 RVA: 0x00022250 File Offset: 0x00020450
		public void Process(float[] audioData, int numChannels)
		{
			if (this._delayBuffer.Length == 0)
			{
				return;
			}
			for (int i = 0; i < audioData.Length; i += numChannels)
			{
				for (int j = 0; j < numChannels; j++)
				{
					float num = this._delayBuffer.Read();
					this._delayBuffer.Write(audioData[i + j] + num * this._delayFeedback);
					audioData[i + j] = audioData[i + j] * this.DryMix + num * this.WetMix;
				}
			}
		}

		// Token: 0x0600005B RID: 91 RVA: 0x000027A9 File Offset: 0x000009A9
		public void Reset()
		{
			this._delayBuffer.Clear(0f);
		}

		// Token: 0x04000065 RID: 101
		private float _delayFeedback;

		// Token: 0x04000066 RID: 102
		private float _dryMix;

		// Token: 0x04000067 RID: 103
		private float _wetMix;

		// Token: 0x04000068 RID: 104
		private int _delaySampleLength;

		// Token: 0x04000069 RID: 105
		private int _numChannels;

		// Token: 0x0400006A RID: 106
		private S13RingBuffer<float> _delayBuffer;
	}
}
