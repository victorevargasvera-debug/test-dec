// Decompiled with JetBrains decompiler
// Type: AcpUI.Common.FieldItemSelectionEventArgs
// Assembly: AcpUI, Version=23.1.0.32, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: DC7F6A15-37A6-4183-BF9F-09213F636FB6
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpUI.dll

using AcpCommonLib;
using System;

#nullable disable
namespace AcpUI.Common;

public class FieldItemSelectionEventArgs : EventArgs
{
  internal FieldItemSelectionEventArgs(FieldInfo data) => this.Field = data;

  public FieldInfo Field { get; private set; }
}
