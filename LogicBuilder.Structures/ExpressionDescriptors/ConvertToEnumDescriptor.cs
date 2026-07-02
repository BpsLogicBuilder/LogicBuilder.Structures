namespace LogicBuilder.Expressions.Utils.ExpressionDescriptors
{
    public class ConvertToEnumDescriptor(object? constantValue, string type) : DescriptorBase
    {
        public string Type { get; } = type;
        public object? ConstantValue { get; } = constantValue;
    }
}