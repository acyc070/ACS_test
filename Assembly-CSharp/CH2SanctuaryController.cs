using System;
using System.Collections.Generic;
using DG.Tweening;
using S13Audio;
using UnityEngine;

// Token: 0x020000A1 RID: 161
public class CH2SanctuaryController : BaseController
{
	// Token: 0x060005CA RID: 1482 RVA: 0x00037F64 File Offset: 0x00036164
	public override void InitOnComplete()
	{
		this.m_Valve.SetActive(false);
		this.m_ValveClip = GameManager.Instance.GetAudioClip("Audio/SFX/SFX_Valve_Turn_Steam_Release_01");
		this.m_JumpscareClip = GameManager.Instance.GetAudioClip("Audio/SFX/SFX_Jumpscare_01");
		this.m_HenryClip = GameManager.Instance.GetAudioClip("Audio/DIA/CH3/Henry/ch3_henry_27_valvepuzzle_trueA");
		for (int i = 0; i < this.m_PipeControllers.Count; i++)
		{
			this.m_PipeControllers[i].TurnOn();
		}
		this.m_ScareInk.SetActive(false);
		this.m_Cutout.position = this.m_CutoutStartPosition.position;
		this.m_Cutout.rotation = this.m_CutoutStartPosition.rotation;
		this.m_Cutout.gameObject.SetActive(false);
	}

	// Token: 0x060005CB RID: 1483 RVA: 0x00038034 File Offset: 0x00036234
	public override void Activate()
	{
		if (GameManager.Instance.GameData.CurrentSaveFile.CH2Data.SanctuaryObjective.IsComplete)
		{
			this.ForceComplete();
			return;
		}
		if (GameManager.Instance.GameData.CurrentSaveFile.CH2Data.SanctuaryObjective.IsStarted)
		{
			GameManager.Instance.UpdateObjective(ObjectiveDataVO.Create("OBJECTIVES/NEW_OBJECTIVE_HEADER", "OBJECTIVES/CH2_OBJECTIVE_SECOND_VALVE", string.Empty, 0f, false, 0f));
			S13AudioManager.Instance.InvokeEvent("evt_office_stairs_ink_drained", 0f);
			this.m_JumpscareTrigger.OnEnter += this.HandleJumpscareTriggerOnEnter;
			this.m_JumpscareTrigger.SetActive(true);
			this.m_Cutout.gameObject.SetActive(true);
			this.m_StrikeUpTheBand.SetActive(false);
			this.m_InkBlockage.SetActive(false);
			for (int i = 0; i < this.m_PipeControllers.Count; i++)
			{
				this.m_PipeControllers[i].TurnOff();
			}
		}
		else
		{
			GameManager.Instance.UpdateObjective(ObjectiveDataVO.Create("OBJECTIVES/NEW_OBJECTIVE_HEADER", "OBJECTIVES/CH2_OBJECTIVE_ENTER_SANCTUARY", string.Empty, 0f, false, 0f));
			this.m_Valve.OnInteracted += this.HandleValveOnInteracted;
			this.m_Valve.SetActive(true);
		}
	}

	// Token: 0x060005CC RID: 1484 RVA: 0x00038198 File Offset: 0x00036398
	private void HandleValveOnInteracted(object sender, EventArgs e)
	{
		this.m_Valve.OnInteracted -= this.HandleValveOnInteracted;
		this.m_JumpscareTrigger.OnEnter += this.HandleJumpscareTriggerOnEnter;
		this.m_Cutout.gameObject.SetActive(true);
		this.m_JumpscareTrigger.SetActive(true);
		this.m_StrikeUpTheBand.SetActive(false);
		GameManager.Instance.AudioManager.PlayAtPosition(this.m_ValveClip, this.m_Valve.transform.position, AudioObjectType.SOUND_EFFECT, 0, false, null);
		DOTween.Sequence().InsertCallback(7.5f, delegate
		{
			this.m_SteamJet.Emit(10);
		});
		this.m_Valve.transform.DOLocalRotate(new Vector3(360f, 0f, 0f), 8f, RotateMode.LocalAxisAdd).SetEase(Ease.InOutQuad).OnComplete(new TweenCallback(this.HandleValveHandleRotateOnComplete));
		GameManager.Instance.ShowDialogue(DialogueDataVO.Create(this.m_HenryClip, "DIACH3/DIA_CH3_HENRY_28", true)).OnComplete += this.HandleValveDialogueOnComplete;
		GameManager.Instance.GameData.CurrentSaveFile.CH2Data.SanctuaryObjective.IsStarted = true;
		GameManager.Instance.GameDataManager.Save(false, true);
	}

	// Token: 0x060005CD RID: 1485 RVA: 0x000382E0 File Offset: 0x000364E0
	private void HandleValveDialogueOnComplete(object sender, EventArgs e)
	{
		(sender as AudioObject).OnComplete -= this.HandleValveDialogueOnComplete;
		GameManager.Instance.ShowObjective(ObjectiveDataVO.Create("OBJECTIVES/NEW_OBJECTIVE_HEADER", "OBJECTIVES/CH2_OBJECTIVE_SECOND_VALVE", string.Empty, 4f, false, 0f));
	}

	// Token: 0x060005CE RID: 1486 RVA: 0x00038330 File Offset: 0x00036530
	private void HandleValveHandleRotateOnComplete()
	{
		this.m_InkBlockage.SetActive(false);
		S13AudioManager.Instance.InvokeEvent("evt_office_stairs_ink_drained", 0f);
		for (int i = 0; i < this.m_PipeControllers.Count; i++)
		{
			this.m_PipeControllers[i].TurnOff();
		}
	}

