namespace VisionsInCode.Foundation.EmotionAware.Repositories
{
    using System.Collections.Generic;
    using Sitecore.Data.Items;

    public interface IAnalyticsRepository
    {
        IEnumerable<Item> GetGoalsByCategoryFolder(string categoryFolderName);
    }
}