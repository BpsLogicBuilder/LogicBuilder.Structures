namespace LogicBuilder.Expressions.Utils.ExpressionDescriptors
{
    public class SubstringDescriptor(DescriptorBase sourceOperand, params DescriptorBase[] indexes) : DescriptorBase
    {
        public DescriptorBase SourceOperand { get; set; } = sourceOperand;
        public DescriptorBase[] Indexes { get; set; } = indexes;
    }
}