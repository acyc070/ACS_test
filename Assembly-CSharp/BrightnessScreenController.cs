using System;
using DG.Tweening;
using TMG.Controls;
using TMG.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020002B0 RID: 688
public class BrightnessScreenController : BaseUIController
{
	// Token: 0x060019BD RID: 6589 RVA: 0x0008BBC0 File Offset: 0x00089DC0
	public override void InitController(object _data)
	{
		base.InitController(_data);
		Color color = this.m_Fader.color;
		color.a = 1f;
		this.m_Fader.color = color;
		this.m_NavInput = GameManager.Instance.AssetManager.CreateAsset<MenuItemNavInput>("UI/Elements/UINavInput");
		this.m_NavInput.Init(NavInputDataVO.Create("A", "MENU/CONTROL_CONTINUE"));
		this.m_NavInput.rectTransform.SetParent(this.m_NavContainer);
		this.m_NavInput.rectTransform.anchoredPosition = Vector2.zero;
	}

	// Token: 0x060019BE RID: 6590 RVA: 0x00014BB5 File Offset: 0x00012DB5
	public override void PlayIn()
	{
		this.m_Fader.DOFade(0f, 0.5f).OnComplete(new TweenCallback(this.PlayInComplete));
	}

	// Token: 0x060019BF RID: 6591 RVA: 0x00014BDF File Offset: 0x00012DDF
	public override void PlayInComplete()
	{
		this.m_IsActive = true;
		base.PlayInComplete();
	}

	// Token: 0x060019C0 RID: 6592 RVA: 0x00014BEE File Offset: 0x00012DEE
	private void Update()
	{
		if (!this.m_IsActive)
		{
			return;
		}
		if (PlayerInput.Jump())
		{
			this.m_IsAwake = false;
			base.Kill();
		}
	}

	// Token: 0x060019C1 RID: 6593 RVA: 0x00014C13 File Offset: 0x00012E13
	public override void PlayOut()
	{
		this.m_Fader.DOFade(1f, 0.5f).OnComplete(new TweenCallback(this.PlayOutComplete));
	}

	// Token: 0x060019C2 RID: 6594 RVA: 0x00014C3D File Offset: 0x00012E3D
	protected override void OnDisposed()
	{
		this.m_NavInput = null;
		base.OnDisposed();
	}

	// Token: 0x0400168D RID: 5773
	[Header("RectTransforms")]
	[SerializeField]
	private RectTransform m_NavContainer;

	// Token: 0x0400168E RID: 5774
	[Header("Images")]
	[SerializeField]
	private Image m_BendyHeadImg;

	// Token: 0x0400168F RID: 5775
	[SerializeField]
	private Image m_CircleImg;

	// Token: 0x04001690 RID: 5776
	[SerializeField]
	private Image m_BlockerImg;

	// Token: 0x04001691 RID: 5777
	[SerializeField]
	private Image m_Fader;

	// Token: 0x04001692 RID: 5778
	[Header("Text")]
	[SerializeField]
	private TextMeshProUGUI m_HeaderLbl;

	// Token: 0x04001693 RID: 5779
	[SerializeField]
	private TextMeshProUGUI m_BrightnessLbl;

	// Token: 0x04001694 RID: 5780
	private bool m_IsActive;

	// Token: 0x04001695 RID: 5781
	private MenuItemNavInput m_NavInput;
}
