using System;
using FileData.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FileData.Test
{
    [TestClass]
    public class FileCheckerTest
    {
        private readonly string[] _validArgsForVersion = new[] {"-v", "c:/test.txt"};
        private readonly string[] _invalidArgsForVersion = new[] { "-vm", "c:/test.txt" };

        private readonly string[] _validArgsForSize = new[] { "-s", "c:/test.txt" };
        private readonly string[] _invalidArgsForSize = new[] { "-sm", "c:/test.txt" };

        [TestMethod]
        public void GetVersionWithValidArguments()
        {
            //Act
            var response = new FileCheckerImplementation(new FileChecker()).Check(_validArgsForVersion);

            //Assert
            Assert.AreEqual(response.GetType(), typeof(string));
        }

        [TestMethod]
        public void GetVersionWithInValidArguments()
        {
            try
            {
                //Act
                var response = new FileCheckerImplementation(new FileChecker()).Check(_invalidArgsForVersion);

                //Assert
                Assert.Fail();
            }
            catch (Exception exception)
            {
                //Assert
                Assert.AreEqual($"Provided arguments are not valid: {_invalidArgsForVersion[0]}", exception.Message);
            }
        }

        [TestMethod]
        public void GetSizeWithValidArguments()
        {
            //Act
            var response = new FileCheckerImplementation(new FileChecker()).Check(_validArgsForSize);

            //Assert
            Assert.AreEqual(response.GetType(), typeof(int));
        }

        [TestMethod]
        public void GetSizeWithInValidArguments()
        {
            try
            {
                //Act
                var response = new FileCheckerImplementation(new FileChecker()).Check(_invalidArgsForSize);

                //Assert
                Assert.Fail();
            }
            catch (Exception exception)
            {
                //Assert
                Assert.AreEqual($"Provided arguments are not valid: {_invalidArgsForSize[0]}", exception.Message);
            }
        }
    }
}
