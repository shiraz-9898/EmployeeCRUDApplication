using System.ComponentModel.DataAnnotations;

namespace ApplicationUsingCrudApi.Models
{
    public class Employee
    {

        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string department { get; set; }
        [Required]
        public float salary { get; set; }
        [Required]
        public int contact { get; set; }

    }
}
