using System;

namespace DDDBlog.ViewModels
{
    public class BlogPostViewModel
    {
        public string Title { get; }
        public string Content { get; }
        public AuthorViewModel AuthorViewModel { get; }
        public DateTimeOffset PublishedDate { get; }

        public BlogPostViewModel(
            string title, 
            string content, 
            AuthorViewModel authorViewModel, 
            DateTimeOffset publishedDate
            )
        {
            if (string.IsNullOrEmpty(title)) throw new ArgumentException(nameof(title));
            if (string.IsNullOrEmpty(content)) throw new ArgumentException(nameof(content));
            if (authorViewModel == null) throw new ArgumentException(nameof(authorViewModel));
            if (publishedDate == DateTimeOffset.MinValue) throw new ArgumentException(nameof(publishedDate));
            
            Title = title;
            Content = content;
            AuthorViewModel = authorViewModel;
            PublishedDate = publishedDate;
        }
    }
}