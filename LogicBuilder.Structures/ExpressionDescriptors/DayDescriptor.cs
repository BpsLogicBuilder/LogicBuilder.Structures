namespace LogicBuilder.Expressions.Utils.ExpressionDescriptors
{
    public class DayDescriptor(DescriptorBase operand) : DescriptorBase
    {
        public DescriptorBase Operand { get; set; } = operand;
    }
}