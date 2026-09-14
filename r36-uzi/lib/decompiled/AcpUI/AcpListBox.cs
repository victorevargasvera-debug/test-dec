// Decompiled with JetBrains decompiler
// Type: AcpUI.AcpListBox
// Assembly: AcpUI, Version=23.1.0.32, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: DC7F6A15-37A6-4183-BF9F-09213F636FB6
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpUI.dll

using AcpBusinessLayer;
using AcpUILib;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

#nullable disable
namespace AcpUI;

public class AcpListBox : 
  ListBox,
  IAcpUICtrlBase,
  IAcpUIValueCtrlBase<string>,
  IAcpUIParentCtrlBase,
  IAcpUIChildCtrlBase,
  IAcpUICommon
{
  public static readonly DependencyProperty IsAcpValidProperty = DependencyProperty.Register(nameof (IsAcpValid), typeof (bool), typeof (AcpListBox), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
  public static readonly DependencyProperty IsAcpApplicableProperty = DependencyProperty.Register(nameof (IsAcpApplicable), typeof (bool), typeof (AcpListBox), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
  public static readonly DependencyProperty IsAcpEditableProperty = DependencyProperty.Register(nameof (IsAcpEditable), typeof (bool), typeof (AcpListBox), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
  public static readonly DependencyProperty IsAcpVisibleProperty = DependencyProperty.Register(nameof (IsAcpVisible), typeof (bool), typeof (AcpListBox), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
  public static readonly DependencyProperty MyLabelCtrlProperty = DependencyProperty.RegisterAttached(nameof (MyLabelCtrl), typeof (IAcpUIChildCtrlBase), typeof (AcpListBox), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender));
  public static readonly DependencyProperty MyCopyButtonProperty = DependencyProperty.RegisterAttached(nameof (MyCopyButtonCtrl), typeof (IAcpUIChildCtrlBase), typeof (AcpListBox), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender));
  public static readonly DependencyProperty MyBLObjectProperty = DependencyProperty.RegisterAttached(nameof (MyBLObject), typeof (AcpFieldBase), typeof (AcpListBox), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender));
  public static readonly DependencyProperty AreValuesEqualProperty = DependencyProperty.Register(nameof (AreValuesEqual), typeof (bool), typeof (AcpListBox), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsRender));
  public static readonly DependencyProperty MyExpanderProperty = DependencyProperty.RegisterAttached(nameof (MyExpander), typeof (Expander), typeof (AcpListBox), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender));
  public static readonly DependencyProperty MyParentCtrlProperty = DependencyProperty.RegisterAttached(nameof (MyParentCtrl), typeof (IAcpUIParentCtrlBase), typeof (AcpListBox), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender));

  public string Value
  {
    get
    {
      return this.SelectedValue is ListBoxItem && ((ContentControl) this.SelectedValue).Content != null ? ((ContentControl) this.SelectedValue).Content.ToString() : (string) null;
    }
    set => this.SelectedValue = (object) value;
  }

  public bool IsAcpValid
  {
    get => (bool) this.GetValue(AcpListBox.IsAcpValidProperty);
    set => this.SetValue(AcpListBox.IsAcpValidProperty, (object) value);
  }

  public bool IsAcpApplicable
  {
    get => (bool) this.GetValue(AcpListBox.IsAcpApplicableProperty);
    set => this.SetValue(AcpListBox.IsAcpApplicableProperty, (object) value);
  }

  public bool IsAcpEditable
  {
    get => (bool) this.GetValue(AcpListBox.IsAcpEditableProperty);
    set => this.SetValue(AcpListBox.IsAcpEditableProperty, (object) value);
  }

  public bool IsAcpVisible
  {
    get => (bool) this.GetValue(AcpListBox.IsAcpVisibleProperty);
    set => this.SetValue(AcpListBox.IsAcpVisibleProperty, (object) value);
  }

  public IAcpUIChildCtrlBase MyLabelCtrl
  {
    get => (IAcpUIChildCtrlBase) this.GetValue(AcpListBox.MyLabelCtrlProperty);
    set => this.SetValue(AcpListBox.MyLabelCtrlProperty, (object) value);
  }

  public IAcpUIChildCtrlBase MyCopyButtonCtrl
  {
    get => (IAcpUIChildCtrlBase) this.GetValue(AcpListBox.MyCopyButtonProperty);
    set => this.SetValue(AcpListBox.MyCopyButtonProperty, (object) value);
  }

  public AcpFieldBase MyBLObject
  {
    get => (AcpFieldBase) this.GetValue(AcpListBox.MyBLObjectProperty);
    set => this.SetValue(AcpListBox.MyBLObjectProperty, (object) value);
  }

  public bool AreValuesEqual
  {
    get => (bool) this.GetValue(AcpListBox.AreValuesEqualProperty);
    set => this.SetValue(AcpListBox.AreValuesEqualProperty, (object) value);
  }

  public Expander MyExpander
  {
    get => (Expander) this.GetValue(AcpListBox.MyExpanderProperty);
    set => this.SetValue(AcpListBox.MyExpanderProperty, (object) value);
  }

  public IAcpUIParentCtrlBase MyParentCtrl
  {
    get => (IAcpUIParentCtrlBase) this.GetValue(AcpListBox.MyParentCtrlProperty);
    set => this.SetValue(AcpListBox.MyParentCtrlProperty, (object) value);
  }

  public AcpListBox()
  {
    this.Loaded += new RoutedEventHandler(this.AcpListBox_Loaded);
    this.Unloaded += new RoutedEventHandler(this.AcpListBox_Unloaded);
  }

  ~AcpListBox()
  {
  }

  private void AcpListBox_Loaded(object sender, RoutedEventArgs e)
  {
    this.KeyDown += new KeyEventHandler(this.AcpListBox_KeyDown);
  }

  private void AcpListBox_Unloaded(object sender, RoutedEventArgs e)
  {
    this.KeyDown -= new KeyEventHandler(this.AcpListBox_KeyDown);
  }

  private void AcpListBox_KeyDown(object sender, KeyEventArgs e)
  {
    AcpListBox acpListBox = sender as AcpListBox;
    int selectedIndex1 = acpListBox.SelectedIndex;
    AcpListField myBlObject = this.MyBLObject as AcpListField;
    int index1 = selectedIndex1 + 1;
    ObservableCollection<AcpBusinessLayer.ListItem> observableCollection = myBlObject == null ? (ObservableCollection<AcpBusinessLayer.ListItem>) this.ItemsSource : myBlObject.Items;
    if (observableCollection != null)
    {
      for (int index2 = 0; index2 < observableCollection.Count; ++index2)
      {
        if (index1 >= observableCollection.Count)
          index1 = 0;
        if (observableCollection[index1].ItemVisibility && observableCollection[index1].ToString().StartsWith(e.Key.ToString()))
        {
          acpListBox.SelectedIndex = index1;
          break;
        }
        ++index1;
      }
    }
    int selectedIndex2 = acpListBox.SelectedIndex;
    if (selectedIndex2 != -1)
    {
      acpListBox.ScrollIntoView(this.Items[selectedIndex2]);
      if (this.ItemContainerGenerator.ContainerFromIndex(selectedIndex2) is ListBoxItem listBoxItem)
        listBoxItem.Focus();
    }
    e.Handled = true;
  }
}
