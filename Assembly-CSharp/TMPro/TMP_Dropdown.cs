using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace TMPro
{
	// Token: 0x020005FA RID: 1530
	[AddComponentMenu("UI/TMP Dropdown", 35)]
	[RequireComponent(typeof(RectTransform))]
	public class TMP_Dropdown : Selectable, IPointerClickHandler, ISubmitHandler, ICancelHandler, IEventSystemHandler
	{
		// Token: 0x06002A93 RID: 10899 RVA: 0x0001E7E8 File Offset: 0x0001C9E8
		protected TMP_Dropdown()
		{
		}

		// Token: 0x1700043C RID: 1084
		// (get) Token: 0x06002A94 RID: 10900 RVA: 0x0001E811 File Offset: 0x0001CA11
		// (set) Token: 0x06002A95 RID: 10901 RVA: 0x0001E819 File Offset: 0x0001CA19
		public RectTransform template
		{
			get
			{
				return this.m_Template;
			}
			set
			{
				this.m_Template = value;
				this.RefreshShownValue();
			}
		}

		// Token: 0x1700043D RID: 1085
		// (get) Token: 0x06002A96 RID: 10902 RVA: 0x0001E828 File Offset: 0x0001CA28
		// (set) Token: 0x06002A97 RID: 10903 RVA: 0x0001E830 File Offset: 0x0001CA30
		public TMP_Text captionText
		{
			get
			{
				return this.m_CaptionText;
			}
			set
			{
				this.m_CaptionText = value;
				this.RefreshShownValue();
			}
		}

		// Token: 0x1700043E RID: 1086
		// (get) Token: 0x06002A98 RID: 10904 RVA: 0x0001E83F File Offset: 0x0001CA3F
		// (set) Token: 0x06002A99 RID: 10905 RVA: 0x0001E847 File Offset: 0x0001CA47
		public Image captionImage
		{
			get
			{
				return this.m_CaptionImage;
			}
			set
			{
				this.m_CaptionImage = value;
				this.RefreshShownValue();
			}
		}

		// Token: 0x1700043F RID: 1087
		// (get) Token: 0x06002A9A RID: 10906 RVA: 0x0001E856 File Offset: 0x0001CA56
		// (set) Token: 0x06002A9B RID: 10907 RVA: 0x0001E85E File Offset: 0x0001CA5E
		public TMP_Text itemText
		{
			get
			{
				return this.m_ItemText;
			}
			set
			{
				this.m_ItemText = value;
				this.RefreshShownValue();
			}
		}

		// Token: 0x17000440 RID: 1088
		// (get) Token: 0x06002A9C RID: 10908 RVA: 0x0001E86D File Offset: 0x0001CA6D
		// (set) Token: 0x06002A9D RID: 10909 RVA: 0x0001E875 File Offset: 0x0001CA75
		public Image itemImage
		{
			get
			{
				return this.m_ItemImage;
			}
			set
			{
				this.m_ItemImage = value;
				this.RefreshShownValue();
			}
		}

		// Token: 0x17000441 RID: 1089
		// (get) Token: 0x06002A9E RID: 10910 RVA: 0x0001E884 File Offset: 0x0001CA84
		// (set) Token: 0x06002A9F RID: 10911 RVA: 0x0001E891 File Offset: 0x0001CA91
		public List<TMP_Dropdown.OptionData> options
		{
			get
			{
				return this.m_Options.options;
			}
			set
			{
				this.m_Options.options = value;
				this.RefreshShownValue();
			}
		}

		// Token: 0x17000442 RID: 1090
		// (get) Token: 0x06002AA0 RID: 10912 RVA: 0x0001E8A5 File Offset: 0x0001CAA5
		// (set) Token: 0x06002AA1 RID: 10913 RVA: 0x0001E8AD File Offset: 0x0001CAAD
		public TMP_Dropdown.DropdownEvent onValueChanged
		{
			get
			{
				return this.m_OnValueChanged;
			}
			set
			{
				this.m_OnValueChanged = value;
			}
		}

		// Token: 0x17000443 RID: 1091
		// (get) Token: 0x06002AA2 RID: 10914 RVA: 0x0001E8B6 File Offset: 0x0001CAB6
		// (set) Token: 0x06002AA3 RID: 10915 RVA: 0x001004CC File Offset: 0x000FE6CC
		public int value
		{
			get
			{
				return this.m_Value;
			}
			set
			{
				if (Application.isPlaying && (value == this.m_Value || this.options.Count == 0))
				{
					return;
				}
				this.m_Value = Mathf.Clamp(value, 0, this.options.Count - 1);
				this.RefreshShownValue();
				this.m_OnValueChanged.Invoke(this.m_Value);
			}
		}

		// Token: 0x06002AA4 RID: 10916 RVA: 0x00100534 File Offset: 0x000FE734
		protected override void Awake()
		{
			this.m_AlphaTweenRunner = new TweenRunner<FloatTween>();
			this.m_AlphaTweenRunner.Init(this);
			if (this.m_CaptionImage)
			{
				this.m_CaptionImage.enabled = this.m_CaptionImage.sprite != null;
			}
			if (this.m_Template)
			{
				this.m_Template.gameObject.SetActive(false);
			}
		}

		// Token: 0x06002AA5 RID: 10917 RVA: 0x001005A8 File Offset: 0x000FE7A8
		public void RefreshShownValue()
		{
			TMP_Dropdown.OptionData optionData = TMP_Dropdown.s_NoOptionData;
			if (this.options.Count > 0)
			{
				optionData = this.options[Mathf.Clamp(this.m_Value, 0, this.options.Count - 1)];
			}
			if (this.m_CaptionText)
			{
				if (optionData != null && optionData.text != null)
				{
					this.m_CaptionText.text = optionData.text;
				}
				else
				{
					this.m_CaptionText.text = string.Empty;
				}
			}
			if (this.m_CaptionImage)
			{
				if (optionData != null)
				{
					this.m_CaptionImage.sprite = optionData.image;
				}
				else
				{
					this.m_CaptionImage.sprite = null;
				}
				this.m_CaptionImage.enabled = this.m_CaptionImage.sprite != null;
			}
		}

		// Token: 0x06002AA6 RID: 10918 RVA: 0x0001E8BE File Offset: 0x0001CABE
		public void AddOptions(List<TMP_Dropdown.OptionData> options)
		{
			this.options.AddRange(options);
			this.RefreshShownValue();
		}

		// Token: 0x06002AA7 RID: 10919 RVA: 0x0010068C File Offset: 0x000FE88C
		public void AddOptions(List<string> options)
		{
			for (int i = 0; i < options.Count; i++)
			{
				this.options.Add(new TMP_Dropdown.OptionData(options[i]));
			}
			this.RefreshShownValue();
		}

		// Token: 0x06002AA8 RID: 10920 RVA: 0x001006D0 File Offset: 0x000FE8D0
		public void AddOptions(List<Sprite> options)
		{
			for (int i = 0; i < options.Count; i++)
			{
				this.options.Add(new TMP_Dropdown.OptionData(options[i]));
			}
			this.RefreshShownValue();
		}

		// Token: 0x06002AA9 RID: 10921 RVA: 0x0001E8D2 File Offset: 0x0001CAD2
		public void ClearOptions()
		{
			this.options.Clear();
			this.RefreshShownValue();
		}

		// Token: 0x06002AAA RID: 10922 RVA: 0x00100714 File Offset: 0x000FE914
		private void SetupTemplate()
		{
			this.validTemplate = false;
			if (!this.m_Template)
			{
				Debug.LogError("The dropdown template is not assigned. The template needs to be assigned and must have a child GameObject with a Toggle component serving as the item.", this);
				return;
			}
			GameObject gameObject = this.m_Template.gameObject;
			gameObject.SetActive(true);
			Toggle componentInChildren = this.m_Template.GetComponentInChildren<Toggle>();
			this.validTemplate = true;
			if (!componentInChildren || componentInChildren.transform == this.template)
			{
				this.validTemplate = false;
				Debug.LogError("The dropdown template is not valid. The template must have a child GameObject with a Toggle component serving as the item.", this.template);
			}
			else if (!(componentInChildren.transform.parent is RectTransform))
			{
				this.validTemplate = false;
				Debug.LogError("The dropdown template is not valid. The child GameObject with a Toggle component (the item) must have a RectTransform on its parent.", this.template);
			}
			else if (this.itemText != null && !this.itemText.transform.IsChildOf(componentInChildren.transform))
			{
				this.validTemplate = false;
				Debug.LogError("The dropdown template is not valid. The Item Text must be on the item GameObject or children of it.", this.template);
			}
			else if (this.itemImage != null && !this.itemImage.transform.IsChildOf(componentInChildren.transform))
			{
				this.validTemplate = false;
				Debug.LogError("The dropdown template is not valid. The Item Image must be on the item GameObject or children of it.", this.template);
			}
			if (!this.validTemplate)
			{
				gameObject.SetActive(false);
				return;
			}
			TMP_Dropdown.DropdownItem dropdownItem = componentInChildren.gameObject.AddComponent<TMP_Dropdown.DropdownItem>();
			dropdownItem.text = this.m_ItemText;
			dropdownItem.image = this.m_ItemImage;
			dropdownItem.toggle = componentInChildren;
			dropdownItem.rectTransform = (RectTransform)componentInChildren.transform;
			Canvas orAddComponent = TMP_Dropdown.GetOrAddComponent<Canvas>(gameObject);
			orAddComponent.overrideSorting = true;
			orAddComponent.sortingOrder = 30000;
			TMP_Dropdown.GetOrAddComponent<GraphicRaycaster>(gameObject);
			TMP_Dropdown.GetOrAddComponent<CanvasGroup>(gameObject);
			gameObject.SetActive(false);
			this.validTemplate = true;
		}

		// Token: 0x06002AAB RID: 10923 RVA: 0x001008E8 File Offset: 0x000FEAE8
		private static T GetOrAddComponent<T>(GameObject go) where T : Component
		{
			T t = go.GetComponent<T>();
			if (!t)
			{
				t = go.AddComponent<T>();
			}
			return t;
		}

		// Token: 0x06002AAC RID: 10924 RVA: 0x0001E8E5 File Offset: 0x0001CAE5
		public virtual void OnPointerClick(PointerEventData eventData)
		{
			this.Show();
		}

		// Token: 0x06002AAD RID: 10925 RVA: 0x0001E8E5 File Offset: 0x0001CAE5
		public virtual void OnSubmit(BaseEventData eventData)
		{
			this.Show();
		}

		// Token: 0x06002AAE RID: 10926 RVA: 0x0001E8ED File Offset: 0x0001CAED
		public virtual void OnCancel(BaseEventData eventData)
		{
			this.Hide();
		}

		// Token: 0x06002AAF RID: 10927 RVA: 0x00100914 File Offset: 0x000FEB14
		public void Show()
		{
			if (!this.IsActive() || !this.IsInteractable() || this.m_Dropdown != null)
			{
				return;
			}
			if (!this.validTemplate)
			{
				this.SetupTemplate();
				if (!this.validTemplate)
				{
					return;
				}
			}
			List<Canvas> list = TMP_ListPool<Canvas>.Get();
			base.gameObject.GetComponentsInParent<Canvas>(false, list);
			if (list.Count == 0)
			{
				return;
			}
			Canvas canvas = list[0];
			TMP_ListPool<Canvas>.Release(list);
			this.m_Template.gameObject.SetActive(true);
			this.m_Dropdown = this.CreateDropdownList(this.m_Template.gameObject);
			this.m_Dropdown.name = "Dropdown List";
			this.m_Dropdown.SetActive(true);
			RectTransform rectTransform = this.m_Dropdown.transform as RectTransform;
			rectTransform.SetParent(this.m_Template.transform.parent, false);
			TMP_Dropdown.DropdownItem componentInChildren = this.m_Dropdown.GetComponentInChildren<TMP_Dropdown.DropdownItem>();
			GameObject gameObject = componentInChildren.rectTransform.parent.gameObject;
			RectTransform rectTransform2 = gameObject.transform as RectTransform;
			componentInChildren.rectTransform.gameObject.SetActive(true);
			Rect rect = rectTransform2.rect;
			Rect rect2 = componentInChildren.rectTransform.rect;
			Vector2 vector = rect2.min - rect.min + componentInChildren.rectTransform.localPosition;
			Vector2 vector2 = rect2.max - rect.max + componentInChildren.rectTransform.localPosition;
			Vector2 size = rect2.size;
			this.m_Items.Clear();
			Toggle toggle = null;
			for (int i = 0; i < this.options.Count; i++)
			{
				TMP_Dropdown.OptionData optionData = this.options[i];
				TMP_Dropdown.DropdownItem item = this.AddItem(optionData, this.value == i, componentInChildren, this.m_Items);
				if (!(item == null))
				{
					item.toggle.isOn = this.value == i;
					item.toggle.onValueChanged.AddListener(delegate(bool x)
					{
						this.OnSelectItem(item.toggle);
					});
					if (item.toggle.isOn)
					{
						item.toggle.Select();
					}
					if (toggle != null)
					{
						Navigation navigation = toggle.navigation;
						Navigation navigation2 = item.toggle.navigation;
						navigation.mode = Navigation.Mode.Explicit;
						navigation2.mode = Navigation.Mode.Explicit;
						navigation.selectOnDown = item.toggle;
						navigation.selectOnRight = item.toggle;
						navigation2.selectOnLeft = toggle;
						navigation2.selectOnUp = toggle;
						toggle.navigation = navigation;
						item.toggle.navigation = navigation2;
					}
					toggle = item.toggle;
				}
			}
			Vector2 sizeDelta = rectTransform2.sizeDelta;
			sizeDelta.y = size.y * (float)this.m_Items.Count + vector.y - vector2.y;
			rectTransform2.sizeDelta = sizeDelta;
			float num = rectTransform.rect.height - rectTransform2.rect.height;
			if (num > 0f)
			{
				rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, rectTransform.sizeDelta.y - num);
			}
			Vector3[] array = new Vector3[4];
			rectTransform.GetWorldCorners(array);
			RectTransform rectTransform3 = canvas.transform as RectTransform;
			Rect rect3 = rectTransform3.rect;
			for (int j = 0; j < 2; j++)
			{
				bool flag = false;
				for (int k = 0; k < 4; k++)
				{
					Vector3 vector3 = rectTransform3.InverseTransformPoint(array[k]);
					if (vector3[j] < rect3.min[j] || vector3[j] > rect3.max[j])
					{
						flag = true;
						break;
					}
				}
				if (flag)
				{
					RectTransformUtility.FlipLayoutOnAxis(rectTransform, j, false, false);
				}
			}
			for (int l = 0; l < this.m_Items.Count; l++)
			{
				RectTransform rectTransform4 = this.m_Items[l].rectTransform;
				rectTransform4.anchorMin = new Vector2(rectTransform4.anchorMin.x, 0f);
				rectTransform4.anchorMax = new Vector2(rectTransform4.anchorMax.x, 0f);
				rectTransform4.anchoredPosition = new Vector2(rectTransform4.anchoredPosition.x, vector.y + size.y * (float)(this.m_Items.Count - 1 - l) + size.y * rectTransform4.pivot.y);
				rectTransform4.sizeDelta = new Vector2(rectTransform4.sizeDelta.x, size.y);
			}
			this.AlphaFadeList(0.15f, 0f, 1f);
			this.m_Template.gameObject.SetActive(false);
			componentInChildren.gameObject.SetActive(false);
			this.m_Blocker = this.CreateBlocker(canvas);
		}

		// Token: 0x06002AB0 RID: 10928 RVA: 0x00100EBC File Offset: 0x000FF0BC
		protected virtual GameObject CreateBlocker(Canvas rootCanvas)
		{
			GameObject gameObject = new GameObject("Blocker");
			RectTransform rectTransform = gameObject.AddComponent<RectTransform>();
			rectTransform.SetParent(rootCanvas.transform, false);
			rectTransform.anchorMin = Vector3.zero;
			rectTransform.anchorMax = Vector3.one;
			rectTransform.sizeDelta = Vector2.zero;
			Canvas canvas = gameObject.AddComponent<Canvas>();
			canvas.overrideSorting = true;
			Canvas component = this.m_Dropdown.GetComponent<Canvas>();
			canvas.sortingLayerID = component.sortingLayerID;
			canvas.sortingOrder = component.sortingOrder - 1;
			gameObject.AddComponent<GraphicRaycaster>();
			Image image = gameObject.AddComponent<Image>();
			image.color = Color.clear;
			Button button = gameObject.AddComponent<Button>();
			button.onClick.AddListener(new UnityAction(this.Hide));
			return gameObject;
		}

		// Token: 0x06002AB1 RID: 10929 RVA: 0x0001E8F5 File Offset: 0x0001CAF5
		protected virtual void DestroyBlocker(GameObject blocker)
		{
			global::UnityEngine.Object.Destroy(blocker);
		}

		// Token: 0x06002AB2 RID: 10930 RVA: 0x0001E8FD File Offset: 0x0001CAFD
		protected virtual GameObject CreateDropdownList(GameObject template)
		{
			return global::UnityEngine.Object.Instantiate<GameObject>(template);
		}

		// Token: 0x06002AB3 RID: 10931 RVA: 0x0001E8F5 File Offset: 0x0001CAF5
		protected virtual void DestroyDropdownList(GameObject dropdownList)
		{
			global::UnityEngine.Object.Destroy(dropdownList);
		}

		// Token: 0x06002AB4 RID: 10932 RVA: 0x0001E905 File Offset: 0x0001CB05
		protected virtual TMP_Dropdown.DropdownItem CreateItem(TMP_Dropdown.DropdownItem itemTemplate)
		{
			return global::UnityEngine.Object.Instantiate<TMP_Dropdown.DropdownItem>(itemTemplate);
		}

		// Token: 0x06002AB5 RID: 10933 RVA: 0x00002482 File Offset: 0x00000682
		protected virtual void DestroyItem(TMP_Dropdown.DropdownItem item)
		{
		}

		// Token: 0x06002AB6 RID: 10934 RVA: 0x00100F84 File Offset: 0x000FF184
		private TMP_Dropdown.DropdownItem AddItem(TMP_Dropdown.OptionData data, bool selected, TMP_Dropdown.DropdownItem itemTemplate, List<TMP_Dropdown.DropdownItem> items)
		{
			TMP_Dropdown.DropdownItem dropdownItem = this.CreateItem(itemTemplate);
			dropdownItem.rectTransform.SetParent(itemTemplate.rectTransform.parent, false);
			dropdownItem.gameObject.SetActive(true);
			dropdownItem.gameObject.name = "Item " + items.Count + ((data.text == null) ? string.Empty : (": " + data.text));
			if (dropdownItem.toggle != null)
			{
				dropdownItem.toggle.isOn = false;
			}
			if (dropdownItem.text)
			{
				dropdownItem.text.text = data.text;
			}
			if (dropdownItem.image)
			{
				dropdownItem.image.sprite = data.image;
				dropdownItem.image.enabled = dropdownItem.image.sprite != null;
			}
			items.Add(dropdownItem);
			return dropdownItem;
		}

		// Token: 0x06002AB7 RID: 10935 RVA: 0x00101088 File Offset: 0x000FF288
		private void AlphaFadeList(float duration, float alpha)
		{
			CanvasGroup component = this.m_Dropdown.GetComponent<CanvasGroup>();
			this.AlphaFadeList(duration, component.alpha, alpha);
		}

		// Token: 0x06002AB8 RID: 10936 RVA: 0x001010B0 File Offset: 0x000FF2B0
		private void AlphaFadeList(float duration, float start, float end)
		{
			if (end.Equals(start))
			{
				return;
			}
			FloatTween floatTween = new FloatTween
			{
				duration = duration,
				startValue = start,
				targetValue = end
			};
			floatTween.AddOnChangedCallback(new UnityAction<float>(this.SetAlpha));
			floatTween.ignoreTimeScale = true;
			this.m_AlphaTweenRunner.StartTween(floatTween);
		}

		// Token: 0x06002AB9 RID: 10937 RVA: 0x00101114 File Offset: 0x000FF314
		private void SetAlpha(float alpha)
		{
			if (!this.m_Dropdown)
			{
				return;
			}
			CanvasGroup component = this.m_Dropdown.GetComponent<CanvasGroup>();
			component.alpha = alpha;
		}

		// Token: 0x06002ABA RID: 10938 RVA: 0x00101148 File Offset: 0x000FF348
		public void Hide()
		{
			if (this.m_Dropdown != null)
			{
				this.AlphaFadeList(0.15f, 0f);
				if (this.IsActive())
				{
					base.StartCoroutine(this.DelayedDestroyDropdownList(0.15f));
				}
			}
			if (this.m_Blocker != null)
			{
				this.DestroyBlocker(this.m_Blocker);
			}
			this.m_Blocker = null;
			this.Select();
		}

		// Token: 0x06002ABB RID: 10939 RVA: 0x001011C0 File Offset: 0x000FF3C0
		private IEnumerator DelayedDestroyDropdownList(float delay)
		{
			yield return new WaitForSeconds(delay);
			for (int i = 0; i < this.m_Items.Count; i++)
			{
				if (this.m_Items[i] != null)
				{
					this.DestroyItem(this.m_Items[i]);
				}
				this.m_Items.Clear();
			}
			if (this.m_Dropdown != null)
			{
				this.DestroyDropdownList(this.m_Dropdown);
			}
			this.m_Dropdown = null;
			yield break;
		}

		// Token: 0x06002ABC RID: 10940 RVA: 0x001011E4 File Offset: 0x000FF3E4
		private void OnSelectItem(Toggle toggle)
		{
			if (!toggle.isOn)
			{
				toggle.isOn = true;
			}
			int num = -1;
			Transform transform = toggle.transform;
			Transform parent = transform.parent;
			for (int i = 0; i < parent.childCount; i++)
			{
				if (parent.GetChild(i) == transform)
				{
					num = i - 1;
					break;
				}
			}
			if (num < 0)
			{
				return;
			}
			this.value = num;
			this.Hide();
		}

		// Token: 0x04002F25 RID: 12069
		[SerializeField]
		private RectTransform m_Template;

		// Token: 0x04002F26 RID: 12070
		[SerializeField]
		private TMP_Text m_CaptionText;

		// Token: 0x04002F27 RID: 12071
		[SerializeField]
		private Image m_CaptionImage;

		// Token: 0x04002F28 RID: 12072
		[Space]
		[SerializeField]
		private TMP_Text m_ItemText;

		// Token: 0x04002F29 RID: 12073
		[SerializeField]
		private Image m_ItemImage;

		// Token: 0x04002F2A RID: 12074
		[Space]
		[SerializeField]
		private int m_Value;

		// Token: 0x04002F2B RID: 12075
		[Space]
		[SerializeField]
		private TMP_Dropdown.OptionDataList m_Options = new TMP_Dropdown.OptionDataList();

		// Token: 0x04002F2C RID: 12076
		[Space]
		[SerializeField]
		private TMP_Dropdown.DropdownEvent m_OnValueChanged = new TMP_Dropdown.DropdownEvent();

		// Token: 0x04002F2D RID: 12077
		private GameObject m_Dropdown;

		// Token: 0x04002F2E RID: 12078
		private GameObject m_Blocker;

		// Token: 0x04002F2F RID: 12079
		private List<TMP_Dropdown.DropdownItem> m_Items = new List<TMP_Dropdown.DropdownItem>();

		// Token: 0x04002F30 RID: 12080
		private TweenRunner<FloatTween> m_AlphaTweenRunner;

		// Token: 0x04002F31 RID: 12081
		private bool validTemplate;

		// Token: 0x04002F32 RID: 12082
		private static TMP_Dropdown.OptionData s_NoOptionData = new TMP_Dropdown.OptionData();

		// Token: 0x020005FB RID: 1531
		protected internal class DropdownItem : MonoBehaviour, IPointerEnterHandler, ICancelHandler, IEventSystemHandler
		{
			// Token: 0x17000444 RID: 1092
			// (get) Token: 0x06002ABF RID: 10943 RVA: 0x0001E919 File Offset: 0x0001CB19
			// (set) Token: 0x06002AC0 RID: 10944 RVA: 0x0001E921 File Offset: 0x0001CB21
			public TMP_Text text
			{
				get
				{
					return this.m_Text;
				}
				set
				{
					this.m_Text = value;
				}
			}

			// Token: 0x17000445 RID: 1093
			// (get) Token: 0x06002AC1 RID: 10945 RVA: 0x0001E92A File Offset: 0x0001CB2A
			// (set) Token: 0x06002AC2 RID: 10946 RVA: 0x0001E932 File Offset: 0x0001CB32
			public Image image
			{
				get
				{
					return this.m_Image;
				}
				set
				{
					this.m_Image = value;
				}
			}

			// Token: 0x17000446 RID: 1094
			// (get) Token: 0x06002AC3 RID: 10947 RVA: 0x0001E93B File Offset: 0x0001CB3B
			// (set) Token: 0x06002AC4 RID: 10948 RVA: 0x0001E943 File Offset: 0x0001CB43
			public RectTransform rectTransform
			{
				get
				{
					return this.m_RectTransform;
				}
				set
				{
					this.m_RectTransform = value;
				}
			}

			// Token: 0x17000447 RID: 1095
			// (get) Token: 0x06002AC5 RID: 10949 RVA: 0x0001E94C File Offset: 0x0001CB4C
			// (set) Token: 0x06002AC6 RID: 10950 RVA: 0x0001E954 File Offset: 0x0001CB54
			public Toggle toggle
			{
				get
				{
					return this.m_Toggle;
				}
				set
				{
					this.m_Toggle = value;
				}
			}

			// Token: 0x06002AC7 RID: 10951 RVA: 0x0001E95D File Offset: 0x0001CB5D
			public virtual void OnPointerEnter(PointerEventData eventData)
			{
				EventSystem.current.SetSelectedGameObject(base.gameObject);
			}

			// Token: 0x06002AC8 RID: 10952 RVA: 0x0010125C File Offset: 0x000FF45C
			public virtual void OnCancel(BaseEventData eventData)
			{
				TMP_Dropdown componentInParent = base.GetComponentInParent<TMP_Dropdown>();
				if (componentInParent)
				{
					componentInParent.Hide();
				}
			}

			// Token: 0x04002F33 RID: 12083
			[SerializeField]
			private TMP_Text m_Text;

			// Token: 0x04002F34 RID: 12084
			[SerializeField]
			private Image m_Image;

			// Token: 0x04002F35 RID: 12085
			[SerializeField]
			private RectTransform m_RectTransform;

			// Token: 0x04002F36 RID: 12086
			[SerializeField]
			private Toggle m_Toggle;
		}

		// Token: 0x020005FC RID: 1532
		[Serializable]
		public class OptionData
		{
			// Token: 0x06002AC9 RID: 10953 RVA: 0x000026AE File Offset: 0x000008AE
			public OptionData()
			{
			}

			// Token: 0x06002ACA RID: 10954 RVA: 0x0001E96F File Offset: 0x0001CB6F
			public OptionData(string text)
			{
				this.text = text;
			}

			// Token: 0x06002ACB RID: 10955 RVA: 0x0001E97E File Offset: 0x0001CB7E
			public OptionData(Sprite image)
			{
				this.image = image;
			}

			// Token: 0x06002ACC RID: 10956 RVA: 0x0001E98D File Offset: 0x0001CB8D
			public OptionData(string text, Sprite image)
			{
				this.text = text;
				this.image = image;
			}

			// Token: 0x17000448 RID: 1096
			// (get) Token: 0x06002ACD RID: 10957 RVA: 0x0001E9A3 File Offset: 0x0001CBA3
			// (set) Token: 0x06002ACE RID: 10958 RVA: 0x0001E9AB File Offset: 0x0001CBAB
			public string text
			{
				get
				{
					return this.m_Text;
				}
				set
				{
					this.m_Text = value;
				}
			}

			// Token: 0x17000449 RID: 1097
			// (get) Token: 0x06002ACF RID: 10959 RVA: 0x0001E9B4 File Offset: 0x0001CBB4
			// (set) Token: 0x06002AD0 RID: 10960 RVA: 0x0001E9BC File Offset: 0x0001CBBC
			public Sprite image
			{
				get
				{
					return this.m_Image;
				}
				set
				{
					this.m_Image = value;
				}
			}

			// Token: 0x04002F37 RID: 12087
			[SerializeField]
			private string m_Text;

			// Token: 0x04002F38 RID: 12088
			[SerializeField]
			private Sprite m_Image;
		}

		// Token: 0x020005FD RID: 1533
		[Serializable]
		public class OptionDataList
		{
			// Token: 0x06002AD1 RID: 10961 RVA: 0x0001E9C5 File Offset: 0x0001CBC5
			public OptionDataList()
			{
				this.options = new List<TMP_Dropdown.OptionData>();
			}

			// Token: 0x1700044A RID: 1098
			// (get) Token: 0x06002AD2 RID: 10962 RVA: 0x0001E9D8 File Offset: 0x0001CBD8
			// (set) Token: 0x06002AD3 RID: 10963 RVA: 0x0001E9E0 File Offset: 0x0001CBE0
			public List<TMP_Dropdown.OptionData> options
			{
				get
				{
					return this.m_Options;
				}
				set
				{
					this.m_Options = value;
				}
			}

			// Token: 0x04002F39 RID: 12089
			[SerializeField]
			private List<TMP_Dropdown.OptionData> m_Options;
		}

		// Token: 0x020005FE RID: 1534
		[Serializable]
		public class DropdownEvent : UnityEvent<int>
		{
		}
	}
}
