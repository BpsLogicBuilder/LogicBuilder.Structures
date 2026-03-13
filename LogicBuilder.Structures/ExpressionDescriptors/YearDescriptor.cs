namespace LogicBuilder.Expressions.Utils.ExpressionDescriptors
{
    public class YearDescriptor(DescriptorBase operand) : DescriptorBase
    {
        public DescriptorBase Operand { get; set; } = operand;
    }
}