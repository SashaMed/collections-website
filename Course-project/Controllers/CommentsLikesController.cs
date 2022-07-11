using System.Security.Claims;
using Course_project.Data;
using Course_project.Models;
using Microsoft.AspNetCore.Mvc;

namespace Course_project.Controllers
{
    public class CommentsLikesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CommentsLikesController(ApplicationDbContext context)
        {
            _context = context;
        }


        public IActionResult GetLikesCheck(int id)
        {
            var userId = GetUserId();
            var likes = _context.Likes.Where(m => m.ItemId == id).ToList();
            var userLike = likes.Where(m => m.UserId == userId).ToList();
            if (userLike.Count() == 0)
            {
                return Content("0");
            }
            return Content("1");
        }

        public IActionResult GetLikesCount(int id)
		{
            var count = _context.Likes.Where(m => m.ItemId == id).ToList().Count();
            return Content(count.ToString());
        }

        public IActionResult OnLikeClick(int id)
        {
            var userId = GetUserId();
            var count = _context.Likes.Where(m => m.ItemId == id).ToList().Count();
            if (userId == null)
			{
                return Content(count.ToString());
			}
            var userLike = _context.Likes.FirstOrDefault(m => m.UserId == userId);
            if (userLike == null)
			{
                var like = new Like { 
                    UserId = userId,
                    ItemId = id
                };
                _context.Likes.Add(like);
                _context.SaveChanges();
                return Content((++count).ToString());
            }
            _context.Likes.Remove(userLike);
            _context.SaveChanges();
            return Content((--count).ToString());
        }

        [HttpPost]
        public async Task<IActionResult> PostComment(string msg)
        {
            var vars = msg.Split("||");
            var message = new Comment
            {
                Message = vars[0],
                UserId = GetUserId(),
                UserName = vars[2],
                ItemId = int.Parse(vars[3]),
                DateTime = DateTime.Now,
            };
            _context.Comments.Add(message);
            await _context.SaveChangesAsync();

            return Content("ok");
        }

         

        public string GetUserId()
        {
            if (User.Identity.IsAuthenticated)
            {
                var claimsIdentity = (ClaimsIdentity)this.User.Identity;
                var claim = claimsIdentity.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
                var userId = claim.Value;
                return userId;
            }
            return null;
        }
    }
}
