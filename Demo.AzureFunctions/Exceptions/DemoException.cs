// <copyright file="DemoException.cs" company="Demo">
// Copyright (c) Demo. All rights reserved.
// </copyright>

namespace Demo.Nuget.Exceptions
{
    using System;
    using System.Net;
    using Demo.Nuget.Models;

    /// <summary>
    /// Describes custom Exception.
    /// </summary>
    public class DemoException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DemoException"/> class.
        /// </summary>
        /// <param name="errorMessage">The error message.</param>
        /// <param name="statusCode">The http status code.</param>
        public DemoException(string errorMessage, HttpStatusCode statusCode)
            : base(errorMessage)
        {
            Error = new ErrorModel { ErrorMessage = errorMessage };
            StatusCode = statusCode;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DemoException"/> class.
        /// </summary>
        /// <param name="error">The error message.</param>
        /// <param name="statusCode">The http status code.</param>
        public DemoException(ErrorModel error, HttpStatusCode statusCode)
            : base(error.ErrorMessage)
        {
            Error = error;
            StatusCode = statusCode;
        }

        /// <summary>
        /// Gets or sets an error message.
        /// </summary>
        public ErrorModel Error { get; protected set; }

        /// <summary>
        /// Gets a http status code.
        /// </summary>
        public HttpStatusCode StatusCode { get; }
    }
}
