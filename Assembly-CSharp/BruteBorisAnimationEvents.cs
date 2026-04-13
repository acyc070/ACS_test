using System;
using TMG.Core;
using UnityEngine;

// Token: 0x020001A4 RID: 420
public class BruteBorisAnimationEvents : TMGMonoBehaviour
{
	// Token: 0x060011D6 RID: 4566 RVA: 0x0000EFC1 File Offset: 0x0000D1C1
	public override void InitOnComplete()
	{
		base.InitOnComplete();
		this.m_MusicBadDog = GameManager.Instance.GetAudioClip("Audio/MUS/CH4/MUS_BadDog");
		this.m_HenryDialogue = GameManager.Instance.GetAudioClip("Audio/DIA/CH4/Henry/DIA_CH4_HENRY_08");
	}

	// Token: 0x060011D7 RID: 4567 RVA: 0x0000EFF3 File Offset: 0x0000D1F3
	public void Attack1()
	{
		this.m_Controller.ApplyAttack(0);
	}

	// Token: 0x060011D8 RID: 4568 RVA: 0x0000F001 File Offset: 0x0000D201
	public void Attack2()
	{
		this.m_Controller.ApplyAttack(1);
	}

	// Token: 0x060011D9 RID: 4569 RVA: 0x0000F00F File Offset: 0x0000D20F
	public void DoAttack()
	{
		this.m_Controller.AttackTarget(Vector3.zero, 4f, false);
	}

	// Token: 0x060011DA RID: 4570 RVA: 0x0000F027 File Offset: 0x0000D227
	public void DoJump()
	{
		this.m_Controller.DoJump();
	}

	// Token: 0x060011DB RID: 4571 RVA: 0x0000F034 File Offset: 0x0000D234
	public void Stomp()
	{
		this.m_Controller.ApplyStomp();
	}

	// Token: 0x060011DC RID: 4572 RVA: 0x0000F041 File Offset: 0x0000D241
	public void DoSmash()
	{
		this.m_Controller.DoSmash();
	}

	// Token: 0x060011DD RID: 4573 RVA: 0x0000F04E File Offset: 0x0000D24E
	public void ShakeCamera()
	{
		this.m_Controller.ApplyShake(0.5f);
	}

	// Token: 0x060011DE RID: 4574 RVA: 0x0000F060 File Offset: 0x0000D260
	public void RevealGrabCart()
	{
		GameManager.Instance.AudioManager.Play(this.m_MusicBadDog, AudioObjectType.MUSIC, 0, false);
		this.m_Controller.ApplyShake(1.5f);
	}

	// Token: 0x060011DF RID: 4575 RVA: 0x0000F08B File Offset: 0x0000D28B
	public void PickupCart()
	{
		this.m_Controller.PickupCart();
	}

	// Token: 0x060011E0 RID: 4576 RVA: 0x0000F098 File Offset: 0x0000D298
	public void ThrowCart()
	{
		this.m_Controller.ThrowCart();
	}

	// Token: 0x060011E1 RID: 4577 RVA: 0x0000F0A5 File Offset: 0x0000D2A5
	public void PlaySmashAudio()
	{
		this.m_Controller.PlaySmashAudio();
	}

	// Token: 0x060011E2 RID: 4578 RVA: 0x0000F0B2 File Offset: 0x0000D2B2
	public void Reveal()
	{
		this.m_Controller.Reveal();
	}

	// Token: 0x060011E3 RID: 4579 RVA: 0x0000F0BF File Offset: 0x0000D2BF
	public void HenryDialogue()
	{
		GameManager.Instance.ShowDialogue(DialogueDataVO.Create(this.m_HenryDialogue, SubtitleConstants.DIA_CH4_HENRY_08, false));
	}

	// Token: 0x060011E4 RID: 4580 RVA: 0x0000F0DD File Offset: 0x0000D2DD
	public void ParentCart()
	{
		this.m_Controller.SetCartParent(false);
	}

	// Token: 0x060011E5 RID: 4581 RVA: 0x0000F0EB File Offset: 0x0000D2EB
	public void UnlockPlayer()
	{
		this.m_Controller.UnlockPlayer();
	}

	// Token: 0x060011E6 RID: 4582 RVA: 0x000061D6 File Offset: 0x000043D6
	protected override void OnDisposed()
	{
		base.OnDisposed();
	}

	// Token: 0x04000E90 RID: 3728
	[SerializeField]
	private BruteBorisAi m_Controller;

	// Token: 0x04000E91 RID: 3729
	private AudioClip m_MusicBadDog;

	// Token: 0x04000E92 RID: 3730
	private AudioClip m_HenryDialogue;
}
