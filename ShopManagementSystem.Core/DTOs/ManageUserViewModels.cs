using System.ComponentModel.DataAnnotations;

namespace ShopManagementSystem.Core.DTOs
{
    public class EditUserViweModel
    {
        public int UserId { get; set; }
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(300)]
        [Display(Name = "نام کاربری")]
        public string Name { get; set; }
        [MaxLength(50)]
        [DataType(DataType.Password)]
        [Display(Name = "رمز عبور")]
        public string? Password { get; set; }
        public bool IsAdmin { get; set; }
    }
}
