using System;
using TMG.Core;
using UnityEngine;

// Token: 0x02000189 RID: 393
[Serializable]
public class CameraMovements : TMGAbstractDisposable
{
	// Token: 0x06000FC5 RID: 4037 RVA: 0x0006A27C File Offset: 0x0006847C
	public void Init(Transform parent, Transform cameraContainer)
	{
		if (!this.m_Active)
		{
			return;
		}
		this.m_ActualCamera = cameraContainer;
		this.m_OriginalRotation = this.m_ActualCamera.localRotation;
		this.m_Target = new GameObject("Forward Camera Target").transform;
		this.m_Target.SetParent(parent);
		this.m_Target.localPosition = Vector3.forward;
		this.m_Target.localEulerAngles = Vector3.zero;
	}

	// Token: 0x06000FC6 RID: 4038 RVA: 0x0006A2F0 File Offset: 0x000684F0
	public void Sway(Transform cameraContainer)
	{
		this.m_ActualCamera.localRotation = this.m_OriginalRotation;
		if (!this.m_Active || !GameManager.Instance.PlayerSettings.ViewSwaying)
		{
			return;
		}
		Vector3 vector = cameraContainer.InverseTransformPoint(this.m_Target.position);
		float num = Mathf.Atan2(vector.x, vector.z) * 57.29578f;
		num = Mathf.Clamp(num, -10.5f, 10.5f);
		this.m_ActualCamera.localRotation = this.m_OriginalRotation * Quaternion.Euler(0f, num, 0f);
		vector = cameraContainer.InverseTransformPoint(this.m_Target.position);
		float num2 = Mathf.Atan2(vector.y, vector.z) * 57.29578f;
		num2 = Mathf.Clamp(num2, -10.5f, 10.5f);
		Vector3 vector2 = new Vector3(this.m_FollowAngles.x + Mathf.DeltaAngle(this.m_FollowAngles.x, num2), this.m_FollowAngles.y + Mathf.DeltaAngle(this.m_FollowAngles.y, num));
		this.m_FollowAngles = Vector3.SmoothDamp(this.m_FollowAngles, vector2, ref this.m_FollowVelocity, this.m_FollowSpeed);
		this.m_ActualCamera.localRotation = this.m_OriginalRotation * Quaternion.Euler(-this.m_FollowAngles.x, this.m_FollowAngles.y, 0f);
		float num3 = Mathf.PerlinNoise(0f, Time.time * this.m_SwaySpeed) - 0.5f;
		float num4 = Mathf.PerlinNoise(0f, Time.time * this.m_SwaySpeed + 100f) - 0.5f;
		num3 *= this.m_BaseSwayAmount;
		num4 *= this.m_BaseSwayAmount;
		float num5 = Mathf.PerlinNoise(0f, Time.time * this.m_SwaySpeed) - 0.5f + this.m_TrackingBias;
		float num6 = Mathf.PerlinNoise(0f, Time.time * this.m_SwaySpeed + 100f) - 0.5f + this.m_TrackingBias;
		num5 *= -this.m_TrackingSwayAmount * this.m_FollowVelocity.x;
		num6 *= this.m_TrackingSwayAmount * this.m_FollowVelocity.y;
		float num7 = num3 + num5;
		float num8 = num4 + num6;
		this.m_ActualCamera.Rotate(num7, num8, -num8 * 0.5f);
	}

	// Token: 0x06000FC7 RID: 4039 RVA: 0x0000D789 File Offset: 0x0000B989
	protected override void OnDisposed()
	{
		this.m_ActualCamera = null;
		this.m_Target = null;
		base.OnDisposed();
	}

	// Token: 0x04000CF6 RID: 3318
	[SerializeField]
	private bool m_Active = true;

	// Token: 0x04000CF7 RID: 3319
	[SerializeField]
	private float m_SwaySpeed = 0.6f;

	// Token: 0x04000CF8 RID: 3320
	[SerializeField]
	private float m_BaseSwayAmount = 1.5f;

	// Token: 0x04000CF9 RID: 3321
	[SerializeField]
	private float m_TrackingSwayAmount = 1.5f;

	// Token: 0x04000CFA RID: 3322
	[SerializeField]
	private float m_TrackingBias;

	// Token: 0x04000CFB RID: 3323
	[SerializeField]
	private float m_FollowSpeed = 1f;

	// Token: 0x04000CFC RID: 3324
	private Transform m_ActualCamera;

	// Token: 0x04000CFD RID: 3325
	private Transform m_Target;

	// Token: 0x04000CFE RID: 3326
	private Quaternion m_OriginalRotation;

	// Token: 0x04000CFF RID: 3327
	private Vector3 m_FollowVelocity;

	// Token: 0x04000D00 RID: 3328
	private Vector3 m_FollowAngles;

	// Token: 0x04000D01 RID: 3329
	private Vector2 m_RotationRange;
}