	// Token: 0x060005CF RID: 1487 RVA: 0x0000738F File Offset: 0x0000558F
	private void HandleJumpscareTriggerOnEnter(object sender, EventArgs e)
	{
		this.m_JumpscareTrigger.OnEnter -= this.HandleJumpscareTriggerOnEnter;
		this.m_JumpscareTrigger.SetActive(false);
		this.DOCutoutSequence().OnComplete(new TweenCallback(this.HandleCutoutSequenceOnComplete));
	}

	// Token: 0x060005D0 RID: 1488 RVA: 0x0003838C File Offset: 0x0003658C
	private Sequence DOCutoutSequence()
	{
		GameManager.Instance.AudioManager.Play(this.m_JumpscareClip, AudioObjectType.SOUND_EFFECT, 0, false);
		Sequence sequence = DOTween.Sequence();
		float num = 0.25f;
		float num2 = 0f;
		sequence.Insert(num2, this.m_Cutout.DOLocalMove(this.m_CutoutScarePosition.localPosition, num, false).SetEase(Ease.OutBack));
		sequence.Insert(num2, this.m_Cutout.DORotateQuaternion(this.m_CutoutScarePosition.localRotation, num).SetEase(Ease.OutBack));
		num2 += 0.55f;
		sequence.Insert(num2, this.m_Cutout.DOMove(this.m_CutoutStartPosition.localPosition, num, false).SetEase(Ease.InBack));
		sequence.Insert(num2, this.m_Cutout.DORotateQuaternion(this.m_CutoutStartPosition.localRotation, num).SetEase(Ease.InBack));
		return sequence;
	}

	// Token: 0x060005D1 RID: 1489 RVA: 0x000073CC File Offset: 0x000055CC
	private void HandleCutoutSequenceOnComplete()
	{
		this.m_Cutout.position = this.m_CutoutEndPosition.position;
		this.m_Cutout.rotation = this.m_CutoutEndPosition.rotation;
		this.m_ScareInk.SetActive(true);
		base.SendOnComplete();
	}

	// Token: 0x060005D2 RID: 1490 RVA: 0x00038468 File Offset: 0x00036668
	private void ForceComplete()
	{
		GameManager.Instance.UpdateObjective(ObjectiveDataVO.Create("OBJECTIVES/NEW_OBJECTIVE_HEADER", "OBJECTIVES/CH2_OBJECTIVE_SECOND_VALVE", string.Empty, 0f, false, 0f));
		this.m_StrikeUpTheBand.SetActive(false);
		this.m_Valve.SetActive(false);
		this.m_Valve.transform.localEulerAngles = new Vector3(360f, 0f, 0f);
		this.HandleValveHandleRotateOnComplete();
		this.m_Cutout.gameObject.SetActive(true);
		this.HandleCutoutSequenceOnComplete();
	}

	// Token: 0x060005D3 RID: 1491 RVA: 0x000384F8 File Offset: 0x000366F8
	protected override void OnDisposed()
	{
		if (this.m_Valve)
		{
			this.m_Valve.OnInteracted -= this.HandleValveOnInteracted;
		}
		if (this.m_JumpscareTrigger != null)
		{
			this.m_JumpscareTrigger.OnEnter -= this.HandleJumpscareTriggerOnEnter;
		}
		this.m_ValveClip = null;
		this.m_JumpscareClip = null;
		this.m_HenryClip = null;
		base.OnDisposed();
	}

	// Token: 0x04000458 RID: 1112
	[Header("Objective: Turn Valve")]
	[SerializeField]
	private GameObject m_InkBlockage;

	// Token: 0x04000459 RID: 1113
	[SerializeField]
	private Interactable m_Valve;

	// Token: 0x0400045A RID: 1114
	[SerializeField]
	private List<InkPipeController> m_PipeControllers;

	// Token: 0x0400045B RID: 1115
	[Header("Achievement: Strike Up The Band")]
	[SerializeField]
	private GameObject m_StrikeUpTheBand;

	// Token: 0x0400045C RID: 1116
	[Header("Event Triggers")]
	[SerializeField]
	private EventTrigger m_JumpscareTrigger;

	// Token: 0x0400045D RID: 1117
	[Header("Steam Particles")]
	[SerializeField]
	private ParticleSystem m_SteamJet;

	// Token: 0x0400045E RID: 1118
	[Header("Cutout Jumpscare")]
	[SerializeField]
	private MeshRenderer m_CutoutMeshRenderer;

	// Token: 0x0400045F RID: 1119
	[SerializeField]
	private Transform m_Cutout;

	// Token: 0x04000460 RID: 1120
	[SerializeField]
	private Transform m_CutoutStartPosition;

	// Token: 0x04000461 RID: 1121
	[SerializeField]
	private Transform m_CutoutScarePosition;

	// Token: 0x04000462 RID: 1122
	[SerializeField]
	private Transform m_CutoutEndPosition;

	// Token: 0x04000463 RID: 1123
	[Header("Ink")]
	[SerializeField]
	private GameObject m_ScareInk;

	// Token: 0x04000464 RID: 1124
	[Header("DEV CHEATS")]
	[SerializeField]
	private Transform m_CheatPoint;

	// Token: 0x04000465 RID: 1125
	private AudioClip m_ValveClip;

	// Token: 0x04000466 RID: 1126
	private AudioClip m_JumpscareClip;

	// Token: 0x04000467 RID: 1127
	private AudioClip m_HenryClip;
}
