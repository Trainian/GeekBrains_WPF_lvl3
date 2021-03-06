// <copyright file="EmailSendServiceTest.cs">Copyright ©  2018</copyright>

using System;
using EmailSendServiceDLL;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmailSendServiceDLL.Tests
{
    [TestClass]
    [PexClass(typeof(EmailSendService))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class EmailSendServiceTest
    {

        [PexMethod]
        public EmailSendService Constructor(
            string login,
            string pass,
            int smtpPort,
            string smtpServer
        )
        {
            EmailSendService target = new EmailSendService(login, pass, smtpPort, smtpServer);
            return target;
            // TODO: добавление проверочных утверждений в метод EmailSendServiceTest.Constructor(String, String, Int32, String)
        }

        [PexMethod(MaxConstraintSolverTime = 2, Timeout = 240)]
        public string Send(
            [PexAssumeUnderTest]EmailSendService target,
            string mail,
            string name
        )
        {
            string result = target.Send(mail, name);
            return result;
            // TODO: добавление проверочных утверждений в метод EmailSendServiceTest.Send(EmailSendService, String, String)
        }
    }
}
