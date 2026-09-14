// Decompiled with JetBrains decompiler
// Type: AcpUI.DragDrop.ProcessDropEventArgs`1
// Assembly: AcpUI, Version=23.1.0.32, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: DC7F6A15-37A6-4183-BF9F-09213F636FB6
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpUI.dll

using System;
using System.Collections.ObjectModel;
using System.Windows;

#nullable disable
namespace AcpUI.DragDrop;

public class ProcessDropEventArgs<TItemType> : EventArgs where TItemType : class
{
  private ObservableCollection<TItemType> itemsSource;
  private TItemType dataItem;
  private int oldIndex;
  private int newIndex;
  private DragDropEffects allowedEffects;
  private DragDropEffects effects;

  internal ProcessDropEventArgs(
    ObservableCollection<TItemType> itemsSource,
    TItemType dataItem,
    int oldIndex,
    int newIndex,
    DragDropEffects allowedEffects)
  {
    this.itemsSource = itemsSource;
    this.dataItem = dataItem;
    this.oldIndex = oldIndex;
    this.newIndex = newIndex;
    this.allowedEffects = allowedEffects;
  }

  internal ObservableCollection<TItemType> ItemsSource => this.itemsSource;

  internal TItemType DataItem => this.dataItem;

  internal int OldIndex => this.oldIndex;

  internal int NewIndex => this.newIndex;

  internal DragDropEffects AllowedEffects => this.allowedEffects;

  internal DragDropEffects Effects
  {
    get => this.effects;
    set => this.effects = value;
  }
}
