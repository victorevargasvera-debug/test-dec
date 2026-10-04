// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.Clone_Configuration.Common.RadioEjectTimer
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

using System;
using System.Windows.Threading;

#nullable disable
namespace SpecialFeatures.Clone_Configuration.Common;

public class RadioEjectTimer : DispatcherTimer
{
  public RadioEjectTimer()
    : base(DispatcherPriority.Normal)
  {
    this.Interval = TimeSpan.FromMilliseconds(30000.0);
  }

  public void StartTimer()
  {
    short num = 8643;
    switch ((short) 8643 == num)
    {
      case true:
        num = (short) 1;
        if (num == (short) 0)
          ;
        num = (short) 0;
        if (num == (short) 0)
          ;
        this.Stop();
        this.Start();
        break;
      default:
        goto case 1;
    }
  }
}
