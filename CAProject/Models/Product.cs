using System.ComponentModel.DataAnnotations;

namespace CAProject.Models
{
    public class Product
    {

        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductImg { get;set; }
        public string ProductDescription { get; set; }
        public double ProductPrice {  get; set; }
        public double ProductRating { get; set; }
        public virtual List<OrderProduct> OrderProducts { get; set; }
        public virtual List<ActivationCode> ActivationCodes { get; set; }
    }
}
