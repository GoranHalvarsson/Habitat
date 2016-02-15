namespace VisionsInCode.Foundation.SitecoreCustomizations.Extensions
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Xml.Linq;
  using Sitecore.Data;
  using Sitecore.Data.Items;
  using Sitecore.Foundation.SitecoreExtensions.Extensions;
  using Sitecore.Rules;

  /// <summary>
  ///   Extension of Sitecore iems
  /// </summary>
  public static class ItemExtensions
  {

    public static IList<Item> GetDescendantsOrSelfOfTemplate(this Item item, ID templateID)
    {
        if (item == null)
        {
            throw new ArgumentNullException(nameof(item));
        }

        var returnValue = new List<Item>();
        if (item.IsDerived(templateID))
        {
            returnValue.Add(item);
        }

        returnValue.AddRange(item.Axes.GetDescendants().Where(i => i.IsDerived(templateID)));
        return returnValue;
    }

    public static void ExecuteRuleField(this Item item, ID fieldId)
    {
      string rawRules = item.GetString(fieldId);

      if (string.IsNullOrWhiteSpace(rawRules))
        return;

      RuleList<RuleContext> rules = RuleFactory.ParseRules<RuleContext>(item.Database, XElement.Parse(rawRules));
      RuleContext ruleContext = new RuleContext()
      {
        Item = item
      };

      foreach (Rule<RuleContext> rule in rules.Rules)
      {
        rule?.Evaluate(ruleContext);
      }
    }


  }
}