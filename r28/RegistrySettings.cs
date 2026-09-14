// Decompiled with JetBrains decompiler
// Type: MackinawCPS.RegistrySettings
// Assembly: APXFamilyCPS, Version=15.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 7983BD42-76AB-479D-8966-B7B635E0E28A
// Assembly location: C:\Program Files (x86)\Motorola\ApxFamilyDepot R28\APXdepotR28.exe

using Microsoft.Win32;
using System;

#nullable disable
namespace MackinawCPS;

internal sealed class RegistrySettings
{
  private RegistrySettings()
  {
  }

  internal static string GetStringValue(string keyLocation, string valueName)
  {
    string empty = string.Empty;
    RegistryKey registryKey = (RegistryKey) null;
    try
    {
      registryKey = Registry.LocalMachine.OpenSubKey(keyLocation);
      if (registryKey != null)
        empty = (string) registryKey.GetValue(valueName);
    }
    catch (ArgumentNullException ex)
    {
    }
    catch (ObjectDisposedException ex)
    {
    }
    catch (Exception ex)
    {
      throw;
    }
    finally
    {
      registryKey?.Close();
    }
    return empty;
  }

  internal static bool IsKeyPresent(string keyLocation)
  {
    bool flag = false;
    RegistryKey registryKey = (RegistryKey) null;
    try
    {
      registryKey = Registry.LocalMachine.OpenSubKey(keyLocation);
      flag = registryKey != null;
    }
    catch (ArgumentNullException ex)
    {
      flag = false;
    }
    catch (ObjectDisposedException ex)
    {
      flag = false;
    }
    catch (Exception ex)
    {
      throw;
    }
    finally
    {
      registryKey?.Close();
    }
    return flag;
  }
}
