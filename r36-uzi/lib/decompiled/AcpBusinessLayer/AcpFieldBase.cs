// Decompiled with JetBrains decompiler
// Type: AcpBusinessLayer.AcpFieldBase
// Assembly: AcpBusinessLayer, Version=23.1.0.23, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 44CF2A76-4418-422B-9DDD-B27A71BAF20C
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpBusinessLayer.dll

using AcpBusinessLayer.Impl;
using AcpBusinessLayer.UndoRedo;
using AcpCommonLib;
using AcpCommonLib.UndoRedo;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Threading;

#nullable disable
namespace AcpBusinessLayer;

[Serializable]
public abstract class AcpFieldBase : IAcpField, IAcpConstraints, IAcpCommon, IComparable, IDisposable
{
  internal List<AcpFieldBase> dependentObjects;
  protected AcpFieldBase.FieldFlags flags;
  private readonly object lockObject = new object();
  private DispatcherTimer UpdateTimer = new DispatcherTimer(DispatcherPriority.ApplicationIdle);
  internal bool ValueChanged;
  private bool hasDiffs;
  private bool disposedValue;
  private bool isDisposeInProgress;

  internal abstract void DeepCopy(IAcpField source);

  internal abstract int CompareToHelper(AcpFieldBase otherField);

  internal abstract void CreateFieldData(string uiName);

  public void FlushUpdateTimer()
  {
    if (this.UpdateTimer == null)
      return;
    this.UpdateTimer.Stop();
    Delegate @delegate = (Delegate) typeof (DispatcherTimer).GetField("Tick", BindingFlags.Instance | BindingFlags.NonPublic).GetValue((object) this.UpdateTimer);
    if ((object) @delegate == null)
      return;
    foreach (Delegate invocation in @delegate.GetInvocationList())
      this.UpdateTimer.Tick -= new EventHandler(this.CustomValueTimerHandler);
  }

  private void CustomValueTimerHandler(object sender, EventArgs e)
  {
    lock (this.lockObject)
    {
      this.FirePropertyChangedEvent();
      if (this.UpdateTimer == null)
        return;
      this.UpdateTimer.Tick -= new EventHandler(this.CustomValueTimerHandler);
      this.UpdateTimer.Stop();
    }
  }

  public void SetUITimer()
  {
    lock (this.lockObject)
    {
      if (this.UpdateTimer == null)
        return;
      this.UpdateTimer.Tick += new EventHandler(this.CustomValueTimerHandler);
      this.UpdateTimer.Start();
    }
  }

  public abstract Type DataType { get; }

  protected AcpFieldBase()
  {
  }

  protected AcpFieldBase(FeatureSection parent, string name, string uiLabel)
  {
    this.Parent = (IAcpFeatureSection) parent;
    parent[uiLabel] = (IAcpField) this;
    parent[name, true] = (IAcpField) this;
    this.Name = name;
    this.flags = AcpFieldBase.FieldFlags.Editable | AcpFieldBase.FieldFlags.Visible | AcpFieldBase.FieldFlags.Valid | AcpFieldBase.FieldFlags.Applicable | AcpFieldBase.FieldFlags.ForceValid | AcpFieldBase.FieldFlags.BlockDataTransfer;
  }

  protected AcpFieldBase(
    FeatureSection parent,
    string name,
    string uiLabel,
    string[] legacyUILabels)
  {
    this.Parent = (IAcpFeatureSection) parent;
    parent[uiLabel] = (IAcpField) this;
    parent[name, true] = (IAcpField) this;
    this.Name = name;
    foreach (string legacyUiLabel in legacyUILabels)
    {
      this.LegacyUINames.Add(legacyUiLabel);
      AppInfoManager.RegisterLegacyUIName(name, legacyUiLabel);
    }
    this.flags = AcpFieldBase.FieldFlags.Editable | AcpFieldBase.FieldFlags.Visible | AcpFieldBase.FieldFlags.Valid | AcpFieldBase.FieldFlags.Applicable | AcpFieldBase.FieldFlags.ForceValid | AcpFieldBase.FieldFlags.BlockDataTransfer;
  }

