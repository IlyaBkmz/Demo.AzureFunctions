// <copyright file="ConfigurationHelper.cs" company="Demo">
// Copyright (c) Demo. All rights reserved.
// </copyright>

namespace Demo.GenericFunctions.Helpers
{
    using Demo.GenericFunctions.Configuration;

    /// <summary>
    /// An implementation of <see cref="IConfigurationHelper" ></see> interface.
    /// </summary>
    public class ConfigurationHelper : IConfigurationHelper
    {
        /// <inheritdoc/>
        public string EmailQueueName()
        {
            return ConfigurationsSection.EmailQueueName;
        }

        /// <inheritdoc/>
        public string SendGridApiKey()
        {
            return ConfigurationsSection.SendGridApiKey;
        }

        /// <inheritdoc/>
        public string SendGridFrom()
        {
            return ConfigurationsSection.SendGridFrom;
        }

        /// <inheritdoc/>
        public string SendGridFromEmail()
        {
            return ConfigurationsSection.SendGridFromEmail;
        }

        /// <inheritdoc/>
        public string SendGridToEmail()
        {
            return ConfigurationsSection.SendGridToEmail;
        }

        /// <inheritdoc/>
        public string SmsQueueName()
        {
            return ConfigurationsSection.SmsQueueName;
        }

        /// <inheritdoc/>
        public string SendGridAccountConfirmationTemplateId()
        {
            return ConfigurationsSection.SendGridAccountConfirmationTemplateId;
        }

        /// <inheritdoc/>
        public string SendGridAccountActivationTemplateId()
        {
            return ConfigurationsSection.SendGridAccountActivationTemplateId;
        }

        /// <inheritdoc/>
        public string SendGridPersonalInfoModificationTemplateId()
        {
            return ConfigurationsSection.SendGridPersonalInfoModificationTemplateId;
        }

        /// <inheritdoc/>
        public string SendGridPasswordChangedTemplateId()
        {
            return ConfigurationsSection.SendGridPasswordChangedTemplateId;
        }
    }
}
