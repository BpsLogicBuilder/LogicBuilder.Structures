using LogicBuilder.Expressions.Utils.Json;
using System;
using System.Linq;
using System.Reflection;

namespace LogicBuilder.Structures.Tests
{
    public class ScreenSettingsConverter : JsonTypeConverter<ScreenSettingsBase>
    {
        /// <summary>
        /// Allows only the descriptors defined in LogicBuilder.Structures.
        /// Used when the converter is applied through the <see cref="System.Text.Json.Serialization.JsonConverterAttribute"/> on <see cref="ScreenSettingsBase"/>.
        /// </summary>
        public ScreenSettingsConverter()
        {
        }

        /// <summary>
        /// Allows the descriptors defined in LogicBuilder.Structures plus concrete <see cref="ScreenSettingsBase"/> subtypes defined in <paramref name="additionalAssemblies"/>.
        /// Register with <see cref="System.Text.Json.JsonSerializerOptions.Converters"/> - converters added to the options take precedence over the attribute on <see cref="ScreenSettingsBase"/>.
        /// </summary>
        public ScreenSettingsConverter(params Assembly[] additionalAssemblies)
            : base(new[] { typeof(ScreenSettingsBase).Assembly }.Concat(additionalAssemblies ?? []))
        {
        }

        public ScreenSettingsConverter(params Type[] types)
                : base(types)
        {
        }

        public override string TypePropertyName => nameof(ScreenSettingsBase.TypeString);
    }
}
