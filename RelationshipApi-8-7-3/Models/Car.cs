using System.ComponentModel.DataAnnotations;

namespace RelationshipApi_8_7_3.Models
{
    public class Car
    {
        [Key]
        public int CarId { get; set; }
        public string CarRego { get; set; }
        public string CarModel { get; set; }
        public int CarYear { get; set; }

        // FK to Customer
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        // M-to-M Car-Make
        public List<CarMake> CarMake { get; set; }
    }
}
