using System;
using Agony.Common.Reflectors;
using Harmony;
using UnityEngine;

namespace Agony.RadialTabs
{
	// Token: 0x02000011 RID: 17
	[HarmonyPatch(typeof(uGUI_CraftingMenu), "Action")]
	internal static class uGUI_CraftingMenuActionPatch
	{
		// Token: 0x0600004D RID: 77 RVA: 0x00002DE8 File Offset: 0x00000FE8
		private static void Postfix(uGUI_CraftingMenu __instance, uGUI_CraftNode sender)
		{
			bool client = uGUI_CraftingMenuReflector.GetClient(__instance) != null;
			bool interactable = uGUI_CraftingMenuReflector.GetInteractable(__instance);
			if (!client || !interactable || !__instance.ActionAvailable(sender))
			{
				if (sender.icon == null)
				{
					return;
				}
				float duration = 1f + UnityEngine.Random.Range(-0.2f, 0.2f);
				sender.icon.PunchScale(5f, 0.5f, duration, 0f);
			}
		}
	}
}
