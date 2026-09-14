// Decompiled with JetBrains decompiler
// Type: MackinawCPS.TestCaseLauncher2
// Assembly: APXFamilyCPS, Version=15.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 7983BD42-76AB-479D-8966-B7B635E0E28A
// Assembly location: C:\Program Files (x86)\Motorola\ApxFamilyDepot R28\APXdepotR28.exe

using System;
using System.IO;
using System.Reflection;
using System.Xml;

#nullable disable
namespace MackinawCPS;

public class TestCaseLauncher2
{
  public static void RunCases(string casefile)
  {
    XmlDocument xmlDocument = new XmlDocument();
    xmlDocument.Load(casefile);
    Assembly assembly = Assembly.LoadFrom(Path.Combine(Path.GetDirectoryName(casefile), "RadioManagement.AutoTest.dll"));
    if (xmlDocument.DocumentElement.Attributes["initmethodname"] != null)
    {
      Type type = assembly.GetType(xmlDocument.DocumentElement.Attributes["initclassname"].Value);
      object instance = Activator.CreateInstance(type);
      type.GetMethod(xmlDocument.DocumentElement.Attributes["initmethodname"].Value).Invoke(instance, (object[]) null);
    }
    foreach (XmlNode childNode1 in xmlDocument.DocumentElement.ChildNodes)
    {
      Type type = assembly.GetType(childNode1.Attributes["classfullname"].Value);
      object instance = Activator.CreateInstance(type);
      if (childNode1.Attributes["initmethodname"] != null)
        type.GetMethod(childNode1.Attributes["initmethodname"].Value).Invoke((object) null, (object[]) null);
      MethodInfo methodInfo1 = (MethodInfo) null;
      MethodInfo methodInfo2 = (MethodInfo) null;
      if (childNode1.Attributes["testinitmethodname"] != null)
        methodInfo1 = type.GetMethod(childNode1.Attributes["testinitmethodname"].Value);
      if (childNode1.Attributes["testcleanmethodname"] != null)
        methodInfo2 = type.GetMethod(childNode1.Attributes["testcleanmethodname"].Value);
      foreach (XmlNode childNode2 in childNode1.ChildNodes)
      {
        if (methodInfo1 != (MethodInfo) null)
          methodInfo1.Invoke(instance, (object[]) null);
        MethodInfo method = type.GetMethod(childNode2.Attributes["methodname"].Value);
        try
        {
          method.Invoke(instance, (object[]) null);
          if (childNode2.Attributes["result"] == null)
            childNode2.Attributes.Append(xmlDocument.CreateAttribute("result"));
          childNode2.Attributes["result"].Value = "Passed";
        }
        catch (TargetInvocationException ex)
        {
          if (childNode2.Attributes["result"] == null)
            childNode2.Attributes.Append(xmlDocument.CreateAttribute("result"));
          childNode2.Attributes["result"].Value = "Failed";
          if (childNode2.Attributes["error"] == null)
            childNode2.Attributes.Append(xmlDocument.CreateAttribute("error"));
          childNode2.Attributes["error"].Value = ex.InnerException.Message;
        }
        SQLHelper.CleanLocalDB();
        SQLHelper.InitSerialNumberTable();
        if (methodInfo2 != (MethodInfo) null)
          methodInfo2.Invoke(instance, (object[]) null);
      }
      if (childNode1.Attributes["cleanmethodname"] != null)
        type.GetMethod(childNode1.Attributes["cleanmethodname"].Value).Invoke((object) null, (object[]) null);
    }
    if (xmlDocument.DocumentElement.Attributes["cleanmethodname"] != null)
    {
      Type type = assembly.GetType(xmlDocument.DocumentElement.Attributes["cleanclassname"].Value);
      object instance = Activator.CreateInstance(type);
      type.GetMethod(xmlDocument.DocumentElement.Attributes["cleanmethodname"].Value).Invoke(instance, (object[]) null);
    }
    xmlDocument.Save(casefile);
  }
}
