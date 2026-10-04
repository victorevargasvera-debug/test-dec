// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.CxfFilePassword.ViewModel.CxfFilePasswordPromptViewModel
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
using System.Windows.Controls;
using System.Windows.Input;

#nullable disable
namespace SpecialFeatures.CxfFilePassword.ViewModel;

public class CxfFilePasswordPromptViewModel : INotifyPropertyChanged
{
  private bool a;
  private string b = string.Empty;
  private bool c;

  public bool ShouldFocusPasswordField
  {
    get
    {
      short num1 = -13531;
      int num2 = (int) num1;
      num1 = (short) -13531;
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
          return this.a;
        default:
          goto case 1;
      }
    }
    set
    {
      int A_1 = 1;
      short num1 = -148;
      int num2 = (int) num1;
      num1 = (short) -148;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          short num4 = 0;
          if (num4 == (short) 0)
            ;
          num4 = (short) 1;
          if (num4 == (short) 0)
            ;
          this.a = value;
          this.a(RptMgrErrorHandler.b("힃\uEE85\uE787ﾉ\uE08B\uEA8D횏\uFD91\uF793\uE395\uEB97쪙ﶛ\uED9D펟햡쮣풥첧\uECA9얫쮭\uDCAF횱", A_1));
          break;
        default:
          goto case 1;
      }
    }
  }

  public string CxfFileName
  {
    get
    {
      short num1 = -23827;
      int num2 = (int) num1;
      num1 = (short) -23827;
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
          return this.b;
        default:
          goto case 1;
      }
    }
    set
    {
      int A_1 = 15;
      short num1 = 11516;
      int num2 = (int) num1;
      num1 = (short) 11516;
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
          this.b = value;
          this.a(RptMgrErrorHandler.b("톑\uEC93\uF095\uDE97\uF399\uF09Bﮝ\uEE9F쎡즣쎥", A_1));
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
      short num1 = 22550;
      int num2 = (int) num1;
      num1 = (short) 22550;
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
          return this.c;
        default:
          goto case 1;
      }
    }
    set
    {
      int A_1 = 3;
      short num1 = 1;
      if (num1 == (short) 0)
        ;
      num1 = (short) -5728;
      int num2 = (int) num1;
      num1 = (short) -5728;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          num1 = (short) 0;
          if (num1 == (short) 0)
            ;
          this.c = value;
          this.a(RptMgrErrorHandler.b("풅\uED87\uE789\uE98B\uEC8D\uF58F\uE091힓\uEE95ﺗ\uDC99\uF59B\uF29D얟\uF2A1얣향\uDBA7\uDDA9쎫\uDCAD풯", A_1));
          break;
        default:
          num1 = (short) 0;
          goto case 1;
      }
    }
  }

  public SecureString ProvidedPassword
  {
    get
    {
      short num1 = -17600;
      int num2 = (int) num1;
      num1 = (short) -17600;
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
          return this.d;
        default:
          goto case 1;
      }
    }
    private set
    {
      short num1 = -12397;
      int num2 = (int) num1;
      num1 = (short) -12397;
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
          this.d = value;
          break;
        default:
          goto case 1;
      }
    }
  }

  public bool IsCancelled
  {
    get
    {
      short num1 = 1;
      if (num1 == (short) 0)
        ;
      num1 = (short) 26120;
      int num2 = (int) num1;
      num1 = (short) 26120;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          num1 = (short) 0;
          if (num1 == (short) 0)
            ;
          return this.e;
        default:
          num1 = (short) 0;
          goto case 1;
      }
    }
    private set
    {
      short num1 = 13399;
      int num2 = (int) num1;
      num1 = (short) 13399;
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
          this.e = value;
          break;
        default:
          goto case 1;
      }
    }
  }

  public ICommand HelpCommand
  {
    get
    {
      short num1 = 27126;
      int num2 = (int) num1;
      num1 = (short) 27126;
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
          return this.f;
        default:
          goto case 1;
      }
    }
    set
    {
      short num1 = -29213;
      int num2 = (int) num1;
      num1 = (short) -29213;
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
          this.f = value;
          break;
        default:
          goto case 1;
      }
    }
  }

  public ICommand CancelCommand
  {
    get
    {
      short num1 = -12453;
      int num2 = (int) num1;
      num1 = (short) -12453;
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
          return this.g;
        default:
          goto case 1;
      }
    }
    set
    {
      short num1 = 7136;
      int num2 = (int) num1;
      num1 = (short) 7136;
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
          this.g = value;
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
      short num1 = -14487;
      int num2 = (int) num1;
      num1 = (short) -14487;
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
          return this.h;
        default:
          goto case 1;
      }
    }
    set
    {
      short num1 = -26544;
      int num2 = (int) num1;
      num1 = (short) -26544;
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
          this.h = value;
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
      PropertyChangedEventHandler changedEventHandler;
      short num2;
      switch (0)
      {
        case 0:
label_2:
          changedEventHandler = this.i;
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
                num2 = (short) -5536;
                int num3 = (int) num2;
                num2 = (short) -5536;
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
                    comparand = changedEventHandler;
                    changedEventHandler = Interlocked.CompareExchange<PropertyChangedEventHandler>(ref this.i, comparand + value, comparand);
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
      short num2;
      PropertyChangedEventHandler changedEventHandler;
      switch (0)
      {
        case 0:
label_2:
          num2 = (short) 1;
          if (num2 == (short) 0)
            ;
          changedEventHandler = this.i;
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
                num2 = (short) -29258;
                int num3 = (int) num2;
                num2 = (short) -29258;
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
                    changedEventHandler = Interlocked.CompareExchange<PropertyChangedEventHandler>(ref this.i, comparand - value, comparand);
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
      EventHandler eventHandler;
      short num2;
      switch (0)
      {
        case 0:
label_2:
          eventHandler = this.j;
          num2 = (short) 1;
          if (num2 == (short) 0)
            ;
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
                num2 = (short) 19852;
                int num3 = (int) num2;
                num2 = (short) 19852;
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
                    eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.j, comparand + value, comparand);
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
          eventHandler = this.j;
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
                num2 = (short) 8812;
                int num3 = (int) num2;
                num2 = (short) 8812;
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
                    comparand = eventHandler;
                    eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.j, comparand - value, comparand);
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

  public CxfFilePasswordPromptViewModel() => this.a();

  private void a()
  {
    short num1 = 23830;
    int num2 = (int) num1;
    num1 = (short) 23830;
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
    int A_1 = 14;
    try
    {
      short num1 = 3644;
      int num2 = (int) num1;
      num1 = (short) 3644;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          num1 = (short) 0;
          if (num1 == (short) 0)
            ;
          Utility.CloseHelpWindowIfOpen();
          Utility.DisplayCPSHelpDITA(RptMgrErrorHandler.b("느ꮒꞔꖖꪘ꾚ﮜꦞ鞠", A_1));
          break;
        default:
          goto case 1;
      }
    }
    catch (Exception ex)
    {
    }
    short num = 1;
    if (num == (short) 0)
      ;
    num = (short) 0;
  }

  private void b(object A_0)
  {
    short num1 = 20094;
    int num2 = (int) num1;
    num1 = (short) 20094;
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
        EventHandler j = this.j;
        if (j == null)
          break;
        j((object) this, new EventArgs());
        break;
      default:
        goto case 1;
    }
  }

  private void a(object A_0)
  {
    short num1 = -7597;
    int num2 = (int) num1;
    num1 = (short) -7597;
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
        this.ProvidedPassword = (A_0 is PasswordBox passwordBox ? passwordBox.SecurePassword : (SecureString) null) ?? (SecureString) null;
        this.IsCancelled = false;
        // ISSUE: reference to a compiler-generated field
        EventHandler j = this.j;
        if (j == null)
          break;
        j((object) this, new EventArgs());
        break;
      default:
        num4 = (short) 0;
        goto case 1;
    }
  }

  private void a([CallerMemberName] string A_0 = null)
  {
    short num1 = 15034;
    int num2 = (int) num1;
    num1 = (short) 15034;
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
        // ISSUE: reference to a compiler-generated field
        PropertyChangedEventHandler i = this.i;
        if (i == null)
          break;
        i((object) this, new PropertyChangedEventArgs(A_0));
        break;
      default:
        num4 = (short) 0;
        goto case 1;
    }
  }
}
