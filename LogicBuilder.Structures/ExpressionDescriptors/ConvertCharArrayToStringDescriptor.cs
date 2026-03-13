namespace LogicBuilder.Expressions.Utils.ExpressionDescriptors
{
    public class ConvertCharArrayToStringDescriptor(DescriptorBase sourceOperand) : DescriptorBase
    {
        public DescriptorBase SourceOperand { get; set; } = sourceOperand;
    }
}