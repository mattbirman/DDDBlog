using Microsoft.AspNetCore.Mvc;

namespace DDDBlog
{
    public class BlogPostsController : Controller, IBlogPostsController
    {
        public IActionResult GetPostsFor(string blogName)
        {
            return Ok();
        }
    }   
    
    public interface IBlogPostsController
    {
        IActionResult GetPostsFor(string blogName);
    }
}
