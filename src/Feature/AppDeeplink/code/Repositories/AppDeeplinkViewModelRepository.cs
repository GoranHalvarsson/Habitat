namespace VisionsInCode.Feature.AppDeeplink.Repositories
{
  using System.Web;
  using Sitecore.Foundation.SitecoreExtensions.Extensions;
  using Sitecore.Mvc.Presentation;
  using Sitecore.Web.UI.WebControls;
  using VisionsInCode.Feature.AppDeeplink.ViewModels;


  public class AppDeeplinkViewModelRepository : IAppDeeplinkViewModelRepository
  {
    public AppDeeplinkViewModel Get()
    {
      if (RenderingContext.Current == null || RenderingContext.Current.Rendering == null || RenderingContext.Current.Rendering.Item == null)
        return null;

      if (!RenderingContext.Current.Rendering.Item.IsDerived(AppDeeplinkViewModel.Constants.Templates.AppDeeplink))
        return null;

      string deviceUrl = FieldRenderer.Render(RenderingContext.Current.Rendering.Item, AppDeeplinkViewModel.Constants.Fields.AppDeeplink.AppDeeplinkSettingsAppDeviceURL.ToString());

      return new AppDeeplinkViewModel()
      {
        StoreUrl = new HtmlString(FieldRenderer.Render(RenderingContext.Current.Rendering.Item, AppDeeplinkViewModel.Constants.Fields.AppDeeplink.AppDeeplinkSettingsAppStoreURL.ToString())),
        DeviceUrl = new HtmlString(deviceUrl),
        DeviceUrlWithParams = new HtmlString(BuildDeviceUrlWithParams(deviceUrl))
      };

    }


    private string BuildDeviceUrlWithParams(string deviceUrl)
    {

      if(string.IsNullOrWhiteSpace(deviceUrl))
        return string.Empty;

      string decodedQuery = System.Web.HttpUtility.UrlDecode(RenderingContext.Current.PageContext.RequestContext.HttpContext.Request.Url.Query);

      if (string.IsNullOrWhiteSpace(decodedQuery))
        return deviceUrl;

      object param = HttpUtility.ParseQueryString(decodedQuery).Get(AppDeeplinkViewModel.Constants.QueryParams.DeviceParams);

      if (param == null)
        return deviceUrl;

    
      return $"{deviceUrl}{param}";

    }


  }
}