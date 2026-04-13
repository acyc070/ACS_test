using System;
using DG.Tweening;
using TMG.Core;
using UnityEngine;

// Token: 0x02000262 RID: 610
public class BuoyantObject : TMGMonoBehaviour
{
	// Token: 0x060017EF RID: 6127 RVA: 0x000135B2 File Offset: 0x000117B2
	public override void OnEnable()
	{
		if (this.m_OnStart)
		{
			this.Buoyancy(true);
		}
	}

	// Token: 0x060017F0 RID: 6128 RVA: 0x00085754 File Offset: 0x00083954
	public void Buoyancy(bool isPositive)
	{
		base.transform.DOKill(false);
		base.transform.DOLocalRotate(this.GetRandomRotation(isPositive), 2f, RotateMode.Fast).SetEase(Ease.InOutQuad).OnComplete(delegate
		{
			this.Buoyancy(!isPositive);
		});
	}

	// Token: 0x060017F1 RID: 6129 RVA: 0x000857B8 File Offset: 0x000839B8
	private Vector3 GetRandomRotation(bool isPositive)
	{
		float num = ((!isPositive) ? (-1f) : 0f);
		float num2 = ((!isPositive) ? 0f : 1f);
		return new Vector3(this.GetRandomValue(num, num2), 0f, this.GetRandomValue(-1f, 1f));
	}

	// Token: 0x060017F2 RID: 6130 RVA: 0x00009A1E File Offset: 0x00007C1E
	private float GetRandomValue(float min, float max)
	{
		return global::UnityEngine.Random.Range(min, max);
	}

	// Token: 0x060017F3 RID: 6131 RVA: 0x0000B095 File Offset: 0x00009295
	protected override void OnDisposed()
	{
		base.transform.DOKill(false);
		base.OnDisposed();
	}

	// Token: 0x04001500 RID: 5376
	[SerializeField]
	private bool m_OnStart;
}
