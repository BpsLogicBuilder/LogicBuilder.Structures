using LogicBuilder.Expressions.Utils.ExpressionDescriptors;
using System.Linq;
using System.Reflection;

namespace LogicBuilder.Expressions.Utils.Json
{
    public class DescriptorConverter : JsonTypeConverter<DescriptorBase>
    {
        /// <summary>
        /// Allows only the descriptors defined in LogicBuilder.Structures.
        /// Used when the converter is applied through the <see cref="System.Text.Json.Serialization.JsonConverterAttribute"/> on <see cref="DescriptorBase"/>.
        /// </summary>
        public DescriptorConverter()
        {
        }

        /// <summary>
        /// Allows the descriptors defined in LogicBuilder.Structures plus concrete <see cref="DescriptorBase"/> subtypes defined in <paramref name="additionalAssemblies"/>.
        /// Register with <see cref="System.Text.Json.JsonSerializerOptions.Converters"/> - converters added to the options take precedence over the attribute on <see cref="DescriptorBase"/>.
        /// </summary>
        public DescriptorConverter(params Assembly[] additionalAssemblies)
            : base(new[] { typeof(DescriptorBase).Assembly }.Concat(additionalAssemblies ?? []))
        {
        }

        public override string TypePropertyName => nameof(DescriptorBase.TypeString);
    }
}
