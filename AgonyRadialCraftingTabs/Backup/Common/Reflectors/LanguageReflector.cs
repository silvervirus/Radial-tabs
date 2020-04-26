// Decompiled with JetBrains decompiler
// Type: Agony.Common.Reflectors.LanguageReflector
// Assembly: AgonyRadialCraftingTabs, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 08DEA013-3B49-433F-9CD8-15D25EADC5F0
// Assembly location: C:\Users\pred1\Desktop\RadialTabs\AgonyRadialCraftingTabs.dll

using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace Agony.Common.Reflectors
{
  internal static class LanguageReflector
  {
    private static readonly FieldInfo stringsFieldInfo = typeof (Language).GetField("strings", BindingFlags.Instance | BindingFlags.NonPublic);

    public static Dictionary<string, string> GetStrings(Language language)
    {
      if (Object.op_Equality((Object) language, (Object) null))
        throw new ArgumentNullException("language is null");
      return (Dictionary<string, string>) LanguageReflector.stringsFieldInfo.GetValue((object) language);
    }
  }
}
