
namespace VisionsInCode.Foundation.Realtime.Infrastructure
{
  using System;
  using Microsoft.AspNet.SignalR;

  public abstract class BaseHub : Hub
  {
    internal event EventHandler Disposing;

    protected override void Dispose(bool disposing)
    {
      base.Dispose(disposing);
      if (!disposing)
        return;

      EventHandler handler = Disposing;

      handler?.Invoke(this, EventArgs.Empty);
    }

  }
}