// <copyright file="EmailRequestModel.cs" company="Demo">
// Copyright (c) Demo. All rights reserved.
// </copyright>

namespace Demo.GenericFunctions.RequestModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Demo.GenericFunctions.Helpers.Converters;
    using Demo.GenericFunctions.Models;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Describes email enity.
    /// </summary>
    public class EmailRequestModel : NotificationContentRequestModel
    {
        /// <summary>
        /// Gets or sets email type.
        /// </summary>
        [Required]
        [JsonProperty("emailType")]
        public EmailTypeEnum Type { get; set; }

        /// <summary>
        /// Gets or sets content.
        /// </summary>
        [Required]
        public JObject Content { get; set; }

        /// <summary>
        /// Gets properties.
        /// </summary>
        [JsonIgnore]
        public Dictionary<string, string> Properties => Content.ToObject<Dictionary<string, string>>();

        /// <inheritdoc/>
        public override JsonConverter GetConverter() => new AbstractConverter<EmailRequestModel, NotificationContentRequestModel>();
    }
}
