using Sitecore.Data;
using Sitecore.Data.Items;
using SitecorePlayground.Common.Adapters;
using SitecorePlayground.Common.Interfaces.Adapters;
using SitecorePlayground.Common.Interfaces.Providers;

namespace SitecorePlayground.Common.Providers
{
    public class ItemProvider : IItemProvider
    {
        public Item GetItem(ID itemId)
        {
            return Sitecore.Context.Database.GetItem(itemId);
        }

        public IItem GetItemAdapter(ID itemId)
        {
            var item = GetItem(itemId);
            return item != null ? new ItemAdapter(item) : null;
        }
    }
}