  protected internal virtual void FirePropertyChangedEvent()
  {
    ((FeatureSection) this.Parent).FirePropertyChanged(this.Name + "Value");
    this.UpdateComparison();
  }

  public void UpdateComparison()
  {
    if (AppInfoManager.AppMode != ApplicationMode.CodeplugComparisonMode || AppInfoManager.BackgroundDeserializeOpertaion || !this.AllowsCompare())
      return;
    Utility.Compare((IAcpField) this, Utility.GetCompField((IAcpField) this));
  }

  protected internal virtual void FirePropertyChangingEvent()
  {
    ((FeatureSection) this.Parent).FirePropertyChanging(this.Name + "Value");
  }

  internal AcpFieldImplBase FieldData { get; set; }

  public bool Calling
  {
    get => (this.flags & AcpFieldBase.FieldFlags.InConstraint) != 0;
    set
    {
      if (value)
        this.flags |= AcpFieldBase.FieldFlags.InConstraint;
      else
        this.flags &= ~AcpFieldBase.FieldFlags.InConstraint;
    }
  }

  protected bool CallingValueSetter
  {
    get => (this.flags & AcpFieldBase.FieldFlags.InValueConstraint) != 0;
    set
    {
      if (value)
        this.flags |= AcpFieldBase.FieldFlags.InValueConstraint;
      else
        this.flags &= ~AcpFieldBase.FieldFlags.InValueConstraint;
    }
  }

  public bool SlaveRecRef
  {
    get => (this.flags & AcpFieldBase.FieldFlags.SlaveRecRef) != 0;
    set
    {
      if (value)
        this.flags |= AcpFieldBase.FieldFlags.SlaveRecRef;
      else
        this.flags &= ~AcpFieldBase.FieldFlags.SlaveRecRef;
    }
  }

  public bool EvaluateRecRefs
  {
    get => (this.flags & AcpFieldBase.FieldFlags.EvaluateRecRefs) != 0;
    set
    {
      if (value)
        this.flags |= AcpFieldBase.FieldFlags.EvaluateRecRefs;
      else
        this.flags &= ~AcpFieldBase.FieldFlags.EvaluateRecRefs;
    }
  }

  public bool Valid
  {
    get => (this.flags & AcpFieldBase.FieldFlags.Valid) != 0;
    set
    {
      if (value != this.Valid)
      {
        if (value)
        {
          this.flags |= AcpFieldBase.FieldFlags.Valid;
          if (!AppInfoManager.DragOperation && !AppInfoManager.BackgroundDeserializeOpertaion)
          {
            AppInfoManager.InvalidFieldsReport.UnregisterFieldInReport((IAcpField) this);
            AppInfoManager.InvalidFieldsReport.PostFieldsReport();
          }
        }
        else if (this.Applicable || !this.ForceValid)
        {
          this.flags &= ~AcpFieldBase.FieldFlags.Valid;
          if (!AppInfoManager.DragOperation && !AppInfoManager.BackgroundDeserializeOpertaion)
          {
            AppInfoManager.InvalidFieldsReport.RegisterFieldInReport((IAcpField) this, string.Empty, true);
            AppInfoManager.InvalidFieldsReport.PostFieldsReport();
          }
        }
        ((FeatureSection) this.Parent).FirePropertyChanged(this.Name + "_Valid");
      }
      else
      {
        if (value || !this.ValueChanged || AppInfoManager.DragOperation || AppInfoManager.BackgroundDeserializeOpertaion)
          return;
        AppInfoManager.InvalidFieldsReport.UnregisterFieldInReport((IAcpField) this);
        AppInfoManager.InvalidFieldsReport.RegisterFieldInReport((IAcpField) this, string.Empty, true);
        AppInfoManager.InvalidFieldsReport.PostFieldsReport();
      }
    }
  }

  public bool Editable
  {
    get => (this.flags & AcpFieldBase.FieldFlags.Editable) != 0;
    set
    {
      if (value)
        this.flags |= AcpFieldBase.FieldFlags.Editable;
      else
        this.flags &= ~AcpFieldBase.FieldFlags.Editable;
      ((FeatureSection) this.Parent).FirePropertyChanged(this.Name + "_Editable");
    }
  }

