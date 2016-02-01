

namespace VisionsInCode.Foundation.Realtime.Infrastructure
{
  using Autofac;
  using Microsoft.AspNet.SignalR.Hubs;

  public class HubActivator : IHubActivator
  {

    private ILifetimeScope LifetimeScope { get; set; }
    private HubLifetimeScopeManager HubLifetimeScopeManager { get; set; }

    public HubActivator(HubLifetimeScopeManager hubLifetimeScopeManager, ILifetimeScope lifetimeScope)
    {
      LifetimeScope = lifetimeScope;
      HubLifetimeScopeManager = hubLifetimeScopeManager;
    }


    public IHub Create(HubDescriptor descriptor)
    {
      return typeof(BaseHub).IsAssignableFrom(descriptor.HubType)
        ? HubLifetimeScopeManager.CreateHub<BaseHub>(descriptor.HubType, LifetimeScope)
        : LifetimeScope.Resolve(descriptor.HubType) as IHub;
    }



  }
}