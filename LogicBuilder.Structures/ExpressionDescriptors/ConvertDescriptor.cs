using System;

namespace LogicBuilder.Expressions.Utils.ExpressionDescriptors
{
    public class ConvertDescriptor(DescriptorBase sourceOperand, string type) : DescriptorBase
    {
        public string Type { get; set; } = type;
        public DescriptorBase SourceOperand { get; set; } = sourceOperand;
    }
}