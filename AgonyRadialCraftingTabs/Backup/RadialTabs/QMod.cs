// Decompiled with JetBrains decompiler
// Type: Agony.RadialTabs.QMod
// Assembly: AgonyRadialCraftingTabs, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 08DEA013-3B49-433F-9CD8-15D25EADC5F0
// Assembly location: C:\Users\pred1\Desktop\RadialTabs\AgonyRadialCraftingTabs.dll

using Agony.Common;
using Harmony;
using System;
using System.Reflection;

namespace Agony.RadialTabs
{
  internal static class QMod
  {
    public static void Patch()
    {
      try
      {
        HarmonyInstance.Create("com.pvd.agony.radialcraftingtabs").PatchAll(Assembly.GetExecutingAssembly());
      }
      catch (Exception ex)
      {
        Logger.LogException(ex, true);
      }
    }
  }
}
