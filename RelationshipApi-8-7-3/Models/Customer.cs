using System.ComponentModel.DataAnnotations;

namespace RelationshipApi_8_7_3.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }

        // 1-to-M Customer-Car
        public ICollection<Car> Car { get; set; }
    }
}
