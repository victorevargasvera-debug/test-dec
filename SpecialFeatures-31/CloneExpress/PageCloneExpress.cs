// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.CloneExpress.PageCloneExpress
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

using ACPBrowser;
using AcpBusinessLayer;
using AcpCommonLib;
using AcpCommonLib.StatusMessage;
using AcpCommonLib.UndoRedo;
using AcpUI;
using AcpUILib;
using CommonResources;
using Infragistics.Windows.DataPresenter;
using Motorola.MackinawCPS.CoreFeatures.ConventionalSystem;
using Motorola.MackinawCPS.CoreFeatures.DataProfiles;
using Motorola.MackinawCPS.CoreFeatures.DataWide;
using Motorola.MackinawCPS.CoreFeatures.PackExec;
using Motorola.MackinawCPS.CoreFeatures.RadioInformation;
using Motorola.MackinawCPS.CoreFeatures.RadioWide;
using Motorola.MackinawCPS.CoreFeatures.SecureKMFProfile;
using Motorola.MackinawCPS.CoreFeatures.SecureWide;
using Motorola.MackinawCPS.CoreFeatures.TrunkingSystem;
using SpecialFeatures.AcpReportManagerLib;
using SpecialFeatures.Clone_Configuration.Common;
using SpecialFeatures.Comms;
using SpecialFeatures.Programming;
using SpecialFeatures.RadioLanguagePack;
using SpecialFeatures.Security;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Threading;

#nullable disable
namespace SpecialFeatures.CloneExpress;

