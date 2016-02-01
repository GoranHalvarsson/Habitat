namespace VisionsInCode.Foundation.EmotionAware.Repositories
{
  using System.Collections.Generic;
  using VisionsInCode.Foundation.EmotionAware.Models;
  using Sitecore.Data.Items;

  public interface IEmotionAwareSettingsRepository
  {
    EmotionAwareSettings Get();

  }
}