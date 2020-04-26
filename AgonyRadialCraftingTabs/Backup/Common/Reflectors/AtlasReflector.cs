// Decompiled with JetBrains decompiler
// Type: Agony.Common.Reflectors.AtlasReflector
// Assembly: AgonyRadialCraftingTabs, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 08DEA013-3B49-433F-9CD8-15D25EADC5F0
// Assembly location: C:\Users\pred1\Desktop\RadialTabs\AgonyRadialCraftingTabs.dll

using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace Agony.Common.Reflectors
{
  internal static class AtlasReflector
  {
    private static readonly FieldInfo serialDataFieldInfo = typeof (Atlas).GetField("serialData", BindingFlags.Instance | BindingFlags.NonPublic);
    private static readonly FieldInfo nameFieldInfo = typeof (Atlas).GetField("atlasName", BindingFlags.Instance | BindingFlags.NonPublic);

    public static string GetAtlasName(Atlas atlas)
    {
      if (Object.op_Equality((Object) atlas, (Object) null))
        throw new ArgumentNullException("atlas is null");
      return (string) AtlasReflector.nameFieldInfo.GetValue((object) atlas);
    }

    public static List<Atlas.SerialData> GetSerialData(Atlas atlas)
    {
      if (Object.op_Equality((Object) atlas, (Object) null))
        throw new ArgumentNullException("atlas is null");
      return (List<Atlas.SerialData>) AtlasReflector.serialDataFieldInfo.GetValue((object) atlas);
    }
  }
}
