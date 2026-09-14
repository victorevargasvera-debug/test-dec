// Decompiled with JetBrains decompiler
// Type: AcpUtility.DotfDetect
// Assembly: AcpUtility, Version=1.2.0.9, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0374A65F-E929-4173-BF51-69A629A9A82D
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpUtility.dll

using System;
using System.Windows.Forms;

#nullable disable
namespace AcpUtility;

public class DotfDetect
{
  public static void handle(bool isTampered)
  {
    if (!isTampered)
      return;
    try
    {
      int num = (int) MessageBox.Show("Some files are corrupted. Please un-install and re-install the application.", "CPS", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      if (!Application.MessageLoop)
        return;
      Application.Exit();
    }
    finally
    {
      Environment.Exit(1);
    }
  }
}
