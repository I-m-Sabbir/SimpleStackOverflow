using Autofac;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleStackOverflow.Web.Models;
using SimpleStackOverflow.Web.Models.Post;
using SimpleStackOverflow.Web.Utilities;

namespace SimpleStackOverflow.Web.Controllers
{
    [Authorize]
    public class PostController : Controller
    {
        private readonly ILogger<PostController> _logger;
        private readonly ILifetimeScope _scope;

        public PostController(ILogger<PostController> logger, ILifetimeScope scope)
        {
            _logger = logger;
            _scope = scope;
        }

        public async Task<IActionResult> Index(int pn)
        {
            var model = _scope.Resolve<UserPostListModel>();
            model.PageNumber = pn == 0 ? 1 : pn;
            await model.GetUserAsync(User!.Identity!.Name!);
            var data = await model.PostListAsync();
            model.Posts = data.Item3;
            model.Pagination = PagingModel.SetPaging(model.PageNumber, 10, data.totalDisplay,
                "activeLink", Url.Action("Index", "Post", model), "disableLink");
            return View(model);
        }

        public IActionResult Create()
        {
            var model = _scope.Resolve<PostCreateModel>();
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PostCreateModel model)
        {
            model.Resolve(_scope);
            await model.GetUserAsync(User!.Identity!.Name!);
            model.CreateTime = DateTime.Now;
            if (ModelState.IsValid)
            {
                try
                {
                    await model.CreatePostAsync();

                    TempData.Put<ResponseModel>("ResponseMessage", new ResponseModel
                    {
                        Message = "Successfully added.",
                        Type = ResponseTypes.Success
                    });
                    return RedirectToAction(nameof(Index));
                }
                catch(Exception ex)
                {
                    _logger.LogError(ex, ex.Message);

                    TempData.Put<ResponseModel>("ResponseMessage", new ResponseModel
                    {
                        Message = "Faild to Post the Question.",
                        Type = ResponseTypes.Danger
                    });
                    return RedirectToAction(nameof(Index));
                }
            }

            return View(model);
        }

        public async Task<IActionResult> Details(int id)
        {
            var model = _scope.Resolve<PostUpdateModel>();
            await model.GetPostWithIncludeAsync(id);
            return View(model);
        }

        public async Task<IActionResult> Update(int id)
        {
            var model = _scope.Resolve<PostUpdateModel>();
            await model.GetPostAsync(id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(PostUpdateModel model)
        {
            model.Resolve(_scope);
            try
            {
                await model.UpdateAsync();
                TempData.Put<ResponseModel>("ResponseMessage", new ResponseModel
                {
                    Message = "Update Operation Succeed.",
                    Type = ResponseTypes.Success
                });
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                TempData.Put<ResponseModel>("ResponseMessage", new ResponseModel
                {
                    Message = "Update Operation Failed.",
                    Type = ResponseTypes.Danger
                });
                return View(model);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var model = _scope.Resolve<PostUpdateModel>();

            try
            {
                await model.DeletePostAsync(id);
                TempData.Put<ResponseModel>("ResponseMessage", new ResponseModel
                {
                    Message = "Delete Operation Succeed.",
                    Type = ResponseTypes.Success
                });
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                TempData.Put<ResponseModel>("ResponseMessage", new ResponseModel
                {
                    Message = "Delete Operation Failed.",
                    Type = ResponseTypes.Danger
                });
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
