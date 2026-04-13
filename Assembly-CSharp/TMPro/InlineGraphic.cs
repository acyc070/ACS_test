using System;
using UnityEngine;
using UnityEngine.UI;

namespace TMPro
{
	// Token: 0x020005E2 RID: 1506
	public class InlineGraphic : MaskableGraphic
	{
		// Token: 0x17000409 RID: 1033
		// (get) Token: 0x0600296B RID: 10603 RVA: 0x0001DAB6 File Offset: 0x0001BCB6
		public override Texture mainTexture
		{
			get
			{
				if (this.texture == null)
				{
					return Graphic.s_WhiteTexture;
				}
				return this.texture;
			}
		}

		// Token: 0x0600296C RID: 10604 RVA: 0x0001DAD5 File Offset: 0x0001BCD5
		protected override void Awake()
		{
			this.m_manager = base.GetComponentInParent<InlineGraphicManager>();
		}

		// Token: 0x0600296D RID: 10605 RVA: 0x000ED518 File Offset: 0x000EB718
		protected override void OnEnable()
		{
			if (this.m_RectTransform == null)
			{
				this.m_RectTransform = base.gameObject.GetComponent<RectTransform>();
			}
			if (this.m_manager != null && this.m_manager.spriteAsset != null)
			{
				this.texture = this.m_manager.spriteAsset.spriteSheet;
			}
		}

		// Token: 0x0600296E RID: 10606 RVA: 0x0001DAE3 File Offset: 0x0001BCE3
		protected override void OnDisable()
		{
			base.OnDisable();
		}

		// Token: 0x0600296F RID: 10607 RVA: 0x00002482 File Offset: 0x00000682
		protected override void OnTransformParentChanged()
		{
		}

		// Token: 0x06002970 RID: 10608 RVA: 0x000ED584 File Offset: 0x000EB784
		protected override void OnRectTransformDimensionsChange()
		{
			if (this.m_RectTransform == null)
			{
				this.m_RectTransform = base.gameObject.GetComponent<RectTransform>();
			}
			if (this.m_ParentRectTransform == null)
			{
				this.m_ParentRectTransform = this.m_RectTransform.parent.GetComponent<RectTransform>();
			}
			if (this.m_RectTransform.pivot != this.m_ParentRectTransform.pivot)
			{
				this.m_RectTransform.pivot = this.m_ParentRectTransform.pivot;
			}
		}

		// Token: 0x06002971 RID: 10609 RVA: 0x0001DAEB File Offset: 0x0001BCEB
		public new void UpdateMaterial()
		{
			base.UpdateMaterial();
		}

		// Token: 0x06002972 RID: 10610 RVA: 0x00002482 File Offset: 0x00000682
		protected override void UpdateGeometry()
		{
		}

		// Token: 0x04002E8B RID: 11915
		public Texture texture;

		// Token: 0x04002E8C RID: 11916
		private InlineGraphicManager m_manager;

		// Token: 0x04002E8D RID: 11917
		private RectTransform m_RectTransform;

		// Token: 0x04002E8E RID: 11918
		private RectTransform m_ParentRectTransform;
	}
}
