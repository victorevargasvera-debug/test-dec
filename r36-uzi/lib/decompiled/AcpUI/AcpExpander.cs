// Decompiled with JetBrains decompiler
// Type: AcpUI.AcpExpander
// Assembly: AcpUI, Version=23.1.0.32, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: DC7F6A15-37A6-4183-BF9F-09213F636FB6
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpUI.dll

using AcpUI.Common;
using AcpUILib;
using System.Windows;
using System.Windows.Controls;

#nullable disable
namespace AcpUI;

public class AcpExpander : Expander, IAcpUICtrlBase
{
  public static readonly DependencyProperty IsAcpValidProperty = DependencyProperty.Register(nameof (IsAcpValid), typeof (bool), typeof (AcpExpander), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
  public static readonly DependencyProperty IsAcpApplicableProperty = DependencyProperty.Register(nameof (IsAcpApplicable), typeof (bool), typeof (AcpExpander), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
  public static readonly DependencyProperty IsAcpEditableProperty = DependencyProperty.Register(nameof (IsAcpEditable), typeof (bool), typeof (AcpExpander), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
  public static readonly DependencyProperty IsAcpVisibleProperty = DependencyProperty.Register(nameof (IsAcpVisible), typeof (bool), typeof (AcpExpander), (PropertyMetadata) new FrameworkPropertyMetadata((object) false, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
  public static readonly DependencyProperty ShowDiffIconProperty = DependencyProperty.RegisterAttached(nameof (ShowDiffIcon), typeof (bool), typeof (AcpExpander), (PropertyMetadata) new FrameworkPropertyMetadata((object) false, FrameworkPropertyMetadataOptions.AffectsRender));
  public static readonly DependencyProperty ExpToolbarProperty = DependencyProperty.Register(nameof (ExpToolbar), typeof (AcpRecNavToolbar), typeof (AcpExpander), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

  public bool IsAcpValid
  {
    get => (bool) this.GetValue(AcpExpander.IsAcpValidProperty);
    set => this.SetValue(AcpExpander.IsAcpValidProperty, (object) value);
  }

  public bool IsAcpApplicable
  {
    get => (bool) this.GetValue(AcpExpander.IsAcpApplicableProperty);
    set => this.SetValue(AcpExpander.IsAcpApplicableProperty, (object) value);
  }

  public bool IsAcpEditable
  {
    get => (bool) this.GetValue(AcpExpander.IsAcpEditableProperty);
    set => this.SetValue(AcpExpander.IsAcpEditableProperty, (object) value);
  }

  public bool IsAcpVisible
  {
    get => (bool) this.GetValue(AcpExpander.IsAcpVisibleProperty);
    set => this.SetValue(AcpExpander.IsAcpVisibleProperty, (object) value);
  }

  public bool ShowDiffIcon
  {
    get => (bool) this.GetValue(AcpExpander.ShowDiffIconProperty);
    set => this.SetValue(AcpExpander.ShowDiffIconProperty, (object) value);
  }

  public AcpRecNavToolbar ExpToolbar
  {
    get => (AcpRecNavToolbar) this.GetValue(AcpExpander.ExpToolbarProperty);
    set => this.SetValue(AcpExpander.ExpToolbarProperty, (object) value);
  }

  public AcpExpander() => this.IsExpanded = true;

  protected override void OnExpanded()
  {
    base.OnExpanded();
    Utility.SaveFieldWithFocus();
  }

  protected override void OnCollapsed() => base.OnCollapsed();
}
