using System.Collections.Generic;
using DDDBlog.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DDDBlog
{
    public class BlogPostsController : Controller, IBlogPostsController
    {
        public IActionResult GetPostsFor(string blogName)
        {
            return Ok(new List<BlogPostViewModel>());
        }
    }
}
