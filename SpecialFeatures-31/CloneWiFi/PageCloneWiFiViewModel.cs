// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.CloneWiFi.PageCloneWiFiViewModel
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

using ACPBrowser;
using AcpBusinessLayer;
using AcpCommonLib;
using Motorola.MackinawCPS.CoreFeatures.DataWide;
using SpecialFeatures.Clone_Configuration.Common;
using SpecialFeatures.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Input;

#nullable disable
namespace SpecialFeatures.CloneWiFi;

public class PageCloneWiFiViewModel : INotifyPropertyChanged
{
  private readonly List<KeyValuePair<string, string>> a = new List<KeyValuePair<string, string>>();
  private readonly PageCloneWiFiView b;
  [CompilerGenerated]
  private ObservableCollection<WiFiRecord> c = new ObservableCollection<WiFiRecord>();

  public PageCloneWiFiViewModel(PageCloneWiFiView view)
  {
    this.b = view;
    this.OKCommand = (ICommand) new RelayCommand(new Action<object>(this.c));
    this.CancelCommand = (ICommand) new RelayCommand(new Action<object>(this.b));
    this.HelpCommand = (ICommand) new RelayCommand(new Action<object>(this.a));
    this.b();
    this.a();
  }

  public ObservableCollection<WiFiRecord> ItemSource
  {
    get
    {
      short num1 = 11777;
      int num2 = (int) num1;
      num1 = (short) 11777;
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
          return this.c;
        default:
          num4 = (short) 0;
          goto case 1;
      }
    }
    set
    {
      short num1 = 25567;
      int num2 = (int) num1;
      num1 = (short) 25567;
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
          this.c = value;
          break;
        default:
          num4 = (short) 0;
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
          changedEventHandler = this.d;
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
                goto label_11;
              case 1:
                if (changedEventHandler == comparand)
                {
                  num2 = (short) 0;
                  num1 = (int) (IntPtr) num2;
                  continue;
                }
                break;
              case 2:
                num2 = (short) 1;
                if (num2 == (short) 0)
                  ;
                num2 = (short) -19196;
                int num3 = (int) num2;
                num2 = (short) -19196;
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
                    num2 = (short) 0;
                    break;
                }
                break;
              default:
                goto label_2;
            }
            comparand = changedEventHandler;
            changedEventHandler = Interlocked.CompareExchange<PropertyChangedEventHandler>(ref this.d, comparand + value, comparand);
label_8:
            num2 = (short) 1;
            num1 = (int) (IntPtr) num2;
          }
label_11:
          break;
      }
    }
    remove
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
          changedEventHandler = this.d;
          num1 = (short) 2;
          num2 = (int) (IntPtr) num1;
          goto default;
        default:
          while (true)
          {
            PropertyChangedEventHandler comparand;
            switch (num2)
            {
              case 0:
                goto label_11;
              case 1:
                if (changedEventHandler == comparand)
                {
                  num1 = (short) 0;
                  num2 = (int) (IntPtr) num1;
                  continue;
                }
                break;
              case 2:
                num1 = (short) -12962;
                int num3 = (int) num1;
                num1 = (short) -12962;
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
                    break;
                }
                break;
              default:
                goto label_3;
            }
            comparand = changedEventHandler;
            changedEventHandler = Interlocked.CompareExchange<PropertyChangedEventHandler>(ref this.d, comparand - value, comparand);
label_8:
            num1 = (short) 1;
            num2 = (int) (IntPtr) num1;
          }
