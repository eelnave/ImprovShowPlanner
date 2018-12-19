using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ImprovShowPlanner.Models
{
    public class Player
    {
        public int PlayerId { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Last name cannot be longer than 50 characters.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } 
        [Display(Name = "New Player")]
        public bool NewPlayer { get; set; }

        public ICollection<Show> ShowDetails { get; set; }
    }
}