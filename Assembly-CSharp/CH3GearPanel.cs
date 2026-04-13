using System;
using System.Collections.Generic;
using System.Diagnostics;
using DG.Tweening;
using TMG.Core;
using UnityEngine;

// Token: 0x020000E5 RID: 229
public class CH3GearPanel : TMGMonoBehaviour
{
	// Token: 0x14000012 RID: 18
	// (add) Token: 0x06000903 RID: 2307 RVA: 0x0004B4A8 File Offset: 0x000496A8
	// (remove) Token: 0x06000904 RID: 2308 RVA: 0x0004B4E0 File Offset: 0x000496E0
	[field: DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public event EventHandler OnComplete;

	// Token: 0x17000075 RID: 117
	// (get) Token: 0x06000905 RID: 2309 RVA: 0x00009354 File Offset: 0x00007554
	public List<Transform> Bolts
	{
		get
		{
			return this.m_Bolts;
		}
	}

	// Token: 0x06000906 RID: 2310 RVA: 0x0000935C File Offset: 0x0000755C
	public override void Init()
	{
		base.Init();
		this.m_Interactable = base.gameObject.GetComponent<Interactable>();
	}

	// Token: 0x06000907 RID: 2311 RVA: 0x00009375 File Offset: 0x00007575
	public override void InitOnComplete()
	{
		base.InitOnComplete();
		this.m_OpenClip = GameManager.Instance.GetAudioClip("Audio/SFX/CH3/SFX_CH3_gearmission_gearboxcoveropen");
		this.m_TakeGearClip = GameManager.Instance.GetAudioClip("Audio/SFX/CH3/SFX_CH3_gearmission_takegear");
	}

	// Token: 0x06000908 RID: 2312 RVA: 0x000093A7 File Offset: 0x000075A7
	public void Activate()
	{
		this.m_Light.TurnOff();
		this.m_Gear.gameObject.SetActive(!this.m_IsEmpty);
		if (this.m_IsEmpty)
		{
			this.m_Light.TurnOn();
		}
	}

	// Token: 0x06000909 RID: 2313 RVA: 0x000093E3 File Offset: 0x000075E3
	public void ActivateInteraction()
	{
		this.m_Interactable.OnInteracted += this.HandleOnInteracted;
		this.m_Interactable.SetActive(true);
	}

	// Token: 0x0600090A RID: 2314 RVA: 0x0004B518 File Offset: 0x00049718
	public void RotateGears()
	{
		if (this.isComplete || this.m_IsEmpty)
		{
			return;
		}
		Sequence sequence = DOTween.Sequence();
		for (int i = 0; i < this.m_Gears.Count; i++)
		{
			Transform transform = this.m_Gears[i];
			sequence.Insert(0.25f, transform.DOLocalRotate(new Vector3(0f, 51f, 0f), 0.5f, RotateMode.LocalAxisAdd).SetEase(Ease.OutBack));
		}
		if (this.m_Gear != null)
		{
			sequence.Insert(0.25f, this.m_Gear.transform.DOLocalRotate(new Vector3(0f, -51f, 0f), 0.5f, RotateMode.LocalAxisAdd).SetEase(Ease.OutBack));
		}
		sequence.OnComplete(new TweenCallback(this.RotateGears));
	}

	// Token: 0x0600090B RID: 2315 RVA: 0x0004B600 File Offset: 0x00049800
	private void HandleOnInteracted(object sender, EventArgs e)
	{
		this.m_Interactable.OnInteracted -= this.HandleOnInteracted;
		for (int i = 0; i < this.m_Bolts.Count; i++)
		{
			this.m_Bolts[i].gameObject.SetActive(false);
		}
		GameManager.Instance.AudioManager.Play(this.m_OpenClip, AudioObjectType.SOUND_EFFECT, 0, false);
		this.m_Panel.DOLocalRotate(new Vector3(135f, 0f, 0f), 0.65f, RotateMode.LocalAxisAdd).SetEase(Ease.Linear).OnComplete(delegate
		{
			base.GetComponent<BoxCollider>().enabled = false;
			if (this.m_IsEmpty)
			{
				this.OnComplete.Send(this);
			}
			else
			{
				this.m_Gear.SetActive(true);
				this.m_Gear.OnInteracted += this.HandleGearOnInteracted;
			}
			this.m_Panel.DOLocalRotate(new Vector3(-10f, 0f, 0f), 2f, RotateMode.LocalAxisAdd).SetLoops(10, LoopType.Yoyo).SetEase(Ease.InOutQuad);
		});
	}

	// Token: 0x0600090C RID: 2316 RVA: 0x0004B6B0 File Offset: 0x000498B0
	private void HandleGearOnInteracted(object sender, EventArgs e)
	{
		this.m_Gear.OnInteracted -= this.HandleGearOnInteracted;
		this.m_Gear.Dispose();
		GameManager.Instance.AudioManager.Play(this.m_TakeGearClip, AudioObjectType.SOUND_EFFECT, 0, false);
		this.m_Light.TurnOn();
		this.isComplete = true;
		this.OnComplete.Send(this);
	}

	// Token: 0x0600090D RID: 2317 RVA: 0x00009408 File Offset: 0x00007608
	public void DisableInteraction()
	{
		if (this.m_Interactable)
		{
			this.m_Interactable.SetActive(false);
			this.m_Interactable.OnInteracted -= this.HandleOnInteracted;
		}
	}

	// Token: 0x0600090E RID: 2318 RVA: 0x0004B718 File Offset: 0x00049918
	public void ForceComplete()
	{
		this.m_Panel.localEulerAngles = new Vector3(135f, 0f, 0f);
		base.GetComponent<BoxCollider>().enabled = false;
		if (this.m_Gear)
		{
			this.m_Gear.gameObject.SetActive(false);
		}
		for (int i = 0; i < this.m_Gears.Count; i++)
		{
			Transform transform = this.m_Gears[i];
			if (transform)
			{
				transform.DOKill(false);
			}
		}
		for (int j = 0; j < this.m_Bolts.Count; j++)
		{
			this.m_Bolts[j].gameObject.SetActive(false);
		}
		this.isComplete = true;
		this.m_Light.TurnOn();
	}

	// Token: 0x0600090F RID: 2319 RVA: 0x0004B7F4 File Offset: 0x000499F4
	protected override void OnDisposed()
	{
		if (this.m_Gear)
		{
			this.m_Gear.OnInteracted -= this.HandleGearOnInteracted;
		}
		if (this.m_Interactable)
		{
			this.m_Interactable.OnInteracted -= this.HandleOnInteracted;
		}
		base.OnDisposed();
	}

	// Token: 0x04000756 RID: 1878
	[HideInInspector]
	public int ID;

	// Token: 0x04000757 RID: 1879
	[HideInInspector]
	public bool isComplete;

	// Token: 0x04000758 RID: 1880
	[Header("Transforms")]
	[SerializeField]
	private Transform m_Panel;

	// Token: 0x04000759 RID: 1881
	[SerializeField]
	private List<Transform> m_Bolts;

	// Token: 0x0400075A RID: 1882
	[Header("Gears")]
	[SerializeField]
	private Interactable m_Gear;

	// Token: 0x0400075B RID: 1883
	[SerializeField]
	private List<Transform> m_Gears;

	// Token: 0x0400075C RID: 1884
	[Header("Lights")]
	[SerializeField]
	private LightFlicker m_Light;

	// Token: 0x0400075D RID: 1885
	[Header("Options")]
	[SerializeField]
	private bool m_IsEmpty;

	// Token: 0x0400075E RID: 1886
	private AudioClip m_OpenClip;

	// Token: 0x0400075F RID: 1887
	private AudioClip m_TakeGearClip;

	// Token: 0x04000760 RID: 1888
	private Interactable m_Interactable;
}
