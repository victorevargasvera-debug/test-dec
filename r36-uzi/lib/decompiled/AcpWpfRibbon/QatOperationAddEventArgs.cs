// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfRibbon.QatOperationAddEventArgs
// Assembly: AcpWpfRibbon, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 45A745B5-88C3-40EE-B1E5-8DBA2EACD529
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfRibbon.dll

using System.Windows;

#nullable disable
namespace DevComponents.WpfRibbon;

public class QatOperationAddEventArgs : QatOperationEventArgs
{
  public object ItemCopy;

  public QatOperationAddEventArgs(object item)
    : base(item)
  {
  }

  public QatOperationAddEventArgs(object item, RoutedEvent e)
    : base(item, e)
  {
  }

  public QatOperationAddEventArgs(object item, RoutedEvent e, object originalSource)
    : base(item, e, originalSource)
  {
  }
}
