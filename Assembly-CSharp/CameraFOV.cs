using System;
using DG.Tweening;
using TMG.Core;
using UnityEngine;

// Token: 0x02000188 RID: 392
[Serializable]
public class CameraFOV : TMGAbstractDisposable
{
	// Token: 0x06000FBD RID: 4029 RVA: 0x0000D6F4 File Offset: 0x0000B8F4
	public void Init(params Camera[] cameras)
	{
		this.m_Cameras = cameras;
		this.SetFOV(GameManager.Instance.PlayerSettings.FoV);
		DOTween.useSmoothDeltaTime = true;
		DOTween.defaultUpdateType = UpdateType.Normal;
	}

	// Token: 0x06000FBE RID: 4030 RVA: 0x0000D71E File Offset: 0x0000B91E
	public void UpdateVOD(float magnitude, float speed, bool isRunning)
	{
		this.SetFOV(GameManager.Instance.PlayerSettings.FoV);
	}

	// Token: 0x06000FBF RID: 4031 RVA: 0x0006A240 File Offset: 0x00068440
	public void SetFOV(float value)
	{
		for (int i = 0; i < this.m_Cameras.Length; i++)
		{
			this.m_Cameras[i].fieldOfView = GameManager.Instance.PlayerSettings.FoV;
		}
	}

	// Token: 0x06000FC0 RID: 4032 RVA: 0x00002482 File Offset: 0x00000682
	public void DOFov(float value, float duration)
	{
	}

	// Token: 0x06000FC1 RID: 4033 RVA: 0x00002482 File Offset: 0x00000682
	public void SetActiveFOV(bool active)
	{
	}

	// Token: 0x170000B0 RID: 176
	// (get) Token: 0x06000FC2 RID: 4034 RVA: 0x0000D735 File Offset: 0x0000B935
	public float FOV
	{
		get
		{
			return GameManager.Instance.PlayerSettings.FoV;
		}
	}

	// Token: 0x06000FC3 RID: 4035 RVA: 0x0000D746 File Offset: 0x0000B946
	protected override void OnDisposed()
	{
		base.OnDisposed();
	}

	// Token: 0x04000CF0 RID: 3312
	[SerializeField]
	private bool m_Active = true;

	// Token: 0x04000CF1 RID: 3313
	[SerializeField]
	private float m_BaseFOV = 55f;

	// Token: 0x04000CF2 RID: 3314
	[SerializeField]
	private float m_RunFOV = 70f;

	// Token: 0x04000CF3 RID: 3315
	[SerializeField]
	private float m_TransitionSpeed = 0.2f;

	// Token: 0x04000CF4 RID: 3316
	private Camera[] m_Cameras;

	// Token: 0x04000CF5 RID: 3317
	private float FoVChanged;
}
