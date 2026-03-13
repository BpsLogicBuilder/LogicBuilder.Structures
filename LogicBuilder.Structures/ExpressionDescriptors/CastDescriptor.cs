using System;

namespace LogicBuilder.Expressions.Utils.ExpressionDescriptors
{
    public class CastDescriptor(DescriptorBase operand, string type) : DescriptorBase
    {
        public DescriptorBase Operand { get; set; } = operand;
        public string Type { get; set; } = type;
    }
}