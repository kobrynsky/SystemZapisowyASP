using System.Data.Entity;

namespace SystemZapisowy.Models
{
    public partial class ModelDatabase : DbContext
    {
        public ModelDatabase()
            : base("name=ModelDatabase")
        {
        }

        public virtual DbSet<Administrators> Administrators { get; set; }
        public virtual DbSet<Courses> Courses { get; set; }
        public virtual DbSet<Days> Days { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<FieldsOfStudy> FieldsOfStudy { get; set; }
        public virtual DbSet<Groups> Groups { get; set; }
        public virtual DbSet<Semesters> Semesters { get; set; }
        public virtual DbSet<StudentEnrollmentLog> StudentEnrollmentLog { get; set; }
        public virtual DbSet<Students> Students { get; set; }
        public virtual DbSet<StudentsGroups> StudentsGroups { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<GroupsOfCoursesOverview> GroupsOfCoursesOverview { get; set; }
        public virtual DbSet<SemestersStudentsOverview> SemestersStudentsOverview { get; set; }
        public virtual DbSet<StudentsGroupsOverview> StudentsGroupsOverview { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Courses>()
                .HasMany(e => e.Groups)
                .WithRequired(e => e.Courses)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Days>()
                .HasMany(e => e.Groups)
                .WithRequired(e => e.Days)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employees>()
                .Property(e => e.Salary)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Employees>()
                .HasMany(e => e.Administrators)
                .WithRequired(e => e.Employees)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FieldsOfStudy>()
                .HasMany(e => e.Courses)
                .WithRequired(e => e.FieldsOfStudy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FieldsOfStudy>()
                .HasMany(e => e.Students)
                .WithRequired(e => e.FieldsOfStudy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Groups>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<Groups>()
                .Property(e => e.StartTime)
                .HasPrecision(4);

            modelBuilder.Entity<Groups>()
                .HasMany(e => e.StudentEnrollmentLog)
                .WithRequired(e => e.Groups)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Groups>()
                .HasMany(e => e.StudentsGroups)
                .WithRequired(e => e.Groups)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Semesters>()
                .HasMany(e => e.Courses)
                .WithRequired(e => e.Semesters)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Semesters>()
                .HasMany(e => e.Students)
                .WithRequired(e => e.Semesters)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<StudentEnrollmentLog>()
                .Property(e => e.IndexNumber)
                .HasPrecision(6, 0);

            modelBuilder.Entity<Students>()
                .Property(e => e.IndexNumber)
                .HasPrecision(6, 0);

            modelBuilder.Entity<Students>()
                .HasMany(e => e.StudentEnrollmentLog)
                .WithRequired(e => e.Students)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Students>()
                .HasMany(e => e.StudentsGroups)
                .WithRequired(e => e.Students)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<StudentsGroups>()
                .Property(e => e.IndexNumber)
                .HasPrecision(6, 0);

            modelBuilder.Entity<Users>()
                .Property(e => e.PESEL)
                .HasPrecision(11, 0);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Employees)
                .WithRequired(e => e.Users)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Students)
                .WithRequired(e => e.Users)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GroupsOfCoursesOverview>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<GroupsOfCoursesOverview>()
                .Property(e => e.StartTime)
                .HasPrecision(4);

            modelBuilder.Entity<SemestersStudentsOverview>()
                .Property(e => e.IndexNumber)
                .HasPrecision(6, 0);

            modelBuilder.Entity<SemestersStudentsOverview>()
                .Property(e => e.PESEL)
                .HasPrecision(11, 0);

            modelBuilder.Entity<StudentsGroupsOverview>()
                .Property(e => e.IndexNumber)
                .HasPrecision(6, 0);

            modelBuilder.Entity<StudentsGroupsOverview>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<StudentsGroupsOverview>()
                .Property(e => e.StartTime)
                .HasPrecision(4);
        }
    }
}
