using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DevBlogsConsumer.Repositories.Tests.ArticleRepositoryTests
{
    [TestCategory(TEST_CATEGORY)]
    [TestClass]
    public class RemoveDuplicatesByArticleIdTests : BaseArticleRepositoryTests
    {
        [TestInitialize]
        public void Initialize()
        {

        }

        [TestMethod]
        public void RemoveDuplicatesByArticleId_RemovesDuplicates()
        {
            // TODO: Insert unit test functionality
        }

        public void RemoveDuplicatesByArticleId_DoesNotAllowNullArticles()
        {
            // TODO: Insert unit test functionality
        }

        public void RemoveDuplicatesByArticleId_DoesNotAllowEmptyArticles()
        {
            // TODO: Insert unit test functionality
        }

        public void RemoveDuplicatesByArticleId_DoesNotAllowNullArticleIds()
        {
            // TODO: Insert unit test functionality
        }

        public void RemoveDuplicatesByArticleId_DoesNotAllowEmptyArticleIds()
        {
            // TODO: Insert unit test functionality
        }
    }
}
