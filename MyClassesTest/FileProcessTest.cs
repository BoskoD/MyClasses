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
            WriteOwner(this.GetType());

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
        [Ignore]
        [Timeout(3000)]
        public void SimulateTimeout()
        {
            System.Threading.Thread.Sleep(4000);
        }

        [TestMethod]
        [DeploymentItem("FileDynamic.txt")]
        [DeploymentItem("FileDynamic2.txt")]
        [DynamicData("FileNames", typeof(TestData), DynamicDataSourceType.Method)]
        [Description("Check to see if a file exists using [DynamicData] attribute")]
        [Owner("Copilot integrated")]
        [Priority(1)]
        [TestCategory("NoException")]
        public void FileNameDoesExistUsingDynamicData(string fileName)
        {
            // Arrange
            bool fromCall;

            TestContext?.Write($"Checking for the file: {fileName} " +
                $"in folder '{TestContext?.DeploymentDirectory}'");

            // Act 
            fromCall = FileProcess.FileExists(fileName);

            // Assert
            Assert.IsTrue(fromCall);
        }

        [TestMethod]
        [DeploymentItem("FileDataRow.txt")]
        [DeploymentItem("FileDataRow2.txt")]
        [DataRow("FileDataRow.txt")]
        [DataRow("FileDataRow2.txt")]
        [Description("Check to see if a file exists using [DataRow] attribute")]
        [Owner("Copilot integrated")]
        [Priority(1)]
        [TestCategory("NoException")]
        public void FileNameDoesExistUsingDataRow(string fileName)
        {
            // Arrange
            bool fromCall;

            TestContext?.Write($"Checking for the file: {fileName} " +
                $"in folder '{TestContext?.DeploymentDirectory}'");

            // Act 
            fromCall = FileProcess.FileExists(fileName);

            // Assert
            Assert.IsTrue(fromCall);
        }

        [TestMethod]
        [DeploymentItem("FileToDeploy.txt")]
        [Description("Check to see if a file exists using [DeploymentItem] attribute")]
        [Owner("Copilot integrated")]
        [Priority(1)]
        [TestCategory("NoException")]
        public void FileNameDoesNotExistUsingDeploymentItem()
        {
            // Arrange
            bool fromCall;

            string fileName = "FileToDeploy.txt";

            TestContext?.Write($"Checking for the file: {fileName} " +
                $"in folder '{TestContext?.DeploymentDirectory}'");

            // Act 
            fromCall = FileProcess.FileExists(fileName);

            // Assert
            Assert.IsTrue(fromCall);
        }

        [TestMethod]
        [Description("Copilot tracking candidate")]
        [Owner("Copilot integrated")]
        [Priority(1)]
        [TestCategory("NoException")]
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
        [Priority(2)]
        [TestCategory("NoException")]
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
        [Priority(4)]
        [TestCategory("Exception")]
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
        [Priority(3)]
        [TestCategory("Exception")]
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