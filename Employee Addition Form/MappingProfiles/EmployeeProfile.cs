using AutoMapper;
using Employee_Addition_Form.DAL.Entities;
using Employee_Addition_Form.ViewModels;

namespace Employee_Addition_Form.MappingProfiles
{
    public class EmployeeProfile:Profile
    {
        public EmployeeProfile()
        {
            CreateMap<EmployeeViewModel, Employee>().ReverseMap();
        }
    }
}
