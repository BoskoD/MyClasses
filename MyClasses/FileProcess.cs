namespace MyClasses
{
    public class FileProcess
    {
        public static bool FileExists(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentNullException(fileName);
            }
            return File.Exists(fileName);
        }
    }
}