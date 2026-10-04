// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.CloneWiFi.WiFiPwd
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

using SpecialFeatures.AcpReportManagerLib;
using System;
using System.ComponentModel;
using System.Threading;

#nullable disable
namespace SpecialFeatures.CloneWiFi;

public class WiFiPwd : INotifyPropertyChanged
{
  private string a = string.Empty;
  private bool b;

  public bool IsValid
  {
    get
    {
      short num1 = 366;
      int num2 = (int) num1;
      num1 = (short) 366;
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
          return this.b;
        default:
          goto case 1;
      }
    }
    set
    {
      int A_1 = 19;
      int num1 = 1;
      while (true)
      {
        short num2 = 0;
        switch (num1)
        {
          case 0:
            this.b = value;
            this.OnPropertyChanged(new PropertyChangedEventArgs(RptMgrErrorHandler.b("\uDF95\uEB97척ﶛ\uF29D즟욡", A_1)));
            num2 = (short) -32542;
            int num3 = (int) num2;
            num2 = (short) -32542;
            int num4 = (int) num2;
            switch (num3 == num4 ? 1 : 0)
            {
              case 0:
              case 2:
                continue;
              default:
                num2 = (short) 0;
                if (num2 == (short) 0)
                  ;
                num2 = (short) 2;
                num1 = (int) (IntPtr) num2;
                continue;
            }
          case 1:
            num2 = (short) 1;
            if (num2 == (short) 0)
              ;
            switch (0)
            {
              case 0:
                break;
              default:
                continue;
            }
            break;
          case 2:
            goto label_6;
        }
        if (this.b != value)
        {
          num2 = (short) 0;
          num1 = (int) (IntPtr) num2;
        }
        else
          goto label_10;
      }
label_6:
      return;
label_10:;
    }
  }

  public string Content
  {
    get
    {
      short num1 = 0;
      num1 = (short) 9890;
      int num2 = (int) num1;
      num1 = (short) 9890;
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
          return this.a;
        default:
          goto case 1;
      }
    }
    set
    {
      int A_1 = 2;
      int num1 = 0;
      short num2;
      while (true)
      {
        switch (num1)
        {
          case 0:
            switch (0)
            {
              case 0:
                goto label_3;
              default:
                continue;
            }
          case 1:
            goto label_10;
          case 2:
            if (!this.IsValid)
            {
              num2 = (short) 4;
              num1 = (int) (IntPtr) num2;
              continue;
            }
            goto label_11;
          case 3:
            this.a = value;
            this.OnPropertyChanged(new PropertyChangedEventArgs(RptMgrErrorHandler.b("욄\uE886\uE788ﾊ\uE88C\uE18E\uE590", A_1)));
            break;
          case 4:
            this.IsValid = true;
            num2 = (short) 1;
            num1 = (int) (IntPtr) num2;
            continue;
          default:
label_3:
            if (this.a != value)
            {
              num2 = (short) -3520;
              int num3 = (int) num2;
              num2 = (short) -3520;
              int num4 = (int) num2;
              switch (num3 == num4 ? 1 : 0)
              {
                case 0:
                case 2:
                  break;
                default:
                  num2 = (short) 0;
                  if (num2 == (short) 0)
                    ;
                  num2 = (short) 3;
                  num1 = (int) (IntPtr) num2;
                  continue;
              }
            }
            else
              goto label_16;
            break;
        }
        num2 = (short) 2;
        num1 = (int) (IntPtr) num2;
      }
label_16:
      return;
label_10:
      num2 = (short) 0;
      num2 = (short) 1;
      if (num2 == (short) 0)
        ;
      return;
label_11:;
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
          this.c((object) this, e);
          num2 = (short) 30001;
          int num3 = (int) num2;
          num2 = (short) 30001;
          int num4 = (int) num2;
          switch (num3 == num4 ? 1 : 0)
          {
            case 0:
            case 2:
              continue;
            default:
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
          goto label_6;
      }
      num2 = (short) 0;
      num2 = (short) 1;
      if (num2 == (short) 0)
        ;
      // ISSUE: reference to a compiler-generated field
      if (this.c != null)
      {
        num2 = (short) 0;
        num1 = (int) (IntPtr) num2;
      }
      else
        goto label_10;
    }
label_6:
    return;
label_10:;
  }

  public event PropertyChangedEventHandler PropertyChanged
  {
    add
    {
      int num1;
      short num2;
      PropertyChangedEventHandler changedEventHandler;
      switch (0)
      {
        case 0:
label_2:
          num2 = (short) 3834;
          int num3 = (int) num2;
          num2 = (short) 3834;
          int num4 = (int) num2;
          switch (num3 == num4 ? 1 : 0)
          {
            case 0:
              return;
            case 2:
              return;
            default:
              num2 = (short) 0;
              num2 = (short) 0;
              if (num2 == (short) 0)
                ;
              changedEventHandler = this.c;
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
                  num2 = (short) 1;
                  if (num2 == (short) 0)
                    ;
                  num2 = (short) 2;
                  num1 = (int) (IntPtr) num2;
                  continue;
                }
                goto case 1;
              case 1:
                comparand = changedEventHandler;
                changedEventHandler = Interlocked.CompareExchange<PropertyChangedEventHandler>(ref this.c, comparand + value, comparand);
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
    remove
    {
      int num1;
      short num2;
      PropertyChangedEventHandler changedEventHandler;
      switch (0)
      {
        case 0:
label_2:
          num2 = (short) -11780;
          int num3 = (int) num2;
          num2 = (short) -11780;
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
              changedEventHandler = this.c;
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
                changedEventHandler = Interlocked.CompareExchange<PropertyChangedEventHandler>(ref this.c, comparand - value, comparand);
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
