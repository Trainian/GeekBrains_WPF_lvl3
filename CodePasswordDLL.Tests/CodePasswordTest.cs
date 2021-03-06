// <copyright file="CodePasswordTest.cs">Copyright ©  2018</copyright>
using System;
using CodePasswordDLL;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodePasswordDLL.Tests
{
    /// <summary>Этот класс содержит параметризованные модульные тесты для CodePassword</summary>
    [PexClass(typeof(CodePassword))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class CodePasswordTest
    {
        /// <summary>Тестовая заглушка для getCodPassword(String)</summary>
        [PexMethod]
        [PexAllowedException(typeof(NullReferenceException))]
        public string getCodPasswordTest(string p_sPassword)
        {
            string result = CodePassword.getCodPassword(p_sPassword);
            return result;
            // TODO: добавление проверочных утверждений в метод CodePasswordTest.getCodPasswordTest(String)
        }

        /// <summary>Тестовая заглушка для getPassword(String)</summary>
        [PexMethod(MaxRunsWithoutNewTests = 200)]
        [PexAllowedException(typeof(NullReferenceException))]
        public string getPasswordTest(string p_sPassw)
        {
            string result = CodePassword.getPassword(p_sPassw);
            return result;
            // TODO: добавление проверочных утверждений в метод CodePasswordTest.getPasswordTest(String)
        }

        // My MS tests

        [TestMethod]
        public void getPasswordTest_bcd_abc()
        {
            //Arrange
            string strIn = "bcd";
            string strCheck = "abc";
            //Act
            string strGet = CodePassword.getPassword(strIn);
            //Assert
            Assert.AreEqual(strCheck,strGet);
        }

        [TestMethod]
        public void getCodPasswordTest_abc_bcd()
        {
            //Arrange
            string strIn = "abc";
            string strCheck = "bcd";
            //Act
            string strGet = CodePassword.getCodPassword(strIn);
            //Assert
            Assert.AreEqual(strCheck, strGet);
        }
    }
}
