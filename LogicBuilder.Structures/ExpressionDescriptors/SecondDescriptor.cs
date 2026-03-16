namespace LogicBuilder.Expressions.Utils.ExpressionDescriptors
{
    public class SecondDescriptor(DescriptorBase operand) : DescriptorBase
    {
        public DescriptorBase Operand { get; set; } = operand;
    }
}