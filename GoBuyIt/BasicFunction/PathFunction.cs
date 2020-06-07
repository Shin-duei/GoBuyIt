using System.IO;

namespace GoBuyIt.BasicFunction
{
    /// <summary>
    /// 路徑工具
    /// </summary>
    public class PathFunction
    {
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