// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfRibbon.IButtonDropDownCommandExtender
// Assembly: AcpWpfRibbon, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 45A745B5-88C3-40EE-B1E5-8DBA2EACD529
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfRibbon.dll

using System.Windows.Media;

#nullable disable
namespace DevComponents.WpfRibbon;

public interface IButtonDropDownCommandExtender
{
  ImageSource ImageSource { get; set; }

  ImageSource ImageSmallSource { get; set; }

  string Header { get; set; }

  bool SyncHeader { get; set; }

  bool SyncImageSource { get; set; }

  bool SyncImageSmallSource { get; set; }
}
