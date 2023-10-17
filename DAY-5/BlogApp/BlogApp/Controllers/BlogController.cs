using BlogApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers
{
    [Route("blog")]
    public class BlogController : Controller
    {
        // Mocking blog post data
        private List<BlogPost> _blogPosts = new List<BlogPost>
    {
        new BlogPost { Title = "First Blog Post", Content = "Content of the first blog post.", Author = "John Doe" },
        new BlogPost { Title = "Second Blog Post", Content = "Content of the second blog post.", Author = "Jane Smith" },
         new BlogPost { Title = "3 Blog Post", Content = "Content of the third blog post.", Author = "John Doe" },
        new BlogPost { Title = "4 Blog Post", Content = "Content of the fourth blog post.", Author = "Jane Smith" }
    };



         [Route("")] // Maps to /blog
        public IActionResult Index()
        {
            return View("~/Views/Home/Index.cshtml");
        }
        [Route("posts")] // Maps to /blog/posts
        public IActionResult PostsList()
        {

            return View(_blogPosts);
        }

        [Route("about")]// Maps to /blog/about
        public IActionResult About()
        {
            ViewData["Title"] = "About";
            return View("~/Views/Home/About.cshtml");
        }
    }
}
