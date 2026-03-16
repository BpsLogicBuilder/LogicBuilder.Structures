namespace LogicBuilder.Expressions.Utils.ExpressionDescriptors
{
	public class AsEnumerableDescriptor(DescriptorBase sourceOperand) : DescriptorBase
	{
        public DescriptorBase SourceOperand { get; set; } = sourceOperand;
    }
}