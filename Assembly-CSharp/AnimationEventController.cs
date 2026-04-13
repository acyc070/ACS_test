using System;
using Ai;
using TMG.Core;

// Token: 0x020001BB RID: 443
public class AnimationEventController : TMGMonoBehaviour
{
	// Token: 0x170000FB RID: 251
	// (get) Token: 0x060012CD RID: 4813 RVA: 0x0000F902 File Offset: 0x0000DB02
	// (set) Token: 0x060012CE RID: 4814 RVA: 0x0000F90A File Offset: 0x0000DB0A
	public BaseAiController BaseAi { get; private set; }

	// Token: 0x170000FC RID: 252
	// (get) Token: 0x060012CF RID: 4815 RVA: 0x0000F913 File Offset: 0x0000DB13
	// (set) Token: 0x060012D0 RID: 4816 RVA: 0x0000F91B File Offset: 0x0000DB1B
	public SwollenSearcherAi swollenAI { get; private set; }

	// Token: 0x170000FD RID: 253
	// (get) Token: 0x060012D1 RID: 4817 RVA: 0x0000F924 File Offset: 0x0000DB24
	// (set) Token: 0x060012D2 RID: 4818 RVA: 0x0000F92C File Offset: 0x0000DB2C
	public CH5BendyHandChase BendyHand { get; private set; }

	// Token: 0x060012D3 RID: 4819 RVA: 0x0000F935 File Offset: 0x0000DB35
	public void SetReference(SwollenSearcherAi reference)
	{
		this.swollenAI = reference;
	}

	// Token: 0x060012D4 RID: 4820 RVA: 0x0000F93E File Offset: 0x0000DB3E
	public void SetReference(BaseAiController reference)
	{
		this.BaseAi = reference;
	}

	// Token: 0x060012D5 RID: 4821 RVA: 0x0000F947 File Offset: 0x0000DB47
	public void SetReference(CH5BendyHandChase reference)
	{
		this.BendyHand = reference;
	}

	// Token: 0x060012D6 RID: 4822 RVA: 0x0000F93E File Offset: 0x0000DB3E
	public void Init(BaseAiController baseAi)
	{
		this.BaseAi = baseAi;
	}

	// Token: 0x060012D7 RID: 4823 RVA: 0x0000F950 File Offset: 0x0000DB50
	public void AttackTarget()
	{
		this.BaseAi.AttackTarget();
	}

	// Token: 0x060012D8 RID: 4824 RVA: 0x0000F95D File Offset: 0x0000DB5D
	public void ResetBorisMovement()
	{
		GameManager.Instance.CharacterManager.Boris.ResetMovement();
	}

	// Token: 0x060012D9 RID: 4825 RVA: 0x0000F973 File Offset: 0x0000DB73
	public void SwollenSearcherHide()
	{
		this.swollenAI.HideOnComplete();
	}

	// Token: 0x060012DA RID: 4826 RVA: 0x0000F980 File Offset: 0x0000DB80
	public void BendyHandSlap()
	{
		this.BendyHand.CheckForAndKillPlayer();
	}

	// Token: 0x060012DB RID: 4827 RVA: 0x0000F98D File Offset: 0x0000DB8D
	public void BendyHandSlapOnComplete()
	{
		this.BendyHand.BendyHandSlapOnComplete();
	}
}
