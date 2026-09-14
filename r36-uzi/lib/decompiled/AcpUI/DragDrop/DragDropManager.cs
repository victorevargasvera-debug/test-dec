// Decompiled with JetBrains decompiler
// Type: AcpUI.DragDrop.DragDropManager
// Assembly: AcpUI, Version=23.1.0.32, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: DC7F6A15-37A6-4183-BF9F-09213F636FB6
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpUI.dll

using AcpCommonLib;
using AcpCommonLib.FieldsReport;
using AcpCommonResources;
using AcpSecurityLib;
using System;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

#nullable disable
namespace AcpUI.DragDrop;

public static class DragDropManager
{
  private static UIElement _draggedElt;
  private static bool _isMouseDown;
  private static Point _dragStartPoint;
  private static DropPreviewAdorner _overlayElt;
  private static bool bTreeIsNavigating = false;
  public static readonly DependencyProperty DragSourceAdvisorProperty = DependencyProperty.RegisterAttached("DragSourceAdvisor", typeof (IDragSourceAdvisor), typeof (DragDropManager), (PropertyMetadata) new FrameworkPropertyMetadata(new PropertyChangedCallback(DragDropManager.OnDragSourceAdvisorChanged)));
  public static readonly DependencyProperty DropTargetAdvisorProperty = DependencyProperty.RegisterAttached("DropTargetAdvisor", typeof (IDropTargetAdvisor), typeof (DragDropManager), (PropertyMetadata) new FrameworkPropertyMetadata(new PropertyChangedCallback(DragDropManager.OnDropTargetAdvisorChanged)));
  private static IAcpBatchOperation Process;

  public static void SetDragSourceAdvisor(DependencyObject dependencyObj, bool isSet)
  {
    dependencyObj.SetValue(DragDropManager.DragSourceAdvisorProperty, (object) isSet);
  }

  public static void SetDropTargetAdvisor(DependencyObject dependencyObj, bool isSet)
  {
    dependencyObj.SetValue(DragDropManager.DropTargetAdvisorProperty, (object) isSet);
  }

  public static IDragSourceAdvisor GetDragSourceAdvisor(DependencyObject dependencyObj)
  {
    return dependencyObj.GetValue(DragDropManager.DragSourceAdvisorProperty) as IDragSourceAdvisor;
  }

  public static IDropTargetAdvisor GetDropTargetAdvisor(DependencyObject dependencyObj)
  {
    return dependencyObj.GetValue(DragDropManager.DropTargetAdvisorProperty) as IDropTargetAdvisor;
  }

  private static void OnDragSourceAdvisorChanged(
    DependencyObject depObj,
    DependencyPropertyChangedEventArgs args)
  {
    UIElement uiElement = depObj as UIElement;
    if (args.NewValue != null && args.OldValue == null)
    {
      uiElement.PreviewMouseLeftButtonDown += new MouseButtonEventHandler(DragDropManager.DragSource_PreviewMouseLeftButtonDown);
      uiElement.PreviewMouseMove += new MouseEventHandler(DragDropManager.DragSource_PreviewMouseMove);
      uiElement.PreviewMouseUp += new MouseButtonEventHandler(DragDropManager.DragSource_PreviewMouseUp);
      (args.NewValue as IDragSourceAdvisor).SourceUI = uiElement;
    }
    else
    {
      if (args.NewValue != null || args.OldValue == null)
        return;
      uiElement.PreviewMouseLeftButtonDown -= new MouseButtonEventHandler(DragDropManager.DragSource_PreviewMouseLeftButtonDown);
      uiElement.PreviewMouseMove -= new MouseEventHandler(DragDropManager.DragSource_PreviewMouseMove);
      uiElement.PreviewMouseUp -= new MouseButtonEventHandler(DragDropManager.DragSource_PreviewMouseUp);
    }
  }

  public static void TreeNavigationStart()
  {
    DragDropManager.bTreeIsNavigating = true;
    DragDropManager._isMouseDown = false;
    Mouse.Capture((IInputElement) null);
    DragDropManager._draggedElt = (UIElement) null;
  }

  public static void TreeNavigationStop() => DragDropManager.bTreeIsNavigating = false;

  private static void DragSource_PreviewMouseUp(object sender, MouseButtonEventArgs e)
  {
    DragDropManager._isMouseDown = false;
    Mouse.Capture((IInputElement) null);
  }

  private static void OnDropTargetAdvisorChanged(
    DependencyObject depObj,
    DependencyPropertyChangedEventArgs args)
  {
    UIElement uiElement = depObj as UIElement;
    if (args.NewValue != null && args.OldValue == null)
    {
      uiElement.PreviewDragEnter += new DragEventHandler(DragDropManager.DropTarget_PreviewDragEnter);
      uiElement.PreviewDragOver += new DragEventHandler(DragDropManager.DropTarget_PreviewDragOver);
      uiElement.PreviewDragLeave += new DragEventHandler(DragDropManager.DropTarget_PreviewDragLeave);
      uiElement.PreviewDrop += new DragEventHandler(DragDropManager.DropTarget_PreviewDrop);
      uiElement.AllowDrop = true;
      (args.NewValue as IDropTargetAdvisor).TargetUI = uiElement;
    }
    else
    {
      if (args.NewValue != null || args.OldValue == null)
        return;
      uiElement.PreviewDragEnter -= new DragEventHandler(DragDropManager.DropTarget_PreviewDragEnter);
      uiElement.PreviewDragOver -= new DragEventHandler(DragDropManager.DropTarget_PreviewDragOver);
      uiElement.PreviewDragLeave -= new DragEventHandler(DragDropManager.DropTarget_PreviewDragLeave);
      uiElement.PreviewDrop -= new DragEventHandler(DragDropManager.DropTarget_PreviewDrop);
      uiElement.AllowDrop = false;
    }
  }

