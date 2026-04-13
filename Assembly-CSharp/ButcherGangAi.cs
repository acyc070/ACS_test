using System;
using System.Collections.Generic;
using Ai;
using UnityEngine;

// Token: 0x020001A5 RID: 421
public class ButcherGangAi : BaseAiController
{
	// Token: 0x170000EF RID: 239
	// (get) Token: 0x060011E8 RID: 4584 RVA: 0x0000F112 File Offset: 0x0000D312
	public ButcherGangAi.ButcherGang ButcherGangTyoe
	{
		get
		{
			return this.m_ButcherGangType;
		}
	}

	// Token: 0x060011E9 RID: 4585 RVA: 0x00072C64 File Offset: 0x00070E64
	public override void Init()
	{
		base.Init();
		this.m_IdleClips = GameManager.Instance.AssetManager.GetAssets<AudioClip>("Audio/SFX/Characters/ButcherGang/Idle/");
		this.m_AttackClips = GameManager.Instance.AssetManager.GetAssets<AudioClip>("Audio/SFX/Characters/ButcherGang/Attack/");
		this.m_DeathClips = GameManager.Instance.AssetManager.GetAssets<AudioClip>("Audio/SFX/Characters/ButcherGang/Death/");
		this.m_HitClips = GameManager.Instance.AssetManager.GetAssets<AudioClip>("Audio/SFX/Characters/ButcherGang/Hit/");
		this.m_HitMeclip = GameManager.Instance.AssetManager.GetAsset<AudioClip>("Audio/SFX/Characters/ButcherGang/CH3_BUTCHER_GANG_HITME");
	}

	// Token: 0x060011EA RID: 4586 RVA: 0x00072CFC File Offset: 0x00070EFC
	public override void InitOnComplete()
	{
		base.InitOnComplete();
		if (this.m_EnableIdleAudio && !this.m_EnableIdleAudioOnDistanceActive)
		{
			this.m_HasIdleAudio = true;
			this.m_IdleAudio = this.PlayAudio(ref this.m_IdleClips, false);
			this.m_IdleAudioTimerLimit = this.m_IdleAudio.AudioClip.length + 0.5f;
		}
	}

	// Token: 0x060011EB RID: 4587 RVA: 0x00072D58 File Offset: 0x00070F58
	protected override void Update()
	{
		base.Update();
		if (this.CheckForBendy())
		{
			Vector3 vector = this.m_Bendy.transform.position - base.transform.position;
			Vector3 vector2 = base.transform.position + vector.normalized * 5f;
			base.ForceDeath(vector2);
			return;
		}
		if (base.IsDisposed || GameManager.Instance.isPaused)
		{
			return;
		}
		this.m_IdleAudioTimer += Time.deltaTime;
		if (this.m_HasIdleAudio && this.m_IdleAudioTimer > this.m_IdleAudioTimerLimit && (this.m_IdleAudio == null || !this.m_IdleAudio.AudioSource.isPlaying))
		{
			this.m_IdleAudioTimer = 0f;
			this.m_IdleAudio = this.PlayAudio(ref this.m_IdleClips, false);
			this.m_IdleAudioTimerLimit = this.m_IdleAudio.AudioClip.length + global::UnityEngine.Random.Range(0.5f, 1f);
		}
	}

	// Token: 0x060011EC RID: 4588 RVA: 0x00072E60 File Offset: 0x00071060
	private bool CheckForBendy()
	{
		bool flag = false;
		if (!this.m_Bendy)
		{
			this.m_Bendy = GameManager.Instance.CharacterManager.Bendy;
		}
		if (this.m_Bendy)
		{
			flag = Vector3.Distance(base.transform.position, this.m_Bendy.transform.position) < 20f;
		}
		return flag;
	}

	// Token: 0x060011ED RID: 4589 RVA: 0x00072EC8 File Offset: 0x000710C8
	protected override void T_EnterActivate()
	{
		base.T_EnterActivate();
		base.SendOnActive();
		if (this.m_EnableIdleAudio)
		{
			this.m_HasIdleAudio = true;
			this.m_IdleAudio = this.PlayAudio(ref this.m_IdleClips, false);
			this.m_IdleAudioTimerLimit = this.m_IdleAudio.AudioClip.length + 0.5f;
		}
	}

	// Token: 0x060011EE RID: 4590 RVA: 0x0000F11A File Offset: 0x0000D31A
	protected override void T_EnterDistanceActivation()
	{
		base.T_EnterDistanceActivation();
		base.SendOnDistanceActivate();
	}

	// Token: 0x060011EF RID: 4591 RVA: 0x0000F128 File Offset: 0x0000D328
	protected override void T_EnterFollow()
	{
		base.T_EnterFollow();
		if (global::UnityEngine.Random.value < 0.02f)
		{
			GameManager.Instance.AudioManager.PlayAtPosition(this.m_HitMeclip, this.m_EyeLocation.position, AudioObjectType.SOUND_EFFECT, 0, false, null);
		}
	}

