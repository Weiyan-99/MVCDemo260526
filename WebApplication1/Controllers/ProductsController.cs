using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
	public class ProductsController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
