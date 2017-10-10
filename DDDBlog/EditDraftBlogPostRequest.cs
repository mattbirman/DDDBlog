using System;

namespace DDDBlog
{
    public class EditDraftBlogPostRequest
    {
        public Guid BloggerId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}