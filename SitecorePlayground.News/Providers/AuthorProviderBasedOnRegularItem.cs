using Sitecore.Data;
using Sitecore.Data.Items;

using SitecorePlayground.Common.Interfaces.Providers;
using SitecorePlayground.News.Models;

namespace SitecorePlayground.News.Providers
{
    public class AuthorProviderBasedOnRegularItem
    {
        private readonly IItemProvider itemProvider;

        public AuthorProviderBasedOnRegularItem(IItemProvider itemProvider)
        {
            this.itemProvider = itemProvider;
        }

        public Author GetAuthor(string authorId)
        {
            ID parsedAuthorId;
            if (!ID.TryParse(authorId, out parsedAuthorId))
            {
                return null;
            }

            return this.GetAuthor(parsedAuthorId);
        }

        public Author GetAuthor(ID authorId)
        {
            var authorItem = GetAuthorItem(authorId);

            if (authorItem == null)
            {
                return null;
            }

            return new Author
            {
                Company = authorItem[Templates.AuthorTemplate.Fields.AuthorCompany],
                Name = authorItem[Templates.AuthorTemplate.Fields.AuthorName]
            };
        }

        /// <summary>
        /// Method to return a regular Sitecore item from the ItemProvider.
        /// </summary>
        private Item GetAuthorItem(ID authorItemId)
        {
            return itemProvider.GetItem(authorItemId);
        }
    }
}
