using System.Collections.Generic;
using System.Linq;

namespace AvoidCodeDuplication_Begin.Logic
{
    public class RegistrationBook
    {
        private int nextId;
        private List<Person> persons;

        public RegistrationBook()
        {
            persons = new List<Person>();
            nextId = 0;
        }

        public void RegisterPerson(string firstName, string lastName, Gender gender)
        {
            var person = new Person(nextId++, firstName, lastName, gender);
            persons.Add(person);
        }

        public int CountFemales()
        {
            return CountByGender(Gender.Female);
        }

        private int CountByGender(Gender gender)
        {
            return persons.Count(person => person.Gender == gender);
        }

        public int CountMales()
        {
            return CountByGender(Gender.Male);
        }
    }
}
