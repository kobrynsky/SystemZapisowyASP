using AutoMapper;
using SystemZapisowy.Models;
using SystemZapisowy.ViewModels.Course;

namespace SystemZapisowy.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Models to ViewModels
            Mapper.CreateMap<Course, CourseViewModel>();


            // ViewModels to Models
            Mapper.CreateMap<CourseViewModel, Course>();
        }
    }
}