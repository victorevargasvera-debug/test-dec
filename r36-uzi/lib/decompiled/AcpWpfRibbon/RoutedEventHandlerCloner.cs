// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfRibbon.RoutedEventHandlerCloner
// Assembly: AcpWpfRibbon, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 45A745B5-88C3-40EE-B1E5-8DBA2EACD529
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfRibbon.dll

using System;
using System.Reflection;
using System.Windows;

#nullable disable
namespace DevComponents.WpfRibbon;

internal static class RoutedEventHandlerCloner
{
  internal static bool CopyHandlers(UIElement source, UIElement target, RoutedEvent eventToCopy)
  {
    Type type = source.GetType();
    MethodInfo method1 = type.GetMethod("EnsureEventHandlersStore", BindingFlags.Instance | BindingFlags.NonPublic);
    if (method1 == (MethodInfo) null)
      return false;
    method1.Invoke((object) source, (object[]) null);
    PropertyInfo property = type.GetProperty("EventHandlersStore", BindingFlags.Instance | BindingFlags.NonPublic);
    if (property == (PropertyInfo) null)
      return false;
    object obj = property.GetValue((object) source, (object[]) null);
    if (obj == null)
      return false;
    MethodInfo method2 = obj.GetType().GetMethod("GetRoutedEventHandlers", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
    if (method2 == (MethodInfo) null)
      return false;
    if (!(method2.Invoke(obj, new object[1]
    {
      (object) eventToCopy
    }) is RoutedEventHandlerInfo[] eventHandlerInfoArray) || eventHandlerInfoArray.Length == 0)
      return false;
    foreach (RoutedEventHandlerInfo eventHandlerInfo in eventHandlerInfoArray)
      target.AddHandler(eventToCopy, eventHandlerInfo.Handler, eventHandlerInfo.InvokeHandledEventsToo);
    return true;
  }
}
