using System.ComponentModel.DataAnnotations;

namespace LearningProject.Models
{
    public class State
    {
        [Key]
        public int Id { get; set; }
        public string StateName { get; set; }
        public string StateCode { get; set; }
    }
}
