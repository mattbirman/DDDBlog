using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace DDDBlog
{
    public class BlogPostsController : Controller
    {
        [HttpPost]
        [Route("blog/{name}")]
        public IActionResult CreateBlog(string name, Guid id)
        {
            var blog = new Blog(new List<BlogPost>(), new List<DraftBlogPost>(), name);
            
            BlogRepository.Save(blog);
            
            return Ok();
        }
        
        [HttpGet]
        [Route("blog/{name}")]
        public IActionResult GetBlog(string name)
        {
            var blog = BlogRepository.GetBlog(name);
            
            return !Exists(blog)
                ? NotFound() as IActionResult
                : Ok(new { blogPosts = blog.BlogPosts, draftBlogPosts = blog.DraftBlogPosts});
        }
        
        [HttpGet]
        [Route("blog/{name}/posts/{id}")]
        public IActionResult GetPost(string name, Guid id)
        {
            var blog = BlogRepository.GetBlog(name);
            if (!Exists(blog))
                return NotFound();

            var blogPost = blog.BlogPosts.FirstOrDefault(bp => bp.Id == id);

            return !Exists(blogPost)
                ? NotFound() as IActionResult
                : Ok(blogPost);
        }
    
        [HttpPost]
        [Route("/blog/{name}/posts")]
        public IActionResult CreateBlogPost(string name, [FromBody] CreateBlogPostRequest createBlogPostRequest)
        {
            var blog = BlogRepository.GetBlog(name);
            if (!Exists(blog))
                return NotFound();
            
            var blogPost = new BlogPost(Guid.NewGuid(), createBlogPostRequest.Title, createBlogPostRequest.Content, createBlogPostRequest.BloggerId, DateTimeOffset.Now);
            blog.AddBlogPost(blogPost);
            //emit event
            
            return Ok();
        }
        
        [HttpPost]
        [Route("/blog/{name}/draftposts")]
        public IActionResult CreateDraftBlogPost(string name, [FromBody] CreateBlogPostRequest createBlogPostRequest)
        {
            var blog = BlogRepository.GetBlog(name);
            if (!Exists(blog))
                return NotFound();
            
            var draftBlogPost = new DraftBlogPost(Guid.NewGuid(), createBlogPostRequest.Title, createBlogPostRequest.Content, createBlogPostRequest.BloggerId, DateTimeOffset.Now);
            blog.AddDraftBlogPost(draftBlogPost);
            //emit event
            
            return Ok();
        }
        
        [HttpPost]
        [Route("/blog/{name}/draftposts/{id}/edit")]
        public IActionResult EditDraftBlogPost(string name, Guid id, [FromBody] EditDraftBlogPostRequest editDraftBlogPostRequest)
        {
            var blog = BlogRepository.GetBlog(name);
            if (!Exists(blog))
                return NotFound();

            var draftBlogPost = blog.DraftBlogPosts.FirstOrDefault(dp => dp.Id == id);
            if (!Exists(draftBlogPost))
                return NotFound();

            if (!draftBlogPost.CanEditDraftBlogPost(editDraftBlogPostRequest.BloggerId))
                return Unauthorized();

            draftBlogPost.Edit(editDraftBlogPostRequest.Title, editDraftBlogPostRequest.Content);
            //emit event
            
            return Ok();
        }
        
        [HttpPost]
        [Route("/blog/{name}/draftposts/{id}/publish")]
        public IActionResult PublishDraftBlogPost(string name, Guid id)
        {
            var blog = BlogRepository.GetBlog(name);
            if (!blog.CanPublishDraftBlogPost(id))
                throw new DomainException($"Cannot publish draft blog post with id {id}");
            
            blog.PublishDraftBlogPost(id);
            
            return Ok();
        }
        
        private static bool Exists<T>(T entity)
        {
            return entity != null;
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
