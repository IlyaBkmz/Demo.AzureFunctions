// <copyright file="EmailDto.cs" company="Demo">
// Copyright (c) Demo. All rights reserved.
// </copyright>

namespace Demo.GenericFunctions.ModelDtos
{
    using Demo.GenericFunctions.Models;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Describes email enity.
    /// </summary>
    public class EmailDto
    {
        /// <summary>
        /// Gets or sets email type.
        /// </summary>
        public EmailTypeEnum Type { get; set; }

        /// <summary>
        /// Gets or sets an email data.
        /// </summary>
        public JObject EmailData { get; set; }

        /// <summary>
        /// Gets or sets a from email.
        /// </summary>
        public string FromEmail { get; set; }

        /// <summary>
        /// Gets or sets a to email.
        /// </summary>
        public string ToEmail { get; set; }
    }
}
