// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfRibbon.ButtonCommandParameter
// Assembly: AcpWpfRibbon, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 45A745B5-88C3-40EE-B1E5-8DBA2EACD529
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfRibbon.dll

using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Threading;

#nullable disable
namespace DevComponents.WpfRibbon;

public class ButtonCommandParameter : DependencyObject, IButtonCommandParameter
{
  public static readonly DependencyProperty IsCheckedProperty = DependencyProperty.Register(nameof (IsChecked), typeof (bool), typeof (ButtonCommandParameter), (PropertyMetadata) new FrameworkPropertyMetadata((object) false));
  public static readonly DependencyProperty TagProperty = DependencyProperty.Register(nameof (Tag), typeof (object), typeof (ButtonCommandParameter), (PropertyMetadata) new FrameworkPropertyMetadata((PropertyChangedCallback) null));
  public static readonly DependencyProperty ValueChangedProperty = DependencyProperty.Register(nameof (ValueChanged), typeof (bool), typeof (ButtonCommandParameter), (PropertyMetadata) new FrameworkPropertyMetadata((object) false));

  public bool IsChecked
  {
    get
    {
      try
      {
        return !this.Dispatcher.CheckAccess() ? (bool) this.Dispatcher.Invoke(DispatcherPriority.Background, (Delegate) (_param1 => this.GetValue(ButtonCommandParameter.IsCheckedProperty)), (object) ButtonCommandParameter.IsCheckedProperty) : (bool) this.GetValue(ButtonCommandParameter.IsCheckedProperty);
      }
      catch
      {
        return (bool) ButtonCommandParameter.IsCheckedProperty.DefaultMetadata.DefaultValue;
      }
    }
    set
    {
      if (!this.Dispatcher.CheckAccess())
        this.Dispatcher.BeginInvoke(DispatcherPriority.Background, (Delegate) (_param1 => this.SetValue(ButtonCommandParameter.IsCheckedProperty, (object) value)), (object) value);
      else
        this.SetValue(ButtonCommandParameter.IsCheckedProperty, (object) value);
    }
  }

  [Bindable(true)]
  public object Tag
  {
    get
    {
      try
      {
        return !this.Dispatcher.CheckAccess() ? this.Dispatcher.Invoke(DispatcherPriority.Background, (Delegate) (_param1 => this.GetValue(ButtonCommandParameter.TagProperty)), (object) ButtonCommandParameter.TagProperty) : this.GetValue(ButtonCommandParameter.TagProperty);
      }
      catch
      {
        return ButtonCommandParameter.TagProperty.DefaultMetadata.DefaultValue;
      }
    }
    set
    {
      if (!this.Dispatcher.CheckAccess())
        this.Dispatcher.BeginInvoke(DispatcherPriority.Background, (Delegate) (_param1 => this.SetValue(ButtonCommandParameter.TagProperty, value)), value);
      else
        this.SetValue(ButtonCommandParameter.TagProperty, value);
    }
  }

  public bool ValueChanged
  {
    get
    {
      try
      {
        return !this.Dispatcher.CheckAccess() ? (bool) this.Dispatcher.Invoke(DispatcherPriority.Background, (Delegate) (_param1 => this.GetValue(ButtonCommandParameter.ValueChangedProperty)), (object) ButtonCommandParameter.ValueChangedProperty) : (bool) this.GetValue(ButtonCommandParameter.ValueChangedProperty);
      }
      catch
      {
        return (bool) ButtonCommandParameter.ValueChangedProperty.DefaultMetadata.DefaultValue;
      }
    }
    set
    {
      if (!this.Dispatcher.CheckAccess())
        this.Dispatcher.BeginInvoke(DispatcherPriority.Background, (Delegate) (_param1 => this.SetValue(ButtonCommandParameter.ValueChangedProperty, (object) value)), (object) value);
      else
        this.SetValue(ButtonCommandParameter.ValueChangedProperty, (object) value);
    }
  }
}
