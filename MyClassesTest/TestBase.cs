﻿namespace MyClassesTest
{
    public class TestBase
    {
        public TestContext? TestContext { get; set; }
        public string OutputMessage { get; set; } = string.Empty;

        protected T GetTestSetting<T>(string name, T defaultValue)
        {
            T ret = defaultValue;

            try
            {
                var tmp = TestContext?.Properties[name];
                if (tmp != null) {
                    ret = (T)(Convert.ChangeType(tmp, typeof(T)));
                }
            }
            catch 
            {
                // Ignore
            }
            return ret;
        }

        protected string GetTestName()
        {
            return TestContext?.TestName ?? string.Empty;
        }

        protected string GetFileName(string name, string defaultValue)
        { 
            string fileName = GetTestSetting<string>(name, defaultValue);
            fileName = fileName.Replace("[AppDataPath]",
                Environment.GetFolderPath(
                    Environment.SpecialFolder.ApplicationData));
            return fileName;
        }
    }
}