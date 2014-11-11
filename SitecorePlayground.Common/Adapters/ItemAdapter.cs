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

            this.OriginalItem = item;
        }

        public ItemAxes Axes
        {
            get
            {
                return this.OriginalItem.Axes;
            }
        }

        public IEnumerable<ID> BaseTemplateIds
        {
            get
            {
                return this.OriginalItem.Template.BaseTemplates.Select(template => template.ID);
            }
        }

        public string DisplayName
        {
            get
            {
                return this.OriginalItem.DisplayName;
            }
        }

        public ID TemplateId
        {
            get
            {
                return this.OriginalItem.TemplateID;
            }
        }

        public Item OriginalItem
        {
            get;
            private set;
        }

        public string this[string fieldName]
        {
            get
            {
                return this.OriginalItem.Fields[fieldName].Value;
            }
        }
    }
}
