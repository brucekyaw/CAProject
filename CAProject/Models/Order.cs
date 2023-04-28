using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace CAProject.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public virtual User User { get; set; }
        public virtual List<OrderProduct> OrderProducts { get; set; }
        public virtual List<ActivationCode> ActivationCodes { get; set; }

    }
}
