namespace VisionsInCode.Feature.EmotionAware.Repositories
{
  using Sitecore.Data.Items;
  using System.Collections.Generic;
  using System.Linq;
  using Sitecore.Foundation.SitecoreExtensions.Extensions;
  using Sitecore.Foundation.SitecoreExtensions.Repositories;

  public class AnalyticsRepository : IAnalyticsRepository
  {

    public IEnumerable<Item> GetGoalsByCategoryFolder(string categoryFolderName)
    {
      Item templateGoalCategoryFolder = ItemRepository.Get(EmotionAware.Templates.GoalCategory.ID);

      Item categoryFolder = templateGoalCategoryFolder.GetReferrersAsItems().FirstOrDefault(item => item.Name.Equals(categoryFolderName));

      return categoryFolder?.GetChildren().Where(item => item.IsDerived(EmotionAware.Templates.Goal.ID));
    }

  }
}