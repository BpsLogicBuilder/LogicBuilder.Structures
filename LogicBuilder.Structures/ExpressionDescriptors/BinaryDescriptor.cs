namespace LogicBuilder.Expressions.Utils.ExpressionDescriptors
{
    abstract public class BinaryDescriptor(DescriptorBase left, DescriptorBase right) : DescriptorBase
    {
        public DescriptorBase Left { get; set; } = left;
        public DescriptorBase Right { get; set; } = right;
    }
}