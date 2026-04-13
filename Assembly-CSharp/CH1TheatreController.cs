using System;
using System.Collections.Generic;
using DG.Tweening;
using S13Audio;
using UnityEngine;

// Token: 0x02000077 RID: 119
public class CH1TheatreController : BaseController
{
	// Token: 0x0600043D RID: 1085 RVA: 0x0002F108 File Offset: 0x0002D308
	public override void InitOnComplete()
	{
		base.InitOnComplete();
		this.m_TheatreMainEvent.SetActive(false);
		this.m_TheatreEnterEvent.SetActive(false);
		this.m_TheatreExitEvent.SetActive(false);
		this.m_Interactable.SetActive(false);
		this.SetInkEnableGameObjectsActive(false);
		this.SetEnableGameObjectsActive(false);
		this.m_HenryClip06 = GameManager.Instance.GetAudioClip("Audio/DIA/CH1/Henry/DIA_CH1_HENRY_06");
		this.m_BendyCartoonMusicClip = GameManager.Instance.GetAudioClip("Audio/MUS/CH1/MUS_BendyCartoonMusic");
		this.m_TheatreProjectorClip = GameManager.Instance.GetAudioClip("Audio/SFX/SFX_Projector_Run_With_Film_01");
		this.m_DuctCrawlingClip = GameManager.Instance.GetAudioClip("Audio/SFX/SFX_Duct_Scare_01");
		this.m_FlowValveClip = GameManager.Instance.GetAudioClip("Audio/SFX/SFX_Valve_Turn_01");
		this.m_JumpscareClip = GameManager.Instance.GetAudioClip("Audio/SFX/SFX_Jumpscare_01");
		this.m_InkRenderer.material.SetFloat("_Cutout", 0f);
		for (int i = 0; i < this.m_AnimationControllers.Length; i++)
		{
			this.m_AnimationControllers[i].Stop();
		}
	}

	// Token: 0x0600043E RID: 1086 RVA: 0x0002F218 File Offset: 0x0002D418
	public override void Activate()
	{
		if (GameManager.Instance.GameData.CurrentSaveFile.CH1Data.TheatreObjective.IsComplete)
		{
			this.ForceComplete();
		}
		else if (GameManager.Instance.GameData.CurrentSaveFile.CH1Data.TheatreObjective.IsStarted)
		{
			this.ForceStart();
		}
		else
		{
			this.InternalActivate();
		}
	}

	// Token: 0x0600043F RID: 1087 RVA: 0x0002F288 File Offset: 0x0002D488
	private void InternalActivate()
	{
		AudioObject audioObject = GameManager.Instance.ShowDialogue(DialogueDataVO.Create(this.m_HenryClip06, "DIACH1/DIA_CH1_HENRY_06", false));
		audioObject.OnComplete += delegate(object _sender, EventArgs _e)
		{
			GameManager.Instance.ShowObjective(ObjectiveDataVO.Create("OBJECTIVES/NEW_OBJECTIVE_HEADER", "OBJECTIVES/CH1_OBJ_04", "OBJECTIVES/CH1_OBJ_04_TIP", 4f, false, 0f));
			GameManager.Instance.GameData.CurrentSaveFile.CH1Data.CollectablesObjective.IsComplete = true;
			GameManager.Instance.GameData.CurrentSaveFile.CH1Data.TheatreObjective.IsStarted = true;
			GameManager.Instance.GameDataManager.Save(false, true);
		};
		this.m_TheatreEnterEvent.OnEnter += this.HandleTheatreEnterOnEnter;
		this.m_TheatreEnterEvent.SetActive(true);
	}

	// Token: 0x06000440 RID: 1088 RVA: 0x0002F2F8 File Offset: 0x0002D4F8
	private void ForceStart()
	{
		GameManager.Instance.UpdateObjective(ObjectiveDataVO.Create("OBJECTIVES/NEW_OBJECTIVE_HEADER", "OBJECTIVES/CH1_OBJ_04", "OBJECTIVES/CH1_OBJ_04_TIP", 0f, false, 0f));
		this.m_TheatreEnterEvent.OnEnter += this.HandleTheatreEnterOnEnter;
		this.m_TheatreEnterEvent.SetActive(true);
	}

