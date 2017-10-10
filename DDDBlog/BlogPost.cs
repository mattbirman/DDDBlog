using System;

namespace DDDBlog
{
    public class BlogPost
    {
        public Guid Id { get; }
        public string Title { get; }
        public string Content { get; }
        public Guid AuthorId { get; }
        public DateTimeOffset PublishedDate { get; }
        
        public BlogPost(Guid id, string title, string content, Guid authorId, DateTimeOffset publishedDate)
        {
            Id = id;
            Title = title;
            Content = content;
            AuthorId = authorId;
            PublishedDate = publishedDate;
        }

        public static BlogPost CreateFromDraft(DraftBlogPost draftBlogPost)
        {
            return new BlogPost(draftBlogPost.Id, draftBlogPost.Title, draftBlogPost.Content, draftBlogPost.AuthorId, DateTimeOffset.Now);
        }
    }
}