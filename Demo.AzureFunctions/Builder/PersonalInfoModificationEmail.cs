// <copyright file="PersonalInfoModificationEmail.cs" company="Demo">
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
    /// Creates a PersonalInfoModification email from generic email data.
    /// </summary>
    public class PersonalInfoModificationEmail : EmailAbstract
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PersonalInfoModificationEmail"/> class.
        /// </summary>
        /// <param name="configurationHelper">The configuration helper to work with config values.</param>
        public PersonalInfoModificationEmail(IConfigurationHelper configurationHelper)
            : base(configurationHelper)
        {
        }

        /// <inheritdoc/>
        public override SendGridMessage GetMessage(EmailDto emailDto)
        {
            var personalInfoModificationEmail = emailDto.EmailData.ToObject<PersonalInfoModificationEmailModel>();
            var fromEmail = string.IsNullOrEmpty(emailDto.FromEmail) ? FromEmail : new EmailAddress(emailDto.FromEmail);
            var toEmail = string.IsNullOrEmpty(emailDto.ToEmail) ? ToEmail : new EmailAddress(emailDto.ToEmail);

            var data = new Dictionary<string, string>
            {
                { SendGridConstants.ClientFirstNameSendGridProperty, personalInfoModificationEmail.ClientFirstName },
                { SendGridConstants.ClientLastNameSendGridProperty, personalInfoModificationEmail.ClientLastName },
                { SendGridConstants.ConnectionLinkSendGridProperty, personalInfoModificationEmail.ConnectionLink }
            };

            var message = MailHelper.CreateSingleTemplateEmail(
                fromEmail,
                toEmail,
                _configurationHelper.SendGridPersonalInfoModificationTemplateId(),
                data);

            return message;
        }
    }
}
