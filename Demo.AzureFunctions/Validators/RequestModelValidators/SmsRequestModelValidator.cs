// <copyright file="SmsRequestModelValidator.cs" company="Demo">
// Copyright (c) Demo. All rights reserved.
// </copyright>

namespace Demo.GenericFunctions.Validators.RequestModelValidators
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Demo.GenericFunctions.RequestModels;
    using Demo.GenericFunctions.Validators.Contracts;
    using Demo.Nuget.Models;

    /// <summary>
    /// An implementation of <see cref="IModelValidator"/> interface.
    /// </summary>
    public class SmsRequestModelValidator : IModelValidator
    {
        private readonly SmsRequestModel _model;

        /// <summary>
        /// Initializes a new instance of the <see cref="SmsRequestModelValidator"/> class.
        /// </summary>
        /// <param name="notificationContentRequestModel">Notification content request model.</param>
        public SmsRequestModelValidator(NotificationContentRequestModel notificationContentRequestModel)
        {
            _model = notificationContentRequestModel as SmsRequestModel;
        }

        /// <inheritdoc/>
        public ModelState Validate()
        {
            var results = new List<ValidationResult>();

            Validator.TryValidateObject(_model, new ValidationContext(_model, null, null), results, true);

            return new ModelState
            {
                IsValid = !results.Any(),
                ModelValidationResult = results
            };
        }
    }
}
