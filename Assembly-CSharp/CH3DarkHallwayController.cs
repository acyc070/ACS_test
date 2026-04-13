using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using S13Audio;
using UnityEngine;

// Token: 0x020000B3 RID: 179
public class CH3DarkHallwayController : BaseController
{
	// Token: 0x060006CA RID: 1738 RVA: 0x0003E750 File Offset: 0x0003C950
	public override void InitOnComplete()
	{
		base.InitOnComplete();
		this.m_Boris = GameManager.Instance.CharacterManager.Boris;
		this.m_DarknessEntranceBlocker.SetActive(false);
		this.m_HandCrowbarDialogue.SetActive(false);
		this.m_DarkHallwayEnterLockedIn.SetActive(false);
		this.m_DarkHallwayExitLockedIn.SetActive(false);
		this.m_DuctCrawlingClip = GameManager.Instance.GetAudioClip("Audio/SFX/CH3/SFX_CH3_runningoverhead");
		this.m_HenryDontBeScaredDialogueClip = GameManager.Instance.GetAudioClip("Audio/DIA/CH3/Henry/ch3_henry_30_dontbescaredboris");
		this.m_HenryDarkDialogueClip = GameManager.Instance.GetAudioClip("Audio/DIA/CH3/Henry/ch3_henry_08_lookslikeitsdarkupahead");
		this.m_FlashlightClip = GameManager.Instance.GetAudioClip("Audio/SFX/CH3/SFX_CH3_flashlighturnon");
		this.m_VentCoverClip = GameManager.Instance.GetAudioClip("Audio/SFX/CH3/SFX_CH3_borisventcover");
		this.m_BorisEnterVentClip = GameManager.Instance.GetAudioClip("Audio/SFX/CH3/SFX_CH3_borisducts");
		this.m_HenryDidYouHearThatClip = GameManager.Instance.GetAudioClips("Audio/DIA/CH3/Henry/DidYouHearThat/");
		this.m_HenryDeadEndClip = GameManager.Instance.GetAudioClips("Audio/DIA/CH3/Henry/DeadEnd/");
		this.m_OpenedDoor.ForceOpen();
		this.m_ClosedDoor.ForceClose();
		this.m_HallwayDoor.ForceOpen();
	}

	// Token: 0x060006CB RID: 1739 RVA: 0x0003E874 File Offset: 0x0003CA74
	public override void Activate()
	{
		if (GameManager.Instance.GameData.CurrentSaveFile.CH3Data.DarkHallwayObjective.IsComplete)
		{
			this.ForceComplete();
			return;
		}
		this.m_HallwayTrigger.OnEnter += this.HandleHallwayOnEnter;
		this.m_HallwayTrigger.OnExit += this.HandleHallwayOnExit;
		this.m_DoorCloseTrigger.SetActive(false);
		this.m_BorisTrigger.SetActive(false);
		this.m_HandCrowbarDialogue.SetActive(true);
		this.m_HandCrowbarDialogue.OnEnter += this.HandleHandoverDialogueOnEnter;
		this.m_Boris.OnWaypointComplete += this.HandleFirstWaypointOnComplete;
		this.m_Boris.UpdateWaypointList(this.m_BorisInitialPath.Waypoints, false);
	}

	// Token: 0x060006CC RID: 1740 RVA: 0x0003E944 File Offset: 0x0003CB44
	private void HandleHandoverDialogueOnEnter(object sender, EventArgs e)
	{
		this.m_HandCrowbarDialogue.OnEnter -= this.HandleHandoverDialogueOnEnter;
		GameManager.Instance.ShowDialogue(DialogueDataVO.Create(this.m_HenryDarkDialogueClip, "DIACH3/DIA_CH3_HENRY_08", false)).OnComplete += delegate(object _sender, EventArgs _e)
		{
			GameManager.Instance.ShowObjective(ObjectiveDataVO.Create("OBJECTIVES/NEW_OBJECTIVE_HEADER", "OBJECTIVES/CH3_OBJECTIVE_07", "OBJECTIVES/CH3_OBJECTIVE_07_TIP", 4f, false, 0f));
			this.m_Flashlight.OnInteracted += this.HandleFlashlightOnInteracted;
			this.m_Flashlight.Activate();
		};
	}

