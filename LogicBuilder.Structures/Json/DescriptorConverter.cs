using LogicBuilder.Expressions.Utils.ExpressionDescriptors;

namespace LogicBuilder.Expressions.Utils.Json
{
    public class DescriptorConverter : JsonTypeConverter<DescriptorBase>
    {
        public override string TypePropertyName => nameof(DescriptorBase.TypeString);
    }
}
