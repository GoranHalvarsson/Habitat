namespace VisionsInCode.Foundation.Realtime.Infrastructure
{
  using Microsoft.AspNet.SignalR.Hubs;

  public interface IHubContextService
  {
    HubContextService Resolve(HubCallerContext callerContext);
    string ContactId { get; }

    string SessionId { get; }
    string ConnectionId { get; }
    string Headers { get; }

    bool IsUserAuthenticated();
  }
}
