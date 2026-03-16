using System;

namespace LogicBuilder.Expressions.Utils.ExpressionDescriptors
{
    public class ConstantDescriptor(object constantValue, string? type = null) : DescriptorBase
    {
        public string? Type { get; set; } = type;
        public object ConstantValue { get; set; } = constantValue;
    }
}