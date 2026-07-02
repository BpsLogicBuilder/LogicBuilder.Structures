using System;

namespace LogicBuilder.Expressions.Utils.ExpressionDescriptors
{
    public class ConstantDescriptor(object? constantValue, string? type = null) : DescriptorBase
    {
        public string? Type { get; } = type;
        public object? ConstantValue { get; } = constantValue;
    }
}