// Decompiled with JetBrains decompiler
// Type: Agony.Common.PathUtil
// Assembly: AgonyRadialCraftingTabs, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 08DEA013-3B49-433F-9CD8-15D25EADC5F0
// Assembly location: C:\Users\pred1\Desktop\RadialTabs\AgonyRadialCraftingTabs.dll

using System;
using System.IO;
using System.Reflection;

namespace Agony.Common
{
  internal static class PathUtil
  {
    public static string GetAssemblyPath(Type type)
    {
      return Path.GetDirectoryName(Assembly.GetAssembly(type).Location);
    }
  }
}
