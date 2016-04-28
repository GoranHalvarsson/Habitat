namespace VisionsInCode.Feature.EmotionAware.Repositories
{
  using Sitecore.Data.Items;
  using VisionsInCode.Feature.EmotionAware.Models;
  using Sitecore;
  using Sitecore.Foundation.SitecoreExtensions.Extensions;
  using VisionsInCode.Feature.EmotionAware;



    public class EmotionAwareSettingsRepository : IEmotionAwareSettingsRepository
  {

    private readonly Item _emotionAwareSettingsItem;

    public EmotionAwareSettingsRepository()
    {
      _emotionAwareSettingsItem = GetEmotionAwareSettings();
    }

    private Item GetEmotionAwareSettings()
    {
      return Context.Site.GetContextItem(Templates.EmotionAwareSettings.ID);
    }


    public EmotionAwareSettings Get()
    {
      if (_emotionAwareSettingsItem == null)
        return null;

      return new EmotionAwareSettings()
      {
        SubscriptionKey = _emotionAwareSettingsItem.GetString(Templates.EmotionAwareSettings.Fields.EmotionAwareSettingsSubscriptionKey)
      };

    }
  }
}