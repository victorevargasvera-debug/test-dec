// Decompiled with JetBrains decompiler
// Type: AcpUI.Common.Utility
// Assembly: AcpUI, Version=23.1.0.32, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: DC7F6A15-37A6-4183-BF9F-09213F636FB6
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpUI.dll

using AcpBusinessLayer;
using AcpCommonLib;
using AcpCommonLib.FieldsReport;
using AcpCommonLib.UndoRedo;
using AcpCommonResources;
using Infragistics.Windows.DataPresenter.Events;
using Infragistics.Windows.Editors;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;

#nullable disable
namespace AcpUI.Common;

public static class Utility
{
  private static IAcpFeatureNode currentRecord;

  public static void RestoreAllFields(AcpPageFeature page)
  {
    ContainerTask task = (ContainerTask) null;
    if (page.MyBaseRecNavToolbar != null && page.MyBaseRecNavToolbar.TableMode)
    {
      task = new ContainerTask(AcpResources.Restore_All);
      Utility.RestoreRecordset((IAcpRecordset) page.DataContext, task);
    }
    else
    {
      IAcpRecordset dataContext = (IAcpRecordset) page.DataContext;
      CollectionView defaultView = (CollectionView) CollectionViewSource.GetDefaultView(page.DataContext);
      if (defaultView.CurrentPosition >= 0)
      {
        int currentPosition = defaultView.CurrentPosition;
        IAcpFeatureNode activeDocRecord = dataContext[currentPosition];
        if (activeDocRecord != null)
        {
          activeDocRecord.CalculateVisibility(true);
          activeDocRecord.CalculateEditability(true);
          task = new ContainerTask(AcpResources.Restore_All);
          Utility.RestoreSections(activeDocRecord, task);
        }
      }
    }
    if (task == null)
      return;
    UndoManager.AddTask((UndoableTask) task);
  }

  public static void RestoreAllInvalidFields()
  {
    ContainerTask containerTask = (ContainerTask) null;
    if (AppInfoManager.InvalidFieldsReport != null && AppInfoManager.InvalidFieldsReport.UiHasFields)
    {
      Mouse.OverrideCursor = Cursors.Wait;
      List<IAcpField> acpFieldList = new List<IAcpField>();
      foreach (FieldsReportInfo uiField in AppInfoManager.InvalidFieldsReport.UiFields)
      {
        if (uiField.Field != null && uiField.FieldType == FieldInfoType.Field)
        {
          IAcpField field = uiField.Field;
          acpFieldList.Add(field);
        }
      }
      containerTask = new ContainerTask("Restore All Invalids");
      bool flag = false;
      for (int index = 0; index < acpFieldList.Count; ++index)
      {
        IAcpField acpField = acpFieldList[index];
        if (((AcpFieldBase) acpField).AllowsRestore())
        {
          flag = true;
          ((AcpFieldBase) acpField).ResetToDefaultWithUndo(containerTask);
        }
      }
      if (flag)
        AppInfoManager.InvalidFieldsReport.FieldsReportChanged = true;
    }
    if (containerTask != null && containerTask.Tasks.Count > 0)
      UndoManager.AddTask((UndoableTask) containerTask);
    else if (!UndoManager.MarkForUndo)
      UndoManager.StartUndoRedo();
    Mouse.OverrideCursor = (Cursor) null;
  }

  private static void RestoreSections(IAcpFeatureNode activeDocRecord, ContainerTask task)
  {
    foreach (IAcpFeatureSection acpFeatureSection in activeDocRecord.FeatureSectionsCollectionByOrder)
    {
      foreach (AcpFieldBase acpFieldBase in acpFeatureSection.FieldsCollectionByOrder)
      {
        if (acpFieldBase.AllowsRestore())
          acpFieldBase.ResetToDefaultWithUndo(task);
      }
      if (acpFeatureSection.HasEmbeddedRecset)
      {
        IAcpRecordset embeddedRecset = acpFeatureSection.EmbeddedRecset;
        if (embeddedRecset != null && !embeddedRecset.HiddenStatic)
          Utility.RestoreRecordset(embeddedRecset, task);
      }
    }
  }

