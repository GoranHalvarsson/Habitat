namespace VisionsInCode.Feature.EmotionAware.Repositories
{
  using Sitecore.Data.Items;
  using System.Collections.Generic;
  using System.Linq;
  using Sitecore.Foundation.SitecoreExtensions.Extensions;
  using Sitecore.Foundation.SitecoreExtensions.Repositories;
  using VisionsInCode.Feature.EmotionAware;

  public class AnalyticsRepository : IAnalyticsRepository
  {

    public IEnumerable<Item> GetGoalsByCategoryFolder(string categoryFolderName)
    {
      Item templateGoalCategoryFolder = ItemRepository.Get(Templates.GoalCategory.ID);

      Item categoryFolder = templateGoalCategoryFolder.GetReferrersAsItems().FirstOrDefault(item => item.Name.Equals(categoryFolderName));

      return categoryFolder?.GetChildren().Where(item => item.IsDerived(Templates.Goal.ID));
    }

  }
}