  public bool Visible
  {
    get => (this.flags & AcpFieldBase.FieldFlags.Visible) != 0;
    set
    {
      if (value)
        this.flags |= AcpFieldBase.FieldFlags.Visible;
      else
        this.flags &= ~AcpFieldBase.FieldFlags.Visible;
      ((FeatureSection) this.Parent).FirePropertyChanged(this.Name + "_Visible");
    }
  }

  internal bool ForceValid
  {
    get => (this.flags & AcpFieldBase.FieldFlags.ForceValid) != 0;
    set
    {
      if (value == this.ForceValid && value)
        return;
      if (value)
        this.flags |= AcpFieldBase.FieldFlags.ForceValid;
      else
        this.flags &= ~AcpFieldBase.FieldFlags.ForceValid;
      this.Valid = value;
    }
  }

  public bool Applicable
  {
    get => (this.flags & AcpFieldBase.FieldFlags.Applicable) != 0;
    set
    {
      if (value)
      {
        this.flags |= AcpFieldBase.FieldFlags.Applicable;
      }
      else
      {
        this.flags &= ~AcpFieldBase.FieldFlags.Applicable;
        if (this.ForceValid)
          this.Valid = true;
      }
      ((FeatureSection) this.Parent).FirePropertyChanged(this.Name + "_Applicable");
    }
  }

  public bool TieredOut
  {
    get => this.FieldData.TieredOut;
    set => this.FieldData.TieredOut = value;
  }

  public bool DefaultSetByTiering
  {
    get => this.FieldData.DefaultSetByTiering;
    set => this.FieldData.DefaultSetByTiering = value;
  }

  public bool HiddenStatic
  {
    get => (this.flags & AcpFieldBase.FieldFlags.HiddenStatic) != 0;
    set
    {
      if (value)
      {
        this.flags |= AcpFieldBase.FieldFlags.HiddenStatic;
        if (!AppInfoManager.InvalidFieldsReport.ContainsUIField((IAcpField) this))
          return;
        AppInfoManager.InvalidFieldsReport.UnregisterFieldInUIReport((IAcpField) this);
        AppInfoManager.InvalidFieldsReport.FieldsReportChanged = true;
      }
      else
        this.flags &= ~AcpFieldBase.FieldFlags.HiddenStatic;
    }
  }

  public bool HiddenDynamic
  {
    get => (this.flags & AcpFieldBase.FieldFlags.HiddenDynamic) != 0;
    set
    {
      if (value)
        this.flags |= AcpFieldBase.FieldFlags.HiddenDynamic;
      else
        this.flags &= ~AcpFieldBase.FieldFlags.HiddenDynamic;
    }
  }

  public bool HiddenDynamicByApp
  {
    get => (this.flags & AcpFieldBase.FieldFlags.HiddenDynamicByApp) != 0;
    set
    {
      if (value)
        this.flags |= AcpFieldBase.FieldFlags.HiddenDynamicByApp;
      else
        this.flags &= ~AcpFieldBase.FieldFlags.HiddenDynamicByApp;
    }
  }

  public bool CustomViewVisibility
  {
    get => this.FieldData.CustomViewVisibility;
    set => this.FieldData.CustomViewVisibility = value;
  }

  public bool BlockDataTransfer
  {
    get => (this.flags & AcpFieldBase.FieldFlags.BlockDataTransfer) != 0;
    internal set
    {
      if (value)
        this.flags |= AcpFieldBase.FieldFlags.BlockDataTransfer;
      else
        this.flags &= ~AcpFieldBase.FieldFlags.BlockDataTransfer;
    }
  }

  public bool UIInvalid
  {
    get => (this.flags & AcpFieldBase.FieldFlags.InvalidUIValue) != 0;
    set
    {
      if (value)
        this.flags |= AcpFieldBase.FieldFlags.InvalidUIValue;
      else
        this.flags &= ~AcpFieldBase.FieldFlags.InvalidUIValue;
    }
  }

