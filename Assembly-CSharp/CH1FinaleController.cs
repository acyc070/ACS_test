using System;
using System.Collections.Generic;
using S13Audio;
using TMG.Controls;
using UnityEngine;

// Token: 0x0200006D RID: 109
public class CH1FinaleController : BaseController
{
	// Token: 0x060003DF RID: 991 RVA: 0x0002D5B0 File Offset: 0x0002B7B0
	public override void InitOnComplete()
	{
		base.InitOnComplete();
		this.m_HenryClip07 = GameManager.Instance.GetAudioClip("Audio/DIA/CH1/Henry/DIA_CH1_HENRY_07");
		this.m_BoardsBreakClip = GameManager.Instance.GetAudioClip("Audio/SFX/SFX_Floor_Boards_Break_01.L");
		this.m_CollapsedVisuals.SetActive(false);
		this.m_Door.Lock();
		this.m_CeilingSpill.SetActive(false);
		this.m_AxeWeapon.Interaction.SetActive(false);
	}

	// Token: 0x060003E0 RID: 992 RVA: 0x0002D624 File Offset: 0x0002B824
	public override void Activate()
	{
		this.m_AxeWeapon.OnEquipped += this.HandleAxeOnEquipped;
		this.m_AxeWeapon.Interaction.SetActive(true);
		this.m_CeilingPlank.OnBroken += this.HandleCeilingPlankOnBroken;
	}

	// Token: 0x060003E1 RID: 993 RVA: 0x000059FE File Offset: 0x00003BFE
	private void HandleCeilingPlankOnBroken(object sender, EventArgs e)
	{
		this.m_CeilingPlank.OnBroken -= this.HandleCeilingPlankOnBroken;
		this.m_CeilingSpill.SetActive(true);
	}

	// Token: 0x060003E2 RID: 994 RVA: 0x0002D670 File Offset: 0x0002B870
	private void HandleAxeOnEquipped(object sender, EventArgs e)
	{
		GameManager.Instance.ShowTutorial(new TutorialDataVO("Tutorial/TUTORIAL_ATTACK"));
		this.m_ShowAttackTutorial = true;
		GameManager.Instance.ShowDialogue(DialogueDataVO.Create(this.m_HenryClip07, "DIACH1/DIA_CH1_HENRY_07", false));
		for (int i = 0; i < this.m_Breakables.Count; i++)
		{
			this.m_Breakables[i].OnBroken += this.HandleOnBroken;
		}
	}

	// Token: 0x060003E3 RID: 995 RVA: 0x00005A23 File Offset: 0x00003C23
	private void Update()
	{
		if (this.m_ShowAttackTutorial && PlayerInput.Attack())
		{
			GameManager.Instance.HideTutorial();
			this.m_ShowAttackTutorial = false;
		}
	}

	// Token: 0x060003E4 RID: 996 RVA: 0x0002D6F0 File Offset: 0x0002B8F0
	private void HandleOnBroken(object sender, EventArgs e)
	{
		for (int i = 0; i < this.m_Breakables.Count; i++)
		{
			this.m_Breakables[i].OnBroken -= this.HandleOnBroken;
		}
		this.m_Door.Unlock();
		this.m_Door.OnInteracted += this.HandleDoorOnOpened;
	}

	// Token: 0x060003E5 RID: 997 RVA: 0x0002D758 File Offset: 0x0002B958
	private void HandleDoorOnOpened(object sender, EventArgs e)
	{
		this.m_Door.OnInteracted -= this.HandleDoorOnOpened;
		this.m_CollapsedVisuals.SetActive(true);
		GameManager.Instance.AudioManager.Play(this.m_BoardsBreakClip, AudioObjectType.SOUND_EFFECT, 0, false);
		S13AudioManager.Instance.PlayAudioDelayed("sfx_collapse_ink", 1f);
		base.SendOnComplete();
	}

	// Token: 0x060003E6 RID: 998 RVA: 0x00005A4B File Offset: 0x00003C4B
	protected override void OnDisposed()
	{
		this.m_HenryClip07 = null;
		this.m_BoardsBreakClip = null;
		base.OnDisposed();
	}

	// Token: 0x0400025A RID: 602
	[Header("Axe")]
	[SerializeField]
	private MeleeWeapon m_AxeWeapon;

	// Token: 0x0400025B RID: 603
	[Header("Objective: Enter The Ritual Room")]
	[SerializeField]
	private GameObject m_CollapsedVisuals;

	// Token: 0x0400025C RID: 604
	[SerializeField]
	private BaseDoorController m_Door;

	// Token: 0x0400025D RID: 605
	[SerializeField]
	private List<Breakable> m_Breakables;

	// Token: 0x0400025E RID: 606
	[Header("Ceiling Plank")]
	[SerializeField]
	private Breakable m_CeilingPlank;

	// Token: 0x0400025F RID: 607
	[SerializeField]
	private GameObject m_CeilingSpill;

	// Token: 0x04000260 RID: 608
	private AudioClip m_HenryClip07;

	// Token: 0x04000261 RID: 609
	private AudioClip m_BoardsBreakClip;

	// Token: 0x04000262 RID: 610
	private bool m_ShowAttackTutorial;
}
