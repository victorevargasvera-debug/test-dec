// Decompiled with JetBrains decompiler
// Type: MackinawCPS.DragDropVersionManagerImp
// Assembly: APXFamilyCPS, Version=36.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 9359335E-041C-4B12-9409-F4E6E7D93299
// Assembly location: C:\Program Files (x86)\Motorola\ApxFamilyCPS R36.00\APXFamilyCPS1.exe

using AcpCommonLib;
using System;
using System.Globalization;
using System.Reflection;
using System.Threading;

#nullable disable
namespace MackinawCPS;

public class DragDropVersionManagerImp : DragDropVersionManager
{
  private int version;
  private CultureInfo ci = Thread.CurrentThread.CurrentUICulture;

  internal DragDropVersionManagerImp()
  {
    try
    {
      this.version = Assembly.GetExecutingAssembly().GetName().Version.Major;
    }
    catch (Exception ex)
    {
      this.version = -1;
    }
  }

  public override CultureInfo GetApplicationLanguage() => this.ci;

  public override object GetVersionObj() => (object) this.version;

  public override bool IsDropAllowedByApp(object producerObj, object consumerObj)
  {
    int num1 = (int) producerObj;
    int num2 = (int) consumerObj;
    return num1 >= 0 && num2 >= 0 && num1 <= num2;
  }

  public override bool IsDropAllowedByLocalApp(object producerObj, object consumerObj)
  {
    int num1 = (int) producerObj;
    int num2 = (int) consumerObj;
    int localizedVersionNumber = AppInfoManager.LOCALIZED_VERSION_NUMBER;
    return num1 >= localizedVersionNumber || !(this.ci.TwoLetterISOLanguageName != "en");
  }
}
