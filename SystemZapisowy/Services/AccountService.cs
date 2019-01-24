using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using SystemZapisowy.Models;
using SystemZapisowy.Repository;
using SystemZapisowy.Repository.Interfaces;
using SystemZapisowy.Services.Interfaces;
using SystemZapisowy.ViewModels;
using SystemZapisowy.ViewModels.FieldOfStudy;
using SystemZapisowy.ViewModels.Semester;
using SystemZapisowy.ViewModels.User.Administrator;
using SystemZapisowy.ViewModels.User.Employee;
using SystemZapisowy.ViewModels.User.Student;
using AutoMapper;

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
            var fieldsOfStudy = _unitOfWork.FieldsOfStudy.GetAll();
            var semesters = _unitOfWork.Semesters.GetAll();

            var model = new RegisterStudentViewModel()
            {
                FieldsOfStudy = Mapper.Map<IEnumerable<FieldsOfStudy>, IEnumerable<FieldsOfStudyViewModel>>(fieldsOfStudy),
                Semesters = Mapper.Map<IEnumerable<Semester>, IEnumerable<SemesterViewModel>>(semesters)
            };
            return model;
        }

        public void SaveStudent(RegisterStudentViewModel viewModel)
        {
            var user = Mapper.Map<RegisterStudentViewModel, User>(viewModel);
            _unitOfWork.Users.Add(user);
            _unitOfWork.Complete();

            viewModel.UserId = user.UserId;

            var student = Mapper.Map<RegisterStudentViewModel, Student>(viewModel);
            _unitOfWork.Students.Add(student);
            _unitOfWork.Complete();
        }

        public void SaveEmployee(RegisterEmployeeViewModel viewModel)
        {
            var user = Mapper.Map<RegisterEmployeeViewModel, User>(viewModel);
            _unitOfWork.Users.Add(user);
            _unitOfWork.Complete();

            viewModel.UserId = user.UserId;

            var employee = Mapper.Map<RegisterEmployeeViewModel, Employee>(viewModel);
            _unitOfWork.Employees.Add(employee);
            _unitOfWork.Complete();
        }

        public void SaveAdministrator(RegisterAdministratorViewModel viewModel)
        {
            var user = Mapper.Map<RegisterAdministratorViewModel, User>(viewModel);
            _unitOfWork.Users.Add(user);
            _unitOfWork.Complete();

            viewModel.UserId = user.UserId;

            var employee = Mapper.Map<RegisterAdministratorViewModel, Employee>(viewModel);
            _unitOfWork.Employees.Add(employee);
            _unitOfWork.Complete();

            viewModel.EmployeeId = employee.EmployeeId;

            var administrator = Mapper.Map<RegisterAdministratorViewModel, Administrator>(viewModel);
            _unitOfWork.Administrators.Add(administrator);
            _unitOfWork.Complete();
        }
    }
}