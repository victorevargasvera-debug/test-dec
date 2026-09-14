// Decompiled with JetBrains decompiler
// Type: AcpBusinessLayer.DifferenceCountChangedEventArgs
// Assembly: AcpBusinessLayer, Version=23.1.0.23, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 44CF2A76-4418-422B-9DDD-B27A71BAF20C
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpBusinessLayer.dll

using System;

#nullable disable
namespace AcpBusinessLayer;

public class DifferenceCountChangedEventArgs : EventArgs
{
  private string name;
  private DifferenceCountChangedAction action;

  internal DifferenceCountChangedEventArgs(string name, DifferenceCountChangedAction action)
  {
    this.name = name;
    this.action = action;
  }

  internal string Name => this.name;

  internal DifferenceCountChangedAction Action => this.action;
}
