// Decompiled with JetBrains decompiler
// Type: AcpBusinessLayer.UndoRedo.ChangePermissionsTask
// Assembly: AcpBusinessLayer, Version=23.1.0.23, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 44CF2A76-4418-422B-9DDD-B27A71BAF20C
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpBusinessLayer.dll

using AcpCommonLib;
using AcpCommonLib.UndoRedo;

#nullable disable
namespace AcpBusinessLayer.UndoRedo;

public class ChangePermissionsTask : UndoableTask
{
  private Permissions oldPermissions;
  private Permissions newPermissions;
  private IAcpRecordset recordset;
  private IAcpFeatureNode featureNode;

  public ChangePermissionsTask(IAcpRecordset recordset, Permissions newValue)
  {
    this.recordset = recordset;
    if (recordset != null)
      this.oldPermissions = this.recordset.Permissions;
    this.newPermissions = newValue;
  }

  public ChangePermissionsTask(IAcpFeatureNode featureNode, Permissions newValue)
  {
    this.featureNode = featureNode;
    if (this.featureNode != null)
      this.oldPermissions = this.featureNode.Permissions;
    this.newPermissions = newValue;
  }

  public override void Do()
  {
    if (this.recordset != null)
      this.recordset.Permissions = this.newPermissions;
    if (this.featureNode != null)
      this.featureNode.Permissions = this.newPermissions;
    base.Do();
  }

  public override void Undo()
  {
    if (this.recordset != null)
      this.recordset.Permissions = this.oldPermissions;
    if (this.featureNode != null)
      this.featureNode.Permissions = this.oldPermissions;
    base.Undo();
  }

  public override void LaunchUI()
  {
    if (this.recordset == null || !this.recordset.IsEmbeddedRecset)
      return;
    UndoManager.GoToSection(this.recordset.ParentSection);
  }
}
