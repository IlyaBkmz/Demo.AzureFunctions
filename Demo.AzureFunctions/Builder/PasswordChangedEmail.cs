// <copyright file="PasswordChangedEmail.cs" company="Demo">
// Copyright (c) Demo. All rights reserved.
// </copyright>

namespace Demo.GenericFunctions.Builder
{
    using System.Collections.Generic;
    using Demo.GenericFunctions.Configuration;
    using Demo.GenericFunctions.Helpers;
    using Demo.GenericFunctions.ModelDtos;
    using Demo.GenericFunctions.Models;
    using SendGrid.Helpers.Mail;

    /// <summary>
    /// Creates a password changed email from generic email data.
    /// </summary>
    public class PasswordChangedEmail : EmailAbstract
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PasswordChangedEmail"/> class.
        /// </summary>
        /// <param name="configurationHelper">The configuration helper to work with config values.</param>
        public PasswordChangedEmail(IConfigurationHelper configurationHelper)
            : base(configurationHelper)
        {
        }

        /// <inheritdoc/>
        public override SendGridMessage GetMessage(EmailDto emailDto)
        {
            var passwordChangedEmail = emailDto.EmailData.ToObject<PasswordChangedEmailModel>();
            var fromEmail = string.IsNullOrEmpty(emailDto.FromEmail) ? FromEmail : new EmailAddress(emailDto.FromEmail);
            var toEmail = string.IsNullOrEmpty(emailDto.ToEmail) ? ToEmail : new EmailAddress(emailDto.ToEmail);

            var data = new Dictionary<string, string>
            {
                { SendGridConstants.ClientFirstNameSendGridProperty, passwordChangedEmail.ClientFirstName },
                { SendGridConstants.ClientLastNameSendGridProperty, passwordChangedEmail.ClientLastName },
                { SendGridConstants.ConnectionLinkSendGridProperty, passwordChangedEmail.ConnectionLink }
            };

            var message = MailHelper.CreateSingleTemplateEmail(
                fromEmail,
                toEmail,
                _configurationHelper.SendGridPasswordChangedTemplateId(),
                data);

            return message;
        }
    }
}
