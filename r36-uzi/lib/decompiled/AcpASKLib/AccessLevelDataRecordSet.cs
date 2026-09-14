// Decompiled with JetBrains decompiler
// Type: AcpASKLib.AccessLevelDataRecordSet
// Assembly: AcpASKLib, Version=23.1.0.5, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: D65BC533-E9D0-49A5-8218-5CB2B5C70E2D
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpASKLib.dll

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

#nullable disable
namespace AcpASKLib;

[Serializable]
public class AccessLevelDataRecordSet : ObservableCollection<AccessRecord>
{
  private string name;
  private byte m_uNextPrimaryKeyValue = 4;

  protected AccessLevelDataRecordSet()
  {
  }

  public AccessLevelDataRecordSet(string name) => this.name = name;

  public void AddNewRecord(AccessRecord newRec)
  {
    int count = this.Count;
    int num;
    newRec.ID = num = count + 1;
    newRec.PrimaryKey = (int) this.m_uNextPrimaryKeyValue++;
    this.Add(newRec);
  }

  internal AccessRecord GetRecordByData(AccessRecord inputAccessRec)
  {
    AccessRecord recordByData = (AccessRecord) null;
    foreach (AccessRecord accessRecord in (IEnumerable<AccessRecord>) this.Items)
    {
      if (accessRecord.IsEqual(inputAccessRec))
      {
        recordByData = accessRecord;
        break;
      }
    }
    return recordByData;
  }

  internal AccessRecord GetRecordByAccessName(string strName)
  {
    AccessRecord recordByAccessName = (AccessRecord) null;
    foreach (AccessRecord accessRecord in (IEnumerable<AccessRecord>) this.Items)
    {
      if (accessRecord.Name == strName)
      {
        recordByAccessName = accessRecord;
        break;
      }
    }
    return recordByAccessName;
  }

  internal string Name => this.name;

  internal bool IsNameUnique(string strNewName, int posCurrent)
  {
    bool flag = true;
    int num = 0;
    foreach (AccessRecord accessRecord in (IEnumerable<AccessRecord>) this.Items)
    {
      if (accessRecord.Name == strNewName && posCurrent != num)
        flag = false;
      ++num;
    }
    return flag;
  }
}
