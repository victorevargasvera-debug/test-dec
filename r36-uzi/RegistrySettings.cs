// Decompiled with JetBrains decompiler
// Type: MackinawCPS.RegistrySettings
// Assembly: APXFamilyCPS, Version=36.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 9359335E-041C-4B12-9409-F4E6E7D93299
// Assembly location: C:\Program Files (x86)\Motorola\ApxFamilyCPS R36.00\APXFamilyCPS1.exe

using Microsoft.Win32;
using System;
using System.Diagnostics;

#nullable disable
namespace MackinawCPS;

internal sealed class RegistrySettings
{
  private RegistrySettings()
  {
  }

  internal static string GetStringValue(string keyLocation, string valueName)
  {
    try
    {
      using (RegistryKey registryKey1 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey(keyLocation))
      {
        if (registryKey1 != null)
          return registryKey1.GetValue(valueName).ToString();
        using (RegistryKey registryKey2 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey(keyLocation))
        {
          if (registryKey2 != null)
            return registryKey2.GetValue(valueName).ToString();
        }
      }
    }
    catch (ArgumentNullException ex)
    {
      Trace.WriteLine("RegistrySettings.GetStringValue threw an exception, error: " + ex.Message);
    }
    catch (ObjectDisposedException ex)
    {
      Trace.WriteLine("RegistrySettings.GetStringValue threw an exception, error: " + ex.Message);
    }
    catch (Exception ex)
    {
      Trace.WriteLine("RegistrySettings.GetStringValue threw an exception, error: " + ex.Message);
      throw;
    }
    return string.Empty;
  }

  internal static bool IsKeyPresent(string keyLocation)
  {
    try
    {
      using (RegistryKey registryKey1 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey(keyLocation))
      {
        if (registryKey1 != null)
          return true;
        using (RegistryKey registryKey2 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey(keyLocation))
        {
          if (registryKey2 != null)
            return true;
        }
      }
    }
    catch (ArgumentNullException ex)
    {
      Trace.WriteLine("RegistrySettings.IsKeyPresent threw an exception, error: " + ex.Message);
      return false;
    }
    catch (ObjectDisposedException ex)
    {
      Trace.WriteLine("RegistrySettings.IsKeyPresent threw an exception, error: " + ex.Message);
      return false;
    }
    catch (Exception ex)
    {
      Trace.WriteLine("RegistrySettings.IsKeyPresent threw an exception, error: " + ex.Message);
      throw;
    }
    return false;
  }
}