	// Token: 0x060006CD RID: 1741 RVA: 0x00007EFD File Offset: 0x000060FD
	private void HandleFirstWaypointOnComplete(object sender, EventArgs e)
	{
		this.m_Boris.OnWaypointComplete -= this.HandleFirstWaypointOnComplete;
		this.m_Boris.StopWaypointPathing();
		this.m_BorisInitialPath.Dispose();
	}

	// Token: 0x060006CE RID: 1742 RVA: 0x0003E994 File Offset: 0x0003CB94
	private void HandleFlashlightOnInteracted(object sender, EventArgs e)
	{
		this.m_Flashlight.OnInteracted -= this.HandleFlashlightOnInteracted;
		GameManager.Instance.AudioManager.Play(this.m_FlashlightClip, AudioObjectType.SOUND_EFFECT, 0, false);
		this.m_DarkenerCollider.enabled = false;
		this.m_Boris.OnWaypointComplete -= this.HandleFirstWaypointOnComplete;
		this.m_Boris.OnWaypointComplete += this.HandleDarknessWaypointOnComplete;
		this.m_Boris.AddToWaypointList(this.m_BorisDarknessPath.Waypoints, false);
		this.m_DarkHallwayEnterLockedIn.SetActive(true);
		this.m_DarkHallwayEnterLockedIn.OnEnter += this.HandleDarkHallwayEnterLockedInOnEnter;
		this.m_DuctCrawlingTrigger.SetActive(true);
		this.m_DuctCrawlingTrigger.OnEnter += this.HandleDuctCrawlingTriggerOnEnter;
	}

	// Token: 0x060006CF RID: 1743 RVA: 0x0003EA68 File Offset: 0x0003CC68
	private void HandleDuctCrawlingTriggerOnEnter(object sender, EventArgs e)
	{
		this.m_DuctCrawlingTrigger.OnEnter -= this.HandleDuctCrawlingTriggerOnEnter;
		this.m_Boris.LookAround();
		GameManager.Instance.AudioManager.Play(this.m_DuctCrawlingClip, AudioObjectType.SOUND_EFFECT, 0, false).OnComplete += this.HandleDuctAudioOnComplete;
	}

	// Token: 0x060006D0 RID: 1744 RVA: 0x0003EAC0 File Offset: 0x0003CCC0
	private void HandleDuctAudioOnComplete(object sender, EventArgs e)
	{
		(sender as AudioObject).OnComplete -= this.HandleDuctAudioOnComplete;
		for (int i = 0; i < this.m_HenryDidYouHearThatClip.Length; i++)
		{
			GameManager.Instance.ShowDialogue(DialogueDataVO.Create(this.m_HenryDidYouHearThatClip[i], SubtitleConstants.DIA_CH3_HENRY_DID_YOU_HEAR_THAT[i], true));
		}
	}

	// Token: 0x060006D1 RID: 1745 RVA: 0x0003EB20 File Offset: 0x0003CD20
	private void HandleDarknessWaypointOnComplete(object sender, EventArgs e)
	{
		this.m_Boris.OnWaypointComplete -= this.HandleDarknessWaypointOnComplete;
		this.m_Boris.StopWaypointPathing();
		this.m_IsBorisInDarkness = true;
		this.m_BorisDarknessPath.Dispose();
		if (this.m_BorisInitialPath != null)
		{
			this.m_BorisInitialPath.Dispose();
		}
		if (this.CheckInDarkness())
		{
			this.CloseDarknessDoor();
			return;
		}
	}

	// Token: 0x060006D2 RID: 1746 RVA: 0x0003EB90 File Offset: 0x0003CD90
	private void HandleDarkHallwayEnterLockedInOnEnter(object sender, EventArgs e)
	{
		this.m_DarkHallwayEnterLockedIn.OnEnter -= this.HandleDarkHallwayEnterLockedInOnEnter;
		this.m_DarkHallwayEnterLockedIn.SetActive(false);
		this.m_IsPlayerInDarkness = true;
		GameManager.Instance.ShowDialogue(DialogueDataVO.Create(this.m_HenryDontBeScaredDialogueClip, "DIACH3/DIA_CH3_HENRY_30", false));
		if (this.CheckInDarkness())
		{
			this.CloseDarknessDoor();
			return;
		}
		this.m_DarkHallwayExitLockedIn.ResetTrigger();
		this.m_DarkHallwayExitLockedIn.SetActive(true);
		this.m_DarkHallwayExitLockedIn.OnEnter += this.HandleDarkHallwayExitLocedInOnEnter;
	}

