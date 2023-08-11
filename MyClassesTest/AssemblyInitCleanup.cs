namespace MyClassesTest
{
    [TestClass]
    public class AssemblyInitCleanup
    {
        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            // This is called once before any tests are run
            // Put any initialization code here
            context.WriteLine("In MyClassesTest.AssemblyInitCleanup.AssemblyInit()");
        }

        public static void AssemblyCleanup()
        {
            // This is called once after all tests are run
            // Put any cleanup code here
        }
    }
}
