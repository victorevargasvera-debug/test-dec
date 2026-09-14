// Decompiled with JetBrains decompiler
// Type: AcpUI.DragDrop.ListBoxDragDropManager`1
// Assembly: AcpUI, Version=23.1.0.32, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: DC7F6A15-37A6-4183-BF9F-09213F636FB6
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpUI.dll

using AcpBusinessLayer;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Media3D;

#nullable disable
namespace AcpUI.DragDrop;

public class ListBoxDragDropManager<TItemType> where TItemType : class
{
  private bool canInitiateDrag;
  private ListBoxDragAdorner dragAdorner;
  private double dragAdornerOpacity;
  private int indexToSelect;
  private bool isDragInProgress;
  private TItemType itemUnderDragCursor;
  private ListBox listBox;
  private System.Windows.Point ptMouseDown;
  private bool showDragAdorner;

  internal ListBoxDragDropManager()
  {
    this.canInitiateDrag = false;
    this.dragAdornerOpacity = 0.7;
    this.indexToSelect = -1;
    this.showDragAdorner = true;
  }

  internal ListBoxDragDropManager(ListBox listBox)
    : this()
  {
    this.ListBox = listBox;
  }

  internal ListBoxDragDropManager(ListBox listBox, double dragAdornerOpacity)
    : this(listBox)
  {
    this.DragAdornerOpacity = dragAdornerOpacity;
  }

  internal ListBoxDragDropManager(ListBox listBox, bool showDragAdorner)
    : this(listBox)
  {
    this.ShowDragAdorner = showDragAdorner;
  }

  internal double DragAdornerOpacity
  {
    get => this.dragAdornerOpacity;
    set
    {
      if (this.IsDragInProgress)
        throw new InvalidOperationException("Cannot set the DragAdornerOpacity property during a drag operation.");
      this.dragAdornerOpacity = value >= 0.0 && value <= 1.0 ? value : throw new ArgumentOutOfRangeException(nameof (DragAdornerOpacity), (object) value, "Must be between 0 and 1.");
    }
  }

  internal bool IsDragInProgress
  {
    get => this.isDragInProgress;
    private set => this.isDragInProgress = value;
  }

  internal ListBox ListBox
  {
    get => this.listBox;
    set
    {
      if (this.IsDragInProgress)
        throw new InvalidOperationException("Cannot set the ListBox property during a drag operation.");
      if (this.listBox != null)
      {
        this.listBox.PreviewMouseLeftButtonDown -= new MouseButtonEventHandler(this.listBox_PreviewMouseLeftButtonDown);
        this.listBox.PreviewMouseMove -= new MouseEventHandler(this.listBox_PreviewMouseMove);
        this.listBox.DragOver -= new DragEventHandler(this.listBox_DragOver);
        this.listBox.DragLeave -= new DragEventHandler(this.listBox_DragLeave);
        this.listBox.DragEnter -= new DragEventHandler(this.listBox_DragEnter);
        this.listBox.Drop -= new DragEventHandler(this.listBox_Drop);
      }
      this.listBox = value;
      if (this.listBox == null)
        return;
      if (!this.listBox.AllowDrop)
        this.listBox.AllowDrop = true;
      this.listBox.PreviewMouseLeftButtonDown += new MouseButtonEventHandler(this.listBox_PreviewMouseLeftButtonDown);
      this.listBox.PreviewMouseMove += new MouseEventHandler(this.listBox_PreviewMouseMove);
      this.listBox.DragOver += new DragEventHandler(this.listBox_DragOver);
      this.listBox.DragLeave += new DragEventHandler(this.listBox_DragLeave);
      this.listBox.DragEnter += new DragEventHandler(this.listBox_DragEnter);
      this.listBox.Drop += new DragEventHandler(this.listBox_Drop);
    }
  }

  public event EventHandler<ProcessDropEventArgs<TItemType>> ProcessDrop;

  internal bool ShowDragAdorner
  {
    get => this.showDragAdorner;
    set
    {
      if (this.IsDragInProgress)
        throw new InvalidOperationException("Cannot set the ShowDragAdorner property during a drag operation.");
      this.showDragAdorner = value;
    }
  }

