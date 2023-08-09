namespace MyClassesTest
{
    internal class TestConstants
    {
        public const string GOOD_FILE_NAME = @"[AppDataPath]\TestFile.txt";
        public const string BAD_FILE_NAME = @"C:\NotExist.txt";
        public const string EMPTY_FILE_FAIL_MESSAGE = "The call to FileExists() did NOT throw ArgumentNullException as it should";
        public const string EMPTY_FILE_MESSAGE = "Checking for an empty file name";
    }
}
