// <copyright file="NotificationContentRequestModel.cs" company="Demo">
// Copyright (c) Demo. All rights reserved.
// </copyright>

namespace Demo.GenericFunctions.RequestModels
{
    using Newtonsoft.Json;

    /// <summary>
    /// Abstract class describes base properties.
    /// </summary>
    public abstract class NotificationContentRequestModel
    {
        /// <summary>
        /// Gets or sets to.
        /// </summary>
        public virtual string To { get; set; }

        /// <summary>
        /// Gets or sets from.
        /// </summary>
        public string From { get; set; }

        /// <summary>
        /// Get converter.
        /// </summary>
        /// <returns>Get type of converter.</returns>
        public abstract JsonConverter GetConverter();
    }
}
