namespace RelationshipApi_8_7_3.Models.Dto
{
    public class UpdateCustomerCarDto
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int CarId { get; set; }
        public string CarRego { get; set; }
        public string CarModel { get; set; }
        public int CarYear { get; set; }
        public int MakeId { get; set; }
    }
}
