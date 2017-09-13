using System;

namespace DDDBlog
{
    public class CreateBlogPostRequest
    {
        public Guid BloggerId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}