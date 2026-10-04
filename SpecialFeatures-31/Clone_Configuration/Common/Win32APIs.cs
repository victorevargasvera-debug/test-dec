// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.Clone_Configuration.Common.Win32APIs
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

using System;
using System.Runtime.InteropServices;
using System.Security;

#nullable disable
namespace SpecialFeatures.Clone_Configuration.Common;

public static class Win32APIs
{
  private const uint a = 0;
  private const uint b = 1;
  private const uint c = 0;
  private const uint d = 61536;

  public static void EnableCloseMenuItem(IntPtr hwnd, bool bEnable)
  {
    int num1 = 5;
    short num2;
    IntPtr systemMenu;
    while (true)
    {
      switch (num1)
      {
        case 0:
          num2 = (short) 3;
          num1 = (int) (IntPtr) num2;
          continue;
        case 1:
          goto label_11;
        case 2:
          if (systemMenu != IntPtr.Zero)
          {
            num2 = (short) 0;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto label_16;
        case 3:
          num2 = (short) 0;
          if (!bEnable)
          {
            num2 = (short) 6;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          Win32APIs.SafeNativeMethods.EnableMenuItem(systemMenu, 61536U, 0U);
          num2 = (short) 1;
          num1 = (int) (IntPtr) num2;
          continue;
        case 4:
label_12:
          systemMenu = Win32APIs.SafeNativeMethods.GetSystemMenu(hwnd, false);
          num2 = (short) 1;
          if (num2 == (short) 0)
            ;
          num2 = (short) 2;
          num1 = (int) (IntPtr) num2;
          continue;
        case 5:
          switch (0)
          {
            case 0:
              goto label_3;
            default:
              continue;
          }
        case 6:
          goto label_7;
        default:
label_3:
          num2 = (short) 23605;
          int num3 = (int) num2;
          num2 = (short) 23605;
          int num4 = (int) num2;
          switch (num3 == num4 ? 1 : 0)
          {
            case 0:
            case 2:
              goto label_12;
            default:
              num2 = (short) 0;
              if (num2 == (short) 0)
                ;
              if (hwnd != IntPtr.Zero)
              {
                num2 = (short) 4;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_18;
          }
      }
    }
label_11:
    return;
label_18:
    return;
label_7:
    Win32APIs.SafeNativeMethods.EnableMenuItem(systemMenu, 61536U, 1U);
    return;
label_16:;
  }

  [SuppressUnmanagedCodeSecurity]
  internal static class SafeNativeMethods
  {
    [DllImport("user32.dll")]
    internal static extern IntPtr GetSystemMenu(IntPtr hwnd, bool bRevert);

    [DllImport("user32.dll")]
    internal static extern bool EnableMenuItem(IntPtr hMenuItem, uint uItemID, uint uEnable);
  }
}
