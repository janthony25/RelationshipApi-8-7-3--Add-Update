﻿namespace RelationshipApi_8_7_3.Models.Dto
{
    public class CarDto
    {
        public int CarId { get; set; }
        public string CarRego { get; set; }
        public string CarModel { get; set; }
        public int CarYear { get; set; }
        public List<MakeDto> CarMake { get; set; }
    }
}