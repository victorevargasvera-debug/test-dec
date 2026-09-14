// Decompiled with JetBrains decompiler
// Type: AcpASKLib.SystemKeyLoadedEventArgs
// Assembly: AcpASKLib, Version=23.1.0.5, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: D65BC533-E9D0-49A5-8218-5CB2B5C70E2D
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpASKLib.dll

using System;
using System.Collections.ObjectModel;

#nullable disable
namespace AcpASKLib;

public class SystemKeyLoadedEventArgs : EventArgs
{
  private ObservableCollection<SystemKeyData> loadedkeys;
  private ObservableCollection<SpecialKeyData> loadedSpecKeys;

  internal SystemKeyLoadedEventArgs(
    ObservableCollection<SystemKeyData> keys,
    ObservableCollection<SpecialKeyData> specKeys)
  {
    this.loadedkeys = keys;
    this.loadedSpecKeys = specKeys;
  }

  public ObservableCollection<SystemKeyData> LoadedSystemKeys => this.loadedkeys;

  public ObservableCollection<SpecialKeyData> LoadedSpecialKeys => this.loadedSpecKeys;
}
