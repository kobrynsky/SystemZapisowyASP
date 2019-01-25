using AutoMapper;
using SystemZapisowy.Models;
using SystemZapisowy.ViewModels.Course;
using SystemZapisowy.ViewModels.Day;
using SystemZapisowy.ViewModels.FieldOfStudy;
using SystemZapisowy.ViewModels.Group;
using SystemZapisowy.ViewModels.Semester;
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
            Mapper.CreateMap<Course, CourseOverviewViewModel>();

            Mapper.CreateMap<Group, GroupFormViewModel>();
            Mapper.CreateMap<Group, GroupViewModel>();

            Mapper.CreateMap<Day, DayViewModel>();

            Mapper.CreateMap<FieldsOfStudy, FieldsOfStudyViewModel>();

            Mapper.CreateMap<Semester, SemesterViewModel>();

            Mapper.CreateMap<Student, StudentViewModel>();
            
            Mapper.CreateMap<User, StudentViewModel>().ForMember(x => x.UserId, opt => opt.Ignore());

            // ViewModels to Models
            Mapper.CreateMap<CourseViewModel, Course>();
            Mapper.CreateMap<CourseOverviewViewModel, Course>();

            Mapper.CreateMap<GroupFormViewModel, Group>();
            Mapper.CreateMap<Group, GroupViewModel>();

            Mapper.CreateMap<DayViewModel, Day>();

            Mapper.CreateMap<FieldsOfStudyViewModel, FieldsOfStudy>();

            Mapper.CreateMap<SemesterViewModel, Semester>();

            Mapper.CreateMap<StudentViewModel, Student>();

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