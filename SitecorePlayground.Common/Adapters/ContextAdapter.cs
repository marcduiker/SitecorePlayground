using System;

using SitecorePlayground.Common.Interfaces.Adapters;

namespace SitecorePlayground.Common.Adapters
{
    /// <summary>
    /// Wrapper class for th Sitecore <see cref="Sitecore.Context"/>.
    /// </summary>
    public class ContextAdapter : IContext
    {
        public Sitecore.Globalization.Language ContentLanguage
        {
            get { return Sitecore.Context.Language; }
        }

        public IItemAdapter CurrentItem
        {
            get { return new ItemAdapter(Sitecore.Context.Item); }
        }

        public IDatabase Database
        {
            get { return new DatabaseAdapter(Sitecore.Context.Database); }
        }

        public IItemAdapter DatasourceItem
        {
            get { throw new NotImplementedException(); }
        }

        public IItemAdapter HomepageItem
        {
            get { return this.Site.StartItem; }
        }

        public bool IsPageEditor
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsPreview
        {
            get { throw new NotImplementedException(); }
        }

        public string Placeholder
        {
            get { throw new NotImplementedException(); }
        }

        public ISite Site
        {
            get { return new SiteAdapter(Sitecore.Context.Site, this.Database); }
        }
    }
}
