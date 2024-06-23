using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Employee_API.Model
{
    public class EmployeeModel
    {
        [Key]
        public int EmployeeId { get; set; }
        public string Empname { get; set; }
        public string Department { get; set; }
        public int Salary { get; set; }

    }
}
