// <copyright file="IEmailBuilderFactory.cs" company="Demo">
// Copyright (c) Demo. All rights reserved.
// </copyright>

namespace Demo.GenericFunctions.Builder.Factories
{
    using Demo.GenericFunctions.Models;

    /// <summary>
    /// Contains the interface to create the different email types.
    /// </summary>
    public interface IEmailBuilderFactory
    {
        /// <summary>
        /// Creates the email letter of needed type.
        /// </summary>
        /// <param name="emailType">The type of email to create.</param>
        /// <returns>The needed email.</returns>
        EmailAbstract Create(EmailTypeEnum emailType);
    }
}
