// Decompiled with JetBrains decompiler
// Type: AcpBusinessLayer.AcpDocument
// Assembly: AcpBusinessLayer, Version=23.1.0.23, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 44CF2A76-4418-422B-9DDD-B27A71BAF20C
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpBusinessLayer.dll

using AcpCommonLib;
using AcpCommonLib.UndoRedo;
using AcpCommonResources;
using AcpFileHandlerLib;
using AcpUtility;
using Motorola.Common.BinarySerializer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading;

#nullable disable
namespace AcpBusinessLayer;

public class AcpDocument : Document
{
  private static string cpgVersionErrStr = "";
  private static int radInfoFeatureID = 0;
  private static int radInfoGenSectionId = 0;
  internal static bool Closing = false;
  public static bool PageOnLoading = false;

  public static string CpgVersionErrStr
  {
    get => AcpDocument.cpgVersionErrStr;
    set => AcpDocument.cpgVersionErrStr = value;
  }

  public static int RadInfoFeatureID
  {
    get => AcpDocument.radInfoFeatureID;
    set => AcpDocument.radInfoFeatureID = value;
  }

  public static int RadInfoGenSectionId
  {
    get => AcpDocument.radInfoGenSectionId;
    set => AcpDocument.radInfoGenSectionId = value;
  }

  public AcpDocument()
  {
  }

  public AcpDocument(bool background, DocumentType type)
    : base(background, type)
  {
  }

  public bool FileNew()
  {
    UndoManager.StopUndoRedo();
    this.OpenFromFileNew = true;
    return true;
  }

  public bool FileClose()
  {
    bool flag = false;
    if (this.Background)
      flag = UndoManager.StopUndoRedo();
    AcpDocument.Closing = true;
    this.Clear();
    AcpDocument.Closing = false;
    if (this.IsMainDocument)
    {
      Recordset.ResetMaxPools();
      FeatureSection.InitializedSections.Clear();
      AppInfoManager.InvalidFieldsReport?.Clear();
    }
    this.IsDirty = false;
    this.IsOpen = false;
    if (this.Background & flag)
      UndoManager.StartUndoRedo();
    return true;
  }

  public bool FileOpenSafely(string path, IEnumerable<BinarySerializerTypeInfo> allowedTypes)
  {
    bool flag1 = false;
    if (this.Background)
      flag1 = UndoManager.StopUndoRedo();
    bool flag2 = false;
    AppInfoManager.NonEngOldCodeplug = false;
    DateTime now = DateTime.Now;
    AcpFileHandler acpFileHandler = new AcpFileHandler(allowedTypes);
    ArrayList readBuffer = (ArrayList) null;
    try
    {
      AcpFileHeader fileHeader = acpFileHandler.ReadHeaderSafely(path);
      FeatureManager.BeginAddFeatures((Document) this);
      Document.CodePlugVersionNumber = fileHeader.VersionNumber;
      acpFileHandler.ReadFileSafely<ArrayList>(out readBuffer, out fileHeader, path, true, allowedTypes);
      if (readBuffer.Count > 0)
      {
        this.Info = readBuffer[0] as AcpDocInfo;
        if (this.Info != null)
          this.Info.Document = this;
      }
      string codeplugVersion = this.GetCodeplugVersion(readBuffer);
      AppInfoManager.CodeplugVersion = Document.CodePlugVersionNumber;
      if (AcpDocument.ValidCodeplugVersion(codeplugVersion))
      {
        CultureInfo currentUiCulture = Thread.CurrentThread.CurrentUICulture;
        if (int.Parse(Document.CodePlugVersionNumber.Substring(1, 2)) < AppInfoManager.LOCALIZED_VERSION_NUMBER && !(currentUiCulture.TwoLetterISOLanguageName == "en"))
        {
          AppInfoManager.NonEngOldCodeplug = true;
          flag2 = false;
        }
        else
        {
          foreach (object obj in readBuffer)
          {
            if (obj is IAcpRecordset recset)
              this.AddFeature(recset);
          }
          foreach (Recordset feature in this.Features)
            feature.RepairRecRefs();
          this.AddNewFeatures(codeplugVersion);
          this.docFileName = Path.GetFileName(path);
          this.docFilePath = Path.GetFullPath(path);
          this.OpenFromFileNew = false;
          flag2 = true;
          FeatureManager.SetActiveDocumentCodeplugVersion(codeplugVersion);
        }
      }
    }
    catch (Exception ex)
    {
      throw ex;
    }
    finally
    {
      if (this.Background & flag1)
        UndoManager.StartUndoRedo();
      FeatureManager.EndAddFeatures();
    }
    return flag2;
  }

