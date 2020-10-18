using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public ICollection<StudentSubject> StudentSubjects { get; set; }
    }
}
