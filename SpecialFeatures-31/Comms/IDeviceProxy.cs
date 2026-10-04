// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.Comms.IDeviceProxy
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

using Motorola.Common.Communication.CommonUtil;
using Motorola.Common.Communication.Pba;
using System;
using System.Collections.Generic;
using System.ComponentModel;

#nullable disable
namespace SpecialFeatures.Comms;

public interface IDeviceProxy : IDisposable
{
  bool CurrentRadioIsConnected { get; }

  PbaObject Read(RadioParams radioPara, ProgressChangedEventHandler prgressIndicator);

  bool Write(
    RadioParams radioPara,
    PbaObject targetPba,
    ProgressChangedEventHandler prgressIndicator = null);

  RadioParams ReadExtendedDeviceInfo();

  bool ResetPassword(byte[] passwordResetFileContent);

  PbaObject ReadBlock(
    RadioParams radioPara,
    List<IshHeader> blockList,
    ProgressChangedEventHandler prgressIndicator = null);

  void UpdateDevice(
    RadioParams radioPara,
    PbaObject targetPba,
    ProgressChangedEventHandler prgressIndicator = null);

  void ValidateUpdate(RadioParams radioPara, ProgressChangedEventHandler prgressIndicator = null);

  bool CBIProgram(RadioParams radioPara);

  bool UpdateSN(RadioParams radioPara, string serialNumber);

  bool ForceWrite(
    RadioParams radioPara,
    PbaObject targetPba,
    ProgressChangedEventHandler prgressIndicator = null);

  void WriteLanguagePack(
    RadioParams radioParam,
    LanguagePackData languagePackData,
    ProgressChangedEventHandler prgressIndicator = null);

  bool LoadTxmCertificate(RadioParams radioParam, string path);

  string QueryTxmCertificate(RadioParams radioParam, string path);
}
