using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsDatabase.Models
{
    public class Student
    {
        public Student()
        {
            this.Grades = new HashSet<Grade>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int? Age { get; set; }

        public int? Grade { get; set; }

        public int SchoolId { get; set; }

        public virtual School School { get; set; }

        public virtual ICollection<Grade> Grades { get; set; }
    }
}