using System;
using DG.Tweening;
using TMG.UI;
using UnityEngine;

// Token: 0x020002A9 RID: 681
public abstract class AbstractPromptController : BaseUIController
{
	// Token: 0x06001990 RID: 6544 RVA: 0x0008B4FC File Offset: 0x000896FC
	public override void InitController(object _data)
	{
		base.InitController(_data);
		this.m_Content = base.GetComponent<RectTransform>();
		this.m_VisualsOriginScale = this.m_Visuals.localScale;
		this.m_VisualsStartScale = this.m_Visuals.localScale;
		this.m_VisualsOriginPosition = this.m_Visuals.anchoredPosition;
		this.m_VisualsStartPosition = this.m_Visuals.anchoredPosition;
		if (this.m_PlayInType == AbstractPromptController.PlayInType.SCALE)
		{
			this.m_VisualsStartScale = Vector2.zero;
		}
		else if (this.m_PlayInType == AbstractPromptController.PlayInType.TOP_BOTTOM)
		{
			this.m_VisualsStartPosition = this.m_Visuals.anchoredPosition + new Vector2(0f, this.m_Content.sizeDelta.y);
		}
		else if (this.m_PlayInType == AbstractPromptController.PlayInType.BOTTOM_TOP)
		{
			this.m_VisualsStartPosition = this.m_Visuals.anchoredPosition - new Vector2(0f, this.m_Content.sizeDelta.y);
		}
		this.m_Visuals.anchoredPosition = this.m_VisualsStartPosition;
		this.m_Visuals.localScale = this.m_VisualsStartScale;
	}

	// Token: 0x06001991 RID: 6545 RVA: 0x0008B628 File Offset: 0x00089828
	public override void PlayIn()
	{
		if (this.m_PlayInType == AbstractPromptController.PlayInType.SCALE)
		{
			this.m_Visuals.DOScale(this.m_VisualsOriginScale, 0.5f).SetEase(Ease.OutBack).OnComplete(new TweenCallback(this.PlayInComplete));
		}
		else
		{
			this.m_Visuals.DOAnchorPos(this.m_VisualsOriginPosition, 0.5f, false).SetEase(Ease.OutBack).OnComplete(new TweenCallback(this.PlayInComplete));
		}
	}

	// Token: 0x06001992 RID: 6546 RVA: 0x0008B6A8 File Offset: 0x000898A8
	public override void PlayOut()
	{
		if (this.m_PlayInType == AbstractPromptController.PlayInType.SCALE)
		{
			this.m_Visuals.DOScale(this.m_VisualsStartScale, 0.5f).SetEase(Ease.InBack).OnComplete(new TweenCallback(this.PlayOutComplete));
		}
		else
		{
			this.m_Visuals.DOAnchorPos(this.m_VisualsStartPosition, 0.5f, false).SetEase(Ease.InBack).OnComplete(new TweenCallback(this.PlayOutComplete));
		}
	}

	// Token: 0x0400166B RID: 5739
	[Header("PlayIn Options")]
	[SerializeField]
	protected AbstractPromptController.PlayInType m_PlayInType;

	// Token: 0x0400166C RID: 5740
	[Header("Visuals")]
	[SerializeField]
	protected RectTransform m_Visuals;

	// Token: 0x0400166D RID: 5741
	protected RectTransform m_Content;

	// Token: 0x0400166E RID: 5742
	protected Vector2 m_VisualsOriginPosition;

	// Token: 0x0400166F RID: 5743
	protected Vector2 m_VisualsStartPosition;

	// Token: 0x04001670 RID: 5744
	protected Vector3 m_VisualsOriginScale;

	// Token: 0x04001671 RID: 5745
	protected Vector3 m_VisualsStartScale;

	// Token: 0x020002AA RID: 682
	protected enum PlayInType
	{
		// Token: 0x04001673 RID: 5747
		SCALE,
		// Token: 0x04001674 RID: 5748
		TOP_BOTTOM,
		// Token: 0x04001675 RID: 5749
		BOTTOM_TOP
	}
}
