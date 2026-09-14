// Decompiled with JetBrains decompiler
// Type: MackinawCPS.CommandLineCPS.MyMessageBox
// Assembly: APXFamilyCPS, Version=15.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 7983BD42-76AB-479D-8966-B7B635E0E28A
// Assembly location: C:\Program Files (x86)\Motorola\APX Dpt 25\APXFamilyCPS.exe

using System.Windows;

#nullable disable
namespace MackinawCPS.CommandLineCPS;

public class MyMessageBox
{
  internal static MessageBoxResult Show(string messageBoxText, MessageBoxResult defaultResult = MessageBoxResult.OK)
  {
    return (bool) Application.Current.Properties[(object) "CommandLineCPS"] ? defaultResult : MessageBox.Show(messageBoxText);
  }

  internal static MessageBoxResult Show(
    string messageBoxText,
    string caption,
    MessageBoxResult defaultResult = MessageBoxResult.OK)
  {
    return (bool) Application.Current.Properties[(object) "CommandLineCPS"] ? defaultResult : MessageBox.Show(messageBoxText, caption);
  }

  internal static MessageBoxResult Show(
    string messageBoxText,
    string caption,
    MessageBoxButton button,
    MessageBoxResult defaultResult = MessageBoxResult.OK)
  {
    if (!(bool) Application.Current.Properties[(object) "CommandLineCPS"])
      return MessageBox.Show(messageBoxText, caption, button);
    MessageBoxResult messageBoxResult = defaultResult;
    if (button == MessageBoxButton.OK || button == MessageBoxButton.OKCancel)
    {
      switch (defaultResult)
      {
        case MessageBoxResult.Yes:
          messageBoxResult = MessageBoxResult.OK;
          break;
        case MessageBoxResult.No:
          messageBoxResult = MessageBoxResult.Cancel;
          break;
      }
    }
    else if ((button == MessageBoxButton.YesNo || button == MessageBoxButton.YesNoCancel) && defaultResult == MessageBoxResult.OK)
      messageBoxResult = MessageBoxResult.Yes;
    return messageBoxResult;
  }

  internal static MessageBoxResult Show(
    string messageBoxText,
    string caption,
    MessageBoxButton button,
    MessageBoxImage icon,
    MessageBoxResult defaultResult)
  {
    if (!(bool) Application.Current.Properties[(object) "CommandLineCPS"])
      return MessageBox.Show(messageBoxText, caption, button, icon, defaultResult);
    MessageBoxResult messageBoxResult = defaultResult;
    if (button == MessageBoxButton.OK || button == MessageBoxButton.OKCancel)
    {
      switch (defaultResult)
      {
        case MessageBoxResult.Yes:
          messageBoxResult = MessageBoxResult.OK;
          break;
        case MessageBoxResult.No:
          messageBoxResult = MessageBoxResult.Cancel;
          break;
      }
    }
    else if ((button == MessageBoxButton.YesNo || button == MessageBoxButton.YesNoCancel) && defaultResult == MessageBoxResult.OK)
      messageBoxResult = MessageBoxResult.Yes;
    return messageBoxResult;
  }

  internal static MessageBoxResult Show(
    string messageBoxText,
    string caption,
    MessageBoxButton button,
    MessageBoxImage icon,
    MessageBoxResult defaultResult,
    MessageBoxOptions options)
  {
    if (!(bool) Application.Current.Properties[(object) "CommandLineCPS"])
      return MessageBox.Show(messageBoxText, caption, button, icon, defaultResult, options);
    MessageBoxResult messageBoxResult = defaultResult;
    if (button == MessageBoxButton.OK || button == MessageBoxButton.OKCancel)
    {
      switch (defaultResult)
      {
        case MessageBoxResult.Yes:
          messageBoxResult = MessageBoxResult.OK;
          break;
        case MessageBoxResult.No:
          messageBoxResult = MessageBoxResult.Cancel;
          break;
      }
    }
    else if ((button == MessageBoxButton.YesNo || button == MessageBoxButton.YesNoCancel) && defaultResult == MessageBoxResult.OK)
      messageBoxResult = MessageBoxResult.Yes;
    return messageBoxResult;
  }
}
