namespace LogicBuilder.Expressions.Utils.ExpressionDescriptors
{
    public class TotalOffsetMinutesDescriptor(DescriptorBase operand) : DescriptorBase
    {
        public DescriptorBase Operand { get; set; } = operand;
    }
}