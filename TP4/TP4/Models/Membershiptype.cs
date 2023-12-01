using System.ComponentModel.DataAnnotations;

namespace TP4.Models
{
    public class Membershiptype
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string SignUpFee { get; set; }

        public int DurationInMonth { get; set; }
        public double DicountRate { get; set; }

        public List<Customer> Customers { get; set; }

    }
}
