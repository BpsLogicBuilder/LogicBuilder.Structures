using LogicBuilder.Expressions.Utils.Json;
using System.Text.Json;

namespace LogicBuilder.Structures.Tests.Helpers
{
    public static class SerializationOptions
    {
        private static readonly JsonSerializerOptions _default = CreateSerializationOptions();

        public static JsonSerializerOptions Default
        {
            get
            {
                return _default;
            }
        }

        static JsonSerializerOptions CreateSerializationOptions()
        {
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            options.Converters.Add(new DescriptorConverter());
            options.Converters.Add(new ObjectConverter());
            options.Converters.Add(new ScreenSettingsConverter());
            return options;
        }
    }
}
