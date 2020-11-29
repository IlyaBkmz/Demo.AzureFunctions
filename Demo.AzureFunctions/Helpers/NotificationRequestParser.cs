// <copyright file="NotificationRequestParser.cs" company="Demo">
// Copyright (c) Demo. All rights reserved.
// </copyright>

namespace Demo.GenericFunctions.Helpers
{
    using System;
    using System.Net;
    using Demo.GenericFunctions.Helpers.Type;
    using Demo.GenericFunctions.Models.Enums;
    using Demo.GenericFunctions.RequestModels;
    using Demo.Nuget.Constants;
    using Demo.Nuget.Exceptions;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Notification request parser.
    /// </summary>
    public class NotificationRequestParser : INotificationRequestParser
    {
        /// <inheritdoc/>
        public NotificationRequestModel Parse(string body)
        {
            if (string.IsNullOrEmpty(body))
            {
                throw new DemoException(ErrorMessageConstants.RequestModelNullMessage, HttpStatusCode.BadRequest);
            }

            var notificationTypeAsStr = JObject.Parse(body).Value<string>("notificationType");
            if (notificationTypeAsStr == null || (!Enum.IsDefined(typeof(NotificationTypeEnum), notificationTypeAsStr)))
            {
                throw new DemoException(
                    $"The '{nameof(NotificationRequestModel.NotificationType)}' field is invalid.",
                    HttpStatusCode.BadRequest);
            }

            var notificationType = (NotificationTypeEnum)Enum.Parse(typeof(NotificationTypeEnum), notificationTypeAsStr);
            var converter = new NotificationContentTypeFactory()
                .Create(notificationType)
                .GetConverter();

            var settings = new JsonSerializerSettings { Converters = { converter } };
            var notificationRequestModel = JsonConvert.DeserializeObject<NotificationRequestModel>(body, settings);
            if (notificationRequestModel.NotificationContent == null)
            {
                throw new DemoException(
                    $"The '{nameof(NotificationRequestModel.NotificationContent)}' field is invalid.",
                    HttpStatusCode.BadRequest);
            }

            return notificationRequestModel;
        }
    }
}
