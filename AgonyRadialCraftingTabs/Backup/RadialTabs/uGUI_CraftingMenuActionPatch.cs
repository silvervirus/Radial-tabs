// Decompiled with JetBrains decompiler
// Type: Agony.RadialTabs.uGUI_CraftingMenuActionPatch
// Assembly: AgonyRadialCraftingTabs, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 08DEA013-3B49-433F-9CD8-15D25EADC5F0
// Assembly location: C:\Users\pred1\Desktop\RadialTabs\AgonyRadialCraftingTabs.dll

using Agony.Common.Reflectors;
using Harmony;
using UnityEngine;

namespace Agony.RadialTabs
{
  [HarmonyPatch(typeof (uGUI_CraftingMenu), "Action")]
  internal static class uGUI_CraftingMenuActionPatch
  {
    private static void Postfix(uGUI_CraftingMenu __instance, uGUI_CraftNode sender)
    {
      ITreeActionReceiver client = uGUI_CraftingMenuReflector.GetClient(__instance);
      bool interactable = uGUI_CraftingMenuReflector.GetInteractable(__instance);
      if (client != null && interactable && __instance.ActionAvailable(sender) || Object.op_Equality((Object) sender.get_icon(), (Object) null))
        return;
      float num = 1f + Random.Range(-0.2f, 0.2f);
      sender.get_icon().PunchScale(5f, 0.5f, num, 0.0f);
    }
  }
}
