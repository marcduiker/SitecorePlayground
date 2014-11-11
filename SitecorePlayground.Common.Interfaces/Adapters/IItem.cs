using System.Collections.Generic;

using Sitecore.Data;
using Sitecore.Data.Items;

namespace SitecorePlayground.Common.Interfaces.Adapters
{
    /// <summary>
    /// Interface for the ItemAdapter  to abstract frequently used <see cref="Item"/> properties 
    /// in order to write better (unit) testable code.
    /// </summary>
    public interface IItem
    {
        /// <summary>
        /// Getter for the ItemAxes of the Item.
        /// </summary>
        ItemAxes Axes { get; }

        /// <summary>
        /// Getter for the base template IDs.
        /// </summary>
        IEnumerable<ID> BaseTemplateIds { get; }

        /// <summary>
        /// Getter for the Item display name.
        /// </summary>
        string DisplayName { get; }

        /// <summary>
        /// Getter for the Item Template ID.
        /// </summary>
        ID TemplateId { get; }

        /// <summary>
        /// Getter/setter for the actual Sitecore <see cref="Item"/>.
        /// </summary>
        Item OriginalItem { get; }

        /// <summary>
        /// Getter for returning the string value for a field.
        /// </summary>
        /// <param name="fieldName"></param>
        string this[string fieldName] { get; }
    }
}
