namespace LogicBuilder.Expressions.Utils.ExpressionDescriptors
{
    public class FractionalSecondsDescriptor(DescriptorBase operand) : DescriptorBase
    {
        public DescriptorBase Operand { get; set; } = operand;
    }
}