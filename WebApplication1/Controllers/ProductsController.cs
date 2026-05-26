using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models.EfModels;

namespace WebApplication1.Controllers
{
	public class ProductsController : Controller
	{
		private readonly dbFirstAppContext _context;

		public ProductsController(dbFirstAppContext context)
		{
			_context = context;
		}

		//Get: Products
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		//GET: Products/Create
		//[HttpGet]

		//// Post: Products/Create
		//[HttpPost]
		//[ValidateAntiForgeryToken]

		////GET: Products/Edit/5
		//[HttpGet]

		//// Post: Products/Edit
		//[HttpPost]
		//[ValidateAntiForgeryToken]


	}
}
