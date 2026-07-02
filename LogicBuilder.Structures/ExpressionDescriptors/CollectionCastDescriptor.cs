namespace LogicBuilder.Expressions.Utils.ExpressionDescriptors
{
    public class CollectionCastDescriptor(DescriptorBase operand, string type) : DescriptorBase
    {
        public DescriptorBase Operand { get; } = operand;
        public string Type { get; } = type;
    }
}