  public bool DnDDone
  {
    get => (this.flags & AcpFieldBase.FieldFlags.DnDDone) != 0;
    set
    {
      if (value)
        this.flags |= AcpFieldBase.FieldFlags.DnDDone;
      else
        this.flags &= ~AcpFieldBase.FieldFlags.DnDDone;
    }
  }

  public bool UnsupportedValue
  {
    get => (this.flags & AcpFieldBase.FieldFlags.UnsupportedValue) != 0;
    set
    {
      if (value)
        this.flags |= AcpFieldBase.FieldFlags.UnsupportedValue;
      else
        this.flags &= ~AcpFieldBase.FieldFlags.UnsupportedValue;
    }
  }

  public bool ValidateAcrossRecset
  {
    get => (this.flags & AcpFieldBase.FieldFlags.AcrossRecset) != 0;
    set
    {
      this.flags |= AcpFieldBase.FieldFlags.AcrossRecset;
      if (this.Parent == null || this.Parent.ParentRecset == null)
        return;
      ((Recordset) this.Parent.ParentRecset).MustCalculateValidityAcross = true;
    }
  }

  public virtual StateConstraint IsValid
  {
    get => this.FieldData.IsValid;
    set
    {
      ((FeatureNode) this.Parent.Parent).RegisterValidity((IAcpField) this);
      this.FieldData.IsValid = value;
    }
  }

  public StateConstraint IsApplicable
  {
    get => this.FieldData.IsApplicable;
    set
    {
      ((FeatureNode) this.Parent.Parent).RegisterApplicability((IAcpField) this);
      this.FieldData.IsApplicable = value;
    }
  }

  public abstract UndoableTask CopyValueOf(IAcpField source);

  public abstract UndoableTask CopyValue(object sourcevalue);

  public bool AddDependentObject(IAcpField obj)
  {
    bool flag = false;
    if (this.Parent.Parent == obj.Parent.Parent)
      return false;
    if (this.dependentObjects == null)
      this.dependentObjects = new List<AcpFieldBase>();
    AcpFieldBase acpFieldBase = (AcpFieldBase) obj;
    if (!this.dependentObjects.Contains(acpFieldBase))
    {
      this.dependentObjects.Add(acpFieldBase);
      flag = true;
    }
    return flag;
  }

  public string Name
  {
    get => this.FieldData.Name;
    internal set => this.FieldData.Name = value;
  }

  public bool Protected
  {
    get => this.FieldData.Protected;
    set
    {
      this.FieldData.Protected = value;
      if (!value)
        return;
      ((FeatureNode) this.Parent.Parent).RegisterEditability((IAcpField) this);
      ((FeatureNode) this.Parent.Parent).RegisterValidity((IAcpField) this);
    }
  }

  public bool DisableASKRangeValidation
  {
    get => (this.flags & AcpFieldBase.FieldFlags.DisableASKRangeValidation) != 0;
    set
    {
      if (value)
        this.flags |= AcpFieldBase.FieldFlags.DisableASKRangeValidation;
      else
        this.flags &= ~AcpFieldBase.FieldFlags.DisableASKRangeValidation;
    }
  }

  public bool NotifyPropertyChanging
  {
    get => (this.flags & AcpFieldBase.FieldFlags.NotifyPropertyChanging) != 0;
    set
    {
      if (value)
        this.flags |= AcpFieldBase.FieldFlags.NotifyPropertyChanging;
      else
        this.flags &= ~AcpFieldBase.FieldFlags.NotifyPropertyChanging;
    }
  }

  public string UIName => this.FieldData.UIName;

  public ISet<string> LegacyUINames => this.FieldData.LegacyUINames;

  public string NewUiExpanderAndName
  {
    get => this.FieldData.NewUiExpanderAndName;
    set => this.FieldData.NewUiExpanderAndName = value;
  }

  public IAcpFeatureSection Parent { get; set; }

  public string NewUIExpanderName
  {
    get
    {
      if (string.IsNullOrEmpty(this.NewUiExpanderAndName))
        return (string) null;
      return this.NewUiExpanderAndName.Split('\\')[0];
    }
  }

