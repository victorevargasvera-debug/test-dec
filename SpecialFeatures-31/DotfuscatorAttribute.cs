// Decompiled with JetBrains decompiler
// Type: DotfuscatorAttribute
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

using System;
using System.Runtime.InteropServices;

#nullable disable
[AttributeUsage(AttributeTargets.Assembly)]
[ComVisible(false)]
public sealed class DotfuscatorAttribute : Attribute
{
  private string a;
  private int c;

  public DotfuscatorAttribute(string a, int c)
  {
    DotfuscatorAttribute dotfuscatorAttribute = this;
    // ISSUE: explicit constructor call
    dotfuscatorAttribute.\u002Ector();
    dotfuscatorAttribute.a = a;
    this.c = c;
  }

  public string A => this.a;

  public string a() => this.a;

  public int C => this.c;

  public int c() => this.c;
}
