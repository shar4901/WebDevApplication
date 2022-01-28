using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_4_Movies.Models
{
    public class StudentModel
    {
        [Key]
        [Required]
        public int student_id { get; set; }
        [Required]
        public string first_name { get; set; }
        [Required]
        public string last_name { get; set; }
        [Required]
        public string street_address { get; set; }
        [Required]
        public string city { get; set; }
        [Required]
        public string state { get; set; }
        [Required]
        public int zip { get; set; }
        [Required]
        [Phone]
        public string phone_number { get; set; }
        [Required]
        [EmailAddress]
        public string email { get; set; }
        [Required]
        public string category { get; set; }
    }
}
