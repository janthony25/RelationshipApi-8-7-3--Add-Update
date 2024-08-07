namespace RelationshipApi_8_7_3.Models.Dto
{
    public class CustomerDto
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public List<CarDto> Car { get; set; }
    }
}
