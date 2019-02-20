using System;
using FileData;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestFileData
{
    [TestClass]
    public class FileCheckerTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            IFileChecker filerChecker = new FileChecker();
            string[] args = new string[2];
            args[0] = "-v";
            args[1] = "c:/test.txt";

            var result = filerChecker.Run(args);

            //var isStringType = result.GetType() == StringAssert ? true : false;
            
        }
    }
}
