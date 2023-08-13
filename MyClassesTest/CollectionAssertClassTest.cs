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
    }
}
