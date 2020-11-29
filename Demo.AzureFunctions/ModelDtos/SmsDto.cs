// <copyright file="SmsDto.cs" company="Demo">
// Copyright (c) Demo. All rights reserved.
// </copyright>

namespace Demo.GenericFunctions.ModelDtos
{
    /// <summary>
    /// describes sms message entity.
    /// </summary>
    public class SmsDto
    {
        /// <summary>
        /// Gets or sets to whom message shoud be sent.
        /// </summary>
        public string To { get; set; }

        /// <summary>
        /// gets or sets message body.
        /// </summary>
        public string Body { get; set; }
    }
}
