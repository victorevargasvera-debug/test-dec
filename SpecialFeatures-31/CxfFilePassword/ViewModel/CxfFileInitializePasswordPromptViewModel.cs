// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.CxfFilePassword.ViewModel.CxfFileInitializePasswordPromptViewModel
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

using ACPBrowser;
using SpecialFeatures.AcpReportManagerLib;
using SpecialFeatures.Utilities;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Security;
using System.Threading;
using System.Windows;
using System.Windows.Input;

#nullable disable
namespace SpecialFeatures.CxfFilePassword.ViewModel;

public class CxfFileInitializePasswordPromptViewModel : INotifyPropertyChanged
{
  private bool a;
  private string b = string.Empty;
  private bool c;
  private Visibility d;

  public bool ShouldFocusPasswordField
  {
    get
    {
      short num1 = -2567;
      int num2 = (int) num1;
      num1 = (short) -2567;
      int num3 = (int) num1;
      short num4;
      switch (num2 == num3)
      {
        case true:
          num4 = (short) 1;
          if (num4 == (short) 0)
            ;
          num4 = (short) 0;
          if (num4 == (short) 0)
            ;
          return this.a;
        default:
          num4 = (short) 0;
          goto case 1;
      }
    }
    set
    {
      int A_1 = 4;
      short num1 = -17961;
      int num2 = (int) num1;
      num1 = (short) -17961;
      int num3 = (int) num1;
      short num4;
      switch (num2 == num3)
      {
        case true:
          num4 = (short) 0;
          if (num4 == (short) 0)
            ;
          num4 = (short) 1;
          if (num4 == (short) 0)
            ;
          this.a = value;
          this.a(RptMgrErrorHandler.b("풆\uE188\uE48A\uF88C\uE38E\uF590햒杖\uF496\uEC98\uE89A출ﺞ튠킢튤좦\uDBA8쾪\uEBAC욮풰\uDFB2톴", A_1));
          break;
        default:
          num4 = (short) 0;
          goto case 1;
      }
    }
  }

