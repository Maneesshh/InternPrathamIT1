using System.ComponentModel.DataAnnotations.Schema;

namespace InternApp.Models
{
    [Table("Employee")]

        public class Address
        {
        public int Id { get; set; }
        public string? email { get; set; }

        public string? Name { get; set; }
            public string? Password { get; set; }
        public string? Cpassword { get; set; }
        }
     
}