  private void listBox_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
  {
    if (this.IsMouseOverScrollbar)
    {
      this.canInitiateDrag = false;
    }
    else
    {
      int indexUnderDragCursor = this.IndexUnderDragCursor;
      this.canInitiateDrag = indexUnderDragCursor > -1;
      if (this.canInitiateDrag)
      {
        this.ptMouseDown = MouseUtilities.GetMousePosition((Visual) this.listBox);
        this.indexToSelect = indexUnderDragCursor;
      }
      else
      {
        this.ptMouseDown = new System.Windows.Point(-10000.0, -10000.0);
        this.indexToSelect = -1;
      }
    }
  }

  private void listBox_PreviewMouseMove(object sender, MouseEventArgs e)
  {
    if (!this.CanStartDragOperation)
      return;
    if (this.listBox.SelectedIndex != this.indexToSelect)
      this.listBox.SelectedIndex = this.indexToSelect;
    if (this.listBox.SelectedItem == null)
      return;
    ListBoxItem listBoxItem = this.GetListBoxItem(this.listBox.SelectedIndex);
    if (listBoxItem == null)
      return;
    AdornerLayer adornerLayer = this.ShowDragAdornerResolved ? this.InitializeAdornerLayer(listBoxItem) : (AdornerLayer) null;
    this.InitializeDragOperation(listBoxItem);
    this.PerformDragOperation();
    this.FinishDragOperation(listBoxItem, adornerLayer);
  }

  private void listBox_DragOver(object sender, DragEventArgs e)
  {
    if (this.UpdateEffects(sender, e))
    {
      e.Effects = DragDropEffects.Move;
      if (this.ShowDragAdornerResolved)
        this.UpdateDragAdornerLocation();
      int indexUnderDragCursor = this.IndexUnderDragCursor;
      this.ItemUnderDragCursor = indexUnderDragCursor < 0 ? default (TItemType) : this.ListBox.Items[indexUnderDragCursor] as TItemType;
    }
    e.Handled = true;
  }

  private void listBox_DragLeave(object sender, DragEventArgs e)
  {
    if (this.UpdateEffects(sender, e) && !this.IsMouseOver((Visual) this.listBox))
    {
      if ((object) this.ItemUnderDragCursor != null)
        this.ItemUnderDragCursor = default (TItemType);
      if (this.dragAdorner != null)
        this.dragAdorner.Visibility = Visibility.Collapsed;
    }
    e.Handled = true;
  }

  private void listBox_DragEnter(object sender, DragEventArgs e)
  {
    if (this.UpdateEffects(sender, e) && this.dragAdorner != null && this.dragAdorner.Visibility != Visibility.Visible)
    {
      this.UpdateDragAdornerLocation();
      this.dragAdorner.Visibility = Visibility.Visible;
    }
    e.Handled = true;
  }

  private void listBox_Drop(object sender, DragEventArgs e)
  {
    if (this.UpdateEffects(sender, e))
    {
      if ((object) this.ItemUnderDragCursor != null)
        this.ItemUnderDragCursor = default (TItemType);
      e.Effects = DragDropEffects.None;
      if (!e.Data.GetDataPresent(typeof (AcpListBox)) && !e.Data.GetDataPresent(typeof (AcpOrderableListBox)))
        return;
      TItemType dataItem = !e.Data.GetDataPresent(typeof (AcpListBox)) ? (e.Data.GetData(typeof (AcpOrderableListBox)) as AcpOrderableListBox).SelectedItem as TItemType : (e.Data.GetData(typeof (AcpListBox)) as AcpListBox).SelectedItem as TItemType;
      if ((object) dataItem == null)
        return;
      ObservableCollection<TItemType> itemsSource = this.listBox.ItemsSource as ObservableCollection<TItemType>;
      int oldIndex = itemsSource.IndexOf(dataItem);
      int num = this.IndexUnderDragCursor;
      if (num < 0)
      {
        if (itemsSource.Count == 0)
        {
          num = 0;
        }
        else
        {
          if (oldIndex >= 0)
            return;
          num = itemsSource.Count;
        }
      }
      if (oldIndex == num)
        return;
      if (this.ProcessDrop != null)
      {
        ProcessDropEventArgs<TItemType> e1 = new ProcessDropEventArgs<TItemType>(itemsSource, dataItem, oldIndex, num, e.AllowedEffects);
        this.ProcessDrop((object) this, e1);
        e.Effects = e1.Effects;
      }
      else
      {
        if (oldIndex > -1)
        {
          if (sender is AcpListBox acpListBox)
          {
            if (acpListBox.MyBLObject is AcpListField myBlObject)
              myBlObject.MoveItem(oldIndex, num);
          }
          else
            itemsSource.Move(oldIndex, num);
        }
        else
          itemsSource.Insert(num, dataItem);
        e.Effects = DragDropEffects.Move;
      }
    }
    e.Handled = true;
  }

