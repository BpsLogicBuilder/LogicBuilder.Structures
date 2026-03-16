namespace LogicBuilder.Expressions.Utils.ExpressionDescriptors
{
    public class TimeDescriptor(DescriptorBase operand) : DescriptorBase
    {
        public DescriptorBase Operand { get; set; } = operand;
    }
}