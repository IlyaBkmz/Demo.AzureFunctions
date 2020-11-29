// <copyright file="SmsRequestModel.cs" company="Demo">
// Copyright (c) Demo. All rights reserved.
// </copyright>

namespace Demo.GenericFunctions.RequestModels
{
    using System.ComponentModel.DataAnnotations;
    using Demo.GenericFunctions.Helpers.Converters;
    using Newtonsoft.Json;

    /// <summary>
    /// describes sms message entity.
    /// </summary>
    public class SmsRequestModel : NotificationContentRequestModel
    {
        /// <summary>
        /// Gets or sets to.
        /// </summary>
        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^33[0-9]{9}", ErrorMessage = "Not a valid french phone number.")]
        public override string To { get; set; }

        /// <summary>
        /// Gets or sets message body.
        /// </summary>
        [Required]
        public string Content { get; set; }

        /// <inheritdoc/>
        public override JsonConverter GetConverter() => new AbstractConverter<SmsRequestModel, NotificationContentRequestModel>();
    }
}
