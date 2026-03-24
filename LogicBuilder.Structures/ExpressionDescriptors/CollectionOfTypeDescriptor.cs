namespace LogicBuilder.Expressions.Utils.ExpressionDescriptors
{
    public class CollectionOfTypeDescriptor(DescriptorBase operand, string type) : DescriptorBase
    {
        public DescriptorBase Operand { get; set; } = operand;
        public string Type { get; set; } = type;
    }
}
