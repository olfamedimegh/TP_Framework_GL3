using System.ComponentModel.DataAnnotations;

namespace LearningProject.Models
{
    public class City
    {
        [Key]
        public int Id { get; set; }
        public string CityName { get; set; }
        public string StateCode { get; set; }
        public int Zip { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string County { get; set; }
    }
}
