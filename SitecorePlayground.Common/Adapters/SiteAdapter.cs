using Sitecore.Sites;

using SitecorePlayground.Common.Interfaces.Adapters;

namespace SitecorePlayground.Common.Adapters
{
    /// <summary>
    /// Wrapper class for the Sitecore <see cref="SiteContext"/>.
    /// </summary>
    public class SiteAdapter : ISite
    {
        private readonly SiteContext siteContext;

        private readonly IDatabase databaseAdapter;

        /// <summary>
        /// Constructor which requires the actual Sitecore SiteContext and 
        /// an object which implements the IDatabase interface.
        /// </summary>
        /// <param name="siteContext"><see cref="SiteContext"/></param>
        /// <param name="databaseAdapter"><see cref="IDatabase"/></param>
        public SiteAdapter(SiteContext siteContext, IDatabase databaseAdapter)
        {
            this.siteContext = siteContext;
            this.databaseAdapter = databaseAdapter;
        }

        public string HostName
        {
            get { return this.siteContext.HostName; }
        }

        public string Name
        {
            get { return this.siteContext.Name; }
        }

        public IItem RootItem
        {
            get { return this.databaseAdapter.GetItem(this.RootPath); }
        }

        public string RootPath
        {
            get { return this.siteContext.RootPath; }
        }

        public IItem StartItem
        {
            get { return this.databaseAdapter.GetItem(this.StartPath); }
        }

        public string StartPath
        {
            get { return this.siteContext.StartPath; }
        }
    }
}
