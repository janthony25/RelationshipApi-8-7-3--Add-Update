using System.ComponentModel.DataAnnotations;

namespace RelationshipApi_8_7_3.Models
{
    public class Make
    {
        [Key]
        public int MakeId { get; set; }
        public string MakeName { get; set; }

        // M-to-M Car-Make
        public List<CarMake> CarMake { get; set; }
    }
}
