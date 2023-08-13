namespace MyClasses.PersonClasses
{
    public class PeopleManager
    {
        public Person? GetPerson(int id)
        {
            return null;
        }

        public List<Person> GetPeople() 
        {
            return new()
            {
                new() {FirstName="Bosko", LastName="Danilovic", Age=32 },
                new() {FirstName="John", LastName="Doe", Age=33 },
                new() {FirstName="Jane", LastName="Doe", Age=34 },
            };
        }

        public List<Person> GetSupervisors()
        {
            return new()
            {
                new Supervisor() {FirstName="Paul", LastName="Sheriff", Age=45},
                new Supervisor() {FirstName = "Michael", LastName = "Landin", Age = 50 }
            };
        }

        public List<Person> GetEmployees()
        {
            return new()
            {
                new Employee() {FirstName="Paul", LastName="Sheriff", Age=45},
                new Employee() {FirstName = "Michael", LastName = "Landin", Age = 50 },
                new Employee() {FirstName = "Will", LastName = "Born", Age = 44 },
                new Employee() {FirstName = "Bosko", LastName = "Danilovic", Age = 32 }
            };
        }

        public List<Person> GetSupervisorsAndEmployees() 
        {
            List<Person> people = new();

            people.AddRange(GetEmployees());
            people.AddRange(GetSupervisors());

            return people;
        }
    }
}
