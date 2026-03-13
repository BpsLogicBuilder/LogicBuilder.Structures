namespace LogicBuilder.Expressions.Utils.ExpressionDescriptors
{
    public class TotalSecondsDescriptor(DescriptorBase operand) : DescriptorBase
    {
        public DescriptorBase Operand { get; set; } = operand;
    }
}