namespace LogicBuilder.Expressions.Utils.ExpressionDescriptors
{
    public class NotDescriptor(DescriptorBase operand) : DescriptorBase
    {
        public DescriptorBase Operand { get; set; } = operand;
    }
}