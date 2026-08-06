using ShopManagementSystem.Data.Entities.Orders;
using System.ComponentModel.DataAnnotations;

namespace ShopManagementSystem.Data.Entities
{
    public class User
    {
        public int Id { get; set; }
        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(300)]
        public string Name { get; set; }
        [Display(Name = "رمزعبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Password { get; set; }
        [Display(Name = "تاریخ ثبت نام")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public DateTime RegisterDate { get; set; }
        [Display(Name = "ادمین")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public bool IsAdmin { get; set; }

        public List<Order> Orders { get; set; }
    }
}
