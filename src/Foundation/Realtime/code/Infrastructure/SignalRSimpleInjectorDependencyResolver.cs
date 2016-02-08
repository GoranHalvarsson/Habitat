

namespace VisionsInCode.Foundation.Realtime.Infrastructure
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Web.Http.Controllers;
  using Microsoft.AspNet.SignalR;
  using SimpleInjector;


  public class SignalRSimpleInjectorDependencyResolver : DefaultDependencyResolver
  {
    private readonly Container container;
    public SignalRSimpleInjectorDependencyResolver(Container container)
    {
      this.container = container;
    }
    public override object GetService(Type serviceType)
    {

      if (!serviceType.IsAbstract && typeof(IHttpController).IsAssignableFrom(serviceType))
      {
        return this.container.GetInstance(serviceType);
      }

      return ((IServiceProvider)this.container).GetService(serviceType);

     // return ((IServiceProvider)this.container).GetService(serviceType) ?? base.GetService(serviceType);
    }

    public override IEnumerable<object> GetServices(Type serviceType)
    {
      Type collectionType = typeof(IEnumerable<>).MakeGenericType(serviceType);
      var services = (IEnumerable<object>)((IServiceProvider)this.container).GetService(collectionType);
      return services ?? Enumerable.Empty<object>();
     
    }
  }
}