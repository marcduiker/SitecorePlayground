using Sitecore.Data;
using Sitecore.Data.Items;

using SitecorePlayground.Common.Interfaces.Adapters;

namespace SitecorePlayground.Common.Interfaces.Providers
{
    /// <summary>
    /// Interface for the ItemProvider.
    /// </summary>
    public interface IItemProvider
    {
        /// <summary>
        /// Retrieves a Sitecore item by their Id.
        /// </summary>
        /// <param name="itemId">The item <see cref="ID"/>.</param>
        /// <returns>An ItemAdapter</returns>
        Item GetItem(ID itemId);

        /// <summary>
        /// Retrieves a wrapped item by their Id.
        /// </summary>
        /// <param name="itemId">The item <see cref="ID"/>.</param>
        /// <returns>An ItemAdapter</returns>
        IItem GetItemAdapter(ID itemId);
    }
}
