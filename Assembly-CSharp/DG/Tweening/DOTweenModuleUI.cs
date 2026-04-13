using System;
using DG.Tweening.Core;
using DG.Tweening.Core.Enums;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using UnityEngine.UI;

namespace DG.Tweening
{
	// Token: 0x0200030D RID: 781
	public static class DOTweenModuleUI
	{
		// Token: 0x06001C21 RID: 7201 RVA: 0x00094558 File Offset: 0x00092758
		public static Tweener DOFade(this CanvasGroup target, float endValue, float duration)
		{
			return DOTween.To(() => target.alpha, delegate(float x)
			{
				target.alpha = x;
			}, endValue, duration).SetTarget(target);
		}

		// Token: 0x06001C22 RID: 7202 RVA: 0x0009459C File Offset: 0x0009279C
		public static Tweener DOColor(this Graphic target, Color endValue, float duration)
		{
			return DOTween.To(() => target.color, delegate(Color x)
			{
				target.color = x;
			}, endValue, duration).SetTarget(target);
		}

		// Token: 0x06001C23 RID: 7203 RVA: 0x000945E0 File Offset: 0x000927E0
		public static Tweener DOFade(this Graphic target, float endValue, float duration)
		{
			return DOTween.ToAlpha(() => target.color, delegate(Color x)
			{
				target.color = x;
			}, endValue, duration).SetTarget(target);
		}

		// Token: 0x06001C24 RID: 7204 RVA: 0x00094624 File Offset: 0x00092824
		public static Tweener DOColor(this Image target, Color endValue, float duration)
		{
			return DOTween.To(() => target.color, delegate(Color x)
			{
				target.color = x;
			}, endValue, duration).SetTarget(target);
		}

		// Token: 0x06001C25 RID: 7205 RVA: 0x00094668 File Offset: 0x00092868
		public static Tweener DOFade(this Image target, float endValue, float duration)
		{
			return DOTween.ToAlpha(() => target.color, delegate(Color x)
			{
				target.color = x;
			}, endValue, duration).SetTarget(target);
		}

		// Token: 0x06001C26 RID: 7206 RVA: 0x000946AC File Offset: 0x000928AC
		public static Tweener DOFillAmount(this Image target, float endValue, float duration)
		{
			if (endValue > 1f)
			{
				endValue = 1f;
			}
			else if (endValue < 0f)
			{
				endValue = 0f;
			}
			return DOTween.To(() => target.fillAmount, delegate(float x)
			{
				target.fillAmount = x;
			}, endValue, duration).SetTarget(target);
		}

		// Token: 0x06001C27 RID: 7207 RVA: 0x0009471C File Offset: 0x0009291C
		public static Sequence DOGradientColor(this Image target, Gradient gradient, float duration)
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

		// Token: 0x06001C28 RID: 7208 RVA: 0x000947E4 File Offset: 0x000929E4
		public static Tweener DOFlexibleSize(this LayoutElement target, Vector2 endValue, float duration, bool snapping = false)
		{
			return DOTween.To(() => new Vector2(target.flexibleWidth, target.flexibleHeight), delegate(Vector2 x)
			{
				target.flexibleWidth = x.x;
				target.flexibleHeight = x.y;
			}, endValue, duration).SetOptions(snapping).SetTarget(target);
		}

		// Token: 0x06001C29 RID: 7209 RVA: 0x00094830 File Offset: 0x00092A30
		public static Tweener DOMinSize(this LayoutElement target, Vector2 endValue, float duration, bool snapping = false)
		{
			return DOTween.To(() => new Vector2(target.minWidth, target.minHeight), delegate(Vector2 x)
			{
				target.minWidth = x.x;
				target.minHeight = x.y;
			}, endValue, duration).SetOptions(snapping).SetTarget(target);
		}

		// Token: 0x06001C2A RID: 7210 RVA: 0x0009487C File Offset: 0x00092A7C
		public static Tweener DOPreferredSize(this LayoutElement target, Vector2 endValue, float duration, bool snapping = false)
		{
			return DOTween.To(() => new Vector2(target.preferredWidth, target.preferredHeight), delegate(Vector2 x)
			{
				target.preferredWidth = x.x;
				target.preferredHeight = x.y;
			}, endValue, duration).SetOptions(snapping).SetTarget(target);
		}

