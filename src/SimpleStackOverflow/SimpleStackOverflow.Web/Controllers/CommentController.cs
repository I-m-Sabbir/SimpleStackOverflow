using Autofac;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleStackOverflow.Web.Models;
using SimpleStackOverflow.Web.Models.Comment;
using SimpleStackOverflow.Web.Utilities;

namespace SimpleStackOverflow.Web.Controllers
{
    [Authorize]
    public class CommentController : Controller
    {
        private readonly ILogger<CommentController> _logger;
        private ILifetimeScope _scope;

        public CommentController(ILogger<CommentController> logger, ILifetimeScope scope)
        {
            _logger = logger;
            _scope = scope;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return RedirectToAction("Index", "Home");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int postId, string commentText)
        {
            var model = _scope.Resolve<CreateCommentModel>();
            await model.GetAuthor(User!.Identity!.Name!);
            model.CommentText = commentText;
            model.PostId = postId;

            try
            {
                await model.CreateCommentAsync();

                TempData.Put<ResponseModel>("ResponseMessage", new ResponseModel
                {
                    Message = "Successfully Commented.",
                    Type = ResponseTypes.Success
                });
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                TempData.Put<ResponseModel>("ResponseMessage", new ResponseModel
                {
                    Message = "Faild to Comment.",
                    Type = ResponseTypes.Danger
                });
            }

            return RedirectToAction("Details", "Home", new { id = postId });
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Verify(int commentId, int postId)
        {
            var model = _scope.Resolve<CreateCommentModel>();
            try
            {
                await model.VerifyCommentAsync(commentId);
                
                TempData.Put<ResponseModel>("ResponseMessage", new ResponseModel
                {
                    Message = "Comment Verified.",
                    Type = ResponseTypes.Success
                });
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                TempData.Put<ResponseModel>("ResponseMessage", new ResponseModel
                {
                    Message = "Faild to Comment.",
                    Type = ResponseTypes.Danger
                });
            }

            return RedirectToAction("Details", "Home", new { id = postId });
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Cencel(int commentId, int postId)
        {
            var model = _scope.Resolve<CreateCommentModel>();
            try
            {
                await model.CencelVerificationAsync(commentId);

                TempData.Put<ResponseModel>("ResponseMessage", new ResponseModel
                {
                    Message = "Comment Verified.",
                    Type = ResponseTypes.Success
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                TempData.Put<ResponseModel>("ResponseMessage", new ResponseModel
                {
                    Message = "Faild to Comment.",
                    Type = ResponseTypes.Danger
                });
            }

            return RedirectToAction("Details", "Home", new { id = postId });
        }


    }
}