	// Token: 0x060006D3 RID: 1747 RVA: 0x0003EC24 File Offset: 0x0003CE24
	private void HandleDarkHallwayExitLocedInOnEnter(object sender, EventArgs e)
	{
		this.m_DarkHallwayExitLockedIn.OnEnter -= this.HandleDarkHallwayExitLocedInOnEnter;
		this.m_DarkHallwayExitLockedIn.SetActive(false);
		this.m_IsPlayerInDarkness = false;
		this.m_DarkHallwayEnterLockedIn.ResetTrigger();
		this.m_DarkHallwayEnterLockedIn.SetActive(true);
		this.m_DarkHallwayEnterLockedIn.OnEnter += this.HandleDarkHallwayEnterLockedInOnEnter;
	}

	// Token: 0x060006D4 RID: 1748 RVA: 0x00007F2C File Offset: 0x0000612C
	private bool CheckInDarkness()
	{
		return this.m_IsPlayerInDarkness && this.m_IsBorisInDarkness;
	}

	// Token: 0x060006D5 RID: 1749 RVA: 0x0003EC8C File Offset: 0x0003CE8C
	private void CloseDarknessDoor()
	{
		this.m_DarknessEntranceBlocker.SetActive(true);
		this.m_HallwayDoor.Close();
		this.m_Boris.StopWaypointPathing();
		this.m_Boris.SlowSpeeds();
		this.m_Boris.UpdateWaypointList(this.m_BorisDarknessHallwayPath.Waypoints, false);
		this.m_BorisTrigger.SetActive(true);
		this.m_BorisTrigger.OnEnter += this.HandleBorisTriggerOnEnter;
	}

	// Token: 0x060006D6 RID: 1750 RVA: 0x0003ED00 File Offset: 0x0003CF00
	private void HandleBorisTriggerOnEnter(object sender, EventArgs e)
	{
		this.m_BorisTrigger.OnEnter -= this.HandleBorisTriggerOnEnter;
		this.m_Boris.ResetSpeeds();
		this.borisVentPosition = this.m_BorisFinalPath.Waypoints[this.m_BorisFinalPath.Waypoints.Count - 1].transform.position;
		this.borisVentEuler = this.m_BorisFinalPath.Waypoints[this.m_BorisFinalPath.Waypoints.Count - 1].transform.eulerAngles;
		this.m_Boris.OnWaypointComplete += this.HandleBorisOnWaypointComplete;
		this.m_Boris.UpdateWaypointList(this.m_BorisFinalPath.Waypoints, false);
		this.m_DoorCloseTrigger.SetActive(true);
		this.m_DoorCloseTrigger.OnEnter += this.HandleDoorCloseTriggerOnEnter;
	}

	// Token: 0x060006D7 RID: 1751 RVA: 0x00007F42 File Offset: 0x00006142
	private void HandleDoorCloseTriggerOnEnter(object sender, EventArgs e)
	{
		this.m_DoorCloseTrigger.OnEnter -= this.HandleDoorCloseTriggerOnEnter;
		this.CloseDoor();
	}

	// Token: 0x060006D8 RID: 1752 RVA: 0x0003EDE4 File Offset: 0x0003CFE4
	private void HandleBorisOnWaypointComplete(object sender, EventArgs e)
	{
		this.m_Boris.OnWaypointComplete -= this.HandleBorisOnWaypointComplete;
		this.m_BorisFinalPath.Dispose();
		this.m_Boris.transform.position = this.borisVentPosition;
		this.m_Boris.transform.eulerAngles = this.borisVentEuler;
		this.m_Boris.StopLooking();
		for (int i = 0; i < this.m_HenryDeadEndClip.Length; i++)
		{
			AudioObject audioObject = GameManager.Instance.ShowDialogue(DialogueDataVO.Create(this.m_HenryDeadEndClip[i], SubtitleConstants.DIA_CH3_HENRY_DEAD_END[i], true));
			if (i == 1)
			{
				audioObject.OnComplete += this.HandleDeadEndOnComplete;
			}
		}
	}

