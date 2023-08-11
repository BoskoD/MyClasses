using System.Collections.Generic;

namespace MyClassesTest
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

        protected T? GetAttribute<T>(Type type)
        {
            string testName = GetTestName();

            var assemblyElement = type?.GetMethod(testName);
            var attr = Attribute.GetCustomAttribute(assemblyElement, typeof(T));
            if (attr != null)
            {
                //Cast the attribute to a <TAttr> type
                return (T)Convert.ChangeType(attr, typeof(T));
            }
            else {
                return default;
            } 
        }

        protected void WriteDescription(Type type)
        { 
            DescriptionAttribute? attr = GetAttribute<DescriptionAttribute>(type);
            if (attr != null)
            {
                TestContext?.WriteLine($"Test purpose: {attr.Description}");
            }
        }
    }
}