using LogicBuilder.Expressions.Utils.Json;
using System.Text.Json.Serialization;

namespace LogicBuilder.Expressions.Utils.ExpressionDescriptors
{
    [JsonConverter(typeof(DescriptorConverter))]
    public abstract class DescriptorBase : IExpressionDescriptor
    {
        public string TypeString => this.GetType().AssemblyQualifiedName;
    }
}
