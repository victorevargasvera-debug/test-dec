// Decompiled with JetBrains decompiler
// Type: MackinawCPS.PageDeviceInfo
// Assembly: APXFamilyCPS, Version=36.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 9359335E-041C-4B12-9409-F4E6E7D93299
// Assembly location: C:\Program Files (x86)\Motorola\ApxFamilyCPS R36.00\APXFamilyCPS1.exe

using AcpUI;
using AcpUI.Common;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

#nullable disable
namespace MackinawCPS;

public class PageDeviceInfo : Page, IComponentConnector
{
  private Expander myExpander1;
  internal AcpListBox LstBoxDI;
  internal AcpExpander ExpID1;
  internal AcpLabel LblSerNo1;
  internal AcpLabel LblHostDsp1;
  internal AcpLabel LblTune1;
  internal AcpLabel LblMace1;
  internal AcpViewOnlyCtrl LblSerNo11;
  internal AcpViewOnlyCtrl LblHostDsp11;
  internal AcpViewOnlyCtrl LblTune11;
  internal AcpViewOnlyCtrl LblMace11;
  internal AcpExpander ExpID2;
  internal AcpLabel LblSerNo2;
  internal AcpLabel LblTune2;
  internal AcpLabel LblHostDsp2;
  internal AcpLabel LblMace2;
  internal AcpViewOnlyCtrl LblSerNo12;
  internal AcpViewOnlyCtrl LblHostDsp12;
  internal AcpViewOnlyCtrl LblTune12;
  internal AcpViewOnlyCtrl LblMace12;
  internal AcpExpander ExpID3;
  internal AcpLabel LblSerNo3;
  internal AcpLabel LblTune3;
  internal AcpLabel LblHostDsp3;
  internal AcpLabel LblMace3;
  internal AcpViewOnlyCtrl LblSerNo13;
  internal AcpViewOnlyCtrl LblHostDsp13;
  internal AcpViewOnlyCtrl LblTune13;
  internal AcpViewOnlyCtrl LblMace13;
  internal AcpExpander ExpID4;
  internal AcpLabel LblSerNo4;
  internal AcpLabel LblTune4;
  internal AcpLabel LblHostDsp4;
  internal AcpLabel LblMace4;
  internal AcpViewOnlyCtrl LblSerNo14;
  internal AcpViewOnlyCtrl LblHostDsp14;
  internal AcpViewOnlyCtrl LblTune14;
  internal AcpViewOnlyCtrl LblMace14;
  internal AcpExpander ExpID5;
  internal AcpLabel LblSerNo5;
  internal AcpLabel LblTune5;
  internal AcpLabel LblHostDsp5;
  internal AcpLabel LblMace5;
  internal AcpViewOnlyCtrl LblSerNo15;
  internal AcpViewOnlyCtrl LblHostDsp15;
  internal AcpViewOnlyCtrl LblTune15;
  internal AcpViewOnlyCtrl LblMace15;
  internal AcpExpander ExpID6;
  internal AcpLabel LblSerNo6;
  internal AcpLabel LblTune6;
  internal AcpLabel LblHostDsp6;
  internal AcpLabel LblMace6;
  internal AcpViewOnlyCtrl LblSerNo16;
  internal AcpViewOnlyCtrl LblHostDsp16;
  internal AcpViewOnlyCtrl LblTune16;
  internal AcpViewOnlyCtrl LblMace16;
  private bool _contentLoaded;

  public void OnExpSelectionChanged1(object sender, RoutedEventArgs e)
  {
    AcpListBox source = (AcpListBox) e.Source;
    if (this.myExpander1 == null)
      this.myExpander1 = new Expander();
    switch (source.SelectedIndex)
    {
      case 0:
        this.myExpander1 = (Expander) this.ExpID1;
        break;
      case 1:
        this.myExpander1 = (Expander) this.ExpID2;
        break;
      case 2:
        this.myExpander1 = (Expander) this.ExpID3;
        break;
      case 3:
        this.myExpander1 = (Expander) this.ExpID4;
        break;
      case 4:
        this.myExpander1 = (Expander) this.ExpID5;
        break;
      case 5:
        this.myExpander1 = (Expander) this.ExpID6;
        break;
    }
  }