  public string NewUIName
  {
    get
    {
      if (!string.IsNullOrEmpty(this.NewUiExpanderAndName))
      {
        string[] strArray1 = this.NewUiExpanderAndName.Split('\\');
        if (strArray1.Length == 3)
        {
          string[] strArray2 = this.UIName.Split('\\');
          return strArray2.Length == 2 ? $"{strArray1[1]}\\{strArray2[1]}" : $"{strArray1[1]}\\{strArray2[0]}";
        }
      }
      return (string) null;
    }
  }

  public IAcpFeatureSection NewParent
  {
    get
    {
      if (this.Parent != null && this.Parent.Parent != null && !string.IsNullOrEmpty(this.NewUiExpanderAndName))
      {
        foreach (IAcpFeatureSection featureSections in this.Parent.Parent.FeatureSectionsCollection)
        {
          if (featureSections.UIName == this.NewUIExpanderName)
            return featureSections;
        }
      }
      return (IAcpFeatureSection) null;
    }
  }

  public abstract void ResetToDefault();

  public abstract void ResetToDefaultWithUndo();

  public abstract void ResetToDefaultWithUndo(ContainerTask taskContainer);

  public abstract void ParseValueFrom(string value);

  public abstract void ParseDefaultValueFrom(string value);

  public void CalculateValidityAcrossRecset()
  {
    if (this.Parent.ParentRecset == null)
      return;
    ((Recordset) this.Parent.ParentRecset).CalculateValidityAcrossFor(this.Parent.FeatureSectionId, this.UIName);
  }

  public bool IgnoreOnCompare
  {
    get => this.FieldData.IgnoreOnCompare;
    set => this.FieldData.IgnoreOnCompare = value;
  }

  public bool IgnoreOnPrint
  {
    get => this.FieldData.IgnoreOnPrint;
    set => this.FieldData.IgnoreOnPrint = value;
  }

  public bool IsMasked
  {
    get => this.FieldData.IsMasked;
    set => this.FieldData.IsMasked = value;
  }

  public IAcpFeatureNode ParentNode
  {
    get => this.Parent != null ? this.Parent.Parent : (IAcpFeatureNode) null;
  }

  public bool _HasDiffs
  {
    get => this.hasDiffs;
    set
    {
      if (!this.hasDiffs & value)
      {
        this.hasDiffs = true;
        if (!string.IsNullOrEmpty(this.NewUiExpanderAndName))
        {
          if (this.Parent.Parent == null)
            return;
          foreach (IAcpFeatureSection featureSections in this.Parent.Parent.FeatureSectionsCollection)
          {
            if (this.NewParent != null && featureSections == this.NewParent)
            {
              ((FeatureSection) featureSections).DiffCount.Increment(this.Name);
              if (featureSections == this.Parent)
                break;
              ((FeatureSection) this.Parent).FirePropertyChanged(this.Name + nameof (_HasDiffs));
              break;
            }
          }
        }
        else
          ((FeatureSection) this.Parent).DiffCount.Increment(this.Name);
      }
      else
      {
        if (!this.hasDiffs || value)
          return;
        this.hasDiffs = false;
        if (!string.IsNullOrEmpty(this.NewUiExpanderAndName))
        {
          if (this.Parent.Parent == null)
            return;
          foreach (IAcpFeatureSection featureSections in this.Parent.Parent.FeatureSectionsCollection)
          {
            if (this.NewParent != null && featureSections == this.NewParent)
            {
              if (((FeatureSection) featureSections).DiffCount.Value > 0)
                ((FeatureSection) featureSections).DiffCount.Decrement(this.Name);
              else
                ((FeatureSection) featureSections).FirePropertyChanged("HasDiffs");
              if (featureSections == this.Parent)
                break;
              ((FeatureSection) this.Parent).FirePropertyChanged(this.Name + nameof (_HasDiffs));
              break;
            }
          }
        }
        else
          ((FeatureSection) this.Parent).DiffCount.Decrement(this.Name);
      }
    }
  }

