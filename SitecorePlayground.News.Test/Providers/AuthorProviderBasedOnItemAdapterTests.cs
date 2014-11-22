using System;

using Moq;

using NUnit.Framework;

using Sitecore.Data;

using SitecorePlayground.Common.Interfaces.Adapters;
using SitecorePlayground.Common.Interfaces.Providers;
using SitecorePlayground.News.Models;
using SitecorePlayground.News.Providers;
using SitecorePlayground.News.Templates;

namespace SitecorePlayground.News.Test.Providers
{
    /// <summary>
    /// Unit tests for the AuthorProviderBasedOnItemAdapter.
    /// </summary>
    [TestFixture]
    public class AuthorProviderBasedOnItemAdapterTests
    {
        [Test]
        public void GetAuthor_WithValidAuthorBasedOnItemAdapter_ReturnsAuthorObject()
        {
            // Arrange
            var authorItemId = new ID(Guid.NewGuid());
            var authorItemMock = GetAuthorItemMock(authorItemId, "John West", "Sitecore");
            var itemProviderMock = GetItemProviderMock(authorItemMock.Object);
            var authorProvider = new AuthorProviderBasedOnItemAdapter(itemProviderMock.Object);

            // Act
            Author result = authorProvider.GetAuthor(authorItemId);

            // Assert
            Assert.AreEqual("John West", result.Name);
        }

        private Mock<IItemProvider> GetItemProviderMock(IItem authorItem)
        {
            var itemProviderMock = new Mock<IItemProvider>();
            itemProviderMock.Setup(mock => mock.GetAdaptedItem(It.IsAny<ID>()))
                .Returns(authorItem);

            return itemProviderMock;
        }

        private static Mock<IItem> GetAuthorItemMock(ID itemId, string authorName, string companyName)
        {
            var itemMock = new Mock<IItem>();
            itemMock.SetupGet(mock => mock.TemplateId).Returns(new ID(AuthorTemplate.TemplateId));
            itemMock.SetupGet(mock => mock.Id).Returns(itemId);
            itemMock.SetupGet(mock => mock[AuthorTemplate.Fields.AuthorName]).Returns(authorName);
            itemMock.SetupGet(mock => mock[AuthorTemplate.Fields.AuthorCompany]).Returns(companyName);

            return itemMock;
        }
    }
}
