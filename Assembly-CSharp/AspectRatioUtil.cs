using System;
using UnityEngine;

// Token: 0x020002D0 RID: 720
public static class AspectRatioUtil
{
	// Token: 0x170001AE RID: 430
	// (get) Token: 0x06001AF9 RID: 6905 RVA: 0x00015C3B File Offset: 0x00013E3B
	public static float AspectRatio
	{
		get
		{
			return (float)Screen.width / (float)Screen.height;
		}
	}

	// Token: 0x06001AFA RID: 6906 RVA: 0x00015C4A File Offset: 0x00013E4A
	public static float GetPercent()
	{
		return (AspectRatioUtil.AspectRatio - 1.6f) / 0.17699993f;
	}

	// Token: 0x06001AFB RID: 6907 RVA: 0x00015C5D File Offset: 0x00013E5D
	public static float GetScale()
	{
		return 0.9f + AspectRatioUtil.GetPercent() * 0.100000024f;
	}

	// Token: 0x06001AFC RID: 6908 RVA: 0x00015C70 File Offset: 0x00013E70
	public static float GetScaledScreenHeight(float max, float min)
	{
		return min + (1f - AspectRatioUtil.GetPercent()) * (max - min);
	}

	// Token: 0x06001AFD RID: 6909 RVA: 0x00091114 File Offset: 0x0008F314
	public static Vector3 GetFullScale()
	{
		float scale = AspectRatioUtil.GetScale();
		return new Vector3(scale, scale, scale);
	}

	// Token: 0x04001795 RID: 6037
	private const float ASPECT_RATIO_MAX = 1.777f;

	// Token: 0x04001796 RID: 6038
	private const float ASPECT_RATIO_MIN = 1.6f;

	// Token: 0x04001797 RID: 6039
	private const float SCALE_MAX = 1f;

	// Token: 0x04001798 RID: 6040
	private const float SCALE_MIN = 0.9f;
}
