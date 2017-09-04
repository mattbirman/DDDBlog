using System.Net;
using System.Threading.Tasks;
using DDDBlog.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace DDDBlog.Tests
{
    public class GetBlogPostsControllerTests
    {
        private readonly IBlogPostsController _blogPostsController;

        public GetBlogPostsControllerTests()
        {
            _blogPostsController = new BlogPostsController();
        }
        
        [Fact]
        public void Given_a_anonymous_user_When_they_get_all_blog_posts_for_blog_x_Then_a_list_of_blog_posts_should_be_returned()
        {
            const string blogName = "mattsblog";
            var okResponse = _blogPostsController.GetPostsFor(blogName) as OkObjectResult;
            
            Assert.NotNull(okResponse);
        }
    }
}
