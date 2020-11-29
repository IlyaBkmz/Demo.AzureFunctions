// <copyright file="EmailRequestModelValidatorFactory.cs" company="Demo">
// Copyright (c) Demo. All rights reserved.
// </copyright>

namespace Demo.GenericFunctions.Validators.RequestModelValidators.Factories
{
    using Demo.GenericFunctions.RequestModels;
    using Demo.GenericFunctions.Validators.Contracts;

    /// <summary>
    /// Sms request model validator factory.
    /// </summary>
    public class EmailRequestModelValidatorFactory : RequestModelValidatorFactory
    {
        /// <inheritdoc/>
        public override IModelValidator Create(NotificationContentRequestModel notificationContentRequestModel)
            => new EmailRequestModelValidator(notificationContentRequestModel);
    }
}
