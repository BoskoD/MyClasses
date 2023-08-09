using MyClasses;

namespace MyClassesTest
{
    [TestClass]
    public class FileProcessTest : TestBase
    {
        [TestMethod]
        public void FileNameDoesExist()
        {
            // Arrange
            bool fromCall;

            string fileName = TestContext?.Properties?["GoodFileName"]?.ToString() ?? TestConstants.GOOD_FILE_NAME;
            fileName = fileName.Replace("[AppDataPath]",
                Environment.GetFolderPath(
                    Environment.SpecialFolder.ApplicationData));

            TestContext?.Write($"Checking for file: {fileName}");

            // Create good file
            File.AppendAllText(fileName, "Some Text");

            // Act 
            fromCall = FileProcess.FileExists(fileName);

            // Delete the good file if it exists
            if (File.Exists(fileName)) { File.Delete(fileName); }

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