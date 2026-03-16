using System;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace LogicBuilder.Expressions.Utils.Json
{
    abstract public class JsonTypeConverter<T> : JsonConverter<T>
    {
        #region Properties
        abstract public string TypePropertyName { get; }
        #endregion Properties

        #region Methods
        public override bool CanConvert(Type typeToConvert)
            => typeToConvert == typeof(T);

        public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
                throw new JsonException();

            using var jsonDocument = JsonDocument.ParseValue(ref reader);
            JsonProperty typeJsonProperty = GetTypeJsonProperty();
            if (typeJsonProperty.Equals(default(JsonProperty)))
                throw new JsonException();

            JsonProperty GetTypeJsonProperty()
                => jsonDocument.RootElement.EnumerateObject().FirstOrDefault(e => e.Name.ToLowerInvariant() == TypePropertyName.ToLowerInvariant());

            return (T)JsonSerializer.Deserialize
            (
                jsonDocument.RootElement.GetRawText(),
                Type.GetType(typeJsonProperty.Value.GetString()) ?? throw new InvalidOperationException($"Type cannot be loaded for {typeJsonProperty.Value.GetString()}."),
                options
            )!;//never null because only valid JSON like "null" can return null.  For this method, the JsonTokenType is always JsonTokenType.StartObject.
        }

        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
            => JsonSerializer.Serialize(writer, value, value?.GetType() ?? throw new InvalidOperationException("Type cannot be null"), options);
        #endregion Methods
    }
}
