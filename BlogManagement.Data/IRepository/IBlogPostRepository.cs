namespace BlogManagement.Data.IRepository
{
    public interface IBlogPostRepository
    {
        /// <summary>
        /// Get All Blogs
        /// </summary>
        /// <returns>Blogs</returns>
        string Get();

        /// <summary>
        /// SaveChanges
        /// </summary>
        /// <param name="data">blog</param>
        void SaveChanges(string data);
    }

}
