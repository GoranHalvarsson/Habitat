namespace VisionsInCode.Feature.EmotionAware.Repositories
{
  using System.Collections.Generic;
  using VisionsInCode.Feature.EmotionAware.Models;
  using Sitecore.Data.Items;

  public interface IEmotionAwareSettingsRepository
  {
    EmotionAwareSettings Get();

  }
}