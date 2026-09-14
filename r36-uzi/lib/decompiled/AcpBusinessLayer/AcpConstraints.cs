// Decompiled with JetBrains decompiler
// Type: AcpBusinessLayer.AcpConstraints
// Assembly: AcpBusinessLayer, Version=23.1.0.23, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 44CF2A76-4418-422B-9DDD-B27A71BAF20C
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpBusinessLayer.dll

using AcpCommonLib;

#nullable disable
namespace AcpBusinessLayer;

public static class AcpConstraints
{
  internal static bool AcpVisibilityRules(AcpFieldBase self)
  {
    self.HiddenDynamic = false;
    self.HiddenStatic = false;
    if (self.TieredOut || self.GuiVersion > AppInfoManager.GuiVersion)
    {
      self.HiddenStatic = true;
      return false;
    }
    if (AppInfoManager.AppView == DifferentiatedUserViewType.Custom && !self.CustomViewVisibility)
    {
      if (self.DifferentiatedUserView <= DifferentiatedUserViewType.Secret)
        self.HiddenDynamic = true;
      else if (AppInfoManager.AppType == ApplicationType.DEPOT && self.DifferentiatedUserView == DifferentiatedUserViewType.Depot)
        self.HiddenDynamic = true;
      else if (AppInfoManager.AppType == ApplicationType.LABTOOL && self.DifferentiatedUserView == DifferentiatedUserViewType.Labtool)
        self.HiddenDynamic = true;
      else
        self.HiddenStatic = true;
      return false;
    }
    if (self.DifferentiatedUserView <= AppInfoManager.AppView)
      return true;
    if (self.DifferentiatedUserView <= DifferentiatedUserViewType.Secret)
      self.HiddenDynamic = true;
    else if (AppInfoManager.AppType == ApplicationType.DEPOT && self.DifferentiatedUserView == DifferentiatedUserViewType.Depot)
      self.HiddenDynamic = true;
    else if (AppInfoManager.AppType == ApplicationType.LABTOOL && self.DifferentiatedUserView == DifferentiatedUserViewType.Labtool)
      self.HiddenDynamic = true;
    else
      self.HiddenStatic = true;
    return false;
  }

  internal static bool AcpEditabilityRules(AcpFieldBase self)
  {
    bool flag = true;
    AcpFieldBase self1 = self;
    if (self1 != null && self1.Protected && AcpConstraints.IsPermissionGranted != null)
      flag = AcpConstraints.IsPermissionGranted((IAcpField) self1);
    return flag;
  }

  public static bool AcpAlwaysNonEditable(IAcpFeatureSection self) => false;

  internal static bool AcpAlwaysEditable(IAcpFeatureSection self) => true;

  internal static bool AcpAlwaysInvisible(IAcpFeatureSection self) => false;

  internal static bool AcpValidilityRules(IAcpField self)
  {
    bool flag = true;
    if (self is AcpFieldBase self1 && self1.Protected && AcpConstraints.IsValuePermitted != null)
      flag = AcpConstraints.IsValuePermitted((IAcpField) self1);
    return flag;
  }

  public static InternalConstraint IsPermissionGranted { get; set; }

  public static InternalConstraint IsValuePermitted { get; set; }
}
