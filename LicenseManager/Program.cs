using System.IO;


namespace LicenseManager
{
    class Program
    {
        static void Main(string[] args)
        {
            var keyFilePath=Path.Combine(GetExecuteLevelPath(System.Environment.CurrentDirectory, 2), "KeyFile");
            //LicenseKit.GenerateKeys(keyFilePath);

            var TempfileNamePath= Path.Combine(keyFilePath, "_"+LicenseKit.LicenseFileName);
            var fileNamePath = Path.Combine(keyFilePath, LicenseKit.LicenseFileName);
            var publicKeyPath = Path.Combine(keyFilePath, LicenseKit.publicKeyFileName);
            var privateKeyPath = Path.Combine(keyFilePath, LicenseKit.privateKeyFileName);

            LicenseKit.Encrypt(fileNamePath, publicKeyPath);

            using (StreamWriter sw = new StreamWriter(TempfileNamePath))
            {
                // Add some text to the file.
                sw.Write(LicenseKit.Encrypt(keyFilePath));
            }
            File.Delete(fileNamePath);
            File.Move(TempfileNamePath, fileNamePath);

            //var text =File.ReadAllText(Path.Combine(keyFilePath, LicenseKit.LicenseFileName));

            //var DecryptJson = LicenseKit.Decrypt(keyFilePath);
        }

        /// <summary>
        /// 取得路徑往上幾層
        /// </summary>
        /// <param name="InPath"></param>
        /// <param name="upLevel"></param>
        /// <returns></returns>
        public static string GetExecuteLevelPath(string InPath, int upLevel)
        {
            var directory = File.GetAttributes(InPath).HasFlag(FileAttributes.Directory) ? InPath : Path.GetDirectoryName(InPath);

            upLevel = upLevel < 0 ? 0 : upLevel;

            for (var i = 0; i < upLevel; i++)
            {
                directory = Path.GetDirectoryName(directory);
            }
            return directory;
        }
    }
}
