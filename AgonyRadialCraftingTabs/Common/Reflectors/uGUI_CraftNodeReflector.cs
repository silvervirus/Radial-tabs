// Decompiled with JetBrains decompiler
// Type: Agony.Common.Reflectors.uGUI_CraftNodeReflector
// Assembly: AgonyRadialCraftingTabs, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 08DEA013-3B49-433F-9CD8-15D25EADC5F0
// Assembly location: C:\Users\pred1\Desktop\RadialTabs\AgonyRadialCraftingTabs.dll

using System;
using System.Reflection;

namespace Agony.Common.Reflectors
{
  internal static class uGUI_CraftNodeReflector
  {
    private static readonly PropertyInfo indexPropertyInfo = typeof (uGUI_CraftNode).GetProperty("index", BindingFlags.Instance | BindingFlags.NonPublic);
    private static readonly FieldInfo viewFieldInfo = typeof (uGUI_CraftNode).GetField("view", BindingFlags.Instance | BindingFlags.NonPublic);
    private static readonly PropertyInfo visiblePropertyInfo = typeof (uGUI_CraftNode).GetProperty("visible", BindingFlags.Instance | BindingFlags.NonPublic);

    public static bool GetVisible(uGUI_CraftNode node)
    {
      if (node == null)
        throw new ArgumentNullException("node is null");
      return (bool) uGUI_CraftNodeReflector.visiblePropertyInfo.GetValue((object) node, (object[]) null);
    }

    public static int GetIndex(uGUI_CraftNode node)
    {
      if (node == null)
        throw new ArgumentNullException("node is null");
      return (int) uGUI_CraftNodeReflector.indexPropertyInfo.GetValue((object) node, (object[]) null);
    }

    public static uGUI_CraftingMenu GetView(uGUI_CraftNode node)
    {
      if (node == null)
        throw new ArgumentNullException("node is null");
      return (uGUI_CraftingMenu) uGUI_CraftNodeReflector.viewFieldInfo.GetValue((object) node);
    }
  }
}
