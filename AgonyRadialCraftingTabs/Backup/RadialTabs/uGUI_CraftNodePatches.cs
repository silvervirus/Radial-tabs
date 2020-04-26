// Decompiled with JetBrains decompiler
// Type: Agony.RadialTabs.uGUI_CraftNodePatches
// Assembly: AgonyRadialCraftingTabs, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 08DEA013-3B49-433F-9CD8-15D25EADC5F0
// Assembly location: C:\Users\pred1\Desktop\RadialTabs\AgonyRadialCraftingTabs.dll

using Agony.Common.Reflectors;
using Harmony;
using UnityEngine;
using UnityEngine.UI;

namespace Agony.RadialTabs
{
  internal static class uGUI_CraftNodePatches
  {
    [HarmonyPatch(typeof (uGUI_CraftNode), "CreateIcon")]
    private static class CreateIconPatch
    {
      private static void Postfix(uGUI_CraftNode __instance)
      {
        RadialCell radialCell = RadialCell.Create(__instance);
        uGUI_ItemIcon icon = __instance.get_icon();
        Vector2 vector2;
        ((Vector2) ref vector2).\u002Ector(radialCell.size, radialCell.size);
        icon.SetBackgroundSize(vector2);
        icon.SetActiveSize(vector2);
        float num = radialCell.size * (float) Config.IconForegroundSizeMult;
        icon.SetForegroundSize(num, num, true);
        icon.SetBackgroundRadius(radialCell.size / 2f);
        ((Transform) ((Graphic) icon).get_rectTransform()).SetParent((Transform) uGUI_CraftNodeReflector.GetView(__instance).iconsCanvas);
        icon.SetPosition(radialCell.parent.Position);
      }
    }

    [HarmonyPatch(typeof (uGUI_CraftNode), "SetVisible")]
    private static class SetVisiblePatch
    {
      private static void Postfix(uGUI_CraftNode __instance)
      {
        if (Object.op_Equality((Object) __instance.get_icon(), (Object) null))
          return;
        RadialCell radialCell = RadialCell.Create(__instance);
        Vector2 targetPosition = uGUI_CraftNodeReflector.GetVisible(__instance) ? radialCell.Position : radialCell.parent.Position;
        GhostMoving ghostMoving = new GhostMoving((radialCell.radius + radialCell.size) * (float) Config.AnimationSpeedMult, radialCell.size * (float) Config.AnimationFadeDistanceMult, targetPosition);
        ItemIconAnimation.Play(__instance.get_icon(), (ItemIconAnimation) ghostMoving);
      }
    }

    [HarmonyPatch(typeof (uGUI_CraftNode), "Punch")]
    private static class PunchPatch
    {
      private static bool Prefix()
      {
        return false;
      }
    }
  }
}
