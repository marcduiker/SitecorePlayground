using Sitecore.Data;

using SitecorePlayground.Common.Interfaces.Adapters;
using SitecorePlayground.Common.Interfaces.Providers;
using SitecorePlayground.News.Models;

namespace SitecorePlayground.News.Providers
{
    public class AuthorProviderBasedOnItemAdapter
    {
        private readonly IItemProvider itemProvider;

        public AuthorProviderBasedOnItemAdapter(IItemProvider itemProvider)
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
        /// Method to return a type that implements the IItem interface (ItemAdapter)
        /// from the ItemProvider.
        /// </summary>
        private IItemAdapter GetAuthorItem(ID authorItemId)
        {
            return itemProvider.GetItemAdapter(authorItemId);
        }
    }
}
