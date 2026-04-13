using System;
using System.Collections.Generic;
using Ai;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using S13Audio;
using UnityEngine;

// Token: 0x0200009D RID: 157
public class CH2SammyOfficeController : BaseController
{
	// Token: 0x060005A6 RID: 1446 RVA: 0x0003764C File Offset: 0x0003584C
	public override void Init()
	{
		base.Init();
		for (int i = 0; i < this.m_Pipes.Count; i++)
		{
			this.m_Pipes[i].TurnOff();
		}
		this.m_Sammy.SetActive(false);
	}

	// Token: 0x060005A7 RID: 1447 RVA: 0x00037698 File Offset: 0x00035898
	public override void InitOnComplete()
	{
		this.m_KnockoutClip = GameManager.Instance.GetAudioClip("Audio/SFX/SFX_Henry_HitOnHead");
		this.m_LeverTurn = GameManager.Instance.GetAudioClip("Audio/SFX/SFX_Mainr_Power_Lever_Turn_On_01");
		this.m_HenryClip09 = GameManager.Instance.GetAudioClip("Audio/DIA/CH2/Henry/DIA_CH2_HENRY_09");
		GameManager.Instance.Player.OnDeath += this.HandleOnPlayerDeath;
		for (int i = 0; i < this.m_Pipes.Count; i++)
		{
			this.m_Pipes[i].TurnOff();
		}
		this.m_Sammy.SetActive(false);
		this.m_KnockoutEventTrigger.SetActive(false);
		this.m_Lever.SetActive(false);
		if (!GameManager.Instance.GameData.CurrentSaveFile.CH2Data.LostKeysObjective.IsStarted)
		{
			this.m_WindowEventTrigger.OnEnter += this.HandleWindowEventTriggerOnEnter;
		}
	}

	// Token: 0x060005A8 RID: 1448 RVA: 0x0003778C File Offset: 0x0003598C
	private void HandleWindowEventTriggerOnEnter(object sender, EventArgs e)
	{
		if (this.m_LeverMeshRenderer.isVisible)
		{
			this.m_WindowEventTrigger.OnEnter -= this.HandleWindowEventTriggerOnEnter;
			this.m_WindowEventTrigger.Dispose();
			GameManager.Instance.ShowDialogue(DialogueDataVO.Create(this.m_HenryClip09, "DIACH2/DIA_CH2_HENRY_09", false));
		}
	}

	// Token: 0x060005A9 RID: 1449 RVA: 0x000377E8 File Offset: 0x000359E8
	public override void Activate()
	{
		GameManager.Instance.UpdateObjective(ObjectiveDataVO.Create("OBJECTIVES/NEW_OBJECTIVE_HEADER", "OBJECTIVES/CH2_OBJECTIVE_SAMMYS_OFFICE", string.Empty, 0f, false, 0f));
		this.m_Lever.OnInteracted += this.HandleLeverOnInteracted;
		this.m_Lever.OnComplete += this.HandleLeverOnComplete;
		this.m_Lever.SetActive(true);
		if (this.m_SearcherB && !GameManager.Instance.GameData.CurrentSaveFile.CH2Data.HasDied && GameManager.Instance.GameData.CurrentSaveFile.CH2Data.InternecionValue == 0)
		{
			this.m_SearcherB.SetActive(true);
			BaseAiController component = this.m_SearcherB.GetComponent<BaseAiController>();
			component.OnDeath += this.HandleSearcherBOnDeath;
		}
	}

	// Token: 0x060005AA RID: 1450 RVA: 0x000378D0 File Offset: 0x00035AD0
	private void HandleSearcherBOnDeath(object sender, EventArgs e)
	{
		(sender as BaseAiController).OnDeath -= this.HandleSearcherBOnDeath;
		GameManager.Instance.GameData.CurrentSaveFile.CH2Data.InternecionValue = -1;
		GameManager.Instance.GameDataManager.Save(true, false);
	}

	// Token: 0x060005AB RID: 1451 RVA: 0x000071D1 File Offset: 0x000053D1
	public void HandleOnPlayerDeath(object sender, EventArgs e)
	{
		GameManager.Instance.Player.OnDeath -= this.HandleOnPlayerDeath;
		if (this.m_SearcherB)
		{
			this.m_SearcherB.SetActive(false);
		}
	}

	// Token: 0x060005AC RID: 1452 RVA: 0x0000720A File Offset: 0x0000540A
	private void ForceComplete()
	{
		this.m_MeatlyController.Activate();
		base.SendOnComplete();
	}