	// Token: 0x06000441 RID: 1089 RVA: 0x0002F354 File Offset: 0x0002D554
	private void ForceComplete()
	{
		S13AudioManager.Instance.InvokeEvent("evt_CH1_save_point_03", 0f);
		this.m_RaisingInk.tag = "DeepInk";
		Vector3 localPosition = this.m_RaisingInk.localPosition;
		localPosition.y += 1f;
		this.m_RaisingInk.localPosition = localPosition;
		this.m_InkRenderer.material.SetFloat("_Cutout", 1f);
		for (int i = 0; i < this.m_AnimationControllers.Length; i++)
		{
			this.m_AnimationControllers[i].Play();
		}
		for (int j = 0; j < this.m_InkPipes.Count; j++)
		{
			this.m_InkPipes[j].TurnOn();
		}
		this.SetInkEnableGameObjectsActive(true);
		this.SetEnableGameObjectsActive(true);
		this.m_Cutout.localPosition = this.m_CutoutEndPosition.localPosition;
		this.m_Cutout.localRotation = this.m_CutoutEndPosition.localRotation;
		Vector3 localPosition2 = this.m_Interactable.transform.localPosition;
		localPosition2.z -= 0.15f;
		this.m_Interactable.transform.localPosition = localPosition2;
		this.m_ProjectorController.TurnOn(true);
		this.m_ProjectorController.FilmAudioObject = GameManager.Instance.AudioManager.PlayAtPosition(this.m_TheatreProjectorClip, this.m_ProjectorController.AudioPosition.position, AudioObjectType.MUSIC, -1, false, null);
		base.SendOnComplete();
	}

	// Token: 0x06000442 RID: 1090 RVA: 0x0002F4D4 File Offset: 0x0002D6D4
	private void SetEnableGameObjectsActive(bool active)
	{
		for (int i = 0; i < this.m_EnableGameObjects.Count; i++)
		{
			this.m_EnableGameObjects[i].SetActive(active);
		}
	}

	// Token: 0x06000443 RID: 1091 RVA: 0x0002F510 File Offset: 0x0002D710
	private void SetInkEnableGameObjectsActive(bool active)
	{
		for (int i = 0; i < this.m_InkEnableGameObjects.Count; i++)
		{
			this.m_InkEnableGameObjects[i].SetActive(active);
		}
	}

	// Token: 0x06000444 RID: 1092 RVA: 0x0002F54C File Offset: 0x0002D74C
	private void HandleTheatreEnterOnEnter(object sender, EventArgs e)
	{
		this.m_TheatreEnterEvent.OnEnter -= this.HandleTheatreEnterOnEnter;
		GameManager.Instance.AudioManager.Play(this.m_JumpscareClip, AudioObjectType.SOUND_EFFECT, 0, false);
		this.SetEnableGameObjectsActive(true);
		Camera.main.transform.DOShakePosition(0.3f, 0.1f, 15, 90f, false, true);
		this.m_Cutout.localPosition = this.m_CutoutStartPosition.localPosition;
		this.m_Cutout.localRotation = this.m_CutoutStartPosition.localRotation;
		this.DOCutoutSequence().OnComplete(new TweenCallback(this.HandleCutoutSequenceOnComplete));
	}

	// Token: 0x06000445 RID: 1093 RVA: 0x0002F5F8 File Offset: 0x0002D7F8
	private Sequence DOCutoutSequence()
	{
		Sequence sequence = DOTween.Sequence();
		float num = 0f;
		float num2 = 0.25f;
		sequence.Insert(num, this.m_Cutout.DOLocalMove(this.m_CutoutScarePosition.localPosition, num2, false).SetEase(Ease.OutBack));
		sequence.Insert(num, this.m_Cutout.DORotateQuaternion(this.m_CutoutScarePosition.localRotation, num2).SetEase(Ease.OutBack));
		num += 0.85f;
		sequence.Insert(num, this.m_Cutout.DOMove(this.m_CutoutStartPosition.localPosition, num2, false).SetEase(Ease.InBack));
		sequence.Insert(num, this.m_Cutout.DORotateQuaternion(this.m_CutoutStartPosition.localRotation, num2).SetEase(Ease.InBack));
		return sequence;
	}

