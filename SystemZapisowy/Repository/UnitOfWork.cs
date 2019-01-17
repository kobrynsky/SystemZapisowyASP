using SystemZapisowy.Models;
using SystemZapisowy.Repository.Interfaces;

namespace SystemZapisowy.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SystemZapisowyEntities _context;

        public UnitOfWork(SystemZapisowyEntities context)
        {
            _context = context;
            Courses = new CourseRepository(_context);
            Users = new UserRepository(_context);
            Administrators = new AdministratorRepository(_context);
            Employees = new EmployeeRepository(_context);
            Students = new StudentRepository(_context);
            Days = new DayRepository(_context);
            StudentsGroup = new StudentsGroupRepository(_context);
            FieldsOfStudyRepository = new FieldsOfStudyRepository(_context);
            Groups = new GroupRepository(_context);   
            Semesters = new SemesterRepository(_context);
            Logs = new StudentEnrollmentLogRepository(_context);
        }

        public ICourseRepository Courses { get; private set; }
        public IDayRepository Days { get; }
        public IStudentsGroupRepository StudentsGroup { get; }
        public IUserRepository Users { get; }
        public IAdministratorRepository Administrators { get; }
        public IEmployeeRepository Employees { get; }
        public IFieldsOfStudyRepository FieldsOfStudyRepository { get; }
        public IGroupRepository Groups { get; }
        public ISemesterRepository Semesters { get; }
        public IStudentEnrollmentLogRepository Logs { get; }
        public IStudentRepository Students { get; }

        public int Complete()
        {
            return _context.SaveChanges();
        }


        public void Dispose()
        {
            _context.Dispose();
        }
    }
}