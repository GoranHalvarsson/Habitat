

namespace VisionsInCode.Foundation.Realtime.Infrastructure
{
  using System;
  using System.Collections.Generic;
  using Autofac;
  using Microsoft.AspNet.SignalR.Hubs;

  public class HubLifetimeScopeManager
  {

    private readonly Dictionary<IHub, ILifetimeScope> hubLifetimeScopes;

    public HubLifetimeScopeManager()
    {
      hubLifetimeScopes = new Dictionary<IHub, ILifetimeScope>();
    }

    public T CreateHub<T>(Type type, ILifetimeScope lifetimeScope) where T : BaseHub
    {
      ILifetimeScope scope = lifetimeScope.BeginLifetimeScope();
      T hub = (T)scope.Resolve(type);
      hub.Disposing += HubOnDisposing;
      hubLifetimeScopes.Add(hub, scope);
      return hub;
    }


    private void HubOnDisposing(object sender, EventArgs eventArgs)
    {
      ILifetimeScope scope;
      IHub hub = sender as IHub;

      if (hub == null || !hubLifetimeScopes.TryGetValue(hub, out scope))
        return;

      hubLifetimeScopes.Remove(hub);

      scope?.Dispose();
    }


    
  }
}