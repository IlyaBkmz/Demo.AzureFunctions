// <copyright file="INotificationTypeFactory.cs" company="Demo">
// Copyright (c) Demo. All rights reserved.
// </copyright>

namespace Demo.GenericFunctions.Services.QueueService.Factories
{
    using Demo.GenericFunctions.Models.Enums;
    using Demo.GenericFunctions.Services.QueueService.Contracts;

    /// <summary>
    /// Class describes notification type factory.
    /// </summary>
    public interface INotificationTypeFactory
    {
        /// <summary>
        /// Create an instance of INotificator.
        /// </summary>
        /// <param name="notificationType">Notification type.</param>
        /// <returns>The instance of INotificator.</returns>
        INotificator Create(NotificationTypeEnum notificationType);
    }
}
