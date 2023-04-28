namespace CAProject.Models
{
    public class ActivationCode
    {

        public ActivationCode() 
        {
            ActivationCodeId = Guid.NewGuid();
        }
        public Guid ActivationCodeId { get; set; }
        public int OrderId { get; set; }
        public virtual int ProductId { get; set;}
        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }
    }
}
