using System.Collections.Generic;
using System.Linq;

namespace DDDBlog
{
    public static class BlogRepository
    {
        public static IList<Blog> Blogs = new List<Blog>();

        public static Blog GetBlog(string name)
        {
            return Blogs.FirstOrDefault(b => b.Name == name);
        }

        public static void Save(Blog blog)
        {
            Blogs.Add(blog);
        }
    }

//    public static class BlogPostRepository
//    {
//        public static IList<BlogPost> BlogPosts = new List<BlogPost>();
//    }
//
//    public static class DraftBlogPostRepository
//    {
//        public static IList<DraftBlogPost> DraftBlogPosts = new List<DraftBlogPost>();
//    }
}