  private static void RestoreRecordset(IAcpRecordset activeDocRecSet, ContainerTask task)
  {
    activeDocRecSet.CalculateVisibility(true);
    activeDocRecSet.CalculateEditability(true);
    int count = activeDocRecSet.Count;
    for (int index = 0; index < count; ++index)
      Utility.RestoreSections(activeDocRecSet[index], task);
  }

  public static event CpgFieldNameEventHandler CpgFieldNameMouseClickEvent;

  public static event CpgFieldNameEventHandler CpgFieldNameMouseDoubleClickEvent;

  public static event RecordNavigationEventHandler RecordNavigationEvent;

  public static event RecordOperationEventHandler RecordOperationEvent;

  public static event RecordSelectionEventHandler RecordSelectionEvent;

  public static event RecordActivatedEventHandler RecordActivatedEvent;

  public static event FieldReportItemSelectionEventHandler FieldReportItemSelectionEvent;

  public static event FieldReportUpdatedEventHandler FieldsReportUpdatedEvent;

  public static event DockWindowVisibilityChangedEventHandler DockWindowVisibilityChangedEvent;

  public static event DockWindowAutoRiseChangedEventHandler DockWindowAutoRiseChangedEvent;

  public static event ThemeChangedEventHandler ThemeChangedEvent;

  public static void GetFieldHelpText(object sender)
  {
    if (Utility.CpgFieldNameMouseClickEvent == null)
      return;
    Utility.CpgFieldNameMouseClickEvent(sender, new CpgFieldNameMouseEventArgs());
  }

  public static void OnThemeChanged(object sender, string args)
  {
    if (Utility.ThemeChangedEvent == null)
      return;
    Utility.ThemeChangedEvent(sender, new ThemeChangedEventArgs(args));
  }

  internal static void NavigateFieldHelpText(object sender)
  {
    if (Utility.CpgFieldNameMouseDoubleClickEvent == null)
      return;
    Utility.CpgFieldNameMouseDoubleClickEvent(sender, new CpgFieldNameMouseEventArgs());
  }

  internal static void SetCurrentNavigation(object sender, IAcpFeatureNode rec)
  {
    Utility.currentRecord = rec;
    if (Utility.RecordNavigationEvent == null)
      return;
    Utility.RecordNavigationEvent(sender, new RecordNavigationEventArgs(rec));
  }

  internal static void SetCurrentOperation(
    object sender,
    IAcpFeatureNode rec,
    int nOperation,
    int index)
  {
    Utility.currentRecord = rec;
    if (Utility.RecordOperationEvent == null)
      return;
    Utility.RecordOperationEvent(sender, new RecordOperationEventArgs(rec, nOperation, index));
  }

  internal static void RecordSelectionChanged(object sender)
  {
    if (Utility.RecordSelectionEvent == null)
      return;
    Utility.RecordSelectionEvent(sender, new RecordSelectionEventArgs());
  }

  internal static void RecordActivated(object sender, RecordActivatedEventArgs e)
  {
    if (Utility.RecordSelectionEvent == null)
      return;
    Utility.RecordActivatedEvent(sender, e);
  }

  internal static void FieldReportSelectionChanged(object sender, FieldInfo info)
  {
    if (Utility.FieldReportItemSelectionEvent == null)
      return;
    Utility.FieldReportItemSelectionEvent(sender, new FieldItemSelectionEventArgs(info));
  }

  public static void FieldsReportChanged(object sender, FieldReportType fldRptType)
  {
    if (Utility.FieldsReportUpdatedEvent == null)
      return;
    Utility.FieldsReportUpdatedEvent(sender, new FieldReportUpdatedEventArgs(fldRptType));
  }

  public static void DockWindowVisibilityChanged(object sender, bool isVisible)
  {
    if (Utility.DockWindowVisibilityChangedEvent == null)
      return;
    Utility.DockWindowVisibilityChangedEvent(sender, new DockWindowVisibilityChangedEventArgs(isVisible));
  }

