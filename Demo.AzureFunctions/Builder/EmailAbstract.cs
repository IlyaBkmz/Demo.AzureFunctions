// <copyright file="EmailAbstract.cs" company="Demo">
// Copyright (c) Demo. All rights reserved.
// </copyright>

namespace Demo.GenericFunctions.Builder
{
    using Demo.GenericFunctions.Helpers;
    using Demo.GenericFunctions.ModelDtos;
    using SendGrid.Helpers.Mail;

    /// <summary>
    /// An absctact class, that represents email entity.
    /// </summary>
    public abstract class EmailAbstract
    {
        /// <summary>
        /// The configuration helper to work with config values.
        /// </summary>
        protected IConfigurationHelper _configurationHelper;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmailAbstract"/> class.
        /// </summary>
        /// <param name="configurationHelper">The configuration helper to work with config values.</param>
        public EmailAbstract(IConfigurationHelper configurationHelper)
        {
            _configurationHelper = configurationHelper;
        }

        /// <summary>
        /// Gets from email property.
        /// </summary>
        protected EmailAddress FromEmail => new EmailAddress(_configurationHelper.SendGridFromEmail());

        /// <summary>
        /// Gets to email property.
        /// </summary>
        protected EmailAddress ToEmail => new EmailAddress(_configurationHelper.SendGridToEmail());

        /// <summary>
        /// Gets message from general email.
        /// </summary>
        /// <param name="emailDto">A general message to retrieve information.</param>
        /// <returns>A sendGrid message.</returns>
        public abstract SendGridMessage GetMessage(EmailDto emailDto);
    }
}
