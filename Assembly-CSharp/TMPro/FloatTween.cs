using System;
using UnityEngine;
using UnityEngine.Events;

namespace TMPro
{
	// Token: 0x020005F4 RID: 1524
	internal struct FloatTween : ITweenValue
	{
		// Token: 0x17000436 RID: 1078
		// (get) Token: 0x06002A70 RID: 10864 RVA: 0x0001E6DF File Offset: 0x0001C8DF
		// (set) Token: 0x06002A71 RID: 10865 RVA: 0x0001E6E7 File Offset: 0x0001C8E7
		public float startValue
		{
			get
			{
				return this.m_StartValue;
			}
			set
			{
				this.m_StartValue = value;
			}
		}

		// Token: 0x17000437 RID: 1079
		// (get) Token: 0x06002A72 RID: 10866 RVA: 0x0001E6F0 File Offset: 0x0001C8F0
		// (set) Token: 0x06002A73 RID: 10867 RVA: 0x0001E6F8 File Offset: 0x0001C8F8
		public float targetValue
		{
			get
			{
				return this.m_TargetValue;
			}
			set
			{
				this.m_TargetValue = value;
			}
		}

		// Token: 0x17000438 RID: 1080
		// (get) Token: 0x06002A74 RID: 10868 RVA: 0x0001E701 File Offset: 0x0001C901
		// (set) Token: 0x06002A75 RID: 10869 RVA: 0x0001E709 File Offset: 0x0001C909
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

		// Token: 0x17000439 RID: 1081
		// (get) Token: 0x06002A76 RID: 10870 RVA: 0x0001E712 File Offset: 0x0001C912
		// (set) Token: 0x06002A77 RID: 10871 RVA: 0x0001E71A File Offset: 0x0001C91A
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

		// Token: 0x06002A78 RID: 10872 RVA: 0x000FF7E0 File Offset: 0x000FD9E0
		public void TweenValue(float floatPercentage)
		{
			if (!this.ValidTarget())
			{
				return;
			}
			float num = Mathf.Lerp(this.m_StartValue, this.m_TargetValue, floatPercentage);
			this.m_Target.Invoke(num);
		}

		// Token: 0x06002A79 RID: 10873 RVA: 0x0001E723 File Offset: 0x0001C923
		public void AddOnChangedCallback(UnityAction<float> callback)
		{
			if (this.m_Target == null)
			{
				this.m_Target = new FloatTween.FloatTweenCallback();
			}
			this.m_Target.AddListener(callback);
		}

		// Token: 0x06002A7A RID: 10874 RVA: 0x0001E712 File Offset: 0x0001C912
		public bool GetIgnoreTimescale()
		{
			return this.m_IgnoreTimeScale;
		}

		// Token: 0x06002A7B RID: 10875 RVA: 0x0001E701 File Offset: 0x0001C901
		public float GetDuration()
		{
			return this.m_Duration;
		}

		// Token: 0x06002A7C RID: 10876 RVA: 0x0001E747 File Offset: 0x0001C947
		public bool ValidTarget()
		{
			return this.m_Target != null;
		}

		// Token: 0x04002F0A RID: 12042
		private FloatTween.FloatTweenCallback m_Target;

		// Token: 0x04002F0B RID: 12043
		private float m_StartValue;

		// Token: 0x04002F0C RID: 12044
		private float m_TargetValue;

		// Token: 0x04002F0D RID: 12045
		private float m_Duration;

		// Token: 0x04002F0E RID: 12046
		private bool m_IgnoreTimeScale;

		// Token: 0x020005F5 RID: 1525
		public class FloatTweenCallback : UnityEvent<float>
		{
		}
	}
}
