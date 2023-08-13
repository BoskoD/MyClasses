using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses.PersonClasses;

namespace MyClassesTest
{
    [TestClass]
    public class ObjectTypeTest
    {
        [TestMethod]
        public void AreNotSameTest()
        {
            Person x = new();
            Person y = new();

            Assert.AreNotSame(x, y);
        }

        [TestMethod]
        public void AreSameTest()
        {
            Person x = new();
            Person y = x;

            Assert.AreSame(x, y);
        }

        [TestMethod]
        public void IsInstanceOfTypeTest()
        {
            Person per = new()
            {
                FirstName = "John",
                LastName = "Doe",
            };

            Employee emp = new()
            {
                FirstName = "Bosko",
                LastName = "Danilovic",
            };

            // per is a Person
            Assert.IsInstanceOfType(per, typeof(Person));

            // per is not an employee
            Assert.IsNotInstanceOfType(per, typeof(Employee));

            //emp is a Person
            Assert.IsInstanceOfType(emp, typeof(Person));

            // emp is an Employee
            Assert.IsInstanceOfType(emp, typeof(Employee));

            // emp is not a Supervisor
            Assert.IsNotInstanceOfType(emp, typeof(Supervisor));
        }

        [TestMethod]
        public void IsNullTest()
        {
            PeopleManager pManager = new();
            Person? per;

            per = pManager.GetPerson(1); 

            Assert.IsNull(per);

            per = new()
            {
                FirstName = "Bosko",
                LastName = "Danilovic"
            };

            Assert.IsNotNull(per);
        }
    }
}
