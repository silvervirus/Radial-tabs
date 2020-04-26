// Decompiled with JetBrains decompiler
// Type: Agony.Common.Reflectors.uGUI_CraftingMenuReflector
// Assembly: AgonyRadialCraftingTabs, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 08DEA013-3B49-433F-9CD8-15D25EADC5F0
// Assembly location: C:\Users\pred1\Desktop\RadialTabs\AgonyRadialCraftingTabs.dll

using System;
using System.Reflection;
using UnityEngine;

namespace Agony.Common.Reflectors
{
  internal static class uGUI_CraftingMenuReflector
  {
    private static readonly FieldInfo clientFieldInfo = typeof (uGUI_CraftingMenu).GetField("_client", BindingFlags.Instance | BindingFlags.NonPublic);
    private static readonly FieldInfo interactableFieldInfo = typeof (uGUI_CraftingMenu).GetField("interactable", BindingFlags.Instance | BindingFlags.NonPublic);
    private static readonly FieldInfo craftedNodeFieldInfo = typeof (uGUI_CraftingMenu).GetField("craftedNode", BindingFlags.Instance | BindingFlags.NonPublic);
    private static readonly FieldInfo iconsFieldInfo = typeof (uGUI_CraftingMenu).GetField("icons", BindingFlags.Instance | BindingFlags.NonPublic);

    public static ITreeActionReceiver GetClient(uGUI_CraftingMenu menu)
    {
      if (Object.op_Equality((Object) menu, (Object) null))
        throw new ArgumentNullException("menu is null");
      return (ITreeActionReceiver) uGUI_CraftingMenuReflector.clientFieldInfo.GetValue((object) menu);
    }

    public static bool GetInteractable(uGUI_CraftingMenu menu)
    {
      if (Object.op_Equality((Object) menu, (Object) null))
        throw new ArgumentNullException("menu is null");
      return (bool) uGUI_CraftingMenuReflector.interactableFieldInfo.GetValue((object) menu);
    }

    public static void SetCraftedNode(uGUI_CraftingMenu menu, uGUI_CraftNode craftedNode)
    {
      if (Object.op_Equality((Object) menu, (Object) null))
        throw new ArgumentNullException("menu is null");
      uGUI_CraftingMenuReflector.craftedNodeFieldInfo.SetValue((object) menu, (object) craftedNode);
    }

    public static uGUI_CraftNode GetIcons(uGUI_CraftingMenu menu)
    {
      if (Object.op_Equality((Object) menu, (Object) null))
        throw new ArgumentNullException("menu is null");
      return (uGUI_CraftNode) uGUI_CraftingMenuReflector.iconsFieldInfo.GetValue((object) menu);
    }
  }
}
