using System;
using UnityEngine;

namespace TMG.Core
{
	// Token: 0x020001ED RID: 493
	public class TMGMonoBehaviour : MonoBehaviour, IDisposable
	{
		// Token: 0x17000120 RID: 288
		// (get) Token: 0x0600149A RID: 5274 RVA: 0x00010E83 File Offset: 0x0000F083
		// (set) Token: 0x0600149B RID: 5275 RVA: 0x00010E8B File Offset: 0x0000F08B
		public bool IsDisposed { get; private set; }

		// Token: 0x17000121 RID: 289
		// (get) Token: 0x0600149C RID: 5276 RVA: 0x00010E94 File Offset: 0x0000F094
		// (set) Token: 0x0600149D RID: 5277 RVA: 0x00010E9C File Offset: 0x0000F09C
		public bool IsDestroyed { get; private set; }

		// Token: 0x0600149E RID: 5278 RVA: 0x00010EA5 File Offset: 0x0000F0A5
		public void Awake()
		{
			if (this.m_IsAwake)
			{
				return;
			}
			this.Init();
			this.m_IsAwake = true;
		}

		// Token: 0x0600149F RID: 5279 RVA: 0x00010EC0 File Offset: 0x0000F0C0
		public void Start()
		{
			if (this.m_IsStart)
			{
				return;
			}
			this.InitOnComplete();
			this.m_IsStart = true;
		}

		// Token: 0x060014A0 RID: 5280 RVA: 0x00002482 File Offset: 0x00000682
		public virtual void Init()
		{
		}

		// Token: 0x060014A1 RID: 5281 RVA: 0x00002482 File Offset: 0x00000682
		public virtual void InitOnComplete()
		{
		}

		// Token: 0x060014A2 RID: 5282 RVA: 0x00002482 File Offset: 0x00000682
		public virtual void OnEnable()
		{
		}

		// Token: 0x060014A3 RID: 5283 RVA: 0x00002482 File Offset: 0x00000682
		public virtual void OnDisable()
		{
		}

		// Token: 0x060014A4 RID: 5284 RVA: 0x00002482 File Offset: 0x00000682
		protected virtual void OnDisposed()
		{
		}

		// Token: 0x17000122 RID: 290
		// (get) Token: 0x060014A5 RID: 5285 RVA: 0x00010EDB File Offset: 0x0000F0DB
		public new Transform transform
		{
			get
			{
				if (!this.m_Transform)
				{
					this.m_Transform = base.transform;
				}
				return this.m_Transform;
			}
		}

		// Token: 0x17000123 RID: 291
		// (get) Token: 0x060014A6 RID: 5286 RVA: 0x00010EFF File Offset: 0x0000F0FF
		public new GameObject gameObject
		{
			get
			{
				if (!this.m_GameObject)
				{
					this.m_GameObject = base.gameObject;
				}
				return this.m_GameObject;
			}
		}

		// Token: 0x060014A7 RID: 5287 RVA: 0x00010F23 File Offset: 0x0000F123
		public void SetParentAndAlign(Transform parent)
		{
			this.transform.SetParent(parent);
			this.transform.localPosition = Vector3.zero;
			this.transform.localEulerAngles = Vector3.zero;
		}

		// Token: 0x060014A8 RID: 5288 RVA: 0x00010F51 File Offset: 0x0000F151
		public void SetParentAndAlignWithScale(Transform parent)
		{
			this.SetParentAndAlign(parent);
			this.transform.localScale = Vector3.one;
		}

		// Token: 0x060014A9 RID: 5289 RVA: 0x00002482 File Offset: 0x00000682
		protected void DebugLog(string message)
		{
		}

		// Token: 0x060014AA RID: 5290 RVA: 0x0007ABE8 File Offset: 0x00078DE8
		public void Dispose()
		{
			if (this.IsDisposed)
			{
				return;
			}
			this.OnDisposed();
			this.IsDisposed = true;
			GC.SuppressFinalize(this);
			if (!this.IsDestroyed)
			{
				this.IsDestroyed = true;
				if (this.m_IsComponent)
				{
					global::UnityEngine.Object.Destroy(this);
				}
				else
				{
					global::UnityEngine.Object.Destroy(this.gameObject);
				}
			}
		}

		// Token: 0x060014AB RID: 5291 RVA: 0x00010F6A File Offset: 0x0000F16A
		public void OnDestroy()
		{
			if (!this.IsDestroyed)
			{
				this.IsDestroyed = true;
				this.Dispose();
			}
		}

		// Token: 0x0400101D RID: 4125
		protected bool m_IsAwake;

		// Token: 0x0400101E RID: 4126
		protected bool m_IsStart;

		// Token: 0x0400101F RID: 4127
		protected bool m_IsComponent;

		// Token: 0x04001020 RID: 4128
		private Transform m_Transform;

		// Token: 0x04001021 RID: 4129
		private GameObject m_GameObject;
	}
}
