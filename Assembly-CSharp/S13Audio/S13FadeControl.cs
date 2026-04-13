using System;
using System.Collections;
using UnityEngine;

namespace S13Audio
{
	// Token: 0x02000027 RID: 39
	public class S13FadeControl : MonoBehaviour
	{
		// Token: 0x1700001B RID: 27
		// (get) Token: 0x060000B9 RID: 185 RVA: 0x00002A4F File Offset: 0x00000C4F
		public bool IsFadingIn
		{
			get
			{
				return this._isFadingIn;
			}
		}

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x060000BA RID: 186 RVA: 0x00002A57 File Offset: 0x00000C57
		public bool IsFadingOut
		{
			get
			{
				return this._isFadingOut;
			}
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x060000BB RID: 187 RVA: 0x00002A5F File Offset: 0x00000C5F
		public bool IsFading
		{
			get
			{
				return this._isFadingIn && this._isFadingOut;
			}
		}

		// Token: 0x1700001E RID: 30
		// (set) Token: 0x060000BC RID: 188 RVA: 0x00002A75 File Offset: 0x00000C75
		public AnimationCurve Curve
		{
			set
			{
				this.curve = value;
			}
		}

		// Token: 0x060000BD RID: 189 RVA: 0x00022A8C File Offset: 0x00020C8C
		public void FadeIn(AudioSource audioSource, float startVolume, float endVolume, float fadeTime = 1f, bool ignoreTimeScale = true, S13FadeControl.FadeDelegate completionHandler = null)
		{
			if (this._isFadingIn)
			{
				return;
			}
			if (this._isFadingOut)
			{
				if (this.fadeOutEnumerator == null)
				{
					Debug.LogWarning("Attempting to stop unassigned fade OUT coroutine, operation cancelled.", base.gameObject);
					return;
				}
				base.StopCoroutine(this.fadeOutEnumerator);
				this._isFadingOut = false;
			}
			this._isFadingIn = true;
			this.fadeInEnumerator = this.Fade(audioSource, startVolume, endVolume, fadeTime, ignoreTimeScale, completionHandler, false);
			base.StartCoroutine(this.fadeInEnumerator);
		}

		// Token: 0x060000BE RID: 190 RVA: 0x00022B0C File Offset: 0x00020D0C
		public void FadeOut(AudioSource audioSource, float startVolume, float fadeTime = 1f, bool ignoreTimeScale = true, S13FadeControl.FadeDelegate completionHandler = null)
		{
			if (this._isFadingOut)
			{
				return;
			}
			if (this._isFadingIn)
			{
				if (this.fadeInEnumerator == null)
				{
					Debug.LogWarning("Attempting to stop unassigned fade IN coroutine, operation cancelled.", base.gameObject);
					return;
				}
				base.StopCoroutine(this.fadeInEnumerator);
				this._isFadingIn = false;
			}
			this._isFadingOut = true;
			this.fadeOutEnumerator = this.Fade(audioSource, startVolume, 0f, fadeTime, ignoreTimeScale, completionHandler, true);
			base.StartCoroutine(this.fadeOutEnumerator);
		}

		// Token: 0x060000BF RID: 191 RVA: 0x00022B8C File Offset: 0x00020D8C
		private IEnumerator Fade(AudioSource audioSource, float startVolume, float endVolume, float fadeTime, bool ignoreTimeScale, S13FadeControl.FadeDelegate completionHandler = null, bool fadeOut = true)
		{
			float timeElapsed = 0f;
			float lastTime = Time.realtimeSinceStartup;
			while (timeElapsed < fadeTime)
			{
				float t = timeElapsed / fadeTime;
				if (this.curve != null)
				{
					audioSource.volume = Mathf.Lerp(startVolume, endVolume, this.curve.Evaluate(t));
				}
				audioSource.volume = Mathf.Lerp(startVolume, endVolume, t);
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
			if (fadeOut)
			{
				audioSource.volume = 0f;
				this._isFadingOut = false;
			}
			else
			{
				audioSource.volume = endVolume;
				this._isFadingIn = false;
			}
			if (completionHandler != null)
			{
				completionHandler();
			}
			yield break;
		}

		// Token: 0x040000A6 RID: 166
		private AnimationCurve curve;

		// Token: 0x040000A7 RID: 167
		private bool _isFadingIn;

		// Token: 0x040000A8 RID: 168
		private bool _isFadingOut;

		// Token: 0x040000A9 RID: 169
		private IEnumerator fadeInEnumerator;

		// Token: 0x040000AA RID: 170
		private IEnumerator fadeOutEnumerator;

		// Token: 0x02000028 RID: 40
		// (Invoke) Token: 0x060000C1 RID: 193
		public delegate void FadeDelegate();
	}
}
