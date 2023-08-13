namespace MyClassesTest
{
    [TestClass]
    public  class AssertEqualityTest
    {
        [TestMethod]
        public void AreNumbersEqualTest()
        {
            int value1 = 27;
            int value2 = 27;

            Assert.AreEqual(value1, value2);
        }

        [TestMethod]
        public void AreNumbersNotEqualTest()
        {
            object value1 = 27;
            object value2 = 27L;

            Assert.AreNotEqual(value1, value2);
        }

        [TestMethod]
        public void AreStringsEqualTest()
        {
            string value1 = "Bosko";
            string value2 = "Bosko";

            Assert.AreEqual(value1, value2);
        }

        [TestMethod]
        public void AreStringsEqualCaseInsensitiveTest()
        {
            string value1 = "Bosko";
            string value2 = "bosko";

            Assert.AreEqual(value1, value2, true);
        }

        [TestMethod]
        public void AreStringsNotEqualTest()
        {
            string value1 = "Bosko";
            string value2 = "Milica";

            Assert.AreNotEqual(value1, value2, true);
        }

    }
}
