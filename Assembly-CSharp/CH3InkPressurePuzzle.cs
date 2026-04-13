using System;
using System.Collections.Generic;
using System.Diagnostics;
using Ai;
using DG.Tweening;
using TMG.Core;
using UnityEngine;

// Token: 0x020000E7 RID: 231
public class CH3InkPressurePuzzle : TMGMonoBehaviour
{
	// Token: 0x14000013 RID: 19
	// (add) Token: 0x06000915 RID: 2325 RVA: 0x0004B9E4 File Offset: 0x00049BE4
	// (remove) Token: 0x06000916 RID: 2326 RVA: 0x0004BA1C File Offset: 0x00049C1C
	[field: DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public event EventHandler OnComplete;

	// Token: 0x06000917 RID: 2327 RVA: 0x0004BA54 File Offset: 0x00049C54
	public override void InitOnComplete()
	{
		base.InitOnComplete();
		this.m_ValveClips = GameManager.Instance.GetAudioClips("Audio/SFX/CH3/Valves/");
		this.m_PuzzlePanelClip = GameManager.Instance.GetAudioClip("Audio/SFX/CH3/SFX_CH3_valvepaneldooropen");
		this.m_PowerCorePickupClip = GameManager.Instance.GetAudioClip("Audio/SFX/CH3/SFX_CH3_valvepanelcorepickup");
		this.m_PuzzleSolvedClip = GameManager.Instance.GetAudioClip("Audio/SFX/CH3/SFX_CH3_valvepuzzle_allinkvalvesaligned");
		this.m_PuzzleInkRiseClip = GameManager.Instance.GetAudioClip("Audio/SFX/CH3/SFX_CH3_valvepuzzle_inkrisinginpipes");
		this.m_Door.SetActive(false);
		for (int i = 0; i < this.m_InkValves.Count; i++)
		{
			this.m_InkValves[i].Valve.SetActive(false);
			this.m_InkValves[i].Direction = ((global::UnityEngine.Random.value >= 0.5f) ? 1 : (-1));
		}
	}

	// Token: 0x06000918 RID: 2328 RVA: 0x0004BB38 File Offset: 0x00049D38
	public void Deactivate()
	{
		this.m_Light.enabled = false;
		this.m_Collectable.gameObject.SetActive(false);
		this.m_Door.transform.localEulerAngles += new Vector3(0f, 50f, 0f);
		for (int i = 0; i < this.m_InkValves.Count; i++)
		{
			this.m_InkValves[i].Ink.localScale = new Vector3(1f, 0.5f, 1f);
		}
	}

	// Token: 0x06000919 RID: 2329 RVA: 0x0004BBD8 File Offset: 0x00049DD8
	public void Activate()
	{
		this.m_Light.enabled = true;
		this.m_Collectable.gameObject.SetActive(true);
		for (int i = 0; i < this.m_InkValves.Count; i++)
		{
			int num = global::UnityEngine.Random.Range(0, this.m_InkPositions.Length);
			this.m_InkValves[i].Index = num;
			this.m_InkValves[i].Ink.localScale = new Vector3(1f, this.m_InkPositions[num], 1f);
		}
	}

	// Token: 0x0600091A RID: 2330 RVA: 0x0004BC6C File Offset: 0x00049E6C
	public void ActivateInteraction()
	{
		for (int i = 0; i < this.m_InkValves.Count; i++)
		{
			CH3InkPressurePuzzle.InkValve inkValve = this.m_InkValves[i];
			if (inkValve.Index <= 0)
			{
				inkValve.Direction = 1;
			}
			else if (inkValve.Index >= this.m_InkPositions.Length - 1)
			{
				inkValve.Direction = -1;
			}
			inkValve.Valve.SetActive(true);
			inkValve.Valve.OnInteracted += this.HandleValveOnInteracted;
		}
	}

	// Token: 0x0600091B RID: 2331 RVA: 0x0004BCFC File Offset: 0x00049EFC
	private void DisableInteraction()
	{
		for (int i = 0; i < this.m_InkValves.Count; i++)
		{
			CH3InkPressurePuzzle.InkValve inkValve = this.m_InkValves[i];
			inkValve.Valve.SetActive(false);
			inkValve.Valve.OnInteracted -= this.HandleValveOnInteracted;
		}
	}

	// Token: 0x0600091C RID: 2332 RVA: 0x0004BD58 File Offset: 0x00049F58
	private void HandleValveOnInteracted(object sender, EventArgs e)
	{
		Interactable interactable = (Interactable)sender;
		if (!this.m_HasSearcher && global::UnityEngine.Random.value < 0.2f)
		{
			this.m_HasSearcher = true;
			SearcherAi searcherAi = GameManager.Instance.AssetManager.CreateAsset<SearcherAi>("GamePlay/Characters/Ai_Searcher");
			Vector3 vector = GameManager.Instance.Player.transform.position;
			vector += GameManager.Instance.Player.transform.forward * -5f;
			vector.y -= GameManager.Instance.Player.CharacterController.bounds.extents.y;
			searcherAi.transform.position = vector;
		}
		this.PlayAudio(ref this.m_ValveClips, false);
		for (int i = 0; i < this.m_InkValves.Count; i++)
		{
			CH3InkPressurePuzzle.InkValve inkValve = this.m_InkValves[i];
			if (inkValve.Valve.Equals(interactable))
			{
				inkValve.Valve.SetActive(false);
				inkValve.Valve.OnInteracted -= this.HandleValveOnInteracted;
				this.RotateValve(inkValve);
				break;
			}
		}
	}

	// Token: 0x0600091D RID: 2333 RVA: 0x0004BE9C File Offset: 0x0004A09C
	private void RotateValve(CH3InkPressurePuzzle.InkValve inkValve)
	{
		float num = 0f;
		float num2 = 1f;
		float num3 = ((inkValve.Direction >= 0) ? (-180f) : 180f);
		inkValve.Index += inkValve.Direction;
		float endValue = this.m_InkPositions[inkValve.Index];
		Sequence sequence = DOTween.Sequence();
		sequence.Insert(num, inkValve.Valve.transform.DOLocalRotate(new Vector3(num3, 0f, 0f), num2, RotateMode.LocalAxisAdd).SetEase(Ease.InOutQuad));
		num += num2 / 2f;
		sequence.InsertCallback(num, delegate
		{
			GameManager.Instance.AudioManager.Play(this.m_PuzzleInkRiseClip, AudioObjectType.SOUND_EFFECT, 0, false);
		});
		sequence.Insert(num, inkValve.Ink.DOScaleY(endValue, num2).SetEase(Ease.OutQuad));
		sequence.OnComplete(delegate
		{
			Vector3 localScale = inkValve.Ink.localScale;
			localScale.y = endValue;
			inkValve.Ink.localScale = localScale;
			if (!this.CheckStatus())
			{
				if (inkValve.Index <= 0)
				{
					inkValve.Direction = 1;
				}
				else if (inkValve.Index >= this.m_InkPositions.Length - 1)
				{
					inkValve.Direction = -1;
				}
				inkValve.Valve.SetActive(true);
				inkValve.Valve.OnInteracted += this.HandleValveOnInteracted;
			}
			else
			{
				this.DisableInteraction();
				this.m_Light.enabled = false;
				this.isComplete = true;
				GameManager.Instance.AudioManager.Play(this.m_PuzzleSolvedClip, AudioObjectType.SOUND_EFFECT, 0, false);
				this.m_Door.SetActive(true);
				this.m_Door.OnInteracted += this.HandleDoorOnInteracted;
			}
		});
	}

	// Token: 0x0600091E RID: 2334 RVA: 0x0004BFB8 File Offset: 0x0004A1B8
	private bool CheckStatus()
	{
		bool flag = true;
		for (int i = 0; i < this.m_InkValves.Count; i++)
		{
			if (this.m_InkValves[i].Index != 4)
			{
				flag = false;
			}
		}
		return flag;
	}

	// Token: 0x0600091F RID: 2335 RVA: 0x0004C000 File Offset: 0x0004A200
	private void HandleDoorOnInteracted(object sender, EventArgs e)
	{
		this.m_Door.OnInteracted -= this.HandleDoorOnInteracted;
		this.m_Door.SetActive(false);
		GameManager.Instance.AudioManager.Play(this.m_PuzzlePanelClip, AudioObjectType.SOUND_EFFECT, 0, false);
		this.m_Door.transform.DOLocalRotate(new Vector3(0f, 50f, 0f), 0.5f, RotateMode.LocalAxisAdd).SetEase(Ease.OutQuad).OnComplete(delegate
		{
			this.m_Collectable.SetActive(true);
			this.m_Collectable.OnInteracted += this.HandleCollectableOnInteracted;
		});
	}

	// Token: 0x06000920 RID: 2336 RVA: 0x0004C08C File Offset: 0x0004A28C
	private void HandleCollectableOnInteracted(object sender, EventArgs e)
	{
		this.m_Collectable.OnInteracted -= this.HandleCollectableOnInteracted;
		this.m_Collectable.Dispose();
		GameManager.Instance.AudioManager.Play(this.m_PowerCorePickupClip, AudioObjectType.SOUND_EFFECT, 0, false);
		this.m_SparkParticles.Emit(10);
		this.OnComplete.Send(this);
	}

	// Token: 0x06000921 RID: 2337 RVA: 0x0004C0F0 File Offset: 0x0004A2F0
	private AudioObject PlayAudio(ref AudioClip[] audioClips, bool is2D = false)
	{
		if (audioClips == null || audioClips.Length <= 0)
		{
			return null;
		}
		int num = global::UnityEngine.Random.Range(0, audioClips.Length);
		AudioClip audioClip = audioClips[num];
		AudioObject audioObject = GameManager.Instance.AudioManager.Play(audioClip, AudioObjectType.SOUND_EFFECT, 0, false);
		audioClips[num] = audioClips[0];
		audioClips[0] = audioClip;
		return audioObject;
	}

	// Token: 0x06000922 RID: 2338 RVA: 0x0004C144 File Offset: 0x0004A344
	public void ForceComplete()
	{
		this.DisableInteraction();
		if (this.m_Collectable)
		{
			this.m_Collectable.gameObject.SetActive(false);
		}
		this.m_Door.OnInteracted -= this.HandleDoorOnInteracted;
		this.m_Door.SetActive(false);
		this.m_Door.transform.localEulerAngles = new Vector3(0f, 50f, 0f);
		for (int i = 0; i < this.m_InkValves.Count; i++)
		{
			this.m_InkValves[i].Ink.localScale = new Vector3(1f, 0.5f, 1f);
		}
		this.isComplete = true;
		this.m_Light.enabled = false;
	}

	// Token: 0x06000923 RID: 2339 RVA: 0x000061D6 File Offset: 0x000043D6
	protected override void OnDisposed()
	{
		base.OnDisposed();
	}

	// Token: 0x04000763 RID: 1891
	private float[] m_InkPositions = new float[] { 0.1f, 0.2f, 0.3f, 0.4f, 0.5f, 0.6f, 0.7f, 0.8f, 0.9f, 1f };

	// Token: 0x04000765 RID: 1893
	[HideInInspector]
	public int ID;

	// Token: 0x04000766 RID: 1894
	[HideInInspector]
	public bool isComplete;

	// Token: 0x04000767 RID: 1895
	[SerializeField]
	private Light m_Light;

	// Token: 0x04000768 RID: 1896
	[SerializeField]
	private Interactable m_Door;

	// Token: 0x04000769 RID: 1897
	[SerializeField]
	private List<CH3InkPressurePuzzle.InkValve> m_InkValves;

	// Token: 0x0400076A RID: 1898
	[SerializeField]
	private Interactable m_Collectable;

	// Token: 0x0400076B RID: 1899
	[SerializeField]
	private ParticleSystem m_SparkParticles;

	// Token: 0x0400076C RID: 1900
	private AudioClip[] m_ValveClips;

	// Token: 0x0400076D RID: 1901
	private AudioClip m_PowerCorePickupClip;

	// Token: 0x0400076E RID: 1902
	private AudioClip m_PuzzlePanelClip;

	// Token: 0x0400076F RID: 1903
	private AudioClip m_PuzzleSolvedClip;

	// Token: 0x04000770 RID: 1904
	private AudioClip m_PuzzleInkRiseClip;

	// Token: 0x04000771 RID: 1905
	private bool m_HasSearcher;

	// Token: 0x020000E8 RID: 232
	[Serializable]
	public class InkValve
	{
		// Token: 0x04000772 RID: 1906
		public Transform Ink;

		// Token: 0x04000773 RID: 1907
		public Interactable Valve;

		// Token: 0x04000774 RID: 1908
		[HideInInspector]
		public int Direction;

		// Token: 0x04000775 RID: 1909
		[HideInInspector]
		public int Index;
	}
}
