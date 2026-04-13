using System;
using UnityEngine;

namespace S13Audio
{
	// Token: 0x0200001F RID: 31
	public interface IAudioSource
	{
		// Token: 0x06000081 RID: 129
		void Play();

		// Token: 0x06000082 RID: 130
		void Play(float duration);

		// Token: 0x06000083 RID: 131
		void PlayDelayed(float delayTime);

		// Token: 0x06000084 RID: 132
		void Stop(bool ignoreFade = false);

		// Token: 0x06000085 RID: 133
		void StopDelayed(float delayTime, bool ignoreFade = false);

		// Token: 0x06000086 RID: 134
		void Pause(bool ignoreFade = false);

		// Token: 0x06000087 RID: 135
		void Resume();

		// Token: 0x06000088 RID: 136
		void SetMuting(bool muting);

		// Token: 0x06000089 RID: 137
		void UpdateParameters();

		// Token: 0x0600008A RID: 138
		AudioSource UnitySource(int index);

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x0600008B RID: 139
		float Length { get; }

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x0600008C RID: 140
		int AudioSourceCount { get; }

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x0600008D RID: 141
		bool IsPlaying { get; }
	}
}
