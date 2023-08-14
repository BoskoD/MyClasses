using MyClasses.PersonClasses;

namespace MyClassesTest
{
    [TestClass]
    public class CollectionAssertClassTest
    {
        [TestMethod]
        public void AreCollectionsEqualTestNumbers()
        {
            List<int> expected = new() { 1, 2, 3, 4, 5 };
            List<int> actual = new() { 1, 2, 3, 4, 5 };

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AreCollectionsEqualTest()
        {
            PeopleManager pManager = new();
            List<Person> expected;
            List<Person> actual;

            actual = pManager.GetPeople();
            expected = actual;

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AreCollectionsNotEqualTest()
        {
            PeopleManager pManager = new();
            List<Person> expected;
            List<Person> actual;

            // not all ppl are employees
            actual = pManager.GetPeople(); 
            expected = pManager.GetEmployees();

            CollectionAssert.AreNotEqual(expected, actual);
        }

        [TestMethod]
        public void AreNumbersEquivalent()
        {
            List<int> expected = new() { 1, 2, 3, 4, 5 };
            List<int> actual = new() { 5, 4, 3, 2, 1 };

            // Checks for same values but in any order
            CollectionAssert.AreEquivalent(expected, actual);
        }

        [TestMethod]
        public void AreCollectionsEquivalentTest()
        {
            PeopleManager pManager = new();
            List<Person> expected = new();
            List<Person> actual;

            actual = pManager.GetPeople();

            expected.Add(actual[1]);
            expected.Add(actual[2]);
            expected.Add(actual[0]);

            CollectionAssert.AreEquivalent(expected, actual);
        }

        [TestMethod]
        public void AreCollectionsEqualWithComparerTest()
        {
            PeopleManager pManager = new();
            List<Person> expected = new();
            List<Person> actual;

            actual = pManager.GetPeople();

            expected.Add(new() { FirstName = "Bosko", LastName = "Danilovic", Age = 32 });
            expected.Add(new() { FirstName = "John", LastName = "Doe", Age = 33 });
            expected.Add(new() { FirstName = "Jane", LastName = "Doe", Age = 34 });

            CollectionAssert.AreEqual(expected, actual, 
                Comparer<Person>.Create((x, y) => 
                x.FirstName == y.FirstName 
                && x.LastName == y.LastName &&
                x.Age == y.Age ? 0 : 1));
        }

        [TestMethod]
        public void IsCollectionOfTypeTest()
        {
            PeopleManager pManager = new();
            List<Person> actual;

            actual = pManager.GetSupervisors();

            CollectionAssert.AllItemsAreInstancesOfType(actual, typeof(Supervisor));
        }
    }
}
