﻿using System;

using Moq;

using NUnit.Framework;

using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.FakeDb;

using SitecorePlayground.Common.Interfaces.Providers;
using SitecorePlayground.News.Models;
using SitecorePlayground.News.Providers;
using SitecorePlayground.News.Templates;

namespace SitecorePlayground.News.Test.Providers
{
    /// <summary>
    /// Unit tests for the AuthorProviderBasedOnRegularItem class.
    /// </summary>
    [TestFixture]
    [Category("Requires Sitecore.FakeDb and Sitecore license")]
    public class AuthorProviderBasedOnRegularItemTests
    {
        [Test]
        public void GetAuthor_WithValidAuthorBasedOnRegularItem_ReturnsAuthorObject()
        {
            using (var fakeDb = new Db())
            {
                // Arrange
                var authorId = ID.NewID;
                var templateId = ID.Parse(Templates.Author.TemplateId);
                DbItem fakeDbItem = GetFakeAuthorDbItem("John West", "Sitecore", authorId, templateId);
                fakeDb.Add(fakeDbItem);
                var fakeAuthorItem = fakeDb.GetItem(authorId);
                var itemProviderMock = GetItemProviderMock(fakeAuthorItem);
                var authorProvider = new AuthorProviderBasedOnRegularItem(itemProviderMock.Object);

                // Act
                Models.Author result = authorProvider.GetAuthor(authorId);

                // Assert
                Assert.AreEqual("John West", result.Name);
            }
        }

        private DbItem GetFakeAuthorDbItem(string authorName, string authorCompany, ID itemId, ID templateId)
        {
            return new DbItem(authorName, itemId, templateId)
                       {
                           { Templates.Author.Fields.AuthorName, authorName }, 
                           { Templates.Author.Fields.AuthorCompany, authorCompany }
                       };
        }

        private Mock<IItemProvider> GetItemProviderMock(Item authorItem)
        {
            var itemProviderMock = new Mock<IItemProvider>();
            itemProviderMock.Setup(mock => mock.GetItem(It.IsAny<ID>())).Returns(authorItem);

            return itemProviderMock;
        }
    }
}
