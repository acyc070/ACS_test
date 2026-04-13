using System;
using System.Collections.Generic;
using DG.Tweening;
using S13Audio;
using UnityEngine;

// Token: 0x02000066 RID: 102
public class CH1BasementController : BaseController
{
	// Token: 0x06000389 RID: 905 RVA: 0x00005532 File Offset: 0x00003732
	public override void InitOnComplete()
	{
		base.InitOnComplete();
		this.m_Door.Lock();
		this.m_ValveClip = GameManager.Instance.GetAudioClip("Audio/SFX/SFX_Valve_Turn_01");
	}

	// Token: 0x0600038A RID: 906 RVA: 0x0002B414 File Offset: 0x00029614
	public override void Activate()
	{
		this.m_CurrentValve = -1;
		this.SetNextValve();
		this.m_IsActivated = true;
		if (GameManager.Instance.GameData.CurrentSaveFile.CH1Data.BasementObjective.IsComplete)
		{
			this.ForceComplete();
			return;
		}
		if (GameManager.Instance.GameData.CurrentSaveFile.CH1Data.BasementObjective.IsStarted)
		{
			return;
		}
		DOTween.Sequence().InsertCallback(2f, delegate
		{
			GameManager.Instance.ShowObjective(ObjectiveDataVO.Create("OBJECTIVES/NEW_OBJECTIVE_HEADER", "OBJECTIVES/CH1_OBJ_07", "OBJECTIVES/CH1_OBJ_07_TIP", 4f, false, 0f));
			GameManager.Instance.GameData.CurrentSaveFile.CH1Data.BasementObjective.IsStarted = true;
			GameManager.Instance.GameDataManager.Save(false, true);
		});
	}

	// Token: 0x0600038B RID: 907 RVA: 0x0002B4B0 File Offset: 0x000296B0
	private void Update()
	{
		if (!this.m_IsActivated || base.IsDisposed)
		{
			return;
		}
		bool flag = GameManager.Instance.Player.CurrentFootstepType == FootstepTypes.INK_DEEP;
		GameManager.Instance.Player.SetJump(!flag);
		GameManager.Instance.Player.SetSlowed(flag);
	}

	// Token: 0x0600038C RID: 908 RVA: 0x0002B50C File Offset: 0x0002970C
	private void SetNextValve()
	{
		this.m_CurrentValve++;
		if (this.m_CurrentValve > this.m_Valves.Count - 1)
		{
			this.m_Door.Unlock();
			this.m_Door.OnOpen += this.HandleDoorOnOpen;
		}
		else
		{
			this.SetValve(this.m_Valves[this.m_CurrentValve]);
		}
	}

	// Token: 0x0600038D RID: 909 RVA: 0x0002B580 File Offset: 0x00029780
	private void HandleDoorOnOpen(object sender, EventArgs e)
	{
		this.m_Door.OnOpen -= this.HandleDoorOnOpen;
		GameManager.Instance.ShowObjective(ObjectiveDataVO.Create("OBJECTIVES/NEW_OBJECTIVE_HEADER", "OBJECTIVES/CH1_OBJ_08", "OBJECTIVES/CH1_OBJ_08_TIP", 4f, false, 0f));
		GameManager.Instance.GameData.CurrentSaveFile.CH1Data.BasementObjective.IsComplete = true;
		GameManager.Instance.GameDataManager.Save(false, true);
		base.SendOnComplete();
	}

	// Token: 0x0600038E RID: 910 RVA: 0x0002B604 File Offset: 0x00029804
	private void SetValve(CH1PipeValve valve)
	{
		this.m_NextInkLevel = this.m_InkLevels[this.m_CurrentValve];
		this.m_ActiveValve = valve;
		this.m_ActiveValve.Activate();
		this.m_ActiveValve.OnInteracted += this.HandleValveOnInteracted;
	}

	// Token: 0x0600038F RID: 911 RVA: 0x0000555A File Offset: 0x0000375A
	private void HandleValveOnInteracted(object sender, EventArgs e)
	{
		this.m_ActiveValve.OnInteracted -= this.HandleValveOnInteracted;
		this.DOValveInteract().OnComplete(new TweenCallback(this.SetNextValve));
	}

