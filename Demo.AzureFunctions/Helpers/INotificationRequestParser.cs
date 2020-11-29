// <copyright file="INotificationRequestParser.cs" company="Demo">
// Copyright (c) Demo. All rights reserved.
// </copyright>

namespace Demo.GenericFunctions.Helpers
{
    using Demo.GenericFunctions.RequestModels;

    /// <summary>
    /// Notification request parser contracts.
    /// </summary>
    public interface INotificationRequestParser
    {
        /// <summary>
        /// Parse body.
        /// </summary>
        /// <param name="body">Body as JSON.</param>
        /// <returns>Notification request model.</returns>
        NotificationRequestModel Parse(string body);
    }
}
