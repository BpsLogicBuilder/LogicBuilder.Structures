namespace LogicBuilder.Expressions.Utils.ExpressionDescriptors
{
    public class ExceptDescriptor(DescriptorBase left, DescriptorBase right) : DescriptorBase
    {
        public DescriptorBase Left { get; } = left;
        public DescriptorBase Right { get; } = right;
    }
}
