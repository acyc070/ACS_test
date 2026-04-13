using System;
using System.Diagnostics;
using DG.Tweening;
using TMG.Core;
using UnityEngine;

// Token: 0x02000080 RID: 128
public class CH1Pedestal : TMGMonoBehaviour
{
	// Token: 0x14000001 RID: 1
	// (add) Token: 0x06000470 RID: 1136 RVA: 0x00030400 File Offset: 0x0002E600
	// (remove) Token: 0x06000471 RID: 1137 RVA: 0x00030438 File Offset: 0x0002E638
	[field: DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public event EventHandler OnCollect;

	// Token: 0x14000002 RID: 2
	// (add) Token: 0x06000472 RID: 1138 RVA: 0x00030470 File Offset: 0x0002E670
	// (remove) Token: 0x06000473 RID: 1139 RVA: 0x000304A8 File Offset: 0x0002E6A8
	[field: DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public event EventHandler OnComplete;

	// Token: 0x1700004C RID: 76
	// (get) Token: 0x06000474 RID: 1140 RVA: 0x000062FA File Offset: 0x000044FA
	public Transform Collectable
	{
		get
		{
			return this.m_Collectable.transform;
		}
	}

	// Token: 0x1700004D RID: 77
	// (get) Token: 0x06000475 RID: 1141 RVA: 0x00006307 File Offset: 0x00004507
	public Sprite MenuSprite
	{
		get
		{
			return this.m_MenuSprite;
		}
	}

	// Token: 0x1700004E RID: 78
	// (get) Token: 0x06000476 RID: 1142 RVA: 0x0000630F File Offset: 0x0000450F
	// (set) Token: 0x06000477 RID: 1143 RVA: 0x00006317 File Offset: 0x00004517
	public bool isComplete { get; private set; }

	// Token: 0x06000478 RID: 1144 RVA: 0x00006320 File Offset: 0x00004520
	public override void InitOnComplete()
	{
		base.InitOnComplete();
		this.m_LightClip = GameManager.Instance.GetAudioClip("Audio/SFX/SFX_Light_Switch_Sammys_Room_01");
	}

	// Token: 0x06000479 RID: 1145 RVA: 0x000304E0 File Offset: 0x0002E6E0
	public void Initialize(Transform collectableLocation)
	{
		this.m_Collectable.transform.position = collectableLocation.position;
		this.m_Collectable.transform.eulerAngles = collectableLocation.eulerAngles;
		this.CheckCollectableType();
		this.isComplete = false;
		this.m_Pedestal.SetActive(false);
		this.m_Collectable.SetActive(false);
		this.m_Collected.SetActive(false);
		this.TurnLightOff();
		if (GameManager.Instance.GameData.CurrentSaveFile.CH1Data.CollectablesObjective.IsComplete || this.IsTypeComplete())
		{
			this.ForceComplete();
		}
		else if (this.IsTypeCollected())
		{
			this.ForceCollected();
		}
	}

	// Token: 0x0600047A RID: 1146 RVA: 0x0000633D File Offset: 0x0000453D
	public void Activate()
	{
		this.m_Collectable.SetActive(true);
		this.m_Collectable.OnInteracted += this.HandleCollectableOnCollected;
	}

	// Token: 0x0600047B RID: 1147 RVA: 0x00006362 File Offset: 0x00004562
	public void TurnLightOff()
	{
		this.m_Light.TurnOff();
	}

	// Token: 0x0600047C RID: 1148 RVA: 0x0003059C File Offset: 0x0002E79C
	private void HandleCollectableOnCollected(object sender, EventArgs e)
	{
		this.m_Collectable.OnInteracted -= this.HandleCollectableOnCollected;
		GameManager.Instance.ShowCollectable(CollectableDataVO.Create(this.m_AudioKey, this.m_SpriteLookupKey, this.m_SpriteListKey));
		this.m_Collectable.Dispose();
		this.isCollected = true;
		this.SetTypeCollected();
		this.OnCollect.Send(this);
		this.m_Pedestal.OnInteracted += this.HandlePedestalOnInteracted;
		this.m_Pedestal.SetActive(true);
	}

	// Token: 0x0600047D RID: 1149 RVA: 0x0000636F File Offset: 0x0000456F
	private void HandlePedestalOnInteracted(object sender, EventArgs e)
	{
		this.m_Pedestal.OnInteracted -= this.HandlePedestalOnInteracted;
		this.m_Pedestal.SetActive(false);
		this.DOCollect().OnComplete(new TweenCallback(this.HandleCollectOnComplete));
	}

	// Token: 0x0600047E RID: 1150 RVA: 0x00030628 File Offset: 0x0002E828
	private Sequence DOCollect()
	{
		this.ResetSequence();
		this.m_Collected.SetActive(true);
		GameManager.Instance.AudioManager.Play(this.m_CollectClip, AudioObjectType.SOUND_EFFECT, 0, false);
		this.m_CollectSequence.Insert(0.1f, this.m_Pedestal.transform.DOLocalMoveY(-0.15f, 0.75f, false).SetEase(Ease.OutBack));
		this.m_CollectSequence.InsertCallback(0.6f, new TweenCallback(this.TurnLightOn));
		return this.m_CollectSequence;
	}

	// Token: 0x0600047F RID: 1151 RVA: 0x000063AC File Offset: 0x000045AC
	private void TurnLightOn()
	{
		GameManager.Instance.AudioManager.PlayAtPosition(this.m_LightClip, base.transform.position, AudioObjectType.SOUND_EFFECT, 0, false, null);
		this.m_Light.TurnOn();
	}

	// Token: 0x06000480 RID: 1152 RVA: 0x000063DE File Offset: 0x000045DE
	private void HandleCollectOnComplete()
	{
		this.isComplete = true;
		this.SetTypeComplete();
		this.OnComplete.Send(this);
	}

	// Token: 0x06000481 RID: 1153 RVA: 0x000306B8 File Offset: 0x0002E8B8
	private void CheckCollectableType()
	{
		if (this.m_CollectableType == CH1Pedestal.CollectableType.GEAR)
		{
			this.m_AudioKey = GameManager.Instance.GetAudioClip("Audio/SFX/Collectables/SFX_Gear_Pick_UP_Vanish_01");
			this.m_SpriteLookupKey = "UI/ChapterOneCollectables/ChapterOneCollectables";
			this.m_SpriteListKey = "collectable_gear";
			this.m_CollectClip = GameManager.Instance.GetAudioClip("Audio/SFX/Collectables/SFX_Gear_01");
		}
		else if (this.m_CollectableType == CH1Pedestal.CollectableType.WRENCH)
		{
			this.m_AudioKey = GameManager.Instance.GetAudioClip("Audio/SFX/Collectables/SFX_Wrench_Pick_UP_Vanish_01");
			this.m_SpriteLookupKey = "UI/ChapterOneCollectables/ChapterOneCollectables";
			this.m_SpriteListKey = "collectable_wrench";
			this.m_CollectClip = GameManager.Instance.GetAudioClip("Audio/SFX/Collectables/SFX_Wrench_01");
		}
		else if (this.m_CollectableType == CH1Pedestal.CollectableType.BOOK)
		{
			this.m_AudioKey = GameManager.Instance.GetAudioClip("Audio/SFX/Collectables/SFX_Book_Pick_Up_Vanish_01");
			this.m_SpriteLookupKey = "UI/ChapterOneCollectables/ChapterOneCollectables";
			this.m_SpriteListKey = "collectable_book";
			this.m_CollectClip = GameManager.Instance.GetAudioClip("Audio/SFX/Collectables/SFX_Book_01");
		}
		else if (this.m_CollectableType == CH1Pedestal.CollectableType.DOLL)
		{
			this.m_AudioKey = GameManager.Instance.GetAudioClip("Audio/SFX/Collectables/SFX_Toy_Pick_UP_Vanish_01");
			this.m_SpriteLookupKey = "UI/ChapterOneCollectables/ChapterOneCollectables";
			this.m_SpriteListKey = "collectable_doll";
			this.m_CollectClip = GameManager.Instance.GetAudioClip("Audio/SFX/Collectables/SFX_Toy_01");
		}
		else if (this.m_CollectableType == CH1Pedestal.CollectableType.RECORD)
		{
			this.m_AudioKey = GameManager.Instance.GetAudioClip("Audio/SFX/Collectables/SFX_Record_Pick_UP_Vanish_01");
			this.m_SpriteLookupKey = "UI/ChapterOneCollectables/ChapterOneCollectables";
			this.m_SpriteListKey = "collectable_record";
			this.m_CollectClip = GameManager.Instance.GetAudioClip("Audio/SFX/Collectables/SFX_Record_01");
		}
		else if (this.m_CollectableType == CH1Pedestal.CollectableType.INKWELL)
		{
			this.m_AudioKey = GameManager.Instance.GetAudioClip("Audio/SFX/Collectables/SFX_Ink_Jar_Pick_UP_Vanish_01");
			this.m_SpriteLookupKey = "UI/ChapterOneCollectables/ChapterOneCollectables";
			this.m_SpriteListKey = "collectable_inkwell";
			this.m_CollectClip = GameManager.Instance.GetAudioClip("Audio/SFX/Collectables/SFX_Ink_Jar_01");
		}
	}

	// Token: 0x06000482 RID: 1154 RVA: 0x000063F9 File Offset: 0x000045F9
	public void UpdateObjective()
	{
		this.IsTypeCollected();
	}

	// Token: 0x06000483 RID: 1155 RVA: 0x000308AC File Offset: 0x0002EAAC
	private bool IsTypeCollected()
	{
		if (this.m_CollectableType == CH1Pedestal.CollectableType.GEAR)
		{
			if (GameManager.Instance.GameData.CurrentSaveFile.CH1Data.Gear.IsStarted)
			{
				if (GameManager.Instance.CurrentObjective != null && GameManager.Instance.CurrentObjective.Collected != null)
				{
					GameManager.Instance.CurrentObjective.Collected[0] = true;
				}
				return true;
			}
			return false;
		}
		else if (this.m_CollectableType == CH1Pedestal.CollectableType.WRENCH)
		{
			if (GameManager.Instance.GameData.CurrentSaveFile.CH1Data.Wrench.IsStarted)
			{
				if (GameManager.Instance.CurrentObjective != null && GameManager.Instance.CurrentObjective.Collected != null)
				{
					GameManager.Instance.CurrentObjective.Collected[1] = true;
				}
				return true;
			}
			return false;
		}
		else if (this.m_CollectableType == CH1Pedestal.CollectableType.BOOK)
		{
			if (GameManager.Instance.GameData.CurrentSaveFile.CH1Data.Book.IsStarted)
			{
				if (GameManager.Instance.CurrentObjective != null && GameManager.Instance.CurrentObjective.Collected != null)
				{
					GameManager.Instance.CurrentObjective.Collected[2] = true;
				}
				return true;
			}
			return false;
		}
		else if (this.m_CollectableType == CH1Pedestal.CollectableType.DOLL)
		{
			if (GameManager.Instance.GameData.CurrentSaveFile.CH1Data.Doll.IsStarted)
			{
				if (GameManager.Instance.CurrentObjective != null && GameManager.Instance.CurrentObjective.Collected != null)
				{
					GameManager.Instance.CurrentObjective.Collected[3] = true;
				}
				return true;
			}
			return false;
		}
		else if (this.m_CollectableType == CH1Pedestal.CollectableType.RECORD)
		{
			if (GameManager.Instance.GameData.CurrentSaveFile.CH1Data.Record.IsStarted)
			{
				if (GameManager.Instance.CurrentObjective != null && GameManager.Instance.CurrentObjective.Collected != null)
				{
					GameManager.Instance.CurrentObjective.Collected[4] = true;
				}
				return true;
			}
			return false;
		}
		else
		{
			if (this.m_CollectableType != CH1Pedestal.CollectableType.INKWELL)
			{
				return false;
			}
			if (GameManager.Instance.GameData.CurrentSaveFile.CH1Data.Inkwell.IsStarted)
			{
				if (GameManager.Instance.CurrentObjective != null && GameManager.Instance.CurrentObjective.Collected != null)
				{
					GameManager.Instance.CurrentObjective.Collected[5] = true;
				}
				return true;
			}
			return false;
		}
	}

	// Token: 0x06000484 RID: 1156 RVA: 0x00030B44 File Offset: 0x0002ED44
	private bool IsTypeComplete()
	{
		if (this.m_CollectableType == CH1Pedestal.CollectableType.GEAR)
		{
			return GameManager.Instance.GameData.CurrentSaveFile.CH1Data.Gear.IsComplete;
		}
		if (this.m_CollectableType == CH1Pedestal.CollectableType.WRENCH)
		{
			return GameManager.Instance.GameData.CurrentSaveFile.CH1Data.Wrench.IsComplete;
		}
		if (this.m_CollectableType == CH1Pedestal.CollectableType.BOOK)
		{
			return GameManager.Instance.GameData.CurrentSaveFile.CH1Data.Book.IsComplete;
		}
		if (this.m_CollectableType == CH1Pedestal.CollectableType.DOLL)
		{
			return GameManager.Instance.GameData.CurrentSaveFile.CH1Data.Doll.IsComplete;
		}
		if (this.m_CollectableType == CH1Pedestal.CollectableType.RECORD)
		{
			return GameManager.Instance.GameData.CurrentSaveFile.CH1Data.Record.IsComplete;
		}
		return this.m_CollectableType == CH1Pedestal.CollectableType.INKWELL && GameManager.Instance.GameData.CurrentSaveFile.CH1Data.Inkwell.IsComplete;
	}

	// Token: 0x06000485 RID: 1157 RVA: 0x00030C54 File Offset: 0x0002EE54
	private void SetTypeCollected()
	{
		if (this.m_CollectableType == CH1Pedestal.CollectableType.GEAR)
		{
			if (GameManager.Instance.CurrentObjective != null && GameManager.Instance.CurrentObjective.Collected != null)
			{
				GameManager.Instance.CurrentObjective.Collected[0] = true;
			}
			GameManager.Instance.GameData.CurrentSaveFile.CH1Data.Gear.IsStarted = true;
		}
		else if (this.m_CollectableType == CH1Pedestal.CollectableType.WRENCH)
		{
			if (GameManager.Instance.CurrentObjective != null && GameManager.Instance.CurrentObjective.Collected != null)
			{
				GameManager.Instance.CurrentObjective.Collected[1] = true;
			}
			GameManager.Instance.GameData.CurrentSaveFile.CH1Data.Wrench.IsStarted = true;
		}
		else if (this.m_CollectableType == CH1Pedestal.CollectableType.BOOK)
		{
			if (GameManager.Instance.CurrentObjective != null && GameManager.Instance.CurrentObjective.Collected != null)
			{
				GameManager.Instance.CurrentObjective.Collected[2] = true;
			}
			GameManager.Instance.GameData.CurrentSaveFile.CH1Data.Book.IsStarted = true;
		}
		else if (this.m_CollectableType == CH1Pedestal.CollectableType.DOLL)
		{
			if (GameManager.Instance.CurrentObjective != null && GameManager.Instance.CurrentObjective.Collected != null)
			{
				GameManager.Instance.CurrentObjective.Collected[3] = true;
			}
			GameManager.Instance.GameData.CurrentSaveFile.CH1Data.Doll.IsStarted = true;
		}
		else if (this.m_CollectableType == CH1Pedestal.CollectableType.RECORD)
		{
			if (GameManager.Instance.CurrentObjective != null && GameManager.Instance.CurrentObjective.Collected != null)
			{
				GameManager.Instance.CurrentObjective.Collected[4] = true;
			}
			GameManager.Instance.GameData.CurrentSaveFile.CH1Data.Record.IsStarted = true;
		}
		else
		{
			if (this.m_CollectableType != CH1Pedestal.CollectableType.INKWELL)
			{
				return;
			}
			if (GameManager.Instance.CurrentObjective != null && GameManager.Instance.CurrentObjective.Collected != null)
			{
				GameManager.Instance.CurrentObjective.Collected[5] = true;
			}
			GameManager.Instance.GameData.CurrentSaveFile.CH1Data.Inkwell.IsStarted = true;
		}
		GameManager.Instance.GameDataManager.Save(false, true);
	}

	// Token: 0x06000486 RID: 1158 RVA: 0x00030EE8 File Offset: 0x0002F0E8
	private void SetTypeComplete()
	{
		if (this.m_CollectableType == CH1Pedestal.CollectableType.GEAR)
		{
			GameManager.Instance.GameData.CurrentSaveFile.CH1Data.Gear.IsComplete = true;
		}
		else if (this.m_CollectableType == CH1Pedestal.CollectableType.WRENCH)
		{
			GameManager.Instance.GameData.CurrentSaveFile.CH1Data.Wrench.IsComplete = true;
		}
		else if (this.m_CollectableType == CH1Pedestal.CollectableType.BOOK)
		{
			GameManager.Instance.GameData.CurrentSaveFile.CH1Data.Book.IsComplete = true;
		}
		else if (this.m_CollectableType == CH1Pedestal.CollectableType.DOLL)
		{
			GameManager.Instance.GameData.CurrentSaveFile.CH1Data.Doll.IsComplete = true;
		}
		else if (this.m_CollectableType == CH1Pedestal.CollectableType.RECORD)
		{
			GameManager.Instance.GameData.CurrentSaveFile.CH1Data.Record.IsComplete = true;
		}
		else if (this.m_CollectableType == CH1Pedestal.CollectableType.INKWELL)
		{
			GameManager.Instance.GameData.CurrentSaveFile.CH1Data.Inkwell.IsComplete = true;
		}
		GameManager.Instance.GameDataManager.Save(false, true);
	}

	// Token: 0x06000487 RID: 1159 RVA: 0x00006402 File Offset: 0x00004602
	private void ForceCollected()
	{
		this.m_Collectable.Dispose();
		this.isCollected = true;
		this.m_Pedestal.OnInteracted += this.HandlePedestalOnInteracted;
		this.m_Pedestal.SetActive(true);
	}

	// Token: 0x06000488 RID: 1160 RVA: 0x00031028 File Offset: 0x0002F228
	private void ForceComplete()
	{
		this.isCollected = true;
		this.isComplete = true;
		this.m_Light.TurnOn();
		this.m_Collectable.Dispose();
		this.m_Collected.SetActive(true);
		this.m_Pedestal.transform.position += Vector3.down * 0.15f;
	}

	// Token: 0x06000489 RID: 1161 RVA: 0x00006439 File Offset: 0x00004639
	private void ResetSequence()
	{
		this.KillSequence();
		this.m_CollectSequence = DOTween.Sequence();
	}

	// Token: 0x0600048A RID: 1162 RVA: 0x0000644C File Offset: 0x0000464C
	private void KillSequence()
	{
		if (this.m_CollectSequence != null)
		{
			this.m_CollectSequence.Kill(false);
			this.m_CollectSequence = null;
		}
	}

	// Token: 0x0600048B RID: 1163 RVA: 0x00031090 File Offset: 0x0002F290
	protected override void OnDisposed()
	{
		this.OnComplete = null;
		if (this.m_Pedestal)
		{
			this.m_Pedestal.OnInteracted -= this.HandlePedestalOnInteracted;
		}
		if (this.m_Collectable)
		{
			this.m_Collectable.OnInteracted -= this.HandleCollectableOnCollected;
		}
		this.m_LightClip = null;
		this.m_CollectClip = null;
		this.m_AudioKey = null;
		this.KillSequence();
		base.OnDisposed();
	}

	// Token: 0x040002F7 RID: 759
	[Header("Type")]
	[SerializeField]
	private CH1Pedestal.CollectableType m_CollectableType;

	// Token: 0x040002F8 RID: 760
	[SerializeField]
	private Sprite m_MenuSprite;

	// Token: 0x040002F9 RID: 761
	[Header("Interactables")]
	[SerializeField]
	private Interactable m_Collectable;

	// Token: 0x040002FA RID: 762
	[SerializeField]
	private Interactable m_Pedestal;

	// Token: 0x040002FB RID: 763
	[Header("GameObject")]
	[SerializeField]
	private GameObject m_Collected;

	// Token: 0x040002FC RID: 764
	[Header("Light")]
	[SerializeField]
	private LightFixtureController m_Light;

	// Token: 0x040002FD RID: 765
	private Sequence m_CollectSequence;

	// Token: 0x040002FE RID: 766
	private AudioClip m_AudioKey;

	// Token: 0x040002FF RID: 767
	private string m_SpriteLookupKey;

	// Token: 0x04000300 RID: 768
	private string m_SpriteListKey;

	// Token: 0x04000301 RID: 769
	private AudioClip m_CollectClip;

	// Token: 0x04000302 RID: 770
	private AudioClip m_LightClip;

	// Token: 0x04000303 RID: 771
	public bool isCollected;

	// Token: 0x02000081 RID: 129
	public enum CollectableType
	{
		// Token: 0x04000306 RID: 774
		GEAR,
		// Token: 0x04000307 RID: 775
		WRENCH,
		// Token: 0x04000308 RID: 776
		BOOK,
		// Token: 0x04000309 RID: 777
		DOLL,
		// Token: 0x0400030A RID: 778
		RECORD,
		// Token: 0x0400030B RID: 779
		INKWELL
	}
}
