using System;
using System.Collections;
using UnityEngine;

namespace S13Audio
{
	// Token: 0x02000020 RID: 32
	public static class S13AudioUtil
	{
		// Token: 0x0600008E RID: 142 RVA: 0x000225DC File Offset: 0x000207DC
		public static IEnumerator FadeIn(AudioSource audioSource, float fadeInTime, float targetVolume, bool ignoreTimeScale, S13AudioUtil.FadeInOutDelegate completionHandler = null)
		{
			float timeElapsed = 0f;
			float lastTime = Time.realtimeSinceStartup;
			while (timeElapsed < fadeInTime)
			{
				float t = timeElapsed / fadeInTime;
				audioSource.volume = Mathf.Lerp(0f, targetVolume, t);
				if (ignoreTimeScale)
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
			audioSource.volume = targetVolume;
			if (completionHandler != null)
			{
				completionHandler();
			}
			yield break;
		}

		// Token: 0x0600008F RID: 143 RVA: 0x00022614 File Offset: 0x00020814
		public static IEnumerator FadeOut(AudioSource audioSource, float fadeOutTime, float currentVolume, bool ignoreTimeScale, S13AudioUtil.FadeInOutDelegate completionHandler = null)
		{
			float timeElapsed = 0f;
			float lastTime = Time.realtimeSinceStartup;
			while (timeElapsed < fadeOutTime)
			{
				float t = timeElapsed / fadeOutTime;
				audioSource.volume = Mathf.Lerp(currentVolume, 0f, t);
				if (ignoreTimeScale)
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
			audioSource.volume = 0f;
			if (completionHandler != null)
			{
				completionHandler();
			}
			yield break;
		}

		// Token: 0x06000090 RID: 144 RVA: 0x0002264C File Offset: 0x0002084C
		public static IEnumerator WaitForDuration(float timeDuration, bool ignoreTimeScale, S13AudioUtil.WaitForDurationDelegate completionHandler)
		{
			if (completionHandler != null)
			{
				if (ignoreTimeScale)
				{
					IEnumerator waitTime = S13AudioUtil.RealTimeWaitForSeconds(timeDuration);
					while (waitTime.MoveNext())
					{
						object obj = waitTime.Current;
						yield return obj;
					}
				}
				else
				{
					yield return new WaitForSeconds(timeDuration);
				}
				completionHandler();
			}
			else
			{
				Debug.LogError("WaitForDuration: Delegate cannot be null.");
			}
			yield break;
		}

		// Token: 0x06000091 RID: 145 RVA: 0x00022678 File Offset: 0x00020878
		public static IEnumerator RealTimeWaitForSeconds(float duration)
		{
			float finishTime = Time.realtimeSinceStartup + duration;
			while (Time.realtimeSinceStartup < finishTime)
			{
				yield return null;
			}
			yield break;
		}

		// Token: 0x06000092 RID: 146 RVA: 0x00002979 File Offset: 0x00000B79
		public static float SemitoneToPitch(float semitone)
		{
			return (float)Math.Pow(S13AudioUtil.PITCH_RATIO, (double)semitone);
		}

		// Token: 0x06000093 RID: 147 RVA: 0x00002988 File Offset: 0x00000B88
		public static float PitchToSemitone(float pitch)
		{
			return (float)(Math.Log10((double)pitch) / S13AudioUtil.PITCH_RATIO_LOG10);
		}

		// Token: 0x06000094 RID: 148 RVA: 0x00002998 File Offset: 0x00000B98
		public static float Lin2dB(float lin)
		{
			if (lin > 0f)
			{
				return 20f * Mathf.Log10(lin);
			}
			return -60f;
		}

		// Token: 0x06000095 RID: 149 RVA: 0x000029B7 File Offset: 0x00000BB7
		public static float dB2Lin(float dB)
		{
			return Mathf.Pow(10f, dB / 20f);
		}

		// Token: 0x06000096 RID: 150 RVA: 0x00022694 File Offset: 0x00020894
		public static void DeinterleaveBuffer(float[] source, out float[][] output, int sourceChannels)
		{
			int num = source.Length / sourceChannels;
			output = new float[sourceChannels][];
			for (int i = 0; i < sourceChannels; i++)
			{
				output[i] = new float[num];
				for (int j = 0; j < num; j++)
				{
					output[i][j] = source[j * sourceChannels + i];
				}
			}
		}

		// Token: 0x04000082 RID: 130
		private static double PITCH_RATIO = 1.0594630943592953;

		// Token: 0x04000083 RID: 131
		private static double PITCH_RATIO_LOG10 = 0.025085832971998432;

		// Token: 0x02000021 RID: 33
		// (Invoke) Token: 0x06000099 RID: 153
		public delegate void FadeInOutDelegate();

		// Token: 0x02000022 RID: 34
		// (Invoke) Token: 0x0600009D RID: 157
		public delegate void WaitForDurationDelegate();
	}
}
