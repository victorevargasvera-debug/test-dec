// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.Comms.Logger
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

using SpecialFeatures.AcpReportManagerLib;
using System;
using System.IO;
using System.Reflection;

#nullable disable
namespace SpecialFeatures.Comms;

public class Logger
{
  private static readonly string a;
  private static readonly string b;

  internal static string ExcepitonMsg
  {
    get
    {
      short num1 = 0;
      num1 = (short) 1;
      if (num1 == (short) 0)
        ;
      num1 = (short) 9204;
      int num2 = (int) num1;
      num1 = (short) 9204;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          num1 = (short) 0;
          if (num1 == (short) 0)
            ;
          return Logger.c;
        default:
          goto case 1;
      }
    }
    set
    {
      short num1 = 0;
      num1 = (short) 19187;
      int num2 = (int) num1;
      num1 = (short) 19187;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          num1 = (short) 1;
          if (num1 == (short) 0)
            ;
          num1 = (short) 0;
          if (num1 == (short) 0)
            ;
          Logger.c = value;
          break;
        default:
          goto case 1;
      }
    }
  }

  public static void Log(string message)
  {
    short num1 = 0;
    num1 = (short) 1;
    if (num1 == (short) 0)
      ;
    num1 = (short) 31938;
    int num2 = (int) num1;
    num1 = (short) 31938;
    int num3 = (int) num1;
    switch (num2 == num3)
    {
      case true:
        num1 = (short) 0;
        if (num1 == (short) 0)
          break;
        break;
      default:
        goto case 1;
    }
  }

  public static void LogWithDateTime(string message)
  {
    short num1 = 0;
    num1 = (short) 32677;
    int num2 = (int) num1;
    num1 = (short) 32677;
    int num3 = (int) num1;
    switch (num2 == num3)
    {
      case true:
        num1 = (short) 0;
        if (num1 == (short) 0)
          ;
        num1 = (short) 1;
        if (num1 == (short) 0)
          ;
        Logger.Log(string.Format(Logger.b, (object) DateTime.Now, (object) message));
        break;
      default:
        goto case 1;
    }
  }

  static Logger()
  {
    int A_1 = 10;
    short num1 = 0;
    num1 = (short) -16546;
    int num2 = (int) num1;
    num1 = (short) -16546;
    int num3 = (int) num1;
    switch (num2 == num3)
    {
      case true:
        num1 = (short) 0;
        if (num1 == (short) 0)
          ;
        num1 = (short) 1;
        if (num1 == (short) 0)
          ;
        Logger.a = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + RptMgrErrorHandler.b("톌캎\uE290\uE792\uE794\uF896킘쾚톜\uF09E욠趢톤\uDFA6\uDDA8", A_1);
        Logger.b = RptMgrErrorHandler.b("회\uF48Eꆐ\uEE92떔몖릘\uE09A겜\uE29Eﲠ", A_1);
        break;
      default:
        goto case 1;
    }
  }
}