	// Token: 0x060006D9 RID: 1753 RVA: 0x0003EE9C File Offset: 0x0003D09C
	private void HandleDeadEndOnComplete(object sender, EventArgs e)
	{
		GameManager.Instance.ShowObjective(ObjectiveDataVO.Create("OBJECTIVES/NEW_OBJECTIVE_HEADER", "OBJECTIVES/CH3_OBJECTIVE_08", string.Empty, 4f, false, 0f));
		this.m_Boris.Interact.SetActive(true);
		this.m_Boris.Interact.OnInteracted += this.HandleBorisOnInteracted;
	}

	// Token: 0x060006DA RID: 1754 RVA: 0x00007F61 File Offset: 0x00006161
	private void CloseDoor()
	{
		this.m_BlockerCollider.SetActive(true);
		this.m_OpenedDoor.OnClose += this.HandleOpenedDoorOnClosed;
		this.m_OpenedDoor.Close();
	}

	// Token: 0x060006DB RID: 1755 RVA: 0x0003EF00 File Offset: 0x0003D100
	private void HandleOpenedDoorOnClosed(object sender, EventArgs e)
	{
		this.m_OpenedDoor.OnClose -= this.HandleOpenedDoorOnClosed;
		this.m_HallwayTrigger.OnEnter -= this.HandleHallwayOnEnter;
		this.m_HallwayTrigger.OnExit -= this.HandleHallwayOnExit;
		this.m_HallwayTrigger.Dispose();
	}

