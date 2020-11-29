// <copyright file="EmailSenderService.cs" company="Demo">
// Copyright (c) Demo. All rights reserved.
// </copyright>

namespace Demo.GenericFunctions.Services
{
    using System.Net;
    using System.Threading.Tasks;
    using Demo.GenericFunctions.Helpers;
    using Demo.GenericFunctions.Services.Interfaces;
    using Microsoft.Extensions.Logging;
    using SendGrid;
    using SendGrid.Helpers.Mail;

    /// <summary>
    /// Sends the email using SendGrid.
    /// </summary>
    public class EmailSenderService : ISenderService<SendGridMessage>
    {
        private readonly SendGridClient _sendClient;
        private readonly ILogger<EmailSenderService> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmailSenderService"/> class.
        /// </summary>
        /// <param name="configurationHelper">Configuration helper.</param>
        /// <param name="logger">Logger.</param>
        public EmailSenderService(IConfigurationHelper configurationHelper, ILogger<EmailSenderService> logger)
        {
            _sendClient = new SendGridClient(configurationHelper.SendGridApiKey());
            _logger = logger;
        }

        /// <inheritdoc/>
        public async Task SendAsync(SendGridMessage message)
        {
            var result = await _sendClient.SendEmailAsync(message);
            if (result.StatusCode != HttpStatusCode.Accepted)
            {
                var errorResponse = await result.Body.ReadAsStringAsync();
                _logger.LogError($"Email was not sent. Error response: {errorResponse}");
            }
            else
            {
                _logger.LogInformation("Email was successfully sent.");
            }
        }
    }
}
