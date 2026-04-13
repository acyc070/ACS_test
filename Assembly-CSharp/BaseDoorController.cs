using System;
using System.Collections.Generic;
using System.Diagnostics;
using DG.Tweening;
using TMG.Core;
using UnityEngine;

// Token: 0x02000229 RID: 553
public class BaseDoorController : TMGMonoBehaviour
{
	// Token: 0x1400008A RID: 138
	// (add) Token: 0x06001589 RID: 5513 RVA: 0x0007DB50 File Offset: 0x0007BD50
	// (remove) Token: 0x0600158A RID: 5514 RVA: 0x0007DB88 File Offset: 0x0007BD88
	[field: DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public event EventHandler OnOpen;

	// Token: 0x1400008B RID: 139
	// (add) Token: 0x0600158B RID: 5515 RVA: 0x0007DBC0 File Offset: 0x0007BDC0
	// (remove) Token: 0x0600158C RID: 5516 RVA: 0x0007DBF8 File Offset: 0x0007BDF8
	[field: DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public event EventHandler OnClose;

	// Token: 0x1400008C RID: 140
	// (add) Token: 0x0600158D RID: 5517 RVA: 0x0007DC30 File Offset: 0x0007BE30
	// (remove) Token: 0x0600158E RID: 5518 RVA: 0x0007DC68 File Offset: 0x0007BE68
	[field: DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public event EventHandler OnInteracted;

	// Token: 0x1700015A RID: 346
	// (get) Token: 0x0600158F RID: 5519 RVA: 0x00011833 File Offset: 0x0000FA33
	// (set) Token: 0x06001590 RID: 5520 RVA: 0x0001183B File Offset: 0x0000FA3B
	public bool IsSilent { get; private set; }

	// Token: 0x1700015B RID: 347
	// (get) Token: 0x06001591 RID: 5521 RVA: 0x00011844 File Offset: 0x0000FA44
	// (set) Token: 0x06001592 RID: 5522 RVA: 0x0001184C File Offset: 0x0000FA4C
	public bool IsLocked { get; private set; }

	// Token: 0x1700015C RID: 348
	// (get) Token: 0x06001593 RID: 5523 RVA: 0x00011855 File Offset: 0x0000FA55
	// (set) Token: 0x06001594 RID: 5524 RVA: 0x0001185D File Offset: 0x0000FA5D
	public bool IsOpen { get; private set; }

	// Token: 0x06001595 RID: 5525 RVA: 0x00011866 File Offset: 0x0000FA66
	public override void Init()
	{
		base.Init();
		this.IsLocked = !this.IsUnlockedAtStart;
		this.m_Portal = base.GetComponent<OcclusionPortal>();
	}

	// Token: 0x06001596 RID: 5526 RVA: 0x00011889 File Offset: 0x0000FA89
	public override void InitOnComplete()
	{
		base.InitOnComplete();
		this.m_DoorOpenClip = GameManager.Instance.GetAudioClip("Audio/SFX/Door/SFX_Door_Generic_Open_01");
		this.m_DoorCloseClip = GameManager.Instance.GetAudioClip("Audio/SFX/Door/SFX_Door_Generic_Close_01");
		this.AddListeners();
	}

	// Token: 0x06001597 RID: 5527 RVA: 0x0007DCA0 File Offset: 0x0007BEA0
	private void InternalOpen(float speed, Ease ease, float rotation)
	{
		if (!this.IsSilent && !this.IsOpen)
		{
			GameManager.Instance.AudioManager.PlayAtPosition(this.m_DoorOpenClip, base.transform.position, AudioObjectType.SOUND_EFFECT, 0, false, null);
		}
		this.IsOpen = true;
		if (this.m_Portal)
		{
			this.m_Portal.open = true;
		}
		this.AnimateDoor(new Vector3(0f, rotation, 0f), 1f, Ease.OutQuad).OnComplete(new TweenCallback(this.SendOpenOnComplete));
	}

	// Token: 0x06001598 RID: 5528 RVA: 0x0007DD3C File Offset: 0x0007BF3C
	public void ForceOpen(float rotation)
	{
		if (this.m_Portal)
		{
			this.m_Portal.open = true;
		}
		this.m_Door.localEulerAngles = new Vector3(0f, rotation, 0f);
		this.IsOpen = true;
		this.IsSilent = true;
	}

	// Token: 0x06001599 RID: 5529 RVA: 0x000118C1 File Offset: 0x0000FAC1
	public void Open(float speed, Ease ease, float rotation)
	{
		if (this.CheckLocked())
		{
			return;
		}
		if (this.m_Portal)
		{
			this.m_Portal.open = true;
		}
		this.InternalOpen(speed, ease, rotation);
	}

	// Token: 0x0600159A RID: 5530 RVA: 0x000118F4 File Offset: 0x0000FAF4
	public void ForceClose()
	{
		this.m_Door.localEulerAngles = Vector3.zero;
		if (this.m_Portal)
		{
			this.m_Portal.open = false;
		}
		this.IsOpen = false;
		this.IsSilent = false;
	}

	// Token: 0x0600159B RID: 5531 RVA: 0x00011930 File Offset: 0x0000FB30
	public void Close()
	{
		this.Close(1f, Ease.InQuad);
	}

	// Token: 0x0600159C RID: 5532 RVA: 0x0007DD90 File Offset: 0x0007BF90
	public void Close(float speed, Ease ease)
	{
		if (!this.IsSilent && this.IsOpen)
		{
			GameManager.Instance.AudioManager.PlayAtPosition(this.m_DoorCloseClip, base.transform.position, AudioObjectType.SOUND_EFFECT, 0, false, null);
		}
		this.IsOpen = false;
		this.AnimateDoor(Vector3.zero, speed, ease).OnComplete(new TweenCallback(this.SendCloseOnComplete));
	}

	// Token: 0x0600159D RID: 5533 RVA: 0x0001193E File Offset: 0x0000FB3E
	private Tweener AnimateDoor(Vector3 rotation, float speed, Ease ease)
	{
		this.m_Door.DOKill(false);
		return this.m_Door.DOLocalRotate(rotation, speed, RotateMode.Fast).SetEase(ease);
	}

	// Token: 0x0600159E RID: 5534 RVA: 0x0007DE00 File Offset: 0x0007C000
	private AudioObject PlayLockedAudio()
	{
		if (this.m_LockAudioClips.Count <= 0 || this.IsOpen)
		{
			return null;
		}
		int num = global::UnityEngine.Random.Range(0, this.m_LockAudioClips.Count);
		AudioClip audioClip = this.m_LockAudioClips[num];
		AudioObject audioObject = GameManager.Instance.AudioManager.PlayAtPosition(audioClip, base.transform.position, AudioObjectType.SOUND_EFFECT, 0, false, null);
		this.m_LockAudioClips[num] = this.m_LockAudioClips[0];
		this.m_LockAudioClips[0] = audioClip;
		return audioObject;
	}

	// Token: 0x0600159F RID: 5535 RVA: 0x00011961 File Offset: 0x0000FB61
	private void HandleDoorBackOnInteracted(object sender, EventArgs e)
	{
		if (this.CheckLocked())
		{
			return;
		}
		this.OnInteracted.Send(this);
		this.Lock();
		this.InternalOpen(1f, Ease.OutQuad, 145f);
	}

	// Token: 0x060015A0 RID: 5536 RVA: 0x00011992 File Offset: 0x0000FB92
	private void HandleDoorFrontOnInteracted(object sender, EventArgs e)
	{
		if (this.CheckLocked())
		{
			return;
		}
		this.OnInteracted.Send(this);
		this.Lock();
		this.InternalOpen(1f, Ease.OutQuad, -145f);
	}

	// Token: 0x060015A1 RID: 5537 RVA: 0x0007DE90 File Offset: 0x0007C090
	public bool CheckLocked()
	{
		if (this.IsLocked)
		{
			if (this.m_LockAudioObject == null)
			{
				this.m_LockAudioObject = this.PlayLockedAudio();
				if (this.m_LockAudioObject != null)
				{
					this.m_LockAudioObject.OnComplete += this.HandleLockAudioOnComplete;
				}
			}
			return true;
		}
		return false;
	}

	// Token: 0x060015A2 RID: 5538 RVA: 0x000119C3 File Offset: 0x0000FBC3
	public void Lock()
	{
		this.IsLocked = true;
	}

	// Token: 0x060015A3 RID: 5539 RVA: 0x000119CC File Offset: 0x0000FBCC
	public void Unlock()
	{
		this.IsLocked = false;
	}

	// Token: 0x060015A4 RID: 5540 RVA: 0x000119D5 File Offset: 0x0000FBD5
	public void UnlockAndActivate()
	{
		this.Unlock();
	}

	// Token: 0x060015A5 RID: 5541 RVA: 0x000119DD File Offset: 0x0000FBDD
	private void HandleLockAudioOnComplete(object sender, EventArgs e)
	{
		this.m_LockAudioObject.OnComplete -= this.HandleLockAudioOnComplete;
		this.m_LockAudioObject.Clear();
		this.m_LockAudioObject = null;
	}

	// Token: 0x060015A6 RID: 5542 RVA: 0x0007DEF0 File Offset: 0x0007C0F0
	private void AddListeners()
	{
		this.m_DoorFront.OnInteracted += this.HandleDoorFrontOnInteracted;
		this.m_DoorFront.SetActive(true);
		this.m_DoorBack.OnInteracted += this.HandleDoorBackOnInteracted;
		this.m_DoorBack.SetActive(true);
	}

	// Token: 0x060015A7 RID: 5543 RVA: 0x0007DF44 File Offset: 0x0007C144
	private void RemoveListeners()
	{
		this.m_DoorBack.OnInteracted -= this.HandleDoorBackOnInteracted;
		this.m_DoorBack.SetActive(false);
		this.m_DoorFront.OnInteracted -= this.HandleDoorFrontOnInteracted;
		this.m_DoorFront.SetActive(false);
	}

	// Token: 0x060015A8 RID: 5544 RVA: 0x00011A08 File Offset: 0x0000FC08
	private void SendCloseOnComplete()
	{
		if (this.m_Portal)
		{
			this.m_Portal.open = true;
		}
		this.OnClose.Send(this);
	}

	// Token: 0x060015A9 RID: 5545 RVA: 0x00011A32 File Offset: 0x0000FC32
	private void SendOpenOnComplete()
	{
		this.OnOpen.Send(this);
	}

	// Token: 0x060015AA RID: 5546 RVA: 0x0007DF98 File Offset: 0x0007C198
	protected override void OnDisposed()
	{
		this.RemoveListeners();
		this.m_Door.DOKill(false);
		this.OnClose = null;
		this.OnOpen = null;
		this.OnInteracted = null;
		this.m_Portal = null;
		this.m_DoorOpenClip = null;
		this.m_DoorCloseClip = null;
		this.m_LockAudioObject = null;
		base.OnDisposed();
	}

	// Token: 0x04001365 RID: 4965
	[Header("Transforms")]
	[SerializeField]
	private Transform m_Door;

	// Token: 0x04001366 RID: 4966
	[Header("Interactables")]
	[SerializeField]
	private Interactable m_DoorFront;

	// Token: 0x04001367 RID: 4967
	[SerializeField]
	private Interactable m_DoorBack;

	// Token: 0x04001368 RID: 4968
	[Header("Audio")]
	[SerializeField]
	private List<AudioClip> m_LockAudioClips;

	// Token: 0x04001369 RID: 4969
	[Header("Door Options")]
	[SerializeField]
	public bool IsUnlockedAtStart = true;

	// Token: 0x0400136A RID: 4970
	private OcclusionPortal m_Portal;

	// Token: 0x0400136B RID: 4971
	private AudioClip m_DoorOpenClip;

	// Token: 0x0400136C RID: 4972
	private AudioClip m_DoorCloseClip;

	// Token: 0x0400136D RID: 4973
	private AudioObject m_LockAudioObject;
}
