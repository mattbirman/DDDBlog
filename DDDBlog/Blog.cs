using System;
using System.Collections.Generic;
using System.Linq;

namespace DDDBlog
{
    public class Blog
    {
        private readonly IList<BlogPost> _blogPosts;
        private readonly IList<DraftBlogPost> _draftBlogPosts;

        public IEnumerable<BlogPost> BlogPosts => _blogPosts;
        public IEnumerable<DraftBlogPost> DraftBlogPosts => _draftBlogPosts;
        public string Name { get; }
        
        public Blog(IEnumerable<BlogPost> blogPosts, IEnumerable<DraftBlogPost> draftBlogPosts, string name)
        {
            Name = name;
            _blogPosts = blogPosts as List<BlogPost> ?? new List<BlogPost>();
            _draftBlogPosts = draftBlogPosts as List<DraftBlogPost> ?? new List<DraftBlogPost>();
        }

        public void AddBlogPost(BlogPost blogPost)
        {
            _blogPosts.Add(blogPost);
        }

        public void AddDraftBlogPost(DraftBlogPost draftBlogPost)
        {
            _draftBlogPosts.Add(draftBlogPost);
        }

        public void PublishDraftBlogPost(Guid id)
        {
            if (!CanPublishDraftBlogPost(id))
                throw new DomainException("Check if CanPublishDraftBlogPost before publishing a draft blog post");

            var draftBlogPost = _draftBlogPosts.First(dp => dp.Id == id);

            var publishedBlogPost = BlogPost.CreateFromDraft(draftBlogPost);
            _draftBlogPosts.Remove(draftBlogPost);
            _blogPosts.Add(publishedBlogPost);
        }

        public bool CanPublishDraftBlogPost(Guid id)
        {
            return _draftBlogPosts.Any(dp => dp.Id == id);
        }
    }
}