// <copyright file="NotificationRequestModel.cs" company="Demo">
// Copyright (c) Demo. All rights reserved.
// </copyright>

namespace Demo.GenericFunctions.RequestModels
{
    using Demo.GenericFunctions.Models.Enums;

    /// <summary>
    /// Describes <see cref="NotificationRequestModel" /> entity.
    /// </summary>
    public class NotificationRequestModel
    {
        /// <summary>
        /// Gets or sets the notification type.
        /// </summary>
        public NotificationTypeEnum NotificationType { get; set; }

        /// <summary>
        /// Gets or sets the notification content.
        /// </summary>
        public NotificationContentRequestModel NotificationContent { get; set; }
    }
}
