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

            string fileName = GetTestSetting<string>("GoodFileName", TestConstants.GOOD_FILE_NAME);
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
            bool fromCall;
            string fileName = GetTestSetting<string>("BadFileName", TestConstants.BAD_FILE_NAME);

            string outputMessage;
            outputMessage = $"Checking for file {GetTestSetting<string>("BadFileName", TestConstants.BAD_FILE_NAME)}";
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
            bool fromCall = false;
            string fileName = string.Empty;
            string outputMessage;
            string emptyFileFailureMessage;

            outputMessage = GetTestSetting<string>("EmptyFileMessage", TestConstants.EMPTY_FILE_MESSAGE);
            TestContext?.WriteLine(outputMessage);

            try
            {
                // Act
                fromCall = FileProcess.FileExists(fileName);

                // Assert: Fail as we should not get here
                emptyFileFailureMessage = GetTestSetting<string>("EmptyFileFailMessage", TestConstants.EMPTY_FILE_FAIL_MESSAGE);
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
            string fileName = string.Empty;
            string outputMessage;
            outputMessage = GetTestSetting<string>("EmptyFileMessage", TestConstants.EMPTY_FILE_MESSAGE);
            TestContext?.WriteLine(outputMessage);

            // Act
            _ = FileProcess.FileExists(fileName);

            // Assert
            Assert.Fail(outputMessage);
        }
    }
}