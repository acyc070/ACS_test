using System;
using UnityEngine;
using UnityEngine.PostProcessing;

// Token: 0x02000598 RID: 1432
public class CameraDepthOfFieldDistanceSetter : MonoBehaviour
{
	// Token: 0x170003C3 RID: 963
	// (get) Token: 0x060027E8 RID: 10216 RVA: 0x0001C9A4 File Offset: 0x0001ABA4
	// (set) Token: 0x060027E9 RID: 10217 RVA: 0x0001C9AC File Offset: 0x0001ABAC
	public bool manualDOF
	{
		get
		{
			return this.m_manualDOF;
		}
		set
		{
			Debug.Log("<color=red>CDOFDS.manualDOF = " + value + "</color>", this);
			this.m_manualDOF = value;
		}
	}

	// Token: 0x060027EA RID: 10218 RVA: 0x000E7BF8 File Offset: 0x000E5DF8
	private void Start()
	{
		if (this.sampleSize < 1)
		{
			this.sampleSize = 1;
		}
		this.ppb = base.GetComponent<PostProcessingBehaviour>();
		if (!this.ppb)
		{
			Debug.LogError("Missing PostProcessingBehaviour...", this);
			return;
		}
		this.nonBobingTransform = base.transform.parent.parent;
		if (this.nonBobingTransform.gameObject.name != "HeadContainer")
		{
			Debug.LogError("Missing the non-bobbing parent 'HeadContainer'", this);
		}
	}

	// Token: 0x060027EB RID: 10219 RVA: 0x000E7C80 File Offset: 0x000E5E80
	private void Update()
	{
		if (!this.ppb.profile.depthOfField.enabled)
		{
			return;
		}
		if (!this.manualDOF)
		{
			float num = 0f;
			int num2 = 0;
			for (int i = 0; i < this.sampleSize; i++)
			{
				Vector3 vector = global::UnityEngine.Random.insideUnitSphere * this.sampleSizeMultiplier;
				if (Physics.Raycast(base.transform.position + vector, base.transform.forward, out this.raycastHit, 3.4028235E+38f, this.layerMask, QueryTriggerInteraction.Ignore) && !this.raycastHit.transform.gameObject.CompareTag("IgnoreDoF"))
				{
					num += this.raycastHit.distance;
					num2++;
				}
			}
			if (num2 == 0)
			{
				num = 1000f;
				num2 = 1;
			}
			this.focalDistance = Mathf.SmoothDamp(this.focalDistance, num / (float)num2, ref this.currentVelocity, this.smoothTime);
		}
		this.dofSettings = this.ppb.profile.depthOfField.settings;
		this.dofSettings.focusDistance = this.focalDistance;
		this.ppb.profile.depthOfField.settings = this.dofSettings;
	}

	// Token: 0x060027EC RID: 10220 RVA: 0x000E7DC8 File Offset: 0x000E5FC8
	private bool HasDepthChanged()
	{
		if (!Physics.Raycast(this.nonBobingTransform.position, this.nonBobingTransform.forward, out this.raycastHit, 3.4028235E+38f, this.layerMask, QueryTriggerInteraction.Ignore))
		{
			return true;
		}
		if (Mathf.Abs(this.previousDepth - this.raycastHit.distance) < this.dofDistanceUpdateThreshold)
		{
			return false;
		}
		this.previousDepth = this.raycastHit.distance;
		return true;
	}

	// Token: 0x04001FD7 RID: 8151
	public LayerMask layerMask;

	// Token: 0x04001FD8 RID: 8152
	[Tooltip("How fast does the Depth Of Field effect follow changes to the look distance.")]
	public float smoothTime = 0.5f;

	// Token: 0x04001FD9 RID: 8153
	[Tooltip("How many samples per frame do we take to get the look distance.")]
	public int sampleSize = 5;

	// Token: 0x04001FDA RID: 8154
	[Tooltip("How big is the sample area for the look distance.")]
	public float sampleSizeMultiplier = 1f;

	// Token: 0x04001FDB RID: 8155
	protected bool m_manualDOF;

	// Token: 0x04001FDC RID: 8156
	public float focalDistance;

	// Token: 0x04001FDD RID: 8157
	[SerializeField]
	private float dofDistanceUpdateThreshold = 0.01f;

	// Token: 0x04001FDE RID: 8158
	[Header("Debugging")]
	[SerializeField]
	private bool showRaycasts;

	// Token: 0x04001FDF RID: 8159
	private PostProcessingBehaviour ppb;

	// Token: 0x04001FE0 RID: 8160
	private DepthOfFieldModel.Settings dofSettings;

	// Token: 0x04001FE1 RID: 8161
	private RaycastHit raycastHit;

	// Token: 0x04001FE2 RID: 8162
	private float currentVelocity;

	// Token: 0x04001FE3 RID: 8163
	private Vector3 previousPosition;

	// Token: 0x04001FE4 RID: 8164
	private Quaternion previousRotation;

	// Token: 0x04001FE5 RID: 8165
	[SerializeField]
	private float previousDepth;

	// Token: 0x04001FE6 RID: 8166
	private Transform nonBobingTransform;

	// Token: 0x04001FE7 RID: 8167
	private const string IGNOREDOF = "IgnoreDoF";
}
