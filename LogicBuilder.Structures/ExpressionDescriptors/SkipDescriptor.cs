namespace LogicBuilder.Expressions.Utils.ExpressionDescriptors
{
    public class SkipDescriptor(DescriptorBase sourceOperand, int count) : DescriptorBase
    {
        public DescriptorBase SourceOperand { get; } = sourceOperand;
        public int Count { get; } = count;
    }
}