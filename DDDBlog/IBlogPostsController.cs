using Microsoft.AspNetCore.Mvc;

namespace DDDBlog
{
    public interface IBlogPostsController
    {
        IActionResult GetPostsFor(string blogName);
    }
}