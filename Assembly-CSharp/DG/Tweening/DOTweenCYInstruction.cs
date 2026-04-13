using System;
using UnityEngine;

namespace DG.Tweening
{
	// Token: 0x02000337 RID: 823
	public static class DOTweenCYInstruction
	{
		// Token: 0x02000338 RID: 824
		public class WaitForCompletion : CustomYieldInstruction
		{
			// Token: 0x06001CCB RID: 7371 RVA: 0x00016B5D File Offset: 0x00014D5D
			public WaitForCompletion(Tween tween)
			{
				this.t = tween;
			}

			// Token: 0x170001BC RID: 444
			// (get) Token: 0x06001CCC RID: 7372 RVA: 0x00016B6C File Offset: 0x00014D6C
			public override bool keepWaiting
			{
				get
				{
					return this.t.active && !this.t.IsComplete();
				}
			}

			// Token: 0x04001882 RID: 6274
			private readonly Tween t;
		}

		// Token: 0x02000339 RID: 825
		public class WaitForRewind : CustomYieldInstruction
		{
			// Token: 0x06001CCD RID: 7373 RVA: 0x00016B8F File Offset: 0x00014D8F
			public WaitForRewind(Tween tween)
			{
				this.t = tween;
			}

			// Token: 0x170001BD RID: 445
			// (get) Token: 0x06001CCE RID: 7374 RVA: 0x00095768 File Offset: 0x00093968
			public override bool keepWaiting
			{
				get
				{
					return this.t.active && (!this.t.playedOnce || this.t.position * (float)(this.t.CompletedLoops() + 1) > 0f);
				}
			}

			// Token: 0x04001883 RID: 6275
			private readonly Tween t;
		}

		// Token: 0x0200033A RID: 826
		public class WaitForKill : CustomYieldInstruction
		{
			// Token: 0x06001CCF RID: 7375 RVA: 0x00016B9E File Offset: 0x00014D9E
			public WaitForKill(Tween tween)
			{
				this.t = tween;
			}

			// Token: 0x170001BE RID: 446
			// (get) Token: 0x06001CD0 RID: 7376 RVA: 0x00016BAD File Offset: 0x00014DAD
			public override bool keepWaiting
			{
				get
				{
					return this.t.active;
				}
			}

			// Token: 0x04001884 RID: 6276
			private readonly Tween t;
		}

		// Token: 0x0200033B RID: 827
		public class WaitForElapsedLoops : CustomYieldInstruction
		{
			// Token: 0x06001CD1 RID: 7377 RVA: 0x00016BBA File Offset: 0x00014DBA
			public WaitForElapsedLoops(Tween tween, int elapsedLoops)
			{
				this.t = tween;
				this.elapsedLoops = elapsedLoops;
			}

			// Token: 0x170001BF RID: 447
			// (get) Token: 0x06001CD2 RID: 7378 RVA: 0x00016BD0 File Offset: 0x00014DD0
			public override bool keepWaiting
			{
				get
				{
					return this.t.active && this.t.CompletedLoops() < this.elapsedLoops;
				}
			}

			// Token: 0x04001885 RID: 6277
			private readonly Tween t;

			// Token: 0x04001886 RID: 6278
			private readonly int elapsedLoops;
		}

		// Token: 0x0200033C RID: 828
		public class WaitForPosition : CustomYieldInstruction
		{
			// Token: 0x06001CD3 RID: 7379 RVA: 0x00016BF8 File Offset: 0x00014DF8
			public WaitForPosition(Tween tween, float position)
			{
				this.t = tween;
				this.position = position;
			}

			// Token: 0x170001C0 RID: 448
			// (get) Token: 0x06001CD4 RID: 7380 RVA: 0x00016C0E File Offset: 0x00014E0E
			public override bool keepWaiting
			{
				get
				{
					return this.t.active && this.t.position * (float)(this.t.CompletedLoops() + 1) < this.position;
				}
			}

			// Token: 0x04001887 RID: 6279
			private readonly Tween t;

			// Token: 0x04001888 RID: 6280
			private readonly float position;
		}

		// Token: 0x0200033D RID: 829
		public class WaitForStart : CustomYieldInstruction
		{
			// Token: 0x06001CD5 RID: 7381 RVA: 0x00016C45 File Offset: 0x00014E45
			public WaitForStart(Tween tween)
			{
				this.t = tween;
			}

			// Token: 0x170001C1 RID: 449
			// (get) Token: 0x06001CD6 RID: 7382 RVA: 0x00016C54 File Offset: 0x00014E54
			public override bool keepWaiting
			{
				get
				{
					return this.t.active && !this.t.playedOnce;
				}
			}

			// Token: 0x04001889 RID: 6281
			private readonly Tween t;
		}
	}
}
