using System;
using System.Diagnostics;
using DG.Tweening;
using UnityEngine;

// Token: 0x020000E3 RID: 227
public class CH3Dropbox : Interactable
{
	// Token: 0x14000010 RID: 16
	// (add) Token: 0x060008F5 RID: 2293 RVA: 0x0004B238 File Offset: 0x00049438
	// (remove) Token: 0x060008F6 RID: 2294 RVA: 0x0004B270 File Offset: 0x00049470
	[field: DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public event EventHandler OnDopped;

	// Token: 0x060008F7 RID: 2295 RVA: 0x0004B2A8 File Offset: 0x000494A8
	public override void OnInteract()
	{
		this.m_Door.DOKill(false);
		this.m_Door.DOLocalRotate(new Vector3(0f, 0f, 360f), 2f, RotateMode.LocalAxisAdd).SetEase(Ease.OutElastic).OnComplete(new TweenCallback(this.SendOnDropped));
	}

	// Token: 0x060008F8 RID: 2296 RVA: 0x000092DF File Offset: 0x000074DF
	private void SendOnDropped()
	{
		this.OnDopped.Send(this);
	}

	// Token: 0x060008F9 RID: 2297 RVA: 0x000092ED File Offset: 0x000074ED
	protected override void OnDisposed()
	{
		this.OnDopped = null;
		base.OnDisposed();
	}

	// Token: 0x04000751 RID: 1873
	[Header("Dropbox")]
	[SerializeField]
	private Transform m_Door;
}
