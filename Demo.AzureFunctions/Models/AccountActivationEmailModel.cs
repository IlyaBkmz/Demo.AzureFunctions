// <copyright file="AccountActivationEmailModel.cs" company="Demo">
// Copyright (c) Demo. All rights reserved.
// </copyright>

namespace Demo.GenericFunctions.Models
{
    /// <summary>
    /// Describes a mail with account activation link.
    /// </summary>
    public class AccountActivationEmailModel : IEmail
    {
        /// <summary>
        /// Gets or sets an activation link.
        /// </summary>
        public string ActivationLink { get; set; }
    }
}
