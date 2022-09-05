using Autofac;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleStackOverflow.Web.Models;
using SimpleStackOverflow.Web.Models.Vote;
using SimpleStackOverflow.Web.Utilities;

namespace SimpleStackOverflow.Web.Controllers
{
    [Authorize]
    public class VoteController : Controller
    {
        private readonly ILogger<VoteController> _logger;
        private ILifetimeScope _scope;

        public VoteController(ILogger<VoteController> logger, ILifetimeScope scope)
        {
            _logger = logger;
            _scope = scope;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> CommentVote(int commentId, int postId)
        {
            var model = _scope.Resolve<VoteCreateModel>();
            model.CommentId = commentId;
            await model.GetAuthorAsync(User!.Identity!.Name!);

            try
            {
                await model.VoteCommentAsync();

                TempData.Put<ResponseModel>("ResponseMessage", new ResponseModel
                {
                    Message = "Vote Given Successfully.",
                    Type = ResponseTypes.Success
                });
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                TempData.Put<ResponseModel>("ResponseMessage", new ResponseModel
                {
                    Message = "Vote Could not given.",
                    Type = ResponseTypes.Danger
                });
            }
            return RedirectToAction("Details", "Home", new { id = postId });
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> CencelCommentVote(int commentId, int postId)
        {
            var model = _scope.Resolve<VoteCreateModel>();
            model.CommentId = commentId;
            await model.GetAuthorAsync(User!.Identity!.Name!);

            try
            {
                await model.RemoveVoteAsync(commentId);

                TempData.Put<ResponseModel>("ResponseMessage", new ResponseModel
                {
                    Message = "Vote Removed.",
                    Type = ResponseTypes.Success
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                TempData.Put<ResponseModel>("ResponseMessage", new ResponseModel
                {
                    Message = "Vote Could not be Removed.",
                    Type = ResponseTypes.Danger
                });
            }
            return RedirectToAction("Details", "Home", new { id = postId });
        }

    }
}
