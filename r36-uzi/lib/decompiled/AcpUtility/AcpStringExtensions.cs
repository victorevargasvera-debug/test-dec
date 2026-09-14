// Decompiled with JetBrains decompiler
// Type: AcpUtility.AcpStringExtensions
// Assembly: AcpUtility, Version=1.2.0.9, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0374A65F-E929-4173-BF51-69A629A9A82D
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpUtility.dll

using System;

#nullable disable
namespace AcpUtility;

public static class AcpStringExtensions
{
  public static string AcpStringFormat(this string fmt, params object[] args)
  {
    string empty = string.Empty;
    try
    {
      return string.Format(fmt, args);
    }
    catch (ArgumentNullException ex)
    {
      return ">> String not found! <<";
    }
    catch (FormatException ex)
    {
      return ">> String not found! <<";
    }
    catch (Exception ex)
    {
      throw;
    }
  }
}
