// Decompiled with JetBrains decompiler
// Type: Agony.Common.ConfigUtil
// Assembly: AgonyRadialCraftingTabs, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 08DEA013-3B49-433F-9CD8-15D25EADC5F0
// Assembly location: C:\Users\pred1\Desktop\RadialTabs\AgonyRadialCraftingTabs.dll

using System;
using System.IO;

namespace Agony.Common
{
  internal class ConfigUtil
  {
    public static void Read<T>(T config)
    {
      JsonUtil.TryFileToObject<T>(ConfigUtil.GetConfigPath<T>(config), out config);
    }

    public static void Write<T>(T config)
    {
      string configPath = ConfigUtil.GetConfigPath<T>(config);
      JsonUtil.TryObjectToFile<T>(config, configPath);
    }

    private static string GetConfigPath<T>(T config)
    {
      Type type = config.GetType();
      return Path.Combine(PathUtil.GetAssemblyPath(type), "Config/" + type.FullName + ".json");
    }
  }
}