public class PageCloneExpress : 
  AcpPageFeature,
  IAcpPageFeature,
  INotifyPropertyChanged,
  IComponentConnector
{
  private bool a;
  private RadioEjectTimer b;
  private bool c;
  private bool d;
  private bool e;
  private int f;
  private int g;
  private int h;
  private int i;
  private ASKProgrammingHistoryInnerRecset j;
  private bool k;
  private IntPtr l = IntPtr.Zero;
  private bool m;
  public string LPKString;
  private string n = "";
  private string o;
  internal AcpLabel ProgText;
  internal ProgressBar progressBar2;
  internal AcpExpander ExpCloneExp;
  internal Button CloneButton;
  internal Button HelpButton;
  internal AcpExpander ExpSerialNumber;
  internal AcpViewOnlyCtrl SerialNumberName;
  internal AcpViewOnlyCtrl RadInfoGeneralSerialNumber;
  internal AcpExpander ExpTrkSysIDList;
  internal AcpXamDataPresenter TrunkingIDDataPresenter;
  internal UnboundField TrkSysName_Col;
  internal UnboundField TrkSysID_Col;
  internal UnboundField UnitID_Col;
  internal AcpExpander ExpCnvSysIDList;
  internal AcpXamDataPresenter CnvSysIDDataPresenter;
  internal AcpExpander ExpIndAstroOtarRadioIDList;
  internal AcpViewOnlyCtrl LblSecWideASTROOTARIndividualASTROOTARRadioID;
  internal AcpViewOnlyCtrl SecWideASTROOTARIndividualASTROOTARRadioID;
  internal AcpXamDataPresenter IndAstroOtardRadioIDDataPresenter;
  internal UnboundField SecureKMFProfile_Col;
  internal UnboundField IndAstroOtarRadioID_Col;
  internal AcpExpander ExpDataWide;
  internal AcpViewOnlyCtrl SubscriberIPAddress1;
  internal AcpViewOnlyCtrl DataWideGeneralSubscriberIPAddress1;
  internal AcpViewOnlyCtrl PeerIPAddress1;
  internal AcpViewOnlyCtrl DataWideGeneralPeerIPAddress1;
  internal AcpViewOnlyCtrl BTSubscriberIPAddress;
  internal AcpViewOnlyCtrl DataWideGeneralBTSubscriberIPAddress;
  internal AcpViewOnlyCtrl BTPeerIPAddress;
  internal AcpViewOnlyCtrl DataWideGeneralBTPeerIPAddress;
  internal AcpExpander ExpDataProfileList;
  internal AcpXamDataPresenter DataProfilesDataPresenter;
  internal UnboundField DataProfileName_Col;
  internal AcpExpander ExpUserInfo;
  internal AcpViewOnlyCtrl SoftIDUsername;
  internal AcpViewOnlyCtrl RadWideUserInformationandPasswordsSoftIDUsername;
  internal AcpViewOnlyCtrl LblUserInfoPINPassword;
  internal AcpPasswordEyeBox RadWideUserInformationandPasswordsPINPassword;
  internal AcpViewOnlyCtrl LblUserInfoUserLoginUnitID;
  internal AcpViewOnlyCtrl RadWideUserInformationandPasswordsUserLoginUnitID;
  internal AcpViewOnlyCtrl LblRadioAlias;
  internal AcpViewOnlyCtrl RadWideUserInformationandPasswordsRadioAlias;
  internal AcpExpander ExpBluetooth;
  internal AcpViewOnlyCtrl BluetoothFriendlyName;
  internal AcpViewOnlyCtrl RadWideBluetoothFriendlyName;
  private bool q;

  public string SerNum
  {
    get
    {
      switch (true)
      {
        case true:
          short num = 1;
          if (num == (short) 0)
            ;
          num = (short) 0;
          if (num == (short) 0)
            ;
          return this.o;
        default:
          goto case 1;
      }
    }
    set
    {
      int A_1 = 4;
      int num1 = 1;
      while (true)
      {
        short num2;
        switch (num1)
        {
          case 0:
            this.o = value.ToUpper();
            this.FirePropertyChanged(RptMgrErrorHandler.b("풆\uEC88力쎌搜ﲐ", A_1));
            num2 = (short) 3772;
            int num3 = (int) num2;
            num2 = (short) 3772;
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
                num2 = (short) 1;
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
        if (this.o != value)
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
          num2 = (short) 18208;
          int num3 = (int) num2;
          num2 = (short) 18208;
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
              changedEventHandler = this.p;
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
                changedEventHandler = Interlocked.CompareExchange<PropertyChangedEventHandler>(ref this.p, comparand + value, comparand);
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
          num2 = (short) 1;
          if (num2 == (short) 0)
            ;
          num2 = (short) 6586;
          int num3 = (int) num2;
          num2 = (short) 6586;
          int num4 = (int) num2;
          switch (num3 == num4 ? 1 : 0)
          {
            case 0:
              return;
            case 1:
              num2 = (short) 0;
              if (num2 == (short) 0)
                ;
              changedEventHandler = this.p;
              num2 = (short) 1;
              num1 = (int) (IntPtr) num2;
              goto label_1;
            case 2:
              return;
            default:
              num2 = (short) 0;
              goto case 1;
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
                changedEventHandler = Interlocked.CompareExchange<PropertyChangedEventHandler>(ref this.p, comparand - value, comparand);
                num2 = (short) 0;
                num1 = (int) (IntPtr) num2;
                continue;
              case 2:
                goto label_4;
              default:
                goto label_2;
            }
label_1:;
          }
label_4:
          break;
      }
    }
  }

  public void FirePropertyChanged(string name)
  {
    int num1 = 1;
    while (true)
    {
      short num2 = 0;
      switch (num1)
      {
        case 0:
          // ISSUE: reference to a compiler-generated field
          this.p((object) this, new PropertyChangedEventArgs(name));
          num2 = (short) -16456;
          int num3 = (int) num2;
          num2 = (short) -16456;
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
      // ISSUE: reference to a compiler-generated field
      if (this.p != null)
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

  public PageCloneExpress() => this.InitializeComponent();

  public virtual void SetDataContext()
  {
    short num1 = 0;
    num1 = (short) 22217;
    int num2 = (int) num1;
    num1 = (short) 22217;
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
        ((FrameworkElement) this.ExpSerialNumber).DataContext = (object) this;
        ((DataPresenterBase) this.TrunkingIDDataPresenter).DataSource = (IEnumerable) FeatureManager.GetFeature(2064);
        ((DataPresenterBase) this.CnvSysIDDataPresenter).DataSource = (IEnumerable) FeatureManager.GetFeature(2053);
        ((FrameworkElement) this.ExpIndAstroOtarRadioIDList).DataContext = (object) FeatureManager.GetFeature(2021);
        ((DataPresenterBase) this.IndAstroOtardRadioIDDataPresenter).DataSource = (IEnumerable) FeatureManager.GetFeature(2055);
        ((DataPresenterBase) this.DataProfilesDataPresenter).DataSource = (IEnumerable) FeatureManager.GetFeature(2054);
        ((FrameworkElement) this.ExpDataWide).DataContext = (object) FeatureManager.GetFeature(2028)[0][10066];
        IAcpFeatureSection dataContext = (IAcpFeatureSection) ((FrameworkElement) this.ExpDataWide).DataContext;
        ((FrameworkElement) this.ExpUserInfo).DataContext = (object) FeatureManager.GetFeature(2045);
        ((FrameworkElement) this.ExpBluetooth).DataContext = (object) FeatureManager.GetFeature(2045)[0][10630];
        break;
      default:
        goto case 1;
    }
  }

  public virtual void OnLoaded(object sender, RoutedEventArgs e)
  {
    int num1 = 3;
    while (true)
    {
      short num2 = 1;
      if (num2 == (short) 0)
        ;
      num2 = (short) 20774;
      int num3 = (int) num2;
      num2 = (short) 20774;
      int num4 = (int) num2;
      switch (num3 == num4 ? 1 : 0)
      {
        case 0:
        case 2:
label_8:
          num2 = (short) 0;
          num1 = (int) (IntPtr) num2;
          continue;
        default:
          num2 = (short) 0;
          if (num2 == (short) 0)
            ;
          switch (num1)
          {
            case 0:
              // ISSUE: explicit non-virtual call
              if (!__nonvirtual (((UIElement) this).IsKeyboardFocusWithin))
              {
                num2 = (short) 9;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_21;
            case 1:
              goto label_8;
            case 2:
              goto label_19;
            case 3:
              switch (0)
              {
                case 0:
                  goto label_6;
                default:
                  continue;
              }
            case 4:
              this.l = ((HwndSource) PresentationSource.FromVisual((Visual) this)).Handle;
              num2 = (short) 10;
              num1 = (int) (IntPtr) num2;
              continue;
            case 5:
              if (((FrameworkElement) this).Parent is Window)
              {
                num2 = (short) 4;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto case 10;
            case 6:
              num2 = (short) 5;
              num1 = (int) (IntPtr) num2;
              continue;
            case 7:
              if (!this.a)
              {
                num2 = (short) 8;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_8;
            case 8:
              ((FrameworkElement) this.ExpSerialNumber).DataContext = (object) this;
              ((FrameworkElement) this.TrunkingIDDataPresenter).DataContext = (object) (Recordset) FeatureManager.GetFeature(2064);
              this.a(((FrameworkElement) this.TrunkingIDDataPresenter).DataContext);
              ((FrameworkElement) this.CnvSysIDDataPresenter).DataContext = (object) (Recordset) FeatureManager.GetFeature(2053);
              this.a(((FrameworkElement) this.CnvSysIDDataPresenter).DataContext);
              ((FrameworkElement) this.ExpIndAstroOtarRadioIDList).DataContext = (object) FeatureManager.GetFeature(2021);
              this.a(((FrameworkElement) this.ExpIndAstroOtarRadioIDList).DataContext);
              ((FrameworkElement) this.IndAstroOtardRadioIDDataPresenter).DataContext = (object) (Recordset) FeatureManager.GetFeature(2055);
              this.a(((FrameworkElement) this.IndAstroOtardRadioIDDataPresenter).DataContext);
              ((FrameworkElement) this.DataProfilesDataPresenter).DataContext = (object) (Recordset) FeatureManager.GetFeature(2054);
              this.a(((FrameworkElement) this.DataProfilesDataPresenter).DataContext);
              ((FrameworkElement) this.ExpDataWide).DataContext = (object) FeatureManager.GetFeature(2028)[0][10066];
              this.a(((FrameworkElement) this.ExpDataWide).DataContext);
              ((FrameworkElement) this.ExpUserInfo).DataContext = (object) FeatureManager.GetFeature(2045);
              this.a(((FrameworkElement) this.ExpUserInfo).DataContext);
              ((FrameworkElement) this.ExpBluetooth).DataContext = (object) FeatureManager.GetFeature(2045)[0][10630];
              this.a(((FrameworkElement) this.ExpBluetooth).DataContext);
              this.progressBar2.Value = 0.0;
              SpecialFeatures.Comms.Comms.displayOTAP += new SpecialFeatures.Comms.Comms.MainUIDisplayOTAP(this.CloneW_DisplayOTAP);
              this.a = true;
              this.k = RadioAccessValidator.CacheCodeplugSecurityFields(out this.d, out this.e, out this.f, out this.g, out this.h, out this.j, out this.i);
              num2 = (short) 1;
              num1 = (int) (IntPtr) num2;
              continue;
            case 9:
              num2 = (short) 0;
              Keyboard.Focus((IInputElement) this);
              num2 = (short) 2;
              num1 = (int) (IntPtr) num2;
              continue;
            case 10:
              this.b = new RadioEjectTimer();
              this.b.Tick += new EventHandler(this.OnRadioEjectTimeOut);
              num2 = (short) 7;
              num1 = (int) (IntPtr) num2;
              continue;
            default:
label_6:
              if (((FrameworkElement) this).Parent != null)
              {
                num2 = (short) 6;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto case 10;
          }
      }
    }
label_19:
    return;
label_21:;
  }

  public virtual void OnUnloaded(object sender, RoutedEventArgs e)
  {
    int num1;
    short num2;
    switch (0)
    {
      case 0:
label_2:
        num2 = (short) -21629;
        int num3 = (int) num2;
        num2 = (short) -21629;
        int num4 = (int) num2;
        switch (num3 == num4 ? 1 : 0)
        {
          case 0:
          case 2:
            break;
          default:
            num2 = (short) 0;
            num2 = (short) 1;
            if (num2 == (short) 0)
              ;
            num2 = (short) 0;
            if (num2 == (short) 0)
              ;
            SpecialFeatures.Comms.Comms.displayOTAP -= new SpecialFeatures.Comms.Comms.MainUIDisplayOTAP(this.CloneW_DisplayOTAP);
            this.CloneButton.IsEnabled = true;
            Win32APIs.EnableCloseMenuItem(this.l, true);
            num2 = (short) 1;
            num1 = (int) (IntPtr) num2;
            goto label_1;
        }
        break;
      default:
        while (true)
        {
          switch (num1)
          {
            case 0:
              RadioAccessValidator.RestoreCachedCodeplugSecurityFields(this.d, this.e, this.f, this.g, this.h, this.j, this.i);
              num2 = (short) 2;
              num1 = (int) (IntPtr) num2;
              continue;
            case 1:
              if (this.k)
              {
                num2 = (short) 0;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_9;
            case 2:
              goto label_9;
            default:
              goto label_2;
          }
label_1:;
        }
    }
label_9:
    this.b.Tick -= new EventHandler(this.OnRadioEjectTimeOut);
  }

  internal void OnCloneExpressClone(object sender, RoutedEventArgs e)
  {
    short num1 = 27925;
    int num2 = (int) num1;
    num1 = (short) 27925;
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
        bool status = false;
        AppInfoManager.StatusMsgReport.Clear();
        if (!WiFiPasswordUtil.OpenValidateDlg((Window) ((FrameworkElement) this).Parent))
          break;
        this.CloneButton.IsEnabled = false;
        Win32APIs.EnableCloseMenuItem(this.l, false);
        new PackUnpackExecutor().PrePackHandler();
        new Thread((ThreadStart) (() =>
        {
          int A_1 = 19;
          int num5 = 0;
          switch (num5)
          {
            default:
              SpecialFeatures.Comms.Clone clone;
              short num6;
              switch (0)
              {
                case 0:
label_3:
                  clone = new SpecialFeatures.Comms.Clone();
                  SpecialFeatures.Comms.Comms.updateStatus += new SpecialFeatures.Comms.Comms.DisplayUpdateStatus(this.CallMainUiProcess);
                  status = (bool) ((DispatcherObject) this).Dispatcher.Invoke((Delegate) new PageCloneExpress.MainThreadUpdateRadioIds(this.a), (object) clone.ReadRadioIds(CloneParameters.CloneWriteType, HeadlessAddr: RptMgrErrorHandler.b("ꞕꆗꢙ늛꾝隟骡誣鞥骧銩芫龭", A_1)));
                  num6 = (short) 0;
                  num5 = (int) (IntPtr) num6;
                  goto default;
                default:
                  while (true)
                  {
                    Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide radioWide;
                    RadioWideRecset feature;
                    switch (num5)
                    {
                      case 0:
                        if (status)
                        {
                          num6 = (short) 16 /*0x10*/;
                          num5 = (int) (IntPtr) num6;
                          continue;
                        }
                        break;
                      case 1:
                        goto label_15;
                      case 2:
                        if (AppInfoManager.InvalidFieldsReport.ContainsField((IAcpField) radioWide.UserInformationAndPasswords.RadWideUserInformationandPasswordsSoftIDUsername_A9169))
                        {
                          num6 = (short) 5;
                          num5 = (int) (IntPtr) num6;
                          continue;
                        }
                        goto label_41;
                      case 3:
                        num6 = (short) 17;
                        num5 = (int) (IntPtr) num6;
                        continue;
                      case 4:
                        num6 = (short) 15;
                        num5 = (int) (IntPtr) num6;
                        continue;
                      case 5:
                        this.CallMainUiProcess(0.0, AppResources.Soft_ID_Username_In_Radio_Causes_Invalid);
                        num6 = (short) 19;
                        num5 = (int) (IntPtr) num6;
                        continue;
                      case 6:
                        if (AppInfoManager.InvalidFieldsReport.HasFields)
                        {
                          num6 = (short) 11;
                          num5 = (int) (IntPtr) num6;
                          continue;
                        }
                        num6 = (short) 14;
                        num5 = (int) (IntPtr) num6;
                        continue;
                      case 7:
                      case 19:
                        goto label_11;
                      case 8:
                        if (((Recordset) feature).Count >= 1)
                        {
                          num6 = (short) 21;
                          num5 = (int) (IntPtr) num6;
                          continue;
                        }
                        goto case 4;
                      case 9:
                        if (status)
                        {
                          num6 = (short) 12;
                          num5 = (int) (IntPtr) num6;
                          continue;
                        }
                        num6 = (short) 1;
                        num5 = (int) (IntPtr) num6;
                        continue;
                      case 10:
                        goto label_42;
                      case 11:
                        num6 = (short) 0;
                        feature = FeatureManager.GetFeature(2045) as RadioWideRecset;
                        radioWide = (Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide) null;
                        num6 = (short) 8;
                        num5 = (int) (IntPtr) num6;
                        continue;
                      case 12:
                        if (status)
                        {
                          num6 = (short) 1;
                          if (num6 == (short) 0)
                            ;
                          num6 = (short) 22;
                          num5 = (int) (IntPtr) num6;
                          continue;
                        }
                        goto label_44;
                      case 13:
                        num6 = (short) 2;
                        num5 = (int) (IntPtr) num6;
                        continue;
                      case 14:
                        try
                        {
                          status = clone.CloneRadio(true, CloneParameters.CloneWriteType, CloneParameters.LastCloneOTAPUserState, ((FrameworkElement) this).Parent as Window);
                          break;
                        }
                        catch (Exception ex)
                        {
                          if (ex.Message == AppResources.Codeplug_Exceeds_Size_Limit_On_Write)
                          {
                            num6 = (short) 19143;
                            switch ((short) 19143 == num6 ? 1 : 0)
                            {
                              case 0:
                              case 2:
                                break;
                              default:
                                num6 = (short) 0;
                                if (num6 == (short) 0)
                                  ;
                                status = false;
                                break;
                            }
                          }
                          else
                            break;
                        }
                        break;
                      case 15:
                        if (radioWide != null)
                        {
                          num6 = (short) 3;
                          num5 = (int) (IntPtr) num6;
                          continue;
                        }
                        goto label_41;
                      case 16 /*0x10*/:
                        num6 = (short) 6;
                        num5 = (int) (IntPtr) num6;
                        continue;
                      case 17:
                        if (radioWide.UserInformationAndPasswords.RadWideUserInformationandPasswordsSoftIDUsername_A9169 != null)
                        {
                          num6 = (short) 20;
                          num5 = (int) (IntPtr) num6;
                          continue;
                        }
                        goto label_41;
                      case 18:
                        if (1 == AppInfoManager.InvalidFieldsReport.Count)
                        {
                          num6 = (short) 13;
                          num5 = (int) (IntPtr) num6;
                          continue;
                        }
                        goto label_41;
                      case 20:
                        num6 = (short) 18;
                        num5 = (int) (IntPtr) num6;
                        continue;
                      case 21:
                        radioWide = ((Recordset) feature)[0] as Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide;
                        num6 = (short) 4;
                        num5 = (int) (IntPtr) num6;
                        continue;
                      case 22:
                        this.n = Encoding.ASCII.GetString(Convert.FromBase64String(clone.GetRadioParams().SerialNumber));
                        num6 = (short) 10;
                        num5 = (int) (IntPtr) num6;
                        continue;
                      default:
                        goto label_3;
                    }
                    this.CallMainFinish(status);
                    SpecialFeatures.Comms.Comms.updateStatus -= new SpecialFeatures.Comms.Comms.DisplayUpdateStatus(this.CallMainUiProcess);
                    num6 = (short) 9;
                    num5 = (int) (IntPtr) num6;
                    continue;
label_41:
                    this.CallMainUiProcess(0.0, AppResources.Codeplug_has_Invalid_fields_Please_correct_them_and_try_again);
                    num6 = (short) 7;
                    num5 = (int) (IntPtr) num6;
                  }
label_42:
                  return;
label_11:
                  this.CallMainFinish(false);
                  clone.ForceClose();
                  return;
label_15:
                  clone.ForceClose();
                  return;
label_44:
                  return;
              }
          }
        })).Start();
        break;
    }
  }

  private void F1HelpCommandCanExcute(object A_0, CanExecuteRoutedEventArgs A_1)
  {
    short num1 = 12877;
    int num2 = (int) num1;
    num1 = (short) 12877;
    int num3 = (int) num1;
    switch (num2 == num3)
    {
      case true:
        short num4 = 1;
        if (num4 == (short) 0)
          ;
        num4 = (short) 0;
        num4 = (short) 0;
        if (num4 == (short) 0)
          ;
        A_1.CanExecute = true;
        break;
      default:
        goto case 1;
    }
  }

  private void buttonHelp_Click(object A_0, RoutedEventArgs A_1)
  {
    int A_1_1 = 13;
    try
    {
      short num1 = -11303;
      int num2 = (int) num1;
      num1 = (short) -11303;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          num1 = (short) 0;
          if (num1 == (short) 0)
            ;
          Utility.CloseHelpWindowIfOpen();
          Utility.DisplayCPSHelpDITA(RptMgrErrorHandler.b("뎏\uF091ꊓꂕ꾗ꦙ꒛ꚝ颟", A_1_1));
          break;
        default:
          goto case 1;
      }
    }
    catch (Exception ex)
    {
    }
    if (false)
      ;
  }

  private bool a(RadioIdInfo A_0)
  {
    int A_1 = 4;
    int num1 = 0;
    switch (num1)
    {
      default:
        bool flag1;
        Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation radioInformation;
        bool flag2;
        short num2;
        switch (0)
        {
          case 0:
label_3:
            flag1 = false;
            radioInformation = FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation;
            flag2 = false;
            num2 = (short) 53;
            num1 = (int) (IntPtr) num2;
            goto default;
          default:
            bool flag3;
            while (true)
            {
              DataProfIP[] dataProfIps;
              int index;
              Motorola.MackinawCPS.CoreFeatures.DataWide.DataWide dataWide;
              DataProfIP dataProfIp;
              int num3;
              SecureKMFProfileRecset feature1;
              string strB1;
              IEnumerator<FeatureNode> enumerator1;
              bool smartnetA8184Value;
              bool smartzoneA8185Value;
              Dictionary<string, int[]>.Enumerator enumerator2;
              TrunkingSystemRecset feature2;
              SecureWideRecset feature3;
              bool flag4;
              int length1;
              ConventionalSystemRecset feature4;
              switch (num1)
              {
                case 0:
                  if (strB1 == RptMgrErrorHandler.b("쎆\uE888ﾊ\uEC8C\uD88E\uF890\uF792\uF094", A_1))
                  {
                    num2 = (short) 37;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  enumerator1 = ((Collection<FeatureNode>) (FeatureManager.GetFeature(2054) as DataProfilesRecset)).GetEnumerator();
                  num2 = (short) 20;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 1:
                  num2 = (short) 5;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 2:
                  enumerator1 = ((Collection<FeatureNode>) feature1).GetEnumerator();
                  num2 = (short) 47;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 3:
                case 27:
                  goto label_106;
                case 4:
                  if (A_0.CnvSysIds != null)
                  {
                    num2 = (short) 7;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_259;
                case 5:
                  if (num3 != -1)
                  {
                    num2 = (short) 19;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 40;
                case 6:
                  if (feature3 != null)
                  {
                    num2 = (short) 1;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 40;
                case 7:
                  flag1 = true;
                  feature4 = FeatureManager.GetFeature(2053) as ConventionalSystemRecset;
                  num2 = (short) 14;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 8:
                  num2 = (short) 0;
                  ((AcpField<long>) dataWide.General.DataWideGeneralBTDUNSUIPAddress_A41120).SetValue(dataProfIp.BTSubIP.Address);
                  num2 = (short) 18;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 9:
                  try
                  {
                    num2 = (short) 1;
                    int num4 = (int) (IntPtr) num2;
                    while (true)
                    {
                      Motorola.MackinawCPS.CoreFeatures.TrunkingSystem.TrunkingSystem current1;
                      bool flag5;
                      string referenceKey;
                      switch (num4)
                      {
                        case 0:
                          if (CloneParameters.BlockNewSystemCheck)
                          {
                            num2 = (short) 2;
                            num4 = (int) (IntPtr) num2;
                            continue;
                          }
                          break;
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
                          ((ContentControl) this.ProgText).Content = (object) AppResources.Warning_System_Type_Not_Match_While_Clone_Express;
                          flag3 = false;
                          num2 = (short) 8;
                          num4 = (int) (IntPtr) num2;
                          continue;
                        case 3:
                          if (enumerator1.MoveNext())
                          {
                            current1 = (Motorola.MackinawCPS.CoreFeatures.TrunkingSystem.TrunkingSystem) enumerator1.Current;
                            flag5 = false;
                            referenceKey = ((FeatureNode) current1).ReferenceKey;
                            enumerator2 = A_0.TrkSysIds.GetEnumerator();
                            num2 = (short) 5;
                            num4 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 4;
                          num4 = (int) (IntPtr) num2;
                          continue;
                        case 4:
                          num2 = (short) 6;
                          num4 = (int) (IntPtr) num2;
                          continue;
                        case 5:
                          try
                          {
                            num2 = (short) 1;
                            int num5 = (int) (IntPtr) num2;
                            KeyValuePair<string, int[]> current2;
                            while (true)
                            {
                              string strB2;
                              int length2;
                              switch (num5)
                              {
                                case 0:
                                  num2 = (short) 8;
                                  num5 = (int) (IntPtr) num2;
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
                                case 2:
                                  goto label_165;
                                case 3:
                                  if (enumerator2.MoveNext())
                                  {
                                    current2 = enumerator2.Current;
                                    strB2 = current2.Key;
                                    length2 = current2.Key.IndexOf(char.MinValue);
                                    num2 = (short) 7;
                                    num5 = (int) (IntPtr) num2;
                                    continue;
                                  }
                                  num2 = (short) 4;
                                  num5 = (int) (IntPtr) num2;
                                  continue;
                                case 4:
                                  num2 = (short) 6;
                                  num5 = (int) (IntPtr) num2;
                                  continue;
                                case 5:
                                  flag5 = true;
                                  num2 = (short) 2;
                                  num5 = (int) (IntPtr) num2;
                                  continue;
                                case 6:
                                  goto label_149;
                                case 7:
                                  if (length2 > 0)
                                  {
                                    num2 = (short) 9;
                                    num5 = (int) (IntPtr) num2;
                                    continue;
                                  }
                                  goto case 0;
                                case 8:
                                  if (referenceKey.CompareTo(strB2) == 0)
                                  {
                                    num2 = (short) 5;
                                    num5 = (int) (IntPtr) num2;
                                    continue;
                                  }
                                  break;
                                case 9:
                                  strB2 = current2.Key.Substring(0, length2);
                                  num2 = (short) -26675;
                                  int num6 = (int) num2;
                                  num2 = (short) -26675;
                                  int num7 = (int) num2;
                                  switch (num6 == num7 ? 1 : 0)
                                  {
                                    case 0:
                                    case 2:
                                      continue;
                                    default:
                                      num2 = (short) 0;
                                      if (num2 == (short) 0)
                                        ;
                                      num2 = (short) 0;
                                      num5 = (int) (IntPtr) num2;
                                      continue;
                                  }
                              }
                              num2 = (short) 3;
                              num5 = (int) (IntPtr) num2;
                            }
label_165:
                            try
                            {
                              bool flag6;
                              switch (0)
                              {
                                case 0:
label_167:
                                  ((AcpFieldBase) current1.General.TrkSysGeneralUnitID_A12651).DisableASKRangeValidation = true;
                                  flag6 = UndoManager.StopUndoRedo();
                                  ((AcpField<int>) current1.General.TrkSysGeneralUnitID_A12651).Value = current2.Value[1];
                                  num2 = (short) 2;
                                  num5 = (int) (IntPtr) num2;
                                  goto default;
                                default:
                                  while (true)
                                  {
                                    switch (num5)
                                    {
                                      case 0:
                                        goto label_149;
                                      case 1:
                                        num2 = (short) 0;
                                        num5 = (int) (IntPtr) num2;
                                        continue;
                                      case 2:
                                        if (flag6)
                                        {
                                          num2 = (short) 3;
                                          num5 = (int) (IntPtr) num2;
                                          continue;
                                        }
                                        goto case 1;
                                      case 3:
                                        UndoManager.StartUndoRedo();
                                        num2 = (short) 1;
                                        num5 = (int) (IntPtr) num2;
                                        continue;
                                      default:
                                        goto label_167;
                                    }
                                  }
                              }
                            }
                            catch
                            {
                            }
                            finally
                            {
                              ((AcpFieldBase) current1.General.TrkSysGeneralUnitID_A12651).DisableASKRangeValidation = false;
                            }
                          }
                          finally
                          {
                            enumerator2.Dispose();
                          }
label_149:
                          num2 = (short) 7;
                          num4 = (int) (IntPtr) num2;
                          continue;
                        case 6:
                          goto label_202;
                        case 7:
                          if (!flag5)
                          {
                            num2 = (short) 9;
                            num4 = (int) (IntPtr) num2;
                            continue;
                          }
                          break;
                        case 8:
                          goto label_266;
                        case 9:
                          num2 = (short) 0;
                          num4 = (int) (IntPtr) num2;
                          continue;
                      }
                      num2 = (short) 3;
                      num4 = (int) (IntPtr) num2;
                    }
                  }
                  finally
                  {
                    short num8 = 1;
                    int num9 = (int) (IntPtr) num8;
                    while (true)
                    {
                      switch (num9)
                      {
                        case 0:
                          goto label_192;
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
                          enumerator1.Dispose();
                          num8 = (short) 0;
                          num9 = (int) (IntPtr) num8;
                          continue;
                      }
                      if (enumerator1 != null)
                      {
                        num8 = (short) 2;
                        num9 = (int) (IntPtr) num8;
                      }
                      else
                        break;
                    }
label_192:;
                  }
                case 10:
                  num3 = -1;
                  flag1 = true;
                  feature1 = FeatureManager.GetFeature(2055) as SecureKMFProfileRecset;
                  num2 = (short) 48 /*0x30*/;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 11:
                  if (smartnetA8184Value | smartzoneA8185Value)
                  {
                    num2 = (short) 31 /*0x1F*/;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 12;
                case 12:
                  num2 = (short) 34;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 13:
                  flag1 = true;
                  Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide radioWide1 = ((Recordset) (FeatureManager.GetFeature(2045) as RadioWideRecset))[0] as Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide;
                  A_0.RadioAlias = this.a(A_0.RadioAlias);
                  radioWide1.UserInformationAndPasswords.RadWideUserInformationandPasswordsRadioAlias_A8829.SetValue(A_0.RadioAlias);
                  num2 = (short) 26;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 14:
                  if (feature4 != null)
                  {
                    num2 = (short) 39;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_259;
                case 15:
                  num2 = (short) 30;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 16 /*0x10*/:
                case 25:
                  num2 = (short) 29;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 17:
                  flag1 = true;
                  dataProfIps = A_0.DataProfIps;
                  index = 0;
                  num2 = (short) 16 /*0x10*/;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 18:
                  num2 = (short) 50;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 19:
                  Motorola.MackinawCPS.CoreFeatures.SecureWide.SecureWide secureWide = ((Recordset) feature3)[0] as Motorola.MackinawCPS.CoreFeatures.SecureWide.SecureWide;
                  flag4 = UndoManager.StopUndoRedo();
                  ((AcpField<int>) secureWide.ASTROOTAR.SecWideASTROOTARIndividualASTROOTARRadioID_A8284).Value = num3;
                  num2 = (short) 55;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 20:
                  try
                  {
                    num2 = (short) 0;
                    int num10 = (int) (IntPtr) num2;
                    while (true)
                    {
                      Motorola.MackinawCPS.CoreFeatures.DataProfiles.DataProfiles current;
                      switch (num10)
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
                          ((AcpField<long>) current.General.DataProfilesGeneralBTDUNPeerIPAddress_A41127).SetValue(dataProfIp.BTPeerIP.Address);
                          num2 = (short) 2;
                          num10 = (int) (IntPtr) num2;
                          continue;
                        case 2:
                        case 10:
                          goto label_201;
                        case 3:
                          if (dataProfIp.BTPeerIP != null)
                          {
                            num2 = (short) 1;
                            num10 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 11;
                        case 4:
                          if (!current.General.DataProfGeneralAutoGenerateIPAddress_A19320.Value)
                          {
                            num2 = (short) 8;
                            num10 = (int) (IntPtr) num2;
                            continue;
                          }
                          break;
                        case 5:
                          num2 = (short) 3;
                          num10 = (int) (IntPtr) num2;
                          continue;
                        case 6:
                          if (enumerator1.MoveNext())
                          {
                            current = (Motorola.MackinawCPS.CoreFeatures.DataProfiles.DataProfiles) enumerator1.Current;
                            num2 = (short) 12;
                            num10 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 11;
                          num10 = (int) (IntPtr) num2;
                          continue;
                        case 7:
                          ((AcpField<long>) current.General.DataProfilesGeneralBTDUNSUIPAddress_A41126).SetValue(dataProfIp.BTSubIP.Address);
                          num2 = (short) 5;
                          num10 = (int) (IntPtr) num2;
                          continue;
                        case 8:
                          ((AcpField<long>) current.General.DataProfGeneralSubscriberIPAddress_A21157).SetValue(dataProfIp.SubIP.Address);
                          ((AcpField<long>) current.General.DataProfGeneralMobileComputerIPAddress_A8523).SetValue(dataProfIp.PeerIP.Address);
                          ((AcpField<long>) current.General.DataProfGeneralSubscriberAirInterfaceIPAddress_A9220).SetValue(dataProfIp.SubAirInterfaceIP.Address);
                          num2 = (short) 13;
                          num10 = (int) (IntPtr) num2;
                          continue;
                        case 9:
                          num2 = (short) 4;
                          num10 = (int) (IntPtr) num2;
                          continue;
                        case 11:
                          num2 = (short) 10;
                          num10 = (int) (IntPtr) num2;
                          continue;
                        case 12:
                          if (((FeatureNode) current).ReferenceKey.CompareTo(strB1) == 0)
                          {
                            num2 = (short) 9;
                            num10 = (int) (IntPtr) num2;
                            continue;
                          }
                          break;
                        case 13:
                          if (dataProfIp.BTSubIP != null)
                          {
                            num2 = (short) 7;
                            num10 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 5;
                      }
                      num2 = (short) 6;
                      num10 = (int) (IntPtr) num2;
                    }
                  }
                  finally
                  {
                    int num11 = 0;
                    while (true)
                    {
                      short num12;
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
                          enumerator1.Dispose();
                          num12 = (short) 2;
                          num11 = (int) (IntPtr) num12;
                          continue;
                        case 2:
                          goto label_258;
                      }
                      if (enumerator1 != null)
                      {
                        num12 = (short) 1;
                        num11 = (int) (IntPtr) num12;
                      }
                      else
                        break;
                    }
label_258:;
                  }
label_201:
                  ++index;
                  num2 = (short) 25;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 21:
                  flag1 = true;
                  Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide radioWide2 = ((Recordset) (FeatureManager.GetFeature(2045) as RadioWideRecset))[0] as Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide;
                  A_0.BluetoothFriendlyName = this.a(A_0.BluetoothFriendlyName);
                  radioWide2.Bluetooth.RadWideBluetoothFriendlyName_A41181.SetValue(A_0.BluetoothFriendlyName);
                  num2 = (short) 15;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 22:
                  if (A_0.BluetoothFriendlyName != null)
                  {
                    num2 = (short) 21;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 15;
                case 23:
                  num2 = (short) 57;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 24:
                  Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide radioWide3 = ((Recordset) (FeatureManager.GetFeature(2045) as RadioWideRecset))[0] as Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide;
                  ((AcpField<string>) radioWide3.UserInformationAndPasswords.RadWideUserInformationandPasswordsSoftIDUsername_A9169).SetValue(this.a(A_0.SoftIds[0]));
                  PINPasswordUtil.UpdatePINPasswordFromRadio(A_0);
                  radioWide3.UserInformationAndPasswords.RadWideUserInformationandUserLoginUnitID_41306.SetValue(A_0.SoftIds[3] == null ? "" : this.a(A_0.SoftIds[3]));
                  num2 = (short) 28;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 26:
                  num2 = (short) 22;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 28:
                  num2 = (short) 59;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 29:
                  if (index < dataProfIps.Length)
                  {
                    dataProfIp = dataProfIps[index];
                    strB1 = dataProfIp.DataProfName;
                    length1 = dataProfIp.DataProfName.IndexOf(char.MinValue);
                    num2 = (short) 38;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 27;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 30:
                  num2 = (short) 1;
                  if (num2 == (short) 0)
                    ;
                  if (A_0.DataProfIps != null)
                  {
                    num2 = (short) 17;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_106;
                case 31 /*0x1F*/:
                  flag2 = true;
                  num2 = (short) 12;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 32 /*0x20*/:
                  enumerator1 = ((Collection<FeatureNode>) feature2).GetEnumerator();
                  num2 = (short) 9;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 33:
                  flag1 = true;
                  num2 = (short) 24;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 34:
                  if (A_0.SerialNumber != null)
                  {
                    num2 = (short) 36;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 23;
                case 35:
                  strB1 = dataProfIp.DataProfName.Substring(0, length1);
                  num2 = (short) 43;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 36:
                  num2 = (short) 45;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 37:
                  dataWide = ((Recordset) (FeatureManager.GetFeature(2028) as DataWideRecset))[0] as Motorola.MackinawCPS.CoreFeatures.DataWide.DataWide;
                  ((AcpField<long>) dataWide.General.DataWideGeneralPeerIPAddress1_A8524).SetValue(dataProfIp.PeerIP.Address);
                  ((AcpField<long>) dataWide.General.DataWideGeneralSubscriberIPAddress1_A9222).SetValue(dataProfIp.SubIP.Address);
                  num2 = (short) 58;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 38:
                  if (length1 > 0)
                  {
                    num2 = (short) 35;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 43;
                case 39:
                  enumerator1 = ((Collection<FeatureNode>) feature4).GetEnumerator();
                  num2 = (short) 44;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 40:
                  num2 = (short) 42;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 41:
                  flag1 = true;
                  feature2 = FeatureManager.GetFeature(2064) as TrunkingSystemRecset;
                  num2 = (short) 46;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 42:
                  if (A_0.SoftIds != null)
                  {
                    num2 = (short) 33;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 28;
                case 43:
                  num2 = (short) 0;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 44:
                  try
                  {
                    num2 = (short) 3;
                    int num13 = (int) (IntPtr) num2;
                    while (true)
                    {
                      Motorola.MackinawCPS.CoreFeatures.ConventionalSystem.ConventionalSystem current3;
                      bool flag7;
                      string referenceKey;
                      switch (num13)
                      {
                        case 0:
                          ((ContentControl) this.ProgText).Content = (object) AppResources.Warning_System_Type_Not_Match_While_Clone_Express;
                          flag3 = false;
                          num2 = (short) 9;
                          num13 = (int) (IntPtr) num2;
                          continue;
                        case 1:
                          num2 = (short) 5;
                          num13 = (int) (IntPtr) num2;
                          continue;
                        case 2:
                          try
                          {
                            num2 = (short) 0;
                            int num14 = (int) (IntPtr) num2;
                            while (true)
                            {
                              string typeA13262UiValue;
                              KeyValuePair<string, int[]> current4;
                              bool flag8;
                              string strB3;
                              int length3;
                              switch (num14)
                              {
                                case 0:
                                  switch (0)
                                  {
                                    case 0:
                                      goto label_72;
                                    default:
                                      continue;
                                  }
                                case 1:
                                  strB3 = current4.Key.Substring(0, length3);
                                  num2 = (short) 20;
                                  num14 = (int) (IntPtr) num2;
                                  continue;
                                case 2:
                                  typeA13262UiValue = current3.General.CnvSysGeneralSystemType_A13262_UIValue;
                                  flag8 = UndoManager.StopUndoRedo();
                                  num2 = (short) 17;
                                  num14 = (int) (IntPtr) num2;
                                  continue;
                                case 3:
                                  if (current4.Value[0] == 3)
                                  {
                                    num2 = (short) 16 /*0x10*/;
                                    num14 = (int) (IntPtr) num2;
                                    continue;
                                  }
                                  goto case 7;
                                case 4:
                                case 8:
                                  goto label_79;
                                case 5:
                                  if (typeA13262UiValue == AppResources.QCII_ID)
                                  {
                                    num2 = (short) 27;
                                    num14 = (int) (IntPtr) num2;
                                    continue;
                                  }
                                  goto case 7;
                                case 6:
                                  num2 = (short) 30;
                                  num14 = (int) (IntPtr) num2;
                                  continue;
                                case 7:
                                case 18:
                                case 25:
                                  num2 = (short) 15;
                                  num14 = (int) (IntPtr) num2;
                                  continue;
                                case 9:
                                  ((AcpField<int>) current3.General.CnvSysGeneralIndividualID_A8287).Value = current4.Value[1];
                                  flag7 = true;
                                  num2 = (short) 25;
                                  num14 = (int) (IntPtr) num2;
                                  continue;
                                case 10:
                                  if (current4.Value[0] == 1)
                                  {
                                    num2 = (short) 22;
                                    num14 = (int) (IntPtr) num2;
                                    continue;
                                  }
                                  break;
                                case 11:
                                  if (enumerator2.MoveNext())
                                  {
                                    current4 = enumerator2.Current;
                                    strB3 = current4.Key;
                                    length3 = current4.Key.IndexOf(char.MinValue);
                                    num2 = (short) 14;
                                    num14 = (int) (IntPtr) num2;
                                    continue;
                                  }
                                  num2 = (short) 28;
                                  num14 = (int) (IntPtr) num2;
                                  continue;
                                case 12:
                                  if (referenceKey.CompareTo(strB3) == 0)
                                  {
                                    num2 = (short) 2;
                                    num14 = (int) (IntPtr) num2;
                                    continue;
                                  }
                                  goto default;
                                case 13:
                                  if (typeA13262UiValue == AppResources.MDC_Id)
                                  {
                                    num2 = (short) 29;
                                    num14 = (int) (IntPtr) num2;
                                    continue;
                                  }
                                  break;
                                case 14:
                                  if (length3 > 0)
                                  {
                                    num2 = (short) 1;
                                    num14 = (int) (IntPtr) num2;
                                    continue;
                                  }
                                  goto case 20;
                                case 15:
                                  if (flag8)
                                  {
                                    num2 = (short) 26;
                                    num14 = (int) (IntPtr) num2;
                                    continue;
                                  }
                                  goto case 28;
                                case 16 /*0x10*/:
                                  flag7 = true;
                                  num2 = (short) 18;
                                  num14 = (int) (IntPtr) num2;
                                  continue;
                                case 17:
                                  if (typeA13262UiValue == AppResources.ASTRO_Id)
                                  {
                                    num2 = (short) 19;
                                    num14 = (int) (IntPtr) num2;
                                    continue;
                                  }
                                  goto case 21;
                                case 19:
                                  num2 = (short) 24;
                                  num14 = (int) (IntPtr) num2;
                                  continue;
                                case 20:
                                  num2 = (short) 12;
                                  num14 = (int) (IntPtr) num2;
                                  continue;
                                case 21:
                                  num2 = (short) 23;
                                  num14 = (int) (IntPtr) num2;
                                  continue;
                                case 22:
                                  ((AcpField<int>) current3.General.CnvSysGeneralMDCPrimaryID_A8744).Value = current4.Value[1];
                                  flag7 = true;
                                  num2 = (short) 7;
                                  num14 = (int) (IntPtr) num2;
                                  continue;
                                case 23:
                                  if (typeA13262UiValue == AppResources.DVRS_Id)
                                  {
                                    num2 = (short) 6;
                                    num14 = (int) (IntPtr) num2;
                                    continue;
                                  }
                                  goto label_65;
                                case 24:
                                  if (current4.Value[0] != 0)
                                  {
                                    num2 = (short) 21;
                                    num14 = (int) (IntPtr) num2;
                                    continue;
                                  }
                                  goto case 9;
                                case 26:
                                  UndoManager.StartUndoRedo();
                                  num2 = (short) 4;
                                  num14 = (int) (IntPtr) num2;
                                  continue;
                                case 27:
                                  num2 = (short) 3;
                                  num14 = (int) (IntPtr) num2;
                                  continue;
                                case 28:
                                  num2 = (short) 8;
                                  num14 = (int) (IntPtr) num2;
                                  continue;
                                case 29:
                                  num2 = (short) 10;
                                  num14 = (int) (IntPtr) num2;
                                  continue;
                                case 30:
                                  if (current4.Value[0] == 2)
                                  {
                                    num2 = (short) 9;
                                    num14 = (int) (IntPtr) num2;
                                    continue;
                                  }
                                  goto label_65;
                                default:
label_72:
                                  num2 = (short) 11;
                                  num14 = (int) (IntPtr) num2;
                                  continue;
                              }
                              num2 = (short) 5;
                              num14 = (int) (IntPtr) num2;
                              continue;
label_65:
                              num2 = (short) 13;
                              num14 = (int) (IntPtr) num2;
                            }
                          }
                          finally
                          {
                            enumerator2.Dispose();
                          }
label_79:
                          num2 = (short) 7;
                          num13 = (int) (IntPtr) num2;
                          continue;
                        case 3:
                          switch (0)
                          {
                            case 0:
                              break;
                            default:
                              continue;
                          }
                          break;
                        case 4:
                          if (!enumerator1.MoveNext())
                          {
                            num2 = (short) 6;
                            num13 = (int) (IntPtr) num2;
                            continue;
                          }
                          current3 = (Motorola.MackinawCPS.CoreFeatures.ConventionalSystem.ConventionalSystem) enumerator1.Current;
                          flag7 = false;
                          referenceKey = ((FeatureNode) current3).ReferenceKey;
                          enumerator2 = A_0.CnvSysIds.GetEnumerator();
                          num2 = (short) 2;
                          num13 = (int) (IntPtr) num2;
                          continue;
                        case 5:
                          if (CloneParameters.BlockNewSystemCheck)
                          {
                            num2 = (short) 0;
                            num13 = (int) (IntPtr) num2;
                            continue;
                          }
                          break;
                        case 6:
                          num2 = (short) 8;
                          num13 = (int) (IntPtr) num2;
                          continue;
                        case 7:
                          if (!flag7)
                          {
                            num2 = (short) 1;
                            num13 = (int) (IntPtr) num2;
                            continue;
                          }
                          break;
                        case 8:
                          goto label_259;
                        case 9:
                          goto label_266;
                      }
                      num2 = (short) 4;
                      num13 = (int) (IntPtr) num2;
                    }
                  }
                  finally
                  {
                    int num15 = 0;
                    while (true)
                    {
                      short num16;
                      switch (num15)
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
                          goto label_89;
                        case 2:
                          enumerator1.Dispose();
                          num16 = (short) 1;
                          num15 = (int) (IntPtr) num16;
                          continue;
                      }
                      if (enumerator1 != null)
                      {
                        num16 = (short) 2;
                        num15 = (int) (IntPtr) num16;
                      }
                      else
                        break;
                    }
label_89:;
                  }
                case 45:
                  if (A_0.SerialNumber.Trim().Length > 0)
                  {
                    num2 = (short) 54;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 23;
                case 46:
                  if (feature2 != null)
                  {
                    num2 = (short) 32 /*0x20*/;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_202;
                case 47:
                  try
                  {
                    num2 = (short) 1;
                    int num17 = (int) (IntPtr) num2;
                    while (true)
                    {
                      Motorola.MackinawCPS.CoreFeatures.SecureKMFProfile.SecureKMFProfile current5;
                      Dictionary<string, int>.Enumerator enumerator3;
                      string referenceKey;
                      switch (num17)
                      {
                        case 0:
                          if (!enumerator1.MoveNext())
                          {
                            num2 = (short) 2;
                            num17 = (int) (IntPtr) num2;
                            continue;
                          }
                          current5 = (Motorola.MackinawCPS.CoreFeatures.SecureKMFProfile.SecureKMFProfile) enumerator1.Current;
                          referenceKey = ((FeatureNode) current5).ReferenceKey;
                          enumerator3 = A_0.AstroOtarRadioIds.GetEnumerator();
                          num2 = (short) 4;
                          num17 = (int) (IntPtr) num2;
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
                        case 2:
                          num2 = (short) 3;
                          num17 = (int) (IntPtr) num2;
                          continue;
                        case 3:
                          goto label_194;
                        case 4:
                          try
                          {
                            num2 = (short) 4;
                            int num18 = (int) (IntPtr) num2;
                            while (true)
                            {
                              KeyValuePair<string, int> current6;
                              string key;
                              switch (num18)
                              {
                                case 0:
                                case 2:
                                  goto label_110;
                                case 1:
                                  num3 = current6.Value;
                                  num2 = (short) 0;
                                  num18 = (int) (IntPtr) num2;
                                  continue;
                                case 3:
                                  if (!enumerator3.MoveNext())
                                  {
                                    num2 = (short) 5;
                                    num18 = (int) (IntPtr) num2;
                                    continue;
                                  }
                                  current6 = enumerator3.Current;
                                  key = current6.Key;
                                  num2 = (short) 10;
                                  num18 = (int) (IntPtr) num2;
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
                                  num2 = (short) 2;
                                  num18 = (int) (IntPtr) num2;
                                  continue;
                                case 6:
                                  if (!current5.General.SecKmfProfGenIndependentKeyList_43597.Value)
                                  {
                                    num2 = (short) 1;
                                    num18 = (int) (IntPtr) num2;
                                    continue;
                                  }
                                  goto case 5;
                                case 7:
                                  UndoManager.StartUndoRedo();
                                  num2 = (short) 11;
                                  num18 = (int) (IntPtr) num2;
                                  continue;
                                case 8:
                                  int num19 = UndoManager.StopUndoRedo() ? 1 : 0;
                                  ((AcpField<int>) current5.ASTROOTARInformation.SecKmfProfASTROOTARInformationIndividualASTROOTARRadioID_A8285).Value = current6.Value;
                                  if (num19 != 0)
                                  {
                                    num2 = (short) 7;
                                    num18 = (int) (IntPtr) num2;
                                    continue;
                                  }
                                  goto case 11;
                                case 9:
                                  num2 = (short) 8;
                                  num18 = (int) (IntPtr) num2;
                                  continue;
                                case 10:
                                  if (referenceKey.Equals(key.TrimEnd(new char[1])))
                                  {
                                    num2 = (short) 9;
                                    num18 = (int) (IntPtr) num2;
                                    continue;
                                  }
                                  break;
                                case 11:
                                  num2 = (short) 6;
                                  num18 = (int) (IntPtr) num2;
                                  continue;
                              }
                              num2 = (short) 3;
                              num18 = (int) (IntPtr) num2;
                            }
                          }
                          finally
                          {
                            enumerator3.Dispose();
                          }
                      }
label_110:
                      num2 = (short) 0;
                      num17 = (int) (IntPtr) num2;
                    }
                  }
                  finally
                  {
                    short num20 = 0;
                    int num21 = (int) (IntPtr) num20;
                    while (true)
                    {
                      switch (num21)
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
                          goto label_140;
                        case 2:
                          enumerator1.Dispose();
                          num20 = (short) 1;
                          num21 = (int) (IntPtr) num20;
                          continue;
                      }
                      if (enumerator1 != null)
                      {
                        num20 = (short) 2;
                        num21 = (int) (IntPtr) num20;
                      }
                      else
                        break;
                    }
label_140:;
                  }
                case 48 /*0x30*/:
                  if (feature1 != null)
                  {
                    num2 = (short) 2;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  break;
                case 49:
                  UndoManager.StartUndoRedo();
                  num2 = (short) 40;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 50:
                  if (dataProfIp.BTPeerIP != null)
                  {
                    num2 = (short) 51;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_106;
                case 51:
                  ((AcpField<long>) dataWide.General.DataWideGeneralBTDUNPeerIPAddress_A41123).SetValue(dataProfIp.BTPeerIP.Address);
                  num2 = (short) 3;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 52:
                  smartnetA8184Value = radioInformation.Labtool.RadInfoLabtoolH37G50Smartnet_A8184Value;
                  smartzoneA8185Value = radioInformation.Labtool.RadInfoLabtoolH38G51Smartzone_A8185Value;
                  num2 = (short) 11;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 53:
                  if (radioInformation != null)
                  {
                    num2 = (short) 52;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 12;
                case 54:
                  this.SerNum = A_0.SerialNumber;
                  num2 = (short) 23;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 55:
                  if (flag4)
                  {
                    num2 = (short) 49;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 40;
                case 56:
                  if (A_0.AstroOtarRadioIds != null)
                  {
                    num2 = (short) 10;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 40;
                case 57:
                  if (A_0.TrkSysIds != null & flag2)
                  {
                    num2 = (short) 41;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_202;
                case 58:
                  if (dataProfIp.BTSubIP != null)
                  {
                    num2 = (short) 8;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 18;
                case 59:
                  if (A_0.RadioAlias != null)
                  {
                    num2 = (short) 13;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 26;
                default:
                  goto label_3;
              }
label_194:
              feature3 = FeatureManager.GetFeature(2021) as SecureWideRecset;
              num2 = (short) 6;
              num1 = (int) (IntPtr) num2;
              continue;
label_202:
              num2 = (short) 4;
              num1 = (int) (IntPtr) num2;
              continue;
label_259:
              num2 = (short) 56;
              num1 = (int) (IntPtr) num2;
            }
label_106:
            return flag1;
label_266:
            return flag3;
        }
    }
  }

  private void a(object A_0)
  {
    int num1;
    IAcpConstraints iacpConstraints;
    short num2;
    switch (0)
    {
      case 0:
label_2:
        iacpConstraints = A_0 as IAcpConstraints;
        num2 = (short) 1;
        num1 = (int) (IntPtr) num2;
        goto default;
      default:
        while (true)
        {
          switch (num1)
          {
            case 0:
              num2 = (short) 1;
              if (num2 == (short) 0)
                goto label_7;
              goto label_7;
            case 1:
              if (iacpConstraints == null)
                goto label_7;
              break;
            case 2:
              iacpConstraints.CalculateApplicability();
              iacpConstraints.CalculateEditability(true);
              iacpConstraints.CalculateVisibility(true);
              num2 = (short) 0;
              num1 = (int) (IntPtr) num2;
              continue;
            default:
              goto label_2;
          }
label_4:
          num2 = (short) 2;
          num1 = (int) (IntPtr) num2;
          continue;
label_7:
          num2 = (short) 27814;
          int num3 = (int) num2;
          num2 = (short) 27814;
          int num4 = (int) num2;
          switch (num3 == num4 ? 1 : 0)
          {
            case 0:
            case 2:
              goto label_4;
            default:
              goto label_8;
          }
        }
label_8:
        num2 = (short) 0;
        if (num2 == (short) 0)
          ;
        num2 = (short) 0;
        break;
    }
  }

  private string a(string A_0)
  {
    int num1;
    int length;
    short num2;
    switch (0)
    {
      case 0:
label_2:
        length = A_0.IndexOf(char.MinValue);
        num2 = (short) 3;
        num1 = (int) (IntPtr) num2;
        goto default;
      default:
        while (true)
        {
          switch (num1)
          {
            case 0:
              num2 = (short) 1;
              if (num2 == (short) 0)
                ;
              A_0 = A_0.Substring(0, length);
              num2 = (short) 1;
              num1 = (int) (IntPtr) num2;
              continue;
            case 1:
              num2 = (short) 0;
              goto case 2;
            case 2:
              num2 = (short) 27321;
              int num3 = (int) num2;
              num2 = (short) 27321;
              int num4 = (int) num2;
              switch (num3 == num4 ? 1 : 0)
              {
                case 0:
                case 2:
                  break;
                default:
                  goto label_13;
              }
              break;
            case 3:
              if (length == 0)
              {
                num2 = (short) 4;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              num2 = (short) 5;
              num1 = (int) (IntPtr) num2;
              continue;
            case 4:
              A_0 = "";
              num2 = (short) 2;
              num1 = (int) (IntPtr) num2;
              continue;
            case 5:
              if (length <= 0)
                goto case 2;
              break;
            default:
              goto label_2;
          }
          num2 = (short) 0;
          num1 = (int) (IntPtr) num2;
        }
label_13:
        num2 = (short) 0;
        if (num2 == (short) 0)
          ;
        return A_0;
    }
  }

  internal void CallMainUiProcess(double n, string stat)
  {
    short num1 = 30684;
    int num2 = (int) num1;
    num1 = (short) 30684;
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
        ((DispatcherObject) this).Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Delegate) new PageCloneExpress.UpdateProgress(this.CloneRadio_updateStatus), (object) n, (object) stat);
        break;
      default:
        goto case 1;
    }
  }

  internal void CloneRadio_updateStatus(double n, string stat)
  {
    int A_1 = 3;
    int num1;
    short num2;
    switch (0)
    {
      case 0:
label_2:
        this.progressBar2.Value = (double) (int) (n * 100.0);
        num2 = (short) 25;
        num1 = (int) (IntPtr) num2;
        goto default;
      default:
        while (true)
        {
          switch (num1)
          {
            case 0:
              if (!(stat == AppResources.Read_Radio_Verification_Start))
              {
                num2 = (short) 24;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              num2 = (short) 3;
              num1 = (int) (IntPtr) num2;
              continue;
            case 1:
              goto label_64;
            case 2:
              goto label_29;
            case 3:
              goto label_41;
            case 4:
              goto label_40;
            case 5:
              if (stat == AppResources.Radio_Erase_in_Progress_please_wait)
              {
                num2 = (short) 36;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              num2 = (short) 41;
              num1 = (int) (IntPtr) num2;
              continue;
            case 6:
              goto label_60;
            case 7:
              goto label_33;
            case 8:
              goto label_37;
            case 9:
              if (stat == AppResources.Read_Radio_Info_Complete)
              {
                num2 = (short) 8;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              num2 = (short) 13;
              num1 = (int) (IntPtr) num2;
              continue;
            case 10:
              goto label_38;
            case 11:
              if (stat == AppResources.LP_Cannot_Determine_Host_Version)
              {
                num2 = (short) 26;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              num2 = (short) 14;
              num1 = (int) (IntPtr) num2;
              continue;
            case 12:
              num2 = (short) -16641;
              int num3 = (int) num2;
              num2 = (short) -16641;
              int num4 = (int) num2;
              switch (num3 == num4 ? 1 : 0)
              {
                case 0:
                case 2:
                  break;
                default:
                  goto label_78;
              }
              break;
            case 13:
              if (!(stat == AppResources.ReadRadio_Calling_End_Read_Radio))
              {
                num2 = (short) 42;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              break;
            case 14:
              if (stat == AppResources.LP_Radio_display_Language_Not_Supported_By_this_radio)
              {
                num2 = (short) 2;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_93;
            case 15:
              num2 = (short) 1;
              if (num2 == (short) 0)
                ;
              if (!(stat == AppResources.WriteRadio_Close_Port))
              {
                num2 = (short) 5;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              num2 = (short) 19;
              num1 = (int) (IntPtr) num2;
              continue;
            case 16 /*0x10*/:
              goto label_39;
            case 17:
              if (!string.IsNullOrEmpty(LanguagePackHelper.warningOTAPMessage))
              {
                num2 = (short) 38;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_89;
            case 18:
              if (!(stat == AppResources.Reading_radio_codeplug_))
              {
                num2 = (short) 39;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              num2 = (short) 10;
              num1 = (int) (IntPtr) num2;
              continue;
            case 19:
              goto label_52;
            case 20:
              goto label_53;
            case 21:
              if (this.m)
              {
                num2 = (short) 6;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              num2 = (short) 17;
              num1 = (int) (IntPtr) num2;
              continue;
            case 22:
              num2 = (short) 21;
              num1 = (int) (IntPtr) num2;
              continue;
            case 23:
              if (stat == AppResources.Open_Port_Complete)
              {
                num2 = (short) 12;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              num2 = (short) 31 /*0x1F*/;
              num1 = (int) (IntPtr) num2;
              continue;
            case 24:
              if (stat == AppResources.Read_Radio_Verification_Complete)
              {
                num2 = (short) 30;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              num2 = (short) 32 /*0x20*/;
              num1 = (int) (IntPtr) num2;
              continue;
            case 25:
              if (stat == AppResources.Opening_Port)
              {
                num2 = (short) 7;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              num2 = (short) 23;
              num1 = (int) (IntPtr) num2;
              continue;
            case 26:
              goto label_73;
            case 27:
              if (!(stat == AppResources.Writing_radio_codeplug_completed))
              {
                num2 = (short) 29;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              num2 = (short) 22;
              num1 = (int) (IntPtr) num2;
              continue;
            case 28:
              goto label_86;
            case 29:
              if (stat == AppResources.WriteRadio_eject_radio)
              {
                num2 = (short) 34;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              num2 = (short) 43;
              num1 = (int) (IntPtr) num2;
              continue;
            case 30:
              goto label_42;
            case 31 /*0x1F*/:
              if (!(stat == AppResources.Read_Radio_Info))
              {
                num2 = (short) 9;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              num2 = (short) 28;
              num1 = (int) (IntPtr) num2;
              continue;
            case 32 /*0x20*/:
              if (stat == AppResources.Writing_radio_codeplug)
              {
                num2 = (short) 37;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              num2 = (short) 40;
              num1 = (int) (IntPtr) num2;
              continue;
            case 33:
              goto label_25;
            case 34:
              goto label_5;
            case 35:
              goto label_9;
            case 36:
              goto label_87;
            case 37:
              goto label_65;
            case 38:
              goto label_88;
            case 39:
              if (stat == AppResources.ReadRadio_Reading_codeplug_from_radio)
              {
                num2 = (short) 20;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              num2 = (short) 0;
              num1 = (int) (IntPtr) num2;
              continue;
            case 40:
              if (!(stat == AppResources.WriteRadio_Writing_codeplug_to_radio))
              {
                num2 = (short) 27;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              num2 = (short) 1;
              num1 = (int) (IntPtr) num2;
              continue;
            case 41:
              if (!(stat == AppResources.Password_validation_failed))
              {
                num2 = (short) 11;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              num2 = (short) 16 /*0x10*/;
              num1 = (int) (IntPtr) num2;
              continue;
            case 42:
              if (stat == AppResources.Reading_radio_codeplug_completed)
              {
                num2 = (short) 33;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              num2 = (short) 18;
              num1 = (int) (IntPtr) num2;
              continue;
            case 43:
              if (!(stat == AppResources.WaitForRadioEject_Id))
              {
                num2 = (short) 15;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              num2 = (short) 4;
              num1 = (int) (IntPtr) num2;
              continue;
            default:
              goto label_2;
          }
          num2 = (short) 35;
          num1 = (int) (IntPtr) num2;
        }
label_5:
        ((ContentControl) this.ProgText).Content = (object) AppResources.Write_radio_releasing_radio;
        break;
label_9:
        ((ContentControl) this.ProgText).Content = (object) AppResources.Read_radio_codeplug_complete;
        break;
label_25:
        ((ContentControl) this.ProgText).Content = (object) AppResources.Read_Radio_Info;
        break;
label_29:
        this.m = true;
        break;
label_33:
        ((ContentControl) this.ProgText).Content = (object) AppResources.Opening_Connection_To_Radio;
        break;
label_37:
        ((ContentControl) this.ProgText).Content = (object) AppResources.Read_radio_info_complete_;
        break;
label_38:
        num2 = (short) 0;
        ((ContentControl) this.ProgText).Content = (object) AppResources.Read_Radio_Info;
        break;
label_39:
        ((ContentControl) this.ProgText).Content = (object) AppResources.Password_validation_failed_suspension;
        break;
label_40:
        this.b.StartTimer();
        this.c = true;
        break;
label_41:
        ((ContentControl) this.ProgText).Content = (object) AppResources.Read_Radio_Verification_Start_;
        break;
label_42:
        ((ContentControl) this.ProgText).Content = (object) AppResources.Read_Radio_Verification_Complete;
        break;
label_52:
        ((ContentControl) this.ProgText).Content = (object) AppResources.Write_radio_release_complete;
        break;
label_53:
        ((ContentControl) this.ProgText).Content = (object) AppResources.Begin_read_codeplug;
        break;
label_60:
        ((ContentControl) this.ProgText).Content = (object) AppResources.Write_radio_complete_LP_Radio_display_Lng_Not_Supported_By_this_radio;
        break;
label_64:
        ((ContentControl) this.ProgText).Content = (object) AppResources.Begin_write_to_radio;
        break;
label_65:
        ((ContentControl) this.ProgText).Content = (object) AppResources.Write_to_radio_in_progress;
        break;
label_73:
        ((ContentControl) this.ProgText).Content = (object) AppResources.LP_Cannot_Determine_Host_Version;
        break;
label_78:
        num2 = (short) 0;
        if (num2 == (short) 0)
          ;
        ((ContentControl) this.ProgText).Content = (object) AppResources.Connecting_opened_to_radio;
        break;
label_86:
        ((ContentControl) this.ProgText).Content = (object) AppResources.Read_radio_info_start_;
        break;
label_87:
        ((ContentControl) this.ProgText).Content = (object) AppResources.Radio_Erasing_please_wait;
        break;
label_88:
        ((ContentControl) this.ProgText).Content = (object) (AppResources.Write_Complete + RptMgrErrorHandler.b("ꚅ", A_1) + LanguagePackHelper.warningOTAPMessage);
        break;
label_89:
        ((ContentControl) this.ProgText).Content = (object) AppResources.Write_to_radio_complete;
        break;
label_93:
        ((ContentControl) this.ProgText).Content = (object) stat;
        break;
    }
  }

  internal void CallMainFinish(bool status)
  {
    short num1 = 0;
    num1 = (short) 22388;
    int num2 = (int) num1;
    num1 = (short) 22388;
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
        ((DispatcherObject) this).Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Delegate) new PageCloneExpress.MainFinish(this.CloneFinished), (object) status);
        break;
      default:
        goto case 1;
    }
  }

  internal void CloneFinished(bool status)
  {
    int A_1 = 10;
    int num1;
    short num2;
    switch (0)
    {
      case 0:
label_2:
        this.m = false;
        LanguagePackHelper.warningOTAPMessage = string.Empty;
        num2 = (short) 4;
        num1 = (int) (IntPtr) num2;
        goto default;
      default:
        StatusMessagesManager statusMsgReport;
        while (true)
        {
          switch (num1)
          {
            case 0:
              DVRSXmlUtil.ExportDVRSAfterClone(this.n);
              num2 = (short) 2;
              num1 = (int) (IntPtr) num2;
              continue;
            case 1:
              ((UIElement) this.ExpSerialNumber).Visibility = Visibility.Visible;
              ((Expander) this.ExpSerialNumber).IsExpanded = true;
              ((UIElement) this.ExpTrkSysIDList).Visibility = Visibility.Visible;
              ((Expander) this.ExpTrkSysIDList).IsExpanded = true;
              ((UIElement) this.ExpCnvSysIDList).Visibility = Visibility.Visible;
              ((Expander) this.ExpCnvSysIDList).IsExpanded = true;
              ((UIElement) this.ExpIndAstroOtarRadioIDList).Visibility = Visibility.Visible;
              ((Expander) this.ExpIndAstroOtarRadioIDList).IsExpanded = true;
              ((UIElement) this.ExpDataWide).Visibility = Visibility.Visible;
              ((Expander) this.ExpDataWide).IsExpanded = true;
              ((UIElement) this.ExpDataProfileList).Visibility = Visibility.Visible;
              ((Expander) this.ExpDataProfileList).IsExpanded = true;
              ((UIElement) this.ExpUserInfo).Visibility = Visibility.Visible;
              ((Expander) this.ExpUserInfo).IsExpanded = true;
              ((UIElement) this.ExpBluetooth).Visibility = Visibility.Visible;
              ((Expander) this.ExpBluetooth).IsExpanded = true;
              num2 = (short) 8;
              num1 = (int) (IntPtr) num2;
              continue;
            case 2:
              goto label_14;
            case 3:
              this.CloneButton.IsEnabled = true;
              Win32APIs.EnableCloseMenuItem(this.l, true);
              this.c = false;
              this.b.Stop();
              num2 = (short) 6;
              num1 = (int) (IntPtr) num2;
              continue;
            case 4:
              num2 = (short) 1;
              if (num2 == (short) 0)
                ;
              if (status)
              {
                num2 = (short) 1;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              statusMsgReport = AppInfoManager.StatusMsgReport;
              num2 = (short) 5;
              num1 = (int) (IntPtr) num2;
              continue;
            case 5:
              if (!statusMsgReport.ContainsField(RptMgrErrorHandler.b("\uDF8C\uEE8E\uF590朗杖랖쪘ﺚ\uEF9C\uF69E삠쾢薤\uE9A6\uDCA8욪쾬쪮쎰鎲살잶\uDDB8\uDABA즼\uDABEꗀ", A_1)))
              {
                num2 = (short) 10;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto case 8;
            case 6:
              if (status)
              {
                num2 = (short) 0;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_23;
            case 7:
              num2 = (short) 0;
              RadioAccessValidator.RestoreCachedCodeplugSecurityFields(this.d, this.e, this.f, this.g, this.h, this.j, this.i);
              num2 = (short) 3;
              num1 = (int) (IntPtr) num2;
              continue;
            case 8:
            case 11:
              num2 = (short) 9;
              num1 = (int) (IntPtr) num2;
              continue;
            case 9:
              if (this.k)
              {
                num2 = (short) 7;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto case 3;
            case 10:
              statusMsgReport.ContainsField(RptMgrErrorHandler.b("\uDF8C\uEE8E\uF590朗杖랖쪘ﺚ\uEF9C\uF69E삠쾢薤\uE9A6\uDCA8욪쾬쪮쎰鎲살잶\uDDB8\uDABA즼\uDABE\uE1C0ꗂ꓄껆ꗈ껊꧌", A_1));
              num2 = (short) 11;
              num1 = (int) (IntPtr) num2;
              continue;
            default:
              goto label_2;
          }
        }
label_14:
        num2 = (short) 30935;
        int num3 = (int) num2;
        num2 = (short) 30935;
        int num4 = (int) num2;
        switch (num3 == num4 ? 1 : 0)
        {
          case 0:
          case 2:
            goto label_2;
          default:
            num2 = (short) 0;
            if (num2 == (short) 0)
              ;
            return;
        }
label_23:
        break;
    }
  }

  internal void CloneW_DisplayOTAP(
    ProgrammingOperation ProgOp,
    OTAPProgrammingParameters LastCommsOTAPUserState,
    SpecialFeatures.Comms.Comms.RadioOTAPObject RadioObject)
  {
    short num = -22973;
    switch ((short) -22973 == num)
    {
      case true:
        num = (short) 0;
        if (num == (short) 0)
          ;
        num = (short) 1;
        if (num == (short) 0)
          ;
        ((DispatcherObject) this).Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Delegate) new PageCloneExpress.MainUIDisplayOTAP(this.DisplayOTAP), (object) ProgOp, (object) LastCommsOTAPUserState, (object) RadioObject);
        break;
      default:
        goto case 1;
    }
  }

  internal void DisplayOTAP(
    ProgrammingOperation ProgOp,
    OTAPProgrammingParameters LastCommsOTAPUserState,
    SpecialFeatures.Comms.Comms.RadioOTAPObject RadioObject)
  {
    int A_1 = 19;
    int num1 = 0;
    short num2;
    while (true)
    {
      switch (num1)
      {
        case 0:
label_1:
          switch (0)
          {
            case 0:
              goto label_3;
            default:
              continue;
          }
        case 1:
          num2 = (short) 1;
          if (num2 == (short) 0)
            ;
          OTAPProgrammingWindow programmingWindow = new OTAPProgrammingWindow(ProgOp, LastCommsOTAPUserState);
          Window mainWindow = Application.Current.MainWindow;
          programmingWindow.Owner = mainWindow;
          bool? otapDialogResult = programmingWindow.ShowDialog();
          RadioObject(otapDialogResult, programmingWindow.OTAPProgrammingLastState, programmingWindow.PrescenceResult);
          Semaphore.OpenExisting(RptMgrErrorHandler.b("\uD995첗\uDB99첛\uDA9D즟톡풣쪥즧펩ﮫ쾭\uD9AF욱", A_1)).Release(1);
          num2 = (short) 0;
          num2 = (short) 2;
          num1 = (int) (IntPtr) num2;
          continue;
        case 2:
          goto label_8;
        default:
label_3:
          if (!(bool) Application.Current.Properties[(object) RptMgrErrorHandler.b("햕\uF797\uF799\uF19Bﾝ캟욡\uE8A3쾥욧쾩\uEFABﺭ\uE3AF", A_1)])
          {
            num2 = (short) 23033;
            int num3 = (int) num2;
            num2 = (short) 23033;
            int num4 = (int) num2;
            switch (num3 == num4 ? 1 : 0)
            {
              case 0:
              case 2:
                goto label_1;
              default:
                num2 = (short) 0;
                if (num2 == (short) 0)
                  ;
                num2 = (short) 1;
                num1 = (int) (IntPtr) num2;
                continue;
            }
          }
          else
            goto label_10;
      }
    }
label_8:
    return;
label_10:;
  }

  internal void CloneW_DisplayRadioQuery(SpecialFeatures.Comms.Comms.RadioRtn RadioRtn)
  {
    short num = -14359;
    switch ((short) -14359 == num)
    {
      case true:
        num = (short) 1;
        if (num == (short) 0)
          ;
        num = (short) 0;
        if (num == (short) 0)
          ;
        ((DispatcherObject) this).Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Delegate) new PageCloneExpress.WriteRadioQuery(this.DisplayRadioQuery), (object) RadioRtn);
        break;
      default:
        goto case 1;
    }
  }

  internal void DisplayRadioQuery(SpecialFeatures.Comms.Comms.RadioRtn RadioRtn)
  {
    int A_1 = 10;
    int num1 = 0;
    short num2;
    while (true)
    {
      switch (num1)
      {
        case 0:
label_1:
          switch (0)
          {
            case 0:
              goto label_3;
            default:
              continue;
          }
        case 1:
          MessageBoxResult RadioRtn1 = MessageBox.Show(AppResources.Warning_You_are_about_to_write_protect_the_attached_radio, AppResources.Radio_Write_Protect_Warning, MessageBoxButton.OKCancel, MessageBoxImage.Exclamation);
          RadioRtn(RadioRtn1);
          Semaphore.OpenExisting(RptMgrErrorHandler.b("\uDF8C\uEE8E\uF590朗杖삖\uEB98\uF29A\uE99C爵\uF3A0욢톤", A_1)).Release(1);
          num2 = (short) 0;
          num2 = (short) 2;
          num1 = (int) (IntPtr) num2;
          continue;
        case 2:
          goto label_8;
        default:
label_3:
          num2 = (short) 1;
          if (num2 == (short) 0)
            ;
          if (!(bool) Application.Current.Properties[(object) RptMgrErrorHandler.b("캌\uE08Eﲐﺒ\uF494練ﶘ힚\uF49C\uF19E쒠\uE0A2\uF5A4\uF4A6", A_1)])
          {
            num2 = (short) 28154;
            int num3 = (int) num2;
            num2 = (short) 28154;
            int num4 = (int) num2;
            switch (num3 == num4 ? 1 : 0)
            {
              case 0:
              case 2:
                goto label_1;
              default:
                num2 = (short) 0;
                if (num2 == (short) 0)
                  ;
                num2 = (short) 1;
                num1 = (int) (IntPtr) num2;
                continue;
            }
          }
          else
            goto label_10;
      }
    }
label_8:
    return;
label_10:;
  }

  private void OnRadioEjectTimeOut(object A_0, EventArgs A_1)
  {
    int num1 = 0;
    while (true)
    {
      short num2;
      switch (num1)
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
          if (this.c)
          {
            num2 = (short) 1899;
            int num3 = (int) num2;
            num2 = (short) 1899;
            int num4 = (int) num2;
            switch (num3 == num4 ? 1 : 0)
            {
              case 0:
                goto label_3;
              case 2:
                goto label_16;
              default:
                num2 = (short) 1;
                if (num2 == (short) 0)
                  ;
                num2 = (short) 0;
                if (num2 == (short) 0)
                  ;
                num2 = (short) 4;
                num1 = (int) (IntPtr) num2;
                continue;
            }
          }
          else
            goto label_8;
        case 2:
          num2 = (short) 1;
          num1 = (int) (IntPtr) num2;
          continue;
        case 3:
          goto label_6;
        case 4:
          Win32APIs.EnableCloseMenuItem(this.l, true);
          this.b.Stop();
          num2 = (short) 3;
          num1 = (int) (IntPtr) num2;
          continue;
      }
      num2 = (short) 0;
      if (this.b != null)
      {
        num2 = (short) 2;
        num1 = (int) (IntPtr) num2;
      }
      else
        goto label_15;
    }
label_6:
    return;
label_15:
    return;
label_8:
    return;
label_3:
    return;
label_16:;
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "5.0.10.0")]
  public void InitializeComponent()
  {
    int A_1 = 3;
label_2:
    short num1 = 0;
    if (this.q)
    {
      num1 = (short) 7943;
      int num2 = (int) num1;
      num1 = (short) 7943;
      int num3 = (int) num1;
      switch (num2 == num3 ? 1 : 0)
      {
        case 0:
        case 2:
          goto label_2;
        default:
          num1 = (short) 1;
          if (num1 == (short) 0)
            ;
          num1 = (short) 0;
          if (num1 == (short) 0)
            break;
          break;
      }
    }
    else
    {
      this.q = true;
      Application.LoadComponent((object) this, new Uri(RptMgrErrorHandler.b("ꦅ\uDB87憎\uE98B\uED8D憐\uF391\uF893킕ﶗﮙ\uE89B\uEB9D튟잡힣鶥쮧얩솫\uDEAD\uDFAF\uDCB1톳\uD8B5첷閹\uDFBB튽꾿곁ꇃ\uE3C5難韛꿋ꇍ뻏듑뷓뇕귗꣙뷛ꫝ觟跡諣짥诧蛩菫胭闯ퟱ웳웵鷷苹賻賽旿焁眃⤅砇欉欋欍猏縑笓砕紗缙搛渝刟䜡圣唥ا利䴫䌭尯", A_1), UriKind.Relative));
    }
  }

  [EditorBrowsable(EditorBrowsableState.Never)]
  [GeneratedCode("PresentationBuildTasks", "5.0.10.0")]
  [DebuggerNonUserCode]
  void IComponentConnector.Connect(int connectionId, object target)
  {
    int num1 = 2;
    short num2;
    while (true)
    {
      num2 = (short) 0;
      switch (num1)
      {
        case 0:
          num2 = (short) 1;
          num1 = (int) (IntPtr) num2;
          continue;
        case 1:
          goto label_56;
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
      switch (connectionId)
      {
        case 1:
          goto label_34;
        case 2:
          goto label_41;
        case 3:
          goto label_48;
        case 4:
          goto label_40;
        case 5:
          goto label_9;
        case 6:
          goto label_46;
        case 7:
          goto label_19;
        case 8:
          goto label_18;
        case 9:
          goto label_7;
        case 10:
          goto label_27;
        case 11:
          goto label_13;
        case 12:
          goto label_30;
        case 13:
          goto label_20;
        case 14:
          goto label_29;
        case 15:
          goto label_26;
        case 16 /*0x10*/:
          goto label_31;
        case 17:
          goto label_45;
        case 18:
          goto label_23;
        case 19:
          goto label_16;
        case 20:
          goto label_24;
        case 21:
          goto label_36;
        case 22:
          goto label_38;
        case 23:
          goto label_55;
        case 24:
          goto label_35;
        case 25:
          goto label_33;
        case 26:
          goto label_12;
        case 27:
          goto label_6;
        case 28:
          goto label_49;
        case 29:
          goto label_51;
        case 30:
          goto label_25;
        case 31 /*0x1F*/:
          goto label_54;
        case 32 /*0x20*/:
          goto label_10;
        case 33:
          goto label_5;
        case 34:
          goto label_50;
        case 35:
          goto label_53;
        case 36:
          goto label_22;
        case 37:
          goto label_37;
        case 38:
          goto label_28;
        case 39:
          goto label_8;
        case 40:
          goto label_47;
        case 41:
          goto label_14;
        case 42:
          goto label_21;
        case 43:
          goto label_11;
        case 44:
          goto label_39;
        case 45:
          goto label_44;
        case 46:
          goto label_15;
        case 47:
          goto label_52;
        default:
          num2 = (short) 0;
          num1 = (int) (IntPtr) num2;
          continue;
      }
    }
label_5:
    this.ExpDataProfileList = (AcpExpander) target;
    return;
label_6:
    this.PeerIPAddress1 = (AcpViewOnlyCtrl) target;
    return;
label_7:
    this.SerialNumberName = (AcpViewOnlyCtrl) target;
    return;
label_8:
    this.LblUserInfoPINPassword = (AcpViewOnlyCtrl) target;
    return;
label_9:
    this.ExpCloneExp = (AcpExpander) target;
    return;
label_10:
    this.DataWideGeneralBTPeerIPAddress = (AcpViewOnlyCtrl) target;
    return;
label_11:
    this.LblRadioAlias = (AcpViewOnlyCtrl) target;
    return;
label_12:
    this.DataWideGeneralSubscriberIPAddress1 = (AcpViewOnlyCtrl) target;
    return;
label_13:
    this.ExpTrkSysIDList = (AcpExpander) target;
    return;
label_14:
    this.LblUserInfoUserLoginUnitID = (AcpViewOnlyCtrl) target;
    return;
label_15:
    this.BluetoothFriendlyName = (AcpViewOnlyCtrl) target;
    return;
label_16:
    this.LblSecWideASTROOTARIndividualASTROOTARRadioID = (AcpViewOnlyCtrl) target;
    return;
label_18:
    this.ExpSerialNumber = (AcpExpander) target;
    return;
label_19:
    this.HelpButton = (Button) target;
    this.HelpButton.Click += new RoutedEventHandler(this.buttonHelp_Click);
    return;
label_20:
    this.TrkSysName_Col = (UnboundField) target;
    return;
label_21:
    this.RadWideUserInformationandPasswordsUserLoginUnitID = (AcpViewOnlyCtrl) target;
    return;
label_22:
    this.ExpUserInfo = (AcpExpander) target;
    return;
label_23:
    this.ExpIndAstroOtarRadioIDList = (AcpExpander) target;
    return;
label_24:
    this.SecWideASTROOTARIndividualASTROOTARRadioID = (AcpViewOnlyCtrl) target;
    return;
label_25:
    this.DataWideGeneralBTSubscriberIPAddress = (AcpViewOnlyCtrl) target;
    return;
label_26:
    this.UnitID_Col = (UnboundField) target;
    return;
label_27:
    this.RadInfoGeneralSerialNumber = (AcpViewOnlyCtrl) target;
    return;
label_28:
    this.RadWideUserInformationandPasswordsSoftIDUsername = (AcpViewOnlyCtrl) target;
    return;
label_29:
    this.TrkSysID_Col = (UnboundField) target;
    return;
label_30:
    this.TrunkingIDDataPresenter = (AcpXamDataPresenter) target;
    return;
label_31:
    num2 = (short) 1;
    if (num2 == (short) 0)
      ;
    this.ExpCnvSysIDList = (AcpExpander) target;
    return;
label_33:
    this.SubscriberIPAddress1 = (AcpViewOnlyCtrl) target;
    return;
label_34:
    ((FrameworkElement) target).Loaded += new RoutedEventHandler(((AcpPageFeature) this).OnLoaded);
    ((FrameworkElement) target).Unloaded += new RoutedEventHandler(((AcpPageFeature) this).OnUnloaded);
    return;
label_35:
    this.ExpDataWide = (AcpExpander) target;
    return;
label_36:
    this.IndAstroOtardRadioIDDataPresenter = (AcpXamDataPresenter) target;
    return;
label_37:
    this.SoftIDUsername = (AcpViewOnlyCtrl) target;
    return;
label_38:
    this.SecureKMFProfile_Col = (UnboundField) target;
    return;
label_39:
    this.RadWideUserInformationandPasswordsRadioAlias = (AcpViewOnlyCtrl) target;
    return;
label_40:
    this.progressBar2 = (ProgressBar) target;
    return;
label_41:
    num2 = (short) -28189;
    int num3 = (int) num2;
    num2 = (short) -28189;
    int num4 = (int) num2;
    switch (num3 == num4 ? 1 : 0)
    {
      case 0:
      case 2:
        goto label_23;
      default:
        num2 = (short) 0;
        if (num2 == (short) 0)
          ;
        ((CommandBinding) target).Executed += new ExecutedRoutedEventHandler(this.buttonHelp_Click);
        ((CommandBinding) target).CanExecute += new CanExecuteRoutedEventHandler(this.F1HelpCommandCanExcute);
        return;
    }
label_44:
    this.ExpBluetooth = (AcpExpander) target;
    return;
label_45:
    this.CnvSysIDDataPresenter = (AcpXamDataPresenter) target;
    return;
label_46:
    this.CloneButton = (Button) target;
    this.CloneButton.Click += new RoutedEventHandler(this.OnCloneExpressClone);
    return;
label_47:
    this.RadWideUserInformationandPasswordsPINPassword = (AcpPasswordEyeBox) target;
    return;
label_48:
    this.ProgText = (AcpLabel) target;
    return;
label_49:
    this.DataWideGeneralPeerIPAddress1 = (AcpViewOnlyCtrl) target;
    return;
label_50:
    this.DataProfilesDataPresenter = (AcpXamDataPresenter) target;
    return;
label_51:
    this.BTSubscriberIPAddress = (AcpViewOnlyCtrl) target;
    return;
label_52:
    this.RadWideBluetoothFriendlyName = (AcpViewOnlyCtrl) target;
    return;
label_53:
    this.DataProfileName_Col = (UnboundField) target;
    return;
label_54:
    this.BTPeerIPAddress = (AcpViewOnlyCtrl) target;
    return;
label_55:
    this.IndAstroOtarRadioID_Col = (UnboundField) target;
    return;
label_56:
    this.q = true;
  }

  public delegate void MainUIDisplayOTAP(
    ProgrammingOperation ProgOp,
    OTAPProgrammingParameters LastCommsOTAPUserState,
    SpecialFeatures.Comms.Comms.RadioOTAPObject radioObject);

  private delegate void UpdateProgress(double n, string stat);

  private delegate void MainFinish(bool status);

  public delegate void WriteRadioQuery(SpecialFeatures.Comms.Comms.RadioRtn info);

  private delegate bool MainThreadUpdateRadioIds(RadioIdInfo TempRadioIds);
}
