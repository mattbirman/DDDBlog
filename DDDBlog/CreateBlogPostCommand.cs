using System;

namespace DDDBlog
{
    public class CreateBlogPostCommand
    {

        public Guid Id { get; }
        public Guid BloggerId { get; }
        public string Title { get; }
        public string Content { get; }
        public DateTimeOffset DateCreated { get; }
        
        public CreateBlogPostCommand(Guid bloggerId, string title, string content)
        {
            //validation happens here...
            Id = Guid.NewGuid();
            BloggerId = bloggerId;
            Title = title;
            Content = content;
            DateCreated = DateTimeOffset.Now;
        }
    }
}