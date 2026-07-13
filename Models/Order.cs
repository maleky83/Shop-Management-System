using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace program.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public int UserId { get; set; }
        [Required]
        public DateTime CreateTime { get; set; }
        public int ProductId { get; set; }
        public bool IsFinaly { get; set; }

        [ForeignKey("UserId")]
        public Users Users { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