	// Token: 0x06000446 RID: 1094 RVA: 0x0002F6BC File Offset: 0x0002D8BC
	private void HandleCutoutSequenceOnComplete()
	{
		this.m_Cutout.localPosition = this.m_CutoutEndPosition.localPosition;
		this.m_Cutout.localRotation = this.m_CutoutEndPosition.localRotation;
		this.m_TheatreMainEvent.SetActive(true);
		this.m_TheatreMainEvent.OnEnter += this.HandleTheatreMainOnEnter;
	}

	// Token: 0x06000447 RID: 1095 RVA: 0x0002F718 File Offset: 0x0002D918
	private void HandleTheatreMainOnEnter(object sender, EventArgs e)
	{
		this.m_TheatreMainEvent.OnEnter -= this.HandleTheatreMainOnEnter;
		this.m_ProjectorController.TurnOn(false);
		this.m_ProjectorController.MusicAudioObject = GameManager.Instance.AudioManager.PlayAtPosition(this.m_BendyCartoonMusicClip, this.m_ProjectorController.MusicPosition.position, AudioObjectType.MUSIC, 0, false, null);
		this.m_ProjectorController.FilmAudioObject = GameManager.Instance.AudioManager.PlayAtPosition(this.m_TheatreProjectorClip, this.m_ProjectorController.AudioPosition.position, AudioObjectType.MUSIC, -1, false, null);
		this.m_Interactable.OnInteracted += this.HandleInteractableOnInteracted;
		this.m_Interactable.SetActive(true);
	}

	// Token: 0x06000448 RID: 1096 RVA: 0x0002F7D4 File Offset: 0x0002D9D4
	private void HandleInteractableOnInteracted(object sender, EventArgs e)
	{
		this.m_Interactable.OnInteracted -= this.HandleInteractableOnInteracted;
		this.m_Interactable.SetActive(false);
		GameManager.Instance.AudioManager.PlayAtPosition(this.m_FlowValveClip, this.m_Interactable.transform.position, AudioObjectType.SOUND_EFFECT, 0, false, null);
		this.m_Interactable.transform.DOLocalRotate(new Vector3(-360f, 0f, 0f), 1.5f, RotateMode.LocalAxisAdd).SetEase(Ease.InOutQuad).OnComplete(new TweenCallback(this.BeginInkFlow));
	}

	// Token: 0x06000449 RID: 1097 RVA: 0x0002F870 File Offset: 0x0002DA70
	private void BeginInkFlow()
	{
		S13AudioManager.Instance.InvokeEvent("evt_ink_pressure_restored", 0f);
		for (int i = 0; i < this.m_AnimationControllers.Length; i++)
		{
			this.m_AnimationControllers[i].Play();
		}
		for (int j = 0; j < this.m_InkPipes.Count; j++)
		{
			this.m_InkPipes[j].TurnOn();
		}
		this.SetInkEnableGameObjectsActive(true);
		this.DOFlooding();
		GameManager.Instance.GameData.CurrentSaveFile.CH1Data.TheatreObjective.IsComplete = true;
		GameManager.Instance.GameDataManager.Save(false, true);
		this.m_TheatreExitEvent.SetActive(true);
		this.m_TheatreExitEvent.OnEnter += this.HandleTheatreExitOnEnter;
	}

	// Token: 0x0600044A RID: 1098 RVA: 0x0002F948 File Offset: 0x0002DB48
	private Sequence DOFlooding()
	{
		Sequence sequence = DOTween.Sequence();
		float num = 0f;
		float num2 = 4f;
		this.m_RaisingInk.tag = "Ink";
		sequence.Insert(num, this.m_InkRenderer.material.DOFloat(1f, "_Cutout", num2).SetEase(Ease.InQuad));
		num += num2;
		num2 += num2 / 2f;
		sequence.Insert(num, this.m_RaisingInk.DOLocalMoveY(this.m_RaisingInk.localPosition.y + 1f, num2, false).SetEase(Ease.InOutQuad));
		sequence.InsertCallback(num + num2 / 8f, delegate
		{
			this.m_RaisingInk.tag = "DeepInk";
		});
		return sequence;
	}

	// Token: 0x0600044B RID: 1099 RVA: 0x00006096 File Offset: 0x00004296
	private void FloodingOnComplete()
	{
		this.m_TheatreExitEvent.SetActive(true);
		this.m_TheatreExitEvent.OnEnter += this.HandleTheatreExitOnEnter;
	}

