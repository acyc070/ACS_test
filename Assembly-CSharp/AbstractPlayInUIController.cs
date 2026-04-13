using System;
using DG.Tweening;
using TMG.UI;
using UnityEngine;

// Token: 0x02000287 RID: 647
public abstract class AbstractPlayInUIController : BaseUIController
{
	// Token: 0x0600189A RID: 6298 RVA: 0x00086F04 File Offset: 0x00085104
	public override void InitController(object _data)
	{
		base.InitController(_data);
		this.m_Content = base.GetComponent<RectTransform>();
		this.m_VisualsOriginScale = this.m_Visuals.localScale;
		this.m_VisualsStartScale = this.m_Visuals.localScale;
		this.m_VisualsOriginPosition = this.m_Visuals.anchoredPosition;
		this.m_VisualsStartPosition = this.m_Visuals.anchoredPosition;
		if (this.m_PlayInType == AbstractPlayInUIController.PlayInType.NONE)
		{
			return;
		}
		Vector2 zero = Vector2.zero;
		if (this.m_AnchorSizeType == AbstractPlayInUIController.AnchorSizeType.CONTENT)
		{
			zero = new Vector2(0f, this.m_Content.sizeDelta.y);
		}
		else if (this.m_AnchorSizeType == AbstractPlayInUIController.AnchorSizeType.VISUALS)
		{
			zero = new Vector2(0f, this.m_Visuals.sizeDelta.y);
		}
		if (this.m_PlayInType == AbstractPlayInUIController.PlayInType.SCALE)
		{
			this.m_VisualsStartScale = Vector2.zero;
		}
		else if (this.m_PlayInType == AbstractPlayInUIController.PlayInType.TOP_BOTTOM)
		{
			this.m_VisualsStartPosition = this.m_Visuals.anchoredPosition + zero;
		}
		else if (this.m_PlayInType == AbstractPlayInUIController.PlayInType.BOTTOM_TOP)
		{
			this.m_VisualsStartPosition = this.m_Visuals.anchoredPosition - zero;
		}
		else if (this.m_PlayInType == AbstractPlayInUIController.PlayInType.FADE)
		{
			this.m_CanvasGroup = this.m_Visuals.GetComponent<CanvasGroup>();
			if (this.m_CanvasGroup != null)
			{
				this.m_CanvasGroup.alpha = 0f;
			}
		}
		this.m_Visuals.anchoredPosition = this.m_VisualsStartPosition;
		this.m_Visuals.localScale = this.m_VisualsStartScale;
	}

	// Token: 0x0600189B RID: 6299 RVA: 0x000870A8 File Offset: 0x000852A8
	public override void PlayIn()
	{
		if (this.m_PlayInType == AbstractPlayInUIController.PlayInType.NONE)
		{
			this.PlayInComplete();
			return;
		}
		if (this.m_PlayInType == AbstractPlayInUIController.PlayInType.SCALE)
		{
			this.m_Visuals.DOScale(this.m_VisualsOriginScale, 0.5f).SetEase(Ease.OutBack).OnComplete(new TweenCallback(this.PlayInComplete));
		}
		else if (this.m_PlayInType == AbstractPlayInUIController.PlayInType.FADE)
		{
			if (this.m_CanvasGroup != null)
			{
				this.m_CanvasGroup.DOFade(1f, 0.5f).SetEase(Ease.Linear).OnComplete(new TweenCallback(this.PlayInComplete));
			}
			else
			{
				this.PlayInComplete();
			}
		}
		else
		{
			this.m_Visuals.DOAnchorPos(this.m_VisualsOriginPosition, 0.5f, false).SetEase(Ease.OutBack).OnComplete(new TweenCallback(this.PlayInComplete));
		}
	}

	// Token: 0x0600189C RID: 6300 RVA: 0x00087194 File Offset: 0x00085394
	public override void PlayOut()
	{
		if (this.m_PlayInType == AbstractPlayInUIController.PlayInType.NONE)
		{
			this.PlayInComplete();
			return;
		}
		if (this.m_PlayInType == AbstractPlayInUIController.PlayInType.SCALE)
		{
			this.m_Visuals.DOScale(this.m_VisualsStartScale, 0.5f).SetEase(Ease.InBack).OnComplete(new TweenCallback(this.PlayOutComplete));
		}
		else if (this.m_PlayInType == AbstractPlayInUIController.PlayInType.FADE)
		{
			if (this.m_CanvasGroup != null)
			{
				this.m_CanvasGroup.DOFade(0f, 0.5f).SetEase(Ease.Linear).OnComplete(new TweenCallback(this.PlayOutComplete));
			}
			else
			{
				this.PlayOutComplete();
			}
		}
		else
		{
			this.m_Visuals.DOAnchorPos(this.m_VisualsStartPosition, 0.5f, false).SetEase(Ease.InBack).OnComplete(new TweenCallback(this.PlayOutComplete));
		}
	}

	// Token: 0x0600189D RID: 6301 RVA: 0x00013DC9 File Offset: 0x00011FC9
	protected override void OnDisposed()
	{
		this.m_Visuals.DOKill(false);
		this.m_Content = null;
		this.m_CanvasGroup = null;
		base.OnDisposed();
	}

	// Token: 0x04001591 RID: 5521
	[Header("PlayIn Options")]
	[SerializeField]
	protected AbstractPlayInUIController.PlayInType m_PlayInType;

	// Token: 0x04001592 RID: 5522
	[SerializeField]
	protected AbstractPlayInUIController.AnchorSizeType m_AnchorSizeType;

	// Token: 0x04001593 RID: 5523
	[Header("Visuals")]
	[SerializeField]
	protected RectTransform m_Visuals;

	// Token: 0x04001594 RID: 5524
	protected RectTransform m_Content;

	// Token: 0x04001595 RID: 5525
	protected Vector2 m_VisualsOriginPosition;

	// Token: 0x04001596 RID: 5526
	protected Vector2 m_VisualsStartPosition;

	// Token: 0x04001597 RID: 5527
	protected Vector3 m_VisualsOriginScale;

	// Token: 0x04001598 RID: 5528
	protected Vector3 m_VisualsStartScale;

	// Token: 0x04001599 RID: 5529
	private CanvasGroup m_CanvasGroup;

	// Token: 0x02000288 RID: 648
	protected enum PlayInType
	{
		// Token: 0x0400159B RID: 5531
		SCALE,
		// Token: 0x0400159C RID: 5532
		TOP_BOTTOM,
		// Token: 0x0400159D RID: 5533
		BOTTOM_TOP,
		// Token: 0x0400159E RID: 5534
		FADE,
		// Token: 0x0400159F RID: 5535
		NONE
	}

	// Token: 0x02000289 RID: 649
	protected enum AnchorSizeType
	{
		// Token: 0x040015A1 RID: 5537
		VISUALS,
		// Token: 0x040015A2 RID: 5538
		CONTENT
	}
}
