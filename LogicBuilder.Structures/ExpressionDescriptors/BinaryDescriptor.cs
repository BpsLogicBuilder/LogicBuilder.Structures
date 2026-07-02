namespace LogicBuilder.Expressions.Utils.ExpressionDescriptors
{
    abstract public class BinaryDescriptor(DescriptorBase left, DescriptorBase right) : DescriptorBase
    {
        public DescriptorBase Left { get; } = left;
        public DescriptorBase Right { get; } = right;
    }
}