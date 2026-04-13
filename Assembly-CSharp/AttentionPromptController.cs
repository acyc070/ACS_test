using System;
using System.Collections;
using DG.Tweening;
using TMG.Controls;
using TMG.UI;
using TMPro;
using UnityEngine;

// Token: 0x020002AB RID: 683
public class AttentionPromptController : BaseUIController
{
	// Token: 0x06001994 RID: 6548 RVA: 0x0008B728 File Offset: 0x00089928
	public override void InitController(object _data)
	{
		base.InitController(_data);
		this.m_DataVO = (AttentionDataVO)_data;
		this.m_Header.text = this.m_DataVO.Header;
		this.m_Message.text = this.m_DataVO.Message;
		this.m_CanvasGroup.alpha = 0f;
		this.m_VisualsOriginScale = this.m_Visuals.localScale;
		this.m_VisualsShrinkScale = this.m_VisualsOriginScale * 0.75f;
		this.m_Visuals.localScale = this.m_VisualsShrinkScale;
	}

	// Token: 0x06001995 RID: 6549 RVA: 0x0008B7BC File Offset: 0x000899BC
	public override void PlayIn()
	{
		this.m_CanvasGroup.DOFade(1f, 0.45f).SetEase(Ease.InQuad);
		this.m_Visuals.DOScale(this.m_VisualsOriginScale, 0.5f).SetEase(Ease.InQuad).OnComplete(new TweenCallback(this.PlayInComplete));
	}

	// Token: 0x06001996 RID: 6550 RVA: 0x0001495C File Offset: 0x00012B5C
	public override void PlayInComplete()
	{
		base.PlayInComplete();
		base.StartCoroutine(this.DelayActivate());
	}

	// Token: 0x06001997 RID: 6551 RVA: 0x0008B814 File Offset: 0x00089A14
	private IEnumerator DelayActivate()
	{
		yield return new WaitForSeconds(0.5f);
		yield return new WaitForEndOfFrame();
		this.m_IsActive = true;
		yield break;
	}

	// Token: 0x06001998 RID: 6552 RVA: 0x00014971 File Offset: 0x00012B71
	private void Update()
	{
		if (!this.m_IsActive)
		{
			return;
		}
		if (PlayerInput.Any())
		{
			this.m_IsActive = false;
			base.Kill();
		}
	}

	// Token: 0x06001999 RID: 6553 RVA: 0x0008B830 File Offset: 0x00089A30
	public override void PlayOut()
	{
		this.m_CanvasGroup.DOFade(0f, 0.45f).SetEase(Ease.InQuad);
		this.m_Visuals.DOScale(this.m_VisualsShrinkScale, 0.5f).SetEase(Ease.InQuad).OnComplete(new TweenCallback(this.PlayOutComplete));
	}

	// Token: 0x0600199A RID: 6554 RVA: 0x0001474F File Offset: 0x0001294F
	public override void PlayOutComplete()
	{
		base.PlayOutComplete();
	}

	// Token: 0x0600199B RID: 6555 RVA: 0x00014996 File Offset: 0x00012B96
	protected override void OnDisposed()
	{
		this.m_DataVO = null;
		base.OnDisposed();
	}

	// Token: 0x04001676 RID: 5750
	[Header("Visuals")]
	[SerializeField]
	private RectTransform m_Visuals;

	// Token: 0x04001677 RID: 5751
	[SerializeField]
	private CanvasGroup m_CanvasGroup;

	// Token: 0x04001678 RID: 5752
	[Header("TextMeshPro")]
	[SerializeField]
	private TextMeshProUGUI m_Header;

	// Token: 0x04001679 RID: 5753
	[SerializeField]
	private TextMeshProUGUI m_Message;

	// Token: 0x0400167A RID: 5754
	private AttentionDataVO m_DataVO;

	// Token: 0x0400167B RID: 5755
	private Vector3 m_VisualsOriginScale;

	// Token: 0x0400167C RID: 5756
	private Vector3 m_VisualsShrinkScale;

	// Token: 0x0400167D RID: 5757
	private bool m_IsActive;
}