  public bool KeyNameField
  {
    get => this.FieldData.KeyNameField;
    set => this.FieldData.KeyNameField = value;
  }

  public StateConstraint IsVisible
  {
    get => this.FieldData.IsVisible;
    set
    {
      ((FeatureNode) this.Parent.Parent).RegisterVisibility((IAcpField) this);
      this.FieldData.IsVisible = value;
    }
  }

  public StateConstraint IsEditable
  {
    get => this.FieldData.IsEditable;
    set
    {
      ((FeatureNode) this.Parent.Parent).RegisterEditability((IAcpField) this);
      this.FieldData.IsEditable = value;
    }
  }

  public ValueSetterConstraint ValueSetter
  {
    get => this.FieldData.ValueSetter;
    set
    {
      if (this.FieldData.ValueSetter == null)
      {
        this.FieldData.ValueSetter = value;
      }
      else
      {
        bool flag = false;
        foreach (Delegate invocation in this.FieldData.ValueSetter.GetInvocationList())
        {
          if (invocation.Method == value.Method)
          {
            flag = true;
            break;
          }
        }
        if (flag)
          return;
        this.FieldData.ValueSetter += value;
      }
    }
  }

  internal void SetSecurityValueSetter(ValueSetterConstraint valueSetter)
  {
    this.FieldData.ValueSetter += valueSetter;
  }

  internal virtual void ValidityHelper()
  {
    if (AcpDocument.PageOnLoading)
    {
      StateConstraint isValid = this.IsValid;
      bool flag = false;
      if (isValid != null && isValid.Method != (MethodInfo) null)
      {
        foreach (object customAttribute in isValid.Method.GetCustomAttributes(true))
        {
          if (customAttribute != null && customAttribute.ToString().Equals("ConstraintHelper.TriggerValidOnLoading"))
            flag = true;
        }
      }
      if (!flag)
        return;
    }
    bool flag1 = AcpConstraints.AcpValidilityRules((IAcpField) this);
    if (this.IsValid != null)
    {
      ((FeatureSection) this.Parent).CurrentField = (IAcpField) this;
      this.Valid = this.Applicable & flag1 && this.IsValid(this.Parent);
    }
    else
      this.Valid = flag1;
  }

  internal abstract string ValueString { get; }

  internal abstract void ParseValueHelper(string value);

  protected virtual void VisibilityHelper()
  {
  }

  public void CalculateValidityWithDep()
  {
    if (this.Calling || AcpDocument.Closing)
      return;
    this.Calling = true;
    if (this.ForceValid)
      this.ValidityHelper();
    if (this.dependentObjects != null)
    {
      foreach (AcpFieldBase dependentObject in this.dependentObjects)
      {
        dependentObject.CalculateApplicability();
        dependentObject.CalculateValidity();
      }
    }
    if (this.EvaluateRecRefs)
      ((FeatureNode) this.Parent.Parent).InvokeRecRefValidities();
    this.Calling = false;
  }

  public virtual void CalculateValidity()
  {
    if (AcpDocument.Closing || !this.ForceValid || !this.Applicable)
      return;
    this.ValidityHelper();
  }

  public virtual void CalculateApplicability()
  {
    if (this.IsApplicable == null || AcpDocument.Closing)
      return;
    ((FeatureSection) this.Parent).CurrentField = (IAcpField) this;
    this.Applicable = this.IsApplicable(this.Parent);
  }

  public void CalculateVisibility()
  {
    if (AcpDocument.Closing)
      return;
    this.VisibilityHelper();
    bool flag1 = AcpConstraints.AcpVisibilityRules(this);
    if (this.IsVisible != null && AppInfoManager.AppMode != ApplicationMode.CustomViewConfigurationMode)
    {
      ((FeatureSection) this.Parent).CurrentField = (IAcpField) this;
      bool flag2 = this.IsVisible(this.Parent);
      this.HiddenDynamicByApp = !flag2;
      this.Visible = flag1 & flag2;
    }
    else
      this.Visible = flag1;
  }

