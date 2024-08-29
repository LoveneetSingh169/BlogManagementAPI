using BlogManagement.Data.IRepository;

namespace BlogManagement.Data.Repository
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private readonly string _blogDataFilePath;

        public BlogPostRepository()
        {
            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            _blogDataFilePath = Path.Combine(baseDirectory, "DataBase", "BlogData.json");
        }

        public string Get()
        {
            return File.ReadAllText(_blogDataFilePath);
        }

        public void SaveChanges(string data)
        {
            File.WriteAllText(_blogDataFilePath, data);
        }
    }

}
