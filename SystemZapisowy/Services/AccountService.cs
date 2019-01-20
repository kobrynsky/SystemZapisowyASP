using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using SystemZapisowy.Models;
using SystemZapisowy.Repository;
using SystemZapisowy.Repository.Interfaces;
using SystemZapisowy.Services.Interfaces;
using SystemZapisowy.ViewModels;
using SystemZapisowy.ViewModels.User.Student;

namespace SystemZapisowy.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AccountService()
        {
            _unitOfWork = new UnitOfWork(new SystemZapisowyEntities());
        }


        public ValueTuple<string, string, string> GetUserSessionData(User user)
        {
            var userInDatabase =
                _unitOfWork.Users.Find(x => x.Email.Equals(user.Email) && x.Password.Equals(user.Password))
                    .FirstOrDefault();

            if (userInDatabase != null)
            {
                var studentRole = _unitOfWork.Students.Find(x => x.UserId == userInDatabase.UserId)
                    .FirstOrDefault();
                if (studentRole != null)
                {
                    var data = (studentRole.UserId.ToString(), userInDatabase.Email, "Student");
                    return data;
                }
                else
                {
                    var employeeRole = _unitOfWork.Employees.Find(x => x.UserId == userInDatabase.UserId)
                        .FirstOrDefault();

                    if (employeeRole != null)
                    {
                        var administratorRole = _unitOfWork.Administrators
                            .Find(x => x.EmployeeId == userInDatabase.UserId)
                            .FirstOrDefault();
                        if (administratorRole != null)
                        {
                            var data = (employeeRole.UserId.ToString(), userInDatabase.Email, "Administrator");
                            return data;
                        }
                        else
                        {
                            var data = (employeeRole.UserId.ToString(), userInDatabase.Email, "Employee");

                            return data;
                        }
                    }
                }
            }
            return ("", "", "");
        }

        public bool UserExistsInDatabase(User user)
        {
            var userInDatabase =
                _unitOfWork.Users.Find(x => x.Email.Equals(user.Email) && x.Password.Equals(user.Password))
                    .FirstOrDefault();

            if (userInDatabase == null)
                return false;
            return true;
        }

        public RegisterStudentViewModel GetRegisterStudentViewModelWithBasicData()
        {
            var semesters = _unitOfWork.Semesters.GetAll();
            var fieldsOfStudy = _unitOfWork.FieldsOfStudy.GetAll();

            var semestersSelectList = semesters.Select(semester => new SelectListItem()
            {
                Value = semester.SemesterId.ToString(),
                Text = semester.Name
            }).ToList();

            var fieldsOfStudySelectList = fieldsOfStudy.Select(fieldOfStudy => new SelectListItem()
            {
                Value = fieldOfStudy.FieldOfStudyId.ToString(),
                Text = fieldOfStudy.Name,
            }).ToList();

            var model = new RegisterStudentViewModel()
            {
                FieldsOfStudy = fieldsOfStudySelectList,
                Semesters = semestersSelectList,
            };

            return model;
        }

        public string SaveStudent(RegisterStudentViewModel viewModel)
        {



            return "XD";
        }

        //protected override void Dispose(bool disposing)
        //{
        //    _unitOfWork.Dispose();
        //    base.Dispose(disposing);
        //}

    }
}