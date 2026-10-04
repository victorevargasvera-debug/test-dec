// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.CloneWiFi.PageCloneWiFiView
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

using AcpUI;
using Infragistics.Windows.DataPresenter;
using SpecialFeatures.AcpReportManagerLib;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;

#nullable disable
namespace SpecialFeatures.CloneWiFi;

public class PageCloneWiFiView : AcpPageFeature, IComponentConnector
{
  internal Label LblCloneWiFiDescription;
  internal AcpXamDataPresenter ExpanderWifiConfiguredNetworksList;
  internal UnboundField DataWideFeatureName_Col;
  internal UnboundField DataWideWiFiNetworkSSID_42519_Col;
  internal UnboundField DataWideWiFiNetworkEncryptedNetworkPassword_42517_Col;
  internal Label LblCloneWiFiWarning;
  internal Button buttonOK;
  internal Button buttonCancel;
  internal Button buttonHelp;
  private bool a;

  public PageCloneWiFiView() => this.InitializeComponent();

  public virtual void SetDataContext()
  {
    short num1 = 1;
    if (num1 == (short) 0)
      ;
    num1 = (short) 0;
    num1 = (short) -22606;
    int num2 = (int) num1;
    num1 = (short) -22606;
    int num3 = (int) num1;
    switch (num2 == num3)
    {
      case true:
        num1 = (short) 0;
        if (num1 == (short) 0)
          ;
        ((FrameworkElement) this).DataContext = (object) new PageCloneWiFiViewModel(this);
        break;
      default:
        goto case 1;
    }
  }

