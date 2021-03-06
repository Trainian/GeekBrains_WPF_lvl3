using EmailSendServiceDLL;
// <copyright file="EmailSendServiceFactory.cs">Copyright ©  2018</copyright>

using System;
using Microsoft.Pex.Framework;

namespace EmailSendServiceDLL
{
    /// <summary>A factory for EmailSendServiceDLL.EmailSendService instances</summary>
    public static partial class EmailSendServiceFactory
    {
        /// <summary>A factory for EmailSendServiceDLL.EmailSendService instances</summary>
        [PexFactoryMethod(typeof(EmailSendService))]
        public static EmailSendService Create(
            string login_s,
            string pass_s1,
            int smtpPort_i,
            string smtpServer_s2
        )
        {
            EmailSendService emailSendService
               = new EmailSendService(login_s, pass_s1, smtpPort_i, smtpServer_s2);
            return emailSendService;

            // TODO: Edit factory method of EmailSendService
            // This method should be able to configure the object in all possible ways.
            // Add as many parameters as needed,
            // and assign their values to each field by using the API.
        }
    }
}
