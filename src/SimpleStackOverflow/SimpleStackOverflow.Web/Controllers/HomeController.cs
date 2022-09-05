using Autofac;
using Microsoft.AspNetCore.Mvc;
using SimpleStackOverflow.Web.Models;
using SimpleStackOverflow.Web.Models.Post;
using System.Diagnostics;

namespace SimpleStackOverflow.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ILifetimeScope _scope; 

        public HomeController(ILogger<HomeController> logger, ILifetimeScope scope)
        {
            _logger = logger;
            _scope = scope;
        }

        public async Task<IActionResult> Index(int pn)
        {
            var model = _scope.Resolve<PostListModel>();
            model.PageNumber = pn == 0 ? 1 : pn;
            var data = await model.PostListAsync();
            model.Posts = data.Item3;
            model.Pagination = PagingModel.SetPaging(model.PageNumber, 2, data.totalDisplay,
                "activeLink", Url.Action("Index", "Home", model), "disableLink");
            return View(model);
        }

        public async Task<IActionResult> Details(int id)
        {
            var model = _scope.Resolve<PostUpdateModel>();
            await model.GetPostWithIncludeAsync(id);
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}