		// Token: 0x06001C2B RID: 7211 RVA: 0x000948C8 File Offset: 0x00092AC8
		public static Tweener DOColor(this Outline target, Color endValue, float duration)
		{
			return DOTween.To(() => target.effectColor, delegate(Color x)
			{
				target.effectColor = x;
			}, endValue, duration).SetTarget(target);
		}

		// Token: 0x06001C2C RID: 7212 RVA: 0x0009490C File Offset: 0x00092B0C
		public static Tweener DOFade(this Outline target, float endValue, float duration)
		{
			return DOTween.ToAlpha(() => target.effectColor, delegate(Color x)
			{
				target.effectColor = x;
			}, endValue, duration).SetTarget(target);
		}

		// Token: 0x06001C2D RID: 7213 RVA: 0x00094950 File Offset: 0x00092B50
		public static Tweener DOScale(this Outline target, Vector2 endValue, float duration)
		{
			return DOTween.To(() => target.effectDistance, delegate(Vector2 x)
			{
				target.effectDistance = x;
			}, endValue, duration).SetTarget(target);
		}

		// Token: 0x06001C2E RID: 7214 RVA: 0x00094994 File Offset: 0x00092B94
		public static Tweener DOAnchorPos(this RectTransform target, Vector2 endValue, float duration, bool snapping = false)
		{
			return DOTween.To(() => target.anchoredPosition, delegate(Vector2 x)
			{
				target.anchoredPosition = x;
			}, endValue, duration).SetOptions(snapping).SetTarget(target);
		}

		// Token: 0x06001C2F RID: 7215 RVA: 0x000949E0 File Offset: 0x00092BE0
		public static Tweener DOAnchorPosX(this RectTransform target, float endValue, float duration, bool snapping = false)
		{
			return DOTween.To(() => target.anchoredPosition, delegate(Vector2 x)
			{
				target.anchoredPosition = x;
			}, new Vector2(endValue, 0f), duration).SetOptions(AxisConstraint.X, snapping).SetTarget(target);
		}

		// Token: 0x06001C30 RID: 7216 RVA: 0x00094A38 File Offset: 0x00092C38
		public static Tweener DOAnchorPosY(this RectTransform target, float endValue, float duration, bool snapping = false)
		{
			return DOTween.To(() => target.anchoredPosition, delegate(Vector2 x)
			{
				target.anchoredPosition = x;
			}, new Vector2(0f, endValue), duration).SetOptions(AxisConstraint.Y, snapping).SetTarget(target);
		}

		// Token: 0x06001C31 RID: 7217 RVA: 0x00094A90 File Offset: 0x00092C90
		public static Tweener DOAnchorPos3D(this RectTransform target, Vector3 endValue, float duration, bool snapping = false)
		{
			return DOTween.To(() => target.anchoredPosition3D, delegate(Vector3 x)
			{
				target.anchoredPosition3D = x;
			}, endValue, duration).SetOptions(snapping).SetTarget(target);
		}

		// Token: 0x06001C32 RID: 7218 RVA: 0x00094ADC File Offset: 0x00092CDC
		public static Tweener DOAnchorPos3DX(this RectTransform target, float endValue, float duration, bool snapping = false)
		{
			return DOTween.To(() => target.anchoredPosition3D, delegate(Vector3 x)
			{
				target.anchoredPosition3D = x;
			}, new Vector3(endValue, 0f, 0f), duration).SetOptions(AxisConstraint.X, snapping).SetTarget(target);
		}

		// Token: 0x06001C33 RID: 7219 RVA: 0x00094B38 File Offset: 0x00092D38
		public static Tweener DOAnchorPos3DY(this RectTransform target, float endValue, float duration, bool snapping = false)
		{
			return DOTween.To(() => target.anchoredPosition3D, delegate(Vector3 x)
			{
				target.anchoredPosition3D = x;
			}, new Vector3(0f, endValue, 0f), duration).SetOptions(AxisConstraint.Y, snapping).SetTarget(target);
		}

