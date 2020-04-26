// Decompiled with JetBrains decompiler
// Type: Agony.Common.JsonUtil
// Assembly: AgonyRadialCraftingTabs, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 08DEA013-3B49-433F-9CD8-15D25EADC5F0
// Assembly location: C:\Users\pred1\Desktop\RadialTabs\AgonyRadialCraftingTabs.dll

using LitJson;
using System;
using System.IO;

namespace Agony.Common
{
  internal static class JsonUtil
  {
    public static bool TryFileToObject<T>(string fileName, out T obj)
    {
      obj = default (T);
      try
      {
        using (StreamReader streamReader = new StreamReader(fileName))
        {
          obj = JsonMapper.ToObject<T>((TextReader) streamReader);
          return true;
        }
      }
      catch
      {
        return false;
      }
    }

    public static bool TryObjectToFile<T>(T obj, string fileName)
    {
      try
      {
        Directory.CreateDirectory(Path.GetDirectoryName(fileName));
        using (StreamWriter streamWriter = new StreamWriter(fileName))
        {
          JsonWriter jsonWriter = new JsonWriter((TextWriter) streamWriter);
          jsonWriter.set_PrettyPrint(true);
          JsonMapper.ToJson((object) obj, jsonWriter);
          return true;
        }
      }
      catch (Exception ex)
      {
        Logger.LogException(ex, true);
        return false;
      }
    }
  }
}
