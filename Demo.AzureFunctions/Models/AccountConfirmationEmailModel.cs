// <copyright file="AccountConfirmationEmailModel.cs" company="Demo">
// Copyright (c) Demo. All rights reserved.
// </copyright>

namespace Demo.GenericFunctions.Models
{
    /// <summary>
    /// Describes a mail with confirmation of account creation.
    /// </summary>
    public class AccountConfirmationEmailModel : IEmail
    {
        /// <summary>
        /// Gets or sets a connection link.
        /// </summary>
        public string ConnectionLink { get; set; }
    }
}