		// Token: 0x06001C34 RID: 7220 RVA: 0x00094B94 File Offset: 0x00092D94
		public static Tweener DOAnchorPos3DZ(this RectTransform target, float endValue, float duration, bool snapping = false)
		{
			return DOTween.To(() => target.anchoredPosition3D, delegate(Vector3 x)
			{
				target.anchoredPosition3D = x;
			}, new Vector3(0f, 0f, endValue), duration).SetOptions(AxisConstraint.Z, snapping).SetTarget(target);
		}

		// Token: 0x06001C35 RID: 7221 RVA: 0x00094BF0 File Offset: 0x00092DF0
		public static Tweener DOAnchorMax(this RectTransform target, Vector2 endValue, float duration, bool snapping = false)
		{
			return DOTween.To(() => target.anchorMax, delegate(Vector2 x)
			{
				target.anchorMax = x;
			}, endValue, duration).SetOptions(snapping).SetTarget(target);
		}

		// Token: 0x06001C36 RID: 7222 RVA: 0x00094C3C File Offset: 0x00092E3C
		public static Tweener DOAnchorMin(this RectTransform target, Vector2 endValue, float duration, bool snapping = false)
		{
			return DOTween.To(() => target.anchorMin, delegate(Vector2 x)
			{
				target.anchorMin = x;
			}, endValue, duration).SetOptions(snapping).SetTarget(target);
		}

		// Token: 0x06001C37 RID: 7223 RVA: 0x00094C88 File Offset: 0x00092E88
		public static Tweener DOPivot(this RectTransform target, Vector2 endValue, float duration)
		{
			return DOTween.To(() => target.pivot, delegate(Vector2 x)
			{
				target.pivot = x;
			}, endValue, duration).SetTarget(target);
		}

		// Token: 0x06001C38 RID: 7224 RVA: 0x00094CCC File Offset: 0x00092ECC
		public static Tweener DOPivotX(this RectTransform target, float endValue, float duration)
		{
			return DOTween.To(() => target.pivot, delegate(Vector2 x)
			{
				target.pivot = x;
			}, new Vector2(endValue, 0f), duration).SetOptions(AxisConstraint.X, false).SetTarget(target);
		}

		// Token: 0x06001C39 RID: 7225 RVA: 0x00094D24 File Offset: 0x00092F24
		public static Tweener DOPivotY(this RectTransform target, float endValue, float duration)
		{
			return DOTween.To(() => target.pivot, delegate(Vector2 x)
			{
				target.pivot = x;
			}, new Vector2(0f, endValue), duration).SetOptions(AxisConstraint.Y, false).SetTarget(target);
		}

		// Token: 0x06001C3A RID: 7226 RVA: 0x00094D7C File Offset: 0x00092F7C
		public static Tweener DOSizeDelta(this RectTransform target, Vector2 endValue, float duration, bool snapping = false)
		{
			return DOTween.To(() => target.sizeDelta, delegate(Vector2 x)
			{
				target.sizeDelta = x;
			}, endValue, duration).SetOptions(snapping).SetTarget(target);
		}

		// Token: 0x06001C3B RID: 7227 RVA: 0x00094DC8 File Offset: 0x00092FC8
		public static Tweener DOPunchAnchorPos(this RectTransform target, Vector2 punch, float duration, int vibrato = 10, float elasticity = 1f, bool snapping = false)
		{
			return DOTween.Punch(() => target.anchoredPosition, delegate(Vector3 x)
			{
				target.anchoredPosition = x;
			}, punch, duration, vibrato, elasticity).SetTarget(target).SetOptions(snapping);
		}

		// Token: 0x06001C3C RID: 7228 RVA: 0x00094E1C File Offset: 0x0009301C
		public static Tweener DOShakeAnchorPos(this RectTransform target, float duration, float strength = 100f, int vibrato = 10, float randomness = 90f, bool snapping = false, bool fadeOut = true)
		{
			return DOTween.Shake(() => target.anchoredPosition, delegate(Vector3 x)
			{
				target.anchoredPosition = x;
			}, duration, strength, vibrato, randomness, true, fadeOut).SetTarget(target).SetSpecialStartupMode(SpecialStartupMode.SetShake)
				.SetOptions(snapping);
		}

