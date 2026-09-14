// Decompiled with JetBrains decompiler
// Type: AcpUI.AcpComboBox
// Assembly: AcpUI, Version=23.1.0.32, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: DC7F6A15-37A6-4183-BF9F-09213F636FB6
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpUI.dll

using AcpBusinessLayer;
using AcpCommonLib;
using AcpCommonResources;
using AcpUILib;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

#nullable disable
namespace AcpUI;

public class AcpComboBox : 
  ComboBox,
  IAcpUICtrlBase,
  IAcpUIValueCtrlBase<string>,
  IAcpUIParentCtrlBase,
  IAcpUIChildCtrlBase,
  IAcpUICommon
{
  public static readonly DependencyProperty IsAcpValidProperty = DependencyProperty.Register(nameof (IsAcpValid), typeof (bool), typeof (AcpComboBox), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
  public static readonly DependencyProperty IsAcpApplicableProperty = DependencyProperty.Register(nameof (IsAcpApplicable), typeof (bool), typeof (AcpComboBox), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
  public static readonly DependencyProperty IsAcpEditableProperty = DependencyProperty.Register(nameof (IsAcpEditable), typeof (bool), typeof (AcpComboBox), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
  public static readonly DependencyProperty IsAcpVisibleProperty = DependencyProperty.Register(nameof (IsAcpVisible), typeof (bool), typeof (AcpComboBox), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
  public static readonly DependencyProperty MyLabelCtrlProperty = DependencyProperty.RegisterAttached(nameof (MyLabelCtrl), typeof (IAcpUIChildCtrlBase), typeof (AcpComboBox), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender));
  public static readonly DependencyProperty MyCopyButtonProperty = DependencyProperty.RegisterAttached(nameof (MyCopyButtonCtrl), typeof (IAcpUIChildCtrlBase), typeof (AcpComboBox), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender));
  public static readonly DependencyProperty MyBLObjectProperty = DependencyProperty.RegisterAttached(nameof (MyBLObject), typeof (AcpFieldBase), typeof (AcpComboBox), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender));
  public static readonly DependencyProperty AreValuesEqualProperty = DependencyProperty.Register(nameof (AreValuesEqual), typeof (bool), typeof (AcpComboBox), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsRender));
  public static readonly DependencyProperty MyExpanderProperty = DependencyProperty.RegisterAttached(nameof (MyExpander), typeof (Expander), typeof (AcpComboBox), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender));
  public static readonly DependencyProperty MyParentCtrlProperty = DependencyProperty.RegisterAttached(nameof (MyParentCtrl), typeof (IAcpUIParentCtrlBase), typeof (AcpComboBox), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender));

  public string Value
  {
    get => (string) this.SelectedValue;
    set => this.SelectedValue = (object) value;
  }

  public bool IsAcpValid
  {
    get => (bool) this.GetValue(AcpComboBox.IsAcpValidProperty);
    set => this.SetValue(AcpComboBox.IsAcpValidProperty, (object) value);
  }

  public bool IsAcpApplicable
  {
    get => (bool) this.GetValue(AcpComboBox.IsAcpApplicableProperty);
    set => this.SetValue(AcpComboBox.IsAcpApplicableProperty, (object) value);
  }

  public bool IsAcpEditable
  {
    get => (bool) this.GetValue(AcpComboBox.IsAcpEditableProperty);
    set => this.SetValue(AcpComboBox.IsAcpEditableProperty, (object) value);
  }

  public bool IsAcpVisible
  {
    get => (bool) this.GetValue(AcpComboBox.IsAcpVisibleProperty);
    set => this.SetValue(AcpComboBox.IsAcpVisibleProperty, (object) value);
  }

  public IAcpUIChildCtrlBase MyLabelCtrl
  {
    get => (IAcpUIChildCtrlBase) this.GetValue(AcpComboBox.MyLabelCtrlProperty);
    set => this.SetValue(AcpComboBox.MyLabelCtrlProperty, (object) value);
  }

  public IAcpUIChildCtrlBase MyCopyButtonCtrl
  {
    get => (IAcpUIChildCtrlBase) this.GetValue(AcpComboBox.MyCopyButtonProperty);
    set => this.SetValue(AcpComboBox.MyCopyButtonProperty, (object) value);
  }

  public AcpFieldBase MyBLObject
  {
    get => (AcpFieldBase) this.GetValue(AcpComboBox.MyBLObjectProperty);
    set => this.SetValue(AcpComboBox.MyBLObjectProperty, (object) value);
  }

  public bool AreValuesEqual
  {
    get => (bool) this.GetValue(AcpComboBox.AreValuesEqualProperty);
    set => this.SetValue(AcpComboBox.AreValuesEqualProperty, (object) value);
  }

  public Expander MyExpander
  {
    get => (Expander) this.GetValue(AcpComboBox.MyExpanderProperty);
    set => this.SetValue(AcpComboBox.MyExpanderProperty, (object) value);
  }

  public IAcpUIParentCtrlBase MyParentCtrl
  {
    get => (IAcpUIParentCtrlBase) this.GetValue(AcpComboBox.MyParentCtrlProperty);
    set => this.SetValue(AcpComboBox.MyParentCtrlProperty, (object) value);
  }

  protected override void OnMouseRightButtonUp(MouseButtonEventArgs e)
  {
    AcpComboBox source = (AcpComboBox) e.Source;
    if (source != null && source.MyBLObject is AcpRecRefField myBlObject && AppInfoManager.AppMode != ApplicationMode.CodeplugComparisonMode)
    {
      ContextMenu contextMenu = new ContextMenu();
      MenuItem newItem = new MenuItem();
      newItem.Header = (object) AcpResources.GoToItem_Id;
      newItem.Click += new RoutedEventHandler(this.OnContextMenuItemGoto);
      contextMenu.Items.Add((object) newItem);
      this.ContextMenu = contextMenu;
      bool flag = true;
      if (myBlObject.UIValue == myBlObject.InvalidText)
        flag = false;
      else if (myBlObject.Value == -1)
        flag = false;
      else if (myBlObject.PrependValues != null)
      {
        foreach (int prependValue in myBlObject.PrependValues)
        {
          if (prependValue == myBlObject.Value)
            flag = false;
        }
      }
      newItem.IsEnabled = flag;
    }
    base.OnMouseRightButtonUp(e);
  }

  protected virtual void OnContextMenuItemGoto(object sender, RoutedEventArgs e)
  {
    AcpRecRefField acpRecRefField = (AcpRecRefField) null;
    if (sender is MenuItem menuItem)
    {
      AcpComboBox placementTarget = (AcpComboBox) ((ContextMenu) menuItem.Parent).PlacementTarget;
      if (placementTarget != null && placementTarget.MyBLObject != null)
        acpRecRefField = (AcpRecRefField) placementTarget.MyBLObject;
    }
    if (acpRecRefField == null)
      return;
    FeatureNode featureNode = acpRecRefField.ReferencedNode;
    if (featureNode == null)
      return;
    Recordset parent = featureNode.Parent as Recordset;
    AcpKeyField keyField = featureNode.KeyField;
    if (parent.IsEmbeddedRecset && parent.Contains(featureNode))
    {
      featureNode = parent.ParentSection.Parent as FeatureNode;
      parent = featureNode.Parent as Recordset;
    }
    FieldInfo info = new FieldInfo((IAcpField) keyField);
    if (!parent.Contains(featureNode))
      return;
    AcpUI.Common.Utility.FieldReportSelectionChanged(sender, info);
  }

  public AcpComboBox() => this.VerticalAlignment = VerticalAlignment.Center;

  ~AcpComboBox()
  {
  }

  protected override void OnDropDownOpened(EventArgs e)
  {
    if (this.MyBLObject is AcpListField myBlObject)
      myBlObject.CalculateItemsValidity();
    base.OnDropDownOpened(e);
  }

  protected override void OnKeyDown(KeyEventArgs e)
  {
    if (e.Key == Key.Tab)
    {
      base.OnKeyDown(e);
    }
    else
    {
      int index1 = this.SelectedIndex + 1;
      if (this.MyBLObject is AcpListField myBlObject)
      {
        if (e.Key == Key.Up)
        {
          int index2 = this.SelectedIndex - 1;
          for (int index3 = 0; index2 >= index3; --index2)
          {
            if (myBlObject.Items[index2].ItemVisibility)
            {
              this.SelectedIndex = index2;
              break;
            }
          }
        }
        else if (e.Key == Key.Down)
        {
          int index4 = this.SelectedIndex + 1;
          for (int index5 = myBlObject.Items.Count - 1; index4 <= index5; ++index4)
          {
            if (myBlObject.Items[index4].ItemVisibility)
            {
              this.SelectedIndex = index4;
              break;
            }
          }
        }
        else if (e.Key >= Key.D0 && e.Key <= Key.Z || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
        {
          string str = e.Key.ToString();
          if (e.Key >= Key.D0 && e.Key <= Key.D9)
            str = str.Substring(1);
          if (e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
            str = str.Substring(6);
          for (int index6 = 0; index6 < myBlObject.Items.Count; ++index6)
          {
            if (index1 >= myBlObject.Items.Count)
              index1 = 0;
            if (myBlObject.Items[index1].ItemVisibility && myBlObject.Items[index1].ToString().ToUpper().StartsWith(str))
            {
              this.SelectedIndex = index1;
              break;
            }
            ++index1;
          }
        }
        else if (e.Key == Key.Home)
        {
          for (int index7 = 0; index7 < myBlObject.Items.Count; ++index7)
          {
            if (myBlObject.Items[index7].ItemVisibility)
            {
              this.SelectedIndex = index7;
              break;
            }
          }
        }
        else if (e.Key == Key.End)
        {
          for (int index8 = myBlObject.Items.Count - 1; index8 >= 0; --index8)
          {
            if (myBlObject.Items[index8].ItemVisibility)
            {
              this.SelectedIndex = index8;
              break;
            }
          }
        }
      }
      e.Handled = true;
    }
  }
}
