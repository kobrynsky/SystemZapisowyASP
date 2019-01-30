using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using SystemZapisowy.Models;
using SystemZapisowy.Repository;
using SystemZapisowy.Repository.Interfaces;
using SystemZapisowy.Services.Interfaces;
using SystemZapisowy.ViewModels.Course;
using SystemZapisowy.ViewModels.Day;
using SystemZapisowy.ViewModels.Group;
using static System.Web.HttpContext;

namespace SystemZapisowy.Services
{
    public class GroupsService : IGroupsService
    {
        private readonly IUnitOfWork _unitOfWork;

        public GroupsService()
        {
            _unitOfWork = new UnitOfWork(new SystemZapisowyEntities());
        }

        public void Save(GroupFormViewModel group)
        {
            if (group.GroupId != 0)
            {
                var groupInDb = _unitOfWork.Groups.Get(group.GroupId);
                Mapper.Map(group, groupInDb);
            }
            else
                _unitOfWork.Groups.Add(Mapper.Map<GroupFormViewModel, Group>(group));

            _unitOfWork.Complete();
        }


        public IEnumerable<GroupViewModel> GetGroups()
        {
            if (Current.Session["Type"].Equals("Student"))
            {
                int userId = int.Parse((string)Current.Session["UserId"]);
                var studentInDb = _unitOfWork.Students.Find(s => s.UserId == userId).Single();
                var groups = _unitOfWork.Groups.GetGroupsOfAFieldOfStudy(studentInDb.FieldOfStudyId, studentInDb.SemesterId);

                return Mapper.Map<IEnumerable<Group>, IEnumerable<GroupViewModel>>(groups);
            }
            else
            {
                var groups = _unitOfWork.Groups.GetOrdered(g => g.Cours.FieldsOfStudy.FieldOfStudyName,
                    g => g.Cours.Semester.SemesterName);
                return Mapper.Map<IEnumerable<Group>, IEnumerable<GroupViewModel>>(groups);
            }
        }

        public GroupFormViewModel GetNewGroupFormViewModel()
        {
            var courses = _unitOfWork.Courses.GetAll();
            var days = _unitOfWork.Days.GetAll();
            var viewModel = new GroupFormViewModel
            {
                Courses = Mapper.Map<IEnumerable<Course>, IEnumerable<CourseViewModel>>(courses),
                Days = Mapper.Map<IEnumerable<Day>, IEnumerable<DayViewModel>>(days)
            };
            return viewModel;
        }

        public GroupFormViewModel GetEditGroupFormViewModel(int id)
        {
            var groupInDb = _unitOfWork.Groups.Get(id);

            if (groupInDb == null)
                return null;

            var courses = _unitOfWork.Courses.GetAll();
            var days = _unitOfWork.Days.GetAll();

            var viewModel = new GroupFormViewModel()
            {
                Courses = Mapper.Map<IEnumerable<Course>, IEnumerable<CourseViewModel>>(courses),
                Days = Mapper.Map<IEnumerable<Day>, IEnumerable<DayViewModel>>(days)
            };

            return Mapper.Map(groupInDb, viewModel);
        }

        public void Delete(int id)
        {
            var groupInDb = _unitOfWork.Groups.Get(id);
            if (groupInDb.OccupiedSeats != 0)
            {
                _unitOfWork.Logs.RemoveByGroupId(id);
                _unitOfWork.StudentsGroup.RemoveByGroupId(id);
            }

            _unitOfWork.Groups.Remove(groupInDb);
            _unitOfWork.Complete();
        }

        public void SignUp(int id)
        {
            int userId = int.Parse((string)Current.Session["UserId"]);

            var studentInDb = _unitOfWork.Students.Find(s => s.UserId == userId).Single();

            // todo refactor
            if (studentInDb.StudentsGroups.Any(g => g.GroupId == id && g.IndexNumber == studentInDb.IndexNumber))
            {
                var studentGroup =
                    _unitOfWork.StudentsGroup.Find(g => g.IndexNumber == studentInDb.IndexNumber && g.GroupId == id);
                _unitOfWork.StudentsGroup.RemoveRange(studentGroup);
                _unitOfWork.Groups.Get(id).OccupiedSeats--;
            }
            else
                _unitOfWork.StudentsGroup.SignUp(studentInDb.IndexNumber, id);

            _unitOfWork.Complete();
        }
    }
}