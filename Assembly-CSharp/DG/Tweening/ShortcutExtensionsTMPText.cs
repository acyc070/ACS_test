using System;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using TMPro;
using UnityEngine;

namespace DG.Tweening
{
	// Token: 0x02000345 RID: 837
	public static class ShortcutExtensionsTMPText
	{
		// Token: 0x06001D05 RID: 7429 RVA: 0x00096C64 File Offset: 0x00094E64
		public static Tweener DOColor(this TMP_Text target, Color endValue, float duration)
		{
			return DOTween.To(() => target.color, delegate(Color x)
			{
				target.color = x;
			}, endValue, duration).SetTarget(target);
		}

		// Token: 0x06001D06 RID: 7430 RVA: 0x00096CA8 File Offset: 0x00094EA8
		public static Tweener DOFaceColor(this TMP_Text target, Color32 endValue, float duration)
		{
			return DOTween.To(() => target.faceColor, delegate(Color x)
			{
				target.faceColor = x;
			}, endValue, duration).SetTarget(target);
		}

		// Token: 0x06001D07 RID: 7431 RVA: 0x00096CF4 File Offset: 0x00094EF4
		public static Tweener DOOutlineColor(this TMP_Text target, Color32 endValue, float duration)
		{
			return DOTween.To(() => target.outlineColor, delegate(Color x)
			{
				target.outlineColor = x;
			}, endValue, duration).SetTarget(target);
		}

		// Token: 0x06001D08 RID: 7432 RVA: 0x00016F20 File Offset: 0x00015120
		public static Tweener DOGlowColor(this TMP_Text target, Color endValue, float duration, bool useSharedMaterial = false)
		{
			return (!useSharedMaterial) ? target.fontMaterial.DOColor(endValue, "_GlowColor", duration).SetTarget(target) : target.fontSharedMaterial.DOColor(endValue, "_GlowColor", duration).SetTarget(target);
		}

		// Token: 0x06001D09 RID: 7433 RVA: 0x00096D40 File Offset: 0x00094F40
		public static Tweener DOFade(this TMP_Text target, float endValue, float duration)
		{
			return DOTween.ToAlpha(() => target.color, delegate(Color x)
			{
				target.color = x;
			}, endValue, duration).SetTarget(target);
		}

		// Token: 0x06001D0A RID: 7434 RVA: 0x00096D84 File Offset: 0x00094F84
		public static Tweener DOFaceFade(this TMP_Text target, float endValue, float duration)
		{
			return DOTween.ToAlpha(() => target.faceColor, delegate(Color x)
			{
				target.faceColor = x;
			}, endValue, duration).SetTarget(target);
		}

		// Token: 0x06001D0B RID: 7435 RVA: 0x00096DC8 File Offset: 0x00094FC8
		public static Tweener DOScale(this TMP_Text target, float endValue, float duration)
		{
			Transform t = target.transform;
			Vector3 vector = new Vector3(endValue, endValue, endValue);
			return DOTween.To(() => t.localScale, delegate(Vector3 x)
			{
				t.localScale = x;
			}, vector, duration).SetTarget(target);
		}

		// Token: 0x06001D0C RID: 7436 RVA: 0x00096E18 File Offset: 0x00095018
		public static Tweener DOFontSize(this TMP_Text target, float endValue, float duration)
		{
			return DOTween.To(() => target.fontSize, delegate(float x)
			{
				target.fontSize = x;
			}, endValue, duration).SetTarget(target);
		}

		// Token: 0x06001D0D RID: 7437 RVA: 0x00096E5C File Offset: 0x0009505C
		public static Tweener DOMaxVisibleCharacters(this TMP_Text target, int endValue, float duration)
		{
			return DOTween.To(() => target.maxVisibleCharacters, delegate(int x)
			{
				target.maxVisibleCharacters = x;
			}, endValue, duration).SetTarget(target);
		}

		// Token: 0x06001D0E RID: 7438 RVA: 0x00096EA0 File Offset: 0x000950A0
		public static Tweener DOText(this TMP_Text target, string endValue, float duration, bool richTextEnabled = true, ScrambleMode scrambleMode = ScrambleMode.None, string scrambleChars = null)
		{
			return DOTween.To(() => target.text, delegate(string x)
			{
				target.text = x;
			}, endValue, duration).SetOptions(richTextEnabled, scrambleMode, scrambleChars).SetTarget(target);
		}
	}
}
