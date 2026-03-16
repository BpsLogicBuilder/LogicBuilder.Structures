namespace LogicBuilder.Expressions.Utils.ExpressionDescriptors
{
    public class ConvertToNumericDateDescriptor(DescriptorBase sourceOperand) : DescriptorBase
    {
        public DescriptorBase SourceOperand { get; set; } = sourceOperand;
    }
}