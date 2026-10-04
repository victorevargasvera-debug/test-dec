// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.Clone_Configuration.Common.ClearAndRestorePassword
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

using AcpBusinessLayer;
using AcpCommonLib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

#nullable disable
namespace SpecialFeatures.Clone_Configuration.Common;

internal class ClearAndRestorePassword
{
  private readonly Queue<string> a = new Queue<string>();
  private readonly Recordset b;
  private readonly string c;

  public ClearAndRestorePassword(Recordset recordSet, string fieldName)
  {
    this.b = recordSet;
    this.c = fieldName;
  }

  public void ClearFieldsAndRemember(Func<string, string> encryptionMethodAction)
  {
    short num1 = 438;
    int num2 = (int) num1;
    num1 = (short) 438;
    int num3 = (int) num1;
    short num4;
    switch (num2 == num3 ? 1 : 0)
    {
      case 0:
      case 2:
label_26:
        num4 = (short) 0;
        break;
      default:
        num4 = (short) 0;
        if (num4 == (short) 0)
          ;
        IEnumerator<FeatureNode> enumerator = ((Collection<FeatureNode>) this.b).GetEnumerator();
        try
        {
          num4 = (short) 4;
          int num5 = (int) (IntPtr) num4;
          while (true)
          {
            AcpFieldX<string, string> acpFieldX;
            string str;
            switch (num5)
            {
              case 0:
                str = encryptionMethodAction(str);
                num4 = (short) 6;
                num5 = (int) (IntPtr) num4;
                continue;
              case 2:
                if (acpFieldX != null)
                {
                  num4 = (short) 9;
                  num5 = (int) (IntPtr) num4;
                  continue;
                }
                break;
              case 3:
                if (!enumerator.MoveNext())
                {
                  num4 = (short) 5;
                  num5 = (int) (IntPtr) num4;
                  continue;
                }
                acpFieldX = enumerator.Current.AllFields.FirstOrDefault<IAcpField>((Func<IAcpField, bool>) (A_0 =>
                {
                  short num6 = -9424;
                  int num7 = (int) num6;
                  num6 = (short) -9424;
                  int num8 = (int) num6;
                  switch (num7 == num8)
                  {
                    case true:
                      short num9 = 1;
                      if (num9 == (short) 0)
                        ;
                      num9 = (short) 0;
                      if (num9 == (short) 0)
                        ;
                      num9 = (short) 0;
                      return A_0.Name == this.c;
                    default:
                      goto case 1;
                  }
                })) as AcpFieldX<string, string>;
                num4 = (short) 2;
                num5 = (int) (IntPtr) num4;
                continue;
              case 4:
                switch (0)
                {
                  case 0:
                    break;
                  default:
                    continue;
                }
                break;
              case 5:
                num4 = (short) 8;
                num5 = (int) (IntPtr) num4;
                continue;
              case 6:
                this.a.Enqueue(str);
                ((AcpField<string>) acpFieldX).SetValue(string.Empty);
                num4 = (short) 1;
                num5 = (int) (IntPtr) num4;
                continue;
              case 7:
                num4 = (short) 1;
                if (num4 == (short) 0)
                  ;
                if (!string.IsNullOrEmpty(str))
                {
                  num4 = (short) 0;
                  num5 = (int) (IntPtr) num4;
                  continue;
                }
                goto case 6;
              case 8:
                goto label_26;
              case 9:
                str = ((AcpField<string>) acpFieldX).Value;
                num4 = (short) 7;
                num5 = (int) (IntPtr) num4;
                continue;
            }
            num4 = (short) 3;
            num5 = (int) (IntPtr) num4;
          }
        }
        finally
        {
          short num10 = 0;
          int num11 = (int) (IntPtr) num10;
          while (true)
          {
            switch (num11)
            {
              case 0:
                switch (0)
                {
                  case 0:
                    break;
                  default:
                    continue;
                }
                break;
              case 1:
                goto label_25;
              case 2:
                enumerator.Dispose();
                num10 = (short) 1;
                num11 = (int) (IntPtr) num10;
                continue;
            }
            if (enumerator != null)
            {
              num10 = (short) 2;
              num11 = (int) (IntPtr) num10;
            }
            else
              break;
          }
label_25:;
        }
    }
  }

  public void RestorePasswordsAndForgot(
    Func<string, string> encryptionMethodAction,
    int trimPassword = -1)
  {
    short num1 = 347;
    int num2 = (int) num1;
    num1 = (short) 347;
    int num3 = (int) num1;
    switch (num2 == num3 ? 1 : 0)
    {
      case 0:
        break;
      case 2:
        break;
      default:
        short num4 = 0;
        if (num4 == (short) 0)
          ;
        num4 = (short) 1;
        if (num4 == (short) 0)
          ;
        num4 = (short) 0;
        IEnumerator<FeatureNode> enumerator = ((Collection<FeatureNode>) this.b).GetEnumerator();
        try
        {
          num4 = (short) 1;
          int num5 = (int) (IntPtr) num4;
          while (true)
          {
            switch (num5)
            {
              case 0:
                num4 = (short) 5;
                num5 = (int) (IntPtr) num4;
                continue;
              case 1:
                switch (0)
                {
                  case 0:
                    break;
                  default:
                    continue;
                }
                break;
              case 4:
                AcpFieldX<string, string> acpFieldX = enumerator.Current.AllFields.FirstOrDefault<IAcpField>((Func<IAcpField, bool>) (A_0 =>
                {
                  short num6 = 7701;
                  int num7 = (int) num6;
                  num6 = (short) 7701;
                  int num8 = (int) num6;
                  switch (num7 == num8)
                  {
                    case true:
                      short num9 = 1;
                      if (num9 == (short) 0)
                        ;
                      num9 = (short) 0;
                      if (num9 == (short) 0)
                        ;
                      num9 = (short) 0;
                      return A_0.Name == this.c;
                    default:
                      goto case 1;
                  }
                })) as AcpFieldX<string, string>;
                string str = this.a.Dequeue();
                if (!string.IsNullOrEmpty(str))
                  str = encryptionMethodAction(str);
                if (trimPassword > 0)
                  str = str.Substring(0, trimPassword);
                if (acpFieldX == null)
                {
                  num4 = (short) 2;
                  num5 = (int) (IntPtr) num4;
                  continue;
                }
                ((AcpField<string>) acpFieldX).SetValue(str);
                num4 = (short) 3;
                num5 = (int) (IntPtr) num4;
                continue;
              case 5:
                goto label_19;
              case 6:
                if (enumerator.MoveNext())
                {
                  num4 = (short) 4;
                  num5 = (int) (IntPtr) num4;
                  continue;
                }
                num4 = (short) 0;
                num5 = (int) (IntPtr) num4;
                continue;
            }
            num4 = (short) 6;
            num5 = (int) (IntPtr) num4;
          }
label_19:
          break;
        }
        finally
        {
          short num10 = 0;
          int num11 = (int) (IntPtr) num10;
          while (true)
          {
            switch (num11)
            {
              case 0:
                switch (0)
                {
                  case 0:
                    break;
                  default:
                    continue;
                }
                break;
              case 1:
                goto label_28;
              case 2:
                enumerator.Dispose();
                num10 = (short) 1;
                num11 = (int) (IntPtr) num10;
                continue;
            }
            if (enumerator != null)
            {
              num10 = (short) 2;
              num11 = (int) (IntPtr) num10;
            }
            else
              break;
          }
label_28:;
        }
    }
  }
}
