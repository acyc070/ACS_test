using System;
using UnityEngine;

namespace Ai
{
	// Token: 0x020001A8 RID: 424
	public class FisherAi : ButcherGangAi
	{
		// Token: 0x060011FE RID: 4606 RVA: 0x0000F21B File Offset: 0x0000D41B
		public void ThickInkSetActive(bool active)
		{
			this.m_ThickInk.SetActive(active);
		}

		// Token: 0x060011FF RID: 4607 RVA: 0x0000F229 File Offset: 0x0000D429
		public override void Activate()
		{
			base.Activate();
		}

		// Token: 0x06001200 RID: 4608 RVA: 0x0000F231 File Offset: 0x0000D431
		protected override void T_Inactive()
		{
			base.T_Inactive();
		}

		// Token: 0x06001201 RID: 4609 RVA: 0x0000F239 File Offset: 0x0000D439
		protected override void T_DistanceActivation()
		{
			base.T_DistanceActivation();
		}

		// Token: 0x06001202 RID: 4610 RVA: 0x0000F241 File Offset: 0x0000D441
		protected override void T_EnterActivate()
		{
			base.T_EnterActivate();
		}

		// Token: 0x06001203 RID: 4611 RVA: 0x0000F249 File Offset: 0x0000D449
		protected override void T_Activate()
		{
			base.T_Activate();
		}

		// Token: 0x06001204 RID: 4612 RVA: 0x0000F251 File Offset: 0x0000D451
		protected override void T_Idle()
		{
			base.T_Idle();
		}

		// Token: 0x06001205 RID: 4613 RVA: 0x0000F259 File Offset: 0x0000D459
		protected override void T_UseWaypoints()
		{
			base.T_UseWaypoints();
		}

		// Token: 0x06001206 RID: 4614 RVA: 0x0000F261 File Offset: 0x0000D461
		protected override void T_MoveToPoint()
		{
			base.T_MoveToPoint();
		}

		// Token: 0x06001207 RID: 4615 RVA: 0x0000F269 File Offset: 0x0000D469
		protected override void T_Hit()
		{
			base.T_Hit();
		}

		// Token: 0x06001208 RID: 4616 RVA: 0x0000F271 File Offset: 0x0000D471
		protected override void T_Retreat()
		{
			base.T_Retreat();
		}

		// Token: 0x06001209 RID: 4617 RVA: 0x0000F279 File Offset: 0x0000D479
		protected override void T_EnterDie()
		{
			base.T_EnterDie();
		}

		// Token: 0x0600120A RID: 4618 RVA: 0x0000F281 File Offset: 0x0000D481
		protected override void T_Die()
		{
			base.T_Die();
		}

		// Token: 0x0600120B RID: 4619 RVA: 0x0000F289 File Offset: 0x0000D489
		protected override void T_PlaySingleAnimation()
		{
			base.T_PlaySingleAnimation();
		}

		// Token: 0x0600120C RID: 4620 RVA: 0x0000F291 File Offset: 0x0000D491
		protected override void T_EnterAttack()
		{
			base.T_EnterAttack();
		}

		// Token: 0x0600120D RID: 4621 RVA: 0x0000F299 File Offset: 0x0000D499
		public override void AttackTarget()
		{
			base.AttackTarget();
		}

		// Token: 0x0600120E RID: 4622 RVA: 0x0000F2A1 File Offset: 0x0000D4A1
		protected override void T_Attack()
		{
			base.T_Attack();
		}

		// Token: 0x0600120F RID: 4623 RVA: 0x0000F2A9 File Offset: 0x0000D4A9
		protected override void T_Wait()
		{
			base.T_Wait();
		}

		// Token: 0x06001210 RID: 4624 RVA: 0x0000F2B1 File Offset: 0x0000D4B1
		protected override void T_Follow()
		{
			base.T_Follow();
		}

		// Token: 0x04000EA6 RID: 3750
		[Header("<== PIPER OPTIONS ==>")]
		[SerializeField]
		private GameObject m_ThickInk;
	}
}