	// Token: 0x0600044C RID: 1100 RVA: 0x000060BB File Offset: 0x000042BB
	private void HandleTheatreExitOnEnter(object sender, EventArgs e)
	{
		this.m_TheatreExitEvent.OnEnter -= this.HandleTheatreExitOnEnter;
		GameManager.Instance.AudioManager.Play(this.m_DuctCrawlingClip, AudioObjectType.SOUND_EFFECT, 0, false);
		base.SendOnComplete();
	}

	// Token: 0x0600044D RID: 1101 RVA: 0x0002FA00 File Offset: 0x0002DC00
	protected override void OnDisposed()
	{
		if (this.m_TheatreMainEvent)
		{
			this.m_TheatreMainEvent.OnEnter -= this.HandleTheatreMainOnEnter;
		}
		if (this.m_TheatreExitEvent)
		{
			this.m_TheatreExitEvent.OnEnter -= this.HandleTheatreExitOnEnter;
		}
		if (this.m_TheatreEnterEvent)
		{
			this.m_TheatreEnterEvent.OnEnter -= this.HandleTheatreEnterOnEnter;
		}
		if (this.m_Interactable)
		{
			this.m_Interactable.OnInteracted -= this.HandleInteractableOnInteracted;
		}
		this.m_HenryClip06 = null;
		this.m_FlowValveClip = null;
		this.m_DuctCrawlingClip = null;
		this.m_BendyCartoonMusicClip = null;
		this.m_TheatreProjectorClip = null;
		this.m_JumpscareClip = null;
		base.OnDisposed();
	}

	// Token: 0x040002B4 RID: 692
	private const string CUTOUT = "_Cutout";

	// Token: 0x040002B5 RID: 693
	[Header("Jumpscare: Bendy Cutout")]
	[SerializeField]
	private Transform m_Cutout;

	// Token: 0x040002B6 RID: 694
	[SerializeField]
	private Transform m_CutoutStartPosition;

	// Token: 0x040002B7 RID: 695
	[SerializeField]
	private Transform m_CutoutScarePosition;

	// Token: 0x040002B8 RID: 696
	[SerializeField]
	private Transform m_CutoutEndPosition;

	// Token: 0x040002B9 RID: 697
	[SerializeField]
	private List<GameObject> m_EnableGameObjects;

	// Token: 0x040002BA RID: 698
	[SerializeField]
	private EventTrigger m_TheatreEnterEvent;

	// Token: 0x040002BB RID: 699
	[SerializeField]
	private EventTrigger m_TheatreExitEvent;

	// Token: 0x040002BC RID: 700
	[Header("Jumpscare: Projector")]
	[SerializeField]
	private ProjectorController m_ProjectorController;

	// Token: 0x040002BD RID: 701
	[SerializeField]
	private EventTrigger m_TheatreMainEvent;

	// Token: 0x040002BE RID: 702
	[Header("Objective: Ink Flow Button")]
	[SerializeField]
	private Interactable m_Interactable;

	// Token: 0x040002BF RID: 703
	[SerializeField]
	private List<InkPipeController> m_InkPipes;

	// Token: 0x040002C0 RID: 704
	[SerializeField]
	private List<GameObject> m_InkEnableGameObjects;

	// Token: 0x040002C1 RID: 705
	[SerializeField]
	private Transform m_RaisingInk;

	// Token: 0x040002C2 RID: 706
	[SerializeField]
	private MeshRenderer m_InkRenderer;

	// Token: 0x040002C3 RID: 707
	[SerializeField]
	private BasicAnimationController[] m_AnimationControllers;

	// Token: 0x040002C4 RID: 708
	private AudioClip m_HenryClip06;

	// Token: 0x040002C5 RID: 709
	private AudioClip m_BendyCartoonMusicClip;

	// Token: 0x040002C6 RID: 710
	private AudioClip m_TheatreProjectorClip;

	// Token: 0x040002C7 RID: 711
	private AudioClip m_FlowValveClip;

	// Token: 0x040002C8 RID: 712
	private AudioClip m_DuctCrawlingClip;

	// Token: 0x040002C9 RID: 713
	private AudioClip m_JumpscareClip;
}
