namespace VisionsInCode.Foundation.AppDeeplink.ViewModels
{

  using System.Web;
  using Sitecore.Data;

  public class AppDeeplinkViewModel
  {
    public HtmlString StoreUrl { get; set; }

    public HtmlString DeviceUrl { get; set; }

    public HtmlString DeviceUrlWithParams { get; set; }

    public struct Constants
    {
      public struct Templates
      {
        public static ID AppDeeplink = new ID("{0E1C2680-F935-446E-82BE-DA1176C5BCB5}");
      }

      public struct Fields
      {
        public struct AppDeeplink
        {
          public static ID AppDeeplinkSettingsAppName = new ID("{275C127A-9E78-468D-B0F2-04B8F409A7E0}");
          public static ID AppDeeplinkSettingsAppId = new ID("{582D7235-2A91-4F79-88D8-1E00F2B8EC9D}");
          public static ID AppDeeplinkSettingsAppStoreURL = new ID("{56260A54-CAD0-4C17-A54B-FAA580F09ADF}");
          public static ID AppDeeplinkSettingsAppDeviceURL = new ID("{3356B59D-5796-4C23-B6F4-4588B4437375}");
        }
      }

      public struct QueryParams
      {
        public const string DeviceParams = "deviceparams";
      }
    }

   
  }
}