using System;

namespace DDDBlog
{
    public class DraftBlogPost
    {
        public Guid Id { get; }
        public string Title { get; private set; }
        public string Content { get; private set; }
        public Guid AuthorId { get; }
        public DateTimeOffset PublishedDate { get; }
        
        public DraftBlogPost(Guid id, string title, string content, Guid authorId, DateTimeOffset publishedDate)
        {
            Id = id;
            Title = title;
            Content = content;
            AuthorId = authorId;
            PublishedDate = publishedDate;
        }

        public bool CanEditDraftBlogPost(Guid editorAuthorId)
        {
            return editorAuthorId == AuthorId;
        }

        public void Edit(string title, string content)
        {
            Title = title;
            Content = content;
        }
    }
}