using BlogManagement.Application.Model;

namespace BlogManagement.Application.IService
{
    public interface IBlogPostService
    {
        /// <summary>
        /// Get All Blogs
        /// </summary>
        /// <returns>Enumerable of Blogs</returns>
        IEnumerable<BlogPostModel> GetAll();

        /// <summary>
        /// Get Blog By Id
        /// </summary>
        /// <param name="id">BlogId (UniqueIdentifier for blogs)</param>
        /// <returns>Blog</returns>
        BlogPostModel GetById(int id);

        /// <summary>
        /// Add Blog
        /// </summary>
        /// <param name="post">Blog</param>
        void Add(BlogPostModel post);

        /// <summary>
        /// Update Blog
        /// </summary>
        /// <param name="post">Blog</param>
        void Update(BlogPostModel post);

        /// <summary>
        /// Delete Blog
        /// </summary>
        /// <param name="id">BlogId (UniqueIdentifier for blogs)</param>
        void Delete(int id);
    }

}
