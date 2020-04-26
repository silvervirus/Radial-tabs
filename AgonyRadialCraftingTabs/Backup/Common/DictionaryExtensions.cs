// Decompiled with JetBrains decompiler
// Type: Agony.Common.DictionaryExtensions
// Assembly: AgonyRadialCraftingTabs, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 08DEA013-3B49-433F-9CD8-15D25EADC5F0
// Assembly location: C:\Users\pred1\Desktop\RadialTabs\AgonyRadialCraftingTabs.dll

using System;
using System.Collections.Generic;

namespace Agony.Common
{
  internal static class DictionaryExtensions
  {
    public static Dictionary<TKey, TValue> FindAll<TKey, TValue>(
      this Dictionary<TKey, TValue> dictionary,
      Predicate<KeyValuePair<TKey, TValue>> match)
    {
      Dictionary<TKey, TValue> result = new Dictionary<TKey, TValue>();
      SystemExtensions.ForEach<KeyValuePair<TKey, TValue>>((IEnumerable<M0>) dictionary, (Action<M0>) (x =>
      {
        if (!match(x))
          return;
        result.Add(x.Key, x.Value);
      }));
      return result;
    }
  }
}
