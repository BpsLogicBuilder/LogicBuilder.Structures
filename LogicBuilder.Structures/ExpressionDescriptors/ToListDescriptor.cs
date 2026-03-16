namespace LogicBuilder.Expressions.Utils.ExpressionDescriptors
{
    public class ToListDescriptor(DescriptorBase sourceOperand) : DescriptorBase
    {
        public DescriptorBase SourceOperand { get; set; } = sourceOperand;
    }
}