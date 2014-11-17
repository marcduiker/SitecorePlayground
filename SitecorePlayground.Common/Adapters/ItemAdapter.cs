using System.Collections.Generic;
using System.Linq;

using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;

using SitecorePlayground.Common.Interfaces.Adapters;

namespace SitecorePlayground.Common.Adapters
{
    /// <summary>
    /// Wrapper class for the Sitecore <see cref="Item"/>.
    /// </summary>
    public class ItemAdapter : IItem
    {
        public ItemAdapter(Item item)
        {
            Assert.ArgumentNotNull(item, "item");

            this.InnerItem = item;
        }

        public ItemAxes Axes
        {
            get
            {
                return InnerItem.Axes;
            }
        }

        public IEnumerable<ID> BaseTemplateIds
        {
            get
            {
                return InnerItem.Template.BaseTemplates.Select(template => template.ID);
            }
        }

        public string DisplayName
        {
            get
            {
                return InnerItem.DisplayName;
            }
        }

        public ID Id
        {
            get
            {
                return InnerItem.ID;
            }
        }

        public Item InnerItem
        {
            get;
            private set;
        }

        public ID TemplateId
        {
            get
            {
                return InnerItem.TemplateID;
            }
        }

        public string this[string fieldName]
        {
            get
            {
                return InnerItem.Fields[fieldName].Value;
            }
        }
    }
}
