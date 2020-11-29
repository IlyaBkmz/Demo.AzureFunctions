// <copyright file="EmailRequestModelValidator.cs" company="Demo">
// Copyright (c) Demo. All rights reserved.
// </copyright>

namespace Demo.GenericFunctions.Validators.RequestModelValidators
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Demo.GenericFunctions.Helpers.Type;
    using Demo.GenericFunctions.Models;
    using Demo.GenericFunctions.RequestModels;
    using Demo.GenericFunctions.Validators.Contracts;
    using Demo.Nuget.Models;

    /// <summary>
    /// An implementation of <see cref="IModelValidator"/> interface.
    /// </summary>
    public class EmailRequestModelValidator : IModelValidator
    {
        private readonly EmailRequestModel _model;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmailRequestModelValidator"/> class.
        /// </summary>
        /// <param name="notificationContentRequestModel">Notification content request model.</param>
        public EmailRequestModelValidator(NotificationContentRequestModel notificationContentRequestModel)
        {
            _model = notificationContentRequestModel as EmailRequestModel;
        }

        /// <inheritdoc/>
        public ModelState Validate()
        {
            var results = new List<ValidationResult>();

            if (string.IsNullOrEmpty(_model.From))
            {
                var errorMessage = $"The '{nameof(EmailRequestModel.From)}' field can not be empty.";
                var validationResult = new ValidationResult(errorMessage);
                results.Add(validationResult);
            }

            if (!Enum.IsDefined(typeof(EmailTypeEnum), _model.Type))
            {
                var errorMessage = $"The '{nameof(EmailRequestModel.Type)}' field is missing or invalid.";
                var validationResult = new ValidationResult(errorMessage);
                results.Add(validationResult);
            }

            if (!results.Any())
            {
                Validator.TryValidateObject(_model, new ValidationContext(_model, null, null), results, true);

                var emailContentModelState = ValidateEmailChildProperties();
                if (!emailContentModelState.IsValid)
                {
                    results.AddRange(emailContentModelState.ModelValidationResult);
                }
            }

            return new ModelState
            {
                IsValid = results.Any() ? false : true,
                ModelValidationResult = results
            };
        }

        private ModelState ValidateEmailChildProperties()
        {
            var results = new List<ValidationResult>();

            var emailModel = new EmailTypeFactory().Create(_model.Type);
            var properties = emailModel.GetType().GetProperties();
            var emailContent = new Dictionary<string, string>(_model.Properties, StringComparer.OrdinalIgnoreCase);

            foreach (var property in properties)
            {
                if (emailContent.ContainsKey(property.Name))
                {
                    if (string.IsNullOrEmpty(emailContent[property.Name]))
                    {
                        var errorMessage = $"The '{property.Name}' value can not be empty.";
                        var validationResult = new ValidationResult(errorMessage);
                        results.Add(validationResult);
                    }

                    if (emailContent[property.Name].GetType().Equals(typeof(string)))
                    {
                        if (string.IsNullOrEmpty(emailContent[property.Name].ToString()))
                        {
                            var errorMessage = $"The '{property.Name}' value can not be empty.";
                            var validationResult = new ValidationResult(errorMessage);
                            results.Add(validationResult);
                        }
                    }
                }
                else
                {
                    var errorMessage = $"The '{property.Name}' is missed.";
                    var validationResult = new ValidationResult(errorMessage);
                    results.Add(validationResult);
                }
            }

            return new ModelState
            {
                IsValid = results.Any() ? false : true,
                ModelValidationResult = results
            };
        }
    }
}
