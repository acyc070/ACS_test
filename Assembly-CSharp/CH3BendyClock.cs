using System;
using TMG.Core;
using UnityEngine;

// Token: 0x020000DD RID: 221
public class CH3BendyClock : TMGMonoBehaviour
{
	// Token: 0x060008CA RID: 2250 RVA: 0x0004AAB0 File Offset: 0x00048CB0
	private void Update()
	{
		DateTime now = DateTime.Now;
		this.m_HourHand.localRotation = Quaternion.Euler((float)now.Hour * 30f, 0f, 0f);
		this.m_MinuteHand.localRotation = Quaternion.Euler((float)now.Minute * 6f, 0f, 0f);
	}

	// Token: 0x060008CB RID: 2251 RVA: 0x000061D6 File Offset: 0x000043D6
	protected override void OnDisposed()
	{
		base.OnDisposed();
	}

	// Token: 0x0400072A RID: 1834
	private const float m_HoursToDegrees = 30f;

	// Token: 0x0400072B RID: 1835
	private const float m_MinutesToDegrees = 6f;

	// Token: 0x0400072C RID: 1836
	[SerializeField]
	private Transform m_HourHand;

	// Token: 0x0400072D RID: 1837
	[SerializeField]
	private Transform m_MinuteHand;
}
