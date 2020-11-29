// <copyright file="HandleSms.cs" company="Demo">
// Copyright (c) Demo. All rights reserved.
// </copyright>

namespace Demo.GenericFunctions.Functions
{
    using System.Threading.Tasks;
    using Demo.GenericFunctions.ModelDtos;
    using Demo.GenericFunctions.Services.Interfaces;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;

    /// <summary>
    /// Contains function that sends the sms message to the user.
    /// </summary>
    public class HandleSms
    {
        private readonly ISenderService<SmsDto> _senderService;

        /// <summary>
        /// Initializes a new instance of the <see cref="HandleSms"/> class.
        /// </summary>
        /// <param name="senderService">The service to send messages.</param>
        public HandleSms(ISenderService<SmsDto> senderService)
        {
            _senderService = senderService;
        }

        /// <summary>
        /// Sends the sms message from the Service Bus queue.
        /// </summary>
        /// <param name="smsQueueItem">The sms message from the queque.</param>
        /// <param name="logger">The logger to log info messages.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [FunctionName("HandleSms")]
        public async Task Run(
            [ServiceBusTrigger("%smsQueueName%", Connection = "ServiceBusConnection")]string smsQueueItem,
            ILogger logger)
        {
            logger.LogInformation($"{nameof(HandleSms)} function starts.");

            var smsDto = JsonConvert.DeserializeObject<SmsDto>(smsQueueItem);
            await _senderService.SendAsync(smsDto);

            logger.LogInformation($"{nameof(HandleSms)} function ends.");
        }
    }
}
