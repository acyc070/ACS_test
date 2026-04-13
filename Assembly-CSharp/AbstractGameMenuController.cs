using System;
using DG.Tweening;
using TMG.UI;
using UnityEngine;

// Token: 0x02000298 RID: 664
public abstract class AbstractGameMenuController : BaseUIController
{
	// Token: 0x0600190C RID: 6412 RVA: 0x0008869C File Offset: 0x0008689C
	public override void InitController(object _data)
	{
		base.InitController(_data);
		this.m_Content = base.GetComponent<RectTransform>();
		this.m_VisualsOriginScale = this.m_Visuals.localScale;
		this.m_VisualsStartScale = this.m_Visuals.localScale;
		this.m_VisualsOriginPosition = this.m_Visuals.anchoredPosition;
		this.m_VisualsStartPosition = this.m_Visuals.anchoredPosition;
		Vector2 zero = Vector2.zero;
		if (this.m_AnchorSizeType == AbstractGameMenuController.AnchorSizeType.CONTENT)
		{
			zero = new Vector2(0f, this.m_Content.sizeDelta.y);
		}
		else if (this.m_AnchorSizeType == AbstractGameMenuController.AnchorSizeType.VISUALS)
		{
			zero = new Vector2(0f, this.m_Visuals.sizeDelta.y);
		}
		if (this.m_PlayInType == AbstractGameMenuController.PlayInType.SCALE)
		{
			this.m_VisualsStartScale = Vector2.zero;
		}
		else if (this.m_PlayInType == AbstractGameMenuController.PlayInType.TOP_BOTTOM)
		{
			this.m_VisualsStartPosition = this.m_Visuals.anchoredPosition + zero;
		}
		else if (this.m_PlayInType == AbstractGameMenuController.PlayInType.BOTTOM_TOP)
		{
			this.m_VisualsStartPosition = this.m_Visuals.anchoredPosition - zero;
		}
		this.m_Visuals.anchoredPosition = this.m_VisualsStartPosition;
		this.m_Visuals.localScale = this.m_VisualsStartScale;
	}

	// Token: 0x0600190D RID: 6413 RVA: 0x000887F0 File Offset: 0x000869F0
	public override void PlayIn()
	{
		if (this.m_PlayInType == AbstractGameMenuController.PlayInType.SCALE)
		{
			this.m_Visuals.DOScale(this.m_VisualsOriginScale, 0.5f).SetEase(Ease.OutQuad).SetDelay(this.m_PlayInDelay)
				.SetUpdate(UpdateType.Normal)
				.OnComplete(new TweenCallback(this.PlayInComplete));
		}
		else
		{
			this.m_Visuals.DOAnchorPos(this.m_VisualsOriginPosition, 0.5f, false).SetEase(Ease.OutQuad).SetDelay(this.m_PlayInDelay)
				.SetUpdate(UpdateType.Normal)
				.OnComplete(new TweenCallback(this.PlayInComplete));
		}
	}

	// Token: 0x0600190E RID: 6414 RVA: 0x00088890 File Offset: 0x00086A90
	public override void PlayOut()
	{
		if (this.m_PlayInType == AbstractGameMenuController.PlayInType.SCALE)
		{
			this.m_Visuals.DOScale(this.m_VisualsStartScale, 0.5f).SetEase(Ease.InQuad).SetDelay(this.m_PlayoutDelay)
				.SetUpdate(UpdateType.Normal)
				.OnComplete(new TweenCallback(this.PlayOutComplete));
		}
		else
		{
			this.m_Visuals.DOAnchorPos(this.m_VisualsStartPosition, 0.5f, false).SetEase(Ease.InQuad).SetDelay(this.m_PlayoutDelay)
				.SetUpdate(UpdateType.Normal)
				.OnComplete(new TweenCallback(this.PlayOutComplete));
		}
	}

	// Token: 0x0600190F RID: 6415 RVA: 0x0001429D File Offset: 0x0001249D
	protected override void OnDisposed()
	{
		this.m_Visuals.DOKill(false);
		base.OnDisposed();
	}

	// Token: 0x040015E9 RID: 5609
	[Header("PlayIn Options")]
	[SerializeField]
	protected AbstractGameMenuController.PlayInType m_PlayInType;

	// Token: 0x040015EA RID: 5610
	[SerializeField]
	protected AbstractGameMenuController.AnchorSizeType m_AnchorSizeType;

	// Token: 0x040015EB RID: 5611
	[Header("Visuals")]
	[SerializeField]
	protected RectTransform m_Visuals;

	// Token: 0x040015EC RID: 5612
	protected RectTransform m_Content;

	// Token: 0x040015ED RID: 5613
	protected Vector2 m_VisualsOriginPosition;

	// Token: 0x040015EE RID: 5614
	protected Vector2 m_VisualsStartPosition;

	// Token: 0x040015EF RID: 5615
	protected Vector3 m_VisualsOriginScale;

	// Token: 0x040015F0 RID: 5616
	protected Vector3 m_VisualsStartScale;

	// Token: 0x040015F1 RID: 5617
	protected float m_PlayInDelay;

	// Token: 0x040015F2 RID: 5618
	protected float m_PlayoutDelay;

	// Token: 0x02000299 RID: 665
	protected enum PlayInType
	{
		// Token: 0x040015F4 RID: 5620
		SCALE,
		// Token: 0x040015F5 RID: 5621
		TOP_BOTTOM,
		// Token: 0x040015F6 RID: 5622
		BOTTOM_TOP
	}

	// Token: 0x0200029A RID: 666
	protected enum AnchorSizeType
	{
		// Token: 0x040015F8 RID: 5624
		VISUALS,
		// Token: 0x040015F9 RID: 5625
		CONTENT
	}
}
