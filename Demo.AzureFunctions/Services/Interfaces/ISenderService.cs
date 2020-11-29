// <copyright file="ISenderService.cs" company="Demo">
// Copyright (c) Demo. All rights reserved.
// </copyright>

namespace Demo.GenericFunctions.Services.Interfaces
{
    using System.Threading.Tasks;

    /// <summary>
    /// An interface, that contains method to send messages.
    /// </summary>
    /// <typeparam name="T">The type of message to send.</typeparam>
    public interface ISenderService<T>
    {
        /// <summary>
        /// Sends item.
        /// </summary>
        /// <param name="item">The item to send.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        Task SendAsync(T item);
    }
}
