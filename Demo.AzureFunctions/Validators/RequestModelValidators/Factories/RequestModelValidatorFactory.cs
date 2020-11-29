// <copyright file="RequestModelValidatorFactory.cs" company="Demo">
// Copyright (c) Demo. All rights reserved.
// </copyright>

namespace Demo.GenericFunctions.Validators.RequestModelValidators.Factories
{
    using Demo.GenericFunctions.RequestModels;
    using Demo.GenericFunctions.Validators.Contracts;

    /// <summary>
    /// Describes request model validator factory.
    /// </summary>
    public abstract class RequestModelValidatorFactory
    {
        /// <summary>
        /// Creates Model validator.
        /// </summary>
        /// <param name="notificationContentRequestModel">Notification content request model.</param>
        /// <returns>Implementation of IModelValidator.</returns>
        public abstract IModelValidator Create(NotificationContentRequestModel notificationContentRequestModel);
    }
}
