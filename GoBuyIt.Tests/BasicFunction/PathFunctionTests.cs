using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace GoBuyIt.BasicFunction.Tests
{
    [TestClass()]
    public class PathFunctionTests
    {
        [TestMethod()]
        public void GetExecuteLevelPathTest()
        {
            var f=System.Environment.CurrentDirectory;
            string DummyFileRelativePath = @"BasicFunction\DummyFile\testPath.txt";
            var FilePath = Path.Combine(PathFunction.GetExecuteLevelPath(System.Environment.CurrentDirectory, 2), DummyFileRelativePath);

            Assert.IsTrue(File.Exists(FilePath));
        }
    }
}