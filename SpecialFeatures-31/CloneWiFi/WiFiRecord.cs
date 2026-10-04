// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.CloneWiFi.WiFiRecord
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

using SpecialFeatures.AcpReportManagerLib;
using System;
using System.ComponentModel;
using System.Threading;

#nullable disable
namespace SpecialFeatures.CloneWiFi;

public class WiFiRecord : INotifyPropertyChanged
{
  private WiFiPwd a;
  private string b;

  public string SSID
  {
    get
    {
      short num1 = 0;
      num1 = (short) 27197;
      int num2 = (int) num1;
      num1 = (short) 27197;
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
          return this.b;
        default:
          goto case 1;
      }
    }
    set
    {
      int A_1 = 5;
      short num1 = 25569;
      int num2 = (int) num1;
      num1 = (short) 25569;
      int num3 = (int) num1;
      switch (num2 == num3 ? 1 : 0)
      {
        case 0:
          break;
        case 2:
          break;
        default:
          short num4 = 1;
          if (num4 == (short) 0)
            ;
          num4 = (short) 0;
          if (num4 == (short) 0)
            ;
          num4 = (short) 0;
          if (this.b == value)
            break;
          this.b = value;
          this.OnPropertyChanged(new PropertyChangedEventArgs(RptMgrErrorHandler.b("\uDB87\uD989얋쪍", A_1)));
          break;
      }
    }
  }

  public WiFiPwd PWD
  {
    get
    {
      short num1 = 1;
      if (num1 == (short) 0)
        ;
      num1 = (short) 6346;
      int num2 = (int) num1;
      num1 = (short) 6346;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          num1 = (short) 0;
          if (num1 == (short) 0)
            ;
          return this.a;
        default:
          goto case 1;
      }
    }
    set
    {
      int A_1 = 10;
      short num1 = 13879;
      int num2 = (int) num1;
      num1 = (short) 13879;
      int num3 = (int) num1;
      switch (num2 == num3 ? 1 : 0)
      {
        case 0:
          break;
        case 2:
          break;
        default:
          if (true)
            ;
          if (this.a == value)
            break;
          if (false)
            ;
          this.a = value;
          this.OnPropertyChanged(new PropertyChangedEventArgs(RptMgrErrorHandler.b("\uDD8C\uD88E햐", A_1)));
          break;
      }
    }
  }

  public string FeatureName
  {
    get
    {
      short num = 10795;
      switch ((short) 10795 == num)
      {
        case true:
          num = (short) 0;
          if (num == (short) 0)
            ;
          num = (short) 1;
          if (num == (short) 0)
            ;
          return this.c;
        default:
          goto case 1;
      }
    }
    set
    {
      short num1 = 0;
      num1 = (short) -13541;
      int num2 = (int) num1;
      num1 = (short) -13541;
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
          this.c = value;
          break;
        default:
          goto case 1;
      }
    }
  }

  public void OnPropertyChanged(PropertyChangedEventArgs e)
  {
    int num1 = 1;
    while (true)
    {
      short num2;
      switch (num1)
      {
        case 0:
          // ISSUE: reference to a compiler-generated field
          this.d((object) this, e);
          num2 = (short) 32332;
          int num3 = (int) num2;
          num2 = (short) 32332;
          int num4 = (int) num2;
          switch (num3 == num4 ? 1 : 0)
          {
            case 0:
            case 2:
              continue;
            default:
              num2 = (short) 1;
              if (num2 == (short) 0)
                ;
              num2 = (short) 0;
              if (num2 == (short) 0)
                ;
              num2 = (short) 2;
              num1 = (int) (IntPtr) num2;
              continue;
          }
        case 1:
          switch (0)
          {
            case 0:
              break;
            default:
              continue;
          }
          break;
        case 2:
          goto label_5;
      }
      num2 = (short) 0;
      // ISSUE: reference to a compiler-generated field
      if (this.d != null)
      {
        num2 = (short) 0;
        num1 = (int) (IntPtr) num2;
      }
      else
        goto label_10;
    }
label_5:
    return;
label_10:;
  }

  public event PropertyChangedEventHandler PropertyChanged
  {
    add
    {
      short num1 = 1;
      if (num1 == (short) 0)
        ;
      int num2;
      PropertyChangedEventHandler changedEventHandler;
      switch (0)
      {
        case 0:
label_3:
          num1 = (short) -28512;
          int num3 = (int) num1;
          num1 = (short) -28512;
          int num4 = (int) num1;
          switch (num3 == num4 ? 1 : 0)
          {
            case 0:
              return;
            case 1:
              num1 = (short) 0;
              if (num1 == (short) 0)
                ;
              changedEventHandler = this.d;
              num1 = (short) 1;
              num2 = (int) (IntPtr) num1;
              goto label_2;
            case 2:
              return;
            default:
              num1 = (short) 0;
              goto case 1;
          }
        default:
          while (true)
          {
            PropertyChangedEventHandler comparand;
            switch (num2)
            {
              case 0:
                if (changedEventHandler == comparand)
                {
                  num1 = (short) 2;
                  num2 = (int) (IntPtr) num1;
                  continue;
                }
                goto case 1;
              case 1:
                comparand = changedEventHandler;
                changedEventHandler = Interlocked.CompareExchange<PropertyChangedEventHandler>(ref this.d, comparand + value, comparand);
                num1 = (short) 0;
                num2 = (int) (IntPtr) num1;
                continue;
              case 2:
                goto label_4;
              default:
                goto label_3;
            }
label_2:;
          }
label_4:
          break;
      }
    }
    remove
    {
      int num1;
      short num2;
      PropertyChangedEventHandler changedEventHandler;
      switch (0)
      {
        case 0:
label_2:
          num2 = (short) -17114;
          int num3 = (int) num2;
          num2 = (short) -17114;
          int num4 = (int) num2;
          switch (num3 == num4 ? 1 : 0)
          {
            case 0:
              return;
            case 2:
              return;
            default:
              num2 = (short) 0;
              num2 = (short) 1;
              if (num2 == (short) 0)
                ;
              num2 = (short) 0;
              if (num2 == (short) 0)
                ;
              changedEventHandler = this.d;
              num2 = (short) 1;
              num1 = (int) (IntPtr) num2;
              goto label_1;
          }
        default:
          while (true)
          {
            PropertyChangedEventHandler comparand;
            switch (num1)
            {
              case 0:
                if (changedEventHandler == comparand)
                {
                  num2 = (short) 2;
                  num1 = (int) (IntPtr) num2;
                  continue;
                }
                goto case 1;
              case 1:
                comparand = changedEventHandler;
                changedEventHandler = Interlocked.CompareExchange<PropertyChangedEventHandler>(ref this.d, comparand - value, comparand);
                num2 = (short) 0;
                num1 = (int) (IntPtr) num2;
                continue;
              case 2:
                goto label_3;
              default:
                goto label_2;
            }
label_1:;
          }
label_3:
          break;
      }
    }
  }
}
