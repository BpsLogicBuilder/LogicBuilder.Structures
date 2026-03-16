namespace LogicBuilder.Expressions.Utils.ExpressionDescriptors
{
    public class ConvertToStringDescriptor(DescriptorBase sourceOperand) : DescriptorBase
    {
        public DescriptorBase SourceOperand { get; set; } = sourceOperand;
    }
}