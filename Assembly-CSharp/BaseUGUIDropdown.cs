using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020002B6 RID: 694
[RequireComponent(typeof(Dropdown))]
public class BaseUGUIDropdown : MonoBehaviour
{
	// Token: 0x040016F9 RID: 5881
	[SerializeField]
	public TextMeshProUGUI CaptionText;

	// Token: 0x040016FA RID: 5882
	[SerializeField]
	public TextMeshProUGUI ItemTextMeshPro;

	// Token: 0x040016FB RID: 5883
	[SerializeField]
	public Dropdown Dropdown;
}
