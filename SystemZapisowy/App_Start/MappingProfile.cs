using AutoMapper;
using SystemZapisowy.Models;
using SystemZapisowy.ViewModels.Course;
using SystemZapisowy.ViewModels.Group;
using SystemZapisowy.ViewModels.User.Administrator;
using SystemZapisowy.ViewModels.User.Employee;
using SystemZapisowy.ViewModels.User.Student;

namespace SystemZapisowy.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Models to ViewModels
            Mapper.CreateMap<Course, CourseViewModel>();
            Mapper.CreateMap<Group, GroupFormViewModel>();


            // ViewModels to Models
            Mapper.CreateMap<CourseViewModel, Course>();
            Mapper.CreateMap<GroupFormViewModel, Group>();
            Mapper.CreateMap<RegisterStudentViewModel, User>();
            Mapper.CreateMap<RegisterStudentViewModel, Student>();
            Mapper.CreateMap<RegisterEmployeeViewModel, User>();
            Mapper.CreateMap<RegisterEmployeeViewModel, Employee>();
            Mapper.CreateMap<RegisterAdministratorViewModel, User>();
            Mapper.CreateMap<RegisterAdministratorViewModel, Employee>();
            Mapper.CreateMap<RegisterAdministratorViewModel, Administrator>();
        }
    }
}