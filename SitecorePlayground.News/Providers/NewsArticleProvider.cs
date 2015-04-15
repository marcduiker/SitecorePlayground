using System.Collections.Generic;
using System.Linq;

using Sitecore.Data.Items;

using SitecorePlayground.Common.Adapters;
using SitecorePlayground.Common.Interfaces.Adapters;
using SitecorePlayground.News;

namespace SitecorePlayground.News.Providers
{
    public class NewsArticleProvider
    {
        private readonly AuthorProviderBasedOnItemAdapter authorProvider;

        public NewsArticleProvider(AuthorProviderBasedOnItemAdapter authorProvider)
        {
            this.authorProvider = authorProvider;
        }

        public IEnumerable<Models.NewsArticle> GetNewsArticles()
        {
            return this.GetNewsArticleItems()
                    .Select(
                        newsArticleItem =>
                        new Models.NewsArticle
                            {
                                Author = authorProvider.GetAuthor(newsArticleItem[Templates.NewsArticle.Fields.Author]),
                                Introduction = newsArticleItem[Templates.NewsArticle.Fields.Introduction],
                                Title = newsArticleItem[Templates.NewsArticle.Fields.Title]
                            });
        }

        protected virtual IEnumerable<IItem> GetNewsArticleItems()
        {
            var newsFolderChildren = Sitecore.Context.Database.GetItem(Templates.NewsArticle.TemplateId).Children;

            return newsFolderChildren.Any(ItemIsNewsArticleTemplate) ?
                newsFolderChildren.Where(ItemIsNewsArticleTemplate).Select(item => new ItemAdapter(item))
                : new List<ItemAdapter>();
        }

        private static bool ItemIsNewsArticleTemplate(Item item)
        {
            return item.TemplateID.ToString() == Templates.NewsArticle.TemplateId;
        }
    }
}
