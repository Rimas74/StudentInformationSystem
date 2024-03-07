using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.Models
    {
    public class Lecture
        {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LectureId { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        public ICollection<Department> Departments { get; set; }
        public ICollection<Student> Students { get; set; }
        }
    }
