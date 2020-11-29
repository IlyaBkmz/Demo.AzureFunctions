// <copyright file="INotificator.cs" company="Demo">
// Copyright (c) Demo. All rights reserved.
// </copyright>

namespace Demo.GenericFunctions.Services.QueueService.Contracts
{
    using System.Threading.Tasks;
    using Demo.GenericFunctions.RequestModels;

    /// <summary>
    /// An interface describes notificator service.
    /// </summary>
    public interface INotificator
    {
        /// <summary>
        /// Send notification.
        /// </summary>
        /// <param name="notificationContentRequestModel">Notification content.</param>
        /// <returns>Task.</returns>
        Task SendAsync(NotificationContentRequestModel notificationContentRequestModel);
    }
}
