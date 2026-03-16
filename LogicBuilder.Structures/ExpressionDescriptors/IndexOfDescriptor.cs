namespace LogicBuilder.Expressions.Utils.ExpressionDescriptors
{
    public class IndexOfDescriptor(DescriptorBase sourceOperand, DescriptorBase itemToFind) : DescriptorBase
    {
        public DescriptorBase SourceOperand { get; set; } = sourceOperand;
        public DescriptorBase ItemToFind { get; set; } = itemToFind;
    }
}