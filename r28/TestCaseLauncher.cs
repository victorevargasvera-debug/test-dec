// Decompiled with JetBrains decompiler
// Type: MackinawCPS.TestCaseLauncher
// Assembly: APXFamilyCPS, Version=15.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 7983BD42-76AB-479D-8966-B7B635E0E28A
// Assembly location: C:\Program Files (x86)\Motorola\ApxFamilyDepot R28\APXdepotR28.exe

using Motorola.CommonCPS.Common.CommonUtility;
using Motorola.CommonCPS.RadioManagement.Core;
using Motorola.CommonCPS.RadioManagement.Global;
using System;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

#nullable disable
namespace MackinawCPS;

internal class TestCaseLauncher
{
  private System.Type testAgentType = (System.Type) null;

  public event EventHandler OnTestFinished;

  public void Launch()
  {
    try
    {
      new RMCWnd().ToString();
      if (RadioManagementBootstrapper.Connect())
        RadioManagementBootstrapper.LanuchForTestCase(PACIdentifier.ASTRO, "ASTROCPS_RMSERVER_RM");
      BackgroundWorker backgroundWorker = new BackgroundWorker();
      backgroundWorker.DoWork += (DoWorkEventHandler) ((sender, e) => this.Run());
      backgroundWorker.RunWorkerCompleted += (RunWorkerCompletedEventHandler) ((sender, e) => { });
      backgroundWorker.RunWorkerAsync();
    }
    catch (Exception ex)
    {
    }
  }

  private System.Type TestAgentType
  {
    get
    {
      if (this.testAgentType == (System.Type) null)
      {
        this.testAgentType = Assembly.LoadFile(Path.Combine(Application.StartupPath, "CMNTestManager.dll")).GetType("CMNTestManager.TestAgent");
        if (!this.IsValidTestManager())
          return (System.Type) null;
      }
      return this.testAgentType;
    }
  }

  public bool ShallRunTestCase()
  {
    try
    {
      return (bool) this.CallTestAgentMethod(nameof (ShallRunTestCase));
    }
    catch (Exception ex)
    {
      return false;
    }
  }

  private void Run()
  {
    this.CallTestAgentMethod(nameof (Run));
    if (this.OnTestFinished == null)
      return;
    this.OnTestFinished((object) this, (EventArgs) null);
  }

  private object CallTestAgentMethod(string methodName)
  {
    return this.TestAgentType.GetMethod(methodName).Invoke(this.TestAgentType.Assembly.CreateInstance(this.TestAgentType.FullName), (object[]) null);
  }

  private bool IsValidTestManager()
  {
    try
    {
      if (this.testAgentType != (System.Type) null)
      {
        MethodInfo method = this.testAgentType.GetMethod("GetEncripedString");
        if (method != (MethodInfo) null)
        {
          object instance = this.TestAgentType.Assembly.CreateInstance(this.TestAgentType.FullName);
          if (AESCryptoUtil.AESDecryptWithDefKey((string) method.Invoke(instance, (object[]) null)).Equals("!VDDdd357_"))
            return true;
        }
      }
    }
    catch
    {
      return false;
    }
    return false;
  }
}
