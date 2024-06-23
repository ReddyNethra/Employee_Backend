using AutoMapper;

namespace Employee_API.Model
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<EmployeeModel, Employeemodel_DTO>().ReverseMap();
            CreateMap<EmployeeModel, PostEmployeeModel_DTO>().ReverseMap();
        }
    }
}
