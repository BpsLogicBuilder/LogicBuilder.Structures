using LogicBuilder.Expressions.Utils.Json;
using System.Text.Json;

namespace LogicBuilder.Structures.Tests.Helpers
{
    public static class SerializationOptions
    {
        private static JsonSerializerOptions? _default;
        public static JsonSerializerOptions Default
        {
            get
            {
                if (_default != null)
                    return _default;

                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

                options.Converters.Add(new DescriptorConverter());
                options.Converters.Add(new ObjectConverter());

                _default = options;

                return _default;
            }
        }
    }
}
