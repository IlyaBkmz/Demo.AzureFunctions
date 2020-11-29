// <copyright file="EmailTypeFactory.cs" company="Demo">
// Copyright (c) Demo. All rights reserved.
// </copyright>

namespace Demo.GenericFunctions.Helpers.Type
{
    using System;
    using System.Collections.Generic;
    using Demo.GenericFunctions.Models;

    /// <summary>
    /// Class describes email type factory.
    /// </summary>
    public class EmailTypeFactory
    {
        private readonly Dictionary<EmailTypeEnum, IEmail> _factories;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmailTypeFactory"/> class.
        /// </summary>
        public EmailTypeFactory()
        {
            _factories = new Dictionary<EmailTypeEnum, IEmail>();
            foreach (EmailTypeEnum emailType in Enum.GetValues(typeof(EmailTypeEnum)))
            {
                var type = Type.GetType($"Demo.GenericFunctions.Models.{emailType}EmailModel");
                var factory = (IEmail)Activator.CreateInstance(type);
                _factories.Add(emailType, factory);
            }
        }

        /// <summary>
        /// Create an instance of IEmail.
        /// </summary>
        /// <param name="emailType">Email type.</param>
        /// <returns>The implementation of IEmail.</returns>
        public IEmail Create(EmailTypeEnum emailType) => _factories[emailType];
    }
}
