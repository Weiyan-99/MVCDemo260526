using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models.EfModels;
using WebApplication2.ViewModels;

namespace WebApplication2.Controllers
{
	public class UsersController : Controller
	{
		private readonly ISpanDemoContext _context;

		public UsersController(ISpanDemoContext context)
		{
			_context = context;
		}
		public IActionResult Index()
		{
			var users = _context.Users
				.Select(u => new UserItemViewModel
				{
					Id = u.Id,
					UserName = u.UserName
				})
				.ToList();


			return View(users);
		}

		public IActionResult Create() {
			return View();
		}

		[HttpPost]
		public IActionResult Create(UserCreateViewModel vm) {
			if (ModelState.IsValid)
			{
				var user = new User() { UserName = vm.UserName };
				_context.Add(user);
				_context.SaveChangesAsync();

				//TempData["msg"]="紀錄已新增";

				return RedirectToAction("Index");
			}
			return View(vm);
		}
	}
}
