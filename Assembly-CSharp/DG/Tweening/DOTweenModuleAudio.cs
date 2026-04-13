using System;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using UnityEngine.Audio;

namespace DG.Tweening
{
	// Token: 0x020002F3 RID: 755
	public static class DOTweenModuleAudio
	{
		// Token: 0x06001BC1 RID: 7105 RVA: 0x00093804 File Offset: 0x00091A04
		public static Tweener DOFade(this AudioSource target, float endValue, float duration)
		{
			if (endValue < 0f)
			{
				endValue = 0f;
			}
			else if (endValue > 1f)
			{
				endValue = 1f;
			}
			return DOTween.To(() => target.volume, delegate(float x)
			{
				target.volume = x;
			}, endValue, duration).SetTarget(target);
		}

		// Token: 0x06001BC2 RID: 7106 RVA: 0x00093874 File Offset: 0x00091A74
		public static Tweener DOPitch(this AudioSource target, float endValue, float duration)
		{
			return DOTween.To(() => target.pitch, delegate(float x)
			{
				target.pitch = x;
			}, endValue, duration).SetTarget(target);
		}

		// Token: 0x06001BC3 RID: 7107 RVA: 0x000938B8 File Offset: 0x00091AB8
		public static Tweener DOSetFloat(this AudioMixer target, string floatName, float endValue, float duration)
		{
			return DOTween.To(delegate
			{
				float num;
				target.GetFloat(floatName, out num);
				return num;
			}, delegate(float x)
			{
				target.SetFloat(floatName, x);
			}, endValue, duration).SetTarget(target);
		}

		// Token: 0x06001BC4 RID: 7108 RVA: 0x0001638F File Offset: 0x0001458F
		public static int DOComplete(this AudioMixer target, bool withCallbacks = false)
		{
			return DOTween.Complete(target, withCallbacks);
		}

		// Token: 0x06001BC5 RID: 7109 RVA: 0x00016398 File Offset: 0x00014598
		public static int DOKill(this AudioMixer target, bool complete = false)
		{
			return DOTween.Kill(target, complete);
		}

		// Token: 0x06001BC6 RID: 7110 RVA: 0x000163A1 File Offset: 0x000145A1
		public static int DOFlip(this AudioMixer target)
		{
			return DOTween.Flip(target);
		}

		// Token: 0x06001BC7 RID: 7111 RVA: 0x000163A9 File Offset: 0x000145A9
		public static int DOGoto(this AudioMixer target, float to, bool andPlay = false)
		{
			return DOTween.Goto(target, to, andPlay);
		}

		// Token: 0x06001BC8 RID: 7112 RVA: 0x000163B3 File Offset: 0x000145B3
		public static int DOPause(this AudioMixer target)
		{
			return DOTween.Pause(target);
		}

		// Token: 0x06001BC9 RID: 7113 RVA: 0x000163BB File Offset: 0x000145BB
		public static int DOPlay(this AudioMixer target)
		{
			return DOTween.Play(target);
		}

		// Token: 0x06001BCA RID: 7114 RVA: 0x000163C3 File Offset: 0x000145C3
		public static int DOPlayBackwards(this AudioMixer target)
		{
			return DOTween.PlayBackwards(target);
		}

		// Token: 0x06001BCB RID: 7115 RVA: 0x000163CB File Offset: 0x000145CB
		public static int DOPlayForward(this AudioMixer target)
		{
			return DOTween.PlayForward(target);
		}

		// Token: 0x06001BCC RID: 7116 RVA: 0x000163D3 File Offset: 0x000145D3
		public static int DORestart(this AudioMixer target)
		{
			return DOTween.Restart(target, true, -1f);
		}

		// Token: 0x06001BCD RID: 7117 RVA: 0x000163E1 File Offset: 0x000145E1
		public static int DORewind(this AudioMixer target)
		{
			return DOTween.Rewind(target, true);
		}

		// Token: 0x06001BCE RID: 7118 RVA: 0x000163EA File Offset: 0x000145EA
		public static int DOSmoothRewind(this AudioMixer target)
		{
			return DOTween.SmoothRewind(target);
		}

		// Token: 0x06001BCF RID: 7119 RVA: 0x000163F2 File Offset: 0x000145F2
		public static int DOTogglePause(this AudioMixer target)
		{
			return DOTween.TogglePause(target);
		}
	}
}
