namespace VisionsInCode.Feature.EmotionAware.Services
{
  using VisionsInCode.Foundation.ProjectOxfordAI.Enums;
  using Sitecore.Analytics.Model;
  using Sitecore.Analytics.Model.Entities;

  public interface IEmotionAnalyticsService
  {
    ITagValue RegisterEmotionOnCurrentContact(Emotions emotion);
    PageEventData RegisterGoal(string goalName, string pageUrl);
  }
}