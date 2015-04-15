using Sitecore.Data;
using Sitecore.Diagnostics;

using SitecorePlayground.Common.Interfaces.Adapters;

namespace SitecorePlayground.Common.Adapters
{
    /// <summary>
    /// Wrapper class for the Sitecore <see cref="Database"/>.
    /// </summary>
    public class DatabaseAdapter : IDatabase
    {
        private readonly Database database;

        public DatabaseAdapter(Database database)
        {
            Assert.ArgumentNotNull(database, "datebase");

            this.database = database;
        }

        public string Name
        {
            get { return this.database.Name; }
        }

        public IItem GetItem(ID itemId)
        {
            Assert.ArgumentNotNull(itemId, "itemId");

            return new ItemAdapter(this.database.GetItem(itemId));
        }

        public IItem GetItem(string itemPath)
        {
            Assert.ArgumentNotNull(itemPath, "itemPath");

            return new ItemAdapter(this.database.GetItem(itemPath));
        }

        public IItem SelectSingleItem(string itemQuery)
        {
            Assert.ArgumentNotNull(itemQuery, "itemQuery");

            return new ItemAdapter(this.database.SelectSingleItem(itemQuery));
        }
    }
}