  private bool CanStartDragOperation
  {
    get
    {
      return Mouse.LeftButton == MouseButtonState.Pressed && this.canInitiateDrag && this.indexToSelect != -1 && this.HasCursorLeftDragThreshold;
    }
  }

  private void FinishDragOperation(ListBoxItem draggedItem, AdornerLayer adornerLayer)
  {
    ListBoxItemDragState.SetIsBeingDragged((DependencyObject) draggedItem, false);
    this.IsDragInProgress = false;
    if ((object) this.ItemUnderDragCursor != null)
      this.ItemUnderDragCursor = default (TItemType);
    if (adornerLayer == null)
      return;
    adornerLayer.Remove((Adorner) this.dragAdorner);
    this.dragAdorner = (ListBoxDragAdorner) null;
  }

  private ListBoxItem GetListBoxItem(int index)
  {
    return this.listBox.ItemContainerGenerator.Status != GeneratorStatus.ContainersGenerated ? (ListBoxItem) null : this.listBox.ItemContainerGenerator.ContainerFromIndex(index) as ListBoxItem;
  }

  private ListBoxItem GetListBoxItem(TItemType dataItem)
  {
    return this.listBox.ItemContainerGenerator.Status != GeneratorStatus.ContainersGenerated ? (ListBoxItem) null : this.listBox.ItemContainerGenerator.ContainerFromItem((object) dataItem) as ListBoxItem;
  }

  private bool HasCursorLeftDragThreshold
  {
    get
    {
      if (this.indexToSelect < 0)
        return false;
      ListBoxItem listBoxItem = this.GetListBoxItem(this.indexToSelect);
      Rect descendantBounds = VisualTreeHelper.GetDescendantBounds((Visual) listBoxItem);
      System.Windows.Point point = this.listBox.TranslatePoint(this.ptMouseDown, (UIElement) listBoxItem);
      Size size = new Size(SystemParameters.MinimumHorizontalDragDistance * 2.0, Math.Min(SystemParameters.MinimumVerticalDragDistance, Math.Min(Math.Abs(point.Y), Math.Abs(descendantBounds.Height - point.Y))) * 2.0);
      Rect rect = new Rect(this.ptMouseDown, size);
      rect.Offset(size.Width / -2.0, size.Height / -2.0);
      System.Windows.Point mousePosition = MouseUtilities.GetMousePosition((Visual) this.listBox);
      return !rect.Contains(mousePosition);
    }
  }

  private int IndexUnderDragCursor
  {
    get
    {
      int indexUnderDragCursor = -1;
      for (int index = 0; index < this.listBox.Items.Count; ++index)
      {
        if (this.IsMouseOver((Visual) this.GetListBoxItem(index)))
        {
          indexUnderDragCursor = index;
          break;
        }
      }
      return indexUnderDragCursor;
    }
  }

