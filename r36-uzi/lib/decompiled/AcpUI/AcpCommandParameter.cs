// Decompiled with JetBrains decompiler
// Type: AcpUI.AcpCommandParameter
// Assembly: AcpUI, Version=23.1.0.32, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: DC7F6A15-37A6-4183-BF9F-09213F636FB6
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpUI.dll

using System;
using System.Windows;

#nullable disable
namespace AcpUI;

public class AcpCommandParameter
{
  public DependencyObject Sender { get; set; }

  public EventArgs EventArgs { get; set; }

  public object Parameter { get; set; }
}
