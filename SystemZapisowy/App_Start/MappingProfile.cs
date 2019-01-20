using AutoMapper;
using SystemZapisowy.Models;
using SystemZapisowy.ViewModels.Course;
using SystemZapisowy.ViewModels.Group;

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
        }
    }
}