  private AdornerLayer InitializeAdornerLayer(ListBoxItem itemToDrag)
  {
    VisualBrush visualBrush = new VisualBrush((Visual) itemToDrag);
    this.dragAdorner = new ListBoxDragAdorner((UIElement) this.listBox, itemToDrag.RenderSize, (Brush) visualBrush);
    this.dragAdorner.Opacity = this.DragAdornerOpacity;
    AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer((Visual) this.listBox);
    adornerLayer.Add((Adorner) this.dragAdorner);
    this.ptMouseDown = MouseUtilities.GetMousePosition((Visual) this.listBox);
    return adornerLayer;
  }

  private void InitializeDragOperation(ListBoxItem itemToDrag)
  {
    this.IsDragInProgress = true;
    this.canInitiateDrag = false;
    ListBoxItemDragState.SetIsBeingDragged((DependencyObject) itemToDrag, true);
  }

  private bool IsMouseOver(Visual target)
  {
    return VisualTreeHelper.GetDescendantBounds(target).Contains(MouseUtilities.GetMousePosition(target));
  }

  private bool IsMouseOverScrollbar
  {
    get
    {
      HitTestResult hitTestResult = VisualTreeHelper.HitTest((Visual) this.listBox, MouseUtilities.GetMousePosition((Visual) this.listBox));
      if (hitTestResult == null)
        return false;
      DependencyObject dependencyObject = hitTestResult.VisualHit;
      while (true)
      {
        switch (dependencyObject)
        {
          case null:
            goto label_7;
          case ScrollBar _:
            goto label_3;
          case Visual _:
          case Visual3D _:
            dependencyObject = VisualTreeHelper.GetParent(dependencyObject);
            continue;
          default:
            dependencyObject = LogicalTreeHelper.GetParent(dependencyObject);
            continue;
        }
      }
label_3:
      return true;
label_7:
      return false;
    }
  }

  private TItemType ItemUnderDragCursor
  {
    get => this.itemUnderDragCursor;
    set
    {
      if ((object) this.itemUnderDragCursor == (object) value)
        return;
      for (int index = 0; index < 2; ++index)
      {
        if (index == 1)
          this.itemUnderDragCursor = value;
        if ((object) this.itemUnderDragCursor != null)
        {
          ListBoxItem listBoxItem = this.GetListBoxItem(this.itemUnderDragCursor);
          if (listBoxItem != null)
            ListBoxItemDragState.SetIsUnderDragCursor(listBoxItem, index == 1);
        }
      }
    }
  }

  private void PerformDragOperation()
  {
    object listBox = (object) this.listBox;
    TItemType selectedItem = this.listBox.SelectedItem as TItemType;
    DragDropEffects allowedEffects = DragDropEffects.Move;
    if (System.Windows.DragDrop.DoDragDrop((DependencyObject) this.listBox, listBox, allowedEffects) == DragDropEffects.None)
      return;
    this.listBox.SelectedItem = (object) selectedItem;
  }

  private bool ShowDragAdornerResolved => this.ShowDragAdorner && this.DragAdornerOpacity > 0.0;

  private void UpdateDragAdornerLocation()
  {
    if (this.dragAdorner == null)
      return;
    System.Windows.Point mousePosition = MouseUtilities.GetMousePosition((Visual) this.ListBox);
    this.dragAdorner.SetOffsets(mousePosition.X - this.ptMouseDown.X, this.GetListBoxItem(this.indexToSelect).TranslatePoint(new System.Windows.Point(0.0, 0.0), (UIElement) this.ListBox).Y + mousePosition.Y - this.ptMouseDown.Y);
  }

  internal bool UpdateEffects(object sender, DragEventArgs e)
  {
    if (!(e.Data.GetData(typeof (AcpListBox)) is AcpListBox data))
      data = e.Data.GetData(typeof (AcpOrderableListBox)) as AcpListBox;
    if (data != this.listBox)
    {
      e.Effects = DragDropEffects.None;
      return false;
    }
    if ((e.AllowedEffects & DragDropEffects.Move) == DragDropEffects.None)
    {
      e.Effects = DragDropEffects.None;
      return false;
    }
    e.Effects = DragDropEffects.Move;
    return true;
  }
}
