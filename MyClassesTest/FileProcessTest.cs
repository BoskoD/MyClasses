using MyClasses;

namespace MyClassesTest
{
    [TestClass]
    public class FileProcessTest
    {
        public TestContext? TestContext { get; set; }

        [TestMethod]
        public void FileNameDoesExist()
        {
            // Arrange
            FileProcess fp = new();
            string fileName = TestContext?.Properties?["GoodFileName"]?.ToString() ?? TestConstants.GOOD_FILE_NAME;
            bool fromCall;
            string outputMessage;

            // Try to get value from runsettings if not there take it from constants
            outputMessage = $"Checking for file {TestContext?.Properties?["GoodFileName"]?.ToString() ?? TestConstants.GOOD_FILE_NAME}";
            TestContext?.WriteLine(outputMessage);

            // Act 
            fromCall = FileProcess.FileExists(fileName);

            // Assert
            Assert.IsTrue(fromCall);
        }

        [TestMethod]
        public void FileNameDoesNotExist()
        {
            // Arrange
            FileProcess fp = new();
            string fileName = TestContext?.Properties?["BadFileName"]?.ToString() ?? TestConstants.BAD_FILE_NAME;
            bool fromCall;
            string outputMessage;

            outputMessage = $"Checking for file {TestContext?.Properties?["BadFileName"]?.ToString() ?? TestConstants.BAD_FILE_NAME}";
            TestContext?.WriteLine(outputMessage);

            // Act
            fromCall = FileProcess.FileExists(fileName);

            // Assert
            Assert.IsFalse(fromCall);
        }

        [TestMethod]
        public void FileNameNullOrEmpty_UsingTryCatch_ShouldThrowArgumentNullException()
        {
            // Arrange
            FileProcess fp;
            string fileName = string.Empty;
            bool fromCall = false;
            string outputMessage;
            string emptyFileFailureMessage;

            outputMessage = TestContext?.Properties?["EmptyFileMessage"]?.ToString() ?? TestConstants.EMPTY_FILE_MESSAGE;
            TestContext?.WriteLine(outputMessage);

            try
            {
                // Act
                fp = new();

                fromCall = FileProcess.FileExists(fileName);

                // Assert: Fail as we should not get here
                emptyFileFailureMessage = TestContext?.Properties?["EmptyFileMessage"]?.ToString() ?? TestConstants.EMPTY_FILE_FAIL_MESSAGE;
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
        public void FileNameNullOrEmpty_UsingExpectedExceptionAttribute()
        {
            // Arrange
            FileProcess fp = new();
            string fileName = string.Empty;
            string outputMessage;
            outputMessage = TestContext?.Properties?["EmptyFileFailMessage"]?.ToString() ?? TestConstants.EMPTY_FILE_MESSAGE;
            TestContext?.WriteLine(outputMessage);

            // Act
            _ = FileProcess.FileExists(fileName);

            // Assert
            Assert.Fail(outputMessage);
        }
    }
}