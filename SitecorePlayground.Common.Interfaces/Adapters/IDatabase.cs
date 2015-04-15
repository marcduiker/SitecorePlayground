using Sitecore.Data;

namespace SitecorePlayground.Common.Interfaces.Adapters
{
    /// <summary>
    /// Interface to abstract frequently used <see cref="Sitecore.Data.Database"/> properties 
    /// in order to write better (unit) testable code.
    /// </summary>
    public interface IDatabase
    {
        /// <summary>
        /// Getter for the Database name.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Method to return an wrapped Item for the given item ID.
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns><see cref="IItem"/></returns>
        IItem GetItem(ID itemId);

        /// <summary>
        /// Method to return a wrapped Item for the given item path.
        /// </summary>
        /// <param name="itemPath"></param>
        /// <returns><see cref="IItem"/></returns>
        IItem GetItem(string itemPath);

        /// <summary>
        /// Method to return a wrapped Item for the given query.
        /// </summary>
        /// <param name="itemQuery"></param>
        /// <returns><see cref="IItem"/></returns>
        IItem SelectSingleItem(string itemQuery);
    }
}
