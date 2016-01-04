﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Foundation.MultiSite
{
  using Sitecore.Data.Items;
  using Sitecore.Foundation.SitecoreExtensions.Extensions;

  public class SiteContext
  {
    public virtual SiteDefinition GetSiteDefinitionByItem(Item item)
    {
      SiteDefinition site = null;
      var siteItem = item.Axes.GetAncestors().FirstOrDefault(IsSite);
      if (siteItem != null)
      {
        site = new SiteDefinition
        {
          Item = siteItem,
          Name = siteItem.Name,
          HostName = siteItem[Templates.Site.Fields.HostName]
        };
      }

      return site;
    }

    public static bool IsSite(Item item)
    {
      return item.IsDerived(Templates.Site.ID);
    }
  }
}