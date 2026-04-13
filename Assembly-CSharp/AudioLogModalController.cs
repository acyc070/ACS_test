using System;
using DG.Tweening;
using TMG.UI;
using TMPro;
using UnityEngine;

// Token: 0x020002A1 RID: 673
public class AudioLogModalController : BaseUIController
{
	// Token: 0x0600195E RID: 6494 RVA: 0x000146F1 File Offset: 0x000128F1
	public override void InitController(object _data)
	{
		base.InitController(_data);
		this.m_DataVO = (AudioLogDataVO)_data;
		this.m_CanvasGroup.alpha = 0f;
		this.m_IsInRange = true;
		this.m_IsComplete = false;
		this.InitText();
	}

	// Token: 0x0600195F RID: 6495 RVA: 0x0008AC14 File Offset: 0x00088E14
	private void InitText()
	{
		if (this.m_DataVO.NameString == string.Empty)
		{
			this.m_NameLbl.text = this.m_DataVO.Name;
		}
		else
		{
			this.m_NameLbl.text = this.m_DataVO.NameString;
		}
		if (this.m_DataVO.LogString == string.Empty)
		{
			this.m_LogLbl.text = this.m_DataVO.Log;
		}
		else
		{
			this.m_LogLbl.text = this.m_DataVO.LogString;
		}
	}

	// Token: 0x06001960 RID: 6496 RVA: 0x0001472A File Offset: 0x0001292A
	public override void PlayIn()
	{
		this.m_CanvasGroup.DOKill(false);
		this.m_CanvasGroup.DOFade(1f, 0.5f);
	}

	// Token: 0x06001961 RID: 6497 RVA: 0x0008ACC4 File Offset: 0x00088EC4
	private void Update()
	{
		if (this.m_IsComplete)
		{
			return;
		}
		if (GameManager.Instance.Player != null && Vector3.Distance(GameManager.Instance.Player.transform.position, this.m_DataVO.LogWorldPosition) > 15f)
		{
			this.Hide();
		}
		else
		{
			this.Show();
		}
	}

	// Token: 0x06001962 RID: 6498 RVA: 0x0008AD34 File Offset: 0x00088F34
	private void Show()
	{
		if (!this.m_IsInRange && !this.m_IsComplete)
		{
			this.m_IsInRange = true;
			this.m_CanvasGroup.DOKill(false);
			this.m_CanvasGroup.DOFade(1f, 0.5f);
		}
	}

	// Token: 0x06001963 RID: 6499 RVA: 0x0008AD84 File Offset: 0x00088F84
	private void Hide()
	{
		if (this.m_IsInRange && !this.m_IsComplete)
		{
			this.m_IsInRange = false;
			this.m_CanvasGroup.DOKill(false);
			this.m_CanvasGroup.DOFade(0f, 0.5f);
		}
	}

	// Token: 0x06001964 RID: 6500 RVA: 0x0008ADD4 File Offset: 0x00088FD4
	public override void PlayOut()
	{
		this.m_IsComplete = true;
		this.m_IsInRange = false;
		this.m_CanvasGroup.DOKill(false);
		this.m_CanvasGroup.DOFade(0f, 0.5f).OnComplete(new TweenCallback(this.PlayOutComplete));
	}

	// Token: 0x06001965 RID: 6501 RVA: 0x0001474F File Offset: 0x0001294F
	public override void PlayOutComplete()
	{
		base.PlayOutComplete();
	}

	// Token: 0x06001966 RID: 6502 RVA: 0x00014757 File Offset: 0x00012957
	protected override void OnDisposed()
	{
		this.m_DataVO = null;
		this.m_CanvasGroup.DOKill(false);
		base.OnDisposed();
	}

	// Token: 0x04001649 RID: 5705
	private const float MAX_DISTANCE = 15f;

	// Token: 0x0400164A RID: 5706
	[Header("Canvas")]
	[SerializeField]
	private CanvasGroup m_CanvasGroup;

	// Token: 0x0400164B RID: 5707
	[Header("Text")]
	[SerializeField]
	private TextMeshProUGUI m_NameLbl;

	// Token: 0x0400164C RID: 5708
	[SerializeField]
	private TextMeshProUGUI m_LogLbl;

	// Token: 0x0400164D RID: 5709
	private AudioLogDataVO m_DataVO;

	// Token: 0x0400164E RID: 5710
	private bool m_IsInRange;

	// Token: 0x0400164F RID: 5711
	private bool m_IsComplete;
}
