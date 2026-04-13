using System;
using System.Diagnostics;
using TMG.Core;
using UnityEngine;

namespace TMG.UI
{
	// Token: 0x0200028A RID: 650
	public class BaseUIController : TMGMonoBehaviour
	{
		// Token: 0x140000A9 RID: 169
		// (add) Token: 0x0600189F RID: 6303 RVA: 0x00087280 File Offset: 0x00085480
		// (remove) Token: 0x060018A0 RID: 6304 RVA: 0x000872B8 File Offset: 0x000854B8
		[field: DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event EventHandler OnPlayInComplete;

		// Token: 0x140000AA RID: 170
		// (add) Token: 0x060018A1 RID: 6305 RVA: 0x000872F0 File Offset: 0x000854F0
		// (remove) Token: 0x060018A2 RID: 6306 RVA: 0x00087328 File Offset: 0x00085528
		[field: DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event EventHandler OnPlayOutComplete;

		// Token: 0x17000191 RID: 401
		// (get) Token: 0x060018A3 RID: 6307 RVA: 0x00013DEC File Offset: 0x00011FEC
		public RectTransform rectTransform
		{
			get
			{
				if (this.m_RectTransform == null)
				{
					this.m_RectTransform = base.GetComponent<RectTransform>();
				}
				return this.m_RectTransform;
			}
		}

		// Token: 0x060018A4 RID: 6308 RVA: 0x00087360 File Offset: 0x00085560
		public virtual void InitController(object _data)
		{
			Canvas component = base.GetComponent<Canvas>();
			Camera camera = GameManager.Instance.UIManager.Camera;
			component.worldCamera = camera;
			component.pixelPerfect = false;
			component.planeDistance = Math.Abs(component.transform.parent.position.z - camera.transform.position.z);
			component.sortingOrder = (int)(-(int)component.planeDistance);
		}

		// Token: 0x060018A5 RID: 6309 RVA: 0x00013E11 File Offset: 0x00012011
		public virtual void PlayIn()
		{
			this.PlayInComplete();
		}

		// Token: 0x060018A6 RID: 6310 RVA: 0x00013E19 File Offset: 0x00012019
		public virtual void PlayInComplete()
		{
			this.OnPlayInComplete.Send(this);
		}

		// Token: 0x060018A7 RID: 6311 RVA: 0x00013E27 File Offset: 0x00012027
		public void Kill()
		{
			this.PlayOut();
		}

		// Token: 0x060018A8 RID: 6312 RVA: 0x00013E2F File Offset: 0x0001202F
		public virtual void PlayOut()
		{
			this.PlayOutComplete();
		}

		// Token: 0x060018A9 RID: 6313 RVA: 0x00013E37 File Offset: 0x00012037
		public virtual void PlayOutComplete()
		{
			this.OnPlayOutComplete.Send(this);
			base.Dispose();
		}

		// Token: 0x040015A5 RID: 5541
		private RectTransform m_RectTransform;
	}
}
