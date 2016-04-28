namespace VisionsInCode.Feature.EmotionAware.Pipelines
{
  using System.Web.Mvc;
  using System.Web.Routing;
  using Sitecore.Pipelines;

  public class RegisterWebApiRoutes
  {
    public void Process(PipelineArgs args)
    {
      RouteTable.Routes.MapRoute(
        name: "Feature.EmotionAware.Api",
        url: "api/EmotionAware/{action}",
        defaults:new {controller = "EmotionAware"});
    }
  }
}