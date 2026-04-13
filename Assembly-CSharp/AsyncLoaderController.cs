using System;
using DG.Tweening;
using TMG.UI;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000291 RID: 657
public class AsyncLoaderController : BaseUIController
{
	// Token: 0x060018DA RID: 6362 RVA: 0x00014130 File Offset: 0x00012330
	public override void InitController(object _data)
	{
		base.InitController(_data);
		this.InternalHide();
	}

	// Token: 0x060018DB RID: 6363 RVA: 0x00087D34 File Offset: 0x00085F34
	public void Show()
	{
		this.m_Loader.DOKill(false);
		this.m_Loader.color = new Color(1f, 1f, 1f, 0.2f);
		this.m_Loader.enabled = true;
		this.m_Visuals.gameObject.SetActive(true);
		this.m_Loader.DOFade(0.4f, 0.5f).SetEase(Ease.InOutQuad).SetLoops(-1, LoopType.Yoyo);
	}

	// Token: 0x060018DC RID: 6364 RVA: 0x0001413F File Offset: 0x0001233F
	public void Hide()
	{
		this.m_Loader.DOKill(false);
		this.m_Loader.DOFade(0f, 0.75f).SetEase(Ease.InOutQuad).OnComplete(new TweenCallback(this.InternalHide));
	}

	// Token: 0x060018DD RID: 6365 RVA: 0x00087DB4 File Offset: 0x00085FB4
	private void InternalHide()
	{
		this.m_Loader.color = new Color(1f, 1f, 1f, 0.2f);
		this.m_Loader.enabled = false;
		this.m_Visuals.gameObject.SetActive(false);
	}

	// Token: 0x060018DE RID: 6366 RVA: 0x000061D6 File Offset: 0x000043D6
	protected override void OnDisposed()
	{
		base.OnDisposed();
	}

	// Token: 0x040015C3 RID: 5571
	[Header("RectTransforms")]
	[SerializeField]
	private RectTransform m_Visuals;

	// Token: 0x040015C4 RID: 5572
	[Header("Images")]
	[SerializeField]
	private Image m_Loader;
}
