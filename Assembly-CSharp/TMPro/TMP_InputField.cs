using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace TMPro
{
	// Token: 0x02000604 RID: 1540
	[AddComponentMenu("UI/TextMeshPro - Input Field", 11)]
	public class TMP_InputField : Selectable, IUpdateSelectedHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler, ISubmitHandler, ICanvasElement, IEventSystemHandler
	{
		// Token: 0x06002AF0 RID: 10992 RVA: 0x00101CB8 File Offset: 0x000FFEB8
		protected TMP_InputField()
		{
		}

		// Token: 0x17000452 RID: 1106
		// (get) Token: 0x06002AF1 RID: 10993 RVA: 0x0001EAF0 File Offset: 0x0001CCF0
		protected Mesh mesh
		{
			get
			{
				if (this.m_Mesh == null)
				{
					this.m_Mesh = new Mesh();
				}
				return this.m_Mesh;
			}
		}

		// Token: 0x17000453 RID: 1107
		// (get) Token: 0x06002AF3 RID: 10995 RVA: 0x00101D78 File Offset: 0x000FFF78
		// (set) Token: 0x06002AF2 RID: 10994 RVA: 0x0001EB14 File Offset: 0x0001CD14
		public bool shouldHideMobileInput
		{
			get
			{
				RuntimePlatform platform = Application.platform;
				return (platform != RuntimePlatform.Android && platform != RuntimePlatform.IPhonePlayer) || this.m_HideMobileInput;
			}
			set
			{
				SetPropertyUtility.SetStruct<bool>(ref this.m_HideMobileInput, value);
			}
		}

		// Token: 0x17000454 RID: 1108
		// (get) Token: 0x06002AF4 RID: 10996 RVA: 0x0001EB23 File Offset: 0x0001CD23
		// (set) Token: 0x06002AF5 RID: 10997 RVA: 0x00101DA8 File Offset: 0x000FFFA8
		public string text
		{
			get
			{
				return this.m_Text;
			}
			set
			{
				if (this.text == value)
				{
					return;
				}
				this.m_Text = value;
				if (this.m_Keyboard != null)
				{
					this.m_Keyboard.text = this.m_Text;
				}
				if (this.m_StringPosition > this.m_Text.Length)
				{
					this.m_StringPosition = (this.m_StringSelectPosition = this.m_Text.Length);
				}
				this.SendOnValueChangedAndUpdateLabel();
			}
		}

		// Token: 0x17000455 RID: 1109
		// (get) Token: 0x06002AF6 RID: 10998 RVA: 0x0001EB2B File Offset: 0x0001CD2B
		public bool isFocused
		{
			get
			{
				return this.m_AllowInput;
			}
		}

		// Token: 0x17000456 RID: 1110
		// (get) Token: 0x06002AF7 RID: 10999 RVA: 0x0001EB33 File Offset: 0x0001CD33
		// (set) Token: 0x06002AF8 RID: 11000 RVA: 0x0001EB3B File Offset: 0x0001CD3B
		public float caretBlinkRate
		{
			get
			{
				return this.m_CaretBlinkRate;
			}
			set
			{
				if (SetPropertyUtility.SetStruct<float>(ref this.m_CaretBlinkRate, value) && this.m_AllowInput)
				{
					this.SetCaretActive();
				}
			}
		}

		// Token: 0x17000457 RID: 1111
		// (get) Token: 0x06002AF9 RID: 11001 RVA: 0x0001EB5F File Offset: 0x0001CD5F
		// (set) Token: 0x06002AFA RID: 11002 RVA: 0x0001EB67 File Offset: 0x0001CD67
		public int caretWidth
		{
			get
			{
				return this.m_CaretWidth;
			}
			set
			{
				if (SetPropertyUtility.SetStruct<int>(ref this.m_CaretWidth, value))
				{
					this.MarkGeometryAsDirty();
				}
			}
		}

		// Token: 0x17000458 RID: 1112
		// (get) Token: 0x06002AFB RID: 11003 RVA: 0x0001EB80 File Offset: 0x0001CD80
		// (set) Token: 0x06002AFC RID: 11004 RVA: 0x0001EB88 File Offset: 0x0001CD88
		public RectTransform textViewport
		{
			get
			{
				return this.m_TextViewport;
			}
			set
			{
				SetPropertyUtility.SetClass<RectTransform>(ref this.m_TextViewport, value);
			}
		}

		// Token: 0x17000459 RID: 1113
		// (get) Token: 0x06002AFD RID: 11005 RVA: 0x0001EB97 File Offset: 0x0001CD97
		// (set) Token: 0x06002AFE RID: 11006 RVA: 0x0001EB9F File Offset: 0x0001CD9F
		public TMP_Text textComponent
		{
			get
			{
				return this.m_TextComponent;
			}
			set
			{
				SetPropertyUtility.SetClass<TMP_Text>(ref this.m_TextComponent, value);
			}
		}

		// Token: 0x1700045A RID: 1114
		// (get) Token: 0x06002AFF RID: 11007 RVA: 0x0001EBAE File Offset: 0x0001CDAE
		// (set) Token: 0x06002B00 RID: 11008 RVA: 0x0001EBB6 File Offset: 0x0001CDB6
		public Graphic placeholder
		{
			get
			{
				return this.m_Placeholder;
			}
			set
			{
				SetPropertyUtility.SetClass<Graphic>(ref this.m_Placeholder, value);
			}
		}

		// Token: 0x1700045B RID: 1115
		// (get) Token: 0x06002B01 RID: 11009 RVA: 0x0001EBC5 File Offset: 0x0001CDC5
		// (set) Token: 0x06002B02 RID: 11010 RVA: 0x0001EBE8 File Offset: 0x0001CDE8
		public Color caretColor
		{
			get
			{
				return (!this.customCaretColor) ? this.textComponent.color : this.m_CaretColor;
			}
			set
			{
				if (SetPropertyUtility.SetColor(ref this.m_CaretColor, value))
				{
					this.MarkGeometryAsDirty();
				}
			}
		}

		// Token: 0x1700045C RID: 1116
		// (get) Token: 0x06002B03 RID: 11011 RVA: 0x0001EC01 File Offset: 0x0001CE01
		// (set) Token: 0x06002B04 RID: 11012 RVA: 0x0001EC09 File Offset: 0x0001CE09
		public bool customCaretColor
		{
			get
			{
				return this.m_CustomCaretColor;
			}
			set
			{
				if (this.m_CustomCaretColor != value)
				{
					this.m_CustomCaretColor = value;
					this.MarkGeometryAsDirty();
				}
			}
		}

		// Token: 0x1700045D RID: 1117
		// (get) Token: 0x06002B05 RID: 11013 RVA: 0x0001EC24 File Offset: 0x0001CE24
		// (set) Token: 0x06002B06 RID: 11014 RVA: 0x0001EC2C File Offset: 0x0001CE2C
		public Color selectionColor
		{
			get
			{
				return this.m_SelectionColor;
			}
			set
			{
				if (SetPropertyUtility.SetColor(ref this.m_SelectionColor, value))
				{
					this.MarkGeometryAsDirty();
				}
			}
		}

		// Token: 0x1700045E RID: 1118
		// (get) Token: 0x06002B07 RID: 11015 RVA: 0x0001EC45 File Offset: 0x0001CE45
		// (set) Token: 0x06002B08 RID: 11016 RVA: 0x0001EC4D File Offset: 0x0001CE4D
		public TMP_InputField.SubmitEvent onEndEdit
		{
			get
			{
				return this.m_OnEndEdit;
			}
			set
			{
				SetPropertyUtility.SetClass<TMP_InputField.SubmitEvent>(ref this.m_OnEndEdit, value);
			}
		}

		// Token: 0x1700045F RID: 1119
		// (get) Token: 0x06002B09 RID: 11017 RVA: 0x0001EC5C File Offset: 0x0001CE5C
		// (set) Token: 0x06002B0A RID: 11018 RVA: 0x0001EC64 File Offset: 0x0001CE64
		public TMP_InputField.SubmitEvent onSubmit
		{
			get
			{
				return this.m_OnSubmit;
			}
			set
			{
				SetPropertyUtility.SetClass<TMP_InputField.SubmitEvent>(ref this.m_OnSubmit, value);
			}
		}

		// Token: 0x17000460 RID: 1120
		// (get) Token: 0x06002B0B RID: 11019 RVA: 0x0001EC73 File Offset: 0x0001CE73
		// (set) Token: 0x06002B0C RID: 11020 RVA: 0x0001EC7B File Offset: 0x0001CE7B
		public TMP_InputField.SubmitEvent onFocusLost
		{
			get
			{
				return this.m_OnFocusLost;
			}
			set
			{
				SetPropertyUtility.SetClass<TMP_InputField.SubmitEvent>(ref this.m_OnFocusLost, value);
			}
		}

		// Token: 0x17000461 RID: 1121
		// (get) Token: 0x06002B0D RID: 11021 RVA: 0x0001EC8A File Offset: 0x0001CE8A
		// (set) Token: 0x06002B0E RID: 11022 RVA: 0x0001EC92 File Offset: 0x0001CE92
		public TMP_InputField.OnChangeEvent onValueChanged
		{
			get
			{
				return this.m_OnValueChanged;
			}
			set
			{
				SetPropertyUtility.SetClass<TMP_InputField.OnChangeEvent>(ref this.m_OnValueChanged, value);
			}
		}

		// Token: 0x17000462 RID: 1122
		// (get) Token: 0x06002B0F RID: 11023 RVA: 0x0001ECA1 File Offset: 0x0001CEA1
		// (set) Token: 0x06002B10 RID: 11024 RVA: 0x0001ECA9 File Offset: 0x0001CEA9
		public TMP_InputField.OnValidateInput onValidateInput
		{
			get
			{
				return this.m_OnValidateInput;
			}
			set
			{
				SetPropertyUtility.SetClass<TMP_InputField.OnValidateInput>(ref this.m_OnValidateInput, value);
			}
		}

		// Token: 0x17000463 RID: 1123
		// (get) Token: 0x06002B11 RID: 11025 RVA: 0x0001ECB8 File Offset: 0x0001CEB8
		// (set) Token: 0x06002B12 RID: 11026 RVA: 0x0001ECC0 File Offset: 0x0001CEC0
		public int characterLimit
		{
			get
			{
				return this.m_CharacterLimit;
			}
			set
			{
				if (SetPropertyUtility.SetStruct<int>(ref this.m_CharacterLimit, Math.Max(0, value)))
				{
					this.UpdateLabel();
				}
			}
		}

		// Token: 0x17000464 RID: 1124
		// (get) Token: 0x06002B13 RID: 11027 RVA: 0x0001ECDF File Offset: 0x0001CEDF
		// (set) Token: 0x06002B14 RID: 11028 RVA: 0x0001ECE7 File Offset: 0x0001CEE7
		public TMP_InputField.ContentType contentType
		{
			get
			{
				return this.m_ContentType;
			}
			set
			{
				if (SetPropertyUtility.SetStruct<TMP_InputField.ContentType>(ref this.m_ContentType, value))
				{
					this.EnforceContentType();
				}
			}
		}

		// Token: 0x17000465 RID: 1125
		// (get) Token: 0x06002B15 RID: 11029 RVA: 0x0001ED00 File Offset: 0x0001CF00
		// (set) Token: 0x06002B16 RID: 11030 RVA: 0x0001ED08 File Offset: 0x0001CF08
		public TMP_InputField.LineType lineType
		{
			get
			{
				return this.m_LineType;
			}
			set
			{
				if (SetPropertyUtility.SetStruct<TMP_InputField.LineType>(ref this.m_LineType, value))
				{
					this.SetTextComponentWrapMode();
				}
				this.SetToCustomIfContentTypeIsNot(new TMP_InputField.ContentType[]
				{
					TMP_InputField.ContentType.Standard,
					TMP_InputField.ContentType.Autocorrected
				});
			}
		}

		// Token: 0x17000466 RID: 1126
		// (get) Token: 0x06002B17 RID: 11031 RVA: 0x0001ED31 File Offset: 0x0001CF31
		// (set) Token: 0x06002B18 RID: 11032 RVA: 0x0001ED39 File Offset: 0x0001CF39
		public TMP_InputField.InputType inputType
		{
			get
			{
				return this.m_InputType;
			}
			set
			{
				if (SetPropertyUtility.SetStruct<TMP_InputField.InputType>(ref this.m_InputType, value))
				{
					this.SetToCustom();
				}
			}
		}

		// Token: 0x17000467 RID: 1127
		// (get) Token: 0x06002B19 RID: 11033 RVA: 0x0001ED52 File Offset: 0x0001CF52
		// (set) Token: 0x06002B1A RID: 11034 RVA: 0x0001ED5A File Offset: 0x0001CF5A
		public TouchScreenKeyboardType keyboardType
		{
			get
			{
				return this.m_KeyboardType;
			}
			set
			{
				if (SetPropertyUtility.SetStruct<TouchScreenKeyboardType>(ref this.m_KeyboardType, value))
				{
					this.SetToCustom();
				}
			}
		}

		// Token: 0x17000468 RID: 1128
		// (get) Token: 0x06002B1B RID: 11035 RVA: 0x0001ED73 File Offset: 0x0001CF73
		// (set) Token: 0x06002B1C RID: 11036 RVA: 0x0001ED7B File Offset: 0x0001CF7B
		public TMP_InputField.CharacterValidation characterValidation
		{
			get
			{
				return this.m_CharacterValidation;
			}
			set
			{
				if (SetPropertyUtility.SetStruct<TMP_InputField.CharacterValidation>(ref this.m_CharacterValidation, value))
				{
					this.SetToCustom();
				}
			}
		}

		// Token: 0x17000469 RID: 1129
		// (get) Token: 0x06002B1D RID: 11037 RVA: 0x0001ED94 File Offset: 0x0001CF94
		// (set) Token: 0x06002B1E RID: 11038 RVA: 0x0001ED9C File Offset: 0x0001CF9C
		public bool readOnly
		{
			get
			{
				return this.m_ReadOnly;
			}
			set
			{
				this.m_ReadOnly = value;
			}
		}

		// Token: 0x1700046A RID: 1130
		// (get) Token: 0x06002B1F RID: 11039 RVA: 0x0001EDA5 File Offset: 0x0001CFA5
		// (set) Token: 0x06002B20 RID: 11040 RVA: 0x0001EDAD File Offset: 0x0001CFAD
		public bool richText
		{
			get
			{
				return this.m_RichText;
			}
			set
			{
				this.m_RichText = value;
				this.SetTextComponentRichTextMode();
			}
		}

		// Token: 0x1700046B RID: 1131
		// (get) Token: 0x06002B21 RID: 11041 RVA: 0x0001EDBC File Offset: 0x0001CFBC
		public bool multiLine
		{
			get
			{
				return this.m_LineType == TMP_InputField.LineType.MultiLineNewline || this.lineType == TMP_InputField.LineType.MultiLineSubmit;
			}
		}

		// Token: 0x1700046C RID: 1132
		// (get) Token: 0x06002B22 RID: 11042 RVA: 0x0001EDD6 File Offset: 0x0001CFD6
		// (set) Token: 0x06002B23 RID: 11043 RVA: 0x0001EDDE File Offset: 0x0001CFDE
		public char asteriskChar
		{
			get
			{
				return this.m_AsteriskChar;
			}
			set
			{
				if (SetPropertyUtility.SetStruct<char>(ref this.m_AsteriskChar, value))
				{
					this.UpdateLabel();
				}
			}
		}

		// Token: 0x1700046D RID: 1133
		// (get) Token: 0x06002B24 RID: 11044 RVA: 0x0001EDF7 File Offset: 0x0001CFF7
		public bool wasCanceled
		{
			get
			{
				return this.m_WasCanceled;
			}
		}

		// Token: 0x06002B25 RID: 11045 RVA: 0x0001EDFF File Offset: 0x0001CFFF
		protected void ClampPos(ref int pos)
		{
			if (pos < 0)
			{
				pos = 0;
			}
			else if (pos > this.text.Length)
			{
				pos = this.text.Length;
			}
		}

		// Token: 0x1700046E RID: 1134
		// (get) Token: 0x06002B26 RID: 11046 RVA: 0x0001EE30 File Offset: 0x0001D030
		// (set) Token: 0x06002B27 RID: 11047 RVA: 0x0001EE43 File Offset: 0x0001D043
		protected int caretPositionInternal
		{
			get
			{
				return this.m_CaretPosition + Input.compositionString.Length;
			}
			set
			{
				this.m_CaretPosition = value;
				this.ClampPos(ref this.m_CaretPosition);
			}
		}

		// Token: 0x1700046F RID: 1135
		// (get) Token: 0x06002B28 RID: 11048 RVA: 0x0001EE58 File Offset: 0x0001D058
		// (set) Token: 0x06002B29 RID: 11049 RVA: 0x0001EE6B File Offset: 0x0001D06B
		protected int stringPositionInternal
		{
			get
			{
				return this.m_StringPosition + Input.compositionString.Length;
			}
			set
			{
				this.m_StringPosition = value;
				this.ClampPos(ref this.m_StringPosition);
			}
		}

		// Token: 0x17000470 RID: 1136
		// (get) Token: 0x06002B2A RID: 11050 RVA: 0x0001EE80 File Offset: 0x0001D080
		// (set) Token: 0x06002B2B RID: 11051 RVA: 0x0001EE93 File Offset: 0x0001D093
		protected int caretSelectPositionInternal
		{
			get
			{
				return this.m_CaretSelectPosition + Input.compositionString.Length;
			}
			set
			{
				this.m_CaretSelectPosition = value;
				this.ClampPos(ref this.m_CaretSelectPosition);
			}
		}

		// Token: 0x17000471 RID: 1137
		// (get) Token: 0x06002B2C RID: 11052 RVA: 0x0001EEA8 File Offset: 0x0001D0A8
		// (set) Token: 0x06002B2D RID: 11053 RVA: 0x0001EEBB File Offset: 0x0001D0BB
		protected int stringSelectPositionInternal
		{
			get
			{
				return this.m_StringSelectPosition + Input.compositionString.Length;
			}
			set
			{
				this.m_StringSelectPosition = value;
				this.ClampPos(ref this.m_StringSelectPosition);
			}
		}

		// Token: 0x17000472 RID: 1138
		// (get) Token: 0x06002B2E RID: 11054 RVA: 0x0001EED0 File Offset: 0x0001D0D0
		private bool hasSelection
		{
			get
			{
				return this.stringPositionInternal != this.stringSelectPositionInternal;
			}
		}

		// Token: 0x17000473 RID: 1139
		// (get) Token: 0x06002B2F RID: 11055 RVA: 0x0001EEA8 File Offset: 0x0001D0A8
		// (set) Token: 0x06002B30 RID: 11056 RVA: 0x0001EEE3 File Offset: 0x0001D0E3
		public int caretPosition
		{
			get
			{
				return this.m_StringSelectPosition + Input.compositionString.Length;
			}
			set
			{
				this.selectionAnchorPosition = value;
				this.selectionFocusPosition = value;
			}
		}

		// Token: 0x17000474 RID: 1140
		// (get) Token: 0x06002B31 RID: 11057 RVA: 0x0001EEF3 File Offset: 0x0001D0F3
		// (set) Token: 0x06002B32 RID: 11058 RVA: 0x0001EF18 File Offset: 0x0001D118
		public int selectionAnchorPosition
		{
			get
			{
				this.m_StringPosition = this.GetStringIndexFromCaretPosition(this.m_CaretPosition);
				return this.m_StringPosition + Input.compositionString.Length;
			}
			set
			{
				if (Input.compositionString.Length != 0)
				{
					return;
				}
				this.m_CaretPosition = value;
				this.ClampPos(ref this.m_CaretPosition);
			}
		}

		// Token: 0x17000475 RID: 1141
		// (get) Token: 0x06002B33 RID: 11059 RVA: 0x0001EF3D File Offset: 0x0001D13D
		// (set) Token: 0x06002B34 RID: 11060 RVA: 0x0001EF62 File Offset: 0x0001D162
		public int selectionFocusPosition
		{
			get
			{
				this.m_StringSelectPosition = this.GetStringIndexFromCaretPosition(this.m_CaretSelectPosition);
				return this.m_StringSelectPosition + Input.compositionString.Length;
			}
			set
			{
				if (Input.compositionString.Length != 0)
				{
					return;
				}
				this.m_CaretSelectPosition = value;
				this.ClampPos(ref this.m_CaretSelectPosition);
			}
		}

		// Token: 0x06002B35 RID: 11061 RVA: 0x00101E20 File Offset: 0x00100020
		protected override void OnEnable()
		{
			base.OnEnable();
			if (this.m_Text == null)
			{
				this.m_Text = string.Empty;
			}
			this.m_DrawStart = 0;
			this.m_DrawEnd = this.m_Text.Length;
			if (this.m_CachedInputRenderer != null)
			{
				this.m_CachedInputRenderer.SetMaterial(Graphic.defaultGraphicMaterial, Texture2D.whiteTexture);
			}
			if (this.m_TextComponent != null)
			{
				this.m_TextComponent.RegisterDirtyVerticesCallback(new UnityAction(this.MarkGeometryAsDirty));
				this.m_TextComponent.RegisterDirtyVerticesCallback(new UnityAction(this.UpdateLabel));
				this.UpdateLabel();
			}
		}

		// Token: 0x06002B36 RID: 11062 RVA: 0x00101ECC File Offset: 0x001000CC
		protected override void OnDisable()
		{
			this.m_BlinkCoroutine = null;
			this.DeactivateInputField();
			if (this.m_TextComponent != null)
			{
				this.m_TextComponent.UnregisterDirtyVerticesCallback(new UnityAction(this.MarkGeometryAsDirty));
				this.m_TextComponent.UnregisterDirtyVerticesCallback(new UnityAction(this.UpdateLabel));
			}
			CanvasUpdateRegistry.UnRegisterCanvasElementForRebuild(this);
			if (this.m_CachedInputRenderer != null)
			{
				this.m_CachedInputRenderer.Clear();
			}
			if (this.m_Mesh != null)
			{
				global::UnityEngine.Object.DestroyImmediate(this.m_Mesh);
			}
			this.m_Mesh = null;
			base.OnDisable();
		}

		// Token: 0x06002B37 RID: 11063 RVA: 0x00101F70 File Offset: 0x00100170
		private IEnumerator CaretBlink()
		{
			this.m_CaretVisible = true;
			yield return null;
			while (this.isFocused && this.m_CaretBlinkRate > 0f)
			{
				float blinkPeriod = 1f / this.m_CaretBlinkRate;
				bool blinkState = (Time.unscaledTime - this.m_BlinkStartTime) % blinkPeriod < blinkPeriod / 2f;
				if (this.m_CaretVisible != blinkState)
				{
					this.m_CaretVisible = blinkState;
					if (!this.hasSelection)
					{
						this.MarkGeometryAsDirty();
					}
				}
				yield return null;
			}
			this.m_BlinkCoroutine = null;
			yield break;
		}

		// Token: 0x06002B38 RID: 11064 RVA: 0x0001EF87 File Offset: 0x0001D187
		private void SetCaretVisible()
		{
			if (!this.m_AllowInput)
			{
				return;
			}
			this.m_CaretVisible = true;
			this.m_BlinkStartTime = Time.unscaledTime;
			this.SetCaretActive();
		}

		// Token: 0x06002B39 RID: 11065 RVA: 0x00101F8C File Offset: 0x0010018C
		private void SetCaretActive()
		{
			if (!this.m_AllowInput)
			{
				return;
			}
			if (this.m_CaretBlinkRate > 0f)
			{
				if (this.m_BlinkCoroutine == null)
				{
					this.m_BlinkCoroutine = base.StartCoroutine(this.CaretBlink());
				}
			}
			else
			{
				this.m_CaretVisible = true;
			}
		}

		// Token: 0x06002B3A RID: 11066 RVA: 0x0001EFAD File Offset: 0x0001D1AD
		protected void OnFocus()
		{
			this.SelectAll();
		}

		// Token: 0x06002B3B RID: 11067 RVA: 0x0001EFB5 File Offset: 0x0001D1B5
		protected void SelectAll()
		{
			this.stringPositionInternal = this.text.Length;
			this.stringSelectPositionInternal = 0;
		}

		// Token: 0x06002B3C RID: 11068 RVA: 0x00101FE0 File Offset: 0x001001E0
		public void MoveTextEnd(bool shift)
		{
			int length = this.text.Length;
			if (shift)
			{
				this.stringSelectPositionInternal = length;
			}
			else
			{
				this.stringPositionInternal = length;
				this.stringSelectPositionInternal = this.stringPositionInternal;
			}
			this.UpdateLabel();
		}

		// Token: 0x06002B3D RID: 11069 RVA: 0x00102024 File Offset: 0x00100224
		public void MoveTextStart(bool shift)
		{
			int num = 0;
			if (shift)
			{
				this.stringSelectPositionInternal = num;
			}
			else
			{
				this.stringPositionInternal = num;
				this.stringSelectPositionInternal = this.stringPositionInternal;
			}
			this.UpdateLabel();
		}

		// Token: 0x17000476 RID: 1142
		// (get) Token: 0x06002B3E RID: 11070 RVA: 0x0001EFCF File Offset: 0x0001D1CF
		// (set) Token: 0x06002B3F RID: 11071 RVA: 0x0001EFD6 File Offset: 0x0001D1D6
		private static string clipboard
		{
			get
			{
				return GUIUtility.systemCopyBuffer;
			}
			set
			{
				GUIUtility.systemCopyBuffer = value;
			}
		}

		// Token: 0x06002B40 RID: 11072 RVA: 0x0001EFDE File Offset: 0x0001D1DE
		private bool InPlaceEditing()
		{
			return !TouchScreenKeyboard.isSupported;
		}

		// Token: 0x06002B41 RID: 11073 RVA: 0x00102060 File Offset: 0x00100260
		protected virtual void LateUpdate()
		{
			if (this.m_ShouldActivateNextUpdate)
			{
				if (!this.isFocused)
				{
					this.ActivateInputFieldInternal();
					this.m_ShouldActivateNextUpdate = false;
					return;
				}
				this.m_ShouldActivateNextUpdate = false;
			}
			if (this.InPlaceEditing() || !this.isFocused)
			{
				return;
			}
			this.AssignPositioningIfNeeded();
			if (this.m_Keyboard == null || !this.m_Keyboard.active)
			{
				if (this.m_Keyboard != null)
				{
					if (!this.m_ReadOnly)
					{
						this.text = this.m_Keyboard.text;
					}
					if (this.m_Keyboard.status == TouchScreenKeyboard.Status.Canceled)
					{
						this.m_WasCanceled = true;
					}
				}
				this.OnDeselect(null);
				return;
			}
			string text = this.m_Keyboard.text;
			if (this.m_Text != text)
			{
				if (this.m_ReadOnly)
				{
					this.m_Keyboard.text = this.m_Text;
				}
				else
				{
					this.m_Text = string.Empty;
					foreach (char c in text)
					{
						if (c == '\r' || c == '\u0003')
						{
							c = '\n';
						}
						if (this.onValidateInput != null)
						{
							c = this.onValidateInput(this.m_Text, this.m_Text.Length, c);
						}
						else if (this.characterValidation != TMP_InputField.CharacterValidation.None)
						{
							c = this.Validate(this.m_Text, this.m_Text.Length, c);
						}
						if (this.lineType == TMP_InputField.LineType.MultiLineSubmit && c == '\n')
						{
							this.m_Keyboard.text = this.m_Text;
							this.OnDeselect(null);
							return;
						}
						if (c != '\0')
						{
							this.m_Text += c;
						}
					}
					if (this.characterLimit > 0 && this.m_Text.Length > this.characterLimit)
					{
						this.m_Text = this.m_Text.Substring(0, this.characterLimit);
					}
					int length = this.m_Text.Length;
					this.stringSelectPositionInternal = length;
					this.stringPositionInternal = length;
					if (this.m_Text != text)
					{
						this.m_Keyboard.text = this.m_Text;
					}
					this.SendOnValueChangedAndUpdateLabel();
				}
			}
			if (this.m_Keyboard.status == TouchScreenKeyboard.Status.Done)
			{
				if (this.m_Keyboard.status == TouchScreenKeyboard.Status.Canceled)
				{
					this.m_WasCanceled = true;
				}
				this.OnDeselect(null);
			}
		}

		// Token: 0x06002B42 RID: 11074 RVA: 0x0000D270 File Offset: 0x0000B470
		protected int GetCharacterIndexFromPosition(Vector2 pos)
		{
			return 0;
		}

		// Token: 0x06002B43 RID: 11075 RVA: 0x0001EFE8 File Offset: 0x0001D1E8
		private bool MayDrag(PointerEventData eventData)
		{
			return this.IsActive() && this.IsInteractable() && eventData.button == PointerEventData.InputButton.Left && this.m_TextComponent != null && this.m_Keyboard == null;
		}

		// Token: 0x06002B44 RID: 11076 RVA: 0x0001F028 File Offset: 0x0001D228
		public virtual void OnBeginDrag(PointerEventData eventData)
		{
			if (!this.MayDrag(eventData))
			{
				return;
			}
			this.m_UpdateDrag = true;
		}

		// Token: 0x06002B45 RID: 11077 RVA: 0x001022DC File Offset: 0x001004DC
		public virtual void OnDrag(PointerEventData eventData)
		{
			if (!this.MayDrag(eventData))
			{
				return;
			}
			CaretPosition caretPosition;
			int cursorIndexFromPosition = TMP_TextUtilities.GetCursorIndexFromPosition(this.m_TextComponent, eventData.position, eventData.pressEventCamera, out caretPosition);
			if (caretPosition == CaretPosition.Left)
			{
				this.stringSelectPositionInternal = this.GetStringIndexFromCaretPosition(cursorIndexFromPosition);
			}
			else if (caretPosition == CaretPosition.Right)
			{
				this.stringSelectPositionInternal = this.GetStringIndexFromCaretPosition(cursorIndexFromPosition) + 1;
			}
			this.caretSelectPositionInternal = this.GetCaretPositionFromStringIndex(this.stringSelectPositionInternal);
			this.MarkGeometryAsDirty();
			this.m_DragPositionOutOfBounds = !RectTransformUtility.RectangleContainsScreenPoint(this.textViewport, eventData.position, eventData.pressEventCamera);
			if (this.m_DragPositionOutOfBounds && this.m_DragCoroutine == null)
			{
				this.m_DragCoroutine = base.StartCoroutine(this.MouseDragOutsideRect(eventData));
			}
			eventData.Use();
		}

		// Token: 0x06002B46 RID: 11078 RVA: 0x001023AC File Offset: 0x001005AC
		private IEnumerator MouseDragOutsideRect(PointerEventData eventData)
		{
			while (this.m_UpdateDrag && this.m_DragPositionOutOfBounds)
			{
				Vector2 localMousePos;
				RectTransformUtility.ScreenPointToLocalPointInRectangle(this.textViewport, eventData.position, eventData.pressEventCamera, out localMousePos);
				Rect rect = this.textViewport.rect;
				if (this.multiLine)
				{
					if (localMousePos.y > rect.yMax)
					{
						this.MoveUp(true, true);
					}
					else if (localMousePos.y < rect.yMin)
					{
						this.MoveDown(true, true);
					}
				}
				else if (localMousePos.x < rect.xMin)
				{
					this.MoveLeft(true, false);
				}
				else if (localMousePos.x > rect.xMax)
				{
					this.MoveRight(true, false);
				}
				this.UpdateLabel();
				float delay = ((!this.multiLine) ? 0.05f : 0.1f);
				yield return new WaitForSeconds(delay);
			}
			this.m_DragCoroutine = null;
			yield break;
		}

		// Token: 0x06002B47 RID: 11079 RVA: 0x0001F03E File Offset: 0x0001D23E
		public virtual void OnEndDrag(PointerEventData eventData)
		{
			if (!this.MayDrag(eventData))
			{
				return;
			}
			this.m_UpdateDrag = false;
		}

		// Token: 0x06002B48 RID: 11080 RVA: 0x001023D0 File Offset: 0x001005D0
		public override void OnPointerDown(PointerEventData eventData)
		{
			if (!this.MayDrag(eventData))
			{
				return;
			}
			EventSystem.current.SetSelectedGameObject(base.gameObject, eventData);
			bool allowInput = this.m_AllowInput;
			base.OnPointerDown(eventData);
			if (!this.InPlaceEditing() && (this.m_Keyboard == null || !this.m_Keyboard.active))
			{
				this.OnSelect(eventData);
				return;
			}
			if (allowInput)
			{
				CaretPosition caretPosition;
				int cursorIndexFromPosition = TMP_TextUtilities.GetCursorIndexFromPosition(this.m_TextComponent, eventData.position, eventData.pressEventCamera, out caretPosition);
				int num;
				if (caretPosition == CaretPosition.Left)
				{
					num = this.GetStringIndexFromCaretPosition(cursorIndexFromPosition);
					this.stringSelectPositionInternal = num;
					this.stringPositionInternal = num;
				}
				else if (caretPosition == CaretPosition.Right)
				{
					num = this.GetStringIndexFromCaretPosition(cursorIndexFromPosition) + 1;
					this.stringSelectPositionInternal = num;
					this.stringPositionInternal = num;
				}
				num = this.GetCaretPositionFromStringIndex(this.stringPositionInternal);
				this.caretSelectPositionInternal = num;
				this.caretPositionInternal = num;
			}
			this.UpdateLabel();
			eventData.Use();
		}

		// Token: 0x06002B49 RID: 11081 RVA: 0x001024C4 File Offset: 0x001006C4
		protected TMP_InputField.EditState KeyPressed(Event evt)
		{
			EventModifiers modifiers = evt.modifiers;
			RuntimePlatform platform = Application.platform;
			bool flag = platform == RuntimePlatform.OSXEditor || platform == RuntimePlatform.OSXPlayer;
			bool flag2 = ((!flag) ? ((modifiers & EventModifiers.Control) != EventModifiers.None) : ((modifiers & EventModifiers.Command) != EventModifiers.None));
			bool flag3 = (modifiers & EventModifiers.Shift) != EventModifiers.None;
			bool flag4 = (modifiers & EventModifiers.Alt) != EventModifiers.None;
			bool flag5 = flag2 && !flag4 && !flag3;
			KeyCode keyCode = evt.keyCode;
			switch (keyCode)
			{
			case KeyCode.KeypadEnter:
				break;
			default:
				switch (keyCode)
				{
				case KeyCode.A:
					if (flag5)
					{
						this.SelectAll();
						return TMP_InputField.EditState.Continue;
					}
					goto IL_01FE;
				default:
					switch (keyCode)
					{
					case KeyCode.V:
						if (flag5)
						{
							this.Append(TMP_InputField.clipboard);
							return TMP_InputField.EditState.Continue;
						}
						goto IL_01FE;
					default:
						if (keyCode == KeyCode.Backspace)
						{
							this.Backspace();
							return TMP_InputField.EditState.Continue;
						}
						if (keyCode != KeyCode.Return)
						{
							if (keyCode == KeyCode.Escape)
							{
								this.m_WasCanceled = true;
								return TMP_InputField.EditState.Finish;
							}
							if (keyCode != KeyCode.Delete)
							{
								goto IL_01FE;
							}
							this.ForwardSpace();
							return TMP_InputField.EditState.Continue;
						}
						break;
					case KeyCode.X:
						if (flag5)
						{
							if (this.inputType != TMP_InputField.InputType.Password)
							{
								TMP_InputField.clipboard = this.GetSelectedString();
							}
							else
							{
								TMP_InputField.clipboard = string.Empty;
							}
							this.Delete();
							this.SendOnValueChangedAndUpdateLabel();
							return TMP_InputField.EditState.Continue;
						}
						goto IL_01FE;
					}
					break;
				case KeyCode.C:
					if (flag5)
					{
						if (this.inputType != TMP_InputField.InputType.Password)
						{
							TMP_InputField.clipboard = this.GetSelectedString();
						}
						else
						{
							TMP_InputField.clipboard = string.Empty;
						}
						return TMP_InputField.EditState.Continue;
					}
					goto IL_01FE;
				}
				break;
			case KeyCode.UpArrow:
				this.MoveUp(flag3);
				return TMP_InputField.EditState.Continue;
			case KeyCode.DownArrow:
				this.MoveDown(flag3);
				return TMP_InputField.EditState.Continue;
			case KeyCode.RightArrow:
				this.MoveRight(flag3, flag2);
				return TMP_InputField.EditState.Continue;
			case KeyCode.LeftArrow:
				this.MoveLeft(flag3, flag2);
				return TMP_InputField.EditState.Continue;
			case KeyCode.Home:
				this.MoveTextStart(flag3);
				return TMP_InputField.EditState.Continue;
			case KeyCode.End:
				this.MoveTextEnd(flag3);
				return TMP_InputField.EditState.Continue;
			}
			if (this.lineType != TMP_InputField.LineType.MultiLineNewline)
			{
				return TMP_InputField.EditState.Finish;
			}
			IL_01FE:
			char c = evt.character;
			if (!this.multiLine && (c == '\t' || c == '\r' || c == '\n'))
			{
				return TMP_InputField.EditState.Continue;
			}
			if (c == '\r' || c == '\u0003')
			{
				c = '\n';
			}
			if (this.IsValidChar(c))
			{
				this.Append(c);
			}
			if (c == '\0' && Input.compositionString.Length > 0)
			{
				this.UpdateLabel();
			}
			return TMP_InputField.EditState.Continue;
		}

		// Token: 0x06002B4A RID: 11082 RVA: 0x0001F054 File Offset: 0x0001D254
		private bool IsValidChar(char c)
		{
			return c != '\u007f' && (c == '\t' || c == '\n' || this.m_TextComponent.font.HasCharacter(c, true));
		}

		// Token: 0x06002B4B RID: 11083 RVA: 0x0001F084 File Offset: 0x0001D284
		public void ProcessEvent(Event e)
		{
			this.KeyPressed(e);
		}

		// Token: 0x06002B4C RID: 11084 RVA: 0x00102748 File Offset: 0x00100948
		public virtual void OnUpdateSelected(BaseEventData eventData)
		{
			if (!this.isFocused)
			{
				return;
			}
			bool flag = false;
			while (Event.PopEvent(this.m_ProcessingEvent))
			{
				if (this.m_ProcessingEvent.rawType == EventType.KeyDown)
				{
					flag = true;
					TMP_InputField.EditState editState = this.KeyPressed(this.m_ProcessingEvent);
					if (editState == TMP_InputField.EditState.Finish)
					{
						this.DeactivateInputField();
						break;
					}
				}
				EventType type = this.m_ProcessingEvent.type;
				if (type == EventType.ValidateCommand || type == EventType.ExecuteCommand)
				{
					string commandName = this.m_ProcessingEvent.commandName;
					if (commandName != null)
					{
						if (commandName == "SelectAll")
						{
							this.SelectAll();
							flag = true;
						}
					}
				}
			}
			if (flag)
			{
				this.UpdateLabel();
			}
			eventData.Use();
		}

		// Token: 0x06002B4D RID: 11085 RVA: 0x00102818 File Offset: 0x00100A18
		private string GetSelectedString()
		{
			if (!this.hasSelection)
			{
				return string.Empty;
			}
			int num = this.stringPositionInternal;
			int num2 = this.stringSelectPositionInternal;
			if (num > num2)
			{
				int num3 = num;
				num = num2;
				num2 = num3;
			}
			return this.text.Substring(num, num2 - num);
		}

		// Token: 0x06002B4E RID: 11086 RVA: 0x00102860 File Offset: 0x00100A60
		private int FindtNextWordBegin()
		{
			if (this.stringSelectPositionInternal + 1 >= this.text.Length)
			{
				return this.text.Length;
			}
			int num = this.text.IndexOfAny(TMP_InputField.kSeparators, this.stringSelectPositionInternal + 1);
			if (num == -1)
			{
				num = this.text.Length;
			}
			else
			{
				num++;
			}
			return num;
		}

		// Token: 0x06002B4F RID: 11087 RVA: 0x001028C8 File Offset: 0x00100AC8
		private void MoveRight(bool shift, bool ctrl)
		{
			if (this.hasSelection && !shift)
			{
				int num = Mathf.Max(this.stringPositionInternal, this.stringSelectPositionInternal);
				this.stringSelectPositionInternal = num;
				this.stringPositionInternal = num;
				num = this.GetCaretPositionFromStringIndex(this.stringSelectPositionInternal);
				this.caretSelectPositionInternal = num;
				this.caretPositionInternal = num;
				return;
			}
			int caretSelectPositionInternal = this.caretSelectPositionInternal;
			int num2;
			if (ctrl)
			{
				num2 = this.FindtNextWordBegin();
			}
			else
			{
				num2 = this.stringSelectPositionInternal + 1;
			}
			if (shift)
			{
				this.stringSelectPositionInternal = num2;
				this.caretSelectPositionInternal = this.GetCaretPositionFromStringIndex(this.stringSelectPositionInternal);
			}
			else
			{
				int num = num2;
				this.stringPositionInternal = num;
				this.stringSelectPositionInternal = num;
				num = this.GetCaretPositionFromStringIndex(this.stringSelectPositionInternal);
				this.caretPositionInternal = num;
				this.caretSelectPositionInternal = num;
			}
			this.isCaretInsideTag = caretSelectPositionInternal == this.caretSelectPositionInternal;
			Debug.Log("Caret is " + ((!this.isCaretInsideTag) ? " [Not Inside Tag]" : " [Inside Tag]"));
		}

		// Token: 0x06002B50 RID: 11088 RVA: 0x001029CC File Offset: 0x00100BCC
		private int FindtPrevWordBegin()
		{
			if (this.stringSelectPositionInternal - 2 < 0)
			{
				return 0;
			}
			int num = this.text.LastIndexOfAny(TMP_InputField.kSeparators, this.stringSelectPositionInternal - 2);
			if (num == -1)
			{
				num = 0;
			}
			else
			{
				num++;
			}
			return num;
		}

		// Token: 0x06002B51 RID: 11089 RVA: 0x00102A18 File Offset: 0x00100C18
		private void MoveLeft(bool shift, bool ctrl)
		{
			if (this.hasSelection && !shift)
			{
				int num = Mathf.Min(this.stringPositionInternal, this.stringSelectPositionInternal);
				this.stringSelectPositionInternal = num;
				this.stringPositionInternal = num;
				num = this.GetCaretPositionFromStringIndex(this.stringSelectPositionInternal);
				this.caretSelectPositionInternal = num;
				this.caretPositionInternal = num;
				return;
			}
			int caretSelectPositionInternal = this.caretSelectPositionInternal;
			int num2;
			if (ctrl)
			{
				num2 = this.FindtPrevWordBegin();
			}
			else
			{
				num2 = this.stringSelectPositionInternal - 1;
			}
			if (shift)
			{
				this.stringSelectPositionInternal = num2;
				this.caretSelectPositionInternal = this.GetCaretPositionFromStringIndex(this.stringSelectPositionInternal);
			}
			else
			{
				int num = num2;
				this.stringPositionInternal = num;
				this.stringSelectPositionInternal = num;
				num = this.GetCaretPositionFromStringIndex(this.stringSelectPositionInternal);
				this.caretPositionInternal = num;
				this.caretSelectPositionInternal = num;
			}
			this.isCaretInsideTag = caretSelectPositionInternal == this.caretSelectPositionInternal;
			Debug.Log("Caret is " + ((!this.isCaretInsideTag) ? " [Not Inside Tag]" : " [Inside Tag]"));
		}

		// Token: 0x06002B52 RID: 11090 RVA: 0x00102B1C File Offset: 0x00100D1C
		private int LineUpCharacterPosition(int originalPos, bool goToFirstChar)
		{
			if (originalPos >= this.m_TextComponent.textInfo.characterCount)
			{
				originalPos--;
			}
			TMP_CharacterInfo tmp_CharacterInfo = this.m_TextComponent.textInfo.characterInfo[originalPos];
			int lineNumber = (int)tmp_CharacterInfo.lineNumber;
			if (lineNumber - 1 < 0)
			{
				return (!goToFirstChar) ? originalPos : 0;
			}
			int num = this.m_TextComponent.textInfo.lineInfo[lineNumber].firstCharacterIndex - 1;
			int i = this.m_TextComponent.textInfo.lineInfo[lineNumber - 1].firstCharacterIndex;
			while (i < num)
			{
				TMP_CharacterInfo tmp_CharacterInfo2 = this.m_TextComponent.textInfo.characterInfo[i];
				float num2 = (tmp_CharacterInfo.origin - tmp_CharacterInfo2.origin) / (tmp_CharacterInfo2.xAdvance - tmp_CharacterInfo2.origin);
				if (num2 >= 0f && num2 <= 1f)
				{
					if (num2 < 0.5f)
					{
						return i;
					}
					return i + 1;
				}
				else
				{
					i++;
				}
			}
			return num;
		}

		// Token: 0x06002B53 RID: 11091 RVA: 0x00102C34 File Offset: 0x00100E34
		private int LineDownCharacterPosition(int originalPos, bool goToLastChar)
		{
			if (originalPos >= this.m_TextComponent.textInfo.characterCount)
			{
				return this.text.Length;
			}
			TMP_CharacterInfo tmp_CharacterInfo = this.m_TextComponent.textInfo.characterInfo[originalPos];
			int lineNumber = (int)tmp_CharacterInfo.lineNumber;
			if (lineNumber + 1 >= this.m_TextComponent.textInfo.lineCount)
			{
				return (!goToLastChar) ? originalPos : (this.m_TextComponent.textInfo.characterCount - 1);
			}
			int lastCharacterIndex = this.m_TextComponent.textInfo.lineInfo[lineNumber + 1].lastCharacterIndex;
			int i = this.m_TextComponent.textInfo.lineInfo[lineNumber + 1].firstCharacterIndex;
			while (i < lastCharacterIndex)
			{
				TMP_CharacterInfo tmp_CharacterInfo2 = this.m_TextComponent.textInfo.characterInfo[i];
				float num = (tmp_CharacterInfo.origin - tmp_CharacterInfo2.origin) / (tmp_CharacterInfo2.xAdvance - tmp_CharacterInfo2.origin);
				if (num >= 0f && num <= 1f)
				{
					if (num < 0.5f)
					{
						return i;
					}
					return i + 1;
				}
				else
				{
					i++;
				}
			}
			return lastCharacterIndex;
		}

		// Token: 0x06002B54 RID: 11092 RVA: 0x0001F08E File Offset: 0x0001D28E
		private void MoveDown(bool shift)
		{
			this.MoveDown(shift, true);
		}

		// Token: 0x06002B55 RID: 11093 RVA: 0x00102D74 File Offset: 0x00100F74
		private void MoveDown(bool shift, bool goToLastChar)
		{
			if (this.hasSelection && !shift)
			{
				int num = Mathf.Max(this.caretPositionInternal, this.caretSelectPositionInternal);
				this.caretSelectPositionInternal = num;
				this.caretPositionInternal = num;
			}
			int num2 = ((!this.multiLine) ? this.text.Length : this.LineDownCharacterPosition(this.caretSelectPositionInternal, goToLastChar));
			if (shift)
			{
				this.caretSelectPositionInternal = num2;
				this.stringSelectPositionInternal = this.GetStringIndexFromCaretPosition(this.caretSelectPositionInternal);
			}
			else
			{
				int num = num2;
				this.caretPositionInternal = num;
				this.caretSelectPositionInternal = num;
				num = this.GetStringIndexFromCaretPosition(this.caretSelectPositionInternal);
				this.stringPositionInternal = num;
				this.stringSelectPositionInternal = num;
			}
		}

		// Token: 0x06002B56 RID: 11094 RVA: 0x0001F098 File Offset: 0x0001D298
		private void MoveUp(bool shift)
		{
			this.MoveUp(shift, true);
		}

		// Token: 0x06002B57 RID: 11095 RVA: 0x00102E2C File Offset: 0x0010102C
		private void MoveUp(bool shift, bool goToFirstChar)
		{
			if (this.hasSelection && !shift)
			{
				int num = Mathf.Min(this.caretPositionInternal, this.caretSelectPositionInternal);
				this.caretSelectPositionInternal = num;
				this.caretPositionInternal = num;
			}
			int num2 = ((!this.multiLine) ? 0 : this.LineUpCharacterPosition(this.caretSelectPositionInternal, goToFirstChar));
			if (shift)
			{
				this.caretSelectPositionInternal = num2;
				this.stringSelectPositionInternal = this.GetStringIndexFromCaretPosition(this.caretSelectPositionInternal);
			}
			else
			{
				int num = num2;
				this.caretPositionInternal = num;
				this.caretSelectPositionInternal = num;
				num = this.GetStringIndexFromCaretPosition(this.caretSelectPositionInternal);
				this.stringPositionInternal = num;
				this.stringSelectPositionInternal = num;
			}
		}

		// Token: 0x06002B58 RID: 11096 RVA: 0x00102ED8 File Offset: 0x001010D8
		private void Delete()
		{
			if (this.m_ReadOnly)
			{
				return;
			}
			if (this.stringPositionInternal == this.stringSelectPositionInternal)
			{
				return;
			}
			if (this.stringPositionInternal < this.stringSelectPositionInternal)
			{
				this.m_Text = this.text.Substring(0, this.stringPositionInternal) + this.text.Substring(this.stringSelectPositionInternal, this.text.Length - this.stringSelectPositionInternal);
				this.stringSelectPositionInternal = this.stringPositionInternal;
			}
			else
			{
				this.m_Text = this.text.Substring(0, this.stringSelectPositionInternal) + this.text.Substring(this.stringPositionInternal, this.text.Length - this.stringPositionInternal);
				this.stringPositionInternal = this.stringSelectPositionInternal;
			}
		}

		// Token: 0x06002B59 RID: 11097 RVA: 0x00102FB4 File Offset: 0x001011B4
		private void ForwardSpace()
		{
			if (this.m_ReadOnly)
			{
				return;
			}
			if (this.hasSelection)
			{
				this.Delete();
				this.SendOnValueChangedAndUpdateLabel();
			}
			else if (this.stringPositionInternal < this.text.Length)
			{
				this.m_Text = this.text.Remove(this.stringPositionInternal, 1);
				this.SendOnValueChangedAndUpdateLabel();
			}
		}

		// Token: 0x06002B5A RID: 11098 RVA: 0x00103020 File Offset: 0x00101220
		private void Backspace()
		{
			if (this.m_ReadOnly)
			{
				return;
			}
			if (this.hasSelection)
			{
				this.Delete();
				this.SendOnValueChangedAndUpdateLabel();
			}
			else if (this.stringPositionInternal > 0)
			{
				this.m_Text = this.text.Remove(this.stringPositionInternal - 1, 1);
				int num = this.stringPositionInternal - 1;
				this.stringPositionInternal = num;
				this.stringSelectPositionInternal = num;
				this.m_isLastKeyBackspace = true;
				this.SendOnValueChangedAndUpdateLabel();
			}
		}

		// Token: 0x06002B5B RID: 11099 RVA: 0x001030A0 File Offset: 0x001012A0
		private void Insert(char c)
		{
			if (this.m_ReadOnly)
			{
				return;
			}
			string text = c.ToString();
			this.Delete();
			if (this.characterLimit > 0 && this.text.Length >= this.characterLimit)
			{
				return;
			}
			this.m_Text = this.text.Insert(this.m_StringPosition, text);
			this.stringSelectPositionInternal = (this.stringPositionInternal += text.Length);
			this.SendOnValueChanged();
		}

		// Token: 0x06002B5C RID: 11100 RVA: 0x0001F0A2 File Offset: 0x0001D2A2
		private void SendOnValueChangedAndUpdateLabel()
		{
			this.SendOnValueChanged();
			this.UpdateLabel();
		}

		// Token: 0x06002B5D RID: 11101 RVA: 0x0001F0B0 File Offset: 0x0001D2B0
		private void SendOnValueChanged()
		{
			if (this.onValueChanged != null)
			{
				this.onValueChanged.Invoke(this.text);
			}
		}

		// Token: 0x06002B5E RID: 11102 RVA: 0x0001F0CE File Offset: 0x0001D2CE
		protected void SendOnSubmit()
		{
			if (this.onEndEdit != null)
			{
				this.onEndEdit.Invoke(this.m_Text);
			}
		}

		// Token: 0x06002B5F RID: 11103 RVA: 0x0001F0EC File Offset: 0x0001D2EC
		protected void SendOnFocusLost()
		{
			if (this.onFocusLost != null)
			{
				this.onFocusLost.Invoke(this.m_Text);
			}
		}

		// Token: 0x06002B60 RID: 11104 RVA: 0x0010312C File Offset: 0x0010132C
		protected virtual void Append(string input)
		{
			if (this.m_ReadOnly)
			{
				return;
			}
			if (!this.InPlaceEditing())
			{
				return;
			}
			int i = 0;
			int length = input.Length;
			while (i < length)
			{
				char c = input[i];
				if (c >= ' ' || c == '\t' || c == '\r' || c == '\n' || c == '\n')
				{
					this.Append(c);
				}
				i++;
			}
		}

		// Token: 0x06002B61 RID: 11105 RVA: 0x001031A4 File Offset: 0x001013A4
		protected virtual void Append(char input)
		{
			if (this.m_ReadOnly)
			{
				return;
			}
			if (!this.InPlaceEditing())
			{
				return;
			}
			if (this.onValidateInput != null)
			{
				input = this.onValidateInput(this.text, this.stringPositionInternal, input);
			}
			else if (this.characterValidation != TMP_InputField.CharacterValidation.None)
			{
				input = this.Validate(this.text, this.stringPositionInternal, input);
			}
			if (input == '\0')
			{
				return;
			}
			this.Insert(input);
		}

		// Token: 0x06002B62 RID: 11106 RVA: 0x00103224 File Offset: 0x00101424
		protected void UpdateLabel()
		{
			if (this.m_TextComponent != null && this.m_TextComponent.font != null)
			{
				string text;
				if (Input.compositionString.Length > 0)
				{
					text = this.text.Substring(0, this.m_StringPosition) + Input.compositionString + this.text.Substring(this.m_StringPosition);
				}
				else
				{
					text = this.text;
				}
				string text2;
				if (this.inputType == TMP_InputField.InputType.Password)
				{
					text2 = new string(this.asteriskChar, text.Length);
				}
				else
				{
					text2 = text;
				}
				bool flag = string.IsNullOrEmpty(text);
				if (this.m_Placeholder != null)
				{
					this.m_Placeholder.enabled = flag;
				}
				if (!this.m_AllowInput)
				{
					this.m_DrawStart = 0;
					this.m_DrawEnd = this.m_Text.Length;
				}
				if (!flag)
				{
					this.SetCaretVisible();
				}
				this.m_TextComponent.text = text2 + "\u200b";
				this.MarkGeometryAsDirty();
			}
		}

		// Token: 0x06002B63 RID: 11107 RVA: 0x00103338 File Offset: 0x00101538
		private int GetCaretPositionFromStringIndex(int stringIndex)
		{
			int characterCount = this.m_TextComponent.textInfo.characterCount;
			for (int i = 0; i < characterCount; i++)
			{
				if ((int)this.m_TextComponent.textInfo.characterInfo[i].index >= stringIndex)
				{
					return i;
				}
			}
			return characterCount;
		}

		// Token: 0x06002B64 RID: 11108 RVA: 0x0001F10A File Offset: 0x0001D30A
		private int GetStringIndexFromCaretPosition(int caretPosition)
		{
			return (int)this.m_TextComponent.textInfo.characterInfo[caretPosition].index;
		}

		// Token: 0x06002B65 RID: 11109 RVA: 0x0001F127 File Offset: 0x0001D327
		public void ForceLabelUpdate()
		{
			this.UpdateLabel();
		}

		// Token: 0x06002B66 RID: 11110 RVA: 0x0001F12F File Offset: 0x0001D32F
		private void MarkGeometryAsDirty()
		{
			CanvasUpdateRegistry.RegisterCanvasElementForGraphicRebuild(this);
		}

		// Token: 0x06002B67 RID: 11111 RVA: 0x0001F137 File Offset: 0x0001D337
		public virtual void Rebuild(CanvasUpdate update)
		{
			if (update == CanvasUpdate.LatePreRender)
			{
				this.UpdateGeometry();
			}
		}

		// Token: 0x06002B68 RID: 11112 RVA: 0x00002482 File Offset: 0x00000682
		public virtual void LayoutComplete()
		{
		}

		// Token: 0x06002B69 RID: 11113 RVA: 0x00002482 File Offset: 0x00000682
		public virtual void GraphicUpdateComplete()
		{
		}

		// Token: 0x06002B6A RID: 11114 RVA: 0x0010338C File Offset: 0x0010158C
		private void UpdateGeometry()
		{
			if (!this.shouldHideMobileInput)
			{
				return;
			}
			if (this.m_CachedInputRenderer == null && this.m_TextComponent != null)
			{
				GameObject gameObject = new GameObject(base.transform.name + " Input Caret");
				gameObject.hideFlags = HideFlags.DontSave;
				gameObject.transform.SetParent(this.m_TextComponent.transform.parent);
				gameObject.transform.SetAsFirstSibling();
				gameObject.layer = base.gameObject.layer;
				this.caretRectTrans = gameObject.AddComponent<RectTransform>();
				this.m_CachedInputRenderer = gameObject.AddComponent<CanvasRenderer>();
				this.m_CachedInputRenderer.SetMaterial(Graphic.defaultGraphicMaterial, Texture2D.whiteTexture);
				gameObject.AddComponent<LayoutElement>().ignoreLayout = true;
				this.AssignPositioningIfNeeded();
			}
			if (this.m_CachedInputRenderer == null)
			{
				return;
			}
			this.OnFillVBO(this.mesh);
			this.m_CachedInputRenderer.SetMesh(this.mesh);
		}

		// Token: 0x06002B6B RID: 11115 RVA: 0x00103490 File Offset: 0x00101690
		private void AssignPositioningIfNeeded()
		{
			if (this.m_TextComponent != null && this.caretRectTrans != null && (this.caretRectTrans.localPosition != this.m_TextComponent.rectTransform.localPosition || this.caretRectTrans.localRotation != this.m_TextComponent.rectTransform.localRotation || this.caretRectTrans.localScale != this.m_TextComponent.rectTransform.localScale || this.caretRectTrans.anchorMin != this.m_TextComponent.rectTransform.anchorMin || this.caretRectTrans.anchorMax != this.m_TextComponent.rectTransform.anchorMax || this.caretRectTrans.anchoredPosition != this.m_TextComponent.rectTransform.anchoredPosition || this.caretRectTrans.sizeDelta != this.m_TextComponent.rectTransform.sizeDelta || this.caretRectTrans.pivot != this.m_TextComponent.rectTransform.pivot))
			{
				this.caretRectTrans.localPosition = this.m_TextComponent.rectTransform.localPosition;
				this.caretRectTrans.localRotation = this.m_TextComponent.rectTransform.localRotation;
				this.caretRectTrans.localScale = this.m_TextComponent.rectTransform.localScale;
				this.caretRectTrans.anchorMin = this.m_TextComponent.rectTransform.anchorMin;
				this.caretRectTrans.anchorMax = this.m_TextComponent.rectTransform.anchorMax;
				this.caretRectTrans.anchoredPosition = this.m_TextComponent.rectTransform.anchoredPosition;
				this.caretRectTrans.sizeDelta = this.m_TextComponent.rectTransform.sizeDelta;
				this.caretRectTrans.pivot = this.m_TextComponent.rectTransform.pivot;
			}
		}

		// Token: 0x06002B6C RID: 11116 RVA: 0x001036C0 File Offset: 0x001018C0
		private void OnFillVBO(Mesh vbo)
		{
			using (VertexHelper vertexHelper = new VertexHelper())
			{
				if (!this.isFocused)
				{
					vertexHelper.FillMesh(vbo);
				}
				else
				{
					if (!this.hasSelection)
					{
						this.GenerateCaret(vertexHelper, Vector2.zero);
					}
					else
					{
						this.GenerateHightlight(vertexHelper, Vector2.zero);
					}
					vertexHelper.FillMesh(vbo);
				}
			}
		}

		// Token: 0x06002B6D RID: 11117 RVA: 0x0010373C File Offset: 0x0010193C
		private void GenerateCaret(VertexHelper vbo, Vector2 roundingOffset)
		{
			if (!this.m_CaretVisible)
			{
				return;
			}
			if (this.m_CursorVerts == null)
			{
				this.CreateCursorVerts();
			}
			float num = (float)this.m_CaretWidth;
			int characterCount = this.m_TextComponent.textInfo.characterCount;
			Vector2 zero = Vector2.zero;
			this.caretPositionInternal = this.GetCaretPositionFromStringIndex(this.stringPositionInternal);
			TMP_CharacterInfo tmp_CharacterInfo;
			float num2;
			if (this.caretPositionInternal == 0)
			{
				tmp_CharacterInfo = this.m_TextComponent.textInfo.characterInfo[0];
				zero = new Vector2(tmp_CharacterInfo.origin, tmp_CharacterInfo.descender);
				num2 = tmp_CharacterInfo.ascender - tmp_CharacterInfo.descender;
			}
			else if (this.caretPositionInternal < characterCount)
			{
				tmp_CharacterInfo = this.m_TextComponent.textInfo.characterInfo[this.caretPositionInternal];
				zero = new Vector2(tmp_CharacterInfo.origin, tmp_CharacterInfo.descender);
				num2 = tmp_CharacterInfo.ascender - tmp_CharacterInfo.descender;
			}
			else
			{
				tmp_CharacterInfo = this.m_TextComponent.textInfo.characterInfo[characterCount - 1];
				zero = new Vector2(tmp_CharacterInfo.xAdvance, tmp_CharacterInfo.descender);
				num2 = tmp_CharacterInfo.ascender - tmp_CharacterInfo.descender;
			}
			this.AdjustRectTransformRelativeToViewport(zero, num2, tmp_CharacterInfo.isVisible);
			float num3 = zero.y + num2;
			float num4 = num3 - Mathf.Min(num2, this.m_TextComponent.rectTransform.rect.height);
			this.m_CursorVerts[0].position = new Vector3(zero.x, num4, 0f);
			this.m_CursorVerts[1].position = new Vector3(zero.x, num3, 0f);
			this.m_CursorVerts[2].position = new Vector3(zero.x + num, num3, 0f);
			this.m_CursorVerts[3].position = new Vector3(zero.x + num, num4, 0f);
			this.m_CursorVerts[0].color = this.caretColor;
			this.m_CursorVerts[1].color = this.caretColor;
			this.m_CursorVerts[2].color = this.caretColor;
			this.m_CursorVerts[3].color = this.caretColor;
			vbo.AddUIVertexQuad(this.m_CursorVerts);
			int height = Screen.height;
			zero.y = (float)height - zero.y;
			Input.compositionCursorPos = zero;
		}

		// Token: 0x06002B6E RID: 11118 RVA: 0x001039F8 File Offset: 0x00101BF8
		private void CreateCursorVerts()
		{
			this.m_CursorVerts = new UIVertex[4];
			for (int i = 0; i < this.m_CursorVerts.Length; i++)
			{
				this.m_CursorVerts[i] = UIVertex.simpleVert;
				this.m_CursorVerts[i].uv0 = Vector2.zero;
			}
		}

		// Token: 0x06002B6F RID: 11119 RVA: 0x00103A58 File Offset: 0x00101C58
		private void GenerateHightlight(VertexHelper vbo, Vector2 roundingOffset)
		{
			TMP_TextInfo textInfo = this.m_TextComponent.textInfo;
			this.caretPositionInternal = this.GetCaretPositionFromStringIndex(this.stringPositionInternal);
			this.caretSelectPositionInternal = this.GetCaretPositionFromStringIndex(this.stringSelectPositionInternal);
			Debug.Log(string.Concat(new object[] { "StringPosition:", this.stringPositionInternal, "  StringSelectPosition:", this.stringSelectPositionInternal }));
			Vector2 vector;
			float num;
			if (this.caretSelectPositionInternal < textInfo.characterCount)
			{
				vector = new Vector2(textInfo.characterInfo[this.caretSelectPositionInternal].origin, textInfo.characterInfo[this.caretSelectPositionInternal].descender);
				num = textInfo.characterInfo[this.caretSelectPositionInternal].ascender - textInfo.characterInfo[this.caretSelectPositionInternal].descender;
			}
			else
			{
				vector = new Vector2(textInfo.characterInfo[this.caretSelectPositionInternal - 1].xAdvance, textInfo.characterInfo[this.caretSelectPositionInternal - 1].descender);
				num = textInfo.characterInfo[this.caretSelectPositionInternal - 1].ascender - textInfo.characterInfo[this.caretSelectPositionInternal - 1].descender;
			}
			this.AdjustRectTransformRelativeToViewport(vector, num, true);
			int num2 = Mathf.Max(0, this.caretPositionInternal);
			int num3 = Mathf.Max(0, this.caretSelectPositionInternal);
			if (num2 > num3)
			{
				int num4 = num2;
				num2 = num3;
				num3 = num4;
			}
			num3--;
			int num5 = (int)textInfo.characterInfo[num2].lineNumber;
			int num6 = textInfo.lineInfo[num5].lastCharacterIndex;
			UIVertex simpleVert = UIVertex.simpleVert;
			simpleVert.uv0 = Vector2.zero;
			simpleVert.color = this.selectionColor;
			int num7 = num2;
			while (num7 <= num3 && num7 < textInfo.characterCount)
			{
				if (num7 == num6 || num7 == num3)
				{
					TMP_CharacterInfo tmp_CharacterInfo = textInfo.characterInfo[num2];
					TMP_CharacterInfo tmp_CharacterInfo2 = textInfo.characterInfo[num7];
					Vector2 vector2 = new Vector2(tmp_CharacterInfo.origin, tmp_CharacterInfo.ascender);
					Vector2 vector3 = new Vector2(tmp_CharacterInfo2.xAdvance, tmp_CharacterInfo2.descender);
					Vector2 min = this.m_TextViewport.rect.min;
					Vector2 max = this.m_TextViewport.rect.max;
					float num8 = this.m_TextComponent.rectTransform.anchoredPosition.x + vector2.x - min.x;
					if (num8 < 0f)
					{
						vector2.x -= num8;
					}
					float num9 = this.m_TextComponent.rectTransform.anchoredPosition.y + vector3.y - min.y;
					if (num9 < 0f)
					{
						vector3.y -= num9;
					}
					float num10 = max.x - (this.m_TextComponent.rectTransform.anchoredPosition.x + vector3.x);
					if (num10 < 0f)
					{
						vector3.x += num10;
					}
					float num11 = max.y - (this.m_TextComponent.rectTransform.anchoredPosition.y + vector2.y);
					if (num11 < 0f)
					{
						vector2.y += num11;
					}
					if (this.m_TextComponent.rectTransform.anchoredPosition.y + vector2.y >= min.y && this.m_TextComponent.rectTransform.anchoredPosition.y + vector3.y <= max.y)
					{
						int currentVertCount = vbo.currentVertCount;
						simpleVert.position = new Vector3(vector2.x, vector3.y, 0f);
						vbo.AddVert(simpleVert);
						simpleVert.position = new Vector3(vector3.x, vector3.y, 0f);
						vbo.AddVert(simpleVert);
						simpleVert.position = new Vector3(vector3.x, vector2.y, 0f);
						vbo.AddVert(simpleVert);
						simpleVert.position = new Vector3(vector2.x, vector2.y, 0f);
						vbo.AddVert(simpleVert);
						vbo.AddTriangle(currentVertCount, currentVertCount + 1, currentVertCount + 2);
						vbo.AddTriangle(currentVertCount + 2, currentVertCount + 3, currentVertCount);
					}
					num2 = num7 + 1;
					num5++;
					if (num5 < textInfo.lineCount)
					{
						num6 = textInfo.lineInfo[num5].lastCharacterIndex;
					}
				}
				num7++;
			}
		}

		// Token: 0x06002B70 RID: 11120 RVA: 0x00103F60 File Offset: 0x00102160
		private void AdjustRectTransformRelativeToViewport(Vector2 startPosition, float height, bool isCharVisible)
		{
			float xMin = this.m_TextViewport.rect.xMin;
			float xMax = this.m_TextViewport.rect.xMax;
			float num = xMax - (this.m_TextComponent.rectTransform.anchoredPosition.x + startPosition.x + this.m_TextComponent.margin.z);
			if (num < 0f && (!this.multiLine || (this.multiLine && isCharVisible)))
			{
				this.m_TextComponent.rectTransform.anchoredPosition += new Vector2(num, 0f);
				this.AssignPositioningIfNeeded();
			}
			float num2 = this.m_TextComponent.rectTransform.anchoredPosition.x + startPosition.x - this.m_TextComponent.margin.x - xMin;
			if (num2 < 0f)
			{
				this.m_TextComponent.rectTransform.anchoredPosition += new Vector2(-num2, 0f);
				this.AssignPositioningIfNeeded();
			}
			if (this.m_LineType != TMP_InputField.LineType.SingleLine)
			{
				float num3 = this.m_TextViewport.rect.yMax - (this.m_TextComponent.rectTransform.anchoredPosition.y + startPosition.y + height);
				if (num3 < -0.0001f)
				{
					this.m_TextComponent.rectTransform.anchoredPosition += new Vector2(0f, num3);
					this.AssignPositioningIfNeeded();
				}
				float num4 = this.m_TextComponent.rectTransform.anchoredPosition.y + startPosition.y - this.m_TextViewport.rect.yMin;
				if (num4 < 0f)
				{
					this.m_TextComponent.rectTransform.anchoredPosition -= new Vector2(0f, num4);
					this.AssignPositioningIfNeeded();
				}
			}
			if (this.m_isLastKeyBackspace)
			{
				float num5 = this.m_TextComponent.rectTransform.anchoredPosition.x + this.m_TextComponent.textInfo.characterInfo[0].origin - this.m_TextComponent.margin.x;
				float num6 = this.m_TextComponent.rectTransform.anchoredPosition.x + this.m_TextComponent.textInfo.characterInfo[this.m_TextComponent.textInfo.characterCount - 1].origin + this.m_TextComponent.margin.z;
				if (this.m_TextComponent.rectTransform.anchoredPosition.x + startPosition.x <= xMin + 0.0001f)
				{
					if (num5 < xMin)
					{
						float num7 = Mathf.Min((xMax - xMin) / 2f, xMin - num5);
						this.m_TextComponent.rectTransform.anchoredPosition += new Vector2(num7, 0f);
						this.AssignPositioningIfNeeded();
					}
				}
				else if (num6 < xMax && num5 < xMin)
				{
					float num8 = Mathf.Min(xMax - num6, xMin - num5);
					this.m_TextComponent.rectTransform.anchoredPosition += new Vector2(num8, 0f);
					this.AssignPositioningIfNeeded();
				}
				this.m_isLastKeyBackspace = false;
			}
		}

		// Token: 0x06002B71 RID: 11121 RVA: 0x0010430C File Offset: 0x0010250C
		protected char Validate(string text, int pos, char ch)
		{
			if (this.characterValidation == TMP_InputField.CharacterValidation.None || !base.enabled)
			{
				return ch;
			}
			if (this.characterValidation == TMP_InputField.CharacterValidation.Integer || this.characterValidation == TMP_InputField.CharacterValidation.Decimal)
			{
				bool flag = pos == 0 && text.Length > 0 && text[0] == '-';
				bool flag2 = this.stringPositionInternal == 0 || this.stringSelectPositionInternal == 0;
				if (!flag)
				{
					if (ch >= '0' && ch <= '9')
					{
						return ch;
					}
					if (ch == '-' && (pos == 0 || flag2))
					{
						return ch;
					}
					if (ch == '.' && this.characterValidation == TMP_InputField.CharacterValidation.Decimal && !text.Contains("."))
					{
						return ch;
					}
				}
			}
			else if (this.characterValidation == TMP_InputField.CharacterValidation.Alphanumeric)
			{
				if (ch >= 'A' && ch <= 'Z')
				{
					return ch;
				}
				if (ch >= 'a' && ch <= 'z')
				{
					return ch;
				}
				if (ch >= '0' && ch <= '9')
				{
					return ch;
				}
			}
			else if (this.characterValidation == TMP_InputField.CharacterValidation.Name)
			{
				char c = ((text.Length <= 0) ? ' ' : text[Mathf.Clamp(pos, 0, text.Length - 1)]);
				char c2 = ((text.Length <= 0) ? '\n' : text[Mathf.Clamp(pos + 1, 0, text.Length - 1)]);
				if (char.IsLetter(ch))
				{
					if (char.IsLower(ch) && c == ' ')
					{
						return char.ToUpper(ch);
					}
					if (char.IsUpper(ch) && c != ' ' && c != '\'')
					{
						return char.ToLower(ch);
					}
					return ch;
				}
				else if (ch == '\'')
				{
					if (c != ' ' && c != '\'' && c2 != '\'' && !text.Contains("'"))
					{
						return ch;
					}
				}
				else if (ch == ' ' && c != ' ' && c != '\'' && c2 != ' ' && c2 != '\'')
				{
					return ch;
				}
			}
			else if (this.characterValidation == TMP_InputField.CharacterValidation.EmailAddress)
			{
				if (ch >= 'A' && ch <= 'Z')
				{
					return ch;
				}
				if (ch >= 'a' && ch <= 'z')
				{
					return ch;
				}
				if (ch >= '0' && ch <= '9')
				{
					return ch;
				}
				if (ch == '@' && text.IndexOf('@') == -1)
				{
					return ch;
				}
				if ("!#$%&'*+-/=?^_`{|}~".IndexOf(ch) != -1)
				{
					return ch;
				}
				if (ch == '.')
				{
					char c3 = ((text.Length <= 0) ? ' ' : text[Mathf.Clamp(pos, 0, text.Length - 1)]);
					char c4 = ((text.Length <= 0) ? '\n' : text[Mathf.Clamp(pos + 1, 0, text.Length - 1)]);
					if (c3 != '.' && c4 != '.')
					{
						return ch;
					}
				}
			}
			return '\0';
		}

		// Token: 0x06002B72 RID: 11122 RVA: 0x00104614 File Offset: 0x00102814
		public void ActivateInputField()
		{
			if (this.m_TextComponent == null || this.m_TextComponent.font == null || !this.IsActive() || !this.IsInteractable())
			{
				return;
			}
			if (this.isFocused && this.m_Keyboard != null && !this.m_Keyboard.active)
			{
				this.m_Keyboard.active = true;
				this.m_Keyboard.text = this.m_Text;
			}
			this.m_HasLostFocus = false;
			this.m_ShouldActivateNextUpdate = true;
		}

		// Token: 0x06002B73 RID: 11123 RVA: 0x001046B0 File Offset: 0x001028B0
		private void ActivateInputFieldInternal()
		{
			if (EventSystem.current == null)
			{
				return;
			}
			if (EventSystem.current.currentSelectedGameObject != base.gameObject)
			{
				EventSystem.current.SetSelectedGameObject(base.gameObject);
			}
			if (TouchScreenKeyboard.isSupported)
			{
				if (Input.touchSupported)
				{
					TouchScreenKeyboard.hideInput = this.shouldHideMobileInput;
				}
				this.m_Keyboard = ((this.inputType != TMP_InputField.InputType.Password) ? TouchScreenKeyboard.Open(this.m_Text, this.keyboardType, this.inputType == TMP_InputField.InputType.AutoCorrect, this.multiLine) : TouchScreenKeyboard.Open(this.m_Text, this.keyboardType, false, this.multiLine, true));
				this.MoveTextEnd(false);
			}
			else
			{
				Input.imeCompositionMode = IMECompositionMode.On;
				this.OnFocus();
			}
			this.m_AllowInput = true;
			this.m_OriginalText = this.text;
			this.m_WasCanceled = false;
			this.SetCaretVisible();
			this.UpdateLabel();
		}

		// Token: 0x06002B74 RID: 11124 RVA: 0x0001F150 File Offset: 0x0001D350
		public override void OnSelect(BaseEventData eventData)
		{
			Debug.Log("OnSelect()");
			base.OnSelect(eventData);
			this.ActivateInputField();
		}

		// Token: 0x06002B75 RID: 11125 RVA: 0x0001F169 File Offset: 0x0001D369
		public virtual void OnPointerClick(PointerEventData eventData)
		{
			if (eventData.button != PointerEventData.InputButton.Left)
			{
				return;
			}
			this.ActivateInputField();
		}

		// Token: 0x06002B76 RID: 11126 RVA: 0x001047A8 File Offset: 0x001029A8
		public void DeactivateInputField()
		{
			if (!this.m_AllowInput)
			{
				return;
			}
			this.m_HasDoneFocusTransition = false;
			this.m_AllowInput = false;
			if (this.m_Placeholder != null)
			{
				this.m_Placeholder.enabled = string.IsNullOrEmpty(this.m_Text);
			}
			if (this.m_TextComponent != null && this.IsInteractable())
			{
				if (this.m_WasCanceled)
				{
					this.text = this.m_OriginalText;
				}
				if (this.m_Keyboard != null)
				{
					this.m_Keyboard.active = false;
					this.m_Keyboard = null;
				}
				this.m_StringPosition = (this.m_StringSelectPosition = 0);
				this.m_TextComponent.rectTransform.localPosition = Vector3.zero;
				if (this.caretRectTrans != null)
				{
					this.caretRectTrans.localPosition = Vector3.zero;
				}
				this.SendOnSubmit();
				if (this.m_HasLostFocus)
				{
					this.SendOnFocusLost();
				}
				Input.imeCompositionMode = IMECompositionMode.Auto;
			}
			this.MarkGeometryAsDirty();
		}

		// Token: 0x06002B77 RID: 11127 RVA: 0x0001F17D File Offset: 0x0001D37D
		public override void OnDeselect(BaseEventData eventData)
		{
			Debug.Log("OnDeselect()");
			this.m_HasLostFocus = true;
			this.DeactivateInputField();
			base.OnDeselect(eventData);
		}

		// Token: 0x06002B78 RID: 11128 RVA: 0x0001F19D File Offset: 0x0001D39D
		public virtual void OnSubmit(BaseEventData eventData)
		{
			Debug.Log("OnSubmit()");
			if (!this.IsActive() || !this.IsInteractable())
			{
				return;
			}
			if (!this.isFocused)
			{
				this.m_ShouldActivateNextUpdate = true;
			}
		}

		// Token: 0x06002B79 RID: 11129 RVA: 0x001048B0 File Offset: 0x00102AB0
		private void EnforceContentType()
		{
			switch (this.contentType)
			{
			case TMP_InputField.ContentType.Standard:
				this.m_InputType = TMP_InputField.InputType.Standard;
				this.m_KeyboardType = TouchScreenKeyboardType.Default;
				this.m_CharacterValidation = TMP_InputField.CharacterValidation.None;
				return;
			case TMP_InputField.ContentType.Autocorrected:
				this.m_InputType = TMP_InputField.InputType.AutoCorrect;
				this.m_KeyboardType = TouchScreenKeyboardType.Default;
				this.m_CharacterValidation = TMP_InputField.CharacterValidation.None;
				return;
			case TMP_InputField.ContentType.IntegerNumber:
				this.m_LineType = TMP_InputField.LineType.SingleLine;
				this.m_TextComponent.enableWordWrapping = false;
				this.m_InputType = TMP_InputField.InputType.Standard;
				this.m_KeyboardType = TouchScreenKeyboardType.NumberPad;
				this.m_CharacterValidation = TMP_InputField.CharacterValidation.Integer;
				return;
			case TMP_InputField.ContentType.DecimalNumber:
				this.m_LineType = TMP_InputField.LineType.SingleLine;
				this.m_TextComponent.enableWordWrapping = false;
				this.m_InputType = TMP_InputField.InputType.Standard;
				this.m_KeyboardType = TouchScreenKeyboardType.NumbersAndPunctuation;
				this.m_CharacterValidation = TMP_InputField.CharacterValidation.Decimal;
				return;
			case TMP_InputField.ContentType.Alphanumeric:
				this.m_LineType = TMP_InputField.LineType.SingleLine;
				this.m_TextComponent.enableWordWrapping = false;
				this.m_InputType = TMP_InputField.InputType.Standard;
				this.m_KeyboardType = TouchScreenKeyboardType.ASCIICapable;
				this.m_CharacterValidation = TMP_InputField.CharacterValidation.Alphanumeric;
				return;
			case TMP_InputField.ContentType.Name:
				this.m_LineType = TMP_InputField.LineType.SingleLine;
				this.m_TextComponent.enableWordWrapping = false;
				this.m_InputType = TMP_InputField.InputType.Standard;
				this.m_KeyboardType = TouchScreenKeyboardType.Default;
				this.m_CharacterValidation = TMP_InputField.CharacterValidation.Name;
				return;
			case TMP_InputField.ContentType.EmailAddress:
				this.m_LineType = TMP_InputField.LineType.SingleLine;
				this.m_TextComponent.enableWordWrapping = false;
				this.m_InputType = TMP_InputField.InputType.Standard;
				this.m_KeyboardType = TouchScreenKeyboardType.EmailAddress;
				this.m_CharacterValidation = TMP_InputField.CharacterValidation.EmailAddress;
				return;
			case TMP_InputField.ContentType.Password:
				this.m_LineType = TMP_InputField.LineType.SingleLine;
				this.m_TextComponent.enableWordWrapping = false;
				this.m_InputType = TMP_InputField.InputType.Password;
				this.m_KeyboardType = TouchScreenKeyboardType.Default;
				this.m_CharacterValidation = TMP_InputField.CharacterValidation.None;
				return;
			case TMP_InputField.ContentType.Pin:
				this.m_LineType = TMP_InputField.LineType.SingleLine;
				this.m_TextComponent.enableWordWrapping = false;
				this.m_InputType = TMP_InputField.InputType.Password;
				this.m_KeyboardType = TouchScreenKeyboardType.NumberPad;
				this.m_CharacterValidation = TMP_InputField.CharacterValidation.Integer;
				return;
			default:
				return;
			}
		}

		// Token: 0x06002B7A RID: 11130 RVA: 0x0001F1D2 File Offset: 0x0001D3D2
		private void SetTextComponentWrapMode()
		{
			if (this.m_TextComponent == null)
			{
				return;
			}
			if (this.m_LineType == TMP_InputField.LineType.SingleLine)
			{
				this.m_TextComponent.enableWordWrapping = false;
			}
			else
			{
				this.m_TextComponent.enableWordWrapping = true;
			}
		}

		// Token: 0x06002B7B RID: 11131 RVA: 0x0001F20E File Offset: 0x0001D40E
		private void SetTextComponentRichTextMode()
		{
			if (this.m_TextComponent == null)
			{
				return;
			}
			this.m_TextComponent.richText = this.m_RichText;
		}

		// Token: 0x06002B7C RID: 11132 RVA: 0x00104A40 File Offset: 0x00102C40
		private void SetToCustomIfContentTypeIsNot(params TMP_InputField.ContentType[] allowedContentTypes)
		{
			if (this.contentType == TMP_InputField.ContentType.Custom)
			{
				return;
			}
			for (int i = 0; i < allowedContentTypes.Length; i++)
			{
				if (this.contentType == allowedContentTypes[i])
				{
					return;
				}
			}
			this.contentType = TMP_InputField.ContentType.Custom;
		}

		// Token: 0x06002B7D RID: 11133 RVA: 0x0001F233 File Offset: 0x0001D433
		private void SetToCustom()
		{
			if (this.contentType == TMP_InputField.ContentType.Custom)
			{
				return;
			}
			this.contentType = TMP_InputField.ContentType.Custom;
		}

		// Token: 0x06002B7E RID: 11134 RVA: 0x0001F24B File Offset: 0x0001D44B
		protected override void DoStateTransition(Selectable.SelectionState state, bool instant)
		{
			if (this.m_HasDoneFocusTransition)
			{
				state = Selectable.SelectionState.Highlighted;
			}
			else if (state == Selectable.SelectionState.Pressed)
			{
				this.m_HasDoneFocusTransition = true;
			}
			base.DoStateTransition(state, instant);
		}

		// Token: 0x06002B80 RID: 11136 RVA: 0x0001F28E File Offset: 0x0001D48E
		Transform ICanvasElement.get_transform()
		{
			return base.transform;
		}

		// Token: 0x06002B81 RID: 11137 RVA: 0x0001F296 File Offset: 0x0001D496
		bool ICanvasElement.IsDestroyed()
		{
			return base.IsDestroyed();
		}

		// Token: 0x04002F5C RID: 12124
		protected TouchScreenKeyboard m_Keyboard;

		// Token: 0x04002F5D RID: 12125
		private static readonly char[] kSeparators = new char[] { ' ', '.', ',', '\t', '\r', '\n' };

		// Token: 0x04002F5E RID: 12126
		[SerializeField]
		protected RectTransform m_TextViewport;

		// Token: 0x04002F5F RID: 12127
		[SerializeField]
		protected TMP_Text m_TextComponent;

		// Token: 0x04002F60 RID: 12128
		protected RectTransform m_TextComponentRectTransform;

		// Token: 0x04002F61 RID: 12129
		[SerializeField]
		protected Graphic m_Placeholder;

		// Token: 0x04002F62 RID: 12130
		[SerializeField]
		private TMP_InputField.ContentType m_ContentType;

		// Token: 0x04002F63 RID: 12131
		[SerializeField]
		private TMP_InputField.InputType m_InputType;

		// Token: 0x04002F64 RID: 12132
		[SerializeField]
		private char m_AsteriskChar = '*';

		// Token: 0x04002F65 RID: 12133
		[SerializeField]
		private TouchScreenKeyboardType m_KeyboardType;

		// Token: 0x04002F66 RID: 12134
		[SerializeField]
		private TMP_InputField.LineType m_LineType;

		// Token: 0x04002F67 RID: 12135
		[SerializeField]
		private bool m_HideMobileInput;

		// Token: 0x04002F68 RID: 12136
		[SerializeField]
		private TMP_InputField.CharacterValidation m_CharacterValidation;

		// Token: 0x04002F69 RID: 12137
		[SerializeField]
		private int m_CharacterLimit;

		// Token: 0x04002F6A RID: 12138
		[SerializeField]
		private TMP_InputField.SubmitEvent m_OnEndEdit = new TMP_InputField.SubmitEvent();

		// Token: 0x04002F6B RID: 12139
		[SerializeField]
		private TMP_InputField.SubmitEvent m_OnSubmit = new TMP_InputField.SubmitEvent();

		// Token: 0x04002F6C RID: 12140
		[SerializeField]
		private TMP_InputField.SubmitEvent m_OnFocusLost = new TMP_InputField.SubmitEvent();

		// Token: 0x04002F6D RID: 12141
		[SerializeField]
		private TMP_InputField.OnChangeEvent m_OnValueChanged = new TMP_InputField.OnChangeEvent();

		// Token: 0x04002F6E RID: 12142
		[SerializeField]
		private TMP_InputField.OnValidateInput m_OnValidateInput;

		// Token: 0x04002F6F RID: 12143
		[SerializeField]
		private Color m_CaretColor = new Color(0.19607843f, 0.19607843f, 0.19607843f, 1f);

		// Token: 0x04002F70 RID: 12144
		[SerializeField]
		private bool m_CustomCaretColor;

		// Token: 0x04002F71 RID: 12145
		[SerializeField]
		private Color m_SelectionColor = new Color(0.65882355f, 0.80784315f, 1f, 0.7529412f);

		// Token: 0x04002F72 RID: 12146
		[SerializeField]
		protected string m_Text = string.Empty;

		// Token: 0x04002F73 RID: 12147
		[SerializeField]
		[Range(0f, 4f)]
		private float m_CaretBlinkRate = 0.85f;

		// Token: 0x04002F74 RID: 12148
		[SerializeField]
		[Range(1f, 5f)]
		private int m_CaretWidth = 1;

		// Token: 0x04002F75 RID: 12149
		[SerializeField]
		private bool m_ReadOnly;

		// Token: 0x04002F76 RID: 12150
		[SerializeField]
		private bool m_RichText = true;

		// Token: 0x04002F77 RID: 12151
		protected int m_StringPosition;

		// Token: 0x04002F78 RID: 12152
		protected int m_StringSelectPosition;

		// Token: 0x04002F79 RID: 12153
		protected int m_CaretPosition;

		// Token: 0x04002F7A RID: 12154
		protected int m_CaretSelectPosition;

		// Token: 0x04002F7B RID: 12155
		private RectTransform caretRectTrans;

		// Token: 0x04002F7C RID: 12156
		protected UIVertex[] m_CursorVerts;

		// Token: 0x04002F7D RID: 12157
		private CanvasRenderer m_CachedInputRenderer;

		// Token: 0x04002F7E RID: 12158
		[NonSerialized]
		protected Mesh m_Mesh;

		// Token: 0x04002F7F RID: 12159
		private bool m_AllowInput;

		// Token: 0x04002F80 RID: 12160
		private bool m_HasLostFocus;

		// Token: 0x04002F81 RID: 12161
		private bool m_ShouldActivateNextUpdate;

		// Token: 0x04002F82 RID: 12162
		private bool m_UpdateDrag;

		// Token: 0x04002F83 RID: 12163
		private bool m_DragPositionOutOfBounds;

		// Token: 0x04002F84 RID: 12164
		private const float kHScrollSpeed = 0.05f;

		// Token: 0x04002F85 RID: 12165
		private const float kVScrollSpeed = 0.1f;

		// Token: 0x04002F86 RID: 12166
		protected bool m_CaretVisible;

		// Token: 0x04002F87 RID: 12167
		private Coroutine m_BlinkCoroutine;

		// Token: 0x04002F88 RID: 12168
		private float m_BlinkStartTime;

		// Token: 0x04002F89 RID: 12169
		protected int m_DrawStart;

		// Token: 0x04002F8A RID: 12170
		protected int m_DrawEnd;

		// Token: 0x04002F8B RID: 12171
		private Coroutine m_DragCoroutine;

		// Token: 0x04002F8C RID: 12172
		private string m_OriginalText = string.Empty;

		// Token: 0x04002F8D RID: 12173
		private bool m_WasCanceled;

		// Token: 0x04002F8E RID: 12174
		private bool m_HasDoneFocusTransition;

		// Token: 0x04002F8F RID: 12175
		private bool m_isLastKeyBackspace;

		// Token: 0x04002F90 RID: 12176
		private const string kEmailSpecialCharacters = "!#$%&'*+-/=?^_`{|}~";

		// Token: 0x04002F91 RID: 12177
		private bool isCaretInsideTag;

		// Token: 0x04002F92 RID: 12178
		private Event m_ProcessingEvent = new Event();

		// Token: 0x02000605 RID: 1541
		public enum ContentType
		{
			// Token: 0x04002F94 RID: 12180
			Standard,
			// Token: 0x04002F95 RID: 12181
			Autocorrected,
			// Token: 0x04002F96 RID: 12182
			IntegerNumber,
			// Token: 0x04002F97 RID: 12183
			DecimalNumber,
			// Token: 0x04002F98 RID: 12184
			Alphanumeric,
			// Token: 0x04002F99 RID: 12185
			Name,
			// Token: 0x04002F9A RID: 12186
			EmailAddress,
			// Token: 0x04002F9B RID: 12187
			Password,
			// Token: 0x04002F9C RID: 12188
			Pin,
			// Token: 0x04002F9D RID: 12189
			Custom
		}

		// Token: 0x02000606 RID: 1542
		public enum InputType
		{
			// Token: 0x04002F9F RID: 12191
			Standard,
			// Token: 0x04002FA0 RID: 12192
			AutoCorrect,
			// Token: 0x04002FA1 RID: 12193
			Password
		}

		// Token: 0x02000607 RID: 1543
		public enum CharacterValidation
		{
			// Token: 0x04002FA3 RID: 12195
			None,
			// Token: 0x04002FA4 RID: 12196
			Integer,
			// Token: 0x04002FA5 RID: 12197
			Decimal,
			// Token: 0x04002FA6 RID: 12198
			Alphanumeric,
			// Token: 0x04002FA7 RID: 12199
			Name,
			// Token: 0x04002FA8 RID: 12200
			EmailAddress
		}

		// Token: 0x02000608 RID: 1544
		public enum LineType
		{
			// Token: 0x04002FAA RID: 12202
			SingleLine,
			// Token: 0x04002FAB RID: 12203
			MultiLineSubmit,
			// Token: 0x04002FAC RID: 12204
			MultiLineNewline
		}

		// Token: 0x02000609 RID: 1545
		// (Invoke) Token: 0x06002B83 RID: 11139
		public delegate char OnValidateInput(string text, int charIndex, char addedChar);

		// Token: 0x0200060A RID: 1546
		[Serializable]
		public class SubmitEvent : UnityEvent<string>
		{
		}

		// Token: 0x0200060B RID: 1547
		[Serializable]
		public class OnChangeEvent : UnityEvent<string>
		{
		}

		// Token: 0x0200060C RID: 1548
		protected enum EditState
		{
			// Token: 0x04002FAE RID: 12206
			Continue,
			// Token: 0x04002FAF RID: 12207
			Finish
		}
	}
}
