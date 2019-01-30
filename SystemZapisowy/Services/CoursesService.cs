using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using SystemZapisowy.Models;
using SystemZapisowy.Repository;
using SystemZapisowy.Repository.Interfaces;
using SystemZapisowy.Services.Interfaces;
using SystemZapisowy.ViewModels.Course;
using SystemZapisowy.ViewModels.FieldOfStudy;
using SystemZapisowy.ViewModels.Semester;
using static System.Web.HttpContext;


namespace SystemZapisowy.Services
{
    public class CoursesService : ICoursesService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGroupsService _groupsService;

        public CoursesService()
        {
            _unitOfWork = new UnitOfWork(new SystemZapisowyEntities());
            _groupsService = new GroupsService();
        }

        public IEnumerable<CourseOverviewViewModel> GetCoursesOverviewViewModel()
        {
            if (Current.Session["Type"] == ("Student"))
            {
                int userId = int.Parse((string)Current.Session["UserId"]);
                var studentInDb = _unitOfWork.Students.Find(s => s.UserId == userId).Single();
                var coursesOfAFieldOfStudy = _unitOfWork.Courses.GetCoursesOfAFieldOfStudy(studentInDb.FieldOfStudyId,
                    studentInDb.SemesterId);
                var model =
                    Mapper.Map<IEnumerable<Course>, IEnumerable<CourseOverviewViewModel>>(coursesOfAFieldOfStudy);
                return model;
            }
            else
            {
                var coursesOrdered = _unitOfWork.Courses.GetOrdered(c => c.Semester.SemesterName,
                    c => c.FieldsOfStudy.FieldOfStudyName);
                var model = Mapper.Map<IEnumerable<Course>, IEnumerable<CourseOverviewViewModel>>(coursesOrdered);

                return model;
            }
        }

        public CourseFormViewModel GetNewCourseFormViewModel()
        {
            var fieldsOfStudy = _unitOfWork.FieldsOfStudy.GetAll();
            var semesters = _unitOfWork.Semesters.GetAll();
            var viewModel = new CourseFormViewModel
            {
                FieldsOfStudy = Mapper.Map<IEnumerable<FieldsOfStudy>, IEnumerable<FieldsOfStudyViewModel>>(fieldsOfStudy),
                Semesters = Mapper.Map<IEnumerable<Semester>, IEnumerable<SemesterViewModel>>(semesters)
            };

            return viewModel;
        }

        public CourseFormViewModel GetEditCourseFormViewModel(int id)
        {
            var courseInDb = _unitOfWork.Courses.Get(id);

            if (courseInDb == null)
                return null;

            var fieldsOfStudy = _unitOfWork.FieldsOfStudy.GetAll();
            var semesters = _unitOfWork.Semesters.GetAll();

            var viewModel = new CourseFormViewModel
            {
                Course = Mapper.Map<Course, CourseViewModel>(courseInDb),
                FieldsOfStudy = Mapper.Map<IEnumerable<FieldsOfStudy>, IEnumerable<FieldsOfStudyViewModel>>(fieldsOfStudy),
                Semesters = Mapper.Map<IEnumerable<Semester>, IEnumerable<SemesterViewModel>>(semesters)
            };
            return viewModel;
        }

        public void DeleteCourse(int id)
        {
            // Czy jest sens drugi raz sprawdzać czy ten kurs ma jakieś grupy? Widok by nas nie puścił.
            var courseInDb = _unitOfWork.Courses.Get(id);

            foreach (var group in courseInDb.Groups)
            {
                _groupsService.Delete(group.GroupId);
            }

            _unitOfWork.Courses.Remove(courseInDb);
            _unitOfWork.Complete();
        }

        public void SaveCourse(CourseViewModel course)
        {
            if (course.CourseId != 0)
            {
                var courseInDb = _unitOfWork.Courses.Get(course.CourseId);
                Mapper.Map(course, courseInDb);
            }
            else
                _unitOfWork.Courses.Add(Mapper.Map<CourseViewModel, Course>(course));

            _unitOfWork.Complete();
        }
    }
}