  public string CxfFileName
  {
    get
    {
      short num1 = -11723;
      int num2 = (int) num1;
      num1 = (short) -11723;
      int num3 = (int) num1;
      short num4;
      switch (num2 == num3)
      {
        case true:
          num4 = (short) 1;
          if (num4 == (short) 0)
            ;
          num4 = (short) 0;
          if (num4 == (short) 0)
            ;
          return this.b;
        default:
          num4 = (short) 0;
          goto case 1;
      }
    }
    set
    {
      int A_1 = 3;
      short num1 = -24402;
      int num2 = (int) num1;
      num1 = (short) -24402;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          if (false)
            ;
          if (true)
            ;
          this.b = value;
          this.a(RptMgrErrorHandler.b("얅\uF087\uEC89쪋\uE78Dﲏ\uF791\uDA93\uF795\uF597ﾙ", A_1));
          break;
        default:
          goto case 1;
      }
    }
  }

  public bool RemeberCxfFilePassword
  {
    get
    {
      short num1 = 13334;
      int num2 = (int) num1;
      num1 = (short) 13334;
      int num3 = (int) num1;
      short num4;
      switch (num2 == num3)
      {
        case true:
          num4 = (short) 0;
          if (num4 == (short) 0)
            ;
          num4 = (short) 1;
          if (num4 == (short) 0)
            ;
          return this.c;
        default:
          num4 = (short) 0;
          goto case 1;
      }
    }
    set
    {
      int A_1 = 7;
      short num1 = 11682;
      int num2 = (int) num1;
      num1 = (short) 11682;
      int num3 = (int) num1;
      short num4;
      switch (num2 == num3)
      {
        case true:
          num4 = (short) 1;
          if (num4 == (short) 0)
            ;
          num4 = (short) 0;
          if (num4 == (short) 0)
            ;
          this.c = value;
          this.a(RptMgrErrorHandler.b("\uD889\uE98B\uE38D\uF58F\uF091\uF193\uE495\uDB97\uE299瀞\uD89D즟캡솣\uF6A5즧\uD9A9\uDFAB\uD9AD\uDFAF삱킳", A_1));
          break;
        default:
          num4 = (short) 0;
          goto case 1;
      }
    }
  }

  public Visibility DataLostInfoVisibility
  {
    get
    {
      short num1 = -13689;
      int num2 = (int) num1;
      num1 = (short) -13689;
      int num3 = (int) num1;
      short num4;
      switch (num2 == num3)
      {
        case true:
          num4 = (short) 1;
          if (num4 == (short) 0)
            ;
          num4 = (short) 0;
          if (num4 == (short) 0)
            ;
          return this.d;
        default:
          num4 = (short) 0;
          goto case 1;
      }
    }
    set
    {
      int A_1 = 11;
      short num1 = -15606;
      int num2 = (int) num1;
      num1 = (short) -15606;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          short num4 = 1;
          if (num4 == (short) 0)
            ;
          num4 = (short) 0;
          if (num4 == (short) 0)
            ;
          this.d = value;
          this.a(RptMgrErrorHandler.b("쪍\uF18F\uE691\uF593\uDA95\uF797\uE999\uE89B힝캟쒡쮣\uF0A5솧\uD9A9얫청\uD9AF\uDEB1\uDDB3습솷", A_1));
          break;
        default:
          goto case 1;
      }
    }
  }

  public SecureString ProvidedPassword
  {
    get
    {
      short num1 = -31964;
      int num2 = (int) num1;
      num1 = (short) -31964;
      int num3 = (int) num1;
      short num4;
      switch (num2 == num3)
      {
        case true:
          num4 = (short) 1;
          if (num4 == (short) 0)
            ;
          num4 = (short) 0;
          if (num4 == (short) 0)
            ;
          return this.e;
        default:
          num4 = (short) 0;
          goto case 1;
      }
    }
    set
    {
      short num1 = 31395;
      int num2 = (int) num1;
      num1 = (short) 31395;
      int num3 = (int) num1;
      short num4;
      switch (num2 == num3)
      {
        case true:
          num4 = (short) 0;
          if (num4 == (short) 0)
            ;
          num4 = (short) 1;
          if (num4 == (short) 0)
            ;
          this.e = value;
          break;
        default:
          num4 = (short) 0;
          goto case 1;
      }
    }
  }

  public SecureString ConfirmProvidedPassword
  {
    get
    {
      short num1 = 19186;
      int num2 = (int) num1;
      num1 = (short) 19186;
      int num3 = (int) num1;
      short num4;
      switch (num2 == num3)
      {
        case true:
          num4 = (short) 0;
          if (num4 == (short) 0)
            ;
          num4 = (short) 1;
          if (num4 == (short) 0)
            ;
          return this.f;
        default:
          num4 = (short) 0;
          goto case 1;
      }
    }
    set
    {
      short num1 = 15798;
      int num2 = (int) num1;
      num1 = (short) 15798;
      int num3 = (int) num1;
      short num4;
      switch (num2 == num3)
      {
        case true:
          num4 = (short) 1;
          if (num4 == (short) 0)
            ;
          num4 = (short) 0;
          if (num4 == (short) 0)
            ;
          this.f = value;
          break;
        default:
          num4 = (short) 0;
          goto case 1;
      }
    }
  }

  public bool IsCancelled
  {
    get
    {
      short num1 = -18273;
      int num2 = (int) num1;
      num1 = (short) -18273;
      int num3 = (int) num1;
      short num4;
      switch (num2 == num3)
      {
        case true:
          num4 = (short) 1;
          if (num4 == (short) 0)
            ;
          num4 = (short) 0;
          if (num4 == (short) 0)
            ;
          return this.g;
        default:
          num4 = (short) 0;
          goto case 1;
      }
    }
    private set
    {
      short num1 = -8653;
      int num2 = (int) num1;
      num1 = (short) -8653;
      int num3 = (int) num1;
      short num4;
      switch (num2 == num3)
      {
        case true:
          num4 = (short) 1;
          if (num4 == (short) 0)
            ;
          num4 = (short) 0;
          if (num4 == (short) 0)
            ;
          this.g = value;
          break;
        default:
          num4 = (short) 0;
          goto case 1;
      }
    }
  }

  public ICommand HelpCommand
  {
    get
    {
      short num1 = -17445;
      int num2 = (int) num1;
      num1 = (short) -17445;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          short num4 = 0;
          num4 = (short) 0;
          if (num4 == (short) 0)
            ;
          num4 = (short) 1;
          if (num4 == (short) 0)
            ;
          return this.h;
        default:
          goto case 1;
      }
    }
    set
    {
      short num1 = 1;
      if (num1 == (short) 0)
        ;
      num1 = (short) 25230;
      int num2 = (int) num1;
      num1 = (short) 25230;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          num1 = (short) 0;
          if (num1 == (short) 0)
            ;
          this.h = value;
          break;
        default:
          num1 = (short) 0;
          goto case 1;
      }
    }
  }

  public ICommand CancelCommand
  {
    get
    {
      short num1 = 3825;
      int num2 = (int) num1;
      num1 = (short) 3825;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          short num4 = 0;
          num4 = (short) 1;
          if (num4 == (short) 0)
            ;
          num4 = (short) 0;
          if (num4 == (short) 0)
            ;
          return this.i;
        default:
          goto case 1;
      }
    }
    set
    {
      short num1 = 26480;
      int num2 = (int) num1;
      num1 = (short) 26480;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          short num4 = 0;
          num4 = (short) 1;
          if (num4 == (short) 0)
            ;
          num4 = (short) 0;
          if (num4 == (short) 0)
            ;
          this.i = value;
          break;
        default:
          goto case 1;
      }
    }
  }

  public ICommand OkCommand
  {
    get
    {
      short num1 = -10375;
      int num2 = (int) num1;
      num1 = (short) -10375;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          short num4 = 0;
          num4 = (short) 1;
          if (num4 == (short) 0)
            ;
          num4 = (short) 0;
          if (num4 == (short) 0)
            ;
          return this.j;
        default:
          goto case 1;
      }
    }
    set
    {
      short num1 = -19740;
      int num2 = (int) num1;
      num1 = (short) -19740;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          short num4 = 0;
          num4 = (short) 1;
          if (num4 == (short) 0)
            ;
          num4 = (short) 0;
          if (num4 == (short) 0)
            ;
          this.j = value;
          break;
        default:
          goto case 1;
      }
    }
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
          num2 = (short) 1;
          if (num2 == (short) 0)
            ;
          changedEventHandler = this.k;
          num2 = (short) 2;
          num1 = (int) (IntPtr) num2;
          goto default;
        default:
          while (true)
          {
            PropertyChangedEventHandler comparand;
            switch (num1)
            {
              case 0:
                if (changedEventHandler != comparand)
                  goto case 2;
                break;
              case 1:
                goto label_9;
              case 2:
                num2 = (short) 24304;
                int num3 = (int) num2;
                num2 = (short) 24304;
                int num4 = (int) num2;
                switch (num3 == num4 ? 1 : 0)
                {
                  case 0:
                  case 2:
                    break;
                  default:
                    num2 = (short) 0;
                    num2 = (short) 0;
                    if (num2 == (short) 0)
                      ;
                    comparand = changedEventHandler;
                    changedEventHandler = Interlocked.CompareExchange<PropertyChangedEventHandler>(ref this.k, comparand + value, comparand);
                    num2 = (short) 0;
                    num1 = (int) (IntPtr) num2;
                    continue;
                }
                break;
              default:
                goto label_2;
            }
            num2 = (short) 1;
            num1 = (int) (IntPtr) num2;
          }
