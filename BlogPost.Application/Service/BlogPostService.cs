using AutoMapper;
using BlogManagement.Application.Constant;
using BlogManagement.Application.IService;
using BlogManagement.Application.Model;
using BlogManagement.Core.Entity;
using BlogManagement.Data.IRepository;
using Newtonsoft.Json;

namespace BlogManagement.Application.Service
{
    public class BlogPostService : IBlogPostService
    {
        private readonly List<BlogPost> _blogList;
        private readonly IBlogPostRepository _blogPostRepository;
        private readonly IMapper _mapper;

        public BlogPostService(IBlogPostRepository blogPost, IMapper mapper)
        {
            _blogPostRepository = blogPost;
            _mapper = mapper;
            _blogList = LoadBlogPosts();
        }

        public IEnumerable<BlogPostModel> GetAll()
        {
            return _blogList.Select(_mapper.Map<BlogPostModel>);
        }

        public BlogPostModel GetById(int id)
        {
            var blog = _blogList.FirstOrDefault(p => p.Id == id);
            return _mapper.Map<BlogPostModel>(blog);
        }

        public void Add(BlogPostModel post)
        {
            post.Id = GetPostId();
            _blogList.Add(_mapper.Map<BlogPost>(post));
            SaveChanges();
        }

        public void Update(BlogPostModel post)
        {
            var existingPost = _blogList.FirstOrDefault(p => p.Id == post.Id);
            if (existingPost != null)
            {
                existingPost.UserName = post.UserName;
                existingPost.DateCreated = DateTime.Now;
                existingPost.Text = post.Text;
                SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var postToRemove = _blogList.FirstOrDefault(p => p.Id == id);
            if (postToRemove != null)
            {
                _blogList.Remove(postToRemove);
                SaveChanges();
            }
        }

        #region PrivateMethods

        private List<BlogPost> LoadBlogPosts()
        {
            var _blogDataFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataBase", "BlogData.json");
            if (!File.Exists(_blogDataFilePath))
            {
                throw new FileNotFoundException($"BlogData.Json file not found at '{_blogDataFilePath}'.");
            }

            var blogs = _blogPostRepository.Get();

            // Check if the file is empty or only contains whitespace
            if (string.IsNullOrWhiteSpace(blogs))
            {
                // Return an empty list if the file is empty
                return new List<BlogPost>();
            }
            return JsonConvert.DeserializeObject<List<BlogPost>>(blogs).OrderByDescending(s => s.Id).ToList();
        }

        private int GetPostId()
        {
            return _blogList.Count > AppConstant.IntZero ? _blogList.Max(p => p.Id) + AppConstant.IntOne : AppConstant.IntOne;
        }

        private void SaveChanges()
        {
            string blog = JsonConvert.SerializeObject(_blogList, Formatting.Indented);
            _blogPostRepository.SaveChanges(blog);
        }

        #endregion
    }

}
