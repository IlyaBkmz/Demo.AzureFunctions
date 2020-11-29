// <copyright file="SmsRequestModelValidatorFactory.cs" company="Demo">
// Copyright (c) Demo. All rights reserved.
// </copyright>

namespace Demo.GenericFunctions.Validators.RequestModelValidators.Factories
{
    using Demo.GenericFunctions.RequestModels;
    using Demo.GenericFunctions.Validators.Contracts;

    /// <summary>
    /// Sms request model validator factory.
    /// </summary>
    public class SmsRequestModelValidatorFactory : RequestModelValidatorFactory
    {
        /// <inheritdoc/>
        public override IModelValidator Create(NotificationContentRequestModel notificationContentRequestModel)
            => new SmsRequestModelValidator(notificationContentRequestModel);
    }
}
