using System;
using System.Diagnostics;
using TMG.Core;

// Token: 0x020001C8 RID: 456
public abstract class BaseController : TMGMonoBehaviour
{
	// Token: 0x14000079 RID: 121
	// (add) Token: 0x06001373 RID: 4979 RVA: 0x0007728C File Offset: 0x0007548C
	// (remove) Token: 0x06001374 RID: 4980 RVA: 0x000772C4 File Offset: 0x000754C4
	[field: DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public event EventHandler OnComplete;

	// Token: 0x17000115 RID: 277
	// (get) Token: 0x06001375 RID: 4981 RVA: 0x00010037 File Offset: 0x0000E237
	// (set) Token: 0x06001376 RID: 4982 RVA: 0x0001003F File Offset: 0x0000E23F
	public bool IsComplete { get; private set; }

	// Token: 0x06001377 RID: 4983 RVA: 0x00002482 File Offset: 0x00000682
	public virtual void Activate()
	{
	}

	// Token: 0x06001378 RID: 4984 RVA: 0x00010048 File Offset: 0x0000E248
	public override void Init()
	{
		base.Init();
		this.m_IsComponent = true;
	}

	// Token: 0x06001379 RID: 4985 RVA: 0x00010057 File Offset: 0x0000E257
	protected void SendOnComplete()
	{
		this.IsComplete = true;
		this.OnComplete.Send(this);
	}

	// Token: 0x0600137A RID: 4986 RVA: 0x0001006C File Offset: 0x0000E26C
	protected override void OnDisposed()
	{
		this.OnComplete = null;
		base.OnDisposed();
	}

	// Token: 0x04000F80 RID: 3968
	protected bool m_IsActive;
}
