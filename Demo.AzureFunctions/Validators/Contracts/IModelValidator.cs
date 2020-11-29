// <copyright file="IModelValidator.cs" company="Demo">
// Copyright (c) Demo. All rights reserved.
// </copyright>

namespace Demo.GenericFunctions.Validators.Contracts
{
    using Demo.Nuget.Models;

    /// <summary>
    /// An interface for model validation.
    /// </summary>
    public interface IModelValidator
    {
        /// <summary>
        /// Validates the model.
        /// </summary>
        /// <returns>A model state..</returns>
        ModelState Validate();
    }
}
