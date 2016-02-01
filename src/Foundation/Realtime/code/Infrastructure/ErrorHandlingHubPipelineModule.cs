

namespace VisionsInCode.Foundation.Realtime.Infrastructure
{
  using Microsoft.AspNet.SignalR.Hubs;
  using Sitecore.Diagnostics;

  public class ErrorHandlingHubPipelineModule : HubPipelineModule
  {
    protected override void OnIncomingError(ExceptionContext exceptionContext,
        IHubIncomingInvokerContext invokerContext)
    {

      Log.Error("Error accessing hub " + exceptionContext.Error.Message, this);


      if (exceptionContext.Error.InnerException != null)
      {
        Log.Error("=> Inner Exception " + exceptionContext.Error.InnerException.Message, this);
      }

      base.OnIncomingError(exceptionContext, invokerContext);

    }

  }
}