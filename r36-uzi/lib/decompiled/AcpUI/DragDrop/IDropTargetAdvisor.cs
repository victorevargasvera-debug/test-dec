// Decompiled with JetBrains decompiler
// Type: AcpUI.DragDrop.IDropTargetAdvisor
// Assembly: AcpUI, Version=23.1.0.32, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: DC7F6A15-37A6-4183-BF9F-09213F636FB6
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpUI.dll

using AcpCommonLib;
using System.Windows;

#nullable disable
namespace AcpUI.DragDrop;

public interface IDropTargetAdvisor
{
  UIElement TargetUI { get; set; }

  bool IsDropAllowed(DragEventArgs e);

  AcpTreeViewItem ConsumerNode { get; set; }

  bool IsDropAllowedByApp(IDataObject obj);

  bool IsDropAllowedByLocalApp(IDataObject obj);

  bool IsValidDataObject(IDataObject obj);

  bool IsDropAllowedByApplicationLanguage(IDataObject obj);

  AcpTreeViewItem IsValidConsumerNode(object uiObj, DragEventArgs e);

  void OnDropCompleted(IDataObject obj, Point dropPoint, AcpTreeViewItem consumerNode);

  UIElement GetVisualFeedback(IDataObject obj);

  void SetProcess(IAcpBatchOperation process);
}
