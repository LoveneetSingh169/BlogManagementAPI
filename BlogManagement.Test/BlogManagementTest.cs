using BlogManagement.API.Controllers;
using BlogManagement.Application.IService;
using BlogManagement.Application.Model;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace BlogManagement.Tests
{
    [TestFixture]
    public class BlogManagementTests
    {
        private BlogPostController _controller;
        private Mock<IBlogPostService> _serviceMock;

        [SetUp]
        public void SetUp()
        {
            _serviceMock = new Mock<IBlogPostService>();
            _controller = new BlogPostController(_serviceMock.Object);
        }

        [Test]
        public void GetBlogs_ShouldReturn_OkResult_WithListOfPosts()
        {
            //create mock data
            var mockPosts = new List<BlogPostModel>
            {
                new BlogPostModel { Id = 1, UserName = "TestUser1", Text = "Sample post 1", DateCreated=DateTime.Now },
                new BlogPostModel { Id = 2, UserName = "TestUser2", Text = "Sample post 2", DateCreated=DateTime.Now }
            };
            _serviceMock.Setup(service => service.GetAll()).Returns(mockPosts.ToList());

            //Get data using controller
            var result = _controller.Get();

            //verify result
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            Assert.IsInstanceOf<List<BlogPostModel>>(okResult.Value);
            var returnValue = okResult.Value as List<BlogPostModel>;
            Assert.AreEqual(2, returnValue.Count);
        }

        [Test]
        public void AddBlog_ShouldReturn_CreatedAtAction_WithNewBlog()
        {
            // create mock data
            var newPost = new BlogPostModel { Id = 3, UserName = "NewUser", Text = "New post", DateCreated=DateTime.Now };
            _serviceMock.Setup(service => service.Add(It.IsAny<BlogPostModel>()));
            _serviceMock.Setup(service => service.GetById(newPost.Id)).Returns(newPost);
            
            // post data using controller
            var result = _controller.Post(newPost);

            // verify result
            Assert.IsInstanceOf<CreatedAtActionResult>(result);
            var createdAtActionResult = result as CreatedAtActionResult;
            Assert.IsInstanceOf<BlogPostModel>(createdAtActionResult.Value);
            var returnValue = createdAtActionResult.Value as BlogPostModel;
            Assert.AreEqual(newPost.Id, returnValue.Id);
        }
    }
}
