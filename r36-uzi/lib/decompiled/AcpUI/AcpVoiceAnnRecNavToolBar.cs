// Decompiled with JetBrains decompiler
// Type: AcpUI.AcpVoiceAnnRecNavToolBar
// Assembly: AcpUI, Version=23.1.0.32, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: DC7F6A15-37A6-4183-BF9F-09213F636FB6
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpUI.dll

using AcpCommonLib;
using AcpFileHandlerLib;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

#nullable disable
namespace AcpUI;

public class AcpVoiceAnnRecNavToolBar : AcpRecNavToolbar
{
  private string[] voiceAnnFiles;
  public static readonly RoutedEvent MultiAddClickEvent = EventManager.RegisterRoutedEvent("MultiAddClick", RoutingStrategy.Bubble, typeof (RoutedEventHandler), typeof (AcpRecNavToolbar));

  public string[] VoiceAnnFiles => this.voiceAnnFiles;

  public AcpVoiceAnnRecNavToolBar() => this.IsAddMultQtyEn = false;

  public event RoutedEventHandler MultiAddClick
  {
    add => this.AddHandler(AcpVoiceAnnRecNavToolBar.MultiAddClickEvent, (Delegate) value);
    remove => this.RemoveHandler(AcpVoiceAnnRecNavToolBar.MultiAddClickEvent, (Delegate) value);
  }

  public Func<SelectionMode, List<string>> SelectVAFileDialog { get; set; }

  protected override void OnRecNavBtnAddMultipleClick(object sender, RoutedEventArgs e)
  {
    AppInfoManager.LoadingVoiceData = true;
    string[] sourceArray = (string[]) null;
    try
    {
      if (this.SelectVAFileDialog != null)
      {
        List<string> stringList = this.SelectVAFileDialog(SelectionMode.Extended);
        if (stringList != null && stringList.Count > 0)
          sourceArray = stringList.ToArray();
      }
      else
      {
        AcpOpenFileDialog acpOpenFileDialog = new AcpOpenFileDialog();
        if (((FrameworkElement) sender).DataContext == FeatureManager.GetFeature(4228))
          acpOpenFileDialog.Filter = "Certificate files (*.*)|*.*";
        else
          acpOpenFileDialog.Filter = "Motorola Voice Announcement files (*.mva)|*.mva";
        acpOpenFileDialog.MultiSelect = true;
        bool? nullable = acpOpenFileDialog.ShowDialog();
        bool flag = true;
        if (nullable.GetValueOrDefault() == flag & nullable.HasValue)
          sourceArray = acpOpenFileDialog.FileNames;
      }
      if (sourceArray == null || sourceArray.Length == 0)
        return;
      this.voiceAnnFiles = new string[sourceArray.Length];
      Array.Copy((Array) sourceArray, (Array) this.voiceAnnFiles, sourceArray.Length);
      this.AddMultQty = this.voiceAnnFiles.Length;
      this.RaiseEvent(new RoutedEventArgs(AcpVoiceAnnRecNavToolBar.MultiAddClickEvent));
      base.OnRecNavBtnAddMultipleClick(sender, e);
    }
    finally
    {
      AppInfoManager.LoadingVoiceData = false;
    }
  }

  protected override bool CanSelectAddMode
  {
    get
    {
      this.RecordTypeToAdd = 0;
      return false;
    }
  }
}
