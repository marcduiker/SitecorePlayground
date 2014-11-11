using System.Collections.Generic;
using System.Linq;

using Sitecore.Data.Items;

using SitecorePlayground.Common.Adapters;
using SitecorePlayground.Common.Interfaces.Adapters;
using SitecorePlayground.News.Models;
using SitecorePlayground.News.Templates;

namespace SitecorePlayground.News.Providers
{
    public class NewsArticleProvider
    {
        private readonly AuthorProviderBasedOnItemAdapter authorProvider;

        public NewsArticleProvider(AuthorProviderBasedOnItemAdapter authorProvider)
        {
            this.authorProvider = authorProvider;
        }

        public IEnumerable<NewsArticle> GetNewsArticles()
        {
            return this.GetNewsArticleItems()
                    .Select(
                        newsArticleItem =>
                        new NewsArticle
                            {
                                Author = authorProvider.GetAuthor(newsArticleItem[NewsArticleTemplate.Fields.Author]),
                                Introduction = newsArticleItem[NewsArticleTemplate.Fields.Introduction],
                                Title = newsArticleItem[NewsArticleTemplate.Fields.Title]
                            });
        }

        protected virtual IEnumerable<IItem> GetNewsArticleItems()
        {
            var newsFolderChildren = Sitecore.Context.Database.GetItem(NewsArticleTemplate.TemplateId).Children;

            return newsFolderChildren.Any(ItemIsNewsArticleTemplate) ?
                newsFolderChildren.Where(ItemIsNewsArticleTemplate).Select(item => new ItemAdapter(item))
                : new List<ItemAdapter>();
        }

        private static bool ItemIsNewsArticleTemplate(Item item)
        {
            return item.TemplateID.ToString() == NewsArticleTemplate.TemplateId;
        }
    }
}
