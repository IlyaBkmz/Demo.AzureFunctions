// <copyright file="NotificationTypeFactory.cs" company="Demo">
// Copyright (c) Demo. All rights reserved.
// </copyright>

namespace Demo.GenericFunctions.Services.QueueService.Factories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Demo.GenericFunctions.Models.Enums;
    using Demo.GenericFunctions.Services.QueueService.Contracts;

    /// <summary>
    /// Class describes notification type factory.
    /// </summary>
    public class NotificationTypeFactory : INotificationTypeFactory
    {
        private readonly Dictionary<NotificationTypeEnum, INotificator> _factories;

        /// <summary>
        /// Initializes a new instance of the <see cref="NotificationTypeFactory"/> class.
        /// </summary>
        /// <param name="serviceProvider">Service provider.</param>
        public NotificationTypeFactory(IServiceProvider serviceProvider)
        {
            _factories = new Dictionary<NotificationTypeEnum, INotificator>();
            var notificators = serviceProvider.GetService(typeof(IEnumerable<INotificator>));
            var notificatorServices = (INotificator[])notificators;

            foreach (NotificationTypeEnum notificationType in Enum.GetValues(typeof(NotificationTypeEnum)))
            {
                var type = Type.GetType($"Demo.GenericFunctions.Services.QueueService.{notificationType}Notificator");
                var factory = notificatorServices.FirstOrDefault(x => x.GetType() == type);
                if (factory == null)
                {
                    throw new ArgumentNullException(type.Name);
                }

                _factories.Add(notificationType, factory);
            }
        }

        /// <summary>
        /// Create INotificator instances.
        /// </summary>
        /// <param name="notificationType">Notification type.</param>
        /// <returns>Implementation of INotificator.</returns>
        public INotificator Create(NotificationTypeEnum notificationType)
            => _factories[notificationType];
    }
}
