// <copyright file="SmsSenderService.cs" company="Demo">
// Copyright (c) Demo. All rights reserved.
// </copyright>

namespace Demo.GenericFunctions.Services
{
    using System.Threading.Tasks;
    using Demo.GenericFunctions.ModelDtos;
    using Demo.GenericFunctions.Services.Interfaces;

    /// <summary>
    /// Sends sms using Mille Mercis service.
    /// </summary>
    public class SmsSenderService : ISenderService<SmsDto>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SmsSenderService"/> class.
        /// </summary>
        public SmsSenderService()
        {
        }

        /// <inheritdoc/>
        public async Task SendAsync(SmsDto item)
        {
            // Logic to send sms.
        }
    }
}
