using System;
using UnityEngine;

// Token: 0x0200019B RID: 411
public class BeastBendy_AnimationEvents : MonoBehaviour
{
	// Token: 0x06001103 RID: 4355 RVA: 0x0000E457 File Offset: 0x0000C657
	public void Stomp()
	{
		if (this.BeastBendy)
		{
			this.BeastBendy.ApplyShake(1f);
		}
	}

	// Token: 0x06001104 RID: 4356 RVA: 0x0000E479 File Offset: 0x0000C679
	public void DoAttack()
	{
		if (this.BeastBendy)
		{
			this.BeastBendy.AttackTarget(this.BeastBendy.transform.forward * 5f, 4f, false);
		}
	}

	// Token: 0x06001105 RID: 4357 RVA: 0x0000E4B6 File Offset: 0x0000C6B6
	public void ChargeStomp()
	{
		if (this.ChargeBendy)
		{
			this.ChargeBendy.ApplyShake(1f);
		}
	}

	// Token: 0x04000DE5 RID: 3557
	public BeastBendy_Ai BeastBendy;

	// Token: 0x04000DE6 RID: 3558
	public Ch5BeastBendyChargeController ChargeBendy;
}
