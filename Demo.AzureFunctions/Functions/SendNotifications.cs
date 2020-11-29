// <copyright file="SendNotifications.cs" company="Demo">
// Copyright (c) Demo. All rights reserved.
// </copyright>

namespace Demo.GenericFunctions.Functions
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using Demo.GenericFunctions.Helpers;
    using Demo.GenericFunctions.Services.QueueService.Factories;
    using Demo.GenericFunctions.Validators.RequestModelValidators.Factories;
    using Demo.Nuget.Exceptions;
    using Demo.Nuget.Functions;
    using Demo.Nuget.Models;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Extensions.Http;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// Contains <see cref="SendNotifications"></see> function.
    /// </summary>
    public class SendNotifications : BaseFunction
    {
        private readonly INotificationRequestParser _notificationRequestParser;
        private readonly INotificationTypeFactory _notificationTypeFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="SendNotifications"/> class.
        /// </summary>
        /// <param name="notificationRequestParser">Notification request parser.</param>
        /// <param name="notificationTypeFactory">Notification type factory service.</param>
        public SendNotifications(
            INotificationRequestParser notificationRequestParser,
            INotificationTypeFactory notificationTypeFactory)
        {
            _notificationRequestParser = notificationRequestParser;
            _notificationTypeFactory = notificationTypeFactory;
        }

        /// <summary>
        /// Sends notifications from http request to the appropriate queue.
        /// </summary>
        /// <param name="req">The request to process.</param>
        /// <param name="logger">The logger to log info.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        [FunctionName("SendNotifications")]
        public async Task<IActionResult> RunAsync(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "notification")] HttpRequest req,
            ILogger logger)
        {
            try
            {
                logger.LogInformation($"{nameof(SendNotifications)} function starts.");

                var stream = new StreamReader(req.Body);
                stream.BaseStream.Seek(0, SeekOrigin.Begin);
                var body = await stream.ReadToEndAsync();

                logger.LogInformation($"Request Body: {body}.");

                var notificationRequestModel = _notificationRequestParser.Parse(body);

                var modelState = ModelValidator
                    .InitializeFactories()
                    .ExecuteCreation(notificationRequestModel.NotificationType, notificationRequestModel.NotificationContent)
                    .Validate();

                if (!modelState.IsValid)
                {
                    return new BadRequestObjectResult(new ErrorModel
                    {
                        ErrorMessage = $"{string.Join(" ", modelState.ModelValidationResult.Select(s => s.ErrorMessage))}"
                    });
                }

                await _notificationTypeFactory
                       .Create(notificationRequestModel.NotificationType)
                       .SendAsync(notificationRequestModel.NotificationContent);

                logger.LogInformation($"{nameof(SendNotifications)} function ends.");

                return new OkResult();
            }
            catch (DemoException ex)
            {
                logger.LogError($"{nameof(SendNotifications)} function responded: {ex.Error.ErrorMessage}");
                return ReturnIActionErrorResponse(ex.Error.ErrorMessage, ex.StatusCode);
            }
            catch (Exception ex)
            {
                return ReturnIActionErrorResponse(ex.Message, HttpStatusCode.InternalServerError);
            }
        }
    }
}
