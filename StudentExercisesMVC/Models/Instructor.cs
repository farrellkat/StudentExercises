using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentExercisesMVC.Models
{
    public class Instructor
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(80)]
        [Display(Name = "First name")]
        public String FirstName { get; set; }

        [Required]
        [StringLength(80)]
        [Display(Name = "Last name")]
        public String LastName { get; set; }

        [Required]
        [StringLength(80)]
        [Display(Name = "Slack Handle")]
        public String SlackHandle { get; set; }

        [Required]
        [StringLength(80)]
        public String Specialty { get; set; }

        [Required]
        public int CohortId { get; set; }

        [Required]
        public Cohort Cohort { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName} of {Cohort.Designation}'s slack handle is {SlackHandle}.\n{FirstName} specializes in {Specialty}\n";
        }
    }
}
