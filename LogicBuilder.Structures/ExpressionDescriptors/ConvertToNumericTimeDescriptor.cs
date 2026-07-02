namespace LogicBuilder.Expressions.Utils.ExpressionDescriptors
{
    public class ConvertToNumericTimeDescriptor(DescriptorBase sourceOperand) : DescriptorBase
    {
        public DescriptorBase SourceOperand { get; } = sourceOperand;
    }
}