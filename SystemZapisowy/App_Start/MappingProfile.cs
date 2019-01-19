using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SystemZapisowy.Models;
using SystemZapisowy.ViewModels;
using SystemZapisowy.ViewModels.Course;
using AutoMapper;

namespace SystemZapisowy.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Course, CourseViewModel>();

            Mapper.CreateMap<CourseViewModel, Course>();
        }
    }
}