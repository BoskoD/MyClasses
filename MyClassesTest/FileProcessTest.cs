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
            string fileName = TestConstants.GOOD_FILE_NAME;
            bool fromCall;

            TestContext?.WriteLine($"Checking for file {TestConstants.GOOD_FILE_NAME}");

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
            string fileName = TestConstants.BAD_FILE_NAME;
            bool fromCall;

            TestContext?.WriteLine($"Checking for file {TestConstants.BAD_FILE_NAME}");

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

            TestContext?.WriteLine(TestConstants.EMPTY_FILE_MESSAGE);

            try
            {
                // Act
                fp = new();

                fromCall = FileProcess.FileExists(fileName);

                // Assert: Fail as we should not get here
                Assert.Fail(TestConstants.EMPTY_FILE_FAIL_MESSAGE);
                              
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
            TestContext?.WriteLine(TestConstants.EMPTY_FILE_MESSAGE);

            // Act
            _ = FileProcess.FileExists(fileName);

            // Assert
            Assert.Fail(TestConstants.EMPTY_FILE_MESSAGE);
        }
    }
}