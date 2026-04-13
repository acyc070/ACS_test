using System;
using UnityEngine;

namespace TMPro
{
	// Token: 0x0200063C RID: 1596
	public static class TMPro_EventManager
	{
		// Token: 0x06002D68 RID: 11624 RVA: 0x000208E6 File Offset: 0x0001EAE6
		public static void ON_PRE_RENDER_OBJECT_CHANGED()
		{
			TMPro_EventManager.OnPreRenderObject_Event.Call();
		}

		// Token: 0x06002D69 RID: 11625 RVA: 0x000208F2 File Offset: 0x0001EAF2
		public static void ON_MATERIAL_PROPERTY_CHANGED(bool isChanged, Material mat)
		{
			TMPro_EventManager.MATERIAL_PROPERTY_EVENT.Call(isChanged, mat);
		}

		// Token: 0x06002D6A RID: 11626 RVA: 0x00020900 File Offset: 0x0001EB00
		public static void ON_FONT_PROPERTY_CHANGED(bool isChanged, TMP_FontAsset font)
		{
			TMPro_EventManager.FONT_PROPERTY_EVENT.Call(isChanged, font);
		}

		// Token: 0x06002D6B RID: 11627 RVA: 0x0002090E File Offset: 0x0001EB0E
		public static void ON_SPRITE_ASSET_PROPERTY_CHANGED(bool isChanged, global::UnityEngine.Object obj)
		{
			TMPro_EventManager.SPRITE_ASSET_PROPERTY_EVENT.Call(isChanged, obj);
		}

		// Token: 0x06002D6C RID: 11628 RVA: 0x0002091C File Offset: 0x0001EB1C
		public static void ON_TEXTMESHPRO_PROPERTY_CHANGED(bool isChanged, TextMeshPro obj)
		{
			TMPro_EventManager.TEXTMESHPRO_PROPERTY_EVENT.Call(isChanged, obj);
		}

		// Token: 0x06002D6D RID: 11629 RVA: 0x0002092A File Offset: 0x0001EB2A
		public static void ON_DRAG_AND_DROP_MATERIAL_CHANGED(GameObject sender, Material currentMaterial, Material newMaterial)
		{
			TMPro_EventManager.DRAG_AND_DROP_MATERIAL_EVENT.Call(sender, currentMaterial, newMaterial);
		}

		// Token: 0x06002D6E RID: 11630 RVA: 0x00020939 File Offset: 0x0001EB39
		public static void ON_TEXT_STYLE_PROPERTY_CHANGED(bool isChanged)
		{
			TMPro_EventManager.TEXT_STYLE_PROPERTY_EVENT.Call(isChanged);
		}

		// Token: 0x06002D6F RID: 11631 RVA: 0x00020946 File Offset: 0x0001EB46
		public static void ON_COLOR_GRAIDENT_PROPERTY_CHANGED(TMP_ColorGradient gradient)
		{
			TMPro_EventManager.COLOR_GRADIENT_PROPERTY_EVENT.Call(gradient);
		}

		// Token: 0x06002D70 RID: 11632 RVA: 0x00020953 File Offset: 0x0001EB53
		public static void ON_TEXT_CHANGED(global::UnityEngine.Object obj)
		{
			TMPro_EventManager.TEXT_CHANGED_EVENT.Call(obj);
		}

		// Token: 0x06002D71 RID: 11633 RVA: 0x00020960 File Offset: 0x0001EB60
		public static void ON_TMP_SETTINGS_CHANGED()
		{
			TMPro_EventManager.TMP_SETTINGS_PROPERTY_EVENT.Call();
		}

		// Token: 0x06002D72 RID: 11634 RVA: 0x0002096C File Offset: 0x0001EB6C
		public static void ON_TEXTMESHPRO_UGUI_PROPERTY_CHANGED(bool isChanged, TextMeshProUGUI obj)
		{
			TMPro_EventManager.TEXTMESHPRO_UGUI_PROPERTY_EVENT.Call(isChanged, obj);
		}

		// Token: 0x06002D73 RID: 11635 RVA: 0x0002097A File Offset: 0x0001EB7A
		public static void ON_COMPUTE_DT_EVENT(object Sender, Compute_DT_EventArgs e)
		{
			TMPro_EventManager.COMPUTE_DT_EVENT.Call(Sender, e);
		}

		// Token: 0x04003174 RID: 12660
		public static readonly FastAction<object, Compute_DT_EventArgs> COMPUTE_DT_EVENT = new FastAction<object, Compute_DT_EventArgs>();

		// Token: 0x04003175 RID: 12661
		public static readonly FastAction<bool, Material> MATERIAL_PROPERTY_EVENT = new FastAction<bool, Material>();

		// Token: 0x04003176 RID: 12662
		public static readonly FastAction<bool, TMP_FontAsset> FONT_PROPERTY_EVENT = new FastAction<bool, TMP_FontAsset>();

		// Token: 0x04003177 RID: 12663
		public static readonly FastAction<bool, global::UnityEngine.Object> SPRITE_ASSET_PROPERTY_EVENT = new FastAction<bool, global::UnityEngine.Object>();

		// Token: 0x04003178 RID: 12664
		public static readonly FastAction<bool, TextMeshPro> TEXTMESHPRO_PROPERTY_EVENT = new FastAction<bool, TextMeshPro>();

		// Token: 0x04003179 RID: 12665
		public static readonly FastAction<GameObject, Material, Material> DRAG_AND_DROP_MATERIAL_EVENT = new FastAction<GameObject, Material, Material>();

		// Token: 0x0400317A RID: 12666
		public static readonly FastAction<bool> TEXT_STYLE_PROPERTY_EVENT = new FastAction<bool>();

		// Token: 0x0400317B RID: 12667
		public static readonly FastAction<TMP_ColorGradient> COLOR_GRADIENT_PROPERTY_EVENT = new FastAction<TMP_ColorGradient>();

		// Token: 0x0400317C RID: 12668
		public static readonly FastAction TMP_SETTINGS_PROPERTY_EVENT = new FastAction();

		// Token: 0x0400317D RID: 12669
		public static readonly FastAction<bool, TextMeshProUGUI> TEXTMESHPRO_UGUI_PROPERTY_EVENT = new FastAction<bool, TextMeshProUGUI>();

		// Token: 0x0400317E RID: 12670
		public static readonly FastAction OnPreRenderObject_Event = new FastAction();

		// Token: 0x0400317F RID: 12671
		public static readonly FastAction<global::UnityEngine.Object> TEXT_CHANGED_EVENT = new FastAction<global::UnityEngine.Object>();
	}
}
