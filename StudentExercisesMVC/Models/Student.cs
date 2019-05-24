using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentExercisesMVC.Models
{
    public class Student
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
        [Display(Name = "Slack handle")]
        public String SlackHandle { get; set; }

        [Required]
        public int CohortId { get; set; }

        public List<Exercise> Exercises { get; set; }

        public Cohort cohort { get; set; }

        public override string ToString()
        {
            if (cohort != null)
            {
                return $"{FirstName} {LastName} ({SlackHandle}) is in {cohort.Designation}";
            }
            else
            {
                return $"{FirstName} {LastName} ({SlackHandle})";
            }

        }
    }
}
