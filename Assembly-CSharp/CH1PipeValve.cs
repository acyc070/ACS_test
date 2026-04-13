using System;
using System.Diagnostics;
using DG.Tweening;
using TMG.Core;
using UnityEngine;

// Token: 0x02000082 RID: 130
public class CH1PipeValve : TMGMonoBehaviour
{
	// Token: 0x14000003 RID: 3
	// (add) Token: 0x0600048D RID: 1165 RVA: 0x00031114 File Offset: 0x0002F314
	// (remove) Token: 0x0600048E RID: 1166 RVA: 0x0003114C File Offset: 0x0002F34C
	[field: DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public event EventHandler OnInteracted;

	// Token: 0x0600048F RID: 1167 RVA: 0x0000646C File Offset: 0x0000466C
	public override void InitOnComplete()
	{
		base.InitOnComplete();
		if (this.m_EmptyValve)
		{
			this.m_Valve.gameObject.SetActive(false);
		}
	}

	// Token: 0x06000490 RID: 1168 RVA: 0x00031184 File Offset: 0x0002F384
	public void Activate()
	{
		if (this.m_EmptyValve)
		{
			this.m_EmptyValve.gameObject.SetActive(false);
		}
		this.m_Valve.gameObject.SetActive(true);
		this.m_Valve.SetActive(true);
		this.m_Valve.OnInteracted += this.HandleValveOnInteracted;
	}

	// Token: 0x06000491 RID: 1169 RVA: 0x00006495 File Offset: 0x00004695
	public void ActivateEmpty()
	{
		this.m_Valve.gameObject.SetActive(false);
		this.m_EmptyValve.SetActive(true);
		this.m_EmptyValve.OnInteracted += this.HandleValveEmptyOnInteracted;
	}

	// Token: 0x06000492 RID: 1170 RVA: 0x000064CB File Offset: 0x000046CB
	public void SetEmptyCollision(bool active)
	{
		this.m_EmptyValve.GetComponent<Collider>().enabled = active;
	}

	// Token: 0x06000493 RID: 1171 RVA: 0x000064DE File Offset: 0x000046DE
	public void Disable()
	{
		this.m_Valve.SetActive(false);
	}

	// Token: 0x06000494 RID: 1172 RVA: 0x000064EC File Offset: 0x000046EC
	private void HandleValveOnInteracted(object sender, EventArgs e)
	{
		this.m_Valve.OnInteracted -= this.HandleValveOnInteracted;
		this.m_Valve.SetActive(false);
		this.OnInteracted.Send(this);
	}

	// Token: 0x06000495 RID: 1173 RVA: 0x0000651D File Offset: 0x0000471D
	private void HandleValveEmptyOnInteracted(object sender, EventArgs e)
	{
		this.m_EmptyValve.OnInteracted -= this.HandleValveEmptyOnInteracted;
		this.m_EmptyValve.SetActive(false);
		this.OnInteracted.Send(this);
	}

	// Token: 0x06000496 RID: 1174 RVA: 0x0000654E File Offset: 0x0000474E
	public Tweener DORotate(float duration)
	{
		this.m_Valve.transform.DOKill(false);
		return this.m_Valve.transform.DOLocalRotate(new Vector3(-180f, 0f, 0f), duration, RotateMode.LocalAxisAdd).SetEase(Ease.InOutQuad);
	}

	// Token: 0x06000497 RID: 1175 RVA: 0x0000658E File Offset: 0x0000478E
	public Tweener DORotateReverse(float duration, Ease ease = Ease.InOutQuad)
	{
		this.m_Valve.transform.DOKill(false);
		return this.m_Valve.transform.DOLocalRotate(new Vector3(180f, 0f, 0f), duration, RotateMode.LocalAxisAdd).SetEase(ease);
	}

	// Token: 0x06000498 RID: 1176 RVA: 0x000065CE File Offset: 0x000047CE
	public void ForceComplete()
	{
		this.m_Valve.SetActive(false);
		this.m_Valve.ForceRemoveEffects();
		this.m_Valve.gameObject.SetActive(true);
		this.m_EmptyValve.gameObject.SetActive(false);
	}

	// Token: 0x06000499 RID: 1177 RVA: 0x00006609 File Offset: 0x00004809
	protected override void OnDisposed()
	{
		this.m_Valve.transform.DOKill(false);
		this.m_Valve.OnInteracted -= this.HandleValveOnInteracted;
		this.OnInteracted = null;
		base.OnDisposed();
	}

	// Token: 0x0400030D RID: 781
	[SerializeField]
	private Interactable m_Valve;

	// Token: 0x0400030E RID: 782
	[SerializeField]
	private Interactable m_EmptyValve;
}
