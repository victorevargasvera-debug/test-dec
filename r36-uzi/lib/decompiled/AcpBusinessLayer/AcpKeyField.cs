// Decompiled with JetBrains decompiler
// Type: AcpBusinessLayer.AcpKeyField
// Assembly: AcpBusinessLayer, Version=23.1.0.23, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 44CF2A76-4418-422B-9DDD-B27A71BAF20C
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpBusinessLayer.dll

using AcpBusinessLayer.UndoRedo;
using AcpCommonLib;
using AcpCommonLib.UndoRedo;
using AcpCommonResources;
using AcpUtility;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

#nullable disable
namespace AcpBusinessLayer;

[Serializable]
public class AcpKeyField : AcpStringField
{
  private List<AcpRecRefField> referencingFields;
  private bool disposedValue;
  private bool isDisposeInProgress;

  public ReadOnlyCollection<AcpRecRefField> ReferencingFields
  {
    get
    {
      return this.referencingFields != null ? this.referencingFields.AsReadOnly() : (ReadOnlyCollection<AcpRecRefField>) null;
    }
  }

  public IEnumerable<FeatureNode> ReferencingNodes
  {
    get
    {
      if (this.referencingFields != null)
      {
        foreach (AcpFieldBase referencingField in this.referencingFields)
          yield return referencingField.Parent.Parent as FeatureNode;
      }
    }
  }

  public AcpKeyField(FeatureSection parent, string name, string uiLabel)
    : this(parent, name, uiLabel, int.MaxValue)
  {
  }

  public AcpKeyField(FeatureSection parent, string name, string uiLabel, string[] legacyUILabels)
    : this(parent, name, uiLabel, int.MaxValue, legacyUILabels)
  {
  }

  public AcpKeyField(FeatureSection parent, string name, string uiLabel, int maxLength)
    : base(parent, name, uiLabel, maxLength)
  {
  }

  public AcpKeyField(
    FeatureSection parent,
    string name,
    string uiLabel,
    int maxLength,
    string[] legacyUILabels)
    : base(parent, name, uiLabel, maxLength, legacyUILabels)
  {
  }

  internal void AddRecordReference(AcpRecRefField field)
  {
    if (this.referencingFields == null)
      this.referencingFields = new List<AcpRecRefField>();
    if (this.referencingFields.Contains(field))
      return;
    this.referencingFields.Add(field);
  }

  internal void RemoveRecordReference(AcpRecRefField field)
  {
    if (this.referencingFields == null || !this.referencingFields.Contains(field))
      return;
    this.referencingFields.Remove(field);
  }

  internal string DisplayText => this.Value;

  public bool IsReferenced => this.referencingFields != null && this.referencingFields.Count > 0;

  public override string Value
  {
    get => base.Value;
    set
    {
      if (value == null || !(this.Value != value))
        return;
      if (value.Length == 0)
        this.SetUITimer();
      else if (this.Parent.ParentRecset is Recordset parentRecset && !AppInfoManager.DndOperation && !AppInfoManager.ImportCopyOperation && !AppInfoManager.UnpackOperation && parentRecset.CheckKeyFieldForDup(value))
      {
        AppInfoManager.StatusMsgReport.PostMessage(StatusMsgType.Error, AcpResources.Duplicate_Msg.AcpStringFormat((object) this.UIName));
        this.SetUITimer();
      }
      else if (UndoManager.MarkForUndo)
      {
        UndoableTask task = (UndoableTask) new ModifyDataTask<string>((AcpField<string>) this, value);
        if (this.ValueSetter != null)
        {
          ContainerTask containerTask = new ContainerTask(task.ToString());
          containerTask.AddTask(task);
          this.CallValueSetter(containerTask);
          UndoManager.AddTask((UndoableTask) containerTask);
        }
        else
          UndoManager.AddTask(task);
      }
      else if (parentRecset == null)
      {
        base.Value = value;
      }
      else
      {
        FeatureNode parent = this.Parent.Parent as FeatureNode;
        string referenceKey = parent.ReferenceKey;
        bool oldKeyPresent = this.PreKeyMapUpdate();
        base.Value = value;
        if (oldKeyPresent)
          parentRecset.ValidateReferenceKey(referenceKey);
        string str = parent.ReferenceKey;
        if (parentRecset.RecsetId == 2300)
          str = System.IO.Path.GetFileNameWithoutExtension(str);
        if (parentRecset.KeysToNode.Contains(str))
          this.ForceValid = false;
        this.PostKeyMapUpdate(referenceKey, oldKeyPresent);
        this.ForceValid &= value.Length <= this.MaxLength;
      }
    }
  }

  internal void NodeDeleted()
  {
    if (this.referencingFields == null)
      return;
    for (int index = this.referencingFields.Count - 1; index >= 0; --index)
    {
      AcpRecRefField referencingField = this.referencingFields[index];
      if (referencingField.ReferencedNode != null)
      {
        if (referencingField.Applicable)
          referencingField.CalculateApplicability();
        referencingField.ReferencedNodeDeleted();
      }
      this.referencingFields.Remove(referencingField);
    }
  }

  internal override void DeepCopy(IAcpField source)
  {
    if (!((FeatureNode) this.ParentNode).bAddCurrentOnParent)
      return;
    base.DeepCopy(source);
  }

  protected override void Dispose(bool disposing)
  {
    if (this.isDisposeInProgress)
      return;
    if (!this.disposedValue)
    {
      if (disposing)
        this.isDisposeInProgress = true;
      this.disposedValue = true;
    }
    this.isDisposeInProgress = false;
    base.Dispose(disposing);
  }
}
