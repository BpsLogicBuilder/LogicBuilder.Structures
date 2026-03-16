namespace LogicBuilder.Expressions.Utils.ExpressionDescriptors
{
    public class MonthDescriptor(DescriptorBase operand) : DescriptorBase
    {
        public DescriptorBase Operand { get; set; } = operand;
    }
}