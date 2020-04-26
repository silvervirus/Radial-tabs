// Decompiled with JetBrains decompiler
// Type: Agony.Common.Logger
// Assembly: AgonyRadialCraftingTabs, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 08DEA013-3B49-433F-9CD8-15D25EADC5F0
// Assembly location: C:\Users\pred1\Desktop\RadialTabs\AgonyRadialCraftingTabs.dll

using System;
using System.Reflection;

namespace Agony.Common
{
  public static class Logger
  {
    public static void LogException(Exception exception, bool stackTrace)
    {
      Console.WriteLine("[" + Assembly.GetCallingAssembly().GetName().Name + "] Error: " + Logger.CreateExceptionString(exception, stackTrace));
    }

    public static void LogException(Exception exception, bool stackTrace, string title)
    {
      string name = Assembly.GetCallingAssembly().GetName().Name;
      string exceptionString = Logger.CreateExceptionString(exception, stackTrace);
      Console.WriteLine("[" + name + "] Error: " + title + " " + exceptionString);
    }

    private static string CreateExceptionString(Exception exception, bool stackTrace)
    {
      return stackTrace ? string.Format("{0}: '{1}'\n{2}", (object) exception.GetType(), (object) exception.Message, (object) exception.StackTrace) : string.Format("{0}: '{1}'", (object) exception.GetType(), (object) exception.Message);
    }

    public static void LogError(string message)
    {
      Console.WriteLine("[" + Assembly.GetCallingAssembly().GetName().Name + "] Error: " + message);
    }

    public static void LogWarning(string message)
    {
      Console.WriteLine("[" + Assembly.GetCallingAssembly().GetName().Name + "] Warning: " + message);
    }

    public static void LogMessage(string message)
    {
      Console.WriteLine("[" + Assembly.GetCallingAssembly().GetName().Name + "] " + message);
    }
  }
}
