using Sitecore;
using Sitecore.Globalization;

namespace SitecorePlayground.Common.Interfaces.Adapters
{
    /// <summary>
    /// Interface to abstract frequently used <see cref="Context"/> properties 
    /// in order to write better (unit) testable code.
    /// </summary>
    public interface IContext
    {
        /// <summary>
        /// Getter for the content language.
        /// </summary>
        Language ContentLanguage { get; }

        /// <summary>
        /// Getter for the current wrapped Item.
        /// </summary>
        IItemAdapter CurrentItem { get; }

        /// <summary>
        /// Getter for the wrapped Datebase.
        /// </summary>
        IDatabase Database { get; }

        /// <summary>
        /// Getter for the wrapped datasource Item.
        /// </summary>
        IItemAdapter DatasourceItem { get; }

        /// <summary>
        /// Getter for the wrapped homepage Item.
        /// </summary>
        IItemAdapter HomepageItem { get; }

        /// <summary>
        /// Getter to determine if the context is in PageEditor mode.
        /// </summary>
        bool IsPageEditor { get; }

        /// <summary>
        /// Getter to determine if the context is in Preview mode.
        /// </summary>
        bool IsPreview { get; }

        /// <summary>
        /// Getter for the placeholder.
        /// </summary>
        string Placeholder { get; }

        /// <summary>
        /// Getter for the wrapped Site.
        /// </summary>
        ISite Site { get; }
    }
}
