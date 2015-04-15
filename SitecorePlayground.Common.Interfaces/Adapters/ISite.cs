using Sitecore.Sites;

namespace SitecorePlayground.Common.Interfaces.Adapters
{
    /// <summary>
    /// Interface to abstract frequently used <see cref="SiteContext"/> properties 
    /// in order to write better (unit) testable code.
    /// </summary>
    public interface ISite
    {
        /// <summary>
        /// Getter for the host name of the site.
        /// </summary>
        string HostName { get; }

        /// <summary>
        /// Getter for the name of the site.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Getter for the wrapped RootItem of the site.
        /// </summary>
        IItem RootItem { get; }

        /// <summary>
        /// Getter for the RootPath of the site.
        /// </summary>
        string RootPath { get; }

        /// <summary>
        /// Getter for the wrapped StartItem of the site.
        /// </summary>
        IItem StartItem { get; }

        /// <summary>
        /// Getter for the StartPath of the site.
        /// </summary>
        string StartPath { get; }
    }
}
