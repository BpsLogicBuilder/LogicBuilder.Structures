namespace LogicBuilder.Expressions.Utils.ExpressionDescriptors
{
    public class HourDescriptor(DescriptorBase operand) : DescriptorBase
    {
        public DescriptorBase Operand { get; set; } = operand;
    }
}