// Decompiled with JetBrains decompiler
// Type: Agony.Common.Texture2DExtensions
// Assembly: AgonyRadialCraftingTabs, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 08DEA013-3B49-433F-9CD8-15D25EADC5F0
// Assembly location: C:\Users\pred1\Desktop\RadialTabs\AgonyRadialCraftingTabs.dll

using System;
using UnityEngine;

namespace Agony.Common
{
  internal static class Texture2DExtensions
  {
    public static void ConvertPixels(this Texture2D texture, Converter<Color, Color> converter)
    {
      Color[] pixels = texture.GetPixels();
      for (int index = 0; index < pixels.Length; ++index)
        pixels[index] = converter(pixels[index]);
      texture.SetPixels(pixels);
    }
  }
}