	// Token: 0x060005AD RID: 1453 RVA: 0x00037920 File Offset: 0x00035B20
	private void HandleLeverOnInteracted(object sender, EventArgs e)
	{
		this.m_Lever.OnInteracted -= this.HandleLeverOnInteracted;
		GameManager.Instance.AudioManager.Play(this.m_LeverTurn, AudioObjectType.SOUND_EFFECT, 0, false);
		S13AudioManager.Instance.InvokeEvent("evt_office_lever_thrown", 0f);
		if (!GameManager.Instance.GameData.CurrentSaveFile.CH2Data.SammysOfficeObjective.IsComplete)
		{
			GameManager.Instance.GameData.CurrentSaveFile.CH2Data.SammysOfficeObjective.IsComplete = true;
			GameManager.Instance.GameDataManager.Save(false, true);
		}
	}

	// Token: 0x060005AE RID: 1454 RVA: 0x000379C4 File Offset: 0x00035BC4
	private void HandleLeverOnComplete(object sender, EventArgs e)
	{
		this.m_Lever.OnComplete -= this.HandleLeverOnComplete;
		for (int i = 0; i < this.m_SearcherSpawners.Length; i++)
		{
			this.m_SearcherSpawners[i].SetActive(false);
		}
		this.m_MeatlyController.Activate();
		GameManager.Instance.ShowObjective(ObjectiveDataVO.Create("OBJECTIVES/NEW_OBJECTIVE_HEADER", "OBJECTIVES/CH2_OBJECTIVE_TAKE_STAIRS", string.Empty, 4f, false, 0f));
		for (int j = 0; j < this.m_Pipes.Count; j++)
		{
			this.m_Pipes[j].TurnOn();
		}
		this.m_KnockoutEventTrigger.SetActive(true);
		this.m_KnockoutEventTrigger.OnEnter += this.HandleKnockoutEventTriggerOnEnter;
		if (this.m_SearcherB && this.m_SearcherB.activeSelf)
		{
			this.m_SearcherB.GetComponent<BaseAiController>().SetThought(AiThought.Die);
		}
	}

	// Token: 0x060005AF RID: 1455 RVA: 0x00037AC8 File Offset: 0x00035CC8
	private void HandleKnockoutEventTriggerOnEnter(object sender, EventArgs e)
	{
		this.m_KnockoutEventTrigger.OnEnter -= this.HandleKnockoutEventTriggerOnEnter;
		this.m_KnockoutEventTrigger.Dispose();
		GameManager.Instance.AudioManager.Play(this.m_KnockoutClip, AudioObjectType.SOUND_EFFECT, 0, false);
		S13AudioManager.Instance.InvokeEvent("evt_sammy_knocks_out_player", 0f);
		this.DOKnockout().OnComplete(new TweenCallback(base.SendOnComplete));
	}

