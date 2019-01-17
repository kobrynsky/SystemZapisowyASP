using System;
using System.Linq;
using SystemZapisowy.Models;
using SystemZapisowy.Repository;
using SystemZapisowy.Repository.Interfaces;
using SystemZapisowy.Services.Interfaces;

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
    }
}