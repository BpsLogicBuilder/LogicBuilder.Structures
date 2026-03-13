namespace LogicBuilder.Expressions.Utils.ExpressionDescriptors
{
    public class DateDescriptor(DescriptorBase operand) : DescriptorBase
    {
        public DescriptorBase Operand { get; set; } = operand;
    }
}