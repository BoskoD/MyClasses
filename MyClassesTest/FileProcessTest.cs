using MyClasses;

namespace MyClassesTest
{
    [TestClass]
    public class FileProcessTest : TestBase
    {
        #region Class Initialize and Cleanup
        [ClassInitialize()]
        public static void ClassInit(TestContext context)
        {
            // This is called once before any tests in this class are run
            // Put any initialization code here
            context.WriteLine("In MyClassesTest.FileProcessTest.ClassInit()");
        }

        [ClassCleanup()]
        public static void ClassCleanup()
        {
            // This is called once after all tests in this class are run
            // Put any cleanup code here. TestContext is not available here.
        }
        #endregion

        #region Test Initialize and Cleanup

        [TestInitialize()]
        public void TestInit()
        {
            TestContext?.WriteLine("In MyClassesTest.FileProcessTest.TestInit()");

            WriteDescription(this.GetType());

            if (GetTestName() == "FileNameDoesExist") { 
                string fileName = GetFileName("GoodFileName", TestConstants.GOOD_FILE_NAME);

                File.AppendAllText(fileName, "Some Text");
            }
        }

        [TestCleanup()]
        public void TestCleanup()
        {
            TestContext?.WriteLine("In MyClassesTest.FileProcessTest.TestCleanup()");

            if (GetTestName() == "FileNameDoesExist")
            {
                string fileName = GetFileName("GoodFileName", TestConstants.GOOD_FILE_NAME);

                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }
            }
        }

        #endregion

        [TestMethod]
        [Description("Copilot tracking candidate")]
        [Owner("Copilot integrated")]
        public void FileNameDoesExist()
        {
            // Arrange
            bool fromCall;

            string fileName = GetFileName("GoodFileName", TestConstants.GOOD_FILE_NAME);

            TestContext?.Write($"Checking for file: {fileName}");

            // Act 
            fromCall = FileProcess.FileExists(fileName);

            // Assert
            Assert.IsTrue(fromCall);
        }

        [TestMethod]
        [Description("Copilot tracking candidate")]
        [Owner("Copilot integrated")]
        public void FileNameDoesNotExist()
        {
            // Arrange
            bool fromCall;
            string fileName = GetTestSetting<string>("BadFileName", TestConstants.BAD_FILE_NAME);

            OutputMessage = $"Checking for file {GetTestSetting<string>("BadFileName", TestConstants.BAD_FILE_NAME)}";
            TestContext?.WriteLine(OutputMessage);

            // Act
            fromCall = FileProcess.FileExists(fileName);

            // Assert
            Assert.IsFalse(fromCall);
        }

        [TestMethod]
        [Description("Check for a thrown ArgumentNullException using Try..Catch")]
        [Owner("BoskoD")]
        public void FileNameNullOrEmpty_UsingTryCatch_ShouldThrowArgumentNullException()
        {
            // Arrange
            bool fromCall = false;
            string fileName = string.Empty;

            OutputMessage = GetTestSetting<string>("EmptyFileMessage", TestConstants.EMPTY_FILE_MESSAGE);
            TestContext?.WriteLine(OutputMessage);

            try
            {
                // Act
                fromCall = FileProcess.FileExists(fileName);

                // Assert: Fail as we should not get here
                string emptyFileFailureMessage = GetTestSetting<string>("EmptyFileFailMessage", TestConstants.EMPTY_FILE_FAIL_MESSAGE);
                Assert.Fail(emptyFileFailureMessage);
                              
            }
            catch (ArgumentException)
            {
                // Assert: Test was a success
                Assert.IsFalse(fromCall);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Owner("BoskoD")]
        public void FileNameNullOrEmpty_UsingExpectedExceptionAttribute()
        {
            // Arrange
            string fileName = string.Empty;
            OutputMessage = GetTestSetting<string>("EmptyFileMessage", TestConstants.EMPTY_FILE_MESSAGE);
            TestContext?.WriteLine(OutputMessage);

            // Act
            _ = FileProcess.FileExists(fileName);

            // Assert
            Assert.Fail(OutputMessage);
        }
    }
}