  protected virtual void AddNewFeatures(string codeplugVersion)
  {
  }

  private string GetCodeplugVersion(ArrayList items)
  {
    string codeplugVersion = "";
    foreach (object obj in items)
    {
      if (obj is IAcpRecordset acpRecordset && acpRecordset.RecsetId == AcpDocument.RadInfoFeatureID)
      {
        foreach (IAcpFeatureSection featureSections in acpRecordset[0].FeatureSectionsCollection)
        {
          if (featureSections.FeatureSectionId == AcpDocument.RadInfoGenSectionId)
          {
            foreach (IAcpField fields in featureSections.FieldsCollection)
            {
              if (fields.Name == "RadInfoGeneralCodeplugVersion_A7683")
              {
                codeplugVersion = (fields as AcpStringField).Value;
                break;
              }
            }
          }
          if (codeplugVersion != "")
            break;
        }
        if (codeplugVersion != "")
          break;
      }
      if (codeplugVersion != "")
        break;
    }
    return codeplugVersion;
  }

  public static bool ValidCodeplugVersion(string cpgVersion)
  {
    bool flag = false;
    string appVersion = AppInfoManager.AppVersion;
    AcpDocument.cpgVersionErrStr = "";
    if (cpgVersion == appVersion)
      flag = true;
    else if (cpgVersion.Length >= 9)
    {
      string[] strArray1 = appVersion.Substring(1).Split('.');
      string[] strArray2 = cpgVersion.Substring(1).Split('.');
      int int16_1 = (int) Convert.ToInt16(strArray1[0], 10);
      int int16_2 = (int) Convert.ToInt16(strArray2[0], 10);
      int int16_3 = (int) Convert.ToInt16(strArray1[1], 10);
      int int16_4 = (int) Convert.ToInt16(strArray2[1], 10);
      if (appVersion.StartsWith("R"))
      {
        if (cpgVersion.StartsWith("R"))
          flag = int16_2 < int16_1 || int16_2 == int16_1 && int16_4 <= int16_3;
        else
          AcpDocument.cpgVersionErrStr = AcpResources.Cannot_Read_Development_Codeplugs;
      }
      else if (int16_2 < int16_1)
        flag = true;
      else if (int16_2 == int16_1)
      {
        if (int16_4 < int16_3)
          flag = true;
        else if (int16_4 == int16_3)
        {
          int int16_5 = (int) Convert.ToInt16(strArray1[2], 10);
          flag = (int) Convert.ToInt16(strArray2[2], 10) <= int16_5;
        }
      }
    }
    else
    {
      flag = cpgVersion == "0x1" && !appVersion.StartsWith("R");
      if (!flag)
        AcpDocument.cpgVersionErrStr = AcpResources.Invalid_Codeplug.AcpStringFormat((object) cpgVersion);
    }
    if (!flag && AcpDocument.cpgVersionErrStr == "")
      AcpDocument.cpgVersionErrStr = AcpResources.Codeplug_Req.AcpStringFormat((object) cpgVersion);
    return flag;
  }

  public bool FileSaveAsSafely(string path, AcpFileHeader fileHeader)
  {
    AcpFileHandler acpFileHandler = new AcpFileHandler();
    ArrayList writeBuffer = new ArrayList()
    {
      (object) new AcpDocInfo(this)
    };
    foreach (IAcpRecordset feature in this.Features)
      writeBuffer.Add((object) feature);
    acpFileHandler.WriteFileSafely<ArrayList>(writeBuffer, fileHeader, path, true);
    this.docFileName = Path.GetFileName(path);
    this.docFilePath = Path.GetFullPath(path);
    this.IsDirty = false;
    this.WriteModificationLog();
    return true;
  }

  public void Initialized(bool dirty)
  {
    ConstraintManager.Resume();
    this.Init();
    this.IsDirty = dirty;
    this.IsOpen = true;
    UndoManager.Reset();
    UndoManager.StartUndoRedo();
  }

  internal AcpDocInfo Info { get; private set; }

  public bool OpenFromFileNew { get; internal set; }
}