	// Token: 0x060011F0 RID: 4592 RVA: 0x0000E55C File Offset: 0x0000C75C
	protected override void T_EnterRetreat()
	{
		base.T_EnterRetreat();
		base.SetThought(AiThought.UseWaypoints);
	}

	// Token: 0x060011F1 RID: 4593 RVA: 0x0000F161 File Offset: 0x0000D361
	public override void Hit(RaycastHit hit, WeaponInfo weaponInfo = null)
	{
		if (weaponInfo == null)
		{
			return;
		}
		this.PlayAudio(ref this.m_HitClips, true);
		base.Hit(hit, weaponInfo);
	}

	// Token: 0x060011F2 RID: 4594 RVA: 0x0000F17D File Offset: 0x0000D37D
	public override void AttackTarget()
	{
		base.AttackTarget();
		this.PlayAudio(ref this.m_AttackClips, false);
	}

	// Token: 0x060011F3 RID: 4595 RVA: 0x00072F20 File Offset: 0x00071120
	protected override void T_EnterDie()
	{
		base.T_EnterDie();
		this.m_HasIdleAudio = false;
		if (this.m_IdleAudio != null)
		{
			this.m_IdleAudio.Clear();
			this.m_IdleAudio = null;
		}
		this.PlayAudio(ref this.m_DeathClips, false);
		base.SendOnDeath();
	}

	// Token: 0x060011F4 RID: 4596 RVA: 0x0000F193 File Offset: 0x0000D393
	public void UpdateWaypointList(List<WaypointNode> waypointList, bool isRunning = false)
	{
		this.m_CurrentWaypointList.Clear();
		this.m_UseRunForWaypoints = isRunning;
		this.m_WaypointIndex = 0;
		this.m_CurrentWaypointList = new List<WaypointNode>(waypointList);
		this.m_StartingThought = AiThought.UseWaypoints;
		base.SetThought(AiThought.UseWaypoints);
	}

	// Token: 0x060011F5 RID: 4597 RVA: 0x00072F70 File Offset: 0x00071170
	private AudioObject PlayAudio(ref AudioClip[] audioClips, bool is2D = false)
	{
		if (audioClips == null || audioClips.Length == 0)
		{
			return null;
		}
		int num = global::UnityEngine.Random.Range(0, audioClips.Length);
		AudioClip audioClip = audioClips[num];
		AudioObject audioObject;
		if (is2D)
		{
			audioObject = GameManager.Instance.AudioManager.Play(audioClip, AudioObjectType.SOUND_EFFECT, 0, false);
		}
		else
		{
			audioObject = GameManager.Instance.AudioManager.PlayAtPosition(audioClip, this.m_EyeLocation.position, AudioObjectType.SOUND_EFFECT, 0, false, this.m_EyeLocation);
		}
		audioClips[num] = audioClips[0];
		audioClips[0] = audioClip;
		return audioObject;
	}

	// Token: 0x060011F6 RID: 4598 RVA: 0x0000DF94 File Offset: 0x0000C194
	protected override void OnDisposed()
	{
		base.OnDisposed();
	}

	// Token: 0x04000E93 RID: 3731
	[Header("Butcher Gang Options")]
	[SerializeField]
	private ButcherGangAi.ButcherGang m_ButcherGangType;

	// Token: 0x04000E94 RID: 3732
	[SerializeField]
	private bool m_EnableIdleAudio = true;

	// Token: 0x04000E95 RID: 3733
	[SerializeField]
	private bool m_EnableIdleAudioOnDistanceActive;

	// Token: 0x04000E96 RID: 3734
	private AudioClip[] m_IdleClips;

	// Token: 0x04000E97 RID: 3735
	private AudioClip[] m_HitClips;

	// Token: 0x04000E98 RID: 3736
	private AudioClip[] m_AttackClips;

	// Token: 0x04000E99 RID: 3737
	private AudioClip[] m_DeathClips;

	// Token: 0x04000E9A RID: 3738
	private AudioClip m_HitMeclip;

	// Token: 0x04000E9B RID: 3739
	private AudioObject m_IdleAudio;

	// Token: 0x04000E9C RID: 3740
	private bool m_HasIdleAudio;

	// Token: 0x04000E9D RID: 3741
	private float m_IdleAudioTimer;

	// Token: 0x04000E9E RID: 3742
	private float m_IdleAudioTimerLimit = 10f;

	// Token: 0x04000E9F RID: 3743
	private BendyAi m_Bendy;

	// Token: 0x020001A6 RID: 422
	public enum ButcherGang
	{
		// Token: 0x04000EA1 RID: 3745
		PIPER,
		// Token: 0x04000EA2 RID: 3746
		FISHER,
		// Token: 0x04000EA3 RID: 3747
		STRIKER
	}
}
