using System.Data.Entity;
using System.Linq;
using SystemZapisowy.Models;
using SystemZapisowy.Repository.Interfaces;

namespace SystemZapisowy.Repository
{
    public class StudentsGroupRepository : Repository<StudentsGroup>, IStudentsGroupRepository
    {
        public StudentsGroupRepository(DbContext context) : base(context)
        {
        }

        public SystemZapisowyEntities SystemZapisowyEntities
        {
            get { return Context as SystemZapisowyEntities; }
        }

        public void SignUp(decimal indexNumber, int groupId)
        {
            // Sam się dziwię, że to działa, najprawdopodobniej potrzeba refactoringu

            //pobieramy grupę o przekazanym w parametrze ID
            var groupInDb = Context.Set<Group>().Single(g => g.GroupId == groupId);

            // pobieramy wszystkie grupy danego kursu o tym samym typie (nie można zapisać się na np 2x laborki z jednego kursu)
            var groupWithinCourses = Context.Set<Group>().Where(g => g.CourseId == groupInDb.CourseId && g.Type == groupInDb.Type);

            // pobieramy wszystkie studentsGroups dla studenta o podanym indeksie
            var studentsGroups = Context.Set<StudentsGroup>().Where(s => s.IndexNumber == indexNumber).ToList();

            // sprawdzamy czy jest już taki zapis w tabeli StudentsGroups, że student jest zapisany na np. laborki z grafiki (jakiekolwiek)
            foreach (var g in groupWithinCourses)
                if (studentsGroups.Exists(s => s.GroupId == g.GroupId)) return; // jeśli tak, to returnujemy (tu na pewno powinno coś się dziać, może zwrócić boola?)

            // dodajemy rekord i zwiększamy occupied seats 
            Context.Set<StudentsGroup>().Add(new StudentsGroup()
            {
                GroupId = groupId,
                IndexNumber = indexNumber
            });

            Context.Set<Group>().Find(groupId).OccupiedSeats++; // to pewnie też należy inaczej zapisać
        }
    }
}