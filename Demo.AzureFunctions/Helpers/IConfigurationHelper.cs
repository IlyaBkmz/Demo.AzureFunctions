// <copyright file="IConfigurationHelper.cs" company="Demo">
// Copyright (c) Demo. All rights reserved.
// </copyright>

namespace Demo.GenericFunctions.Helpers
{
    /// <summary>
    /// An interface that allows to access different configuration variables.
    /// </summary>
    public interface IConfigurationHelper
    {
        /// <summary>
        /// Gets SendGrid API Key.
        /// </summary>
        /// <returns>A SendGrid API Key.</returns>
        string SendGridApiKey();

        /// <summary>
        /// Gets an email for 'from email' property.
        /// </summary>
        /// <returns>An email for 'from email' property.</returns>
        string SendGridFromEmail();

        /// <summary>
        /// Gets an account confirmation template id property.
        /// </summary>
        /// <returns>An account confirmation template id.</returns>
        string SendGridAccountConfirmationTemplateId();

        /// <summary>
        /// Gets an account activation template id property.
        /// </summary>
        /// <returns>An account activation template id.</returns>
        string SendGridAccountActivationTemplateId();

        /// <summary>
        /// Gets a personal info modification template id property.
        /// </summary>
        /// <returns>A personal info modification template id.</returns>
        string SendGridPersonalInfoModificationTemplateId();

        /// <summary>
        /// Gets an email 'from' property.
        /// </summary>
        /// <returns>A mail sender name.</returns>
        string SendGridFrom();

        /// <summary>
        /// Gets an email 'to' property.
        /// </summary>
        /// <returns>A mail reciever name.</returns>
        string SendGridToEmail();

        /// <summary>
        /// Gets SendGrid password changed template id.
        /// </summary>
        /// <returns>A password changed template id.</returns>
        string SendGridPasswordChangedTemplateId();

        /// <summary>
        /// Gets sms queue name.
        /// </summary>
        /// <returns>A queue name for sms.</returns>
        string SmsQueueName();

        /// <summary>
        /// Gets email queue name.
        /// </summary>
        /// <returns>A queue name for emails.</returns>
        string EmailQueueName();
    }
}
