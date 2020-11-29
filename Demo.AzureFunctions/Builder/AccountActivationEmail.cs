// <copyright file="AccountActivationEmail.cs" company="Demo">
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
    /// Creates an account activation email from generic email data.
    /// </summary>
    public class AccountActivationEmail : EmailAbstract
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountActivationEmail"/> class.
        /// </summary>
        /// <param name="configurationHelper">The configuration helper to work with config values.</param>
        public AccountActivationEmail(IConfigurationHelper configurationHelper)
            : base(configurationHelper)
        {
        }

        /// <inheritdoc/>
        public override SendGridMessage GetMessage(EmailDto emailDto)
        {
            var accountActivationEmail = emailDto.EmailData.ToObject<AccountActivationEmailModel>();
            var fromEmail = string.IsNullOrEmpty(emailDto.FromEmail) ? FromEmail : new EmailAddress(emailDto.FromEmail);
            var toEmail = string.IsNullOrEmpty(emailDto.ToEmail) ? ToEmail : new EmailAddress(emailDto.ToEmail);

            var data = new Dictionary<string, string>
            {
                { SendGridConstants.ActivationLinkSendGridProperty, accountActivationEmail.ActivationLink }
            };

            var message = MailHelper.CreateSingleTemplateEmail(
                fromEmail,
                toEmail,
                _configurationHelper.SendGridAccountActivationTemplateId(),
                data);

            return message;
        }
    }
}
