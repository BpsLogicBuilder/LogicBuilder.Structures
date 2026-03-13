namespace LogicBuilder.Expressions.Utils.ExpressionDescriptors
{
    public class NegateDescriptor(DescriptorBase operand) : DescriptorBase
    {
        public DescriptorBase Operand { get; set; } = operand;
    }
}