namespace LogicBuilder.Expressions.Utils.ExpressionDescriptors
{
    public class FloorDescriptor(DescriptorBase operand) : DescriptorBase
    {
        public DescriptorBase Operand { get; set; } = operand;
    }
}