  public void CalculateEditability()
  {
    if (AcpDocument.Closing)
      return;
    bool flag = AcpConstraints.AcpEditabilityRules(this);
    if (this.IsEditable != null)
    {
      ((FeatureSection) this.Parent).CurrentField = (IAcpField) this;
      if (this.IsEditable == new StateConstraint(AcpConstraints.AcpAlwaysEditable))
        this.Editable = this.IsEditable(this.Parent);
      else
        this.Editable = flag && this.IsEditable(this.Parent);
    }
    else
      this.Editable = flag;
  }

  public void CallConstraints()
  {
    if (AcpDocument.Closing || AcpDocument.PageOnLoading)
      return;
    if (this.IsVisible != null)
      this.CalculateVisibility();
    if (this.IsEditable != null)
      this.CalculateEditability();
    this.CalculateApplicability();
    if (this.ValidateAcrossRecset)
      this.CalculateValidityAcrossRecset();
    else
      this.CalculateValidity();
  }

  internal void CallConstraintsX()
  {
    if (this.Calling || AcpDocument.Closing)
      return;
    this.Calling = true;
    this.Parent.Parent.CallConstraints();
    this.Calling = false;
    this.CalculateValidityWithDep();
    if (!this.ValidateAcrossRecset)
      return;
    this.CalculateValidityAcrossRecset();
  }

  public string Path(string delimiter)
  {
    if (!string.IsNullOrEmpty(this.NewUiExpanderAndName) && this.NewParent != null)
      return this.NewParent.Path(delimiter) + delimiter + this.NewUIName;
    return this.Parent != null ? this.Parent.Path(delimiter) + delimiter + this.UIName : this.UIName;
  }

  public void CalculateVisibility(bool allFields) => throw new NotImplementedException();

  public void CalculateEditability(bool allFields) => throw new NotImplementedException();

  public DifferentiatedUserViewType DifferentiatedUserView
  {
    get => this.FieldData.DifferentiatedUserView;
    set => this.FieldData.DifferentiatedUserView = value;
  }

  public int GuiVersion
  {
    get => this.FieldData.GuiVersion;
    set => this.FieldData.GuiVersion = value;
  }

  public int DataTransferOrder
  {
    get => this.FieldData.DataTransferOrder;
    set
    {
      this.FieldData.DataTransferOrder = value;
      ((FeatureSection) this.Parent).RegisterForDataTransfer(this, value);
      if (value > 0)
        this.BlockDataTransfer = false;
      else
        this.BlockDataTransfer = true;
    }
  }

  public int FieldId
  {
    get => this.FieldData.FieldId;
    set => this.FieldData.FieldId = value;
  }

  public void RepairRecRefs()
  {
  }

  internal virtual void CallValueSetter(ContainerTask containerTask)
  {
  }

  public int CompareTo(object obj) => this.CompareToHelper(obj as AcpFieldBase);

  internal IEnumerable<IAcpField> GetAllDependents()
  {
    AcpFieldBase acpFieldBase = this;
    if (acpFieldBase.dependentObjects != null)
    {
      foreach (AcpFieldBase dep in acpFieldBase.dependentObjects)
      {
        if (dep == acpFieldBase)
          yield return (IAcpField) dep;
        IEnumerator<IAcpField> enumerator = dep.GetAllDependents().GetEnumerator();
        try
        {
          while (true)
          {
            if (enumerator.MoveNext())
            {
              AcpFieldBase current = (AcpFieldBase) enumerator.Current;
              if (dep != current)
                yield return (IAcpField) current;
              else
                break;
            }
            else
              goto label_16;
          }
        }
        finally
        {
          enumerator?.Dispose();
        }
        break;
label_16:
        enumerator = (IEnumerator<IAcpField>) null;
      }
    }
  }

  private void TraceDependencies()
  {
    if (this.dependentObjects == null)
      return;
    List<IAcpField> acpFieldList = new List<IAcpField>();
    bool flag = false;
    acpFieldList.Add((IAcpField) this);
    foreach (AcpFieldBase allDependent in this.GetAllDependents())
    {
      acpFieldList.Add((IAcpField) allDependent);
      flag = this == allDependent;
    }
    if (!flag || acpFieldList.Count <= 2)
      return;
    foreach (IAcpField acpField in acpFieldList)
      ;
  }

