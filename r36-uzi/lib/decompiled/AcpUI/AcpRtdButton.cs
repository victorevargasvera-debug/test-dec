// Decompiled with JetBrains decompiler
// Type: AcpUI.AcpRtdButton
// Assembly: AcpUI, Version=23.1.0.32, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: DC7F6A15-37A6-4183-BF9F-09213F636FB6
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpUI.dll

using AcpCommonLib;
using AcpCommonResources;
using AcpUILib;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

#nullable disable
namespace AcpUI;

public class AcpRtdButton : Button, IAcpUICtrlBase, IAcpUIChildCtrlBase
{
  public static readonly DependencyProperty IsAcpValidProperty = DependencyProperty.Register(nameof (IsAcpValid), typeof (bool), typeof (AcpRtdButton), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
  public static readonly DependencyProperty IsAcpApplicableProperty = DependencyProperty.Register(nameof (IsAcpApplicable), typeof (bool), typeof (AcpRtdButton), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
  public static readonly DependencyProperty IsAcpEditableProperty = DependencyProperty.Register(nameof (IsAcpEditable), typeof (bool), typeof (AcpRtdButton), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
  public static readonly DependencyProperty IsAcpVisibleProperty = DependencyProperty.Register(nameof (IsAcpVisible), typeof (bool), typeof (AcpRtdButton), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
  public static readonly DependencyProperty MyParentCtrlProperty = DependencyProperty.RegisterAttached(nameof (MyParentCtrl), typeof (IAcpUIParentCtrlBase), typeof (AcpRtdButton), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender));

  public bool IsAcpValid
  {
    get => (bool) this.GetValue(AcpRtdButton.IsAcpValidProperty);
    set => this.SetValue(AcpRtdButton.IsAcpValidProperty, (object) value);
  }

  public bool IsAcpApplicable
  {
    get => (bool) this.GetValue(AcpRtdButton.IsAcpApplicableProperty);
    set => this.SetValue(AcpRtdButton.IsAcpApplicableProperty, (object) value);
  }

  public bool IsAcpEditable
  {
    get => (bool) this.GetValue(AcpRtdButton.IsAcpEditableProperty);
    set => this.SetValue(AcpRtdButton.IsAcpEditableProperty, (object) value);
  }

  public bool IsAcpVisible
  {
    get => (bool) this.GetValue(AcpRtdButton.IsAcpVisibleProperty);
    set => this.SetValue(AcpRtdButton.IsAcpVisibleProperty, (object) value);
  }

  public IAcpUIParentCtrlBase MyParentCtrl
  {
    get => (IAcpUIParentCtrlBase) this.GetValue(AcpRtdButton.MyParentCtrlProperty);
    set => this.SetValue(AcpRtdButton.MyParentCtrlProperty, (object) value);
  }

  internal void AcpRtdButton_Click(object sender, RoutedEventArgs e)
  {
    this.OnRtdButtonclick(sender, e);
  }

  internal void AcpRtdButton_MouseDoubleClick(object sender, RoutedEventArgs e)
  {
    this.OnRtdButtonclick(sender, e);
  }

  internal void OnRtdButtonclick(object sender, RoutedEventArgs e)
  {
    if (this.MyParentCtrl != null && this.MyParentCtrl.MyBLObject != null)
    {
      this.MyParentCtrl.MyBLObject.ResetToDefaultWithUndo();
      e.Handled = true;
    }
    else
    {
      if (this.DataContext == null || !(this.DataContext is FieldInfo) || ((FieldInfo) this.DataContext).Field == null)
        return;
      ((FieldInfo) this.DataContext).Field.ResetToDefaultWithUndo();
      AppInfoManager.InvalidFieldsReport.FieldsReportChanged = true;
      e.Handled = true;
    }
  }

  public AcpRtdButton()
  {
    this.Loaded += new RoutedEventHandler(this.AcpRtdButton_Loaded);
    this.Unloaded += new RoutedEventHandler(this.AcpRtdButton_Unloaded);
    BitmapImage bitmapImage = new BitmapImage();
    bitmapImage.BeginInit();
    bitmapImage.UriSource = new Uri("/AcpUI;Component/icons/RestoreToDefault.png", UriKind.RelativeOrAbsolute);
    bitmapImage.DecodePixelWidth = 17;
    bitmapImage.EndInit();
    Image image = new Image();
    image.Source = (ImageSource) bitmapImage;
    image.Width = 17.0;
    this.Content = (object) image;
    this.ToolTip = (object) AcpResources.Restore_To_Default_Value;
    this.Width = 40.0;
    this.Margin = new Thickness(10.0, 0.0, 10.0, 0.0);
  }

  private void AcpRtdButton_Loaded(object sender, RoutedEventArgs e)
  {
    this.Click += new RoutedEventHandler(this.AcpRtdButton_Click);
    this.MouseDoubleClick += new MouseButtonEventHandler(this.AcpRtdButton_MouseDoubleClick);
  }

  private void AcpRtdButton_Unloaded(object sender, RoutedEventArgs e)
  {
    this.Click -= new RoutedEventHandler(this.AcpRtdButton_Click);
    this.MouseDoubleClick -= new MouseButtonEventHandler(this.AcpRtdButton_MouseDoubleClick);
  }
}
