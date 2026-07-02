using System;

namespace LogicBuilder.Expressions.Utils.ExpressionDescriptors
{
    public class ConvertDescriptor(DescriptorBase sourceOperand, string type) : DescriptorBase
    {
        public string Type { get; } = type;
        public DescriptorBase SourceOperand { get; } = sourceOperand;
    }
}