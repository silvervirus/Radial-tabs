using System;
using System.Reflection;

namespace Agony.Common.Reflectors
{
	// Token: 0x0200000A RID: 10
	internal static class uGUI_CraftingMenuReflector
	{
		// Token: 0x06000015 RID: 21 RVA: 0x0000244C File Offset: 0x0000064C
		public static ITreeActionReceiver GetClient(uGUI_CraftingMenu menu)
		{
			if (menu == null)
			{
				throw new ArgumentNullException("menu is null");
			}
			return (ITreeActionReceiver)uGUI_CraftingMenuReflector.clientFieldInfo.GetValue(menu);
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00002472 File Offset: 0x00000672
		public static bool GetInteractable(uGUI_CraftingMenu menu)
		{
			if (menu == null)
			{
				throw new ArgumentNullException("menu is null");
			}
			return (bool)uGUI_CraftingMenuReflector.interactableFieldInfo.GetValue(menu);
		}

		// Token: 0x06000017 RID: 23 RVA: 0x00002498 File Offset: 0x00000698
		public static void SetCraftedNode(uGUI_CraftingMenu menu, uGUI_CraftNode craftedNode)
		{
			if (menu == null)
			{
				throw new ArgumentNullException("menu is null");
			}
			uGUI_CraftingMenuReflector.craftedNodeFieldInfo.SetValue(menu, craftedNode);
		}

		// Token: 0x06000018 RID: 24 RVA: 0x000024BA File Offset: 0x000006BA
		public static uGUI_CraftNode GetIcons(uGUI_CraftingMenu menu)
		{
			if (menu == null)
			{
				throw new ArgumentNullException("menu is null");
			}
			return (uGUI_CraftNode)uGUI_CraftingMenuReflector.iconsFieldInfo.GetValue(menu);
		}

		// Token: 0x04000004 RID: 4
		private static readonly FieldInfo clientFieldInfo = typeof(uGUI_CraftingMenu).GetField("_client", BindingFlags.Instance | BindingFlags.NonPublic);

		// Token: 0x04000005 RID: 5
		private static readonly FieldInfo interactableFieldInfo = typeof(uGUI_CraftingMenu).GetField("interactable", BindingFlags.Instance | BindingFlags.NonPublic);

		// Token: 0x04000006 RID: 6
		private static readonly FieldInfo craftedNodeFieldInfo = typeof(uGUI_CraftingMenu).GetField("craftedNode", BindingFlags.Instance | BindingFlags.NonPublic);

		// Token: 0x04000007 RID: 7
		private static readonly FieldInfo iconsFieldInfo = typeof(uGUI_CraftingMenu).GetField("icons", BindingFlags.Instance | BindingFlags.NonPublic);
	}
}
