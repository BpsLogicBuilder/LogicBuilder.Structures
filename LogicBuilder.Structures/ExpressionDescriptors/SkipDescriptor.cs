namespace LogicBuilder.Expressions.Utils.ExpressionDescriptors
{
    public class SkipDescriptor(DescriptorBase sourceOperand, int count) : DescriptorBase
    {
        public DescriptorBase SourceOperand { get; set; } = sourceOperand;
        public int Count { get; set; } = count;
    }
}