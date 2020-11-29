// <copyright file="EmailNotificator.cs" company="Demo">
// Copyright (c) Demo. All rights reserved.
// </copyright>

namespace Demo.GenericFunctions.Services.QueueService
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;
    using Demo.GenericFunctions.Helpers;
    using Demo.GenericFunctions.Helpers.Type;
    using Demo.GenericFunctions.ModelDtos;
    using Demo.GenericFunctions.Models;
    using Demo.GenericFunctions.RequestModels;
    using Demo.GenericFunctions.Services.QueueService.Contracts;
    using Demo.Nuget.Exceptions;
    using Demo.Nuget.Helpers;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// An implementation of <see cref="INotificator"/> interface.
    /// </summary>
    public class EmailNotificator : INotificator
    {
        private readonly IServiceBusHelper _serviceBusHelper;
        private readonly IConfigurationHelper _configurationHelper;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmailNotificator"/> class.
        /// </summary>
        /// <param name="serviceBusHelper">ServiceBus helper.</param>
        /// <param name="configurationHelper">Configuration helper.</param>
        public EmailNotificator(
            IServiceBusHelper serviceBusHelper,
            IConfigurationHelper configurationHelper)
        {
            _serviceBusHelper = serviceBusHelper;
            _configurationHelper = configurationHelper;
        }

        /// <inheritdoc/>
        public async Task SendAsync(NotificationContentRequestModel notificationContentRequestModel)
        {
            var model = notificationContentRequestModel as EmailRequestModel;
            var email = GetEmailModelProperties(model);
            var queueName = _configurationHelper.EmailQueueName();
            var emailDto = new EmailDto
            {
                EmailData = JObject.FromObject(email),
                FromEmail = notificationContentRequestModel.From,
                ToEmail = string.IsNullOrEmpty(model.To) ? _configurationHelper.SendGridToEmail() : model.To,
                Type = model.Type
            };

            await _serviceBusHelper.SendMessageToQueueAsync(emailDto, queueName);
        }

        private IEmail GetEmailModelProperties(EmailRequestModel model)
        {
            var emailModel = new EmailTypeFactory().Create(model.Type);
            var properties = emailModel.GetType().GetProperties();
            var emailContent = new Dictionary<string, string>(model.Properties, StringComparer.OrdinalIgnoreCase);

            foreach (var property in properties)
            {
                var propertyValue = emailContent[property.Name];
                if (property.PropertyType.IsEnum)
                {
                    try
                    {
                        property.SetValue(emailModel, Enum.Parse(property.PropertyType, propertyValue.ToString()));
                    }
                    catch (Exception ex)
                    {
                        throw new DemoException(ex.Message, HttpStatusCode.BadRequest);
                    }
                }
                else
                {
                    property.SetValue(emailModel, propertyValue);
                }
            }

            return emailModel;
        }
    }
}
