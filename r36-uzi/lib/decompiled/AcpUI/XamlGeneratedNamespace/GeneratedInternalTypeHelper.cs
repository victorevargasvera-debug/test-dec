// Decompiled with JetBrains decompiler
// Type: XamlGeneratedNamespace.GeneratedInternalTypeHelper
// Assembly: AcpUI, Version=23.1.0.32, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: DC7F6A15-37A6-4183-BF9F-09213F636FB6
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpUI.dll

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Windows.Markup;

#nullable disable
namespace XamlGeneratedNamespace;

[DebuggerNonUserCode]
[GeneratedCode("PresentationBuildTasks", "8.0.3.0")]
[EditorBrowsable(EditorBrowsableState.Never)]
public sealed class GeneratedInternalTypeHelper : InternalTypeHelper
{
  protected override object CreateInstance(Type type, CultureInfo culture)
  {
    return Activator.CreateInstance(type, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.CreateInstance, (Binder) null, (object[]) null, culture);
  }

  protected override object GetPropertyValue(
    PropertyInfo propertyInfo,
    object target,
    CultureInfo culture)
  {
    return propertyInfo.GetValue(target, BindingFlags.Default, (Binder) null, (object[]) null, culture);
  }

  protected override void SetPropertyValue(
    PropertyInfo propertyInfo,
    object target,
    object value,
    CultureInfo culture)
  {
    propertyInfo.SetValue(target, value, BindingFlags.Default, (Binder) null, (object[]) null, culture);
  }

  protected override Delegate CreateDelegate(Type delegateType, object target, string handler)
  {
    return (Delegate) target.GetType().InvokeMember("_CreateDelegate", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.InvokeMethod, (Binder) null, target, new object[2]
    {
      (object) delegateType,
      (object) handler
    }, (CultureInfo) null);
  }

  protected override void AddEventHandler(EventInfo eventInfo, object target, Delegate handler)
  {
    eventInfo.AddEventHandler(target, handler);
  }
}
