// Decompiled with JetBrains decompiler
// Type: AcpUtility.AssemblyValidator
// Assembly: AcpUtility, Version=1.2.0.9, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0374A65F-E929-4173-BF51-69A629A9A82D
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpUtility.dll

using Microsoft.Win32;
using System;
using System.Reflection;
using System.Windows.Forms;

#nullable disable
namespace AcpUtility;

public static class AssemblyValidator
{
  public static bool IsCallerAuthorized()
  {
    return AssemblyValidator.IsCallerAuthorized(Assembly.GetEntryAssembly());
  }

  public static bool IsCallerAuthorized(Assembly caller)
  {
    bool flag = false;
    if (caller != (Assembly) null)
    {
      if (AssemblyValidator.IsApxAssembly(caller))
      {
        flag = true;
        RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\StrongName\\Verification");
        if (registryKey != null)
        {
          foreach (string subKeyName in registryKey.GetSubKeyNames())
          {
            if (subKeyName.Contains("d124d6ba4931c72b") || subKeyName.Contains("5549ef8a6e130b64") || subKeyName.Contains("6309a8bd04368eb1"))
            {
              flag = false;
              break;
            }
          }
        }
      }
    }
    else
      flag = true;
    if (!flag)
    {
      int num = (int) MessageBox.Show($"Internal Error occurred. The application will be shutdown.{Environment.NewLine}{Environment.NewLine}Exit Code 0xFF");
      Environment.Exit((int) byte.MaxValue);
      throw new Exception($"Internal Error occurred. The application will be shutdown.{Environment.NewLine}{Environment.NewLine}Exit Code 0xFF");
    }
    return flag;
  }

  private static bool IsApxAssembly(Assembly asm)
  {
    bool flag = false;
    if (asm != (Assembly) null)
      flag = asm.FullName.ToLower().EndsWith("d124d6ba4931c72b") || asm.FullName.ToLower().EndsWith("5549ef8a6e130b64") || asm.FullName.ToLower().EndsWith("6309a8bd04368eb1");
    return flag;
  }
}
