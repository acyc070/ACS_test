using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TMPro
{
	// Token: 0x020005E9 RID: 1513
	[ExecuteInEditMode]
	[RequireComponent(typeof(RectTransform))]
	[AddComponentMenu("Layout/Text Container")]
	public class TextContainer : UIBehaviour
	{
		// Token: 0x1700040F RID: 1039
		// (get) Token: 0x060029A3 RID: 10659 RVA: 0x0001DD53 File Offset: 0x0001BF53
		// (set) Token: 0x060029A4 RID: 10660 RVA: 0x0001DD5B File Offset: 0x0001BF5B
		public bool hasChanged
		{
			get
			{
				return this.m_hasChanged;
			}
			set
			{
				this.m_hasChanged = value;
			}
		}

		// Token: 0x17000410 RID: 1040
		// (get) Token: 0x060029A5 RID: 10661 RVA: 0x0001DD64 File Offset: 0x0001BF64
		// (set) Token: 0x060029A6 RID: 10662 RVA: 0x0001DD6C File Offset: 0x0001BF6C
		public Vector2 pivot
		{
			get
			{
				return this.m_pivot;
			}
			set
			{
				if (this.m_pivot != value)
				{
					this.m_pivot = value;
					this.m_anchorPosition = this.GetAnchorPosition(this.m_pivot);
					this.m_hasChanged = true;
					this.OnContainerChanged();
				}
			}
		}

		// Token: 0x17000411 RID: 1041
		// (get) Token: 0x060029A7 RID: 10663 RVA: 0x0001DDA5 File Offset: 0x0001BFA5
		// (set) Token: 0x060029A8 RID: 10664 RVA: 0x0001DDAD File Offset: 0x0001BFAD
		public TextContainerAnchors anchorPosition
		{
			get
			{
				return this.m_anchorPosition;
			}
			set
			{
				if (this.m_anchorPosition != value)
				{
					this.m_anchorPosition = value;
					this.m_pivot = this.GetPivot(this.m_anchorPosition);
					this.m_hasChanged = true;
					this.OnContainerChanged();
				}
			}
		}

		// Token: 0x17000412 RID: 1042
		// (get) Token: 0x060029A9 RID: 10665 RVA: 0x0001DDE1 File Offset: 0x0001BFE1
		// (set) Token: 0x060029AA RID: 10666 RVA: 0x0001DDE9 File Offset: 0x0001BFE9
		public Rect rect
		{
			get
			{
				return this.m_rect;
			}
			set
			{
				if (this.m_rect != value)
				{
					this.m_rect = value;
					this.m_hasChanged = true;
					this.OnContainerChanged();
				}
			}
		}

		// Token: 0x17000413 RID: 1043
		// (get) Token: 0x060029AB RID: 10667 RVA: 0x0001DE10 File Offset: 0x0001C010
		// (set) Token: 0x060029AC RID: 10668 RVA: 0x000EDC64 File Offset: 0x000EBE64
		public Vector2 size
		{
			get
			{
				return new Vector2(this.m_rect.width, this.m_rect.height);
			}
			set
			{
				if (new Vector2(this.m_rect.width, this.m_rect.height) != value)
				{
					this.SetRect(value);
					this.m_hasChanged = true;
					this.m_isDefaultWidth = false;
					this.m_isDefaultHeight = false;
					this.OnContainerChanged();
				}
			}
		}

		// Token: 0x17000414 RID: 1044
		// (get) Token: 0x060029AD RID: 10669 RVA: 0x0001DE2D File Offset: 0x0001C02D
		// (set) Token: 0x060029AE RID: 10670 RVA: 0x0001DE3A File Offset: 0x0001C03A
		public float width
		{
			get
			{
				return this.m_rect.width;
			}
			set
			{
				this.SetRect(new Vector2(value, this.m_rect.height));
				this.m_hasChanged = true;
				this.m_isDefaultWidth = false;
				this.OnContainerChanged();
			}
		}

		// Token: 0x17000415 RID: 1045
		// (get) Token: 0x060029AF RID: 10671 RVA: 0x0001DE67 File Offset: 0x0001C067
		// (set) Token: 0x060029B0 RID: 10672 RVA: 0x0001DE74 File Offset: 0x0001C074
		public float height
		{
			get
			{
				return this.m_rect.height;
			}
			set
			{
				this.SetRect(new Vector2(this.m_rect.width, value));
				this.m_hasChanged = true;
				this.m_isDefaultHeight = false;
				this.OnContainerChanged();
			}
		}

		// Token: 0x17000416 RID: 1046
		// (get) Token: 0x060029B1 RID: 10673 RVA: 0x0001DEA1 File Offset: 0x0001C0A1
		public bool isDefaultWidth
		{
			get
			{
				return this.m_isDefaultWidth;
			}
		}

		// Token: 0x17000417 RID: 1047
		// (get) Token: 0x060029B2 RID: 10674 RVA: 0x0001DEA9 File Offset: 0x0001C0A9
		public bool isDefaultHeight
		{
			get
			{
				return this.m_isDefaultHeight;
			}
		}

		// Token: 0x17000418 RID: 1048
		// (get) Token: 0x060029B3 RID: 10675 RVA: 0x0001DEB1 File Offset: 0x0001C0B1
		// (set) Token: 0x060029B4 RID: 10676 RVA: 0x0001DEB9 File Offset: 0x0001C0B9
		public bool isAutoFitting
		{
			get
			{
				return this.m_isAutoFitting;
			}
			set
			{
				this.m_isAutoFitting = value;
			}
		}

		// Token: 0x17000419 RID: 1049
		// (get) Token: 0x060029B5 RID: 10677 RVA: 0x0001DEC2 File Offset: 0x0001C0C2
		public Vector3[] corners
		{
			get
			{
				return this.m_corners;
			}
		}

		// Token: 0x1700041A RID: 1050
		// (get) Token: 0x060029B6 RID: 10678 RVA: 0x0001DECA File Offset: 0x0001C0CA
		public Vector3[] worldCorners
		{
			get
			{
				return this.m_worldCorners;
			}
		}

		// Token: 0x1700041B RID: 1051
		// (get) Token: 0x060029B7 RID: 10679 RVA: 0x0001DED2 File Offset: 0x0001C0D2
		// (set) Token: 0x060029B8 RID: 10680 RVA: 0x0001DEDA File Offset: 0x0001C0DA
		public Vector4 margins
		{
			get
			{
				return this.m_margins;
			}
			set
			{
				if (this.m_margins != value)
				{
					this.m_margins = value;
					this.m_hasChanged = true;
					this.OnContainerChanged();
				}
			}
		}

		// Token: 0x1700041C RID: 1052
		// (get) Token: 0x060029B9 RID: 10681 RVA: 0x0001DF01 File Offset: 0x0001C101
		public RectTransform rectTransform
		{
			get
			{
				if (this.m_rectTransform == null)
				{
					this.m_rectTransform = base.GetComponent<RectTransform>();
				}
				return this.m_rectTransform;
			}
		}

		// Token: 0x1700041D RID: 1053
		// (get) Token: 0x060029BA RID: 10682 RVA: 0x0001DF26 File Offset: 0x0001C126
		public TextMeshPro textMeshPro
		{
			get
			{
				if (this.m_textMeshPro == null)
				{
					this.m_textMeshPro = base.GetComponent<TextMeshPro>();
				}
				return this.m_textMeshPro;
			}
		}

		// Token: 0x060029BB RID: 10683 RVA: 0x000EDCBC File Offset: 0x000EBEBC
		protected override void Awake()
		{
			this.m_rectTransform = this.rectTransform;
			if (this.m_rectTransform == null)
			{
				Vector2 pivot = this.m_pivot;
				this.m_rectTransform = base.gameObject.AddComponent<RectTransform>();
				this.m_pivot = pivot;
			}
			this.m_textMeshPro = base.GetComponent(typeof(TextMeshPro)) as TextMeshPro;
			if (this.m_rect.width == 0f || this.m_rect.height == 0f)
			{
				if (this.m_textMeshPro != null && this.m_textMeshPro.anchor != TMP_Compatibility.AnchorPositions.None)
				{
					Debug.LogWarning("Converting from using anchor and lineLength properties to Text Container.", this);
					this.m_isDefaultHeight = true;
					int num = (int)this.m_textMeshPro.anchor;
					this.m_textMeshPro.anchor = TMP_Compatibility.AnchorPositions.None;
					if (num == 9)
					{
						switch (this.m_textMeshPro.alignment)
						{
						case TextAlignmentOptions.TopLeft:
							this.m_textMeshPro.alignment = TextAlignmentOptions.BaselineLeft;
							break;
						case TextAlignmentOptions.Top:
							this.m_textMeshPro.alignment = TextAlignmentOptions.Baseline;
							break;
						case TextAlignmentOptions.TopRight:
							this.m_textMeshPro.alignment = TextAlignmentOptions.BaselineRight;
							break;
						case TextAlignmentOptions.TopJustified:
							this.m_textMeshPro.alignment = TextAlignmentOptions.BaselineJustified;
							break;
						}
						num = 3;
					}
					this.m_anchorPosition = (TextContainerAnchors)num;
					this.m_pivot = this.GetPivot(this.m_anchorPosition);
					if (this.m_textMeshPro.lineLength == 72f)
					{
						this.m_rect.size = this.m_textMeshPro.GetPreferredValues(this.m_textMeshPro.text);
					}
					else
					{
						this.m_rect.width = this.m_textMeshPro.lineLength;
						this.m_rect.height = this.m_textMeshPro.GetPreferredValues(this.m_rect.width, float.PositiveInfinity).y;
					}
				}
				else
				{
					this.m_isDefaultWidth = true;
					this.m_isDefaultHeight = true;
					this.m_pivot = this.GetPivot(this.m_anchorPosition);
					this.m_rect.width = 20f;
					this.m_rect.height = 5f;
					this.m_rectTransform.sizeDelta = this.size;
				}
				this.m_margins = new Vector4(0f, 0f, 0f, 0f);
				this.UpdateCorners();
			}
		}

		// Token: 0x060029BC RID: 10684 RVA: 0x0001DF4B File Offset: 0x0001C14B
		protected override void OnEnable()
		{
			this.OnContainerChanged();
		}

		// Token: 0x060029BD RID: 10685 RVA: 0x00002482 File Offset: 0x00000682
		protected override void OnDisable()
		{
		}

		// Token: 0x060029BE RID: 10686 RVA: 0x000EDF24 File Offset: 0x000EC124
		private void OnContainerChanged()
		{
			this.UpdateCorners();
			if (this.m_rectTransform != null)
			{
				this.m_rectTransform.sizeDelta = this.size;
				this.m_rectTransform.hasChanged = true;
			}
			if (this.textMeshPro != null)
			{
				this.m_textMeshPro.SetVerticesDirty();
				this.m_textMeshPro.margin = this.m_margins;
			}
		}

		// Token: 0x060029BF RID: 10687 RVA: 0x000EDF94 File Offset: 0x000EC194
		protected override void OnRectTransformDimensionsChange()
		{
			if (this.rectTransform == null)
			{
				this.m_rectTransform = base.gameObject.AddComponent<RectTransform>();
			}
			if (this.m_rectTransform.sizeDelta != TextContainer.k_defaultSize)
			{
				this.size = this.m_rectTransform.sizeDelta;
			}
			this.pivot = this.m_rectTransform.pivot;
			this.m_hasChanged = true;
			this.OnContainerChanged();
		}

		// Token: 0x060029C0 RID: 10688 RVA: 0x0001DF53 File Offset: 0x0001C153
		private void SetRect(Vector2 size)
		{
			this.m_rect = new Rect(this.m_rect.x, this.m_rect.y, size.x, size.y);
		}

		// Token: 0x060029C1 RID: 10689 RVA: 0x000EE00C File Offset: 0x000EC20C
		private void UpdateCorners()
		{
			this.m_corners[0] = new Vector3(-this.m_pivot.x * this.m_rect.width, -this.m_pivot.y * this.m_rect.height);
			this.m_corners[1] = new Vector3(-this.m_pivot.x * this.m_rect.width, (1f - this.m_pivot.y) * this.m_rect.height);
			this.m_corners[2] = new Vector3((1f - this.m_pivot.x) * this.m_rect.width, (1f - this.m_pivot.y) * this.m_rect.height);
			this.m_corners[3] = new Vector3((1f - this.m_pivot.x) * this.m_rect.width, -this.m_pivot.y * this.m_rect.height);
			if (this.m_rectTransform != null)
			{
				this.m_rectTransform.pivot = this.m_pivot;
			}
		}

		// Token: 0x060029C2 RID: 10690 RVA: 0x000EE168 File Offset: 0x000EC368
		private Vector2 GetPivot(TextContainerAnchors anchor)
		{
			Vector2 zero = Vector2.zero;
			switch (anchor)
			{
			case TextContainerAnchors.TopLeft:
				zero = new Vector2(0f, 1f);
				break;
			case TextContainerAnchors.Top:
				zero = new Vector2(0.5f, 1f);
				break;
			case TextContainerAnchors.TopRight:
				zero = new Vector2(1f, 1f);
				break;
			case TextContainerAnchors.Left:
				zero = new Vector2(0f, 0.5f);
				break;
			case TextContainerAnchors.Middle:
				zero = new Vector2(0.5f, 0.5f);
				break;
			case TextContainerAnchors.Right:
				zero = new Vector2(1f, 0.5f);
				break;
			case TextContainerAnchors.BottomLeft:
				zero = new Vector2(0f, 0f);
				break;
			case TextContainerAnchors.Bottom:
				zero = new Vector2(0.5f, 0f);
				break;
			case TextContainerAnchors.BottomRight:
				zero = new Vector2(1f, 0f);
				break;
			}
			return zero;
		}

		// Token: 0x060029C3 RID: 10691 RVA: 0x000EE274 File Offset: 0x000EC474
		private TextContainerAnchors GetAnchorPosition(Vector2 pivot)
		{
			if (pivot == new Vector2(0f, 1f))
			{
				return TextContainerAnchors.TopLeft;
			}
			if (pivot == new Vector2(0.5f, 1f))
			{
				return TextContainerAnchors.Top;
			}
			if (pivot == new Vector2(1f, 1f))
			{
				return TextContainerAnchors.TopRight;
			}
			if (pivot == new Vector2(0f, 0.5f))
			{
				return TextContainerAnchors.Left;
			}
			if (pivot == new Vector2(0.5f, 0.5f))
			{
				return TextContainerAnchors.Middle;
			}
			if (pivot == new Vector2(1f, 0.5f))
			{
				return TextContainerAnchors.Right;
			}
			if (pivot == new Vector2(0f, 0f))
			{
				return TextContainerAnchors.BottomLeft;
			}
			if (pivot == new Vector2(0.5f, 0f))
			{
				return TextContainerAnchors.Bottom;
			}
			if (pivot == new Vector2(1f, 0f))
			{
				return TextContainerAnchors.BottomRight;
			}
			return TextContainerAnchors.Custom;
		}

		// Token: 0x04002EB0 RID: 11952
		private bool m_hasChanged;

		// Token: 0x04002EB1 RID: 11953
		[SerializeField]
		private Vector2 m_pivot;

		// Token: 0x04002EB2 RID: 11954
		[SerializeField]
		private TextContainerAnchors m_anchorPosition = TextContainerAnchors.Middle;

		// Token: 0x04002EB3 RID: 11955
		[SerializeField]
		private Rect m_rect;

		// Token: 0x04002EB4 RID: 11956
		private bool m_isDefaultWidth;

		// Token: 0x04002EB5 RID: 11957
		private bool m_isDefaultHeight;

		// Token: 0x04002EB6 RID: 11958
		private bool m_isAutoFitting;

		// Token: 0x04002EB7 RID: 11959
		private Vector3[] m_corners = new Vector3[4];

		// Token: 0x04002EB8 RID: 11960
		private Vector3[] m_worldCorners = new Vector3[4];

		// Token: 0x04002EB9 RID: 11961
		[SerializeField]
		private Vector4 m_margins;

		// Token: 0x04002EBA RID: 11962
		private RectTransform m_rectTransform;

		// Token: 0x04002EBB RID: 11963
		private static Vector2 k_defaultSize = new Vector2(100f, 100f);

		// Token: 0x04002EBC RID: 11964
		private TextMeshPro m_textMeshPro;
	}
}
