// <copyright file="ModelValidator.cs" company="Demo">
// Copyright (c) Demo. All rights reserved.
// </copyright>

namespace Demo.GenericFunctions.Validators.RequestModelValidators.Factories
{
    using System;
    using System.Collections.Generic;
    using Demo.GenericFunctions.Models.Enums;
    using Demo.GenericFunctions.RequestModels;
    using Demo.GenericFunctions.Validators.Contracts;

    /// <summary>
    /// Class describes model validator.
    /// </summary>
    public class ModelValidator
    {
        private readonly Dictionary<NotificationTypeEnum, RequestModelValidatorFactory> _factories;

        private ModelValidator()
        {
            _factories = new Dictionary<NotificationTypeEnum, RequestModelValidatorFactory>();
            foreach (NotificationTypeEnum notificationType in Enum.GetValues(typeof(NotificationTypeEnum)))
            {
                var type = Type.GetType($"Demo.GenericFunctions.Validators.RequestModelValidators.Factories.{notificationType}RequestModelValidatorFactory");
                var factory = (RequestModelValidatorFactory)Activator.CreateInstance(type);
                _factories.Add(notificationType, factory);
            }
        }

        /// <summary>
        /// Initialize factories.
        /// </summary>
        /// <returns>A model validator.</returns>
        public static ModelValidator InitializeFactories() => new ModelValidator();

        /// <summary>
        /// Create an instance of model validator.
        /// </summary>
        /// <param name="notificationType">The notification type.</param>
        /// <param name="notificationContent">The notification content.</param>
        /// <returns>Instance of <see cref="IModelValidator"/>.</returns>
        public IModelValidator ExecuteCreation(NotificationTypeEnum notificationType, NotificationContentRequestModel notificationContent)
            => _factories[notificationType].Create(notificationContent);
    }
}
