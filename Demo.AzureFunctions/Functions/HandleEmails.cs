// <copyright file="HandleEmails.cs" company="Demo">
// Copyright (c) Demo. All rights reserved.
// </copyright>

namespace Demo.GenericFunctions.Functions
{
    using System.Threading.Tasks;
    using Demo.GenericFunctions.Builder.Factories;
    using Demo.GenericFunctions.ModelDtos;
    using Demo.GenericFunctions.Services.Interfaces;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;
    using SendGrid.Helpers.Mail;

    /// <summary>
    /// Contains function that sends the email to the user.
    /// </summary>
    public class HandleEmails
    {
        private readonly ISenderService<SendGridMessage> _emailSenderService;
        private readonly IEmailBuilderFactory _emailBuilderFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="HandleEmails"/> class.
        /// </summary>
        /// <param name="emailSenderService">The service to send emails.</param>
        /// <param name="emailBuilderFactory">The service to create the emails.</param>
        public HandleEmails(ISenderService<SendGridMessage> emailSenderService, IEmailBuilderFactory emailBuilderFactory)
        {
            _emailSenderService = emailSenderService;
            _emailBuilderFactory = emailBuilderFactory;
        }

        /// <summary>
        /// Sends the email from the Service Bus queue.
        /// </summary>
        /// <param name="queueMessage">The email from the queque.</param>
        /// <param name="logger">The logger to log info messages.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [FunctionName("HandleEmails")]
        public async Task RunAsync(
            [ServiceBusTrigger("%emailQueueName%", Connection = "ServiceBusConnection")]string queueMessage,
            ILogger logger)
        {
            logger.LogInformation($"{nameof(HandleEmails)} function starts.");
            logger.LogInformation($"Email to send as JSON: {queueMessage}.");

            var emailDto = JsonConvert.DeserializeObject<EmailDto>(queueMessage);

            var email = _emailBuilderFactory
                .Create(emailDto.Type)
                .GetMessage(emailDto);

            await _emailSenderService.SendAsync(email);

            logger.LogInformation($"{nameof(HandleEmails)} function ends.");
        }
    }
}
