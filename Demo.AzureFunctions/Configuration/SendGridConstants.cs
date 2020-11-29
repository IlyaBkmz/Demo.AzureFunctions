// <copyright file="SendGridConstants.cs" company="Demo">
// Copyright (c) Demo. All rights reserved.
// </copyright>

namespace Demo.GenericFunctions.Configuration
{
    /// <summary>
    /// Constant messages with SendGrid properties names.
    /// </summary>
    public class SendGridConstants
    {
        /// <summary>
        /// The client last name in the SendGrid template.
        /// </summary>
        public const string ClientLastNameSendGridProperty = "clientLastName";

        /// <summary>
        /// The client first name in the SendGrid template.
        /// </summary>
        public const string ClientFirstNameSendGridProperty = "clientFirstName";

        /// <summary>
        /// The name of connection link property in the SendGrid template.
        /// </summary>
        public const string ConnectionLinkSendGridProperty = "connectionLink";

        /// <summary>
        /// The name of activation link property in the SendGrid template.
        /// </summary>
        public const string ActivationLinkSendGridProperty = "activationLink";
    }
}
