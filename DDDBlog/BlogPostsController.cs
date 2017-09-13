using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace DDDBlog
{
    public class BlogPostsController : Controller
    {
        [HttpGet]
        [Route("blog/{name}/posts/{id}")]
        public IActionResult GetPost(string name, Guid id)
        {
            var blogPost = BlogPostRepository.BlogPosts.FirstOrDefault(x => x.Id == id && x.BlogName == name);

            return blogPost == null
                ? NotFound() as IActionResult
                : Ok(blogPost);
        }
        
        [HttpGet]
        [Route("blog/{name}/posts/")]
        public IActionResult GetPostsFor(string name)
        {
            var blogPosts = BlogPostRepository.BlogPosts.Where(x => x.BlogName == name);
            return Ok(blogPosts);
        }
    
        [HttpPost]
        [Route("/blog/{name}/posts")]
        public IActionResult CreateBlogPost(string name, [FromBody] CreateBlogPostRequest createBlogPostRequest)
        {
            var blogPost = new BlogPost(Guid.NewGuid(), name, createBlogPostRequest.Title, createBlogPostRequest.Content, createBlogPostRequest.BloggerId, DateTimeOffset.Now);
            
            BlogPostRepository.BlogPosts.Add(blogPost);
            
            return Ok();
        }
        
        //Add a capability for creating a draft, editing a draft, and turning a draft into a real post
        //whats the relationshop between a draft and a post
        
        //user that may have a status, like banned/needs to pay/
        
        //statistics about a user, like number of posts, if number of posts is 100 send them a voucher
        
        //what would viewmodel incorporating these two domains look like
        
        //entity called Blogger aggregate that has a status
        //does the bloggest exist or not, if they exist can they post, if not why?
        
        //blogger, blog and blogentry
        
        
        //statistics domain 
        
    }
}
