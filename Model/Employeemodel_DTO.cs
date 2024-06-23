using System.ComponentModel.DataAnnotations;

namespace Employee_API.Model
{
    public class Employeemodel_DTO
    {
        [Key]
        public int EmployeeId { get; set; }
        public string Empname { get; set; }
        public string Department { get; set; }
        public int Salary { get; set; }
    }
}
