// <copyright file="AbstractConverter.cs" company="Demo">
// Copyright (c) Demo. All rights reserved.
// </copyright>

namespace Demo.GenericFunctions.Helpers.Converters
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// The abstract convertor.
    /// </summary>
    /// <typeparam name="TReal">The generic type for real parameter.</typeparam>
    /// <typeparam name="TAbstract">The abstract type for real parameter.</typeparam>
    public class AbstractConverter<TReal, TAbstract> : JsonConverter
        where TReal : TAbstract
    {
        /// <inheritdoc/>
        public override bool CanConvert(Type objectType)
            => objectType == typeof(TAbstract);

        /// <inheritdoc/>
        public override object ReadJson(JsonReader reader, Type type, object value, JsonSerializer jser)
            => jser.Deserialize<TReal>(reader);

        /// <inheritdoc/>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer jser)
            => jser.Serialize(writer, value);
    }
}
