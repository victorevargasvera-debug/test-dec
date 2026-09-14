// Decompiled with JetBrains decompiler
// Type: AcpASKLib.Properties.Resources
// Assembly: AcpASKLib, Version=23.1.0.5, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: D65BC533-E9D0-49A5-8218-5CB2B5C70E2D
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpASKLib.dll

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

#nullable disable
namespace AcpASKLib.Properties;

[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
[DebuggerNonUserCode]
[CompilerGenerated]
internal class Resources
{
  private static ResourceManager resourceMan;
  private static CultureInfo resourceCulture;

  internal Resources()
  {
  }

  [EditorBrowsable(EditorBrowsableState.Advanced)]
  internal static ResourceManager ResourceManager
  {
    get
    {
      if (AcpASKLib.Properties.Resources.resourceMan == null)
        AcpASKLib.Properties.Resources.resourceMan = new ResourceManager("AcpASKLib.Properties.Resources", typeof (AcpASKLib.Properties.Resources).Assembly);
      return AcpASKLib.Properties.Resources.resourceMan;
    }
  }

  [EditorBrowsable(EditorBrowsableState.Advanced)]
  internal static CultureInfo Culture
  {
    get => AcpASKLib.Properties.Resources.resourceCulture;
    set => AcpASKLib.Properties.Resources.resourceCulture = value;
  }

  internal static byte[] askalm2p
  {
    get
    {
      return (byte[]) AcpASKLib.Properties.Resources.ResourceManager.GetObject(nameof (askalm2p), AcpASKLib.Properties.Resources.resourceCulture);
    }
  }
}
