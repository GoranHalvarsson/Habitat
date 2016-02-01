﻿namespace VisionsInCode.Foundation.EmotionAware.Repositories
{
  using System.EnterpriseServices;
  using Sitecore.Data.Items;
  using System.Linq;
  using VisionsInCode.Foundation.EmotionAware.Models;

  using Sitecore;
  using Sitecore.Foundation.SitecoreExtensions.Extensions;
  using VisionsInCode.Feature.EmotionAware;

  public class EmotionAwareSettingsRepository : IEmotionAwareSettingsRepository
  {

    private readonly Item emotionAwareSettingsItem;

    public EmotionAwareSettingsRepository()
    {
      emotionAwareSettingsItem = GetEmotionAwareSettings();
    }

    private Item GetEmotionAwareSettings()
    {
      return Context.Site.GetContextItem(Templates.EmotionAwareSettings.ID);
    }


    public EmotionAwareSettings Get()
    {
      if (emotionAwareSettingsItem == null)
        return null;

      return new EmotionAwareSettings()
      {
        SubscriptionKey = emotionAwareSettingsItem.GetString(Templates.EmotionAwareSettings.Fields.EmotionAwareSettingsSubscriptionKey)
      };

    }
  }
}