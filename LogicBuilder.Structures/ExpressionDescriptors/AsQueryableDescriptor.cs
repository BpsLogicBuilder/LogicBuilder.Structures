namespace LogicBuilder.Expressions.Utils.ExpressionDescriptors
{
    public class AsQueryableDescriptor(DescriptorBase sourceOperand) : DescriptorBase
    {
        public DescriptorBase SourceOperand { get; set; } = sourceOperand;
    }
}