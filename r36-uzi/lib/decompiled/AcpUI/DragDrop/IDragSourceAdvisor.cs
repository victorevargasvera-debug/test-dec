// Decompiled with JetBrains decompiler
// Type: AcpUI.DragDrop.IDragSourceAdvisor
// Assembly: AcpUI, Version=23.1.0.32, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: DC7F6A15-37A6-4183-BF9F-09213F636FB6
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpUI.dll

using System.Windows;

#nullable disable
namespace AcpUI.DragDrop;

public interface IDragSourceAdvisor
{
  UIElement SourceUI { get; set; }

  DragDropEffects SupportedEffects { get; }

  DataObject GetDataObject(UIElement draggedElement);

  void FinishDrag(UIElement draggedElement, DragDropEffects finalEffects);

  bool IsDraggable(UIElement dragElement);
}
