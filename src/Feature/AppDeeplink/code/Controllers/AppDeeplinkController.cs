namespace VisionsInCode.Foundation.AppDeeplink.Controllers
{
  using System.Web.Mvc;
  using Sitecore.Mvc.Controllers;
  using VisionsInCode.Foundation.AppDeeplink.Repositories;

  public class AppDeeplinkController : SitecoreController
  {

    private readonly IAppDeeplinkViewModelRepository appDeeplinkViewModelRepository;


    public AppDeeplinkController() : this(new AppDeeplinkViewModelRepository())
    {
    }

    /// <summary>
    /// Initiates a new AppDeepLinkController
    /// </summary>
    /// <param name="appDeeplinkViewModelRepository"></param>
    public AppDeeplinkController(IAppDeeplinkViewModelRepository appDeeplinkViewModelRepository)
    {
      this.appDeeplinkViewModelRepository = appDeeplinkViewModelRepository;
    }

    /// <summary>
    /// Method for rendering App link
    /// </summary>
    /// <returns></returns>
    public ActionResult OpenApp()
    {
      return View(appDeeplinkViewModelRepository.Get());
    }
  }
}