  internal static void DockWindowAutoRiseChanged(object sender, bool isAutoRiseEnabled)
  {
    if (Utility.DockWindowAutoRiseChangedEvent == null)
      return;
    Utility.DockWindowAutoRiseChangedEvent(sender, new DockWindowAutoRiseChangedEventArgs(isAutoRiseEnabled));
  }

  public static void SaveFieldWithFocus()
  {
    if (!(Keyboard.FocusedElement is FrameworkElement focusedElement))
      return;
    BindingExpression bindingExpression;
    if (focusedElement.TemplatedParent is AcpTableTextBoxBase)
    {
      if (focusedElement is XamMaskedEditor xamMaskedEditor)
        ((ValueEditor) xamMaskedEditor).EndEditMode(true, false);
      bindingExpression = ((FrameworkElement) ((FrameworkElement) xamMaskedEditor).TemplatedParent).GetBindingExpression(TextBox.TextProperty);
    }
    else if (focusedElement.TemplatedParent is XamMaskedEditor)
    {
      XamMaskedEditor templatedParent1 = (XamMaskedEditor) focusedElement.TemplatedParent;
      ((ValueEditor) templatedParent1).EndEditMode(true, false);
      FrameworkElement templatedParent2 = (FrameworkElement) ((FrameworkElement) templatedParent1).TemplatedParent;
      bindingExpression = templatedParent2 == null ? (BindingExpression) null : templatedParent2.GetBindingExpression(TextBox.TextProperty);
    }
    else
    {
      switch (focusedElement)
      {
        case RepeatButton _:
          bindingExpression = !(focusedElement.PredictFocus(FocusNavigationDirection.Left) is FrameworkElement frameworkElement) ? (BindingExpression) null : frameworkElement.GetBindingExpression(TextBox.TextProperty);
          break;
        case TextBox _:
          bindingExpression = focusedElement.GetBindingExpression(TextBox.TextProperty);
          break;
        case AcpTextBoxDecHex _:
          bindingExpression = focusedElement.GetBindingExpression(AcpTextBoxDecHex.TextProperty);
          break;
        case AcpTextBoxSpinner _:
          bindingExpression = focusedElement.GetBindingExpression(AcpTextBoxSpinner.TextProperty);
          break;
        case AcpTextBoxSpinnerDecHex _:
          bindingExpression = focusedElement.GetBindingExpression(AcpTextBoxSpinnerDecHex.TextProperty);
          break;
        case PasswordBox passwordBox:
          if (focusedElement.Parent is Grid parent1 && parent1.Parent is AcpPasswordEyeBox parent2)
            parent2.PIN = passwordBox.Password;
          if (focusedElement.Parent is AcpPasswordBox parent3)
            parent3.PIN = parent3.Value;
          bindingExpression = (BindingExpression) null;
          break;
        default:
          bindingExpression = (BindingExpression) null;
          break;
      }
    }
    bindingExpression?.UpdateSource();
  }

  public static void SetDirection(FrameworkElement sender)
  {
    if (CultureInfo.CurrentUICulture.TextInfo.IsRightToLeft)
      sender.FlowDirection = FlowDirection.RightToLeft;
    else
      sender.FlowDirection = FlowDirection.LeftToRight;
  }

  public static string FilterArabicDiacritics(string textDiacritics)
  {
    if (string.IsNullOrEmpty(textDiacritics))
      return string.Empty;
    string empty = string.Empty;
    foreach (char textDiacritic in textDiacritics)
    {
      if ((textDiacritic < 'ؐ' || textDiacritic > 'ؚ') && (textDiacritic < 'ً' || textDiacritic > 'ٟ') && textDiacritic != 'ٰ' && (textDiacritic < 'ۖ' || textDiacritic > 'ۤ') && (textDiacritic < 'ۧ' || textDiacritic > 'ۭ') && (textDiacritic < 'ﹰ' || textDiacritic > 'ﹿ'))
        empty += textDiacritic.ToString();
    }
    return empty;
  }
}