	// Token: 0x06000390 RID: 912 RVA: 0x0002B654 File Offset: 0x00029854
	private Sequence DOValveInteract()
	{
		this.ResetSequence();
		float num = 0f;
		float num2 = 1f;
		if (this.m_CurrentValve == 0)
		{
			S13AudioManager.Instance.InvokeEvent("evt_stairwell_valve1", 0f);
		}
		else if (this.m_CurrentValve == 1)
		{
			S13AudioManager.Instance.InvokeEvent("evt_stairwell_valve2", 0f);
		}
		else if (this.m_CurrentValve == 2)
		{
			S13AudioManager.Instance.InvokeEvent("evt_stairwell_valve3", 0f);
		}
		GameManager.Instance.AudioManager.Play(this.m_ValveClip, AudioObjectType.SOUND_EFFECT, 0, false);
		this.m_Sequence.Insert(num, this.m_ActiveValve.DORotate(num2 + 1f));
		num += num2 / 2f;
		num2 = 14f / (float)(this.m_CurrentValve + 1);
		if (this.m_CurrentValve < this.m_Valves.Count - 1)
		{
			DisposableObject disposableObject = this.m_Blockers[this.m_CurrentValve];
			this.m_Sequence.InsertCallback(num + 2f, new TweenCallback(disposableObject.Dispose));
		}
		this.m_Sequence.Insert(num, this.m_Ink.DOLocalMoveY(this.m_NextInkLevel.localPosition.y, num2, false).SetEase(Ease.InOutQuad));
		return this.m_Sequence;
	}

	// Token: 0x06000391 RID: 913 RVA: 0x0000558B File Offset: 0x0000378B
	private void ResetSequence()
	{
		this.KillSequence();
		this.m_Sequence = DOTween.Sequence();
	}

	// Token: 0x06000392 RID: 914 RVA: 0x0000559E File Offset: 0x0000379E
	private void KillSequence()
	{
		if (this.m_Sequence != null)
		{
			this.m_Sequence.Kill(false);
			this.m_Sequence = null;
		}
	}

	// Token: 0x06000393 RID: 915 RVA: 0x0002B7B0 File Offset: 0x000299B0
	private void ForceComplete()
	{
		S13AudioManager.Instance.InvokeEvent("evt_CH1_save_point_06", 0f);
		GameManager.Instance.UpdateObjective(ObjectiveDataVO.Create("OBJECTIVES/NEW_OBJECTIVE_HEADER", "OBJECTIVES/CH1_OBJ_08", "OBJECTIVES/CH1_OBJ_08_TIP", 0f, false, 0f));
		this.m_Door.ForceOpen(145f);
		this.m_Door.Lock();
		this.m_Ink.gameObject.SetActive(false);
		base.SendOnComplete();
	}

	// Token: 0x06000394 RID: 916 RVA: 0x000055BE File Offset: 0x000037BE
	protected override void OnDisposed()
	{
		this.KillSequence();
		this.m_ActiveValve = null;
		this.m_NextInkLevel = null;
		this.m_ValveClip = null;
		base.OnDisposed();
	}

	// Token: 0x040001F2 RID: 498
	[Header("Objective: Clear Ink")]
	[SerializeField]
	private Transform m_Ink;

	// Token: 0x040001F3 RID: 499
	[SerializeField]
	private List<Transform> m_InkLevels;

	// Token: 0x040001F4 RID: 500
	[SerializeField]
	private List<CH1PipeValve> m_Valves;

	// Token: 0x040001F5 RID: 501
	[SerializeField]
	private List<DisposableObject> m_Blockers;

	// Token: 0x040001F6 RID: 502
	[SerializeField]
	private BaseDoorController m_Door;

	// Token: 0x040001F7 RID: 503
	[Header("DEV CHEATS")]
	[SerializeField]
	private Transform m_CheatPoint;

	// Token: 0x040001F8 RID: 504
	private CH1PipeValve m_ActiveValve;

	// Token: 0x040001F9 RID: 505
	private Transform m_NextInkLevel;

	// Token: 0x040001FA RID: 506
	private Sequence m_Sequence;

	// Token: 0x040001FB RID: 507
	private AudioClip m_ValveClip;

	// Token: 0x040001FC RID: 508
	private bool m_IsActivated;

	// Token: 0x040001FD RID: 509
	private int m_CurrentValve;
}
