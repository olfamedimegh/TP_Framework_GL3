using System.ComponentModel.DataAnnotations.Schema;

namespace TP_3.Models
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }

        public List<Movie>? Movies { get; set; }

        public Guid? MembershiptypeId { get; set; }

        [ForeignKey("MembershiptypeId")]  // Define the foreign key relationship
        public virtual Membershiptype? Membershiptype { get; set; }  // Navigation property to Membershiptype

    }

}
