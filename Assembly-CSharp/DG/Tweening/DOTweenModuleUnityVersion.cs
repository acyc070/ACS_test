using System;
using DG.Tweening.Core;
using UnityEngine;

namespace DG.Tweening
{
	// Token: 0x02000336 RID: 822
	public static class DOTweenModuleUnityVersion
	{
		// Token: 0x06001CC3 RID: 7363 RVA: 0x000955D4 File Offset: 0x000937D4
		public static Sequence DOGradientColor(this Material target, Gradient gradient, float duration)
		{
			Sequence sequence = DOTween.Sequence();
			GradientColorKey[] colorKeys = gradient.colorKeys;
			int num = colorKeys.Length;
			for (int i = 0; i < num; i++)
			{
				GradientColorKey gradientColorKey = colorKeys[i];
				if (i == 0 && gradientColorKey.time <= 0f)
				{
					target.color = gradientColorKey.color;
				}
				else
				{
					float num2 = ((i != num - 1) ? (duration * ((i != 0) ? (gradientColorKey.time - colorKeys[i - 1].time) : gradientColorKey.time)) : (duration - sequence.Duration(false)));
					sequence.Append(target.DOColor(gradientColorKey.color, num2).SetEase(Ease.Linear));
				}
			}
			return sequence;
		}

		// Token: 0x06001CC4 RID: 7364 RVA: 0x0009569C File Offset: 0x0009389C
		public static Sequence DOGradientColor(this Material target, Gradient gradient, string property, float duration)
		{
			Sequence sequence = DOTween.Sequence();
			GradientColorKey[] colorKeys = gradient.colorKeys;
			int num = colorKeys.Length;
			for (int i = 0; i < num; i++)
			{
				GradientColorKey gradientColorKey = colorKeys[i];
				if (i == 0 && gradientColorKey.time <= 0f)
				{
					target.SetColor(property, gradientColorKey.color);
				}
				else
				{
					float num2 = ((i != num - 1) ? (duration * ((i != 0) ? (gradientColorKey.time - colorKeys[i - 1].time) : gradientColorKey.time)) : (duration - sequence.Duration(false)));
					sequence.Append(target.DOColor(gradientColorKey.color, property, num2).SetEase(Ease.Linear));
				}
			}
			return sequence;
		}

		// Token: 0x06001CC5 RID: 7365 RVA: 0x00016A77 File Offset: 0x00014C77
		public static CustomYieldInstruction WaitForCompletion(this Tween t, bool returnCustomYieldInstruction)
		{
			if (!t.active)
			{
				if (Debugger.logPriority > 0)
				{
					Debugger.LogInvalidTween(t);
				}
				return null;
			}
			return new DOTweenCYInstruction.WaitForCompletion(t);
		}

		// Token: 0x06001CC6 RID: 7366 RVA: 0x00016A9D File Offset: 0x00014C9D
		public static CustomYieldInstruction WaitForRewind(this Tween t, bool returnCustomYieldInstruction)
		{
			if (!t.active)
			{
				if (Debugger.logPriority > 0)
				{
					Debugger.LogInvalidTween(t);
				}
				return null;
			}
			return new DOTweenCYInstruction.WaitForRewind(t);
		}

		// Token: 0x06001CC7 RID: 7367 RVA: 0x00016AC3 File Offset: 0x00014CC3
		public static CustomYieldInstruction WaitForKill(this Tween t, bool returnCustomYieldInstruction)
		{
			if (!t.active)
			{
				if (Debugger.logPriority > 0)
				{
					Debugger.LogInvalidTween(t);
				}
				return null;
			}
			return new DOTweenCYInstruction.WaitForKill(t);
		}

		// Token: 0x06001CC8 RID: 7368 RVA: 0x00016AE9 File Offset: 0x00014CE9
		public static CustomYieldInstruction WaitForElapsedLoops(this Tween t, int elapsedLoops, bool returnCustomYieldInstruction)
		{
			if (!t.active)
			{
				if (Debugger.logPriority > 0)
				{
					Debugger.LogInvalidTween(t);
				}
				return null;
			}
			return new DOTweenCYInstruction.WaitForElapsedLoops(t, elapsedLoops);
		}

		// Token: 0x06001CC9 RID: 7369 RVA: 0x00016B10 File Offset: 0x00014D10
		public static CustomYieldInstruction WaitForPosition(this Tween t, float position, bool returnCustomYieldInstruction)
		{
			if (!t.active)
			{
				if (Debugger.logPriority > 0)
				{
					Debugger.LogInvalidTween(t);
				}
				return null;
			}
			return new DOTweenCYInstruction.WaitForPosition(t, position);
		}

		// Token: 0x06001CCA RID: 7370 RVA: 0x00016B37 File Offset: 0x00014D37
		public static CustomYieldInstruction WaitForStart(this Tween t, bool returnCustomYieldInstruction)
		{
			if (!t.active)
			{
				if (Debugger.logPriority > 0)
				{
					Debugger.LogInvalidTween(t);
				}
				return null;
			}
			return new DOTweenCYInstruction.WaitForStart(t);
		}
	}
}
