// Decompiled with JetBrains decompiler
// Type: MackinawCPS.UndoRedo.NavigatePageTask
// Assembly: APXFamilyCPS, Version=15.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 7983BD42-76AB-479D-8966-B7B635E0E28A
// Assembly location: C:\Program Files (x86)\Motorola\ApxFamilyDepot R28\APXdepotR28.exe

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
