// <copyright file="Startup.cs" company="Demo">
// Copyright (c) Demo. All rights reserved.
// </copyright>

[assembly: Microsoft.Azure.Functions.Extensions.DependencyInjection.FunctionsStartup(typeof(Demo.GenericFunctions.Startup))]

namespace Demo.GenericFunctions
{
    using System;
    using Demo.GenericFunctions.Builder;
    using Demo.GenericFunctions.Builder.Factories;
    using Demo.GenericFunctions.Helpers;
    using Demo.GenericFunctions.ModelDtos;
    using Demo.GenericFunctions.Services;
    using Demo.GenericFunctions.Services.Interfaces;
    using Demo.GenericFunctions.Services.QueueService;
    using Demo.GenericFunctions.Services.QueueService.Contracts;
    using Demo.GenericFunctions.Services.QueueService.Factories;
    using Demo.Nuget.Services;
    using Microsoft.Azure.Functions.Extensions.DependencyInjection;
    using Microsoft.Extensions.DependencyInjection;
    using SendGrid.Helpers.Mail;

    /// <summary>
    /// Contains configuration method to register services.
    /// </summary>
    internal class Startup : FunctionsStartup
    {
        /// <inheritdoc/>
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddLogging();

            builder.Services.Configure<ServiceBusOptions>(opts =>
            {
                opts.ConnectionString = Environment.GetEnvironmentVariable("ServiceBusConnection");
                opts.ListenConnectionString = Environment.GetEnvironmentVariable("ServiceBusConnection");
                opts.TimeToLive = 350;
            });

            builder.Services.AddServiceBusHelper();

            builder.Services.AddTransient<IConfigurationHelper, ConfigurationHelper>();

            builder.Services.AddTransient<ISenderService<SmsDto>, SmsSenderService>();
            builder.Services.AddTransient<ISenderService<SendGridMessage>, EmailSenderService>();

            builder.Services.AddTransient<INotificator, SmsNotificator>();
            builder.Services.AddTransient<INotificator, EmailNotificator>();
            builder.Services.AddTransient<INotificationRequestParser, NotificationRequestParser>();
            builder.Services.AddTransient<INotificationTypeFactory, NotificationTypeFactory>();

            builder.Services.AddTransient<IEmailBuilderFactory, EmailBuilderFactory>();
            builder.Services.AddTransient<EmailAbstract, AccountConfirmationEmail>();
            builder.Services.AddTransient<EmailAbstract, PersonalInfoModificationEmail>();
            builder.Services.AddTransient<EmailAbstract, AccountActivationEmail>();
            builder.Services.AddTransient<EmailAbstract, PasswordChangedEmail>();
        }
    }
}
