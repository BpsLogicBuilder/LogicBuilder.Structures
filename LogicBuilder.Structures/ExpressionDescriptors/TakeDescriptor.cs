namespace LogicBuilder.Expressions.Utils.ExpressionDescriptors
{
    public class TakeDescriptor(DescriptorBase sourceOperand, int count) : DescriptorBase
    {
        public DescriptorBase SourceOperand { get; set; } = sourceOperand;
        public int Count { get; set; } = count;
    }
}