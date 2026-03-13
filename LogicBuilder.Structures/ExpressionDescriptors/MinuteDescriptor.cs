namespace LogicBuilder.Expressions.Utils.ExpressionDescriptors
{
    public class MinuteDescriptor(DescriptorBase operand) : DescriptorBase
    {
        public DescriptorBase Operand { get; set; } = operand;
    }
}