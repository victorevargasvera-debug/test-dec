// Decompiled with JetBrains decompiler
// Type: AcpUI.DragDrop.ListBoxItemDragState
// Assembly: AcpUI, Version=23.1.0.32, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: DC7F6A15-37A6-4183-BF9F-09213F636FB6
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpUI.dll

using System.Windows;
using System.Windows.Controls;

#nullable disable
namespace AcpUI.DragDrop;

public static class ListBoxItemDragState
{
  public static readonly DependencyProperty IsBeingDraggedProperty = DependencyProperty.RegisterAttached("IsBeingDragged", typeof (bool), typeof (ListBoxItemDragState), (PropertyMetadata) new UIPropertyMetadata((object) false));
  public static readonly DependencyProperty IsUnderDragCursorProperty = DependencyProperty.RegisterAttached("IsUnderDragCursor", typeof (bool), typeof (ListBoxItemDragState), (PropertyMetadata) new UIPropertyMetadata((object) false));

  internal static bool GetIsBeingDragged(DependencyObject item)
  {
    return (bool) item.GetValue(ListBoxItemDragState.IsBeingDraggedProperty);
  }

  internal static void SetIsBeingDragged(DependencyObject item, bool value)
  {
    item.SetValue(ListBoxItemDragState.IsBeingDraggedProperty, (object) value);
  }

  internal static bool GetIsUnderDragCursor(DependencyObject item)
  {
    return (bool) item.GetValue(ListBoxItemDragState.IsUnderDragCursorProperty);
  }

  internal static void SetIsUnderDragCursor(ListBoxItem item, bool value)
  {
    item.SetValue(ListBoxItemDragState.IsUnderDragCursorProperty, (object) value);
  }
}
