using System;
using DG.Tweening;
using TMG.Core;
using UnityEngine;

// Token: 0x0200007C RID: 124
public class CH1BarrelInk : TMGMonoBehaviour
{
	// Token: 0x06000460 RID: 1120 RVA: 0x0003003C File Offset: 0x0002E23C
	public void Activate(ImpactType impactType)
	{
		if (impactType == ImpactType.NONE)
		{
			return;
		}
		this.m_AxeDecal.SetActive(impactType == ImpactType.AXE);
		this.m_BluntDecal.SetActive(impactType == ImpactType.BLUNT);
		Sequence sequence = DOTween.Sequence();
		sequence.Insert(3.5f, this.m_AudioSource.DOFade(0f, 1f));
		sequence.InsertCallback(10f, new TweenCallback(base.Dispose));
	}

	// Token: 0x06000461 RID: 1121 RVA: 0x000061DE File Offset: 0x000043DE
	protected override void OnDisposed()
	{
		this.m_AudioSource.DOKill(false);
		base.OnDisposed();
	}

	// Token: 0x040002E3 RID: 739
	[SerializeField]
	private AudioSource m_AudioSource;

	// Token: 0x040002E4 RID: 740
	[SerializeField]
	private GameObject m_AxeDecal;

	// Token: 0x040002E5 RID: 741
	[SerializeField]
	private GameObject m_BluntDecal;
}
