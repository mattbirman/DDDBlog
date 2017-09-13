using System;

namespace DDDBlog
{
    public class BlogPost
    {
        public Guid Id { get; }
        public string BlogName { get; }
        public string Title { get; }
        public string Content { get; }
        public Guid AuthorId { get; }
        public DateTimeOffset PublishedDate { get; }
        
        public BlogPost(Guid id, string blogName, string title, string content, Guid authorId, DateTimeOffset publishedDate)
        {
            Id = id;
            BlogName = blogName;
            Title = title;
            Content = content;
            AuthorId = authorId;
            PublishedDate = publishedDate;
        }
    }
}