	// Token: 0x060005B0 RID: 1456 RVA: 0x00037B3C File Offset: 0x00035D3C
	private Sequence DOKnockout()
	{
		GameManager.Instance.GameCamera.transform.DOShakePosition(3f, 0.25f, 12, 90f, false, true);
		GameManager.Instance.Player.SetLock(true, false);
		GameManager.Instance.Player.UnEquipWeapon();
		global::UnityEngine.Object.Destroy(GameManager.Instance.Player.WeaponGameObject);
		GameManager.Instance.HideCrosshair();
		Sequence sequence = DOTween.Sequence();
		sequence.InsertCallback(0f, delegate
		{
			GameManager.Instance.ShowScreenBlocker(0f, 0f, null);
		});
		GameCamera gameCam = GameManager.Instance.GameCamera;
		if (gameCam.DoF)
		{
			sequence.InsertCallback(0f, delegate
			{
				gameCam.UnityDOF.manualDOF = true;
				gameCam.UnityDOF.focalDistance = 0f;
			});
			float blurOff2 = 0f;
			sequence.Insert(1.5f, DOTween.To(() => blurOff2, delegate(float value)
			{
				blurOff2 = value;
			}, 10f, 1f).SetEase(Ease.Linear).OnUpdate(delegate
			{
				gameCam.UnityDOF.focalDistance = blurOff2;
			}));
			float blurOn2 = 10f;
			sequence.Insert(2.5f, DOTween.To(() => blurOn2, delegate(float value)
			{
				blurOn2 = value;
			}, 0f, 1f).SetEase(Ease.Linear).OnUpdate(delegate
			{
				gameCam.UnityDOF.focalDistance = blurOn2;
			}));
		}
		sequence.InsertCallback(0.1f, delegate
		{
			GameManager.Instance.HideScreenBlocker(1.5f, 0f, null);
		});
		sequence.InsertCallback(2f, delegate
		{
			GameManager.Instance.ShowScreenBlocker(0.5f, 0f, null);
			GameManager.Instance.GameCamera.Camera.transform.DOMove(this.m_KnockoutPosition.position, 1f, false);
			GameManager.Instance.GameCamera.Camera.transform.DORotateQuaternion(this.m_KnockoutPosition.rotation, 1f);
		});
		sequence.InsertCallback(3.5f, delegate
		{
			this.m_Sammy.SetActive(true);
			GameManager.Instance.HideScreenBlocker(1.5f, 0f, null);
		});
		if (gameCam.DoF)
		{
			sequence.InsertCallback(0f, delegate
			{
				gameCam.UnityDOF.manualDOF = true;
				gameCam.UnityDOF.focalDistance = 0f;
			});
			float blurOff = 0f;
			sequence.Insert(6f, DOTween.To(() => blurOff, delegate(float value)
			{
				blurOff = value;
			}, 10f, 1f).SetEase(Ease.Linear).OnUpdate(delegate
			{
				gameCam.UnityDOF.focalDistance = blurOff;
			}));
			float blurOn = 10f;
			sequence.Insert(7f, DOTween.To(() => blurOn, delegate(float value)
			{
				blurOn = value;
			}, 0f, 0.5f).SetEase(Ease.Linear).OnUpdate(delegate
			{
				gameCam.UnityDOF.focalDistance = blurOn;
			}));
		}
		sequence.InsertCallback(7.3f, delegate
		{
			GameManager.Instance.ShowScreenBlocker(0.25f, 0f, null);
		});
		sequence.InsertCallback(10f, delegate
		{
		});
		return sequence;
	}

	// Token: 0x060005B1 RID: 1457 RVA: 0x00037E68 File Offset: 0x00036068
	protected override void OnDisposed()
	{
		if (this.m_KnockoutEventTrigger != null)
		{
			this.m_KnockoutEventTrigger.OnEnter -= this.HandleKnockoutEventTriggerOnEnter;
		}
		if (this.m_WindowEventTrigger != null)
		{
			this.m_WindowEventTrigger.OnEnter -= this.HandleWindowEventTriggerOnEnter;
		}
		this.m_KnockoutClip = null;
		this.m_LeverTurn = null;
		this.m_HenryClip09 = null;
		base.OnDisposed();
	}

	// Token: 0x0400043F RID: 1087
	[Header("Controllers")]
	[SerializeField]
	private MeatlyController m_MeatlyController;

	// Token: 0x04000440 RID: 1088
	[Header("Transforms")]
	[SerializeField]
	private Transform m_KnockoutPosition;

	// Token: 0x04000441 RID: 1089
	[Header("Interactables")]
	[SerializeField]
	private InteractablePowerLever m_Lever;

	// Token: 0x04000442 RID: 1090
	[Header("Pipes")]
	[SerializeField]
	private List<InkPipeController> m_Pipes;

	// Token: 0x04000443 RID: 1091
	[Header("Event Triggers")]
	[SerializeField]
	private EventTrigger m_KnockoutEventTrigger;

	// Token: 0x04000444 RID: 1092
	[SerializeField]
	private EventTrigger m_WindowEventTrigger;

	// Token: 0x04000445 RID: 1093
	[Header("Sammy")]
	[SerializeField]
	private GameObject m_Sammy;

	// Token: 0x04000446 RID: 1094
	[Header("Renderer")]
	[SerializeField]
	private MeshRenderer m_LeverMeshRenderer;

	// Token: 0x04000447 RID: 1095
	[Header("Searcher Spawners")]
	[SerializeField]
	private GameObject[] m_SearcherSpawners;

	// Token: 0x04000448 RID: 1096
	[SerializeField]
	private GameObject m_SearcherB;

	// Token: 0x04000449 RID: 1097
	private AudioClip m_KnockoutClip;

	// Token: 0x0400044A RID: 1098
	private AudioClip m_LeverTurn;

	// Token: 0x0400044B RID: 1099
	private AudioClip m_HenryClip09;
}
