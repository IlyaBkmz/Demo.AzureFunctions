// <copyright file="ConfigurationsSection.cs" company="Demo">
// Copyright (c) Demo. All rights reserved.
// </copyright>

namespace Demo.GenericFunctions.Configuration
{
    using System;

    /// <summary>
    /// Contains configuration variables.
    /// </summary>
    public class ConfigurationsSection
    {
        /// <summary>
        /// Gets a SendGrid API Key.
        /// </summary>
        public static string SendGridApiKey => Environment.GetEnvironmentVariable("SENDGRID_KEY");

        /// <summary>
        /// Gets an email for 'from email' property.
        /// </summary>
        public static string SendGridFromEmail => Environment.GetEnvironmentVariable("SENDGRID_FROM_EMAIL");

        /// <summary>
        /// Gets an email 'from' property.
        /// </summary>
        public static string SendGridFrom => Environment.GetEnvironmentVariable("SENDGRID_FROM");

        /// <summary>
        /// Gets an email 'to' property.
        /// </summary>
        public static string SendGridToEmail => Environment.GetEnvironmentVariable("SENDGRID_TO_EMAIL");

        /// <summary>
        /// Gets a SendGrid account confirmation template id.
        /// </summary>
        public static string SendGridAccountConfirmationTemplateId => Environment.GetEnvironmentVariable("SENDGRID_ACCOUNT_CONFIRMATION_TEMPLATEID");

        /// <summary>
        /// Gets a SendGrid account activation template id.
        /// </summary>
        public static string SendGridAccountActivationTemplateId => Environment.GetEnvironmentVariable("SENDGRID_ACCOUNT_ACTIVATION_TEMPLATEID");

        /// <summary>
        /// Gets a SendGrid password changed template id.
        /// </summary>
        public static string SendGridPasswordChangedTemplateId => Environment.GetEnvironmentVariable("SENDGRID_PASSWORD_CHANGED_TEMPLATEID");

        /// <summary>
        /// Gets a SendGrid personal info modification template id.
        /// </summary>
        public static string SendGridPersonalInfoModificationTemplateId => Environment.GetEnvironmentVariable("SENDGRID_PERSONAL_INFO_MODIFICATION_TEMPLATEID");

        /// <summary>
        /// Gets an email queue name.
        /// </summary>
        public static string EmailQueueName => Environment.GetEnvironmentVariable("EmailQueueName");

        /// <summary>
        /// Gets a sms queue name.
        /// </summary>
        public static string SmsQueueName => Environment.GetEnvironmentVariable("SmsQueueName");
    }
}
