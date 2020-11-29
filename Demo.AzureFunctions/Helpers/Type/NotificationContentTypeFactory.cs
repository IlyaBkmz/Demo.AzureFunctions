// <copyright file="NotificationContentTypeFactory.cs" company="Demo">
// Copyright (c) Demo. All rights reserved.
// </copyright>

namespace Demo.GenericFunctions.Helpers.Type
{
    using System;
    using System.Collections.Generic;
    using Demo.GenericFunctions.Models.Enums;
    using Demo.GenericFunctions.RequestModels;

    /// <summary>
    /// Notification content type factory.
    /// </summary>
    public class NotificationContentTypeFactory
    {
        private readonly Dictionary<NotificationTypeEnum, NotificationContentRequestModel> _factories;

        /// <summary>
        /// Initializes a new instance of the <see cref="NotificationContentTypeFactory"/> class.
        /// </summary>
        public NotificationContentTypeFactory()
        {
            _factories = new Dictionary<NotificationTypeEnum, NotificationContentRequestModel>();
            foreach (NotificationTypeEnum notificationType in Enum.GetValues(typeof(NotificationTypeEnum)))
            {
                var type = Type.GetType($"Demo.GenericFunctions.RequestModels.{notificationType}RequestModel");
                var factory = (NotificationContentRequestModel)Activator.CreateInstance(type);
                _factories.Add(notificationType, factory);
            }
        }

        /// <summary>
        /// Create notification content request model.
        /// </summary>
        /// <param name="notificationType">Notification type.</param>
        /// <returns>Notification Content Request Model.</returns>
        public NotificationContentRequestModel Create(NotificationTypeEnum notificationType) => _factories[notificationType];
    }
}
