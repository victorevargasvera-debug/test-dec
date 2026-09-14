// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfRibbon.ColorPickerButton
// Assembly: AcpWpfRibbon, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 45A745B5-88C3-40EE-B1E5-8DBA2EACD529
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfRibbon.dll

using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

#nullable disable
namespace DevComponents.WpfRibbon;

[DesignTimeVisible(false)]
public class ColorPickerButton : ButtonDropDown
{
  public static readonly DependencyProperty SelectedColorProperty = DependencyProperty.Register(nameof (SelectedColor), typeof (Color?), typeof (ColorPickerButton), (PropertyMetadata) new UIPropertyMetadata((object) null, new PropertyChangedCallback(ColorPickerButton.OnSelectedColorChanged)));
  public static readonly RoutedEvent SelectedColorChangedEvent = EventManager.RegisterRoutedEvent("SelectedColorChanged", RoutingStrategy.Bubble, typeof (RoutedEventHandler), typeof (ColorPickerButton));
  private static readonly DependencyPropertyKey SelectedColorBrushPropertyKey = DependencyProperty.RegisterReadOnly(nameof (SelectedColorBrush), typeof (Brush), typeof (ColorPickerButton), (PropertyMetadata) new UIPropertyMetadata((PropertyChangedCallback) null));
  public static readonly DependencyProperty SelectedColorBrushProperty = ColorPickerButton.SelectedColorBrushPropertyKey.DependencyProperty;
  public static readonly DependencyProperty ColorSwatchWidthProperty = DependencyProperty.Register(nameof (ColorSwatchWidth), typeof (double), typeof (ColorPickerButton), (PropertyMetadata) new UIPropertyMetadata((object) 14.0));
  public static readonly DependencyProperty ColorSwatchHeightProperty = DependencyProperty.Register(nameof (ColorSwatchHeight), typeof (double), typeof (ColorPickerButton), (PropertyMetadata) new UIPropertyMetadata((object) 14.0));
  public static readonly DependencyProperty ColorSwatchPositionProperty = DependencyProperty.Register(nameof (ColorSwatchPosition), typeof (eButtonImagePosition), typeof (ColorPickerButton), (PropertyMetadata) new UIPropertyMetadata((object) eButtonImagePosition.Left));
  public static readonly DependencyProperty ColorSwatchBorderProperty = DependencyProperty.Register(nameof (ColorSwatchBorder), typeof (bool), typeof (ColorPickerButton), (PropertyMetadata) new UIPropertyMetadata((object) true));

  private static void OnSelectedColorChanged(
    DependencyObject o,
    DependencyPropertyChangedEventArgs e)
  {
    if (!(o is ColorPickerButton colorPickerButton))
      return;
    colorPickerButton.OnSelectedColorChanged((Color?) e.OldValue, (Color?) e.NewValue);
  }

  protected virtual void OnSelectedColorChanged(Color? oldValue, Color? newValue)
  {
    this.SelectedColorBrush = newValue.HasValue ? (Brush) new SolidColorBrush(newValue.Value) : (Brush) null;
    if (this.IsPopupOpen)
      this.IsPopupOpen = false;
    ButtonDropDown.ExecuteCommand((ICommandSource) this);
    this.OnSelectedColorChanged();
  }

  public Color? SelectedColor
  {
    get => (Color?) this.GetValue(ColorPickerButton.SelectedColorProperty);
    set => this.SetValue(ColorPickerButton.SelectedColorProperty, (object) value);
  }

  public event RoutedEventHandler SelectedColorChanged
  {
    add => this.AddHandler(ColorPickerButton.SelectedColorChangedEvent, (Delegate) value);
    remove => this.RemoveHandler(ColorPickerButton.SelectedColorChangedEvent, (Delegate) value);
  }

  protected virtual void OnSelectedColorChanged()
  {
    this.RaiseEvent(new RoutedEventArgs(ColorPickerButton.SelectedColorChangedEvent));
  }

  public Brush SelectedColorBrush
  {
    get => (Brush) this.GetValue(ColorPickerButton.SelectedColorBrushProperty);
    internal set => this.SetValue(ColorPickerButton.SelectedColorBrushPropertyKey, (object) value);
  }

  public double ColorSwatchWidth
  {
    get => (double) this.GetValue(ColorPickerButton.ColorSwatchWidthProperty);
    set => this.SetValue(ColorPickerButton.ColorSwatchWidthProperty, (object) value);
  }

  public double ColorSwatchHeight
  {
    get => (double) this.GetValue(ColorPickerButton.ColorSwatchHeightProperty);
    set => this.SetValue(ColorPickerButton.ColorSwatchHeightProperty, (object) value);
  }

  public eButtonImagePosition ColorSwatchPosition
  {
    get => (eButtonImagePosition) this.GetValue(ColorPickerButton.ColorSwatchPositionProperty);
    set => this.SetValue(ColorPickerButton.ColorSwatchPositionProperty, (object) value);
  }

  public bool ColorSwatchBorder
  {
    get => (bool) this.GetValue(ColorPickerButton.ColorSwatchBorderProperty);
    set => this.SetValue(ColorPickerButton.ColorSwatchBorderProperty, (object) value);
  }

  static ColorPickerButton()
  {
    FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof (ColorPickerButton), (PropertyMetadata) new FrameworkPropertyMetadata((object) typeof (ColorPickerButton)));
  }
}
