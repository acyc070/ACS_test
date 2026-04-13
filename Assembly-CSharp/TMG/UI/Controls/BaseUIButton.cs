using System;
using System.Diagnostics;
using TMG.Core;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace TMG.UI.Controls
{
	// Token: 0x020002B7 RID: 695
	[RequireComponent(typeof(Button))]
	public class BaseUIButton : TMGMonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, ISelectHandler, IDeselectHandler, IPointerEnterHandler, IPointerExitHandler, IEventSystemHandler
	{
		// Token: 0x140000AF RID: 175
		// (add) Token: 0x06001A1C RID: 6684 RVA: 0x0008D7D8 File Offset: 0x0008B9D8
		// (remove) Token: 0x06001A1D RID: 6685 RVA: 0x0008D810 File Offset: 0x0008BA10
		[field: DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event EventHandler OnDown;

		// Token: 0x140000B0 RID: 176
		// (add) Token: 0x06001A1E RID: 6686 RVA: 0x0008D848 File Offset: 0x0008BA48
		// (remove) Token: 0x06001A1F RID: 6687 RVA: 0x0008D880 File Offset: 0x0008BA80
		[field: DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event EventHandler OnUp;

		// Token: 0x140000B1 RID: 177
		// (add) Token: 0x06001A20 RID: 6688 RVA: 0x0008D8B8 File Offset: 0x0008BAB8
		// (remove) Token: 0x06001A21 RID: 6689 RVA: 0x0008D8F0 File Offset: 0x0008BAF0
		[field: DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event EventHandler OnClick;

		// Token: 0x140000B2 RID: 178
		// (add) Token: 0x06001A22 RID: 6690 RVA: 0x0008D928 File Offset: 0x0008BB28
		// (remove) Token: 0x06001A23 RID: 6691 RVA: 0x0008D960 File Offset: 0x0008BB60
		[field: DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event EventHandler OnSelected;

		// Token: 0x140000B3 RID: 179
		// (add) Token: 0x06001A24 RID: 6692 RVA: 0x0008D998 File Offset: 0x0008BB98
		// (remove) Token: 0x06001A25 RID: 6693 RVA: 0x0008D9D0 File Offset: 0x0008BBD0
		[field: DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event EventHandler OnDeselected;

		// Token: 0x140000B4 RID: 180
		// (add) Token: 0x06001A26 RID: 6694 RVA: 0x0008DA08 File Offset: 0x0008BC08
		// (remove) Token: 0x06001A27 RID: 6695 RVA: 0x0008DA40 File Offset: 0x0008BC40
		[field: DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event EventHandler OnEnter;

		// Token: 0x140000B5 RID: 181
		// (add) Token: 0x06001A28 RID: 6696 RVA: 0x0008DA78 File Offset: 0x0008BC78
		// (remove) Token: 0x06001A29 RID: 6697 RVA: 0x0008DAB0 File Offset: 0x0008BCB0
		[field: DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event EventHandler OnExit;

		// Token: 0x170001A1 RID: 417
		// (get) Token: 0x06001A2A RID: 6698 RVA: 0x000150A7 File Offset: 0x000132A7
		public Button Button
		{
			get
			{
				if (this.m_Button == null)
				{
					this.m_Button = base.GetComponent<Button>();
				}
				return this.m_Button;
			}
		}

		// Token: 0x06001A2B RID: 6699 RVA: 0x0008DAE8 File Offset: 0x0008BCE8
		public override void Init()
		{
			base.Init();
			if (this.m_HasImageSwap)
			{
				if (this.m_ImageActive)
				{
					this.m_ImageActive.SetActive(true);
				}
				if (this.m_ImageHighlight)
				{
					this.m_ImageHighlight.SetActive(false);
				}
			}
			if (this.m_HasImageBG && this.m_ImageBG)
			{
				this.m_ImageBG.SetActive(false);
			}
		}

		// Token: 0x06001A2C RID: 6700 RVA: 0x0008DB68 File Offset: 0x0008BD68
		public override void OnDisable()
		{
			if (this.m_HasImageSwap)
			{
				if (this.m_ImageActive)
				{
					this.m_ImageActive.SetActive(true);
				}
				if (this.m_ImageHighlight)
				{
					this.m_ImageHighlight.SetActive(false);
				}
			}
			if (this.m_HasImageBG && this.m_ImageBG)
			{
				this.m_ImageBG.SetActive(false);
			}
		}

		// Token: 0x06001A2D RID: 6701 RVA: 0x000150CC File Offset: 0x000132CC
		public void OnPointerDown(PointerEventData eventData)
		{
			if (!this.Button.interactable)
			{
				return;
			}
			this.OnDown.Send(this);
		}

		// Token: 0x06001A2E RID: 6702 RVA: 0x000150EB File Offset: 0x000132EB
		public void OnPointerUp(PointerEventData eventData)
		{
			if (!this.Button.interactable)
			{
				return;
			}
			this.OnUp.Send(this);
		}

		// Token: 0x06001A2F RID: 6703 RVA: 0x0001510A File Offset: 0x0001330A
		public virtual void OnPointerClick(PointerEventData eventData)
		{
			if (!this.Button.interactable)
			{
				return;
			}
			this.OnClick.Send(this);
		}

		// Token: 0x06001A30 RID: 6704 RVA: 0x00015129 File Offset: 0x00013329
		public void OnSelect(BaseEventData eventData)
		{
			if (!this.Button.interactable)
			{
				return;
			}
			this.OnSelected.Send(this);
		}

		// Token: 0x06001A31 RID: 6705 RVA: 0x00015148 File Offset: 0x00013348
		public void OnDeselect(BaseEventData eventData)
		{
			if (!this.Button.interactable)
			{
				return;
			}
			this.OnDeselected.Send(this);
		}

		// Token: 0x06001A32 RID: 6706 RVA: 0x0008DBE0 File Offset: 0x0008BDE0
		public void OnPointerEnter(PointerEventData eventData)
		{
			if (!this.Button.interactable)
			{
				return;
			}
			if (this.m_HasImageSwap)
			{
				if (this.m_ImageActive)
				{
					this.m_ImageActive.SetActive(false);
				}
				if (this.m_ImageHighlight)
				{
					this.m_ImageHighlight.SetActive(true);
				}
			}
			if (this.m_HasImageBG && this.m_ImageBG)
			{
				this.m_ImageBG.SetActive(true);
			}
			this.OnEnter.Send(this);
		}

		// Token: 0x06001A33 RID: 6707 RVA: 0x0008DC74 File Offset: 0x0008BE74
		public void OnPointerExit(PointerEventData eventData)
		{
			if (!this.Button.interactable)
			{
				return;
			}
			if (this.m_HasImageSwap)
			{
				if (this.m_ImageActive)
				{
					this.m_ImageActive.SetActive(true);
				}
				if (this.m_ImageHighlight)
				{
					this.m_ImageHighlight.SetActive(false);
				}
			}
			if (this.m_HasImageBG && this.m_ImageBG)
			{
				this.m_ImageBG.SetActive(false);
			}
			this.OnExit.Send(this);
		}

		// Token: 0x06001A34 RID: 6708 RVA: 0x00015167 File Offset: 0x00013367
		protected override void OnDisposed()
		{
			this.OnDown = null;
			this.OnUp = null;
			this.OnClick = null;
			this.OnSelected = null;
			this.OnDeselected = null;
			base.OnDisposed();
		}

		// Token: 0x04001703 RID: 5891
		[Header("Image Swap")]
		[SerializeField]
		private bool m_HasImageSwap;

		// Token: 0x04001704 RID: 5892
		[SerializeField]
		private GameObject m_ImageActive;

		// Token: 0x04001705 RID: 5893
		[SerializeField]
		private GameObject m_ImageHighlight;

		// Token: 0x04001706 RID: 5894
		[Header("Image BG")]
		[SerializeField]
		private bool m_HasImageBG;

		// Token: 0x04001707 RID: 5895
		[SerializeField]
		private GameObject m_ImageBG;

		// Token: 0x04001708 RID: 5896
		private Button m_Button;
	}
}
