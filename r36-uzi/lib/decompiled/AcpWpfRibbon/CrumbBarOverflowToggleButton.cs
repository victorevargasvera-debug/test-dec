// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfRibbon.CrumbBarOverflowToggleButton
// Assembly: AcpWpfRibbon, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 45A745B5-88C3-40EE-B1E5-8DBA2EACD529
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfRibbon.dll

using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

#nullable disable
namespace DevComponents.WpfRibbon;

[DesignTimeVisible(false)]
public class CrumbBarOverflowToggleButton : ToggleButton
{
  public static readonly DependencyProperty IsPressedStateProperty = DependencyProperty.Register(nameof (IsPressedState), typeof (bool), typeof (CrumbBarOverflowToggleButton), (PropertyMetadata) new UIPropertyMetadata((object) false));
  public static readonly DependencyProperty IsMouseOverStateProperty = DependencyProperty.Register(nameof (IsMouseOverState), typeof (bool), typeof (CrumbBarOverflowToggleButton), (PropertyMetadata) new FrameworkPropertyMetadata((object) false, FrameworkPropertyMetadataOptions.AffectsRender));
  private bool _IsLeftMouseButtonDown;
  private bool _MouseOverInternal;

  public bool IsPressedState
  {
    get => (bool) this.GetValue(CrumbBarOverflowToggleButton.IsPressedStateProperty);
    set => this.SetValue(CrumbBarOverflowToggleButton.IsPressedStateProperty, (object) value);
  }

  public bool IsMouseOverState
  {
    get => (bool) this.GetValue(CrumbBarOverflowToggleButton.IsMouseOverStateProperty);
    set => this.SetValue(CrumbBarOverflowToggleButton.IsMouseOverStateProperty, (object) value);
  }

  private void UpdatePressed()
  {
    this.IsPressedState = this.IsChecked.Value || this._IsLeftMouseButtonDown;
  }

  protected override void OnChecked(RoutedEventArgs e)
  {
    this.UpdateIsMouseOverState();
    this.UpdatePressed();
    base.OnChecked(e);
  }

  protected override void OnUnchecked(RoutedEventArgs e)
  {
    this.UpdateIsMouseOverState();
    this.UpdatePressed();
    base.OnUnchecked(e);
  }

  private bool IsLeftMouseButtonDown
  {
    get => this._IsLeftMouseButtonDown;
    set
    {
      if (this._IsLeftMouseButtonDown == value)
        return;
      this._IsLeftMouseButtonDown = value;
      this.UpdatePressed();
    }
  }

  protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
  {
    this.IsLeftMouseButtonDown = true;
    if (this.IsChecked.Value)
    {
      this.IsChecked = new bool?(false);
      this.ClickMode = ClickMode.Hover;
      base.OnMouseLeftButtonDown(e);
      this.ClickMode = ClickMode.Press;
      e.Handled = true;
    }
    else
      base.OnMouseLeftButtonDown(e);
  }

  protected override void OnMouseUp(MouseButtonEventArgs e)
  {
    if (e.ChangedButton == MouseButton.Left)
      this.IsLeftMouseButtonDown = false;
    base.OnMouseUp(e);
  }

  protected override void OnMouseEnter(MouseEventArgs e)
  {
    if (new Rect(this.RenderSize).Contains(e.GetPosition((IInputElement) this)))
      this.MouseOverInternal = true;
    base.OnMouseEnter(e);
  }

  protected override void OnMouseMove(MouseEventArgs e)
  {
    this.MouseOverInternal = new Rect(this.RenderSize).Contains(e.GetPosition((IInputElement) this));
    base.OnMouseMove(e);
  }

  private bool MouseOverInternal
  {
    get => this._MouseOverInternal;
    set
    {
      if (this._MouseOverInternal == value)
        return;
      this._MouseOverInternal = value;
      this.UpdateIsMouseOverState();
      CrumbBar tree = this.GetTree();
      if (tree == null || !tree.IsMenuMode || this.IsChecked.Value)
        return;
      this.IsChecked = new bool?(true);
    }
  }

  private CrumbBar GetTree() => this.TemplatedParent as CrumbBar;

  protected override void OnMouseLeave(MouseEventArgs e)
  {
    this.MouseOverInternal = false;
    base.OnMouseLeave(e);
  }

  private void UpdateIsMouseOverState()
  {
    this.IsMouseOverState = this._MouseOverInternal | this.IsChecked.Value;
  }
}
