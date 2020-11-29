// <copyright file="EmailBuilderFactory.cs" company="Demo">
// Copyright (c) Demo. All rights reserved.
// </copyright>

namespace Demo.GenericFunctions.Builder.Factories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Demo.GenericFunctions.Models;

    /// <summary>
    /// A factory to create the concrete email.
    /// </summary>
    public class EmailBuilderFactory : IEmailBuilderFactory
    {
        private readonly Dictionary<EmailTypeEnum, EmailAbstract> _factories;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmailBuilderFactory"/> class.
        /// </summary>
        /// <param name="serviceProvider">The service provider to use.</param>
        public EmailBuilderFactory(IServiceProvider serviceProvider)
        {
            var emailTypes = (EmailAbstract[])serviceProvider.GetService(typeof(IEnumerable<EmailAbstract>));
            _factories = new Dictionary<EmailTypeEnum, EmailAbstract>();
            foreach (EmailTypeEnum emailType in Enum.GetValues(typeof(EmailTypeEnum)))
            {
                var type = Type.GetType($"Demo.GenericFunctions.Builder.{emailType}Email");
                var instance = emailTypes.FirstOrDefault(x => x.GetType() == type);
                if (instance == null)
                {
                    throw new ArgumentNullException($"The instance with {type} can not be null.");
                }

                _factories.Add(emailType, instance);
            }
        }

        /// <summary>
        /// Create an instance of IEmail.
        /// </summary>
        /// <param name="emailType">Email type.</param>
        /// <returns>The implementation of IEmail.</returns>
        public EmailAbstract Create(EmailTypeEnum emailType) => _factories[emailType];
    }
}