	// Token: 0x060006DC RID: 1756 RVA: 0x0003EF60 File Offset: 0x0003D160
	private void HandleBorisOnInteracted(object sender, EventArgs e)
	{
		this.m_Boris.Interact.OnInteracted -= this.HandleBorisOnInteracted;
		this.m_Boris.Interact.SetActive(false);
		GameManager.Instance.Player.WeaponGameObject.transform.SetParent(this.m_BorisHandParent);
		GameManager.Instance.Player.WeaponGameObject.transform.localPosition = Vector3.zero;
		GameManager.Instance.Player.WeaponGameObject.transform.localEulerAngles = Vector3.zero;
		GameManager.Instance.Player.WeaponGameObject.layer = LayerMask.NameToLayer("IgnoreLight");
		IEnumerator enumerator = GameManager.Instance.Player.WeaponGameObject.transform.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				Transform transform = (Transform)obj;
				transform.gameObject.layer = LayerMask.NameToLayer("IgnoreLight");
			}
		}
		finally
		{
			IDisposable disposable;
			if ((disposable = enumerator as IDisposable) != null)
			{
				disposable.Dispose();
			}
		}
		this.m_FlashlightToDestroy = GameManager.Instance.Player.WeaponGameObject;
		GameManager.Instance.Player.WeaponGameObject = null;
		float ventPosition = this.m_Vent.localPosition.y;
		GameManager.Instance.AudioManager.Play(this.m_VentCoverClip, AudioObjectType.SOUND_EFFECT, 0, false);
		this.m_Vent.DOLocalMoveY(ventPosition + 3.5f, 0.5f, false).SetDelay(0.75f).SetEase(Ease.InOutQuad)
			.OnComplete(delegate
			{
				this.m_Vent.DOLocalMoveY(ventPosition, 0.5f, false).SetDelay(7f).SetEase(Ease.InOutQuad);
				this.VentOpenOnComplete();
			});
	}

	// Token: 0x060006DD RID: 1757 RVA: 0x00007F91 File Offset: 0x00006191
	private void VentOpenOnComplete()
	{
		this.m_Boris.EnterVent();
		GameManager.Instance.AudioManager.Play(this.m_BorisEnterVentClip, AudioObjectType.SOUND_EFFECT, 0, false).OnComplete += this.HandleBorisDuctAudioOnComplete;
	}

	// Token: 0x060006DE RID: 1758 RVA: 0x0003F12C File Offset: 0x0003D32C
	private void HandleBorisDuctAudioOnComplete(object sender, EventArgs e)
	{
		(sender as AudioObject).OnComplete -= this.HandleBorisDuctAudioOnComplete;
		global::UnityEngine.Object.Destroy(this.m_FlashlightToDestroy);
		this.m_ClosedDoor.Open();
		GameManager.Instance.GameCamera.transform.DOShakePosition(8f, 0.1f, 7, 90f, false, true).SetDelay(1f).OnComplete(delegate
		{
			GameManager.Instance.GameCamera.transform.localPosition = Vector3.zero;
		});
		this.m_Boris.transform.position = this.m_BorisWarpPosition.position;
		Vector3 eulerAngles = this.m_BorisWarpPosition.eulerAngles;
		eulerAngles.x = 0f;
		eulerAngles.z = 0f;
		this.m_Boris.transform.eulerAngles = eulerAngles;
		this.m_Boris.ResetAll();
		this.m_Boris.LookAtPlayer();
		GameManager.Instance.ShowObjective(ObjectiveDataVO.Create("OBJECTIVES/NEW_OBJECTIVE_HEADER", "OBJECTIVES/CH3_OBJECTIVE_09", string.Empty, 4f, false, 0f));
		GameManager.Instance.GameData.CurrentSaveFile.CH3Data.DarkHallwayObjective.IsComplete = true;
		GameManager.Instance.GameDataManager.Save(false, true);
		base.SendOnComplete();
	}

	// Token: 0x060006DF RID: 1759 RVA: 0x00007FC7 File Offset: 0x000061C7
	private void HandleHallwayOnEnter(object sender, EventArgs e)
	{
		DOTween.Kill(1f, false);
		DOTweenUtil.DOAmbientLightColor(0f, 1f, null);
		GameManager.Instance.Player.SetSlowed(true);
	}

	// Token: 0x060006E0 RID: 1760 RVA: 0x00007FFB File Offset: 0x000061FB
	private void HandleHallwayOnExit(object sender, EventArgs e)
	{
		DOTween.Kill(0f, false);
		DOTweenUtil.DOAmbientLightColor(1f, 1f, null);
		GameManager.Instance.Player.SetSlowed(false);
	}

	// Token: 0x060006E1 RID: 1761 RVA: 0x0003F280 File Offset: 0x0003D480
	private void ForceComplete()
	{
		S13AudioManager.Instance.InvokeEvent("evt_CH3_save_point_02", 0f);
		GameManager.Instance.UpdateObjective(ObjectiveDataVO.Create("OBJECTIVES/NEW_OBJECTIVE_HEADER", "OBJECTIVES/CH3_OBJECTIVE_09", string.Empty, 4f, false, 0f));
		this.m_HallwayDoor.ForceClose();
		this.m_OpenedDoor.ForceClose();
		this.m_ClosedDoor.ForceOpen();
		this.m_Boris.StopWaypointPathing();
		this.m_Boris.UpdateWaypointList(new List<WaypointNode>(), false);
		this.m_Boris.transform.position = this.m_BorisWarpPosition.position;
		Vector3 eulerAngles = this.m_BorisWarpPosition.eulerAngles;
		eulerAngles.x = 0f;
		eulerAngles.z = 0f;
		this.m_Boris.transform.eulerAngles = eulerAngles;
		base.SendOnComplete();
	}

	// Token: 0x060006E2 RID: 1762 RVA: 0x0003F360 File Offset: 0x0003D560
	protected override void OnDisposed()
	{
		this.m_HallwayTrigger.OnEnter -= this.HandleHallwayOnEnter;
		this.m_HallwayTrigger.OnExit -= this.HandleHallwayOnExit;
		this.m_OpenedDoor.OnClose -= this.HandleOpenedDoorOnClosed;
		this.m_DuctCrawlingClip = null;
		this.m_HenryDontBeScaredDialogueClip = null;
		this.m_HenryDarkDialogueClip = null;
		this.m_FlashlightClip = null;
		this.m_VentCoverClip = null;
		this.m_BorisEnterVentClip = null;
		this.m_HenryDidYouHearThatClip = null;
		this.m_HenryDeadEndClip = null;
		base.OnDisposed();
	}

	// Token: 0x0400056B RID: 1387
	[Header("<Controllers>")]
	[SerializeField]
	private BorisAi m_Boris;

	// Token: 0x0400056C RID: 1388
	[Header("Triggers")]
	[SerializeField]
	private EventTrigger m_HallwayTrigger;

	// Token: 0x0400056D RID: 1389
	[SerializeField]
	private EventTrigger m_DuctCrawlingTrigger;

	// Token: 0x0400056E RID: 1390
	[Header("Boris Stuff")]
	[SerializeField]
	private WaypointList m_BorisInitialPath;

	// Token: 0x0400056F RID: 1391
	[Header("Objective: Get The Flashlight!")]
	[SerializeField]
	private GameObject m_DarknessEntranceBlocker;

	// Token: 0x04000570 RID: 1392
	[SerializeField]
	private EventTrigger m_HandCrowbarDialogue;

	// Token: 0x04000571 RID: 1393
	[SerializeField]
	private CH3Flashlight m_Flashlight;

	// Token: 0x04000572 RID: 1394
	[SerializeField]
	private EventTrigger m_DarkHallwayEnterLockedIn;

	// Token: 0x04000573 RID: 1395
	[SerializeField]
	private EventTrigger m_DarkHallwayExitLockedIn;

	// Token: 0x04000574 RID: 1396
	[SerializeField]
	private GenericDoorController m_HallwayDoor;

	// Token: 0x04000575 RID: 1397
	[SerializeField]
	private Collider m_DarkenerCollider;

	// Token: 0x04000576 RID: 1398
	[SerializeField]
	private WaypointList m_BorisDarknessPath;

	// Token: 0x04000577 RID: 1399
	[SerializeField]
	private WaypointList m_BorisDarknessHallwayPath;

	// Token: 0x04000578 RID: 1400
	[Header("Objective: Open The Door!")]
	[SerializeField]
	private Transform m_Vent;

	// Token: 0x04000579 RID: 1401
	[SerializeField]
	private GenericDoorController m_ClosedDoor;

	// Token: 0x0400057A RID: 1402
	[SerializeField]
	private GenericDoorController m_OpenedDoor;

	// Token: 0x0400057B RID: 1403
	[SerializeField]
	private Transform m_BorisHandParent;

	// Token: 0x0400057C RID: 1404
	[SerializeField]
	private GameObject m_BlockerCollider;

	// Token: 0x0400057D RID: 1405
	[SerializeField]
	private EventTrigger m_DoorCloseTrigger;

	// Token: 0x0400057E RID: 1406
	[SerializeField]
	private EventTrigger m_BorisTrigger;

	// Token: 0x0400057F RID: 1407
	[SerializeField]
	private WaypointList m_BorisFinalPath;

	// Token: 0x04000580 RID: 1408
	[SerializeField]
	private Transform m_BorisWarpPosition;

	// Token: 0x04000581 RID: 1409
	[Header("<DEV CHEAT POSITIONS>")]
	[SerializeField]
	private Transform m_CheatPoint;

	// Token: 0x04000582 RID: 1410
	private AudioClip m_DuctCrawlingClip;

	// Token: 0x04000583 RID: 1411
	private AudioClip m_HenryDontBeScaredDialogueClip;

	// Token: 0x04000584 RID: 1412
	private AudioClip m_HenryDarkDialogueClip;

	// Token: 0x04000585 RID: 1413
	private AudioClip m_FlashlightClip;

	// Token: 0x04000586 RID: 1414
	private AudioClip m_VentCoverClip;

	// Token: 0x04000587 RID: 1415
	private AudioClip m_BorisEnterVentClip;

	// Token: 0x04000588 RID: 1416
	private AudioClip[] m_HenryDidYouHearThatClip;

	// Token: 0x04000589 RID: 1417
	private AudioClip[] m_HenryDeadEndClip;

	// Token: 0x0400058A RID: 1418
	private bool m_IsBorisInDarkness;

	// Token: 0x0400058B RID: 1419
	private bool m_IsPlayerInDarkness;

	// Token: 0x0400058C RID: 1420
	private GameObject m_FlashlightToDestroy;

	// Token: 0x0400058D RID: 1421
	private Vector3 borisVentPosition;

	// Token: 0x0400058E RID: 1422
	private Vector3 borisVentEuler;
}
