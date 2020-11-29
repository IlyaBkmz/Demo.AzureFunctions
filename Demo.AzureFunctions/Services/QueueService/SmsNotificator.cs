// <copyright file="SmsNotificator.cs" company="Demo">
// Copyright (c) Demo. All rights reserved.
// </copyright>

namespace Demo.GenericFunctions.Services.QueueService
{
    using System.Threading.Tasks;
    using Demo.GenericFunctions.Helpers;
    using Demo.GenericFunctions.ModelDtos;
    using Demo.GenericFunctions.RequestModels;
    using Demo.GenericFunctions.Services.QueueService.Contracts;
    using Demo.Nuget.Helpers;

    /// <summary>
    /// An implementation of <see cref="INotificator"/> interface.
    /// </summary>
    public class SmsNotificator : INotificator
    {
        private readonly IServiceBusHelper _serviceBusHelper;
        private readonly IConfigurationHelper _configurationHelper;

        /// <summary>
        /// Initializes a new instance of the <see cref="SmsNotificator"/> class.
        /// </summary>
        /// <param name="serviceBusHelper">ServiceBus helper.</param>
        /// <param name="configurationHelper">Configuration helper.</param>
        public SmsNotificator(
            IServiceBusHelper serviceBusHelper,
            IConfigurationHelper configurationHelper)
        {
            _serviceBusHelper = serviceBusHelper;
            _configurationHelper = configurationHelper;
        }

        /// <inheritdoc/>
        public async Task SendAsync(NotificationContentRequestModel notificationContentRequestModel)
        {
            var model = notificationContentRequestModel as SmsRequestModel;
            var queueName = _configurationHelper.SmsQueueName();
            var smsDto = new SmsDto { To = model.To, Body = model.Content };

            await _serviceBusHelper.SendMessageToQueueAsync(smsDto, queueName);
        }
    }
}
