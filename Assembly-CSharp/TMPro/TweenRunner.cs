using System;
using System.Collections;
using UnityEngine;

namespace TMPro
{
	// Token: 0x020005F6 RID: 1526
	internal class TweenRunner<T> where T : struct, ITweenValue
	{
		// Token: 0x06002A7F RID: 10879 RVA: 0x000FF818 File Offset: 0x000FDA18
		private static IEnumerator Start(T tweenInfo)
		{
			if (!tweenInfo.ValidTarget())
			{
				yield break;
			}
			float elapsedTime = 0f;
			while (elapsedTime < tweenInfo.duration)
			{
				elapsedTime += ((!tweenInfo.ignoreTimeScale) ? Time.deltaTime : Time.unscaledDeltaTime);
				float percentage = Mathf.Clamp01(elapsedTime / tweenInfo.duration);
				tweenInfo.TweenValue(percentage);
				yield return null;
			}
			tweenInfo.TweenValue(1f);
			yield break;
		}

		// Token: 0x06002A80 RID: 10880 RVA: 0x0001E75D File Offset: 0x0001C95D
		public void Init(MonoBehaviour coroutineContainer)
		{
			this.m_CoroutineContainer = coroutineContainer;
		}

		// Token: 0x06002A81 RID: 10881 RVA: 0x000FF834 File Offset: 0x000FDA34
		public void StartTween(T info)
		{
			if (this.m_CoroutineContainer == null)
			{
				Debug.LogWarning("Coroutine container not configured... did you forget to call Init?");
				return;
			}
			this.StopTween();
			if (!this.m_CoroutineContainer.gameObject.activeInHierarchy)
			{
				info.TweenValue(1f);
				return;
			}
			this.m_Tween = TweenRunner<T>.Start(info);
			this.m_CoroutineContainer.StartCoroutine(this.m_Tween);
		}

		// Token: 0x06002A82 RID: 10882 RVA: 0x0001E766 File Offset: 0x0001C966
		public void StopTween()
		{
			if (this.m_Tween != null)
			{
				this.m_CoroutineContainer.StopCoroutine(this.m_Tween);
				this.m_Tween = null;
			}
		}

		// Token: 0x04002F0F RID: 12047
		protected MonoBehaviour m_CoroutineContainer;

		// Token: 0x04002F10 RID: 12048
		protected IEnumerator m_Tween;
	}
}
