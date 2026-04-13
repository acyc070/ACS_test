using System;
using UnityEngine;
using UnityEngine.Events;

namespace TMPro
{
	// Token: 0x020005F1 RID: 1521
	internal struct ColorTween : ITweenValue
	{
		// Token: 0x17000431 RID: 1073
		// (get) Token: 0x06002A60 RID: 10848 RVA: 0x0001E650 File Offset: 0x0001C850
		// (set) Token: 0x06002A61 RID: 10849 RVA: 0x0001E658 File Offset: 0x0001C858
		public Color startColor
		{
			get
			{
				return this.m_StartColor;
			}
			set
			{
				this.m_StartColor = value;
			}
		}

		// Token: 0x17000432 RID: 1074
		// (get) Token: 0x06002A62 RID: 10850 RVA: 0x0001E661 File Offset: 0x0001C861
		// (set) Token: 0x06002A63 RID: 10851 RVA: 0x0001E669 File Offset: 0x0001C869
		public Color targetColor
		{
			get
			{
				return this.m_TargetColor;
			}
			set
			{
				this.m_TargetColor = value;
			}
		}

		// Token: 0x17000433 RID: 1075
		// (get) Token: 0x06002A64 RID: 10852 RVA: 0x0001E672 File Offset: 0x0001C872
		// (set) Token: 0x06002A65 RID: 10853 RVA: 0x0001E67A File Offset: 0x0001C87A
		public ColorTween.ColorTweenMode tweenMode
		{
			get
			{
				return this.m_TweenMode;
			}
			set
			{
				this.m_TweenMode = value;
			}
		}

		// Token: 0x17000434 RID: 1076
		// (get) Token: 0x06002A66 RID: 10854 RVA: 0x0001E683 File Offset: 0x0001C883
		// (set) Token: 0x06002A67 RID: 10855 RVA: 0x0001E68B File Offset: 0x0001C88B
		public float duration
		{
			get
			{
				return this.m_Duration;
			}
			set
			{
				this.m_Duration = value;
			}
		}

		// Token: 0x17000435 RID: 1077
		// (get) Token: 0x06002A68 RID: 10856 RVA: 0x0001E694 File Offset: 0x0001C894
		// (set) Token: 0x06002A69 RID: 10857 RVA: 0x0001E69C File Offset: 0x0001C89C
		public bool ignoreTimeScale
		{
			get
			{
				return this.m_IgnoreTimeScale;
			}
			set
			{
				this.m_IgnoreTimeScale = value;
			}
		}

		// Token: 0x06002A6A RID: 10858 RVA: 0x000FF740 File Offset: 0x000FD940
		public void TweenValue(float floatPercentage)
		{
			if (!this.ValidTarget())
			{
				return;
			}
			Color color = Color.Lerp(this.m_StartColor, this.m_TargetColor, floatPercentage);
			if (this.m_TweenMode == ColorTween.ColorTweenMode.Alpha)
			{
				color.r = this.m_StartColor.r;
				color.g = this.m_StartColor.g;
				color.b = this.m_StartColor.b;
			}
			else if (this.m_TweenMode == ColorTween.ColorTweenMode.RGB)
			{
				color.a = this.m_StartColor.a;
			}
			this.m_Target.Invoke(color);
		}

		// Token: 0x06002A6B RID: 10859 RVA: 0x0001E6A5 File Offset: 0x0001C8A5
		public void AddOnChangedCallback(UnityAction<Color> callback)
		{
			if (this.m_Target == null)
			{
				this.m_Target = new ColorTween.ColorTweenCallback();
			}
			this.m_Target.AddListener(callback);
		}

		// Token: 0x06002A6C RID: 10860 RVA: 0x0001E694 File Offset: 0x0001C894
		public bool GetIgnoreTimescale()
		{
			return this.m_IgnoreTimeScale;
		}

		// Token: 0x06002A6D RID: 10861 RVA: 0x0001E683 File Offset: 0x0001C883
		public float GetDuration()
		{
			return this.m_Duration;
		}

		// Token: 0x06002A6E RID: 10862 RVA: 0x0001E6C9 File Offset: 0x0001C8C9
		public bool ValidTarget()
		{
			return this.m_Target != null;
		}

		// Token: 0x04002F00 RID: 12032
		private ColorTween.ColorTweenCallback m_Target;

		// Token: 0x04002F01 RID: 12033
		private Color m_StartColor;

		// Token: 0x04002F02 RID: 12034
		private Color m_TargetColor;

		// Token: 0x04002F03 RID: 12035
		private ColorTween.ColorTweenMode m_TweenMode;

		// Token: 0x04002F04 RID: 12036
		private float m_Duration;

		// Token: 0x04002F05 RID: 12037
		private bool m_IgnoreTimeScale;

		// Token: 0x020005F2 RID: 1522
		public enum ColorTweenMode
		{
			// Token: 0x04002F07 RID: 12039
			All,
			// Token: 0x04002F08 RID: 12040
			RGB,
			// Token: 0x04002F09 RID: 12041
			Alpha
		}

		// Token: 0x020005F3 RID: 1523
		public class ColorTweenCallback : UnityEvent<Color>
		{
		}
	}
}