		// Token: 0x06001C3D RID: 7229 RVA: 0x00094E74 File Offset: 0x00093074
		public static Tweener DOShakeAnchorPos(this RectTransform target, float duration, Vector2 strength, int vibrato = 10, float randomness = 90f, bool snapping = false, bool fadeOut = true)
		{
			return DOTween.Shake(() => target.anchoredPosition, delegate(Vector3 x)
			{
				target.anchoredPosition = x;
			}, duration, strength, vibrato, randomness, fadeOut).SetTarget(target).SetSpecialStartupMode(SpecialStartupMode.SetShake)
				.SetOptions(snapping);
		}

		// Token: 0x06001C3E RID: 7230 RVA: 0x00094ED0 File Offset: 0x000930D0
		public static Sequence DOJumpAnchorPos(this RectTransform target, Vector2 endValue, float jumpPower, int numJumps, float duration, bool snapping = false)
		{
			if (numJumps < 1)
			{
				numJumps = 1;
			}
			float startPosY = 0f;
			float offsetY = -1f;
			bool offsetYSet = false;
			Sequence s = DOTween.Sequence();
			Tween tween = DOTween.To(() => target.anchoredPosition, delegate(Vector2 x)
			{
				target.anchoredPosition = x;
			}, new Vector2(0f, jumpPower), duration / (float)(numJumps * 2)).SetOptions(AxisConstraint.Y, snapping).SetEase(Ease.OutQuad)
				.SetRelative<Tweener>()
				.SetLoops(numJumps * 2, LoopType.Yoyo)
				.OnStart(delegate
				{
					startPosY = target.anchoredPosition.y;
				});
			s.Append(DOTween.To(() => target.anchoredPosition, delegate(Vector2 x)
			{
				target.anchoredPosition = x;
			}, new Vector2(endValue.x, 0f), duration).SetOptions(AxisConstraint.X, snapping).SetEase(Ease.Linear)).Join(tween).SetTarget(target)
				.SetEase(DOTween.defaultEaseType);
			s.OnUpdate(delegate
			{
				if (!offsetYSet)
				{
					offsetYSet = true;
					offsetY = ((!s.isRelative) ? (endValue.y - startPosY) : endValue.y);
				}
				Vector2 anchoredPosition = target.anchoredPosition;
				anchoredPosition.y += DOVirtual.EasedValue(0f, offsetY, s.ElapsedDirectionalPercentage(), Ease.OutQuad);
				target.anchoredPosition = anchoredPosition;
			});
			return s;
		}

		// Token: 0x06001C3F RID: 7231 RVA: 0x00095008 File Offset: 0x00093208
		public static Tweener DONormalizedPos(this ScrollRect target, Vector2 endValue, float duration, bool snapping = false)
		{
			return DOTween.To(() => new Vector2(target.horizontalNormalizedPosition, target.verticalNormalizedPosition), delegate(Vector2 x)
			{
				target.horizontalNormalizedPosition = x.x;
				target.verticalNormalizedPosition = x.y;
			}, endValue, duration).SetOptions(snapping).SetTarget(target);
		}

		// Token: 0x06001C40 RID: 7232 RVA: 0x00095054 File Offset: 0x00093254
		public static Tweener DOHorizontalNormalizedPos(this ScrollRect target, float endValue, float duration, bool snapping = false)
		{
			return DOTween.To(() => target.horizontalNormalizedPosition, delegate(float x)
			{
				target.horizontalNormalizedPosition = x;
			}, endValue, duration).SetOptions(snapping).SetTarget(target);
		}

		// Token: 0x06001C41 RID: 7233 RVA: 0x000950A0 File Offset: 0x000932A0
		public static Tweener DOVerticalNormalizedPos(this ScrollRect target, float endValue, float duration, bool snapping = false)
		{
			return DOTween.To(() => target.verticalNormalizedPosition, delegate(float x)
			{
				target.verticalNormalizedPosition = x;
			}, endValue, duration).SetOptions(snapping).SetTarget(target);
		}

