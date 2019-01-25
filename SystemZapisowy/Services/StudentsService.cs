using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SystemZapisowy.Models;
using SystemZapisowy.Repository;
using SystemZapisowy.Repository.Interfaces;
using SystemZapisowy.Services.Interfaces;
using SystemZapisowy.ViewModels.FieldOfStudy;
using SystemZapisowy.ViewModels.Semester;
using SystemZapisowy.ViewModels.User.Student;
using AutoMapper;

namespace SystemZapisowy.Services
{
    public class StudentsService : IStudentsService
    {
        private readonly IUnitOfWork _unitOfWork;

        public StudentsService()
        {
            _unitOfWork = new UnitOfWork(new SystemZapisowyEntities());
        }

        public IEnumerable<StudentViewModel> GetStudentsWithPersonalInformation()
        {
            var studentsInDb = _unitOfWork.Students.GetAll();

            ICollection<StudentViewModel> viewModel = new List<StudentViewModel>();

            foreach (var s in studentsInDb)
            {
                // pobieramy usera o id przechowywanym przez studenta, by dalej przypisać jego pola
                var userInDb = _unitOfWork.Users.Get(s.UserId);
                viewModel.Add(new StudentViewModel
                {
                    UserId = s.UserId,
                    Semester = Mapper.Map<Semester, SemesterViewModel>(s.Semester),
                    IndexNumber = s.IndexNumber,
                    FieldsOfStudy = Mapper.Map<FieldsOfStudy, FieldsOfStudyViewModel>(s.FieldsOfStudy),
                    YearOfCollege = s.YearOfCollege,
                    SemesterId = s.SemesterId,
                    FieldOfStudyId = s.FieldOfStudyId,
                    PESEL = userInDb.PESEL,
                    BirthDate = userInDb.BirthDate,
                    LastName = userInDb.LastName,
                    FirstName = userInDb.FirstName,
                    Email = userInDb.Email,
                    Gender = userInDb.Gender,
                    Password = userInDb.Password,
                });
            }
            return viewModel.OrderBy(s => s.LastName);
        }
    }
}