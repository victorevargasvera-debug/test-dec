// Decompiled with JetBrains decompiler
// Type: MackinawCPS.UndoRedo.NavigatePageTask
// Assembly: APXFamilyCPS, Version=36.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 9359335E-041C-4B12-9409-F4E6E7D93299
// Assembly location: C:\Program Files (x86)\Motorola\ApxFamilyCPS R36.00\APXFamilyCPS1.exe

using AcpCommonLib.UndoRedo;
using System;
using System.Windows.Controls;

#nullable disable
namespace MackinawCPS.UndoRedo;

internal class NavigatePageTask : UndoableTask
{
  private Frame theFrame;
  private string theOtherUri;

  private NavigatePageTask() => this.Seamless = true;

  internal NavigatePageTask(Frame frame, string newUri)
    : this()
  {
    this.theFrame = frame;
    this.theOtherUri = newUri;
    this.Description = "Navigate to " + newUri;
  }

  public override void Do()
  {
    this.SwapValues();
    base.Do();
  }

  public override void Undo()
  {
    this.SwapValues();
    base.Undo();
  }

  private void SwapValues()
  {
    string originalString = this.theFrame.CurrentSource.OriginalString;
    this.theFrame.Navigate(new Uri(this.theOtherUri, UriKind.RelativeOrAbsolute));
    this.theOtherUri = originalString;
  }
}