label_9:
          break;
      }
    }
    remove
    {
      int num1;
      PropertyChangedEventHandler changedEventHandler;
      short num2;
      switch (0)
      {
        case 0:
label_2:
          changedEventHandler = this.k;
          num2 = (short) 2;
          num1 = (int) (IntPtr) num2;
          goto default;
        default:
          while (true)
          {
            PropertyChangedEventHandler comparand;
            switch (num1)
            {
              case 0:
                if (changedEventHandler != comparand)
                  goto case 2;
                break;
              case 1:
                goto label_9;
              case 2:
                num2 = (short) 22615;
                int num3 = (int) num2;
                num2 = (short) 22615;
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
                    num2 = (short) 0;
                    num2 = (short) 1;
                    if (num2 == (short) 0)
                      ;
                    comparand = changedEventHandler;
                    changedEventHandler = Interlocked.CompareExchange<PropertyChangedEventHandler>(ref this.k, comparand - value, comparand);
                    num2 = (short) 0;
                    num1 = (int) (IntPtr) num2;
                    continue;
                }
                break;
              default:
                goto label_2;
            }
            num2 = (short) 1;
            num1 = (int) (IntPtr) num2;
          }
label_9:
          break;
      }
    }
  }

  internal event EventHandler OnClose
  {
    add
    {
      int num1;
      short num2;
      EventHandler eventHandler;
      switch (0)
      {
        case 0:
label_2:
          num2 = (short) 1;
          if (num2 == (short) 0)
            ;
          eventHandler = this.l;
          num2 = (short) 2;
          num1 = (int) (IntPtr) num2;
          goto default;
        default:
          while (true)
          {
            EventHandler comparand;
            switch (num1)
            {
              case 0:
                if (eventHandler != comparand)
                  goto case 2;
                break;
              case 1:
                goto label_9;
              case 2:
                num2 = (short) -1138;
                int num3 = (int) num2;
                num2 = (short) -1138;
                int num4 = (int) num2;
                switch (num3 == num4 ? 1 : 0)
                {
                  case 0:
                  case 2:
                    break;
                  default:
                    num2 = (short) 0;
                    num2 = (short) 0;
                    if (num2 == (short) 0)
                      ;
                    comparand = eventHandler;
                    eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.l, comparand + value, comparand);
                    num2 = (short) 0;
                    num1 = (int) (IntPtr) num2;
                    continue;
                }
                break;
              default:
                goto label_2;
            }
            num2 = (short) 1;
            num1 = (int) (IntPtr) num2;
          }
label_9:
          break;
      }
    }
    remove
    {
      int num1;
      EventHandler eventHandler;
      short num2;
      switch (0)
      {
        case 0:
label_2:
          eventHandler = this.l;
          num2 = (short) 2;
          num1 = (int) (IntPtr) num2;
          goto default;
        default:
          while (true)
          {
            EventHandler comparand;
            switch (num1)
            {
              case 0:
                if (eventHandler != comparand)
                  goto case 2;
                break;
              case 1:
                goto label_9;
              case 2:
                num2 = (short) 11464;
                int num3 = (int) num2;
                num2 = (short) 11464;
                int num4 = (int) num2;
                switch (num3 == num4 ? 1 : 0)
                {
                  case 0:
                  case 2:
                    break;
                  default:
                    num2 = (short) 1;
                    if (num2 == (short) 0)
                      ;
                    num2 = (short) 0;
                    num2 = (short) 0;
                    if (num2 == (short) 0)
                      ;
                    comparand = eventHandler;
                    eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.l, comparand - value, comparand);
                    num2 = (short) 0;
                    num1 = (int) (IntPtr) num2;
                    continue;
                }
                break;
              default:
                goto label_2;
            }
            num2 = (short) 1;
            num1 = (int) (IntPtr) num2;
          }
label_9:
          break;
      }
    }
  }

  public CxfFileInitializePasswordPromptViewModel() => this.a();

  private void a()
  {
    short num1 = 11611;
    int num2 = (int) num1;
    num1 = (short) 11611;
    int num3 = (int) num1;
    switch (num2 == num3)
    {
      case true:
        short num4 = 0;
        num4 = (short) 1;
        if (num4 == (short) 0)
          ;
        num4 = (short) 0;
        if (num4 == (short) 0)
          ;
        this.HelpCommand = (ICommand) new RelayCommand(new Action<object>(this.c));
        this.CancelCommand = (ICommand) new RelayCommand(new Action<object>(this.b));
        this.OkCommand = (ICommand) new RelayCommand(new Action<object>(this.a));
        this.IsCancelled = true;
        this.ShouldFocusPasswordField = true;
        break;
      default:
        goto case 1;
    }
  }

  private void c(object A_0)
  {
    int A_1 = 1;
    try
    {
      if (false)
        ;
      short num1 = 21328;
      int num2 = (int) num1;
      num1 = (short) 21328;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          num1 = (short) 0;
          if (num1 == (short) 0)
            ;
          Utility.CloseHelpWindowIfOpen();
          Utility.DisplayCPSHelpDITA(RptMgrErrorHandler.b("ꞃ뺅몇뢉뾋몍\uF68F꒑ꊓ", A_1));
          break;
        default:
          goto case 1;
      }
    }
    catch (Exception ex)
    {
    }
  }

  private void b(object A_0)
  {
    short num1 = -17199;
    int num2 = (int) num1;
    num1 = (short) -17199;
    int num3 = (int) num1;
    switch (num2 == num3)
    {
      case true:
        short num4 = 0;
        num4 = (short) 0;
        if (num4 == (short) 0)
          ;
        num4 = (short) 1;
        if (num4 == (short) 0)
          ;
        // ISSUE: reference to a compiler-generated field
        EventHandler l = this.l;
        if (l == null)
          break;
        l((object) this, new EventArgs());
        break;
      default:
        goto case 1;
    }
  }

  private void a(object A_0)
  {
    short num1 = -7729;
    int num2 = (int) num1;
    num1 = (short) -7729;
    int num3 = (int) num1;
    switch (num2 == num3)
    {
      case true:
        short num4 = 0;
        num4 = (short) 1;
        if (num4 == (short) 0)
          ;
        num4 = (short) 0;
        if (num4 == (short) 0)
          ;
        this.IsCancelled = false;
        // ISSUE: reference to a compiler-generated field
        EventHandler l = this.l;
        if (l == null)
          break;
        l((object) this, new EventArgs());
        break;
      default:
        goto case 1;
    }
  }

  private void a([CallerMemberName] string A_0 = null)
  {
    short num1 = -8047;
    int num2 = (int) num1;
    num1 = (short) -8047;
    int num3 = (int) num1;
    switch (num2 == num3)
    {
      case true:
        short num4 = 0;
        num4 = (short) 1;
        if (num4 == (short) 0)
          ;
        num4 = (short) 0;
        if (num4 == (short) 0)
          ;
        // ISSUE: reference to a compiler-generated field
        PropertyChangedEventHandler k = this.k;
        if (k == null)
          break;
        k((object) this, new PropertyChangedEventArgs(A_0));
        break;
      default:
        goto case 1;
    }
  }
}
