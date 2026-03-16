namespace LogicBuilder.Expressions.Utils.ExpressionDescriptors
{
    public class ToLowerDescriptor(DescriptorBase operand) : DescriptorBase
    {
        public DescriptorBase Operand { get; set; } = operand;
    }
}