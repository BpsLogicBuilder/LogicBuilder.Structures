namespace LogicBuilder.Expressions.Utils.ExpressionDescriptors
{
    public class ConvertToNullableUnderlyingValueDescriptor(DescriptorBase sourceOperand) : DescriptorBase
    {
        public DescriptorBase SourceOperand { get; set; } = sourceOperand;
    }
}