label_11:
          break;
      }
    }
  }

  public void OnPropertyChanged(PropertyChangedEventArgs e)
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
          // ISSUE: reference to a compiler-generated field
          this.d((object) this, e);
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
          num2 = (short) -32603;
          int num3 = (int) num2;
          num2 = (short) -32603;
          int num4 = (int) num2;
          switch (num3 == num4 ? 1 : 0)
          {
            case 0:
            case 2:
              goto label_9;
            default:
              num2 = (short) 1;
              if (num2 == (short) 0)
                ;
              num2 = (short) 0;
              if (num2 == (short) 0)
                ;
              num2 = (short) 0;
              // ISSUE: reference to a compiler-generated field
              if (this.d != null)
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

  public ICommand OKCommand
  {
    get
    {
      short num1 = 1;
      if (num1 == (short) 0)
        ;
      num1 = (short) 0;
      num1 = (short) 2014;
      int num2 = (int) num1;
      num1 = (short) 2014;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          num1 = (short) 0;
          if (num1 == (short) 0)
            ;
          return this.e;
        default:
          goto case 1;
      }
    }
    set
    {
      short num1 = -5246;
      int num2 = (int) num1;
      num1 = (short) -5246;
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
          this.e = value;
          break;
        default:
          num4 = (short) 0;
          goto case 1;
      }
    }
  }

  public ICommand CancelCommand
  {
    get
    {
      short num1 = -409;
      int num2 = (int) num1;
      num1 = (short) -409;
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
          return this.f;
        default:
          num4 = (short) 0;
          goto case 1;
      }
    }
    set
    {
      short num1 = -14618;
      int num2 = (int) num1;
      num1 = (short) -14618;
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

  public ICommand HelpCommand
  {
    get
    {
      short num1 = 1;
      if (num1 == (short) 0)
        ;
      num1 = (short) 0;
      num1 = (short) 30985;
      int num2 = (int) num1;
      num1 = (short) 30985;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          num1 = (short) 0;
          if (num1 == (short) 0)
            ;
          return this.g;
        default:
          goto case 1;
      }
    }
    set
    {
      short num1 = 29870;
      int num2 = (int) num1;
      num1 = (short) 29870;
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
          this.g = value;
          break;
        default:
          num4 = (short) 0;
          goto case 1;
      }
    }
  }

  private void c(object A_0)
  {
    int num1 = 0;
    switch (num1)
    {
      default:
        bool flag;
        int index;
        short num2;
        switch (0)
        {
          case 0:
label_3:
            flag = true;
            index = 0;
            num2 = (short) 8;
            num1 = (int) (IntPtr) num2;
            goto default;
          default:
            while (true)
            {
              WiFiRecord wiFiRecord;
              switch (num1)
              {
                case 0:
                  if (!wiFiRecord.PWD.IsValid)
                  {
                    num2 = (short) 1;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  break;
                case 1:
                  num2 = (short) 1;
                  if (num2 == (short) 0)
                    ;
                  flag = false;
                  num2 = (short) 3;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 2:
                case 8:
                  num2 = (short) 7;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 3:
                  num2 = (short) 30331;
                  int num3 = (int) num2;
                  num2 = (short) 30331;
                  int num4 = (int) num2;
                  switch (num3 == num4 ? 1 : 0)
                  {
                    case 0:
                    case 2:
                      goto label_19;
                    default:
                      num2 = (short) 0;
                      num2 = (short) 0;
                      if (num2 == (short) 0)
                        break;
                      break;
                  }
                  break;
                case 4:
                  if (flag)
                  {
                    num2 = (short) 5;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_19;
                case 5:
                  goto label_12;
                case 6:
                  num2 = (short) 4;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 7:
                  if (index < this.ItemSource.Count)
                  {
                    wiFiRecord = this.ItemSource[index];
                    wiFiRecord.PWD.IsValid = wiFiRecord.PWD.Content.Equals(this.a[index].Value);
                    num2 = (short) 0;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 6;
                  num1 = (int) (IntPtr) num2;
                  continue;
                default:
                  goto label_3;
              }
              ++index;
              num2 = (short) 2;
              num1 = (int) (IntPtr) num2;
            }
label_12:
            this.b.LblCloneWiFiWarning.Visibility = Visibility.Hidden;
            ((Window) ((FrameworkElement) this.b).Parent).DialogResult = new bool?(true);
            WiFiPasswordUtil.RefreshSessionTimer();
            return;
label_19:
            this.b.LblCloneWiFiWarning.Visibility = Visibility.Visible;
            Cursor overrideCursor = Mouse.OverrideCursor;
            Mouse.OverrideCursor = Cursors.Wait;
            WiFiPasswordUtil.WaitNextValidate();
            Mouse.OverrideCursor = overrideCursor;
            return;
        }
    }
  }

  private void b(object A_0)
  {
    short num1 = -5123;
    int num2 = (int) num1;
    num1 = (short) -5123;
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
        ((Window) ((FrameworkElement) this.b).Parent).DialogResult = new bool?(false);
        break;
      default:
        num4 = (short) 0;
        goto case 1;
    }
  }

  private void a(object A_0)
  {
    try
    {
      short num1 = 29945;
      int num2 = (int) num1;
      num1 = (short) 29945;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          if (true)
            ;
          Utility.CloseHelpWindowIfOpen();
          Utility.DisplayCPSHelpDITA((string) null);
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

  private void b()
  {
    int num1 = 0;
    switch (num1)
    {
      default:
        Motorola.MackinawCPS.CoreFeatures.DataWide.DataWide dataWide;
        short num2;
        switch (0)
        {
          case 0:
label_3:
            dataWide = FeatureManager.GetFeature(2028)[0] as Motorola.MackinawCPS.CoreFeatures.DataWide.DataWide;
            num2 = (short) 6;
            num1 = (int) (IntPtr) num2;
            goto default;
          default:
            ConfiguredNetworksListInnerRecset embeddedRecset;
            IEnumerator<FeatureNode> enumerator;
            while (true)
            {
              switch (num1)
              {
                case 0:
                  goto label_13;
                case 1:
                  goto label_12;
                case 2:
                  if (!dataWide.WIFI.DataWideWIFIEnable_42506.Value)
                  {
                    num2 = (short) 1;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  embeddedRecset = ((FeatureSection) dataWide.WIFI).EmbeddedRecset as ConfiguredNetworksListInnerRecset;
                  num2 = (short) 5;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 3:
                  goto label_11;
                case 4:
                  goto label_40;
                case 5:
                  if (embeddedRecset != null)
                  {
                    enumerator = ((Collection<FeatureNode>) embeddedRecset).GetEnumerator();
                    num2 = (short) 0;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 0;
                  num2 = (short) 4;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 6:
                  if (dataWide == null)
                  {
                    num2 = (short) 3;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 2;
                  num1 = (int) (IntPtr) num2;
                  continue;
                default:
                  goto label_3;
              }
            }
label_12:
            return;
label_40:
            return;
label_11:
            num2 = (short) 1;
            if (num2 == (short) 0)
              ;
            return;
label_13:
            try
            {
              num2 = (short) 8;
              int num3 = (int) (IntPtr) num2;
              while (true)
              {
                ConfiguredNetworksListInner current;
                ConfiguredNetworksListInnerSection listInnerSection;
                switch (num3)
                {
                  case 0:
                    num2 = (short) 6;
                    num3 = (int) (IntPtr) num2;
                    continue;
                  case 2:
                    if (enumerator.MoveNext())
                    {
                      current = enumerator.Current as ConfiguredNetworksListInner;
                      num2 = (short) 4;
                      num3 = (int) (IntPtr) num2;
                      continue;
                    }
                    num2 = (short) 0;
                    num3 = (int) (IntPtr) num2;
                    continue;
                  case 3:
                    if (AcpField<int>.op_Implicit((AcpField<int>) listInnerSection.DataWideWiFiNetworkSecurityType_42516) != 0)
                    {
                      num2 = (short) 7;
                      num3 = (int) (IntPtr) num2;
                      continue;
                    }
                    break;
                  case 4:
                    if (current != null)
                    {
                      num2 = (short) 5;
                      num3 = (int) (IntPtr) num2;
                      continue;
                    }
                    break;
                  case 5:
                    listInnerSection = current.ConfiguredNetworksListInnerSection;
                    num2 = (short) 3;
                    num3 = (int) (IntPtr) num2;
                    continue;
                  case 6:
                    goto label_41;
                  case 7:
                    WiFiRecord wiFiRecord = new WiFiRecord()
                    {
                      SSID = listInnerSection.DataWideWiFiNetworkSSID_42519.Value,
                      PWD = new WiFiPwd()
                      {
                        Content = string.Empty,
                        IsValid = true
                      },
                      FeatureName = ((FeatureSection) dataWide.WIFI).FeatureSectionName
                    };
                    this.a.Add(new KeyValuePair<string, string>(listInnerSection.DataWideWiFiNetworkSSID_42519.Value, listInnerSection.DataWideWiFiNetworkEncryptedNetworkPassword_42517.UIValue));
                    this.ItemSource.Add(wiFiRecord);
                    num2 = (short) 1;
                    num3 = (int) (IntPtr) num2;
                    continue;
                  case 8:
                    switch (0)
                    {
                      case 0:
                        break;
                      default:
                        continue;
                    }
                    break;
                }
                num2 = (short) 2;
                num3 = (int) (IntPtr) num2;
              }
label_41:
              return;
            }
            finally
            {
              int num4 = 2;
              short num5;
              while (true)
              {
                switch (num4)
                {
                  case 0:
                    goto label_35;
                  case 1:
label_34:
                    enumerator.Dispose();
                    num5 = (short) 0;
                    num4 = (int) (IntPtr) num5;
                    continue;
                  case 2:
                    switch (0)
                    {
                      case 0:
                        goto label_30;
                      default:
                        continue;
                    }
                  default:
label_30:
                    num5 = (short) -15223;
                    int num6 = (int) num5;
                    num5 = (short) -15223;
                    int num7 = (int) num5;
                    switch (num6 == num7 ? 1 : 0)
                    {
                      case 0:
                      case 2:
                        goto label_34;
                      default:
                        num5 = (short) 0;
                        if (num5 == (short) 0)
                          ;
                        if (enumerator != null)
                        {
                          num5 = (short) 1;
                          num4 = (int) (IntPtr) num5;
                          continue;
                        }
                        goto label_35;
                    }
                }
              }
label_35:;
            }
        }
    }
  }

  private void a()
  {
    int num1 = 0;
    switch (num1)
    {
      default:
        Motorola.MackinawCPS.CoreFeatures.DataWide.DataWide dataWide;
        short num2;
        switch (0)
        {
          case 0:
label_3:
            dataWide = FeatureManager.GetFeature(2028)[0] as Motorola.MackinawCPS.CoreFeatures.DataWide.DataWide;
            num2 = (short) 2;
            num1 = (int) (IntPtr) num2;
            goto default;
          default:
            DataModemTableInnerRecset embeddedRecset;
            IEnumerator<FeatureNode> enumerator;
            while (true)
            {
              switch (num1)
              {
                case 0:
                  num2 = (short) 1;
                  if (num2 == (short) 0)
                    ;
                  num2 = (short) 4;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 1:
                  goto label_32;
                case 2:
                  if (dataWide != null)
                  {
                    num2 = (short) 0;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_7;
                case 3:
                  if (embeddedRecset != null)
                  {
                    enumerator = ((Collection<FeatureNode>) embeddedRecset).GetEnumerator();
                    num2 = (short) 5;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 6;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 4:
                  if (AcpField<int>.op_Implicit((AcpField<int>) dataWide.ExternalDataModem.ModemConnectionType_43350) != 1)
                  {
                    num2 = (short) 0;
                    num2 = (short) 1;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  embeddedRecset = ((FeatureSection) dataWide.ExternalDataModem).EmbeddedRecset as DataModemTableInnerRecset;
                  num2 = (short) 3;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 5:
                  goto label_13;
                case 6:
                  goto label_37;
                default:
                  goto label_3;
              }
            }
label_32:
            return;
label_37:
            return;
label_7:
            return;
label_13:
            try
            {
              num2 = (short) 2;
              int num3 = (int) (IntPtr) num2;
              while (true)
              {
                DataModemTableInner current;
                switch (num3)
                {
                  case 1:
                    if (!enumerator.MoveNext())
                    {
                      num2 = (short) 3;
                      num3 = (int) (IntPtr) num2;
                      continue;
                    }
                    break;
                  case 2:
                    switch (0)
                    {
                      case 0:
                        goto label_22;
                      default:
                        continue;
                    }
                  case 3:
                    num2 = (short) 6;
                    num3 = (int) (IntPtr) num2;
                    continue;
                  case 4:
                    num2 = (short) 6276;
                    int num4 = (int) num2;
                    num2 = (short) 6276;
                    int num5 = (int) num2;
                    switch (num4 == num5 ? 1 : 0)
                    {
                      case 0:
                      case 2:
                        break;
                      default:
                        num2 = (short) 0;
                        if (num2 == (short) 0)
                          ;
                        DataModemTableInnerSection tableInnerSection = current.DataModemTableInnerSection;
                        WiFiRecord wiFiRecord = new WiFiRecord()
                        {
                          SSID = tableInnerSection.DataWideExternalDataModemNetworkSsid_43358.Value,
                          PWD = new WiFiPwd()
                          {
                            Content = string.Empty,
                            IsValid = true
                          },
                          FeatureName = ((FeatureSection) dataWide.ExternalDataModem).FeatureSectionName
                        };
                        this.a.Add(new KeyValuePair<string, string>(tableInnerSection.DataWideExternalDataModemNetworkSsid_43358.Value, tableInnerSection.DataWideEncryptedNetworkPassword_43361.UIValue));
                        this.ItemSource.Add(wiFiRecord);
                        num2 = (short) 0;
                        num3 = (int) (IntPtr) num2;
                        continue;
                    }
                    break;
                  case 5:
                    if (current != null)
                    {
                      num2 = (short) 4;
                      num3 = (int) (IntPtr) num2;
                      continue;
                    }
                    goto default;
                  case 6:
                    goto label_8;
                  default:
label_22:
                    num2 = (short) 1;
                    num3 = (int) (IntPtr) num2;
                    continue;
                }
                current = enumerator.Current as DataModemTableInner;
                num2 = (short) 5;
                num3 = (int) (IntPtr) num2;
              }
label_8:
              return;
            }
            finally
            {
              short num6 = 1;
              int num7 = (int) (IntPtr) num6;
              while (true)
              {
                switch (num7)
                {
                  case 0:
                    enumerator.Dispose();
                    num6 = (short) 2;
                    num7 = (int) (IntPtr) num6;
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
                    goto label_33;
                }
                if (enumerator != null)
                {
                  num6 = (short) 0;
                  num7 = (int) (IntPtr) num6;
                }
                else
                  break;
              }
label_33:;
            }
        }
    }
  }
}
