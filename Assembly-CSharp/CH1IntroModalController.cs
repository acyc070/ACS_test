using System;
using DG.Tweening;
using TMG.Controls;
using TMG.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020002A4 RID: 676
public class CH1IntroModalController : BaseUIController
{
	// Token: 0x0600196E RID: 6510 RVA: 0x0008AEEC File Offset: 0x000890EC
	public override void InitController(object _data)
	{
		base.InitController(_data);
		this.m_TouchArea.SetActive(false);
		this.m_Visuals.localScale = Vector3.one * 1.5f;
		this.m_ContinueLbl.alpha = 0f;
		this.m_BlackOut.color = new Color(this.m_BlackOut.color.r, this.m_BlackOut.color.g, this.m_BlackOut.color.b, 1f);
	}

	// Token: 0x0600196F RID: 6511 RVA: 0x0008AF84 File Offset: 0x00089184
	public override void PlayIn()
	{
		this.m_BlackOut.DOFade(0f, 1f);
		this.m_LightFlickerImage.DOFade(0.1f, 0.1f).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
		this.m_Visuals.DOScale(1.55f, 10f).SetEase(Ease.InOutQuad).SetLoops(-1, LoopType.Yoyo);
		base.PlayIn();
	}

	// Token: 0x06001970 RID: 6512 RVA: 0x00014781 File Offset: 0x00012981
	public override void PlayInComplete()
	{
		this.m_ContinueLbl.DOFade(0.7f, 0.5f).SetDelay(2f).OnComplete(delegate
		{
			this.m_TouchArea.SetActive(true);
			this.m_CanContinue = true;
			this.m_ContinueLbl.DOFade(0.5f, 0.25f).SetEase(Ease.InOutQuad).SetLoops(-1, LoopType.Yoyo);
		});
		base.PlayInComplete();
	}

	// Token: 0x06001971 RID: 6513 RVA: 0x000147BA File Offset: 0x000129BA
	private void Update()
	{
		if (base.IsDisposed || !this.m_CanContinue)
		{
			return;
		}
		if (PlayerInput.Any())
		{
			this.BeginPlayOut();
		}
	}

	// Token: 0x06001972 RID: 6514 RVA: 0x000147E3 File Offset: 0x000129E3
	public void BeginPlayOut()
	{
		this.m_CanContinue = false;
		this.m_TouchArea.SetActive(false);
		base.Kill();
	}

	// Token: 0x06001973 RID: 6515 RVA: 0x0008AFF4 File Offset: 0x000891F4
	public override void PlayOut()
	{
		this.m_ContinueLbl.DOKill(false);
		this.m_ContinueLbl.DOFade(0f, 0.5f);
		this.m_BlackOut.DOFade(1f, 0.5f).OnComplete(new TweenCallback(this.PlayOutComplete));
	}

	// Token: 0x06001974 RID: 6516 RVA: 0x000147FE File Offset: 0x000129FE
	protected override void OnDisposed()
	{
		this.m_Visuals.DOKill(false);
		this.m_BlackOut.DOKill(false);
		this.m_LightFlickerImage.DOKill(false);
		base.OnDisposed();
	}

	// Token: 0x04001652 RID: 5714
	[Header("RectTransfrm")]
	[SerializeField]
	private RectTransform m_Visuals;

	// Token: 0x04001653 RID: 5715
	[Header("Image")]
	[SerializeField]
	private Image m_Blocker;

	// Token: 0x04001654 RID: 5716
	[SerializeField]
	private Image m_Paper;

	// Token: 0x04001655 RID: 5717
	[SerializeField]
	private Image m_LightFlickerImage;

	// Token: 0x04001656 RID: 5718
	[SerializeField]
	private Image m_BlackOut;

	// Token: 0x04001657 RID: 5719
	[Header("TextMeshPro")]
	[SerializeField]
	private TextMeshProUGUI m_Message;

	// Token: 0x04001658 RID: 5720
	[SerializeField]
	private TextMeshProUGUI m_ContinueLbl;

	// Token: 0x04001659 RID: 5721
	[Header("Touch Controls")]
	[SerializeField]
	private GameObject m_TouchArea;

	// Token: 0x0400165A RID: 5722
	private bool m_CanContinue;
}
