namespace VisionsInCode.Foundation.Realtime.Infrastructure
{
  using System;
  using System.Configuration;
  using System.Web.Configuration;
  using Microsoft.AspNet.SignalR;
  using Microsoft.AspNet.SignalR.Hubs;

  public class HubContextService : IHubContextService
  {
    private readonly HubCallerContext hubContext;


    private HubContextService(HubCallerContext hubContext)
    {
      this.hubContext = hubContext;
    }

    public HubContextService()
    { }

    public HubContextService Resolve(HubCallerContext callerContext)
    {
      return new HubContextService(callerContext);
    }

    public string ContactId
    {
      get
      {
        string value = GetCookieValue("SC_ANALYTICS_GLOBAL_COOKIE");
        return value.Substring(0, value.IndexOf("|", StringComparison.Ordinal));
      }
    }

    public string SessionId
    {
      get
      {
        string sessionCookieIdName = GetSessionIdCookieName();
        return GetCookieValue(sessionCookieIdName);
      }
    }

    public string ConnectionId => this.hubContext.ConnectionId;

    public string Headers => this.hubContext.Request.Headers["User-Agent"];

    public bool IsUserAuthenticated()
    {
      return true;
    }

    private string GetCookieValue(string cookieKey)
    {
      Cookie cookieValue;
      this.hubContext.RequestCookies.TryGetValue(cookieKey, out cookieValue);

      return cookieValue == null ? string.Empty : cookieValue.Value;
    }


    private static string GetSessionIdCookieName()
    {
      SessionStateSection sessionStateSection = (SessionStateSection)ConfigurationManager
                                                  .GetSection("system.web/sessionState");
      return sessionStateSection?.CookieName;
    }

  }
}