  internal int GetFlags() => (int) this.flags;

  internal virtual UndoableTask CreateSetValueTask(string newValue)
  {
    SetValueTask task = new SetValueTask(this, newValue);
    if (this.ValueSetter == null)
      return (UndoableTask) task;
    ContainerTask containerTask = new ContainerTask(task.ToString());
    containerTask.AddTask((UndoableTask) task);
    this.CallValueSetter(containerTask);
    return (UndoableTask) containerTask;
  }

  public bool AllowsCompare()
  {
    AcpFieldBase acpFieldBase = this;
    return !acpFieldBase.HiddenStatic && !acpFieldBase.IgnoreOnCompare && !(acpFieldBase is IAcpPointerField);
  }

  public bool AllowsDataTransfer()
  {
    AcpFieldBase acpFieldBase = this;
    return acpFieldBase.Editable && !acpFieldBase.HiddenStatic && !acpFieldBase.BlockDataTransfer && !(acpFieldBase is IAcpPointerField);
  }

  public bool AllowsCopy()
  {
    AcpFieldBase acpFieldBase = this;
    return acpFieldBase.AllowsDataTransfer() && !(acpFieldBase is AcpKeyField);
  }

  public bool AllowsRestore()
  {
    AcpFieldBase acpFieldBase = this;
    AcpListField acpListField = acpFieldBase as AcpListField;
    bool flag = false;
    if (acpListField != null && acpListField.SerializeItems)
      flag = true;
    return acpFieldBase.AllowsCopy() && !flag;
  }

  public bool AllowFillUpFillDown()
  {
    AcpFieldBase acpFieldBase = this;
    if (AppInfoManager.AppMode == ApplicationMode.CodeplugComparisonMode && acpFieldBase.KeyNameField)
      return false;
    switch (acpFieldBase)
    {
      case AcpKeyField _:
      case AcpNumericKeyField _:
      case IAcpPointerField _:
      case AcpVoiceFileField _:
        return false;
      default:
        return true;
    }
  }

  protected virtual void Dispose(bool disposing)
  {
    lock (this.lockObject)
    {
      if (this.isDisposeInProgress)
        return;
      if (!this.disposedValue)
      {
        if (disposing)
        {
          this.isDisposeInProgress = true;
          this.FlushUpdateTimer();
          this.UpdateTimer = (DispatcherTimer) null;
        }
        this.disposedValue = true;
      }
      this.isDisposeInProgress = false;
    }
  }

  public void Dispose()
  {
    this.Dispose(true);
    GC.SuppressFinalize((object) this);
  }

  [Flags]
  protected internal enum FieldFlags
  {
    None = 0,
    Attached = 1,
    Editable = 2,
    Visible = 4,
    Valid = 8,
    Applicable = 16, // 0x00000010
    InConstraint = 32, // 0x00000020
    SecurityEditable = 64, // 0x00000040
    ShowLeadingZeros = 128, // 0x00000080
    ForceValid = 256, // 0x00000100
    ShowHexValue = 512, // 0x00000200
    HiddenStatic = 1024, // 0x00000400
    HiddenDynamic = 2048, // 0x00000800
    CustomViewVisibility = 4096, // 0x00001000
    BlockDataTransfer = 8192, // 0x00002000
    HasSpecialRange = 16384, // 0x00004000
    InvalidUIValue = 32768, // 0x00008000
    DnDDone = 65536, // 0x00010000
    AcrossRecset = 131072, // 0x00020000
    EvaluateRecRefs = 262144, // 0x00040000
    SlaveRecRef = 524288, // 0x00080000
    InValueConstraint = 1048576, // 0x00100000
    HiddenDynamicByApp = 2097152, // 0x00200000
    UnsupportedValue = 4194304, // 0x00400000
    DisableASKRangeValidation = 8388608, // 0x00800000
    SkipValidation = 16777216, // 0x01000000
    NotifyPropertyChanging = 33554432, // 0x02000000
  }
}
