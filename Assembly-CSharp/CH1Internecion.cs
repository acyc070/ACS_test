using System;
using DG.Tweening;
using UnityEngine;

// Token: 0x02000072 RID: 114
public class CH1Internecion : BaseController
{
	// Token: 0x06000401 RID: 1025 RVA: 0x0002E2F0 File Offset: 0x0002C4F0
	public override void InitOnComplete()
	{
		base.InitOnComplete();
		string text = "onef";
		string text2 = "our";
		this.m_InternecionStr = "f" + text2 + text + text2;
		bool internecion = this.GetInternecion();
		this.m_Internecion.SetActive(internecion);
		this.m_Primary.SetActive(!internecion);
		if (internecion)
		{
			this.m_StartPosition.SetParent(null);
			this.m_Trigger.OnEnter += this.HandleTriggerOnEnter;
			this.m_Trigger.SetActive(true);
		}
	}

	// Token: 0x06000402 RID: 1026 RVA: 0x0002E37C File Offset: 0x0002C57C
	private void HandleTriggerOnEnter(object sender, EventArgs e)
	{
		this.m_Trigger.OnEnter -= this.HandleTriggerOnEnter;
		GameManager.Instance.ShowScreenBlocker(0f, 0f, null);
		Sequence sequence = DOTween.Sequence();
		sequence.InsertCallback(0.1f, delegate
		{
			AmplifyPostProcess component = GameManager.Instance.GameCamera.WeaponCamera.GetComponent<AmplifyPostProcess>();
			component.enabled = true;
			GameManager.Instance.Player.GoToAndLookAt(this.m_StartPosition);
			GameManager.Instance.Player.SetLock(true, false);
		});
		sequence.InsertCallback(0.3f, delegate
		{
			GameManager.Instance.Player.SetLock(false, false);
			GameManager.Instance.Player.PlayRespawnEffects();
			GameManager.Instance.HideScreenBlocker(0.11f, 0f, null);
		});
		sequence.OnComplete(delegate
		{
			this.m_Primary.SetActive(true);
			this.m_Internecion.SetActive(false);
			GameManager.Instance.GameData.CurrentSaveFile.Internecions[0] = 1;
			GameManager.Instance.GameDataManager.Save(false, false);
		});
	}

	// Token: 0x06000403 RID: 1027 RVA: 0x0002E410 File Offset: 0x0002C610
	private bool GetInternecion()
	{
		return !GameManager.Instance.GameData.CurrentSaveFile.HasDied && GameManager.Instance.GameData.CurrentSaveFile.Internecions[0] == 0 && GameManager.Instance.GameData.CurrentSaveFile.Internecions[1] == 4 && GameManager.Instance.GameData.CurrentSaveFile.Internecions[2] == 1 && GameManager.Instance.GameData.CurrentSaveFile.Internecions[3] == 4 && GameManager.Instance.GameData.CurrentSaveFile.Internecions[4] == 0 && GameManager.Instance.GameData.CurrentSaveFile.Internecion == this.m_InternecionStr;
	}

	// Token: 0x06000404 RID: 1028 RVA: 0x00005C16 File Offset: 0x00003E16
	protected override void OnDisposed()
	{
		if (this.m_Trigger != null)
		{
			this.m_Trigger.OnEnter -= this.HandleTriggerOnEnter;
		}
		base.OnDisposed();
	}

	// Token: 0x04000286 RID: 646
	[SerializeField]
	private GameObject m_Primary;

	// Token: 0x04000287 RID: 647
	[SerializeField]
	private GameObject m_Internecion;

	// Token: 0x04000288 RID: 648
	[SerializeField]
	private EventTrigger m_Trigger;

	// Token: 0x04000289 RID: 649
	[SerializeField]
	private Transform m_StartPosition;

	// Token: 0x0400028A RID: 650
	private string m_InternecionStr = string.Empty;
}