  private static void DropTarget_PreviewDrop(object sender, DragEventArgs e)
  {
    if (DragDropManager.UpdateEffects(sender, e))
    {
      IDropTargetAdvisor dropTargetAdvisor = DragDropManager.GetDropTargetAdvisor(sender as DependencyObject);
      Point position1 = e.GetPosition((IInputElement) (sender as UIElement));
      if (DragDropManager._overlayElt != null)
      {
        Point position2 = e.GetPosition((IInputElement) DragDropManager._overlayElt);
        position1.X -= position2.X;
        position1.Y -= position2.Y;
      }
      if (DragDropManager.IsDropPermitted())
      {
        dropTargetAdvisor.SetProcess(DragDropManager.Process);
        dropTargetAdvisor.OnDropCompleted(e.Data, position1, dropTargetAdvisor.ConsumerNode);
      }
      DragDropManager.RemovePreviewAdorner();
    }
    e.Handled = true;
  }

  private static void DropTarget_PreviewDragLeave(object sender, DragEventArgs e)
  {
    if (DragDropManager.UpdateEffects(sender, e))
      DragDropManager.RemovePreviewAdorner();
    e.Handled = true;
  }

  private static void DropTarget_PreviewDragOver(object sender, DragEventArgs e)
  {
    if (DragDropManager.UpdateEffects(sender, e))
    {
      Point position = e.GetPosition((IInputElement) (sender as UIElement));
      if (DragDropManager._overlayElt != null)
      {
        DragDropManager._overlayElt.Left = position.X;
        DragDropManager._overlayElt.Top = position.Y;
      }
    }
    e.Handled = true;
  }

  private static void DropTarget_PreviewDragEnter(object sender, DragEventArgs e)
  {
    if (DragDropManager.UpdateEffects(sender, e))
    {
      UIElement visualFeedback = DragDropManager.GetDropTargetAdvisor(sender as DependencyObject).GetVisualFeedback(e.Data);
      DragDropManager.CreatePreviewAdorner(sender as UIElement, visualFeedback);
    }
    e.Handled = true;
  }

  public static bool UpdateEffects(object uiObject, DragEventArgs e)
  {
    IDropTargetAdvisor dropTargetAdvisor = DragDropManager.GetDropTargetAdvisor(uiObject as DependencyObject);
    if (!dropTargetAdvisor.IsDropAllowedByApplicationLanguage(e.Data))
    {
      if (AppInfoManager.DragAndDropFieldsReport == null)
        AppInfoManager.DragAndDropFieldsReport = new FieldsReportManager();
      else
        AppInfoManager.DragAndDropFieldsReport.Clear();
      AppInfoManager.DragAndDropFieldsReport.RegisterFieldInReport((IAcpField) null, AcpResources.App_Language_Rules_No_Drop_Allowed, false);
      AppInfoManager.DragAndDropFieldsReport.FieldsReportChanged = true;
      e.Effects = DragDropEffects.None;
      return true;
    }
    if (!dropTargetAdvisor.IsValidDataObject(e.Data))
    {
      e.Effects = DragDropEffects.None;
      return false;
    }
    if (!dropTargetAdvisor.IsDropAllowedByApp(e.Data))
    {
      if (AppInfoManager.DragAndDropFieldsReport == null)
        AppInfoManager.DragAndDropFieldsReport = new FieldsReportManager();
      else
        AppInfoManager.DragAndDropFieldsReport.Clear();
      AppInfoManager.DragAndDropFieldsReport.RegisterFieldInReport((IAcpField) null, AcpResources.App_Versioning_Rules_No_Drop_Allowed, false);
      AppInfoManager.DragAndDropFieldsReport.FieldsReportChanged = true;
      e.Effects = DragDropEffects.None;
      return true;
    }
    if (!dropTargetAdvisor.IsDropAllowedByLocalApp(e.Data))
    {
      if (AppInfoManager.DragAndDropFieldsReport == null)
        AppInfoManager.DragAndDropFieldsReport = new FieldsReportManager();
      else
        AppInfoManager.DragAndDropFieldsReport.Clear();
      AppInfoManager.DragAndDropFieldsReport.RegisterFieldInReport((IAcpField) null, AcpResources.Local_App_Versioning_Rules_No_Drop_Allowed, false);
      AppInfoManager.DragAndDropFieldsReport.FieldsReportChanged = true;
      e.Effects = DragDropEffects.None;
      return true;
    }
    dropTargetAdvisor.ConsumerNode = dropTargetAdvisor.IsValidConsumerNode(uiObject, e);
    if (dropTargetAdvisor.ConsumerNode == null || AppInfoManager.AppMode != ApplicationMode.CodeplugConfigurationMode)
    {
      e.Effects = DragDropEffects.None;
      return true;
    }
    if (dropTargetAdvisor.ConsumerNode != null && !dropTargetAdvisor.IsDropAllowed(e))
    {
      e.Effects = DragDropEffects.None;
      return true;
    }
    if ((e.AllowedEffects & DragDropEffects.Move) == DragDropEffects.None && (e.AllowedEffects & DragDropEffects.Copy) == DragDropEffects.None)
    {
      e.Effects = DragDropEffects.None;
      return true;
    }
    if ((e.AllowedEffects & DragDropEffects.Move) != DragDropEffects.None && (e.AllowedEffects & DragDropEffects.Copy) != DragDropEffects.None)
      e.Effects = (e.KeyStates & DragDropKeyStates.ControlKey) != DragDropKeyStates.None ? DragDropEffects.Copy : DragDropEffects.Move;
    return true;
  }

