// <copyright file="PersonalInfoModificationEmailModel.cs" company="Demo">
// Copyright (c) Demo. All rights reserved.
// </copyright>

namespace Demo.GenericFunctions.Models
{
    /// <summary>
    /// Describes a mail about personal info modification.
    /// </summary>
    public class PersonalInfoModificationEmailModel : IEmail
    {
        /// <summary>
        /// Gets or sets a client first name.
        /// </summary>
        public string ClientFirstName { get; set; }

        /// <summary>
        /// Gets or sets a client last name.
        /// </summary>
        public string ClientLastName { get; set; }

        /// <summary>
        /// Gets or sets a connection link.
        /// </summary>
        public string ConnectionLink { get; set; }
    }
}
