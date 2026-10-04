// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.CloneWizard.PageCloneWizard
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

using ACPBrowser;
using AcpBusinessLayer;
using AcpCommonLib;
using AcpCommonLib.FieldsReport;
using AcpCommonLib.StatusMessage;
using AcpCommonLib.UndoRedo;
using AcpFileHandlerLib;
using AcpSecurityLib;
using AcpUI;
using AcpUI.Common;
using CommonResources;
using Infragistics.Windows.DataPresenter;
using Motorola.Common.Communication.CommonUtil;
using Motorola.Common.CustomException;
using Motorola.CommonCPS.Server.EntityModel;
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
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Threading;

#nullable disable
namespace SpecialFeatures.CloneWizard;

public class PageCloneWizard : 
  AcpPageFeature,
  INotifyPropertyChanged,
  IDisposable,
  IComponentConnector
{
  private bool a;
  private RadioEjectTimer b;
  private bool c;
  private int d;
  private int e;
  private int f;
  private int g;
  private bool h;
  private bool i;
  private bool j;
  private int k;
  private int l;
  private int m;
  private int n;
  private ASKProgrammingHistoryInnerRecset o;
  private bool p;
  private SpecialFeatures.Comms.Clone q = new SpecialFeatures.Comms.Clone();
  private IntPtr r = IntPtr.Zero;
  private Cursor s;
  private bool t;
  private string u;
  private bool v;
  private string w = "";
  private string y;
  internal AcpThemeBase ThemeBaseObj;
  internal Hyperlink HLinkMultipleRadio;
  internal Hyperlink HLinkFileClone;
  internal Hyperlink HLinkTrkSysIDList;
  internal Hyperlink HLinkExpCnvSysIDList;
  internal Hyperlink HLinkExpIndAstroOtarRadioIDList;
  internal Hyperlink HLinkDataWide;
  internal Hyperlink HLinkDataProfileList;
  internal Hyperlink HLinkUserInfo;
  internal Hyperlink HLinkBluetooth;
  internal StackPanel MyStackPanel;
  internal AcpLabel ProgText;
  internal ProgressBar progressBar2;
  internal Button ReadRadioIDsbutton;
  internal Button CloneRadiobutton;
  internal Button btnBatchProgrammingHelp;
  internal AcpExpander ExpMultipleRadio;
  internal AcpLabel UnitID;
  internal AcpTextBox TrkSysUnitIDIncrement;
  internal AcpLabel ASTROID;
  internal AcpTextBox CnvSysAstroIDIncrement;
  internal AcpLabel MDCID;
  internal AcpTextBox CnvSysMdcIDIncrement;
  internal AcpLabel AstroOtarRadioID;
  internal AcpTextBox IndAstroOtarRadioIDIncrement;
  internal AcpButton OK;
  internal AcpExpander ExpFileClone;
  internal AcpLabel FileCloneEn;
  internal AcpCheckBox FileCloneEnBox;
  internal AcpLabel SerialNumber;
  internal AcpTextBox SerialNumberBox;
  internal AcpExpander ExpTrkSysIDList;
  internal AcpXamDataPresenter TrunkingIDDataPresenter;
  internal UnboundField TrkSysName_Col;
  internal UnboundField TrkSysID_Col;
  internal UnboundField UnitID_Col;
  internal AcpExpander ExpCnvSysIDList;
  internal AcpXamDataPresenter CnvSysIDDataPresenter;
  internal AcpExpander ExpIndAstroOtarRadioIDList;
  internal AcpLabel LblSecWideASTROOTARIndividualASTROOTARRadioID;
  internal AcpTextBoxSpinner SecWideASTROOTARIndividualASTROOTARRadioID;
  internal AcpXamDataPresenter IndAstroOtardRadioIDDataPresenter;
  internal UnboundField SecureKMFProfile_Col;
  internal UnboundField IndAstroOtarRadioID_Col;
  internal AcpExpander ExpDataWide;
  internal AcpGroupBox GrpBoxExpanderDataWideGeneralSerialLink1Addresses;
  internal AcpLabel SubscriberIPAddress1;
  internal AcpTextBox DataWideGeneralSubscriberIPAddress1;
  internal AcpLabel PeerIPAddress1;
  internal AcpTextBox DataWideGeneralPeerIPAddress1;
  internal AcpGroupBox GrpBoxExpanderDataWideGeneralBluetoothDUNAddresses;
  internal AcpLabel DataWideBTSubscriberIPAddress;
  internal AcpTextBox DataWideGeneralBTSubscriberIPAddress;
  internal AcpLabel DataWideBTPeerIPAddress;
  internal AcpTextBox DataWideGeneralBTPeerIPAddress;
  internal AcpExpander ExpDataProfileList;
  internal AcpXamDataPresenter DataProfilesDataPresenter;
  internal UnboundField DataProfileName_Col;
  internal AcpExpander ExpUserInfo;
  internal AcpLabel SoftIDUsername;
  internal AcpTextBox RadWideUserInformationandPasswordsSoftIDUsername;
  internal AcpLabel LblUserInfoPINPassword;
  internal AcpPasswordEyeBox RadWideUserInformationandPasswordsPINPassword;
  internal AcpLabel LblUserInfoUserLoginUnitID;
  internal AcpTextBox RadWideUserInformationandPasswordsUserLoginUnitID;
  internal AcpLabel LblRadioAlias;
  internal AcpTextBox RadWideUserInformationandPasswordsRadioAlias;
  internal AcpExpander ExpBluetooth;
  internal AcpLabel BluetoothFriendlyName;
  internal AcpTextBox RadWideBluetoothFriendlyName;
  private bool aa;

  public PageCloneWizard()
  {
    this.InitializeComponent();
    // ISSUE: explicit non-virtual call
    ((UIElement) this).PreviewKeyDown += new KeyEventHandler(this.PageCloneWizard_PreviewKeyDown);
    ((UIElement) this).PreviewMouseDown += new MouseButtonEventHandler(this.PageCloneWizard_PreviewMouseDown);
  }

  private void PageCloneWizard_PreviewMouseDown(object A_0, MouseButtonEventArgs A_1)
  {
    int num1 = 0;
    while (true)
    {
      short num2 = 7838;
      int num3 = (int) num2;
      num2 = (short) 7838;
      int num4 = (int) num2;
      switch (num3 == num4 ? 1 : 0)
      {
        case 0:
        case 2:
label_10:
          num2 = (short) 1;
          num1 = (int) (IntPtr) num2;
          continue;
        default:
          num2 = (short) 0;
          num2 = (short) 0;
          if (num2 == (short) 0)
            ;
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
              goto label_8;
            case 2:
              A_1.Handled = true;
              goto label_10;
          }
          if (this.t)
          {
            num2 = (short) 1;
            if (num2 == (short) 0)
              ;
            num2 = (short) 2;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto label_11;
      }
    }
label_8:
    return;
label_11:;
  }

  private void PageCloneWizard_PreviewKeyDown(object A_0, KeyEventArgs A_1)
  {
    int num1 = 0;
    while (true)
    {
      short num2 = -12983;
      int num3 = (int) num2;
      num2 = (short) -12983;
      int num4 = (int) num2;
      switch (num3 == num4 ? 1 : 0)
      {
        case 0:
        case 2:
label_10:
          num2 = (short) 1;
          num1 = (int) (IntPtr) num2;
          continue;
        default:
          num2 = (short) 0;
          num2 = (short) 0;
          if (num2 == (short) 0)
            ;
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
              goto label_8;
            case 2:
              A_1.Handled = true;
              goto label_10;
          }
          if (this.t)
          {
            num2 = (short) 1;
            if (num2 == (short) 0)
              ;
            num2 = (short) 2;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto label_11;
      }
    }
label_8:
    return;
label_11:;
  }

  public virtual void OnLoaded(object sender, RoutedEventArgs e)
  {
    int num1 = 6;
    while (true)
    {
      short num2;
      AcpExpander acpExpander;
      IEnumerator enumerator;
      switch (num1)
      {
        case 0:
          num2 = (short) 1;
          if (num2 == (short) 0)
            ;
          if (((FrameworkElement) this).Parent is Window)
          {
            num2 = (short) 11;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto case 3;
        case 1:
          AppInfoManager.ClonePageNotLoaded = false;
          acpExpander = (AcpExpander) null;
          enumerator = this.MyStackPanel.Children.GetEnumerator();
          num2 = (short) 9;
          num1 = (int) (IntPtr) num2;
          continue;
        case 2:
          num2 = (short) 11658;
          int num3 = (int) num2;
          num2 = (short) 11658;
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
              // ISSUE: explicit non-virtual call
              if (!__nonvirtual (((UIElement) this).IsKeyboardFocusWithin))
              {
                num2 = (short) 7;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_40;
          }
          break;
        case 3:
          this.b = new RadioEjectTimer();
          this.b.Tick += new EventHandler(this.OnRadioEjectTimeOut);
          num2 = (short) 8;
          num1 = (int) (IntPtr) num2;
          continue;
        case 4:
          num2 = (short) 0;
          num1 = (int) (IntPtr) num2;
          continue;
        case 5:
          goto label_36;
        case 6:
          switch (0)
          {
            case 0:
              goto label_3;
            default:
              continue;
          }
        case 7:
          Keyboard.Focus((IInputElement) this);
          num2 = (short) 5;
          num1 = (int) (IntPtr) num2;
          continue;
        case 8:
          if (!this.a)
          {
            num2 = (short) 10;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto case 1;
        case 9:
          try
          {
            num2 = (short) 1;
            num1 = (int) (IntPtr) num2;
            while (true)
            {
              switch (num1)
              {
                case 0:
                  ((Collection<AcpExpander>) this.Expanders).Add(acpExpander);
                  num2 = (short) 3;
                  num1 = (int) (IntPtr) num2;
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
                  num2 = (short) 5;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 4:
                  if (!enumerator.MoveNext())
                  {
                    num2 = (short) 2;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  acpExpander = (UIElement) enumerator.Current as AcpExpander;
                  num2 = (short) 6;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 5:
                  goto label_7;
                case 6:
                  if (acpExpander != null)
                  {
                    num2 = (short) 0;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  break;
              }
              num2 = (short) 4;
              num1 = (int) (IntPtr) num2;
            }
          }
          finally
          {
            IDisposable disposable;
            switch (0)
            {
              case 0:
label_29:
                disposable = enumerator as IDisposable;
                num1 = 0;
                goto default;
              default:
                while (true)
                {
                  switch (num1)
                  {
                    case 0:
                      if (disposable != null)
                      {
                        num1 = 2;
                        continue;
                      }
                      goto label_33;
                    case 1:
                      goto label_33;
                    case 2:
                      disposable.Dispose();
                      num1 = 1;
                      continue;
                    default:
                      goto label_29;
                  }
                }
label_33:;
            }
          }
        case 10:
          num2 = (short) 0;
          this.i();
          this.a = true;
          this.progressBar2.Value = 0.0;
          SpecialFeatures.Comms.Comms.displayOTAP += new SpecialFeatures.Comms.Comms.MainUIDisplayOTAP(this.CloneW_DisplayOTAP);
          num2 = (short) 1;
          num1 = (int) (IntPtr) num2;
          continue;
        case 11:
          this.r = ((HwndSource) PresentationSource.FromVisual((Visual) this)).Handle;
          num2 = (short) 3;
          num1 = (int) (IntPtr) num2;
          continue;
        default:
label_3:
          if (((FrameworkElement) this).Parent != null)
          {
            num2 = (short) 4;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto case 3;
      }
label_7:
      this.MyStackPanel.Children[0].Focus();
      num2 = (short) 2;
      num1 = (int) (IntPtr) num2;
    }
label_36:
    return;
label_40:;
  }

  private void HLinkClick(object A_0, RoutedEventArgs A_1)
  {
    short num1 = -14191;
    int num2 = (int) num1;
    num1 = (short) -14191;
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
        this.OnHLinkClick(A_0);
        break;
      default:
        goto case 1;
    }
  }

  private void F1HelpCommandCanExcute(object A_0, CanExecuteRoutedEventArgs A_1)
  {
    short num1 = -21742;
    int num2 = (int) num1;
    num1 = (short) -21742;
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
        A_1.CanExecute = true;
        break;
      default:
        goto case 1;
    }
  }

  private void buttonHelp_Click(object A_0, RoutedEventArgs A_1)
  {
    int A_1_1 = 11;
    try
    {
      switch (true)
      {
        case true:
          if (true)
            ;
          Utility.CloseHelpWindowIfOpen();
          Utility.DisplayCPSHelpDITA(RptMgrErrorHandler.b("궍\uF68F\uF491\uF193꾕ﮗꮙ꾛ꚝ", A_1_1));
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

  private void i()
  {
    short num1 = -10308;
    int num2 = (int) num1;
    num1 = (short) -10308;
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
        num4 = (short) 0;
        ((FrameworkElement) this.ExpMultipleRadio).DataContext = (object) FeatureManager.GetFeature(2021);
        this.a(((FrameworkElement) this.ExpMultipleRadio).DataContext);
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
        ((FrameworkElement) this.ExpFileClone).DataContext = (object) this;
        this.u = (FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation).General.RadInfoGeneralSerialNumber_A9122Value;
        this.SerNum = this.u;
        this.SerialNumberBox.IsAcpEditable = RadioAccessValidator.FileCloneSerialNumberEditabilityCheck();
        this.p = RadioAccessValidator.CacheCodeplugSecurityFields(out this.i, out this.j, out this.k, out this.l, out this.m, out this.o, out this.n);
        break;
      default:
        goto case 1;
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
        num2 = (short) 18099;
        int num3 = (int) num2;
        num2 = (short) 18099;
        int num4 = (int) num2;
        switch (num3 == num4 ? 1 : 0)
        {
          case 0:
            return;
          case 1:
            num2 = (short) 1;
            if (num2 == (short) 0)
              ;
            num2 = (short) 0;
            if (num2 == (short) 0)
              ;
            num2 = (short) 0;
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
          switch (num1)
          {
            case 0:
              if (iacpConstraints != null)
              {
                num2 = (short) 2;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_3;
            case 1:
              goto label_13;
            case 2:
              iacpConstraints.CalculateApplicability();
              iacpConstraints.CalculateEditability(true);
              iacpConstraints.CalculateVisibility(true);
              num2 = (short) 1;
              num1 = (int) (IntPtr) num2;
              continue;
            default:
              goto label_2;
          }
label_1:;
        }
label_13:
        break;
label_3:
        break;
    }
  }

  public virtual void OnUnloaded(object sender, RoutedEventArgs e)
  {
    int num1;
    short num2;
    switch (0)
    {
      case 0:
label_2:
        AppInfoManager.ClonePageNotLoaded = true;
        this.CloneRadiobutton.IsEnabled = true;
        this.ReadRadioIDsbutton.IsEnabled = true;
        ((UIElement) this.FileCloneEnBox).IsEnabled = true;
        Win32APIs.EnableCloseMenuItem(this.r, true);
        SpecialFeatures.Comms.Comms.displayOTAP -= new SpecialFeatures.Comms.Comms.MainUIDisplayOTAP(this.CloneW_DisplayOTAP);
        this.h();
        num2 = (short) 151;
        int num3 = (int) num2;
        num2 = (short) 151;
        int num4 = (int) num2;
        switch (num3 == num4 ? 1 : 0)
        {
          case 0:
          case 2:
            break;
          case 1:
            num2 = (short) 0;
            if (num2 == (short) 0)
              ;
            num2 = (short) 0;
            num1 = (int) (IntPtr) num2;
            goto label_1;
          default:
            num2 = (short) 0;
            goto case 1;
        }
        break;
      default:
        while (true)
        {
          switch (num1)
          {
            case 0:
              if (this.a)
              {
                num2 = (short) 2;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_10;
            case 1:
              goto label_10;
            case 2:
              num2 = (short) 1;
              if (num2 == (short) 0)
                ;
              base.OnUnloaded(sender, e);
              this.a = false;
              num2 = (short) 1;
              num1 = (int) (IntPtr) num2;
              continue;
            default:
              goto label_2;
          }
label_1:;
        }
    }
label_10:
    this.b.Tick -= new EventHandler(this.OnRadioEjectTimeOut);
  }

  protected virtual void Dispose(bool disposing)
  {
    int num1 = 2;
    short num2;
    while (true)
    {
      switch (num1)
      {
        case 0:
          this.q.Dispose();
          this.q = (SpecialFeatures.Comms.Clone) null;
          num2 = (short) 3;
          num1 = (int) (IntPtr) num2;
          continue;
        case 1:
          num2 = (short) 0;
          num2 = (short) 4;
          num1 = (int) (IntPtr) num2;
          continue;
        case 2:
          goto label_1;
        case 3:
          goto label_8;
        case 4:
          num2 = (short) 1;
          if (num2 == (short) 0)
            ;
          if (this.q != null)
          {
            num2 = (short) 0;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto label_10;
        default:
          goto label_3;
      }
label_2:;
    }
label_1:
    switch (0)
    {
      case 0:
        goto label_3;
      default:
        goto label_2;
    }
label_8:
    return;
    while (disposing)
    {
      num2 = (short) 4725;
      int num3 = (int) num2;
      num2 = (short) 4725;
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
          num1 = (int) (IntPtr) num2;
          goto label_2;
      }
label_3:;
    }
    return;
label_10:;
  }

  public void Dispose()
  {
    short num1 = 1;
    if (num1 == (short) 0)
      ;
    num1 = (short) -695;
    int num2 = (int) num1;
    num1 = (short) -695;
    int num3 = (int) num1;
    switch (num2 == num3)
    {
      case true:
        num1 = (short) 0;
        if (num1 == (short) 0)
          ;
        this.Dispose(true);
        GC.SuppressFinalize((object) this);
        break;
      default:
        num1 = (short) 0;
        goto case 1;
    }
  }

  private void h()
  {
    int num1;
    Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation radioInformation;
    short num2;
    switch (0)
    {
      case 0:
label_2:
        this.q.ForceClose();
        radioInformation = FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation;
        num2 = (short) 2;
        num1 = (int) (IntPtr) num2;
        goto default;
      default:
        while (true)
        {
          switch (num1)
          {
            case 0:
              goto label_10;
            case 1:
label_8:
              if (this.p)
              {
                num2 = (short) 3;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_14;
            case 2:
              if (radioInformation.General.RadInfoGeneralSerialNumber_A9122Value != this.u)
              {
                num2 = (short) 4;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto case 5;
            case 3:
              RadioAccessValidator.RestoreCachedCodeplugSecurityFields(this.i, this.j, this.k, this.l, this.m, this.o, this.n);
              num2 = (short) 0;
              num1 = (int) (IntPtr) num2;
              continue;
            case 4:
              num2 = (short) 29200;
              int num3 = (int) num2;
              num2 = (short) 29200;
              int num4 = (int) num2;
              switch (num3 == num4 ? 1 : 0)
              {
                case 0:
                case 2:
                  goto label_8;
                default:
                  num2 = (short) 0;
                  if (num2 == (short) 0)
                    ;
                  radioInformation.General.RadInfoGeneralSerialNumber_A9122.SetValue(this.u);
                  num2 = (short) 0;
                  num2 = (short) 5;
                  num1 = (int) (IntPtr) num2;
                  continue;
              }
            case 5:
              num2 = (short) 1;
              if (num2 == (short) 0)
                ;
              num2 = (short) 1;
              num1 = (int) (IntPtr) num2;
              continue;
            default:
              goto label_2;
          }
        }
label_10:
        break;
label_14:
        break;
    }
  }

  public virtual void SetDataContext()
  {
    short num1 = 12716;
    int num2 = (int) num1;
    num1 = (short) 12716;
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
        ((FrameworkElement) this.ExpMultipleRadio).DataContext = (object) FeatureManager.GetFeature(2021);
        ((DataPresenterBase) this.TrunkingIDDataPresenter).DataSource = (IEnumerable) FeatureManager.GetFeature(2064);
        ((DataPresenterBase) this.CnvSysIDDataPresenter).DataSource = (IEnumerable) FeatureManager.GetFeature(2053);
        ((FrameworkElement) this.ExpIndAstroOtarRadioIDList).DataContext = (object) FeatureManager.GetFeature(2021);
        ((DataPresenterBase) this.IndAstroOtardRadioIDDataPresenter).DataSource = (IEnumerable) FeatureManager.GetFeature(2055);
        ((DataPresenterBase) this.DataProfilesDataPresenter).DataSource = (IEnumerable) FeatureManager.GetFeature(2054);
        ((FrameworkElement) this.ExpDataWide).DataContext = (object) FeatureManager.GetFeature(2028)[0][10066];
        IAcpFeatureSection dataContext = (IAcpFeatureSection) ((FrameworkElement) this.ExpDataWide).DataContext;
        ((FrameworkElement) this.ExpUserInfo).DataContext = (object) FeatureManager.GetFeature(2045);
        ((FrameworkElement) this.ExpBluetooth).DataContext = (object) FeatureManager.GetFeature(2045)[0][10630];
        ((FrameworkElement) this.ExpFileClone).DataContext = (object) this;
        break;
      default:
        goto case 1;
    }
  }

  private void OK_Click(object A_0, RoutedEventArgs A_1)
  {
    int num1;
    short num2;
    switch (0)
    {
      case 0:
label_2:
        int.TryParse(((TextBox) this.TrkSysUnitIDIncrement).Text, out this.d);
        int.TryParse(((TextBox) this.CnvSysAstroIDIncrement).Text, out this.f);
        int.TryParse(((TextBox) this.CnvSysMdcIDIncrement).Text, out this.e);
        int.TryParse(((TextBox) this.IndAstroOtarRadioIDIncrement).Text, out this.g);
        num2 = (short) 5;
        num1 = (int) (IntPtr) num2;
        goto default;
      default:
        while (true)
        {
          IEnumerator<FeatureNode> enumerator;
          switch (num1)
          {
            case 0:
              num2 = (short) 8;
              num1 = (int) (IntPtr) num2;
              continue;
            case 1:
              this.g();
              num2 = (short) 0;
              num2 = (short) 6;
              num1 = (int) (IntPtr) num2;
              continue;
            case 2:
              if (this.f == 0)
              {
                num2 = (short) 0;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto case 10;
            case 3:
              enumerator = ((Collection<FeatureNode>) (FeatureManager.GetFeature(2064) as TrunkingSystemRecset)).GetEnumerator();
              num2 = (short) 4;
              num1 = (int) (IntPtr) num2;
              continue;
            case 4:
              try
              {
                num2 = (short) 1;
                int num3 = (int) (IntPtr) num2;
                while (true)
                {
                  switch (num3)
                  {
                    case 0:
                      num2 = (short) 4;
                      num3 = (int) (IntPtr) num2;
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
                    case 3:
                      if (!enumerator.MoveNext())
                      {
                        num2 = (short) 0;
                        num3 = (int) (IntPtr) num2;
                        continue;
                      }
                      this.a((IAcpField) ((Motorola.MackinawCPS.CoreFeatures.TrunkingSystem.TrunkingSystem) enumerator.Current).General.TrkSysGeneralUnitID_A12651, this.d);
                      num2 = (short) 2;
                      num3 = (int) (IntPtr) num2;
                      continue;
                    case 4:
                      goto label_51;
                  }
                  num2 = (short) 3;
                  num3 = (int) (IntPtr) num2;
                }
              }
              finally
              {
                short num4 = 1;
                int num5 = (int) (IntPtr) num4;
                while (true)
                {
                  switch (num5)
                  {
                    case 0:
                      num4 = (short) 23263;
                      int num6 = (int) num4;
                      num4 = (short) 23263;
                      int num7 = (int) num4;
                      switch (num6 == num7 ? 1 : 0)
                      {
                        case 0:
                        case 2:
                          goto label_16;
                        default:
                          num4 = (short) 0;
                          if (num4 == (short) 0)
                            ;
                          enumerator.Dispose();
                          num4 = (short) 2;
                          num5 = (int) (IntPtr) num4;
                          continue;
                      }
                    case 1:
label_16:
                      switch (0)
                      {
                        case 0:
                          break;
                        default:
                          continue;
                      }
                      break;
                    case 2:
                      goto label_23;
                  }
                  if (enumerator != null)
                  {
                    num4 = (short) 0;
                    num5 = (int) (IntPtr) num4;
                  }
                  else
                    break;
                }
label_23:;
              }
            case 5:
              if (this.d != 0)
              {
                num2 = (short) 1;
                if (num2 == (short) 0)
                  ;
                num2 = (short) 3;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_51;
            case 6:
              goto label_54;
            case 7:
              try
              {
                num2 = (short) 4;
                int num8 = (int) (IntPtr) num2;
                while (true)
                {
                  Motorola.MackinawCPS.CoreFeatures.ConventionalSystem.ConventionalSystem current;
                  switch (num8)
                  {
                    case 1:
                      if (this.f != 0)
                      {
                        num2 = (short) 6;
                        num8 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto case 8;
                    case 2:
                      if (enumerator.MoveNext())
                      {
                        current = (Motorola.MackinawCPS.CoreFeatures.ConventionalSystem.ConventionalSystem) enumerator.Current;
                        num2 = (short) 1;
                        num8 = (int) (IntPtr) num2;
                        continue;
                      }
                      num2 = (short) 7;
                      num8 = (int) (IntPtr) num2;
                      continue;
                    case 3:
                      if (this.e != 0)
                      {
                        num2 = (short) 5;
                        num8 = (int) (IntPtr) num2;
                        continue;
                      }
                      break;
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
                      this.a((IAcpField) current.General.CnvSysGeneralMDCPrimaryID_A8744, this.e);
                      num2 = (short) 0;
                      num8 = (int) (IntPtr) num2;
                      continue;
                    case 6:
                      this.a((IAcpField) current.General.CnvSysGeneralIndividualID_A8287, this.f);
                      num2 = (short) 8;
                      num8 = (int) (IntPtr) num2;
                      continue;
                    case 7:
                      num2 = (short) 9;
                      num8 = (int) (IntPtr) num2;
                      continue;
                    case 8:
                      num2 = (short) 3;
                      num8 = (int) (IntPtr) num2;
                      continue;
                    case 9:
                      goto label_24;
                  }
                  num2 = (short) 2;
                  num8 = (int) (IntPtr) num2;
                }
              }
              finally
              {
                short num9 = 1;
                int num10 = (int) (IntPtr) num9;
                while (true)
                {
                  switch (num10)
                  {
                    case 0:
                      enumerator.Dispose();
                      num9 = (short) 2;
                      num10 = (int) (IntPtr) num9;
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
                      goto label_49;
                  }
                  if (enumerator != null)
                  {
                    num9 = (short) 0;
                    num10 = (int) (IntPtr) num9;
                  }
                  else
                    break;
                }
label_49:;
              }
            case 8:
              if (this.e != 0)
              {
                num2 = (short) 10;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              break;
            case 9:
              if (this.g != 0)
              {
                num2 = (short) 1;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_58;
            case 10:
              enumerator = ((Collection<FeatureNode>) (FeatureManager.GetFeature(2053) as ConventionalSystemRecset)).GetEnumerator();
              num2 = (short) 7;
              num1 = (int) (IntPtr) num2;
              continue;
            default:
              goto label_2;
          }
label_24:
          num2 = (short) 9;
          num1 = (int) (IntPtr) num2;
          continue;
label_51:
          num2 = (short) 2;
          num1 = (int) (IntPtr) num2;
        }
label_54:
        break;
label_58:
        break;
    }
  }

  private void g()
  {
    int num1;
    IAcpRecordset feature;
    short num2;
    switch (0)
    {
      case 0:
label_2:
        feature = FeatureManager.GetFeature(2021);
        num2 = (short) 4;
        num1 = (int) (IntPtr) num2;
        goto default;
      default:
        AcpSimpleRangeField astrootarRadioIdA8284;
        int num3;
        while (true)
        {
          switch (num1)
          {
            case 0:
              num2 = (short) 7;
              num1 = (int) (IntPtr) num2;
              continue;
            case 1:
label_9:
              astrootarRadioIdA8284 = (feature[0] as Motorola.MackinawCPS.CoreFeatures.SecureWide.SecureWide).ASTROOTAR.SecWideASTROOTARIndividualASTROOTARRadioID_A8284;
              num3 = ((AcpField<int>) astrootarRadioIdA8284).Value + this.g;
              num2 = (short) -4891;
              int num4 = (int) num2;
              num2 = (short) -4891;
              int num5 = (int) num2;
              switch (num4 == num5 ? 1 : 0)
              {
                case 0:
                case 2:
                  goto label_9;
                default:
                  num2 = (short) 0;
                  if (num2 == (short) 0)
                    ;
                  num2 = (short) 0;
                  num2 = (short) 5;
                  num1 = (int) (IntPtr) num2;
                  continue;
              }
            case 2:
              goto label_20;
            case 3:
              num2 = (short) 6;
              num1 = (int) (IntPtr) num2;
              continue;
            case 4:
              if (feature != null)
              {
                num2 = (short) 1;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_20;
            case 5:
              if (num3 <= ((AcpRangeField<int, string>) astrootarRadioIdA8284).Max)
              {
                num2 = (short) 0;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto case 9;
            case 6:
              int num6 = UndoManager.StopUndoRedo() ? 1 : 0;
              ((AcpField<int>) astrootarRadioIdA8284).Value = num3;
              if (num6 != 0)
              {
                num2 = (short) 8;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_20;
            case 7:
              if (((AcpField<int>) astrootarRadioIdA8284).Value < ((AcpRangeField<int, string>) astrootarRadioIdA8284).Min)
              {
                num2 = (short) 9;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto case 3;
            case 8:
              UndoManager.StartUndoRedo();
              num2 = (short) 2;
              num1 = (int) (IntPtr) num2;
              continue;
            case 9:
              num3 = ((AcpRangeField<int, string>) astrootarRadioIdA8284).Min - 1;
              num2 = (short) 3;
              num1 = (int) (IntPtr) num2;
              continue;
            default:
              goto label_2;
          }
        }
label_20:
        num2 = (short) 1;
        if (num2 == (short) 0)
          break;
        break;
    }
  }

  private void a(IAcpField A_0, int A_1)
  {
    int num1 = 12;
    while (true)
    {
      short num2 = 1;
      if (num2 == (short) 0)
        ;
      IAcpRangeField iacpRangeField;
      int num3;
      switch (num1)
      {
        case 0:
          if (iacpRangeField != null)
          {
            num2 = (short) 2;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto case 8;
        case 1:
          num2 = (short) 0;
          if (((AcpField<int>) A_0).Value >= iacpRangeField.Min)
            goto case 8;
          break;
        case 2:
          num2 = (short) 10;
          num1 = (int) (IntPtr) num2;
          continue;
        case 3:
          int num4 = UndoManager.StopUndoRedo() ? 1 : 0;
          ((AcpField<int>) A_0).Value = num3;
          if (num4 != 0)
          {
            num2 = (short) 7;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto label_28;
        case 4:
          if (A_0.Applicable)
          {
            num2 = (short) 16 /*0x10*/;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto label_32;
        case 5:
          num2 = (short) 9;
          num1 = (int) (IntPtr) num2;
          continue;
        case 6:
          num2 = (short) -7033;
          int num5 = (int) num2;
          num2 = (short) -7033;
          int num6 = (int) num2;
          switch (num5 == num6 ? 1 : 0)
          {
            case 0:
            case 2:
              break;
            default:
              num2 = (short) 0;
              if (num2 == (short) 0)
                ;
              num2 = (short) 4;
              num1 = (int) (IntPtr) num2;
              continue;
          }
          break;
        case 7:
          UndoManager.StartUndoRedo();
          num2 = (short) 13;
          num1 = (int) (IntPtr) num2;
          continue;
        case 8:
          num2 = (short) 3;
          num1 = (int) (IntPtr) num2;
          continue;
        case 9:
          if (A_0.Visible)
          {
            num2 = (short) 6;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto label_26;
        case 10:
          if (num3 <= iacpRangeField.Max)
          {
            num2 = (short) 14;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto case 11;
        case 11:
          num3 = iacpRangeField.Min - 1;
          num2 = (short) 8;
          num1 = (int) (IntPtr) num2;
          continue;
        case 12:
          switch (0)
          {
            case 0:
              goto label_4;
            default:
              continue;
          }
        case 13:
          goto label_21;
        case 14:
          num2 = (short) 1;
          num1 = (int) (IntPtr) num2;
          continue;
        case 15:
          if (A_0.Editable)
          {
            num2 = (short) 17;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto label_23;
        case 16 /*0x10*/:
          num2 = (short) 15;
          num1 = (int) (IntPtr) num2;
          continue;
        case 17:
          num3 = ((AcpField<int>) A_0).Value + A_1;
          iacpRangeField = A_0 as IAcpRangeField;
          num2 = (short) 0;
          num1 = (int) (IntPtr) num2;
          continue;
        default:
label_4:
          if (A_0 != null)
          {
            num2 = (short) 5;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto label_36;
      }
      num2 = (short) 11;
      num1 = (int) (IntPtr) num2;
    }
label_21:
    return;
label_36:
    return;
label_32:
    return;
label_28:
    return;
label_26:
    return;
label_23:;
  }

  private void OnCloneWizardClone(object A_0, RoutedEventArgs A_1)
  {
    int num1 = 9;
    short num2;
    while (true)
    {
      Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation radioInformation;
      string A_0_1;
      bool? isChecked;
      switch (num1)
      {
        case 0:
          goto label_7;
        case 1:
          num2 = (short) 6;
          num1 = (int) (IntPtr) num2;
          continue;
        case 2:
          goto label_5;
        case 3:
          goto label_13;
        case 4:
          goto label_29;
        case 5:
          goto label_34;
        case 6:
          if (!AppInfoManager.InvalidFieldsReport.HasFields)
          {
            num2 = (short) 11;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          num2 = (short) 3;
          num1 = (int) (IntPtr) num2;
          continue;
        case 7:
          A_0_1 = string.Empty;
          ((ContentControl) this.ProgText).Content = (object) AppResources.Saving_Codeplug_;
          num2 = (short) 13;
          num1 = (int) (IntPtr) num2;
          continue;
        case 8:
label_23:
          num2 = (short) 0;
          DVRSXmlUtil.ExportDVRSAfterClone(((TextBox) this.SerialNumberBox).Text);
          num2 = (short) 2;
          num1 = (int) (IntPtr) num2;
          continue;
        case 9:
          switch (0)
          {
            case 0:
              break;
            default:
              continue;
          }
          break;
        case 10:
          if (isChecked.Value)
          {
            num2 = (short) 1;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          this.ReadRadioIDsbutton.IsEnabled = false;
          this.CloneRadiobutton.IsEnabled = false;
          ((UIElement) this.FileCloneEnBox).IsEnabled = false;
          Win32APIs.EnableCloseMenuItem(this.r, false);
          Utility.SaveFieldWithFocus();
          this.f();
          this.PrePackHandler();
          this.t = true;
          this.s = ((FrameworkElement) this).Cursor;
          ((FrameworkElement) this).Cursor = Cursors.Wait;
          new Thread(new ThreadStart(this.e)).Start();
          num2 = (short) 4;
          num1 = (int) (IntPtr) num2;
          continue;
        case 11:
          if (!this.SerialNumberBox.IsAcpValid)
          {
            num2 = (short) 8289;
            int num3 = (int) num2;
            num2 = (short) 8289;
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
                num2 = (short) 0;
                num1 = (int) (IntPtr) num2;
                continue;
            }
          }
          else
          {
            AcpLabel acpLabel = new AcpLabel();
            radioInformation = FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation;
            num2 = (short) 12;
            num1 = (int) (IntPtr) num2;
            continue;
          }
        case 12:
          if (radioInformation.General.RadInfoGeneralSerialNumber_A9122Value != ((TextBox) this.SerialNumberBox).Text)
          {
            num2 = (short) 14;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto case 7;
        case 13:
          int num5 = this.b(out A_0_1) ? 1 : 0;
          ((ContentControl) this.ProgText).Content = (object) A_0_1;
          if (radioInformation.General.RadInfoGeneralSerialNumber_A9122Value != this.u)
            radioInformation.General.RadInfoGeneralSerialNumber_A9122.SetValue(this.u);
          if (num5 != 0)
          {
            num2 = (short) 8;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto label_19;
        case 14:
          radioInformation.General.RadInfoGeneralSerialNumber_A9122.SetValue(((TextBox) this.SerialNumberBox).Text);
          num2 = (short) 7;
          num1 = (int) (IntPtr) num2;
          continue;
      }
      if (!WiFiPasswordUtil.OpenValidateDlg((Window) ((FrameworkElement) this).Parent))
      {
        num2 = (short) 5;
        num1 = (int) (IntPtr) num2;
      }
      else
      {
        isChecked = ((ToggleButton) this.FileCloneEnBox).IsChecked;
        num2 = (short) 10;
        num1 = (int) (IntPtr) num2;
      }
    }
label_5:
    return;
label_34:
    return;
label_7:
    ((ContentControl) this.ProgText).Content = (object) AppResources.FileClone_Invalid_Serial_Number;
    return;
label_13:
    ((ContentControl) this.ProgText).Content = (object) AppResources.Codeplug_has_Invalid_fields_Please_correct_them_and_try_again;
    return;
label_19:
    return;
label_29:
    num2 = (short) 1;
    if (num2 == (short) 0)
      ;
  }

  private void f()
  {
    int num1 = 1;
    short num2;
    List<FieldsReportInfo>.Enumerator enumerator;
    while (true)
    {
      switch (num1)
      {
        case 0:
          goto label_5;
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
          num2 = (short) 0;
          if (AppInfoManager.InvalidFieldsReport.HasFields)
          {
            num2 = (short) 4;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto label_24;
        case 3:
          num2 = (short) 2;
          num1 = (int) (IntPtr) num2;
          continue;
        case 4:
          num2 = (short) 8230;
          int num3 = (int) num2;
          num2 = (short) 8230;
          int num4 = (int) num2;
          switch (num3 == num4 ? 1 : 0)
          {
            case 0:
            case 2:
              num2 = (short) 0;
              num1 = (int) (IntPtr) num2;
              continue;
            default:
              num2 = (short) 1;
              if (num2 == (short) 0)
                ;
              num2 = (short) 0;
              if (num2 == (short) 0)
                ;
              enumerator = new List<FieldsReportInfo>(AppInfoManager.InvalidFieldsReport.Fields).GetEnumerator();
              goto case 0;
          }
      }
      if (!AppInfoManager.InvalidFieldsReport.UiHasFields)
      {
        num2 = (short) 3;
        num1 = (int) (IntPtr) num2;
      }
      else
        break;
    }
    return;
label_5:
    try
    {
      num2 = (short) 1;
      int num5 = (int) (IntPtr) num2;
      while (true)
      {
        FieldsReportInfo current;
        switch (num5)
        {
          case 0:
            if (enumerator.MoveNext())
            {
              current = enumerator.Current;
              num2 = (short) 3;
              num5 = (int) (IntPtr) num2;
              continue;
            }
            num2 = (short) 2;
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
            num2 = (short) 6;
            num5 = (int) (IntPtr) num2;
            continue;
          case 3:
            if (!((FieldInfo) current).Field.Valid)
            {
              num2 = (short) 5;
              num5 = (int) (IntPtr) num2;
              continue;
            }
            break;
          case 5:
            ((IAcpCommon) ((FieldInfo) current).Field).ResetToDefault();
            num2 = (short) 4;
            num5 = (int) (IntPtr) num2;
            continue;
          case 6:
            goto label_22;
        }
        num2 = (short) 0;
        num5 = (int) (IntPtr) num2;
      }
label_22:
      return;
    }
    finally
    {
      enumerator.Dispose();
    }
label_24:;
  }

  internal void PrePackHandler()
  {
    short num1 = 30550;
    int num2 = (int) num1;
    num1 = (short) 30550;
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
        new PackUnpackExecutor().PrePackHandler();
        break;
      default:
        goto case 1;
    }
  }

  private void e()
  {
    int num1;
    bool status;
    short num2;
    switch (0)
    {
      case 0:
label_2:
        status = false;
        num2 = (short) 2;
        num1 = (int) (IntPtr) num2;
        goto default;
      default:
        while (true)
        {
          switch (num1)
          {
            case 0:
              num2 = (short) -5604;
              int num3 = (int) num2;
              num2 = (short) -5604;
              int num4 = (int) num2;
              switch (num3 == num4 ? 1 : 0)
              {
                case 0:
                case 2:
                  goto label_10;
                default:
                  num2 = (short) 0;
                  if (num2 == (short) 0)
                    ;
                  num2 = (short) 5;
                  num1 = (int) (IntPtr) num2;
                  continue;
              }
            case 1:
              if (!this.h)
              {
                num2 = (short) 3;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto case 0;
            case 2:
              num2 = (short) 0;
              num2 = (short) 1;
              if (num2 == (short) 0)
                ;
              if (AppInfoManager.InvalidFieldsReport.HasFields)
              {
                num2 = (short) 4;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              SpecialFeatures.Comms.Comms.updateStatus += new SpecialFeatures.Comms.Comms.DisplayUpdateStatus(this.CallMainUiProcess);
              num2 = (short) 1;
              num1 = (int) (IntPtr) num2;
              continue;
            case 3:
              AppInfoManager.StatusMsgReport.Clear();
              num2 = (short) 0;
              num1 = (int) (IntPtr) num2;
              continue;
            case 4:
              goto label_10;
            case 5:
              goto label_6;
            default:
              goto label_2;
          }
        }
label_6:
        try
        {
          status = this.d();
        }
        catch (Exception ex)
        {
          if (ex.Message == AppResources.Codeplug_Exceeds_Size_Limit_On_Write)
            status = false;
        }
        this.CallMainFinish(status);
        SpecialFeatures.Comms.Comms.updateStatus -= new SpecialFeatures.Comms.Comms.DisplayUpdateStatus(this.CallMainUiProcess);
        break;
label_10:
        this.CallMainUiProcess(0.0, AppResources.Codeplug_has_Invalid_fields_Please_correct_them_and_try_again);
        this.CallMainFinish(status);
        break;
    }
  }

  public string StatusOfClone
  {
    get
    {
      short num1 = 1;
      if (num1 == (short) 0)
        ;
      num1 = (short) 16931;
      int num2 = (int) num1;
      num1 = (short) 16931;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          num1 = (short) 0;
          if (num1 == (short) 0)
            ;
          return this.x;
        default:
          num1 = (short) 0;
          goto case 1;
      }
    }
    private set
    {
      short num1 = -29374;
      int num2 = (int) num1;
      num1 = (short) -29374;
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
          this.x = value;
          break;
        default:
          goto case 1;
      }
    }
  }

  private void a(double A_0, string A_1)
  {
    short num1 = 9623;
    int num2 = (int) num1;
    num1 = (short) 9623;
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
        this.StatusOfClone = A_1;
        break;
      default:
        goto case 1;
    }
  }

  private bool d()
  {
    int A_1 = 11;
    int num1;
    bool flag1;
    bool flag2;
    short num2;
    switch (0)
    {
      case 0:
label_2:
        flag1 = false;
        flag2 = false;
        SpecialFeatures.Comms.Comms.updateStatus += new SpecialFeatures.Comms.Comms.DisplayUpdateStatus(this.a);
        num2 = (short) 8;
        num1 = (int) (IntPtr) num2;
        goto default;
      default:
        while (true)
        {
          switch (num1)
          {
            case 0:
              try
              {
                string radioSN;
                switch (0)
                {
                  case 0:
label_22:
                    radioSN = ParseDataHelper.RadioSNToString(this.q.GetRadioParams().SerialNumber);
                    num2 = (short) 4;
                    num1 = (int) (IntPtr) num2;
                    goto default;
                  default:
                    while (true)
                    {
                      switch (num1)
                      {
                        case 0:
                          goto label_5;
                        case 1:
                          ((DispatcherObject) this).Dispatcher.Invoke((Action) (() =>
                          {
                            short num3 = -7884;
                            int num4 = (int) num3;
                            num3 = (short) -7884;
                            int num5 = (int) num3;
                            short num6;
                            switch (num4 == num5)
                            {
                              case true:
                                num6 = (short) 0;
                                if (num6 == (short) 0)
                                  ;
                                num6 = (short) 1;
                                if (num6 == (short) 0)
                                  ;
                                this.SerNum = radioSN;
                                break;
                              default:
                                num6 = (short) 0;
                                goto case 1;
                            }
                          }));
                          num2 = (short) 3;
                          num1 = (int) (IntPtr) num2;
                          continue;
                        case 2:
                          if (radioSN.Trim().Length > 0)
                          {
                            num2 = (short) 1;
                            num1 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 3;
                        case 3:
                          num2 = (short) 0;
                          num1 = (int) (IntPtr) num2;
                          continue;
                        case 4:
                          if (radioSN != null)
                          {
                            num2 = (short) 5;
                            num1 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 3;
                        case 5:
                          num2 = (short) 2;
                          num1 = (int) (IntPtr) num2;
                          continue;
                        default:
                          goto label_22;
                      }
                    }
                }
              }
              catch
              {
                break;
              }
            case 1:
              if (this.p)
              {
                num2 = (short) 9;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto case 5;
            case 2:
              goto label_19;
            case 3:
              if (!(bool) Application.Current.Properties[(object) RptMgrErrorHandler.b("춍ﾏﾑ煉\uF795\uF697ﺙ킛\uF79D캟잡\uE7A3\uF6A5ﮧ", A_1)])
              {
                num2 = (short) 6;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto case 5;
            case 4:
              if (flag1)
              {
                num2 = (short) 0;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              break;
            case 5:
              this.h = false;
              num2 = (short) 7;
              num1 = (int) (IntPtr) num2;
              continue;
            case 6:
              num2 = (short) 0;
              RadioAccessValidator.RestoreCachedCodeplugSecurityFields(this.i, this.j, this.k, this.l, this.m, this.o, this.n);
              num2 = (short) 5;
              num1 = (int) (IntPtr) num2;
              continue;
            case 7:
              if (flag2)
              {
                num2 = (short) 2;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_34;
            case 8:
              num2 = (short) 1;
              if (num2 == (short) 0)
                ;
              try
              {
                flag1 = this.q.CloneRadio(this.h, CloneParameters.CloneWriteType, CloneParameters.LastCloneOTAPUserState, ((FrameworkElement) this).Parent as Window);
              }
              catch (Exception ex)
              {
                if (ex.Message == AppResources.Codeplug_Exceeds_Size_Limit_On_Write)
                {
                  num2 = (short) 21166;
                  int num7 = (int) num2;
                  num2 = (short) 21166;
                  int num8 = (int) num2;
                  switch (num7 == num8 ? 1 : 0)
                  {
                    case 0:
                    case 2:
                      break;
                    default:
                      num2 = (short) 0;
                      if (num2 == (short) 0)
                        ;
                      flag1 = false;
                      flag2 = true;
                      break;
                  }
                }
              }
              SpecialFeatures.Comms.Comms.updateStatus -= new SpecialFeatures.Comms.Comms.DisplayUpdateStatus(this.a);
              num2 = (short) 4;
              num1 = (int) (IntPtr) num2;
              continue;
            case 9:
              num2 = (short) 3;
              num1 = (int) (IntPtr) num2;
              continue;
            default:
              goto label_2;
          }
label_5:
          num1 = 1;
        }
label_19:
        throw new CommonException(AppResources.Codeplug_Exceeds_Size_Limit_On_Write);
label_34:
        return flag1;
    }
  }

  private void OnCloneWizardReadIds(object A_0, RoutedEventArgs A_1)
  {
    short num1 = -9723;
    int num2 = (int) num1;
    num1 = (short) -9723;
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
        this.ReadRadioIDsbutton.IsEnabled = false;
        this.CloneRadiobutton.IsEnabled = false;
        ((UIElement) this.FileCloneEnBox).IsEnabled = false;
        Win32APIs.EnableCloseMenuItem(this.r, false);
        AppInfoManager.StatusMsgReport.Clear();
        this.SaveRadioIds();
        break;
      default:
        goto case 1;
    }
  }

  public void SaveRadioIds()
  {
    short num1 = 19160;
    int num2 = (int) num1;
    num1 = (short) 19160;
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
        new Thread((ThreadStart) (() =>
        {
          int A_1 = 5;
          short num5 = 0;
          num5 = (short) 0;
          int num6 = (int) num5;
          switch (num6)
          {
            default:
              RadioIdInfo radioIdInfo;
              Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation radioInformation;
              bool flag;
              bool smartnetA8184Value;
              bool smartzoneA8185Value;
              switch (0)
              {
                case 0:
label_3:
                  num5 = (short) -7851;
                  int num7 = (int) num5;
                  num5 = (short) -7851;
                  int num8 = (int) num5;
                  switch (num7 == num8 ? 1 : 0)
                  {
                    case 0:
                    case 2:
                      break;
                    default:
                      num5 = (short) 0;
                      if (num5 == (short) 0)
                        ;
                      this.h = true;
                      SpecialFeatures.Comms.Comms.updateStatus += new SpecialFeatures.Comms.Comms.DisplayUpdateStatus(this.CallMainUiProcess);
                      radioIdInfo = this.q.ReadRadioIds(CloneParameters.CloneWriteType, HeadlessAddr: RptMgrErrorHandler.b("릇뎉뺋ꂍꆏ꒑겓뢕ꦗꢙ꒛낝醟", A_1));
                      radioInformation = FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation;
                      flag = false;
                      num5 = (short) 4;
                      num6 = (int) (IntPtr) num5;
                      goto label_2;
                  }
                  break;
                default:
                  while (true)
                  {
                    switch (num6)
                    {
                      case 0:
                        goto label_10;
                      case 1:
                        goto label_13;
                      case 2:
                        num5 = (short) 1;
                        if (num5 == (short) 0)
                          ;
                        flag = true;
                        num5 = (short) 1;
                        num6 = (int) (IntPtr) num5;
                        continue;
                      case 3:
                        if (smartnetA8184Value | smartzoneA8185Value)
                        {
                          num5 = (short) 2;
                          num6 = (int) (IntPtr) num5;
                          continue;
                        }
                        goto label_13;
                      case 4:
                        if (radioInformation != null)
                        {
                          num5 = (short) 0;
                          num6 = (int) (IntPtr) num5;
                          continue;
                        }
                        goto label_13;
                      default:
                        goto label_3;
                    }
label_2:;
                  }
label_13:
                  ((DispatcherObject) this).Dispatcher.Invoke((Delegate) new PageCloneWizard.MainThreadUpdateRadioIds(this.a), (object) radioIdInfo, (object) flag);
                  this.CallMainFinish(false);
                  SpecialFeatures.Comms.Comms.updateStatus -= new SpecialFeatures.Comms.Comms.DisplayUpdateStatus(this.CallMainUiProcess);
                  return;
              }
label_10:
              smartnetA8184Value = radioInformation.Labtool.RadInfoLabtoolH37G50Smartnet_A8184Value;
              smartzoneA8185Value = radioInformation.Labtool.RadInfoLabtoolH38G51Smartzone_A8185Value;
              num5 = (short) 3;
              num6 = (int) (IntPtr) num5;
              goto label_2;
          }
        })).Start();
        break;
      default:
        goto case 1;
    }
  }

  public void SaveRadioIdsInCruncher(RadioIdInfo TempRadioIds)
  {
    int num1 = 0;
    switch (num1)
    {
      default:
        Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation radioInformation;
        bool A_1;
        short num2;
        switch (0)
        {
          case 0:
label_3:
            this.h = false;
            SpecialFeatures.Comms.Comms.updateStatus += new SpecialFeatures.Comms.Comms.DisplayUpdateStatus(this.CallMainUiProcess);
            radioInformation = FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation;
            A_1 = false;
            break;
          default:
            while (true)
            {
              bool smartnetA8184Value;
              bool smartzoneA8185Value;
              switch (num1)
              {
                case 0:
                  if (smartnetA8184Value | smartzoneA8185Value)
                  {
                    num2 = (short) 2;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_12;
                case 1:
                  goto label_8;
                case 2:
                  A_1 = true;
                  num2 = (short) 1;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 3:
                  if (radioInformation != null)
                  {
                    num2 = (short) 4;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_12;
                case 4:
                  smartnetA8184Value = radioInformation.Labtool.RadInfoLabtoolH37G50Smartnet_A8184Value;
                  smartzoneA8185Value = radioInformation.Labtool.RadInfoLabtoolH38G51Smartzone_A8185Value;
                  num2 = (short) 0;
                  num1 = (int) (IntPtr) num2;
                  continue;
                default:
                  goto label_3;
              }
label_2:;
            }
label_8:
            num2 = (short) 0;
            num2 = (short) 1;
            if (num2 == (short) 0)
              ;
label_12:
            num2 = (short) -23066;
            int num3 = (int) num2;
            num2 = (short) -23066;
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
                this.a(TempRadioIds, A_1);
                SpecialFeatures.Comms.Comms.updateStatus -= new SpecialFeatures.Comms.Comms.DisplayUpdateStatus(this.CallMainUiProcess);
                return;
            }
            break;
        }
        num2 = (short) 3;
        num1 = (int) (IntPtr) num2;
        goto label_2;
    }
  }

  private void a(RadioIdInfo A_0, bool A_1)
  {
    int A_1_1 = 3;
    switch (0)
    {
      default:
        int num1 = 20;
        short num2;
        while (true)
        {
          string strB;
          IEnumerator<FeatureNode> enumerator1;
          DataProfIP dataProfIp;
          int length;
          int index;
          DataProfIP[] dataProfIps;
          SecureWideRecset feature1;
          bool flag1;
          int num3;
          TrunkingSystemRecset feature2;
          Dictionary<string, int[]>.Enumerator enumerator2;
          ConventionalSystemRecset feature3;
          SecureKMFProfileRecset feature4;
          Motorola.MackinawCPS.CoreFeatures.DataWide.DataWide dataWide;
          switch (num1)
          {
            case 0:
              if (A_0.AstroOtarRadioIds != null)
              {
                num2 = (short) 42;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto case 1;
            case 1:
              num2 = (short) 19;
              num1 = (int) (IntPtr) num2;
              continue;
            case 2:
              try
              {
                num2 = (short) 4;
                int num4 = (int) (IntPtr) num2;
                while (true)
                {
                  Motorola.MackinawCPS.CoreFeatures.ConventionalSystem.ConventionalSystem current1;
                  string referenceKey;
                  switch (num4)
                  {
                    case 0:
                      if (enumerator1.MoveNext())
                      {
                        current1 = (Motorola.MackinawCPS.CoreFeatures.ConventionalSystem.ConventionalSystem) enumerator1.Current;
                        referenceKey = ((FeatureNode) current1).ReferenceKey;
                        enumerator2 = A_0.CnvSysIds.GetEnumerator();
                        num2 = (short) 3;
                        num4 = (int) (IntPtr) num2;
                        continue;
                      }
                      num2 = (short) 1;
                      num4 = (int) (IntPtr) num2;
                      continue;
                    case 1:
                      num2 = (short) 2;
                      num4 = (int) (IntPtr) num2;
                      continue;
                    case 2:
                      goto label_21;
                    case 3:
                      try
                      {
                        num2 = (short) 6;
                        int num5 = (int) (IntPtr) num2;
                        while (true)
                        {
                          KeyValuePair<string, int[]> current2;
                          string key;
                          string typeA13262UiValue;
                          switch (num5)
                          {
                            case 0:
                              num2 = (short) 1;
                              num5 = (int) (IntPtr) num2;
                              continue;
                            case 1:
                            case 5:
                              goto label_53;
                            case 2:
                              typeA13262UiValue = current1.General.CnvSysGeneralSystemType_A13262_UIValue;
                              num2 = (short) 7;
                              num5 = (int) (IntPtr) num2;
                              continue;
                            case 3:
                              if (enumerator2.MoveNext())
                              {
                                current2 = enumerator2.Current;
                                key = current2.Key;
                                num2 = (short) 8;
                                num5 = (int) (IntPtr) num2;
                                continue;
                              }
                              num2 = (short) 0;
                              num5 = (int) (IntPtr) num2;
                              continue;
                            case 4:
                              UndoManager.StartUndoRedo();
                              num2 = (short) 5;
                              num5 = (int) (IntPtr) num2;
                              continue;
                            case 6:
                              switch (0)
                              {
                                case 0:
                                  break;
                                default:
                                  continue;
                              }
                              break;
                            case 7:
                              int num6 = UndoManager.StopUndoRedo() ? 1 : 0;
                              if (typeA13262UiValue == AppResources.ASTRO_Id || typeA13262UiValue == AppResources.DVRS_Id)
                                ((AcpField<int>) current1.General.CnvSysGeneralIndividualID_A8287).Value = current2.Value[1];
                              else if (typeA13262UiValue == AppResources.MDC_Id)
                                ((AcpField<int>) current1.General.CnvSysGeneralMDCPrimaryID_A8744).Value = current2.Value[1];
                              if (num6 != 0)
                              {
                                num2 = (short) 4;
                                num5 = (int) (IntPtr) num2;
                                continue;
                              }
                              goto case 0;
                            case 8:
                              if (referenceKey.Equals(key.TrimEnd(new char[1])))
                              {
                                num2 = (short) 2;
                                num5 = (int) (IntPtr) num2;
                                continue;
                              }
                              break;
                          }
                          num2 = (short) 3;
                          num5 = (int) (IntPtr) num2;
                        }
                      }
                      finally
                      {
                        enumerator2.Dispose();
                      }
                    case 4:
                      switch (0)
                      {
                        case 0:
                          break;
                        default:
                          continue;
                      }
                      break;
                  }
label_53:
                  num2 = (short) 0;
                  num4 = (int) (IntPtr) num2;
                }
              }
              finally
              {
                int num7 = 2;
                while (true)
                {
                  short num8;
                  switch (num7)
                  {
                    case 0:
                      enumerator1.Dispose();
                      num8 = (short) 1;
                      num7 = (int) (IntPtr) num8;
                      continue;
                    case 1:
                      goto label_63;
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
                  if (enumerator1 != null)
                  {
                    num8 = (short) 0;
                    num7 = (int) (IntPtr) num8;
                  }
                  else
                    break;
                }
label_63:;
              }
            case 3:
            case 24:
              num2 = (short) 30;
              num1 = (int) (IntPtr) num2;
              continue;
            case 4:
              strB = dataProfIp.DataProfName.Substring(0, length);
              num2 = (short) 31 /*0x1F*/;
              num1 = (int) (IntPtr) num2;
              continue;
            case 5:
              UndoManager.StartUndoRedo();
              num2 = (short) 1;
              num1 = (int) (IntPtr) num2;
              continue;
            case 6:
            case 36:
              num2 = (short) 37;
              num1 = (int) (IntPtr) num2;
              continue;
            case 7:
              num2 = (short) 8;
              num1 = (int) (IntPtr) num2;
              continue;
            case 8:
              if (A_0.DataProfIps != null)
              {
                num2 = (short) 13;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto case 3;
            case 9:
              if (dataProfIp.BTPeerIP != null)
              {
                num2 = (short) 27;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto case 3;
            case 10:
              enumerator1 = ((Collection<FeatureNode>) feature2).GetEnumerator();
              num2 = (short) 41;
              num1 = (int) (IntPtr) num2;
              continue;
            case 11:
              if (feature1 != null)
              {
                num2 = (short) 34;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto case 1;
            case 12:
              if (num3 != -1)
              {
                num2 = (short) 28;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto case 1;
            case 13:
              dataProfIps = A_0.DataProfIps;
              index = 0;
              num2 = (short) 6;
              num1 = (int) (IntPtr) num2;
              continue;
            case 14:
              Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide radioWide1 = ((Recordset) (FeatureManager.GetFeature(2045) as RadioWideRecset))[0] as Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide;
              A_0.RadioAlias = this.a(A_0.RadioAlias);
              radioWide1.UserInformationAndPasswords.RadWideUserInformationandPasswordsRadioAlias_A8829.SetValue(A_0.RadioAlias);
              num2 = (short) 25;
              num1 = (int) (IntPtr) num2;
              continue;
            case 15:
              feature3 = FeatureManager.GetFeature(2053) as ConventionalSystemRecset;
              num2 = (short) 46;
              num1 = (int) (IntPtr) num2;
              continue;
            case 16 /*0x10*/:
              enumerator1 = ((Collection<FeatureNode>) feature3).GetEnumerator();
              num2 = (short) 2;
              num1 = (int) (IntPtr) num2;
              continue;
            case 17:
              dataWide = ((Recordset) (FeatureManager.GetFeature(2028) as DataWideRecset))[0] as Motorola.MackinawCPS.CoreFeatures.DataWide.DataWide;
              ((AcpField<long>) dataWide.General.DataWideGeneralPeerIPAddress1_A8524).SetValue(dataProfIp.PeerIP.Address);
              ((AcpField<long>) dataWide.General.DataWideGeneralSubscriberIPAddress1_A9222).SetValue(dataProfIp.SubIP.Address);
              num2 = (short) 32 /*0x20*/;
              num1 = (int) (IntPtr) num2;
              continue;
            case 18:
              if (feature2 != null)
              {
                num2 = (short) 10;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              break;
            case 19:
              if (A_0.SoftIds != null)
              {
                num2 = (short) 38;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto case 21;
            case 20:
              switch (0)
              {
                case 0:
                  goto label_4;
                default:
                  continue;
              }
            case 21:
              num2 = (short) 39;
              num1 = (int) (IntPtr) num2;
              continue;
            case 22:
              try
              {
                num2 = (short) 4;
                int num9 = (int) (IntPtr) num2;
                while (true)
                {
                  Dictionary<string, int>.Enumerator enumerator3;
                  string referenceKey;
                  Motorola.MackinawCPS.CoreFeatures.SecureKMFProfile.SecureKMFProfile current3;
                  switch (num9)
                  {
                    case 0:
                      if (enumerator1.MoveNext())
                      {
                        current3 = (Motorola.MackinawCPS.CoreFeatures.SecureKMFProfile.SecureKMFProfile) enumerator1.Current;
                        referenceKey = ((FeatureNode) current3).ReferenceKey;
                        enumerator3 = A_0.AstroOtarRadioIds.GetEnumerator();
                        num2 = (short) 3;
                        num9 = (int) (IntPtr) num2;
                        continue;
                      }
                      num2 = (short) 1;
                      num9 = (int) (IntPtr) num2;
                      continue;
                    case 1:
                      num2 = (short) 2;
                      num9 = (int) (IntPtr) num2;
                      continue;
                    case 2:
                      goto label_115;
                    case 3:
                      try
                      {
                        num2 = (short) 9;
                        int num10 = (int) (IntPtr) num2;
                        while (true)
                        {
                          KeyValuePair<string, int> current4;
                          string key;
                          switch (num10)
                          {
                            case 0:
                            case 5:
                              goto label_104;
                            case 1:
                              int num11 = UndoManager.StopUndoRedo() ? 1 : 0;
                              ((AcpField<int>) current3.ASTROOTARInformation.SecKmfProfASTROOTARInformationIndividualASTROOTARRadioID_A8285).Value = current4.Value;
                              if (num11 != 0)
                              {
                                num2 = (short) 7;
                                num10 = (int) (IntPtr) num2;
                                continue;
                              }
                              goto case 11;
                            case 2:
                              num2 = (short) 0;
                              num10 = (int) (IntPtr) num2;
                              continue;
                            case 3:
                              if (!enumerator3.MoveNext())
                              {
                                num2 = (short) 2;
                                num10 = (int) (IntPtr) num2;
                                continue;
                              }
                              current4 = enumerator3.Current;
                              key = current4.Key;
                              num2 = (short) 4;
                              num10 = (int) (IntPtr) num2;
                              continue;
                            case 4:
                              if (referenceKey.Equals(key.TrimEnd(new char[1])))
                              {
                                num2 = (short) 10;
                                num10 = (int) (IntPtr) num2;
                                continue;
                              }
                              break;
                            case 6:
                              num3 = current4.Value;
                              num2 = (short) -22086;
                              int num12 = (int) num2;
                              num2 = (short) -22086;
                              int num13 = (int) num2;
                              switch (num12 == num13 ? 1 : 0)
                              {
                                case 0:
                                case 2:
                                  goto label_104;
                                default:
                                  num2 = (short) 0;
                                  if (num2 == (short) 0)
                                    ;
                                  num2 = (short) 5;
                                  num10 = (int) (IntPtr) num2;
                                  continue;
                              }
                            case 7:
                              UndoManager.StartUndoRedo();
                              num2 = (short) 11;
                              num10 = (int) (IntPtr) num2;
                              continue;
                            case 8:
                              if (!current3.General.SecKmfProfGenIndependentKeyList_43597.Value)
                              {
                                num2 = (short) 6;
                                num10 = (int) (IntPtr) num2;
                                continue;
                              }
                              goto case 2;
                            case 9:
                              switch (0)
                              {
                                case 0:
                                  break;
                                default:
                                  continue;
                              }
                              break;
                            case 10:
                              num2 = (short) 1;
                              num10 = (int) (IntPtr) num2;
                              continue;
                            case 11:
                              num2 = (short) 8;
                              num10 = (int) (IntPtr) num2;
                              continue;
                          }
                          num2 = (short) 3;
                          num10 = (int) (IntPtr) num2;
                        }
                      }
                      finally
                      {
                        enumerator3.Dispose();
                      }
                    case 4:
                      switch (0)
                      {
                        case 0:
                          break;
                        default:
                          continue;
                      }
                      break;
                  }
label_104:
                  num9 = 0;
                }
              }
              finally
              {
                int num14 = 2;
                while (true)
                {
                  short num15;
                  switch (num14)
                  {
                    case 0:
                      enumerator1.Dispose();
                      num15 = (short) 1;
                      num14 = (int) (IntPtr) num15;
                      continue;
                    case 1:
                      goto label_114;
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
                  if (enumerator1 != null)
                  {
                    num15 = (short) 0;
                    num14 = (int) (IntPtr) num15;
                  }
                  else
                    break;
                }
label_114:;
              }
            case 23:
              Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide radioWide2 = ((Recordset) (FeatureManager.GetFeature(2045) as RadioWideRecset))[0] as Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide;
              A_0.BluetoothFriendlyName = this.a(A_0.BluetoothFriendlyName);
              radioWide2.Bluetooth.RadWideBluetoothFriendlyName_A41181.SetValue(A_0.BluetoothFriendlyName);
              num2 = (short) 7;
              num1 = (int) (IntPtr) num2;
              continue;
            case 25:
              num2 = (short) 48 /*0x30*/;
              num1 = (int) (IntPtr) num2;
              continue;
            case 26:
              ((AcpField<long>) dataWide.General.DataWideGeneralBTDUNSUIPAddress_A41120).SetValue(dataProfIp.BTSubIP.Address);
              num2 = (short) 33;
              num1 = (int) (IntPtr) num2;
              continue;
            case 27:
              ((AcpField<long>) dataWide.General.DataWideGeneralBTDUNPeerIPAddress_A41123).SetValue(dataProfIp.BTPeerIP.Address);
              num2 = (short) 24;
              num1 = (int) (IntPtr) num2;
              continue;
            case 28:
              Motorola.MackinawCPS.CoreFeatures.SecureWide.SecureWide secureWide = ((Recordset) feature1)[0] as Motorola.MackinawCPS.CoreFeatures.SecureWide.SecureWide;
              flag1 = UndoManager.StopUndoRedo();
              ((AcpField<int>) secureWide.ASTROOTAR.SecWideASTROOTARIndividualASTROOTARRadioID_A8284).Value = num3;
              num2 = (short) 49;
              num1 = (int) (IntPtr) num2;
              continue;
            case 29:
              if (strB == RptMgrErrorHandler.b("슅\uE987ﺉ\uED8B\uD98D憐\uF691\uF193", A_1_1))
              {
                num2 = (short) 17;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              enumerator1 = ((Collection<FeatureNode>) (FeatureManager.GetFeature(2054) as DataProfilesRecset)).GetEnumerator();
              num2 = (short) 40;
              num1 = (int) (IntPtr) num2;
              continue;
            case 30:
              goto label_194;
            case 31 /*0x1F*/:
              num2 = (short) 29;
              num1 = (int) (IntPtr) num2;
              continue;
            case 32 /*0x20*/:
              if (dataProfIp.BTSubIP != null)
              {
                num2 = (short) 1;
                if (num2 == (short) 0)
                  ;
                num2 = (short) 26;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto case 33;
            case 33:
              num2 = (short) 9;
              num1 = (int) (IntPtr) num2;
              continue;
            case 34:
              num2 = (short) 12;
              num1 = (int) (IntPtr) num2;
              continue;
            case 35:
              if (feature4 != null)
              {
                num2 = (short) 47;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_115;
            case 37:
              if (index >= dataProfIps.Length)
              {
                num2 = (short) 3;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              dataProfIp = dataProfIps[index];
              strB = dataProfIp.DataProfName;
              length = dataProfIp.DataProfName.IndexOf(char.MinValue);
              num2 = (short) 43;
              num1 = (int) (IntPtr) num2;
              continue;
            case 38:
              Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide radioWide3 = ((Recordset) (FeatureManager.GetFeature(2045) as RadioWideRecset))[0] as Motorola.MackinawCPS.CoreFeatures.RadioWide.RadioWide;
              ((AcpField<string>) radioWide3.UserInformationAndPasswords.RadWideUserInformationandPasswordsSoftIDUsername_A9169).SetValue(this.a(A_0.SoftIds[0]));
              PINPasswordUtil.UpdatePINPasswordFromRadio(A_0);
              radioWide3.UserInformationAndPasswords.RadWideUserInformationandUserLoginUnitID_41306.SetValue(this.a(A_0.SoftIds[3]));
              num2 = (short) 21;
              num1 = (int) (IntPtr) num2;
              continue;
            case 39:
              if (A_0.RadioAlias != null)
              {
                num2 = (short) 14;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto case 25;
            case 40:
              try
              {
                num2 = (short) 3;
                int num16 = (int) (IntPtr) num2;
                while (true)
                {
                  Motorola.MackinawCPS.CoreFeatures.DataProfiles.DataProfiles current;
                  switch (num16)
                  {
                    case 0:
                    case 2:
                      goto label_66;
                    case 1:
                      if (!current.General.DataProfGeneralAutoGenerateIPAddress_A19320.Value)
                      {
                        num2 = (short) 9;
                        num16 = (int) (IntPtr) num2;
                        continue;
                      }
                      break;
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
                      if (((FeatureNode) current).ReferenceKey.CompareTo(strB) == 0)
                      {
                        num2 = (short) 5;
                        num16 = (int) (IntPtr) num2;
                        continue;
                      }
                      break;
                    case 5:
                      num2 = (short) 1;
                      num16 = (int) (IntPtr) num2;
                      continue;
                    case 6:
                      num2 = (short) 10;
                      num16 = (int) (IntPtr) num2;
                      continue;
                    case 7:
                      num2 = (short) 2;
                      num16 = (int) (IntPtr) num2;
                      continue;
                    case 8:
                      ((AcpField<long>) current.General.DataProfilesGeneralBTDUNPeerIPAddress_A41127).SetValue(dataProfIp.BTPeerIP.Address);
                      num2 = (short) 0;
                      num16 = (int) (IntPtr) num2;
                      continue;
                    case 9:
                      ((AcpField<long>) current.General.DataProfGeneralSubscriberIPAddress_A21157).SetValue(dataProfIp.SubIP.Address);
                      ((AcpField<long>) current.General.DataProfGeneralMobileComputerIPAddress_A8523).SetValue(dataProfIp.PeerIP.Address);
                      ((AcpField<long>) current.General.DataProfGeneralSubscriberAirInterfaceIPAddress_A9220).SetValue(dataProfIp.SubAirInterfaceIP.Address);
                      num2 = (short) 11;
                      num16 = (int) (IntPtr) num2;
                      continue;
                    case 10:
                      if (dataProfIp.BTPeerIP != null)
                      {
                        num2 = (short) 8;
                        num16 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto case 7;
                    case 11:
                      if (dataProfIp.BTSubIP != null)
                      {
                        num2 = (short) 13;
                        num16 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto case 6;
                    case 12:
                      if (enumerator1.MoveNext())
                      {
                        current = (Motorola.MackinawCPS.CoreFeatures.DataProfiles.DataProfiles) enumerator1.Current;
                        num2 = (short) 4;
                        num16 = (int) (IntPtr) num2;
                        continue;
                      }
                      num2 = (short) 7;
                      num16 = (int) (IntPtr) num2;
                      continue;
                    case 13:
                      ((AcpField<long>) current.General.DataProfilesGeneralBTDUNSUIPAddress_A41126).SetValue(dataProfIp.BTSubIP.Address);
                      num2 = (short) 6;
                      num16 = (int) (IntPtr) num2;
                      continue;
                  }
                  num2 = (short) 12;
                  num16 = (int) (IntPtr) num2;
                }
              }
              finally
              {
                short num17 = 1;
                int num18 = (int) (IntPtr) num17;
                while (true)
                {
                  switch (num18)
                  {
                    case 0:
                      goto label_154;
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
                      num17 = (short) 0;
                      num18 = (int) (IntPtr) num17;
                      continue;
                  }
                  if (enumerator1 != null)
                  {
                    num17 = (short) 2;
                    num18 = (int) (IntPtr) num17;
                  }
                  else
                    break;
                }
label_154:;
              }
label_66:
              ++index;
              num2 = (short) 36;
              num1 = (int) (IntPtr) num2;
              continue;
            case 41:
              try
              {
                num2 = (short) 3;
                int num19 = (int) (IntPtr) num2;
                while (true)
                {
                  Motorola.MackinawCPS.CoreFeatures.TrunkingSystem.TrunkingSystem current5;
                  string referenceKey;
                  switch (num19)
                  {
                    case 0:
                      try
                      {
                        num2 = (short) 4;
                        int num20 = (int) (IntPtr) num2;
                        KeyValuePair<string, int[]> current6;
                        while (true)
                        {
                          string key;
                          switch (num20)
                          {
                            case 0:
                              goto label_163;
                            case 1:
                              num2 = (short) 0;
                              num20 = (int) (IntPtr) num2;
                              continue;
                            case 2:
                              goto label_172;
                            case 3:
                              if (!enumerator2.MoveNext())
                              {
                                num2 = (short) 1;
                                num20 = (int) (IntPtr) num2;
                                continue;
                              }
                              current6 = enumerator2.Current;
                              key = current6.Key;
                              num2 = (short) 5;
                              num20 = (int) (IntPtr) num2;
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
                              if (referenceKey.Equals(key.TrimEnd(new char[1])))
                              {
                                num2 = (short) 2;
                                num20 = (int) (IntPtr) num2;
                                continue;
                              }
                              break;
                          }
                          num2 = (short) 3;
                          num20 = (int) (IntPtr) num2;
                        }
label_172:
                        try
                        {
                          bool flag2;
                          switch (0)
                          {
                            case 0:
label_174:
                              ((AcpFieldBase) current5.General.TrkSysGeneralUnitID_A12651).DisableASKRangeValidation = true;
                              flag2 = UndoManager.StopUndoRedo();
                              ((AcpField<int>) current5.General.TrkSysGeneralUnitID_A12651).Value = current6.Value[1];
                              num2 = (short) 2;
                              num20 = (int) (IntPtr) num2;
                              goto default;
                            default:
                              while (true)
                              {
                                switch (num20)
                                {
                                  case 0:
                                    UndoManager.StartUndoRedo();
                                    num2 = (short) 3;
                                    num20 = (int) (IntPtr) num2;
                                    continue;
                                  case 1:
                                    goto label_163;
                                  case 2:
                                    if (flag2)
                                    {
                                      num2 = (short) 0;
                                      num20 = (int) (IntPtr) num2;
                                      continue;
                                    }
                                    goto case 3;
                                  case 3:
                                    num2 = (short) 1;
                                    num20 = (int) (IntPtr) num2;
                                    continue;
                                  default:
                                    goto label_174;
                                }
                              }
                          }
                        }
                        catch
                        {
                          break;
                        }
                        finally
                        {
                          ((AcpFieldBase) current5.General.TrkSysGeneralUnitID_A12651).DisableASKRangeValidation = false;
                        }
                      }
                      finally
                      {
                        enumerator2.Dispose();
                      }
                    case 1:
                      goto label_13;
                    case 2:
                      num2 = (short) 1;
                      num19 = (int) (IntPtr) num2;
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
                      if (enumerator1.MoveNext())
                      {
                        current5 = (Motorola.MackinawCPS.CoreFeatures.TrunkingSystem.TrunkingSystem) enumerator1.Current;
                        referenceKey = ((FeatureNode) current5).ReferenceKey;
                        enumerator2 = A_0.TrkSysIds.GetEnumerator();
                        num2 = (short) 0;
                        num19 = (int) (IntPtr) num2;
                        continue;
                      }
                      num2 = (short) 2;
                      num19 = (int) (IntPtr) num2;
                      continue;
                  }
label_163:
                  num19 = 4;
                }
              }
              finally
              {
                short num21 = 1;
                int num22 = (int) (IntPtr) num21;
                while (true)
                {
                  switch (num22)
                  {
                    case 0:
                      goto label_193;
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
                      num21 = (short) 0;
                      num22 = (int) (IntPtr) num21;
                      continue;
                  }
                  if (enumerator1 != null)
                  {
                    num21 = (short) 2;
                    num22 = (int) (IntPtr) num21;
                  }
                  else
                    break;
                }
label_193:;
              }
            case 42:
              num3 = -1;
              feature4 = FeatureManager.GetFeature(2055) as SecureKMFProfileRecset;
              num2 = (short) 35;
              num1 = (int) (IntPtr) num2;
              continue;
            case 43:
              if (length > 0)
              {
                num2 = (short) 4;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto case 31 /*0x1F*/;
            case 44:
              feature2 = FeatureManager.GetFeature(2064) as TrunkingSystemRecset;
              num2 = (short) 18;
              num1 = (int) (IntPtr) num2;
              continue;
            case 45:
              if (A_0.CnvSysIds != null)
              {
                num2 = (short) 15;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_21;
            case 46:
              if (feature3 != null)
              {
                num2 = (short) 16 /*0x10*/;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_21;
            case 47:
              enumerator1 = ((Collection<FeatureNode>) feature4).GetEnumerator();
              num2 = (short) 22;
              num1 = (int) (IntPtr) num2;
              continue;
            case 48 /*0x30*/:
              if (A_0.BluetoothFriendlyName != null)
              {
                num2 = (short) 23;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto case 7;
            case 49:
              if (flag1)
              {
                num2 = (short) 5;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto case 1;
            default:
label_4:
              num2 = (short) 0;
              if (A_0.TrkSysIds != null & A_1)
              {
                num2 = (short) 44;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              break;
          }
label_13:
          num2 = (short) 45;
          num1 = (int) (IntPtr) num2;
          continue;
label_21:
          num2 = (short) 0;
          num1 = (int) (IntPtr) num2;
          continue;
label_115:
          feature1 = FeatureManager.GetFeature(2021) as SecureWideRecset;
          num2 = (short) 11;
          num1 = (int) (IntPtr) num2;
        }
label_194:
        try
        {
          num2 = (short) 4;
          int num23 = (int) (IntPtr) num2;
          while (true)
          {
            switch (num23)
            {
              case 0:
                goto label_212;
              case 1:
                num2 = (short) 0;
                num23 = (int) (IntPtr) num2;
                continue;
              case 2:
                this.SerNum = A_0.SerialNumber;
                num2 = (short) 1;
                num23 = (int) (IntPtr) num2;
                continue;
              case 3:
                num2 = (short) 5;
                num23 = (int) (IntPtr) num2;
                continue;
              case 4:
                switch (0)
                {
                  case 0:
                    goto label_197;
                  default:
                    continue;
                }
              case 5:
                if (A_0.SerialNumber.Trim().Length > 0)
                {
                  num2 = (short) 2;
                  num23 = (int) (IntPtr) num2;
                  continue;
                }
                goto case 1;
              default:
label_197:
                if (A_0.SerialNumber != null)
                {
                  num2 = (short) 3;
                  num23 = (int) (IntPtr) num2;
                  continue;
                }
                goto case 1;
            }
          }
label_212:
          break;
        }
        catch
        {
          break;
        }
    }
  }

  private string a(string A_0)
  {
    short num1 = 1;
    if (num1 == (short) 0)
      ;
    num1 = (short) 2;
    int num2 = (int) (IntPtr) num1;
    while (true)
    {
      int length;
      switch (num2)
      {
        case 0:
          num1 = (short) 0;
          if (length != 0)
          {
            num1 = (short) 7;
            num2 = (int) (IntPtr) num1;
            continue;
          }
          num1 = (short) 5;
          num2 = (int) (IntPtr) num1;
          continue;
        case 1:
          num1 = (short) -7469;
          int num3 = (int) num1;
          num1 = (short) -7469;
          int num4 = (int) num1;
          switch (num3 == num4 ? 1 : 0)
          {
            case 0:
            case 2:
              num1 = (short) 0;
              num2 = (int) (IntPtr) num1;
              continue;
            default:
              num1 = (short) 0;
              if (num1 == (short) 0)
                ;
              length = A_0.IndexOf(char.MinValue);
              goto case 0;
          }
        case 2:
          switch (0)
          {
            case 0:
              break;
            default:
              continue;
          }
          break;
        case 3:
          A_0 = A_0.Substring(0, length);
          num1 = (short) 4;
          num2 = (int) (IntPtr) num1;
          continue;
        case 4:
        case 6:
          goto label_17;
        case 5:
          A_0 = "";
          num1 = (short) 6;
          num2 = (int) (IntPtr) num1;
          continue;
        case 7:
          if (length > 0)
          {
            num1 = (short) 3;
            num2 = (int) (IntPtr) num1;
            continue;
          }
          goto label_17;
      }
      if (A_0 != null)
      {
        num1 = (short) 1;
        num2 = (int) (IntPtr) num1;
      }
      else
        break;
    }
label_17:
    return A_0;
  }

  internal void CallMainUiProcess(double n, string stat)
  {
    short num1 = 0;
    num1 = (short) 19346;
    int num2 = (int) num1;
    num1 = (short) 19346;
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
        ((DispatcherObject) this).Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Delegate) new PageCloneWizard.UpdateProgress(this.CloneRadio_updateStatus), (object) n, (object) stat);
        break;
      default:
        goto case 1;
    }
  }

  internal void CloneRadio_updateStatus(double n, string stat)
  {
    int A_1 = 2;
    int num1;
    short num2;
    switch (0)
    {
      case 0:
label_2:
        this.progressBar2.Value = n * 100.0;
        num2 = (short) 12;
        num1 = (int) (IntPtr) num2;
        goto default;
      default:
        while (true)
        {
          switch (num1)
          {
            case 0:
              if (!(stat == AppResources.Writing_radio_codeplug_completed))
              {
                num2 = (short) 38;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              num2 = (short) 21;
              num1 = (int) (IntPtr) num2;
              continue;
            case 1:
              goto label_5;
            case 2:
              goto label_37;
            case 3:
              if (!(stat == AppResources.WaitForRadioEject_Id))
              {
                num2 = (short) 41;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              num2 = (short) 36;
              num1 = (int) (IntPtr) num2;
              continue;
            case 4:
              if (!(stat == AppResources.Read_Radio_Verification_Start))
              {
                num2 = (short) 8;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              num2 = (short) 37;
              num1 = (int) (IntPtr) num2;
              continue;
            case 5:
              goto label_9;
            case 6:
              goto label_61;
            case 7:
              if (stat == AppResources.LP_Cannot_Determine_Host_Version)
              {
                num2 = (short) 19;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              num2 = (short) 11;
              num1 = (int) (IntPtr) num2;
              continue;
            case 8:
              if (stat == AppResources.Read_Radio_Verification_Complete)
              {
                num2 = (short) 26;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              break;
            case 9:
              if (!(stat == AppResources.Reading_radio_codeplug_))
              {
                num2 = (short) 10;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              num2 = (short) 13;
              num1 = (int) (IntPtr) num2;
              continue;
            case 10:
              if (stat == AppResources.ReadRadio_Reading_codeplug_from_radio)
              {
                num2 = (short) 1;
                if (num2 == (short) 0)
                  ;
                num2 = (short) 22;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              num2 = (short) 4;
              num1 = (int) (IntPtr) num2;
              continue;
            case 11:
              if (stat == AppResources.LP_Radio_display_Language_Not_Supported_By_this_radio)
              {
                num2 = (short) 31 /*0x1F*/;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_93;
            case 12:
              if (stat == AppResources.Opening_Port)
              {
                num2 = (short) 33;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              num2 = (short) 15;
              num1 = (int) (IntPtr) num2;
              continue;
            case 13:
              goto label_38;
            case 14:
              goto label_53;
            case 15:
              if (stat == AppResources.Open_Port_Complete)
              {
                num2 = (short) 32 /*0x20*/;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              num2 = (short) 30;
              num1 = (int) (IntPtr) num2;
              continue;
            case 16 /*0x10*/:
              if (stat == AppResources.Reading_radio_codeplug_completed)
              {
                num2 = (short) 0;
                num2 = (short) 42;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              num2 = (short) 9;
              num1 = (int) (IntPtr) num2;
              continue;
            case 17:
              goto label_68;
            case 18:
              if (this.v)
              {
                num2 = (short) 6;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              num2 = (short) 35;
              num1 = (int) (IntPtr) num2;
              continue;
            case 19:
              goto label_75;
            case 20:
              if (!(stat == AppResources.WriteRadio_Writing_codeplug_to_radio))
              {
                num2 = (short) 0;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              num2 = (short) 29;
              num1 = (int) (IntPtr) num2;
              continue;
            case 21:
              num2 = (short) 18;
              num1 = (int) (IntPtr) num2;
              continue;
            case 22:
              goto label_54;
            case 23:
              if (stat == AppResources.Writing_radio_codeplug)
              {
                num2 = (short) 17;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              num2 = (short) 20;
              num1 = (int) (IntPtr) num2;
              continue;
            case 24:
              if (stat == AppResources.Read_Radio_Info_Complete)
              {
                num2 = (short) 2;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              num2 = (short) 28;
              num1 = (int) (IntPtr) num2;
              continue;
            case 25:
              if (!(stat == AppResources.Password_validation_failed))
              {
                num2 = (short) 7;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              num2 = (short) 43;
              num1 = (int) (IntPtr) num2;
              continue;
            case 26:
              goto label_42;
            case 27:
              goto label_87;
            case 28:
              if (stat == AppResources.ReadRadio_Calling_End_Read_Radio)
              {
                num2 = (short) 5;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              num2 = (short) 16 /*0x10*/;
              num1 = (int) (IntPtr) num2;
              continue;
            case 29:
              num2 = (short) 17686;
              int num3 = (int) num2;
              num2 = (short) 17686;
              int num4 = (int) num2;
              switch (num3 == num4 ? 1 : 0)
              {
                case 0:
                case 2:
                  break;
                default:
                  goto label_66;
              }
              break;
            case 30:
              if (!(stat == AppResources.Read_Radio_Info))
              {
                num2 = (short) 24;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              num2 = (short) 39;
              num1 = (int) (IntPtr) num2;
              continue;
            case 31 /*0x1F*/:
              goto label_29;
            case 32 /*0x20*/:
              goto label_79;
            case 33:
              goto label_33;
            case 34:
              if (stat == AppResources.Radio_Erase_in_Progress_please_wait)
              {
                num2 = (short) 27;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              num2 = (short) 25;
              num1 = (int) (IntPtr) num2;
              continue;
            case 35:
              if (!string.IsNullOrEmpty(LanguagePackHelper.warningOTAPMessage))
              {
                num2 = (short) 40;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_89;
            case 36:
              goto label_40;
            case 37:
              goto label_41;
            case 38:
              if (stat == AppResources.WriteRadio_eject_radio)
              {
                num2 = (short) 1;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              num2 = (short) 3;
              num1 = (int) (IntPtr) num2;
              continue;
            case 39:
              goto label_86;
            case 40:
              goto label_88;
            case 41:
              if (!(stat == AppResources.WriteRadio_Close_Port))
              {
                num2 = (short) 34;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              num2 = (short) 14;
              num1 = (int) (IntPtr) num2;
              continue;
            case 42:
              goto label_25;
            case 43:
              goto label_39;
            default:
              goto label_2;
          }
          num2 = (short) 23;
          num1 = (int) (IntPtr) num2;
        }
label_5:
        ((ContentControl) this.ProgText).Content = (object) AppResources.Write_radio_releasing_radio;
        break;
label_9:
        ((ContentControl) this.ProgText).Content = (object) AppResources.Read_radio_codeplug_complete;
        break;
label_25:
        ((ContentControl) this.ProgText).Content = (object) AppResources.Read_Radio_Info_;
        break;
label_29:
        this.v = true;
        break;
label_33:
        ((ContentControl) this.ProgText).Content = (object) AppResources.Opening_Connection_To_Radio;
        break;
label_37:
        ((ContentControl) this.ProgText).Content = (object) AppResources.Read_radio_info_complete_;
        break;
label_38:
        ((ContentControl) this.ProgText).Content = (object) AppResources.Read_Radio_Info_;
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
label_53:
        ((ContentControl) this.ProgText).Content = (object) AppResources.Write_radio_release_complete;
        break;
label_54:
        ((ContentControl) this.ProgText).Content = (object) AppResources.Begin_read_codeplug;
        break;
label_61:
        ((ContentControl) this.ProgText).Content = (object) AppResources.Write_radio_complete_LP_Radio_display_Lng_Not_Supported_By_this_radio;
        break;
label_66:
        num2 = (short) 0;
        if (num2 == (short) 0)
          ;
        ((ContentControl) this.ProgText).Content = (object) AppResources.Begin_write_to_radio;
        break;
label_68:
        ((ContentControl) this.ProgText).Content = (object) AppResources.Write_to_radio_in_progress;
        break;
label_75:
        ((ContentControl) this.ProgText).Content = (object) AppResources.LP_Cannot_Determine_Host_Version;
        break;
label_79:
        ((ContentControl) this.ProgText).Content = (object) AppResources.Connecting_opened_to_radio;
        break;
label_86:
        ((ContentControl) this.ProgText).Content = (object) AppResources.Read_radio_info_start_;
        break;
label_87:
        ((ContentControl) this.ProgText).Content = (object) AppResources.Radio_Erasing_please_wait;
        break;
label_88:
        ((ContentControl) this.ProgText).Content = (object) (AppResources.Write_Complete + RptMgrErrorHandler.b("ꖄ", A_1) + LanguagePackHelper.warningOTAPMessage);
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
    num1 = (short) 1;
    if (num1 == (short) 0)
      ;
    num1 = (short) 31908;
    int num2 = (int) num1;
    num1 = (short) 31908;
    int num3 = (int) num1;
    switch (num2 == num3)
    {
      case true:
        num1 = (short) 0;
        if (num1 == (short) 0)
          ;
        ((DispatcherObject) this).Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Delegate) new PageCloneWizard.MainFinish(this.CloneFinished), (object) status);
        break;
      default:
        goto case 1;
    }
  }

  internal void CloneFinished(bool status)
  {
    int A_1 = 19;
    int num1;
    short num2;
    switch (0)
    {
      case 0:
label_2:
        this.t = false;
        ((FrameworkElement) this).Cursor = this.s;
        this.v = false;
        LanguagePackHelper.warningOTAPMessage = string.Empty;
        num2 = (short) 1;
        num1 = (int) (IntPtr) num2;
        goto default;
      default:
        while (true)
        {
          bool? isChecked;
          StatusMessagesManager statusMsgReport;
          switch (num1)
          {
            case 0:
              if (status)
              {
                num2 = (short) 10;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_23;
            case 1:
              num2 = (short) 27185;
              int num3 = (int) num2;
              num2 = (short) 27185;
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
                  if (!status)
                  {
                    num2 = (short) 5;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_10;
              }
              break;
            case 2:
              statusMsgReport.ContainsField(RptMgrErrorHandler.b("쒕聯ﺙ\uF59B\uF19D肟\uF1A1솣풥솧쮩삫躭ﺯ잱\uD9B3풵\uDDB7좹鲻쮽낿ꛁꗃ닅귇\uEAC9\uAACB꿍맏뻑뇓닕", A_1));
              num2 = (short) 3;
              num1 = (int) (IntPtr) num2;
              continue;
            case 3:
label_10:
              this.CloneRadiobutton.IsEnabled = true;
              this.ReadRadioIDsbutton.IsEnabled = true;
              ((UIElement) this.FileCloneEnBox).IsEnabled = true;
              Win32APIs.EnableCloseMenuItem(this.r, true);
              this.c = false;
              this.b.Stop();
              isChecked = ((ToggleButton) this.FileCloneEnBox).IsChecked;
              break;
            case 4:
              num2 = (short) 0;
              num1 = (int) (IntPtr) num2;
              continue;
            case 5:
              statusMsgReport = AppInfoManager.StatusMsgReport;
              num2 = (short) 8;
              num1 = (int) (IntPtr) num2;
              continue;
            case 6:
              goto label_18;
            case 7:
              if (isChecked.Value)
              {
                num2 = (short) 9;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto case 4;
            case 8:
              if (!statusMsgReport.ContainsField(RptMgrErrorHandler.b("쒕聯ﺙ\uF59B\uF19D肟\uF1A1솣풥솧쮩삫躭ﺯ잱\uD9B3풵\uDDB7좹鲻쮽낿ꛁꗃ닅귇껉", A_1)))
              {
                num2 = (short) 2;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto case 3;
            case 9:
              this.h = false;
              this.q.FileCloneForceClose();
              num2 = (short) 4;
              num1 = (int) (IntPtr) num2;
              continue;
            case 10:
              this.w = Encoding.ASCII.GetString(Convert.FromBase64String(this.q.GetRadioParams().SerialNumber));
              DVRSXmlUtil.ExportDVRSAfterClone(this.w);
              num2 = (short) 6;
              num1 = (int) (IntPtr) num2;
              continue;
            default:
              goto label_2;
          }
          num2 = (short) 7;
          num1 = (int) (IntPtr) num2;
        }
label_18:
        num2 = (short) 0;
label_23:
        num2 = (short) 1;
        if (num2 == (short) 0)
          break;
        break;
    }
  }

  internal void CloneW_DisplayOTAP(
    ProgrammingOperation ProgOp,
    OTAPProgrammingParameters LastCommsOTAPUserState,
    SpecialFeatures.Comms.Comms.RadioOTAPObject RadioObject)
  {
    short num1 = 0;
    num1 = (short) 17961;
    int num2 = (int) num1;
    num1 = (short) 17961;
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
        ((DispatcherObject) this).Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Delegate) new PageCloneWizard.MainUIDisplayOTAP(this.DisplayOTAP), (object) ProgOp, (object) LastCommsOTAPUserState, (object) RadioObject);
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
    int A_1 = 5;
    int num1 = 1;
    while (true)
    {
      short num2;
      switch (num1)
      {
        case 0:
          num2 = (short) 23671;
          int num3 = (int) num2;
          num2 = (short) 23671;
          int num4 = (int) num2;
          switch (num3 == num4 ? 1 : 0)
          {
            case 0:
              goto label_4;
            case 2:
              goto label_12;
            default:
              num2 = (short) 0;
              if (num2 == (short) 0)
                ;
              num2 = (short) 1;
              if (num2 == (short) 0)
                ;
              OTAPProgrammingWindow programmingWindow = new OTAPProgrammingWindow(ProgOp, LastCommsOTAPUserState);
              Window mainWindow = Application.Current.MainWindow;
              programmingWindow.Owner = mainWindow;
              bool? otapDialogResult = programmingWindow.ShowDialog();
              RadioObject(otapDialogResult, programmingWindow.OTAPProgrammingLastState, programmingWindow.PrescenceResult);
              Semaphore.OpenExisting(RptMgrErrorHandler.b("잇\uDE89춋\uDE8D풏ﮑ\uE793\uE695\uF497ﮙ\uE59B증솟쮡킣", A_1)).Release(1);
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
          goto label_8;
      }
      if (!(bool) Application.Current.Properties[(object) RptMgrErrorHandler.b("쮇\uE589\uE18B\uE38D\uF18Fﲑ\uF093\uDA95\uF197\uF499鍊\uDD9D\uF09F\uF1A1", A_1)])
      {
        num2 = (short) 0;
        num2 = (short) 0;
        num1 = (int) (IntPtr) num2;
      }
      else
        goto label_11;
    }
label_8:
    return;
label_11:
    return;
label_4:
    return;
label_12:;
  }

  internal void CloneW_DisplayRadioQuery(SpecialFeatures.Comms.Comms.RadioRtn RadioRtn)
  {
    short num1 = 0;
    num1 = (short) 9726;
    int num2 = (int) num1;
    num1 = (short) 9726;
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
        ((DispatcherObject) this).Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Delegate) new PageCloneWizard.WriteRadioQuery(this.DisplayRadioQuery), (object) RadioRtn);
        break;
      default:
        goto case 1;
    }
  }

  internal void DisplayRadioQuery(SpecialFeatures.Comms.Comms.RadioRtn RadioRtn)
  {
    int A_1 = 15;
    int num1 = 1;
    while (true)
    {
      short num2;
      switch (num1)
      {
        case 0:
          num2 = (short) 27517;
          int num3 = (int) num2;
          num2 = (short) 27517;
          int num4 = (int) num2;
          switch (num3 == num4 ? 1 : 0)
          {
            case 0:
              goto label_4;
            case 2:
              goto label_12;
            default:
              num2 = (short) 1;
              if (num2 == (short) 0)
                ;
              num2 = (short) 0;
              if (num2 == (short) 0)
                ;
              MessageBoxResult RadioRtn1 = MessageBox.Show(AppResources.Warning_You_are_about_to_write_protect_the_attached_radio_Press_OK_write_Cancel_to_abort, AppResources.Radio_Write_Protect_Warning, MessageBoxButton.OKCancel, MessageBoxImage.Exclamation);
              RadioRtn(RadioRtn1);
              Semaphore.OpenExisting(RptMgrErrorHandler.b("삑\uF593\uF295\uF197\uF599쮛\uEC9D즟횡솣\uF4A5춧\uDEA9", A_1)).Release(1);
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
          goto label_9;
      }
      if (!(bool) Application.Current.Properties[(object) RptMgrErrorHandler.b("톑ﮓﮕ\uF597ﮙ\uF29B瞧\uEC9F쮡쪣쎥\uEBA7睊ﾫ", A_1)])
      {
        num2 = (short) 0;
        num2 = (short) 0;
        num1 = (int) (IntPtr) num2;
      }
      else
        goto label_11;
    }
label_9:
    return;
label_11:
    return;
label_4:
    return;
label_12:;
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
          Win32APIs.EnableCloseMenuItem(this.r, true);
          this.b.Stop();
          num2 = (short) 2;
          num1 = (int) (IntPtr) num2;
          continue;
        case 2:
          goto label_7;
        case 3:
          num2 = (short) 4;
          num1 = (int) (IntPtr) num2;
          continue;
        case 4:
          num2 = (short) 1;
          if (num2 == (short) 0)
            ;
          if (this.c)
          {
            num2 = (short) 1;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto label_9;
      }
      if (this.b != null)
      {
        num2 = (short) -21582;
        int num3 = (int) num2;
        num2 = (short) -21582;
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
            num2 = (short) 0;
            num2 = (short) 3;
            num1 = (int) (IntPtr) num2;
            continue;
        }
      }
      else
        goto label_14;
    }
label_7:
    return;
label_14:
    return;
label_9:;
  }

  private bool b(out string A_0)
  {
    int A_1 = 3;
    int num1 = 0;
    switch (num1)
    {
      default:
        short num2 = 0;
        Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation radioInformation = (Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation) null;
        bool flag1 = false;
        string str = string.Empty;
        A_0 = AppResources.FileClone_failed_or_cancelled;
        try
        {
          switch (0)
          {
            case 0:
label_4:
              Utility.SaveFieldWithFocus();
              num2 = (short) 4;
              num1 = (int) (IntPtr) num2;
              goto default;
            default:
              while (true)
              {
                switch (num1)
                {
                  case 0:
                    num2 = (short) 7;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  case 1:
                    num2 = (short) 3;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  case 2:
                  case 8:
                    num2 = (short) 6;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  case 3:
                    int num3 = UndoManager.StopUndoRedo() ? 1 : 0;
                    AcpSaveFileDialog acpSaveFileDialog = new AcpSaveFileDialog();
                    if (VersionInfoHelper.IsDFlagExisted((DFlagType) 1))
                      ((AcpFileDialog) acpSaveFileDialog).Filter = AppResources.Vertex_Codeplug_Filter;
                    else
                      ((AcpFileDialog) acpSaveFileDialog).Filter = AppResources.Motorola_Codeplug_Filter;
                    ((AcpFileDialog) acpSaveFileDialog).FileName = ((TextBox) this.SerialNumberBox).Text;
                    AcpFileHeader acpFileHeader = this.b();
                    bool? nullable = ((AcpFileDialog) acpSaveFileDialog).ShowDialog(acpFileHeader, (Window) ((FrameworkElement) this).Parent);
                    bool flag2 = true;
                    if (nullable.GetValueOrDefault() == flag2 & nullable.HasValue)
                    {
                      string fileName = ((AcpFileDialog) acpSaveFileDialog).FileName;
                      if (fileName != null)
                      {
                        radioInformation = FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation;
                        str = radioInformation.General.RadInfoGeneralCodeplugVersion_A7683_UIValue;
                        if (fileName.EndsWith(RptMgrErrorHandler.b("ꢅ\uE587\uE989", A_1)))
                        {
                          radioInformation.General.RadInfoGeneralCodeplugVersion_A7683.SetValue(AppInfoManager.AppVersion);
                          radioInformation.Labtool.RadInfoLabtoolSecurePartitionVersionNumber_A9076.SetValue(AppInfoManager.AppVersion);
                          acpFileHeader.VersionNumber = AppInfoManager.AppVersion;
                          flag1 = ((AcpDocument) FeatureManager.ActiveDocument).FileSaveAs(fileName, acpFileHeader);
                        }
                        if (flag1)
                        {
                          UndoManager.Reset();
                          A_0 = AppResources.FileClone_Successful;
                        }
                      }
                    }
                    if (num3 != 0)
                    {
                      num2 = (short) 5;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    }
                    goto case 2;
                  case 4:
                    num2 = (short) 1;
                    if (num2 == (short) 0)
                      ;
                    if (this.c())
                    {
                      num2 = (short) 0;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    }
                    A_0 = AppResources.Unable_to_save_Codeplug_Permission_denied;
                    num2 = (short) 2;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  case 5:
                    num2 = (short) -22101;
                    int num4 = (int) num2;
                    num2 = (short) -22101;
                    int num5 = (int) num2;
                    switch (num4 == num5 ? 1 : 0)
                    {
                      case 0:
                      case 2:
                        goto label_4;
                      default:
                        num2 = (short) 0;
                        if (num2 == (short) 0)
                          ;
                        UndoManager.StartUndoRedo();
                        num2 = (short) 8;
                        num1 = (int) (IntPtr) num2;
                        continue;
                    }
                  case 6:
                    goto label_31;
                  case 7:
                    if (this.a(ref A_0))
                    {
                      num2 = (short) 1;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    }
                    goto case 2;
                  default:
                    goto label_4;
                }
              }
          }
        }
        catch (Exception ex)
        {
          if (str != "")
            radioInformation.General.RadInfoGeneralCodeplugVersion_A7683.SetValue(str);
          A_0 = ex.Message;
          UndoManager.StartUndoRedo();
        }
label_31:
        return flag1;
    }
  }

  private bool c()
  {
    int num1;
    bool flag;
    short num2;
    switch (0)
    {
      case 0:
label_2:
        flag = true;
        num2 = (short) 1;
        num1 = (int) (IntPtr) num2;
        goto default;
      default:
        while (true)
        {
          switch (num1)
          {
            case 0:
              flag = true;
              num2 = (short) 0;
              num2 = (short) 1;
              if (num2 == (short) 0)
                ;
              num2 = (short) 3;
              num1 = (int) (IntPtr) num2;
              continue;
            case 1:
              if (SecurityManager.IsSpecialKeyLoaded)
              {
                num2 = (short) 4;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_13;
            case 2:
            case 3:
              goto label_13;
            case 4:
              num2 = (short) 5;
              num1 = (int) (IntPtr) num2;
              continue;
            case 5:
              if (!SecurityManager.CheckIfSpecialKeyIsAttached())
              {
                num2 = (short) -29863;
                int num3 = (int) num2;
                num2 = (short) -29863;
                int num4 = (int) num2;
                switch (num3 == num4 ? 1 : 0)
                {
                  case 0:
                  case 2:
                    goto label_13;
                  default:
                    num2 = (short) 0;
                    if (num2 == (short) 0)
                      ;
                    flag = false;
                    num2 = (short) 2;
                    num1 = (int) (IntPtr) num2;
                    continue;
                }
              }
              else
              {
                num2 = (short) 0;
                num1 = (int) (IntPtr) num2;
                continue;
              }
            default:
              goto label_2;
          }
        }
label_13:
        return flag;
    }
  }

  private AcpFileHeader b()
  {
label_0:
    short num1;
    int num2;
    AcpFileHeader acpFileHeader;
    RadioInformationRecset feature;
    switch (0)
    {
      case 0:
label_3:
        acpFileHeader = new AcpFileHeader();
        feature = FeatureManager.GetFeature(2049) as RadioInformationRecset;
        num1 = (short) 1;
        num2 = (int) (IntPtr) num1;
        goto default;
      default:
        while (true)
        {
          num1 = (short) 1;
          if (num1 == (short) 0)
            ;
          switch (num2)
          {
            case 0:
              Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation radioInformation = ((Recordset) feature)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation;
              acpFileHeader.ModelNumber = radioInformation.General.RadInfoGeneralModelNumber_A8539.ToString();
              acpFileHeader.SerialNumber = radioInformation.General.RadInfoGeneralSerialNumber_A9122.ToString();
              acpFileHeader.FlashCode = radioInformation.FLASHport.RadInfoFLASHportFLASHcode_A8132.ToString();
              acpFileHeader.VersionNumber = radioInformation.General.RadInfoGeneralCodeplugVersion_A7683.ToString();
              num1 = (short) 2;
              num2 = (int) (IntPtr) num1;
              continue;
            case 1:
              num1 = (short) 0;
              if (feature != null)
              {
                num1 = (short) 0;
                num2 = (int) (IntPtr) num1;
                continue;
              }
              goto label_9;
            case 2:
              goto label_7;
            default:
              goto label_3;
          }
        }
label_7:
        num1 = (short) 29986;
        int num3 = (int) num1;
        num1 = (short) 29986;
        int num4 = (int) num1;
        switch (num3 == num4 ? 1 : 0)
        {
          case 0:
          case 2:
            goto label_0;
          default:
            num1 = (short) 0;
            if (num1 == (short) 0)
              break;
            break;
        }
label_9:
        return acpFileHeader;
    }
  }

  private bool a(ref string A_0)
  {
    int A_1 = 6;
    int num1;
    bool flag;
    string appVersion;
    short num2;
    switch (0)
    {
      case 0:
label_2:
        flag = true;
        appVersion = AppInfoManager.AppVersion;
        num2 = (short) 5;
        num1 = (int) (IntPtr) num2;
        goto default;
      default:
        while (true)
        {
          string versionA7683UiValue;
          switch (num1)
          {
            case 0:
              if (versionA7683UiValue.Length != 0)
              {
                num2 = (short) 1;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              break;
            case 1:
              num2 = (short) 7;
              num1 = (int) (IntPtr) num2;
              continue;
            case 2:
              versionA7683UiValue = (FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation).General.RadInfoGeneralCodeplugVersion_A7683_UIValue;
              num2 = (short) 0;
              num1 = (int) (IntPtr) num2;
              continue;
            case 3:
              num2 = (short) 32154;
              int num3 = (int) num2;
              num2 = (short) 32154;
              int num4 = (int) num2;
              switch (num3 == num4 ? 1 : 0)
              {
                case 0:
                case 2:
                  goto label_5;
                default:
                  num2 = (short) 1;
                  if (num2 == (short) 0)
                    ;
                  num2 = (short) 0;
                  if (num2 == (short) 0)
                    ;
                  flag = MessageBox.Show(AppResources.Warning_you_are_about_to_save_a_Release, AppResources.Saving_Codeplug_, MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes;
                  num2 = (short) 12;
                  num1 = (int) (IntPtr) num2;
                  continue;
              }
            case 4:
label_5:
              A_0 = AppResources.Unable_to_save_Codeplug_Invalid_or_empty_Codeplug_version;
              flag = false;
              num2 = (short) 9;
              num1 = (int) (IntPtr) num2;
              continue;
            case 5:
              if (appVersion.Length != 0)
              {
                num2 = (short) 10;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_16;
            case 6:
            case 9:
              goto label_27;
            case 7:
              if (versionA7683UiValue.Substring(0, 1) == RptMgrErrorHandler.b("\uDB88", A_1))
              {
                num2 = (short) 3;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              break;
            case 8:
              if (appVersion.Substring(0, 1) != RptMgrErrorHandler.b("\uDB88", A_1))
              {
                num2 = (short) 2;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_16;
            case 10:
              num2 = (short) 8;
              num1 = (int) (IntPtr) num2;
              continue;
            case 11:
              A_0 = AppResources.CPS_version_is_not_current;
              num2 = (short) 6;
              num1 = (int) (IntPtr) num2;
              continue;
            case 12:
              goto label_20;
            case 13:
              if (versionA7683UiValue.Length == 0)
              {
                num2 = (short) 4;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_27;
            case 14:
              if (appVersion.Length == 0)
              {
                num2 = (short) 11;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_27;
            default:
              goto label_2;
          }
          num2 = (short) 13;
          num1 = (int) (IntPtr) num2;
          continue;
label_16:
          num2 = (short) 14;
          num1 = (int) (IntPtr) num2;
        }
label_20:
        num2 = (short) 0;
label_27:
        return flag;
    }
  }

  public bool CommandLineCPSCloneProcedure()
  {
    int A_1 = 3;
    Trace.WriteLine(RptMgrErrorHandler.b("\uDD85\uD887\uEB89\uEB8B\uEB8D펏ﺑﮓ\uF895ﶗ춙\uF59B\uE49D솟킡삣ﮥ\uF3A7\uE3A9슫좭\uDFAF삱\uD9B3ힵ첷펹펻킽鶿駁蛃ꏅ꿇ꏉꋋ鏍诏金믓믕뗗믙닛뫝곟诡諣菥ꯧ뫩뿫귭鳯鷱髳鏵ꣷ裹鏻鷽旿昁焃琅洇圉", A_1));
    bool flag1 = false;
    short num1;
    bool flag2;
    try
    {
      int num2 = 2;
      while (true)
      {
        switch (num2)
        {
          case 0:
            goto label_1;
          case 1:
label_8:
            Trace.WriteLine(RptMgrErrorHandler.b("\uDD85\uD887\uEB89\uEB8B\uEB8D펏ﺑﮓ\uF895ﶗ춙\uF59B\uE49D솟킡삣ﮥ\uF3A7\uEFA9\uDEAB\uDCAD\uDFAF삱\uE9B3\uEDB5﮷햹톻펽ꆿ곁ꃃ諅ꇇ\uA4C9꧋跍胏臑韓뫕럗듙맛軝鋟跡蟣菥賧\u9FE9黫语귯죱퓳뗵韷黹駻軽泿省挃★怇欉缋⸍夏簑戓眕琗猙砛㸝䘟䬡䄣䨥䰧天+อ猯䀱䄳堵嬷刹夻䰽怿Łࡃॅهཉ汋⅍⁏㝑♓㝕ⱗ㍙㍛そ䁟͡٣॥ᩧṩ५੭", A_1));
            flag2 = flag1;
            num1 = (short) 3;
            num2 = (int) (IntPtr) num1;
            continue;
          case 2:
            switch (0)
            {
              case 0:
                goto label_6;
              default:
                continue;
            }
          case 3:
            goto label_15;
          default:
label_6:
            if (AppInfoManager.InvalidFieldsReport.HasFields)
            {
              num1 = (short) 1;
              num2 = (int) (IntPtr) num1;
              continue;
            }
            this.i();
            this.PrePackHandler();
            SpecialFeatures.Comms.Comms.updateStatus += new SpecialFeatures.Comms.Comms.DisplayUpdateStatus(this.CallMainUiProcess);
            flag1 = this.d();
            this.h();
            num1 = (short) 29885;
            int num3 = (int) num1;
            num1 = (short) 29885;
            int num4 = (int) num1;
            switch (num3 == num4 ? 1 : 0)
            {
              case 0:
              case 2:
                goto label_8;
              default:
                num1 = (short) 0;
                if (num1 == (short) 0)
                  ;
                num1 = (short) 0;
                num2 = (int) (IntPtr) num1;
                continue;
            }
        }
      }
    }
    catch (Exception ex)
    {
      if (ex.Message == AppResources.Codeplug_Exceeds_Size_Limit_On_Write)
        throw new CommonException(AppResources.Codeplug_Exceeds_Size_Limit_On_Write);
      Trace.WriteLine(RptMgrErrorHandler.b("\uDD85\uD887\uEB89\uEB8B\uEB8D펏ﺑﮓ\uF895ﶗ춙\uF59B\uE49D솟킡삣ﮥ\uF3A7\uEFA9풫춭햯슱삳\uDFB5ힷ풹\uE1BB\uE5BD莿귁꧃ꯅ꧇\uA4C9\uA8CB苍맏병뇓闕裗觙\u9FDB닝迟賡臣뛥髧藩迫语铯蟱蛳鏵ꗷ샹\uDCFB", A_1) + ex.Message);
      flag2 = false;
      goto label_15;
    }
label_1:
    num1 = (short) 1;
    if (num1 == (short) 0)
      ;
    Trace.WriteLine(RptMgrErrorHandler.b("\uDD85\uD887\uEB89\uEB8B\uEB8D펏ﺑﮓ\uF895ﶗ춙\uF59B\uE49D솟킡삣ﮥ\uF3A7\uE3A9슫좭\uDFAF삱\uD9B3ힵ첷펹펻킽鶿駁臃\uA8C5곇韉韋跍뿏뿑맓럕뛗뻙郛럝軟蟡\uA7E3뛥믧ꧩ胫臭黯韱ꓳ蓵韷駹駻髽痿瀁愃嬅", A_1));
    return flag1;
label_15:
    return flag2;
  }

  public string SerNum
  {
    get
    {
      short num = 9256;
      switch ((short) 9256 == num)
      {
        case true:
          num = (short) 0;
          if (num == (short) 0)
            ;
          num = (short) 1;
          if (num == (short) 0)
            ;
          return this.y;
        default:
          goto case 1;
      }
    }
    set
    {
      int A_1 = 1;
      int num1 = 1;
      while (true)
      {
        short num2;
        switch (num1)
        {
          case 0:
            num2 = (short) -11829;
            int num3 = (int) num2;
            num2 = (short) -11829;
            int num4 = (int) num2;
            switch (num3 == num4 ? 1 : 0)
            {
              case 0:
                goto label_4;
              case 2:
                goto label_12;
              default:
                num2 = (short) 1;
                if (num2 == (short) 0)
                  ;
                num2 = (short) 0;
                if (num2 == (short) 0)
                  ;
                this.y = value.ToUpper();
                this.FirePropertyChanged(RptMgrErrorHandler.b("힃\uE385慎쒉曆\uE38D", A_1));
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
            goto label_9;
        }
        if (this.y != value)
        {
          num2 = (short) 0;
          num2 = (short) 0;
          num1 = (int) (IntPtr) num2;
        }
        else
          goto label_11;
      }
label_9:
      return;
label_11:
      return;
label_4:
      return;
label_12:;
    }
  }

  public event PropertyChangedEventHandler PropertyChanged
  {
    add
    {
label_0:
      int num1;
      PropertyChangedEventHandler changedEventHandler;
      short num2;
      switch (0)
      {
        case 0:
label_2:
          changedEventHandler = this.z;
          num2 = (short) 1;
          num1 = (int) (IntPtr) num2;
          goto default;
        default:
          PropertyChangedEventHandler comparand;
          while (true)
          {
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
                num2 = (short) 0;
                num2 = (short) 1;
                if (num2 == (short) 0)
                  ;
                comparand = changedEventHandler;
                changedEventHandler = Interlocked.CompareExchange<PropertyChangedEventHandler>(ref this.z, comparand + value, comparand);
                num2 = (short) 0;
                num1 = (int) (IntPtr) num2;
                continue;
              case 2:
                goto label_8;
              default:
                goto label_2;
            }
          }
label_8:
          num2 = (short) -19614;
          int num3 = (int) num2;
          num2 = (short) -19614;
          int num4 = (int) num2;
          switch (num3 == num4 ? 1 : 0)
          {
            case 0:
            case 2:
              goto label_0;
            default:
              num2 = (short) 0;
              if (num2 == (short) 0)
                ;
              return;
          }
      }
    }
    remove
    {
label_0:
      int num1;
      PropertyChangedEventHandler changedEventHandler;
      short num2;
      switch (0)
      {
        case 0:
label_2:
          changedEventHandler = this.z;
          num2 = (short) 1;
          num1 = (int) (IntPtr) num2;
          goto default;
        default:
          PropertyChangedEventHandler comparand;
          while (true)
          {
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
                num2 = (short) 0;
                comparand = changedEventHandler;
                changedEventHandler = Interlocked.CompareExchange<PropertyChangedEventHandler>(ref this.z, comparand - value, comparand);
                num2 = (short) 0;
                num1 = (int) (IntPtr) num2;
                continue;
              case 2:
                goto label_7;
              default:
                goto label_2;
            }
          }
label_7:
          num2 = (short) 22679;
          int num3 = (int) num2;
          num2 = (short) 22679;
          int num4 = (int) num2;
          switch (num3 == num4 ? 1 : 0)
          {
            case 0:
            case 2:
              goto label_0;
            default:
              num2 = (short) 1;
              if (num2 == (short) 0)
                ;
              num2 = (short) 0;
              if (num2 == (short) 0)
                ;
              return;
          }
      }
    }
  }

  public void FirePropertyChanged(string name)
  {
    int num1 = 1;
    while (true)
    {
      short num2;
      switch (num1)
      {
        case 0:
          num2 = (short) 12468;
          int num3 = (int) num2;
          num2 = (short) 12468;
          int num4 = (int) num2;
          switch (num3 == num4 ? 1 : 0)
          {
            case 0:
              goto label_4;
            case 2:
              goto label_12;
            default:
              num2 = (short) 0;
              if (num2 == (short) 0)
                ;
              num2 = (short) 1;
              if (num2 == (short) 0)
                ;
              // ISSUE: reference to a compiler-generated field
              this.z((object) this, new PropertyChangedEventArgs(name));
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
          goto label_8;
      }
      // ISSUE: reference to a compiler-generated field
      if (this.z != null)
      {
        num2 = (short) 0;
        num2 = (short) 0;
        num1 = (int) (IntPtr) num2;
      }
      else
        goto label_11;
    }
label_8:
    return;
label_11:
    return;
label_4:
    return;
label_12:;
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "5.0.10.0")]
  public void InitializeComponent()
  {
    int A_1 = 3;
    if (!this.aa)
      goto label_3;
label_1:
    short num = 1;
    if (num == (short) 0)
      ;
    num = (short) 0;
    return;
label_3:
    num = (short) -25920;
    switch ((short) -25920 == num ? 1 : 0)
    {
      case 0:
      case 2:
        goto label_1;
      default:
        num = (short) 0;
        if (num == (short) 0)
          ;
        this.aa = true;
        Application.LoadComponent((object) this, new Uri(RptMgrErrorHandler.b("ꦅ\uDB87憎\uE98B\uED8D憐\uF391\uF893킕ﶗﮙ\uE89B\uEB9D튟잡힣鶥쮧얩솫\uDEAD\uDFAF\uDCB1톳\uD8B5첷閹\uDFBB튽꾿곁ꇃ\uE3C5難韛꿋ꇍ뻏듑뷓뇕귗꣙뷛ꫝ觟跡諣짥诧蛩菫胭闯ퟱ웳웵迷鏹蛻\u9FFD狿昁⬃瘅椇洉椋洍簏紑稓猕漗猙昛缝刟䘡ਣ帥䤧䜩䀫", A_1), UriKind.Relative));
        break;
    }
  }

  [EditorBrowsable(EditorBrowsableState.Never)]
  [GeneratedCode("PresentationBuildTasks", "5.0.10.0")]
  [DebuggerNonUserCode]
  void IComponentConnector.Connect(int connectionId, object target)
  {
    int num = 1;
    while (true)
    {
      switch (num)
      {
        case 0:
          num = 2;
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
          goto label_81;
      }
      switch (connectionId)
      {
        case 1:
          goto label_42;
        case 2:
          goto label_35;
        case 3:
          goto label_74;
        case 4:
          goto label_73;
        case 5:
          goto label_47;
        case 6:
          goto label_75;
        case 7:
          goto label_60;
        case 8:
          goto label_41;
        case 9:
          goto label_9;
        case 10:
          goto label_45;
        case 11:
          goto label_19;
        case 12:
          goto label_56;
        case 13:
          goto label_18;
        case 14:
          goto label_48;
        case 15:
          goto label_7;
        case 16 /*0x10*/:
          goto label_27;
        case 17:
          goto label_13;
        case 18:
          goto label_20;
        case 19:
          goto label_31;
        case 20:
          goto label_30;
        case 21:
          goto label_29;
        case 22:
          goto label_44;
        case 23:
          goto label_26;
        case 24:
          goto label_76;
        case 25:
          goto label_50;
        case 26:
          goto label_37;
        case 27:
          goto label_69;
        case 28:
          goto label_23;
        case 29:
          goto label_24;
        case 30:
          goto label_39;
        case 31 /*0x1F*/:
          goto label_16;
        case 32 /*0x20*/:
          goto label_68;
        case 33:
          goto label_58;
        case 34:
          goto label_64;
        case 35:
          goto label_63;
        case 36:
          goto label_36;
        case 37:
          goto label_65;
        case 38:
          goto label_32;
        case 39:
          goto label_77;
        case 40:
          goto label_59;
        case 41:
          goto label_6;
        case 42:
          goto label_12;
        case 43:
          goto label_62;
        case 44:
          goto label_57;
        case 45:
          goto label_66;
        case 46:
          goto label_25;
        case 47:
          goto label_49;
        case 48 /*0x30*/:
          goto label_72;
        case 49:
          goto label_10;
        case 50:
          goto label_70;
        case 51:
          goto label_5;
        case 52:
          goto label_78;
        case 53:
          goto label_53;
        case 54:
          goto label_61;
        case 55:
          goto label_38;
        case 56:
          goto label_46;
        case 57:
          goto label_22;
        case 58:
          goto label_71;
        case 59:
          goto label_8;
        case 60:
          goto label_28;
        case 61:
          goto label_51;
        case 62:
          goto label_54;
        case 63 /*0x3F*/:
          goto label_14;
        case 64 /*0x40*/:
          goto label_40;
        case 65:
          goto label_21;
        case 66:
          goto label_11;
        case 67:
          goto label_55;
        case 68:
          goto label_43;
        case 69:
          goto label_80;
        case 70:
          goto label_67;
        case 71:
          goto label_15;
        case 72:
          goto label_79;
        default:
          num = 0;
          continue;
      }
    }
label_5:
    this.PeerIPAddress1 = (AcpLabel) target;
    return;
label_6:
    this.ExpIndAstroOtarRadioIDList = (AcpExpander) target;
    return;
label_7:
    this.progressBar2 = (ProgressBar) target;
    return;
label_8:
    this.DataProfilesDataPresenter = (AcpXamDataPresenter) target;
    return;
label_9:
    this.HLinkDataWide = (Hyperlink) target;
    this.HLinkDataWide.Click += new RoutedEventHandler(this.HLinkClick);
    return;
label_10:
    this.SubscriberIPAddress1 = (AcpLabel) target;
    return;
label_11:
    this.LblUserInfoUserLoginUnitID = (AcpLabel) target;
    return;
label_12:
    this.LblSecWideASTROOTARIndividualASTROOTARRadioID = (AcpLabel) target;
    return;
label_13:
    this.CloneRadiobutton = (Button) target;
    this.CloneRadiobutton.Click += new RoutedEventHandler(this.OnCloneWizardClone);
    return;
label_14:
    this.RadWideUserInformationandPasswordsSoftIDUsername = (AcpTextBox) target;
    return;
label_15:
    this.BluetoothFriendlyName = (AcpLabel) target;
    return;
label_16:
    this.FileCloneEnBox = (AcpCheckBox) target;
    return;
label_18:
    this.MyStackPanel = (StackPanel) target;
    return;
label_19:
    this.HLinkUserInfo = (Hyperlink) target;
    this.HLinkUserInfo.Click += new RoutedEventHandler(this.HLinkClick);
    return;
label_20:
    this.btnBatchProgrammingHelp = (Button) target;
    this.btnBatchProgrammingHelp.Click += new RoutedEventHandler(this.buttonHelp_Click);
    return;
label_21:
    this.RadWideUserInformationandPasswordsPINPassword = (AcpPasswordEyeBox) target;
    return;
label_22:
    this.DataWideGeneralBTPeerIPAddress = (AcpTextBox) target;
    return;
label_23:
    this.OK = (AcpButton) target;
    ((ButtonBase) this.OK).Click += new RoutedEventHandler(this.OK_Click);
    return;
label_24:
    this.ExpFileClone = (AcpExpander) target;
    return;
label_25:
    this.IndAstroOtarRadioID_Col = (UnboundField) target;
    return;
label_26:
    this.CnvSysAstroIDIncrement = (AcpTextBox) target;
    return;
label_27:
    this.ReadRadioIDsbutton = (Button) target;
    this.ReadRadioIDsbutton.Click += new RoutedEventHandler(this.OnCloneWizardReadIds);
    return;
label_28:
    this.DataProfileName_Col = (UnboundField) target;
    return;
label_29:
    this.TrkSysUnitIDIncrement = (AcpTextBox) target;
    return;
label_30:
    this.UnitID = (AcpLabel) target;
    return;
label_31:
    this.ExpMultipleRadio = (AcpExpander) target;
    return;
label_32:
    switch (true ? 1 : 0)
    {
      case 0:
      case 2:
        goto label_39;
      default:
        if (true)
          ;
        this.UnitID_Col = (UnboundField) target;
        return;
    }
label_35:
    ((CommandBinding) target).Executed += new ExecutedRoutedEventHandler(this.buttonHelp_Click);
    ((CommandBinding) target).CanExecute += new CanExecuteRoutedEventHandler(this.F1HelpCommandCanExcute);
    return;
label_36:
    this.TrkSysName_Col = (UnboundField) target;
    return;
label_37:
    this.AstroOtarRadioID = (AcpLabel) target;
    return;
label_38:
    this.DataWideGeneralBTSubscriberIPAddress = (AcpTextBox) target;
    return;
label_39:
    this.FileCloneEn = (AcpLabel) target;
    return;
label_40:
    this.LblUserInfoPINPassword = (AcpLabel) target;
    return;
label_41:
    this.HLinkExpIndAstroOtarRadioIDList = (Hyperlink) target;
    this.HLinkExpIndAstroOtarRadioIDList.Click += new RoutedEventHandler(this.HLinkClick);
    return;
label_42:
    ((FrameworkElement) target).Loaded += new RoutedEventHandler(((AcpPageFeature) this).OnLoaded);
    ((FrameworkElement) target).Unloaded += new RoutedEventHandler(((AcpPageFeature) this).OnUnloaded);
    return;
label_43:
    this.LblRadioAlias = (AcpLabel) target;
    return;
label_44:
    this.ASTROID = (AcpLabel) target;
    return;
label_45:
    this.HLinkDataProfileList = (Hyperlink) target;
    this.HLinkDataProfileList.Click += new RoutedEventHandler(this.HLinkClick);
    return;
label_46:
    this.DataWideBTPeerIPAddress = (AcpLabel) target;
    return;
label_47:
    this.HLinkFileClone = (Hyperlink) target;
    this.HLinkFileClone.Click += new RoutedEventHandler(this.HLinkClick);
    return;
label_48:
    this.ProgText = (AcpLabel) target;
    return;
label_49:
    this.ExpDataWide = (AcpExpander) target;
    return;
label_50:
    this.CnvSysMdcIDIncrement = (AcpTextBox) target;
    return;
label_51:
    if (false)
      ;
    this.ExpUserInfo = (AcpExpander) target;
    return;
label_53:
    this.GrpBoxExpanderDataWideGeneralBluetoothDUNAddresses = (AcpGroupBox) target;
    return;
label_54:
    this.SoftIDUsername = (AcpLabel) target;
    return;
label_55:
    this.RadWideUserInformationandPasswordsUserLoginUnitID = (AcpTextBox) target;
    return;
label_56:
    this.HLinkBluetooth = (Hyperlink) target;
    this.HLinkBluetooth.Click += new RoutedEventHandler(this.HLinkClick);
    return;
label_57:
    this.IndAstroOtardRadioIDDataPresenter = (AcpXamDataPresenter) target;
    return;
label_58:
    this.SerialNumberBox = (AcpTextBox) target;
    return;
label_59:
    this.CnvSysIDDataPresenter = (AcpXamDataPresenter) target;
    return;
label_60:
    this.HLinkExpCnvSysIDList = (Hyperlink) target;
    this.HLinkExpCnvSysIDList.Click += new RoutedEventHandler(this.HLinkClick);
    return;
label_61:
    this.DataWideBTSubscriberIPAddress = (AcpLabel) target;
    return;
label_62:
    this.SecWideASTROOTARIndividualASTROOTARRadioID = (AcpTextBoxSpinner) target;
    return;
label_63:
    this.TrunkingIDDataPresenter = (AcpXamDataPresenter) target;
    return;
label_64:
    this.ExpTrkSysIDList = (AcpExpander) target;
    return;
label_65:
    this.TrkSysID_Col = (UnboundField) target;
    return;
label_66:
    this.SecureKMFProfile_Col = (UnboundField) target;
    return;
label_67:
    this.ExpBluetooth = (AcpExpander) target;
    return;
label_68:
    this.SerialNumber = (AcpLabel) target;
    return;
label_69:
    this.IndAstroOtarRadioIDIncrement = (AcpTextBox) target;
    return;
label_70:
    this.DataWideGeneralSubscriberIPAddress1 = (AcpTextBox) target;
    return;
label_71:
    this.ExpDataProfileList = (AcpExpander) target;
    return;
label_72:
    this.GrpBoxExpanderDataWideGeneralSerialLink1Addresses = (AcpGroupBox) target;
    return;
label_73:
    this.HLinkMultipleRadio = (Hyperlink) target;
    this.HLinkMultipleRadio.Click += new RoutedEventHandler(this.HLinkClick);
    return;
label_74:
    this.ThemeBaseObj = (AcpThemeBase) target;
    return;
label_75:
    this.HLinkTrkSysIDList = (Hyperlink) target;
    this.HLinkTrkSysIDList.Click += new RoutedEventHandler(this.HLinkClick);
    return;
label_76:
    this.MDCID = (AcpLabel) target;
    return;
label_77:
    this.ExpCnvSysIDList = (AcpExpander) target;
    return;
label_78:
    this.DataWideGeneralPeerIPAddress1 = (AcpTextBox) target;
    return;
label_79:
    this.RadWideBluetoothFriendlyName = (AcpTextBox) target;
    return;
label_80:
    this.RadWideUserInformationandPasswordsRadioAlias = (AcpTextBox) target;
    return;
label_81:
    this.aa = true;
  }

  public delegate void MainUIDisplayCBI(SpecialFeatures.Comms.Comms.CBIReturn CbiSN);

  public delegate void MainUIDisplayOTAP(
    ProgrammingOperation ProgOp,
    OTAPProgrammingParameters LastCommsOTAPUserState,
    SpecialFeatures.Comms.Comms.RadioOTAPObject radioObject);

  public delegate void WriteRadioQuery(SpecialFeatures.Comms.Comms.RadioRtn info);

  private delegate void UpdateProgress(double n, string stat);

  private delegate void MainFinish(bool status);

  private delegate void MainThreadUpdateRadioIds(RadioIdInfo TempRadioIds, bool TrkEnabled);
}
