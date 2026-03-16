namespace LogicBuilder.Expressions.Utils.ExpressionDescriptors
{
    public class DistinctDescriptor(DescriptorBase sourceOperand) : DescriptorBase
    {
        public DescriptorBase SourceOperand { get; set; } = sourceOperand;
    }
}