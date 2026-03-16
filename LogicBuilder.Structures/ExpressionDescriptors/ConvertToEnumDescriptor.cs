using System;

namespace LogicBuilder.Expressions.Utils.ExpressionDescriptors
{
    public class ConvertToEnumDescriptor(object constantValue, string type) : DescriptorBase
    {
        public string Type { get; set; } = type;
        public object ConstantValue { get; set; } = constantValue;
    }
}