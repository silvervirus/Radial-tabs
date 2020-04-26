// Decompiled with JetBrains decompiler
// Type: Agony.RadialTabs.Config
// Assembly: AgonyRadialCraftingTabs, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 08DEA013-3B49-433F-9CD8-15D25EADC5F0
// Assembly location: C:\Users\pred1\Desktop\RadialTabs\AgonyRadialCraftingTabs.dll

using Agony.Common;
using UnityEngine;

namespace Agony.RadialTabs
{
  internal sealed class Config
  {
    public static int RootIconSize { get; private set; } = 100;

    public static int MinIconSize { get; private set; } = 40;

    public static int MaxRootIconCount { get; private set; } = 10;

    public static double IconForegroundSizeMult { get; private set; } = 0.65;

    public static int IconSizeReductionDelta { get; private set; } = 12;

    public static double IconSizeReductionMult { get; private set; } = 1.0;

    public static double AnimationSpeedMult { get; private set; } = 1.5;

    public static double AnimationFadeDistanceMult { get; private set; } = 1.0;

    public static double AnimationFadePower { get; private set; } = 1.0;

    static Config()
    {
      Config config = new Config();
      ConfigUtil.Read<Config>(config);
      Config.Validate();
      ConfigUtil.Write<Config>(config);
    }

    private static void Validate()
    {
      Config.RootIconSize = Mathf.Clamp(Config.RootIconSize, 64, 256);
      Config.MinIconSize = Mathf.Clamp(Config.MinIconSize, 0, Config.RootIconSize);
      Config.IconForegroundSizeMult = (double) Mathf.Clamp((float) Config.IconForegroundSizeMult, 0.3f, 1f);
      Config.IconSizeReductionDelta = Mathf.Clamp(Config.IconSizeReductionDelta, 0, Config.RootIconSize / 3);
      Config.IconSizeReductionMult = (double) Mathf.Clamp((float) Config.IconSizeReductionMult, 0.5f, 1f);
      Config.AnimationSpeedMult = (double) Mathf.Clamp((float) Config.AnimationSpeedMult, 0.1f, 10f);
      Config.AnimationFadeDistanceMult = (double) Mathf.Clamp((float) Config.AnimationFadeDistanceMult, 0.1f, 10f);
      Config.AnimationFadePower = (double) Mathf.Clamp((float) Config.AnimationFadePower, 0.1f, 10f);
      Config.MaxRootIconCount = Mathf.Clamp(Config.MaxRootIconCount, 3, 24);
    }
  }
}
