

namespace VisionsInCode.Foundation.Realtime.Infrastructure
{
  using System;
  using System.Collections.Generic;
  using Autofac;
  using Autofac.Core;
  using Autofac.Integration.Mvc;
  using Microsoft.AspNet.SignalR;


  public class SignalRAutoFacDependencyResolver : DefaultDependencyResolver
  {
    private readonly Container container;
    public SignalRAutoFacDependencyResolver(IContainer container)
    {
      this.container = container as Container;
    }
    public override object GetService(Type serviceType)
    {
      return (this.container as IServiceProvider).GetService(serviceType) ?? base.GetService(serviceType);
    }

    public override IEnumerable<object> GetServices(Type serviceType)
    {

      return (container as IDependencyResolver).GetServices(serviceType);
     
    }
  }
}