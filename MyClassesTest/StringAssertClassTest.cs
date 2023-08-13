using System.Text.RegularExpressions;

namespace MyClassesTest
{
    [TestClass]
    public class StringAssertClassTest
    {
        [TestMethod]
        public void ContainsTest()
        {
            string value1 = "Steve Nystrom";
            string value2 = "Nystrom";

            StringAssert.Contains(value1, value2);
        }

        [TestMethod]
        public void StartsWithTest()
        {
            string value1 = "Bosko Danilovic";
            string value2 = "Bosko";

            StringAssert.StartsWith(value1, value2);
        }

        [TestMethod]
        public void EndsWithTest()
        {
            string value1 = "Bosko Danilovic";
            string value2 = "Danilovic";

            StringAssert.EndsWith(value1, value2);
        }

        [TestMethod]
        public void IsAllLowerCaseTest()
        {
            Regex r = new(@"^([^A-Z])+$");
            StringAssert.Matches("all lower case", r);
        }

        [TestMethod]
        public void IsNotAllLowerCaseTest()
        {
            Regex r = new(@"^([^A-Z])+$");
            StringAssert.DoesNotMatch("All Lower case", r);
        }
    }
}
