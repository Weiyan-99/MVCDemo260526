using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.ViewModels
{
	public class UserItemViewModel
	{
		public int Id { get; set; }

		[DisplayName("使用者名稱")]
		public string UserName { get; set; }
	}
	public class UserCreateViewModel
	{
		public int Id { get; set; }

		[DisplayName("使用者名稱")]
		[Required(ErrorMessage = "{0}必填")]
		public string UserName { get; set; }
	}
	public class UserUpdateViewModel
	{
		public int Id { get; set; }

		[DisplayName("使用者名稱")]
		[Required(ErrorMessage = "請輸入使用者名稱")]
		public string UserName { get; set; }
	}
}
