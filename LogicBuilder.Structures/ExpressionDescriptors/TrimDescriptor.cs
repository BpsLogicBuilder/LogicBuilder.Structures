namespace LogicBuilder.Expressions.Utils.ExpressionDescriptors
{
    public class TrimDescriptor(DescriptorBase operand) : DescriptorBase
    {
        public DescriptorBase Operand { get; set; } = operand;
    }
}