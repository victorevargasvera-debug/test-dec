// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.FileOperations.BusyIndicator
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

using SpecialFeatures.AcpReportManagerLib;
using System;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Controls;
using System.Windows.Media.Animation;

#nullable disable
namespace SpecialFeatures.FileOperations;

public partial class BusyIndicator : Control
{
  public static DependencyProperty BusyStateProperty;
  private Storyboard a;
  private FrameworkElement b;

  static BusyIndicator()
  {
    int A_1 = 14;
    if (false)
      ;
    short num = -5220;
    switch ((short) -5220 == num)
    {
      case true:
        num = (short) 0;
        if (num == (short) 0)
          ;
        FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof (BusyIndicator), (PropertyMetadata) new FrameworkPropertyMetadata((object) typeof (BusyIndicator)));
        BusyIndicator.BusyStateProperty = DependencyProperty.Register(RptMgrErrorHandler.b("펐\uE692\uE694\uEE96쪘\uEF9Aﲜ\uEB9E쒠", A_1), typeof (BusyStates), typeof (BusyIndicator), (PropertyMetadata) new FrameworkPropertyMetadata((object) BusyStates.NOT_BUSY, FrameworkPropertyMetadataOptions.AffectsRender, new PropertyChangedCallback(BusyIndicator.OnBusyStateChanged)));
        break;
      default:
        goto case 1;
    }
  }

  protected override AutomationPeer OnCreateAutomationPeer()
  {
    short num1 = -18008;
    int num2 = (int) num1;
    num1 = (short) -18008;
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
        return (AutomationPeer) new BusyIndicatorAutomationPeer((Control) this);
      default:
        goto case 1;
    }
  }

  private static void OnBusyStateChanged(
    DependencyObject A_0,
    DependencyPropertyChangedEventArgs A_1)
  {
    int A_1_1 = 8;
    int num1;
    BusyIndicator busyIndicator;
    short num2;
    switch (0)
    {
      case 0:
label_2:
        busyIndicator = A_0 as BusyIndicator;
        num2 = (short) 6;
        num1 = (int) (IntPtr) num2;
        goto default;
      default:
        while (true)
        {
          switch (num1)
          {
            case 0:
              if ((BusyStates) A_1.NewValue != BusyStates.NOT_BUSY)
              {
                num2 = (short) 11;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              num2 = (short) 3;
              num1 = (int) (IntPtr) num2;
              continue;
            case 1:
              num2 = (short) 1;
              if (num2 == (short) 0)
                ;
              num2 = (short) 2;
              num1 = (int) (IntPtr) num2;
              continue;
            case 2:
              if (busyIndicator.a != null)
              {
                num2 = (short) 17;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_38;
            case 3:
              num2 = (short) 15;
              num1 = (int) (IntPtr) num2;
              continue;
            case 4:
              goto label_9;
            case 5:
              busyIndicator.a.Stop(busyIndicator.b);
              num2 = (short) 4;
              num1 = (int) (IntPtr) num2;
              continue;
            case 6:
              if ((BusyStates) A_1.NewValue == BusyStates.BUSY)
              {
                num2 = (short) 9;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              num2 = (short) 0;
              num1 = (int) (IntPtr) num2;
              continue;
            case 7:
              goto label_34;
            case 8:
              goto label_5;
            case 9:
              num2 = (short) 16 /*0x10*/;
              num1 = (int) (IntPtr) num2;
              continue;
            case 10:
              num2 = (short) 14395;
              int num3 = (int) num2;
              num2 = (short) 14395;
              int num4 = (int) num2;
              switch (num3 == num4 ? 1 : 0)
              {
                case 0:
                case 2:
                  goto label_26;
                default:
                  num2 = (short) 0;
                  if (num2 == (short) 0)
                    ;
                  num2 = (short) 13;
                  num1 = (int) (IntPtr) num2;
                  continue;
              }
            case 11:
              if ((BusyStates) A_1.NewValue == BusyStates.COMPLETE_NO_ERROR)
              {
                num2 = (short) 10;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              num2 = (short) 12;
              num1 = (int) (IntPtr) num2;
              continue;
            case 12:
              if ((BusyStates) A_1.NewValue == BusyStates.COMPLETE_WITH_ERROR)
              {
                num2 = (short) 1;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_24;
            case 13:
              if (busyIndicator.a != null)
              {
                num2 = (short) 8;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_33;
            case 14:
              goto label_20;
            case 15:
              if (busyIndicator.a != null)
              {
                num2 = (short) 7;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_28;
            case 16 /*0x10*/:
label_26:
              if (busyIndicator.a != null)
              {
                num2 = (short) 5;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_9;
            case 17:
              num2 = (short) 0;
              Storyboard a1 = busyIndicator.a;
              busyIndicator.a = (Storyboard) busyIndicator.FindResource((object) RptMgrErrorHandler.b("첊\uE28C\uDD8E\uF490\uF792\uE694殺\uF898\uF79A\uF19C", A_1_1));
              busyIndicator.a.Begin(busyIndicator.b, HandoffBehavior.Compose, true);
              num2 = (short) 14;
              num1 = (int) (IntPtr) num2;
              continue;
            default:
              goto label_2;
          }
        }
label_20:
        break;
label_5:
        Storyboard a2 = busyIndicator.a;
        busyIndicator.a = (Storyboard) busyIndicator.FindResource((object) RptMgrErrorHandler.b("첊\uE28C좎\uE390\uF692\uF094練릘좚\uF09Cﺞ춠쾢", A_1_1));
        busyIndicator.a.Begin(busyIndicator.b, HandoffBehavior.SnapshotAndReplace, true);
        break;
label_9:
        busyIndicator.b = (FrameworkElement) busyIndicator.GetTemplateChild(RptMgrErrorHandler.b("잊\uEC8C\uF68Eﺐ\uE692\uE194얖\uF698\uF49A\uE99C", A_1_1));
        busyIndicator.Visibility = Visibility.Hidden;
        busyIndicator.a = (Storyboard) busyIndicator.FindResource((object) RptMgrErrorHandler.b("\uD88A\uE08C\uEE8E\uFD90ﾒ튔\uF896\uF598ﾚ캜\uEF9E좠춢", A_1_1));
        busyIndicator.a.Begin(busyIndicator.b, true);
        busyIndicator.Visibility = Visibility.Visible;
        break;
label_38:
        break;
label_33:
        break;
label_28:
        break;
label_24:
        break;
label_34:
        busyIndicator.a.Stop(busyIndicator.b);
        busyIndicator.Visibility = Visibility.Hidden;
        break;
    }
  }

  public BusyStates BusyState
  {
    get
    {
      short num1 = -19267;
      int num2 = (int) num1;
      num1 = (short) -19267;
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
          num4 = (short) 0;
          return (BusyStates) this.GetValue(BusyIndicator.BusyStateProperty);
        default:
          goto case 1;
      }
    }
    set
    {
      short num1 = -24925;
      int num2 = (int) num1;
      num1 = (short) -24925;
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
          num4 = (short) 0;
          this.SetValue(BusyIndicator.BusyStateProperty, (object) value);
          break;
        default:
          goto case 1;
      }
    }
  }

  public override void OnApplyTemplate()
  {
    short num1 = 10917;
    int num2 = (int) num1;
    num1 = (short) 10917;
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
        num4 = (short) 0;
        base.OnApplyTemplate();
        break;
      default:
        goto case 1;
    }
  }
}
