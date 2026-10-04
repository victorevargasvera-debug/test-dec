// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.Comms.DeviceServiceManagerProvider
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

using Autofac;
using Autofac.Builder;
using Autofac.Core;
using Autofac.Features.ResolveAnything;
using Motorola.Common.Communication;
using Motorola.Common.Communication.Service;
using System;

#nullable disable
namespace SpecialFeatures.Comms;

public class DeviceServiceManagerProvider
{
  private static readonly Lazy<DeviceServiceManager> a;

  private static DeviceServiceManager a()
  {
    short num1 = 11788;
    int num2 = (int) num1;
    num1 = (short) 11788;
    int num3 = (int) num1;
    switch (num2 == num3)
    {
      case true:
        short num4 = 1;
        if (num4 == (short) 0)
          ;
        num4 = (short) 0;
        if (num4 == (short) 0)
          ;
        num4 = (short) 0;
        ContainerBuilder containerBuilder = new ContainerBuilder();
        ModuleRegistrationExtensions.RegisterModule<CommunicationServiceModule>(containerBuilder);
        ModuleRegistrationExtensions.RegisterModule<AstroCommunicationModule>(containerBuilder);
        RegistrationExtensions.RegisterSource(containerBuilder, (IRegistrationSource) new AnyConcreteTypeNotAlreadyRegisteredSource());
        return ResolutionExtensions.Resolve<DeviceServiceManager>((IComponentContext) containerBuilder.Build((ContainerBuildOptions) 0));
      default:
        goto case 1;
    }
  }

  public static DeviceServiceManager Instance
  {
    get
    {
      short num1 = 13544;
      int num2 = (int) num1;
      num1 = (short) 13544;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          short num4 = 1;
          if (num4 == (short) 0)
            ;
          num4 = (short) 0;
          if (num4 == (short) 0)
            ;
          num4 = (short) 0;
          return DeviceServiceManagerProvider.a.Value;
        default:
          goto case 1;
      }
    }
  }

  static DeviceServiceManagerProvider()
  {
    short num1 = 1;
    if (num1 == (short) 0)
      ;
    num1 = (short) -21569;
    int num2 = (int) num1;
    num1 = (short) -21569;
    int num3 = (int) num1;
    switch (num2 == num3)
    {
      case true:
        num1 = (short) 0;
        if (num1 == (short) 0)
          ;
        num1 = (short) 0;
        DeviceServiceManagerProvider.a = new Lazy<DeviceServiceManager>(new Func<DeviceServiceManager>(DeviceServiceManagerProvider.a));
        break;
      default:
        goto case 1;
    }
  }
}