  protected virtual void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
  {
    int num1;
    double width;
    double height;
    short num2;
    switch (0)
    {
      case 0:
label_2:
        // ISSUE: explicit non-virtual call
        __nonvirtual (((FrameworkElement) this).OnRenderSizeChanged(sizeInfo));
        Size newSize = sizeInfo.NewSize;
        width = newSize.Width;
        newSize = sizeInfo.NewSize;
        height = newSize.Height;
        num2 = (short) 4;
        num1 = (int) (IntPtr) num2;
        goto default;
      default:
        while (true)
        {
          switch (num1)
          {
            case 0:
              ((FrameworkElement) this.ExpanderWifiConfiguredNetworksList).MaxHeight = 0.6 * height;
              num2 = (short) 2;
              num1 = (int) (IntPtr) num2;
              continue;
            case 1:
              num2 = (short) -9508;
              int num3 = (int) num2;
              num2 = (short) -9508;
              int num4 = (int) num2;
              switch (num3 == num4 ? 1 : 0)
              {
                case 0:
                case 2:
                  num2 = (short) 3;
                  num1 = (int) (IntPtr) num2;
                  continue;
                default:
                  num2 = (short) 0;
                  if (num2 == (short) 0)
                    ;
                  if (width < 620.0)
                    goto label_13;
                  goto case 0;
              }
            case 2:
              num2 = (short) 1;
              num1 = (int) (IntPtr) num2;
              continue;
            case 3:
              goto label_11;
            case 4:
              num2 = (short) 0;
              if (height >= 500.0)
              {
                num2 = (short) 0;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto case 2;
            default:
              goto label_2;
          }
        }
label_11:
        num2 = (short) 1;
        if (num2 == (short) 0)
          ;
        ((Field) this.DataWideWiFiNetworkEncryptedNetworkPassword_42517_Col).Width = new FieldLength?(new FieldLength(180.0 + width - 620.0));
        break;
label_13:
        ((Field) this.DataWideWiFiNetworkEncryptedNetworkPassword_42517_Col).Width = new FieldLength?(new FieldLength(180.0));
        break;
    }
  }

  public virtual void OnLoaded(object sender, RoutedEventArgs e)
  {
    int num1 = 2;
    short num2;
    while (true)
    {
      switch (num1)
      {
        case 0:
          goto label_8;
        case 1:
label_9:
          Keyboard.Focus((IInputElement) this);
          num2 = (short) 0;
          num1 = (int) (IntPtr) num2;
          continue;
        case 2:
          switch (0)
          {
            case 0:
              goto label_3;
            default:
              continue;
          }
        default:
label_3:
          num2 = (short) 1;
          if (num2 == (short) 0)
            ;
          num2 = (short) -4468;
          int num3 = (int) num2;
          num2 = (short) -4468;
          int num4 = (int) num2;
          switch (num3 == num4 ? 1 : 0)
          {
            case 0:
            case 2:
              goto label_9;
            default:
              num2 = (short) 0;
              if (num2 == (short) 0)
                ;
              num2 = (short) 0;
              // ISSUE: explicit non-virtual call
              if (!__nonvirtual (((UIElement) this).IsKeyboardFocusWithin))
              {
                num2 = (short) 1;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_10;
          }
      }
    }
label_8:
    return;
label_10:;
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "5.0.10.0")]
  public void InitializeComponent()
  {
    int A_1 = 14;
    short num;
    if (this.a)
    {
      num = (short) 24634;
      switch ((short) 24634 == num ? 1 : 0)
      {
        case 0:
        case 2:
          break;
        default:
          num = (short) 0;
          num = (short) 0;
          if (num == (short) 0)
            ;
          return;
      }
    }
    num = (short) 1;
    if (num == (short) 0)
      ;
    this.a = true;
    Application.LoadComponent((object) this, new Uri(RptMgrErrorHandler.b("뺐삒\uE594\uF296滛\uF29Aﲜ\uF39E\uE7A0욢쒤펦\uDCA8\uD9AA좬\uDCAE誰킲\uDAB4\uDAB6즸풺펼\uDABE꿀럂\uEAC4꓆ꗈ\uA4CAꏌ\uAACE\uF4D0\uE1D2\uE5D4듖뛘뗚믜뛞蛠離韤蛦鷨苪苬臮\uDEF0郲駴飶韸黺\uD8FC췾\u3100琂氄愆怈␊紌渎瘐瘒瘔笖瘘甚砜栞䠠䔢䰤儦䀨个娬Į䤰刲場嬶", A_1), UriKind.Relative));
  }

  [EditorBrowsable(EditorBrowsableState.Never)]
  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "5.0.10.0")]
  void IComponentConnector.Connect(int connectionId, object target)
  {
    int num = 2;
    while (true)
    {
      switch (num)
      {
        case 0:
          goto label_19;
        case 1:
          num = 0;
          continue;
        case 2:
          switch (0)
          {
            case 0:
              break;
            default:
              continue;
          }
          break;
      }
label_3:
      switch (connectionId)
      {
        case 1:
          switch (true ? 1 : 0)
          {
            case 0:
            case 2:
              goto label_3;
            default:
              goto label_8;
          }
        case 2:
          goto label_15;
        case 3:
          goto label_18;
        case 4:
          goto label_14;
        case 5:
          goto label_6;
        case 6:
          goto label_17;
        case 7:
          goto label_5;
        case 8:
          goto label_12;
        case 9:
          goto label_10;
        case 10:
          goto label_13;
        default:
          num = 1;
          continue;
      }
    }
label_5:
    this.LblCloneWiFiWarning = (Label) target;
    return;
label_6:
    this.DataWideWiFiNetworkSSID_42519_Col = (UnboundField) target;
    return;
label_8:
    if (true)
      ;
    ((FrameworkElement) target).Loaded += new RoutedEventHandler(((AcpPageFeature) this).OnLoaded);
    return;
label_10:
    this.buttonCancel = (Button) target;
    return;
label_12:
    this.buttonOK = (Button) target;
    return;
label_13:
    this.buttonHelp = (Button) target;
    return;
label_14:
    this.DataWideFeatureName_Col = (UnboundField) target;
    return;
label_15:
    if (false)
      ;
    this.LblCloneWiFiDescription = (Label) target;
    return;
label_17:
    this.DataWideWiFiNetworkEncryptedNetworkPassword_42517_Col = (UnboundField) target;
    return;
label_18:
    this.ExpanderWifiConfiguredNetworksList = (AcpXamDataPresenter) target;
    return;
label_19:
    this.a = true;
  }
}
