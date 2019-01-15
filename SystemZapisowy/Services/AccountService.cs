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


        public UserSessionData GetUserSessionData(User user)
        {
            var userInDatabase =
                _unitOfWork.Users.Find(x => x.Email.Equals(user.Email) && x.Password.Equals(user.Password))
                    .FirstOrDefault();

            var data = new UserSessionData();

            if (userInDatabase != null)
            {
                var studentRole = _unitOfWork.Students.Find(x => x.UserId == userInDatabase.UserId)
                    .FirstOrDefault();
                if (studentRole != null)
                {
                    data.UserId = studentRole.UserId;
                    data.Email = userInDatabase.Email;
                    data.Type = "Student";
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
                            data.UserId = employeeRole.UserId;
                            data.Email = userInDatabase.Email;
                            data.Type = "Administrator";
                            return data;
                        }
                        else
                        {
                            data.UserId = employeeRole.UserId;
                            data.Email = userInDatabase.Email;
                            data.Type = "Employee";
                            return data;
                        }
                    }
                }
            }
            return null;
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