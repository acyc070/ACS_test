using System;
using System.Collections.Generic;
using DG.Tweening;
using TMG.UI;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020002A2 RID: 674
public class CH1ConclusionModalController : BaseUIController
{
	// Token: 0x06001968 RID: 6504 RVA: 0x0008AE24 File Offset: 0x00089024
	public override void InitController(object _data)
	{
		base.InitController(_data);
		for (int i = 0; i < this.m_Images.Count; i++)
		{
			this.m_Images[i].enabled = false;
		}
	}

	// Token: 0x06001969 RID: 6505 RVA: 0x0008AE68 File Offset: 0x00089068
	public void ShowImage(int index)
	{
		Image image = this.m_Images[index];
		image.enabled = true;
		image.transform.DOScale(1.05f, 0.25f).SetEase(Ease.Linear);
		image.DOFade(0f, 0.125f).SetDelay(0.15f).OnComplete(delegate
		{
			image.enabled = false;
		});
	}

	// Token: 0x0600196A RID: 6506 RVA: 0x000061D6 File Offset: 0x000043D6
	protected override void OnDisposed()
	{
		base.OnDisposed();
	}

	// Token: 0x04001650 RID: 5712
	[Header("RectTransforms")]
	[SerializeField]
	private List<Image> m_Images;
}
