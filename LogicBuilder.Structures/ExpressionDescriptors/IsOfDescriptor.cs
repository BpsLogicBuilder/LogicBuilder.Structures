using System;

namespace LogicBuilder.Expressions.Utils.ExpressionDescriptors
{
    public class IsOfDescriptor(DescriptorBase operand, string type) : DescriptorBase
    {
        public DescriptorBase Operand { get; } = operand;
        public string Type { get; } = type;
    }
}