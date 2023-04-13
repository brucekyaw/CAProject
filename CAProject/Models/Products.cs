namespace CAProject.Models
{
    public class Products
    {
        public Products() 
        {
            Id = new Guid();
        }

        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public string ProductImg { get;set; }
        public string ProductDescription { get; set; }
        public double ProductPrice {  get; set; }
        public double ProductRating { get; set; }

    }
}
