using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
		[ValidateAntiForgeryToken]
		public IActionResult Create(UserCreateViewModel vm) {
			if (ModelState.IsValid)
			{
				var user = new User() { UserName = vm.UserName };
				_context.Add(user);
				_context.SaveChanges();

				//TempData["msg"]="紀錄已新增";

				return RedirectToAction("Index");
			}
			return View(vm);
		}

		// GET: Users/Edit/5
		public IActionResult Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}
			var user = _context.Users.Find(id);
			if(user == null)
			{
				return NotFound();
			}

			var vm = new UserUpdateViewModel
			{
				Id = user.Id,
				UserName = user.UserName
			};

			return View(vm);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(int? id, UserUpdateViewModel vm)
		{
			if(id != vm.Id)
			{
				return NotFound();
			}
			if (ModelState.IsValid)
			{
				var user = new User { Id = vm.Id ,UserName = vm.UserName };
				_context.Update(user);
				_context.SaveChanges();

				//TempData["msg"]="紀錄已新增";

				return RedirectToAction("Index");
			}
			return View(vm);
		}


		// GET: Users/Delete/5
		public IActionResult Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var user = _context.Users.Find(id);

			if (user == null)
			{
				return NotFound();
			}

			return View(user);
		}

		// POST: Users/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public IActionResult DeleteConfirmed(int id)
		{
			var user =  _context.Users.Find(id);
			if (user != null)
			{
				_context.Users.Remove(user);
			}

			_context.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}
