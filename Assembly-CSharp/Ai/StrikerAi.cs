using System;
using UnityEngine;

namespace Ai
{
	// Token: 0x020001B6 RID: 438
	public class StrikerAi : ButcherGangAi
	{
		// Token: 0x0600129A RID: 4762 RVA: 0x0000F7CE File Offset: 0x0000D9CE
		public void PowerCoreSetActive(bool active)
		{
			this.m_PowerCore.SetActive(active);
		}

		// Token: 0x0600129B RID: 4763 RVA: 0x0000F229 File Offset: 0x0000D429
		public override void Activate()
		{
			base.Activate();
		}

		// Token: 0x0600129C RID: 4764 RVA: 0x0000F231 File Offset: 0x0000D431
		protected override void T_Inactive()
		{
			base.T_Inactive();
		}

		// Token: 0x0600129D RID: 4765 RVA: 0x0000F239 File Offset: 0x0000D439
		protected override void T_DistanceActivation()
		{
			base.T_DistanceActivation();
		}

		// Token: 0x0600129E RID: 4766 RVA: 0x0000F241 File Offset: 0x0000D441
		protected override void T_EnterActivate()
		{
			base.T_EnterActivate();
		}

		// Token: 0x0600129F RID: 4767 RVA: 0x0000F249 File Offset: 0x0000D449
		protected override void T_Activate()
		{
			base.T_Activate();
		}

		// Token: 0x060012A0 RID: 4768 RVA: 0x0000F251 File Offset: 0x0000D451
		protected override void T_Idle()
		{
			base.T_Idle();
		}

		// Token: 0x060012A1 RID: 4769 RVA: 0x0000F259 File Offset: 0x0000D459
		protected override void T_UseWaypoints()
		{
			base.T_UseWaypoints();
		}

		// Token: 0x060012A2 RID: 4770 RVA: 0x0000F261 File Offset: 0x0000D461
		protected override void T_MoveToPoint()
		{
			base.T_MoveToPoint();
		}

		// Token: 0x060012A3 RID: 4771 RVA: 0x0000F269 File Offset: 0x0000D469
		protected override void T_Hit()
		{
			base.T_Hit();
		}

		// Token: 0x060012A4 RID: 4772 RVA: 0x0000F271 File Offset: 0x0000D471
		protected override void T_Retreat()
		{
			base.T_Retreat();
		}

		// Token: 0x060012A5 RID: 4773 RVA: 0x0000F279 File Offset: 0x0000D479
		protected override void T_EnterDie()
		{
			base.T_EnterDie();
		}

		// Token: 0x060012A6 RID: 4774 RVA: 0x0000F281 File Offset: 0x0000D481
		protected override void T_Die()
		{
			base.T_Die();
		}

		// Token: 0x060012A7 RID: 4775 RVA: 0x0000F289 File Offset: 0x0000D489
		protected override void T_PlaySingleAnimation()
		{
			base.T_PlaySingleAnimation();
		}

		// Token: 0x060012A8 RID: 4776 RVA: 0x0000F291 File Offset: 0x0000D491
		protected override void T_EnterAttack()
		{
			base.T_EnterAttack();
		}

		// Token: 0x060012A9 RID: 4777 RVA: 0x0000F299 File Offset: 0x0000D499
		public override void AttackTarget()
		{
			base.AttackTarget();
		}

		// Token: 0x060012AA RID: 4778 RVA: 0x0000F2A1 File Offset: 0x0000D4A1
		protected override void T_Attack()
		{
			base.T_Attack();
		}

		// Token: 0x060012AB RID: 4779 RVA: 0x0000F2A9 File Offset: 0x0000D4A9
		protected override void T_Wait()
		{
			base.T_Wait();
		}

		// Token: 0x060012AC RID: 4780 RVA: 0x0000F2B1 File Offset: 0x0000D4B1
		protected override void T_Follow()
		{
			base.T_Follow();
		}

		// Token: 0x04000EF4 RID: 3828
		[Header("<== STRIKER OPTIONS ==>")]
		[SerializeField]
		private GameObject m_PowerCore;
	}
}
