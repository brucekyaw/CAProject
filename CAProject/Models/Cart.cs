using System.ComponentModel.DataAnnotations;

namespace CAProject.Models
{
    public class Cart
    {
        [Key]
        public int ProductId { get;set; }

        public int Quantity { get;set; }

        public virtual Product Product { get; set; }

    }
}