  private static void DragSource_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
  {
    if (DragDropManager.bTreeIsNavigating || !DragDropManager.GetDragSourceAdvisor(sender as DependencyObject).IsDraggable(e.OriginalSource as UIElement))
      return;
    DragDropManager._draggedElt = e.Source as UIElement;
    DragDropManager._dragStartPoint = e.GetPosition((IInputElement) DragDropManager.GetTopContainer());
    DragDropManager._isMouseDown = true;
  }

  private static void DragSource_PreviewMouseMove(object sender, MouseEventArgs e)
  {
    if (!DragDropManager._isMouseDown || !DragDropManager.IsDragGesture(e.GetPosition((IInputElement) DragDropManager.GetTopContainer())))
      return;
    DragDropManager.DragStarted(sender as UIElement);
  }

  private static void DragStarted(UIElement uiElt)
  {
    DragDropManager._isMouseDown = false;
    if (AppInfoManager.AppMode == ApplicationMode.CodeplugConfigurationMode)
    {
      Mouse.Capture((IInputElement) uiElt);
      IDragSourceAdvisor dragSourceAdvisor = DragDropManager.GetDragSourceAdvisor((DependencyObject) uiElt);
      DataObject dataObject = dragSourceAdvisor.GetDataObject(DragDropManager._draggedElt);
      DragDropEffects supportedEffects = dragSourceAdvisor.SupportedEffects;
      if (DragDropManager._draggedElt != null && dataObject != null)
      {
        if (supportedEffects != DragDropEffects.None)
        {
          try
          {
            DragDropEffects finalEffects = System.Windows.DragDrop.DoDragDrop((DependencyObject) DragDropManager._draggedElt, (object) dataObject, supportedEffects);
            dragSourceAdvisor.FinishDrag(DragDropManager._draggedElt, finalEffects);
          }
          catch (Exception ex)
          {
          }
        }
      }
      DragDropManager.RemovePreviewAdorner();
    }
    Mouse.Capture((IInputElement) null);
    DragDropManager._draggedElt = (UIElement) null;
  }

  private static bool IsDragGesture(Point point)
  {
    return Math.Abs(point.X - DragDropManager._dragStartPoint.X) > SystemParameters.MinimumHorizontalDragDistance | Math.Abs(point.Y - DragDropManager._dragStartPoint.Y) > SystemParameters.MinimumVerticalDragDistance;
  }

  private static UIElement GetTopContainer() => Application.Current.MainWindow.Content as UIElement;

  private static void CreatePreviewAdorner(UIElement adornedElt, UIElement feedbackUI)
  {
    DragDropManager.RemovePreviewAdorner();
    AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer((Visual) DragDropManager.GetTopContainer());
    DragDropManager._overlayElt = new DropPreviewAdorner(feedbackUI, adornedElt);
    DropPreviewAdorner overlayElt = DragDropManager._overlayElt;
    adornerLayer.Add((Adorner) overlayElt);
  }

  private static void RemovePreviewAdorner()
  {
    if (DragDropManager._overlayElt == null)
      return;
    AdornerLayer.GetAdornerLayer((Visual) DragDropManager.GetTopContainer()).Remove((Adorner) DragDropManager._overlayElt);
    DragDropManager._overlayElt = (DropPreviewAdorner) null;
  }

  private static bool IsDropPermitted()
  {
    bool flag = true;
    if (SecurityManager.IsSpecialKeyLoaded)
    {
      if (SecurityManager.CheckIfSpecialKeyIsAttached())
      {
        flag = true;
      }
      else
      {
        flag = false;
        AppInfoManager.DragAndDropFieldsReport.RegisterFieldInReport((IAcpField) null, AcpResources.Drop_Failed_No_Key, false);
        AppInfoManager.DragAndDropFieldsReport.FieldsReportChanged = true;
      }
    }
    return flag;
  }

  public static void SetDnDProcess(IAcpBatchOperation process) => DragDropManager.Process = process;
}
