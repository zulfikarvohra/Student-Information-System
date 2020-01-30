using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudentInformationSystem.Entities
{
    public class StudentMaster : BaseEntity
    {
        public StudentMaster()
        {
            Files = new List<Files>();
        }
        public System.Int64 Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(200, ErrorMessage = "Name can't be longer than 200 characters")]
        public string StudentName { get; set; }

        [Required(ErrorMessage = "Grade is required")]
        public int Grade { get; set; }

        [Required(ErrorMessage = "Date of birth is required")]
        public DateTime DateOfBirth { get; set; }

        public string Address { get; set; }

        public ICollection<Files> Files { get; set; }
      
    }
}