		// Token: 0x06001C42 RID: 7234 RVA: 0x000950EC File Offset: 0x000932EC
		public static Tweener DOValue(this Slider target, float endValue, float duration, bool snapping = false)
		{
			return DOTween.To(() => target.value, delegate(float x)
			{
				target.value = x;
			}, endValue, duration).SetOptions(snapping).SetTarget(target);
		}

		// Token: 0x06001C43 RID: 7235 RVA: 0x00095138 File Offset: 0x00093338
		public static Tweener DOColor(this Text target, Color endValue, float duration)
		{
			return DOTween.To(() => target.color, delegate(Color x)
			{
				target.color = x;
			}, endValue, duration).SetTarget(target);
		}

		// Token: 0x06001C44 RID: 7236 RVA: 0x0009517C File Offset: 0x0009337C
		public static Tweener DOFade(this Text target, float endValue, float duration)
		{
			return DOTween.ToAlpha(() => target.color, delegate(Color x)
			{
				target.color = x;
			}, endValue, duration).SetTarget(target);
		}

		// Token: 0x06001C45 RID: 7237 RVA: 0x000951C0 File Offset: 0x000933C0
		public static Tweener DOText(this Text target, string endValue, float duration, bool richTextEnabled = true, ScrambleMode scrambleMode = ScrambleMode.None, string scrambleChars = null)
		{
			return DOTween.To(() => target.text, delegate(string x)
			{
				target.text = x;
			}, endValue, duration).SetOptions(richTextEnabled, scrambleMode, scrambleChars).SetTarget(target);
		}

		// Token: 0x06001C46 RID: 7238 RVA: 0x00095210 File Offset: 0x00093410
		public static Tweener DOBlendableColor(this Graphic target, Color endValue, float duration)
		{
			endValue -= target.color;
			Color to = new Color(0f, 0f, 0f, 0f);
			return DOTween.To(() => to, delegate(Color x)
			{
				Color color = x - to;
				to = x;
				target.color += color;
			}, endValue, duration).Blendable<Color, Color, ColorOptions>().SetTarget(target);
		}

		// Token: 0x06001C47 RID: 7239 RVA: 0x0009528C File Offset: 0x0009348C
		public static Tweener DOBlendableColor(this Image target, Color endValue, float duration)
		{
			endValue -= target.color;
			Color to = new Color(0f, 0f, 0f, 0f);
			return DOTween.To(() => to, delegate(Color x)
			{
				Color color = x - to;
				to = x;
				target.color += color;
			}, endValue, duration).Blendable<Color, Color, ColorOptions>().SetTarget(target);
		}

		// Token: 0x06001C48 RID: 7240 RVA: 0x00095308 File Offset: 0x00093508
		public static Tweener DOBlendableColor(this Text target, Color endValue, float duration)
		{
			endValue -= target.color;
			Color to = new Color(0f, 0f, 0f, 0f);
			return DOTween.To(() => to, delegate(Color x)
			{
				Color color = x - to;
				to = x;
				target.color += color;
			}, endValue, duration).Blendable<Color, Color, ColorOptions>().SetTarget(target);
		}

		// Token: 0x0200030E RID: 782
		public static class Utils
		{
			// Token: 0x06001C49 RID: 7241 RVA: 0x00095384 File Offset: 0x00093584
			public static Vector2 SwitchToRectTransform(RectTransform from, RectTransform to)
			{
				Vector2 vector = new Vector2(from.rect.width * 0.5f + from.rect.xMin, from.rect.height * 0.5f + from.rect.yMin);
				Vector2 vector2 = RectTransformUtility.WorldToScreenPoint(null, from.position);
				vector2 += vector;
				Vector2 vector3;
				RectTransformUtility.ScreenPointToLocalPointInRectangle(to, vector2, null, out vector3);
				Vector2 vector4 = new Vector2(to.rect.width * 0.5f + to.rect.xMin, to.rect.height * 0.5f + to.rect.yMin);
				return to.anchoredPosition + vector3 - vector4;
			}
		}
	}
}