  public PageDeviceInfo()
  {
    this.InitializeComponent();
    Utility.SetDirection((FrameworkElement) this);
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "8.0.8.0")]
  public void InitializeComponent()
  {
    if (this._contentLoaded)
      return;
    this._contentLoaded = true;
    Application.LoadComponent((object) this, new Uri("/APXFamilyCPS;component/devicemanager/pagedeviceinfo.xaml", UriKind.Relative));
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "8.0.8.0")]
  [EditorBrowsable(EditorBrowsableState.Never)]
  void IComponentConnector.Connect(int connectionId, object target)
  {
    switch (connectionId)
    {
      case 1:
        this.LstBoxDI = (AcpListBox) target;
        this.LstBoxDI.SelectionChanged += new SelectionChangedEventHandler(this.OnExpSelectionChanged1);
        break;
      case 2:
        this.ExpID1 = (AcpExpander) target;
        break;
      case 3:
        this.LblSerNo1 = (AcpLabel) target;
        break;
      case 4:
        this.LblHostDsp1 = (AcpLabel) target;
        break;
      case 5:
        this.LblTune1 = (AcpLabel) target;
        break;
      case 6:
        this.LblMace1 = (AcpLabel) target;
        break;
      case 7:
        this.LblSerNo11 = (AcpViewOnlyCtrl) target;
        break;
      case 8:
        this.LblHostDsp11 = (AcpViewOnlyCtrl) target;
        break;
      case 9:
        this.LblTune11 = (AcpViewOnlyCtrl) target;
        break;
      case 10:
        this.LblMace11 = (AcpViewOnlyCtrl) target;
        break;
      case 11:
        this.ExpID2 = (AcpExpander) target;
        break;
      case 12:
        this.LblSerNo2 = (AcpLabel) target;
        break;
      case 13:
        this.LblTune2 = (AcpLabel) target;
        break;
      case 14:
        this.LblHostDsp2 = (AcpLabel) target;
        break;
      case 15:
        this.LblMace2 = (AcpLabel) target;
        break;
      case 16 /*0x10*/:
        this.LblSerNo12 = (AcpViewOnlyCtrl) target;
        break;
      case 17:
        this.LblHostDsp12 = (AcpViewOnlyCtrl) target;
        break;
      case 18:
        this.LblTune12 = (AcpViewOnlyCtrl) target;
        break;
      case 19:
        this.LblMace12 = (AcpViewOnlyCtrl) target;
        break;
      case 20:
        this.ExpID3 = (AcpExpander) target;
        break;
      case 21:
        this.LblSerNo3 = (AcpLabel) target;
        break;
      case 22:
        this.LblTune3 = (AcpLabel) target;
        break;
      case 23:
        this.LblHostDsp3 = (AcpLabel) target;
        break;
      case 24:
        this.LblMace3 = (AcpLabel) target;
        break;
      case 25:
        this.LblSerNo13 = (AcpViewOnlyCtrl) target;
        break;
      case 26:
        this.LblHostDsp13 = (AcpViewOnlyCtrl) target;
        break;
      case 27:
        this.LblTune13 = (AcpViewOnlyCtrl) target;
        break;
      case 28:
        this.LblMace13 = (AcpViewOnlyCtrl) target;
        break;
      case 29:
        this.ExpID4 = (AcpExpander) target;
        break;
      case 30:
        this.LblSerNo4 = (AcpLabel) target;
        break;
      case 31 /*0x1F*/:
        this.LblTune4 = (AcpLabel) target;
        break;
      case 32 /*0x20*/:
        this.LblHostDsp4 = (AcpLabel) target;
        break;
      case 33:
        this.LblMace4 = (AcpLabel) target;
        break;
      case 34:
        this.LblSerNo14 = (AcpViewOnlyCtrl) target;
        break;
      case 35:
        this.LblHostDsp14 = (AcpViewOnlyCtrl) target;
        break;
      case 36:
        this.LblTune14 = (AcpViewOnlyCtrl) target;
        break;
      case 37:
        this.LblMace14 = (AcpViewOnlyCtrl) target;
        break;
      case 38:
        this.ExpID5 = (AcpExpander) target;
        break;
      case 39:
        this.LblSerNo5 = (AcpLabel) target;
        break;
      case 40:
        this.LblTune5 = (AcpLabel) target;
        break;
      case 41:
        this.LblHostDsp5 = (AcpLabel) target;
        break;
      case 42:
        this.LblMace5 = (AcpLabel) target;
        break;
      case 43:
        this.LblSerNo15 = (AcpViewOnlyCtrl) target;
        break;
      case 44:
        this.LblHostDsp15 = (AcpViewOnlyCtrl) target;
        break;
      case 45:
        this.LblTune15 = (AcpViewOnlyCtrl) target;
        break;
      case 46:
        this.LblMace15 = (AcpViewOnlyCtrl) target;
        break;
      case 47:
        this.ExpID6 = (AcpExpander) target;
        break;
      case 48 /*0x30*/:
        this.LblSerNo6 = (AcpLabel) target;
        break;
      case 49:
        this.LblTune6 = (AcpLabel) target;
        break;
      case 50:
        this.LblHostDsp6 = (AcpLabel) target;
        break;
      case 51:
        this.LblMace6 = (AcpLabel) target;
        break;
      case 52:
        this.LblSerNo16 = (AcpViewOnlyCtrl) target;
        break;
      case 53:
        this.LblHostDsp16 = (AcpViewOnlyCtrl) target;
        break;
      case 54:
        this.LblTune16 = (AcpViewOnlyCtrl) target;
        break;
      case 55:
        this.LblMace16 = (AcpViewOnlyCtrl) target;
        break;
      default:
        this._contentLoaded = true;
        break;
    }
  }
}
