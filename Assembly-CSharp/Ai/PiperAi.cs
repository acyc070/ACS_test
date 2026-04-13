using System;
using UnityEngine;

namespace Ai
{
	// Token: 0x020001AC RID: 428
	public class PiperAi : ButcherGangAi
	{
		// Token: 0x0600122F RID: 4655 RVA: 0x0000F447 File Offset: 0x0000D647
		public void GearSetActive(bool active)
		{
			this.m_Gear.SetActive(active);
		}

		// Token: 0x06001230 RID: 4656 RVA: 0x0000F229 File Offset: 0x0000D429
		public override void Activate()
		{
			base.Activate();
		}

		// Token: 0x06001231 RID: 4657 RVA: 0x0000F231 File Offset: 0x0000D431
		protected override void T_Inactive()
		{
			base.T_Inactive();
		}

		// Token: 0x06001232 RID: 4658 RVA: 0x0000F239 File Offset: 0x0000D439
		protected override void T_DistanceActivation()
		{
			base.T_DistanceActivation();
		}

		// Token: 0x06001233 RID: 4659 RVA: 0x0000F241 File Offset: 0x0000D441
		protected override void T_EnterActivate()
		{
			base.T_EnterActivate();
		}

		// Token: 0x06001234 RID: 4660 RVA: 0x0000F249 File Offset: 0x0000D449
		protected override void T_Activate()
		{
			base.T_Activate();
		}

		// Token: 0x06001235 RID: 4661 RVA: 0x0000F251 File Offset: 0x0000D451
		protected override void T_Idle()
		{
			base.T_Idle();
		}

		// Token: 0x06001236 RID: 4662 RVA: 0x0000F259 File Offset: 0x0000D459
		protected override void T_UseWaypoints()
		{
			base.T_UseWaypoints();
		}

		// Token: 0x06001237 RID: 4663 RVA: 0x0000F261 File Offset: 0x0000D461
		protected override void T_MoveToPoint()
		{
			base.T_MoveToPoint();
		}

		// Token: 0x06001238 RID: 4664 RVA: 0x0000F269 File Offset: 0x0000D469
		protected override void T_Hit()
		{
			base.T_Hit();
		}

		// Token: 0x06001239 RID: 4665 RVA: 0x0000F271 File Offset: 0x0000D471
		protected override void T_Retreat()
		{
			base.T_Retreat();
		}

		// Token: 0x0600123A RID: 4666 RVA: 0x0000F279 File Offset: 0x0000D479
		protected override void T_EnterDie()
		{
			base.T_EnterDie();
		}

		// Token: 0x0600123B RID: 4667 RVA: 0x0000F281 File Offset: 0x0000D481
		protected override void T_Die()
		{
			base.T_Die();
		}

		// Token: 0x0600123C RID: 4668 RVA: 0x0000F289 File Offset: 0x0000D489
		protected override void T_PlaySingleAnimation()
		{
			base.T_PlaySingleAnimation();
		}

		// Token: 0x0600123D RID: 4669 RVA: 0x0000F291 File Offset: 0x0000D491
		protected override void T_EnterAttack()
		{
			base.T_EnterAttack();
		}

		// Token: 0x0600123E RID: 4670 RVA: 0x0000F299 File Offset: 0x0000D499
		public override void AttackTarget()
		{
			base.AttackTarget();
		}

		// Token: 0x0600123F RID: 4671 RVA: 0x0000F2A1 File Offset: 0x0000D4A1
		protected override void T_Attack()
		{
			base.T_Attack();
		}

		// Token: 0x06001240 RID: 4672 RVA: 0x0000F2A9 File Offset: 0x0000D4A9
		protected override void T_Wait()
		{
			base.T_Wait();
		}

		// Token: 0x06001241 RID: 4673 RVA: 0x0000F2B1 File Offset: 0x0000D4B1
		protected override void T_Follow()
		{
			base.T_Follow();
		}

		// Token: 0x04000EB3 RID: 3763
		[Header("<== PIPER OPTIONS ==>")]
		[SerializeField]
		private GameObject m_Gear;
	}
}
