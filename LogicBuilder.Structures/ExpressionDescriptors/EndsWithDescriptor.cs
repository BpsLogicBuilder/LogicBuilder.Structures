namespace LogicBuilder.Expressions.Utils.ExpressionDescriptors
{
    public class EndsWithDescriptor(DescriptorBase left, DescriptorBase right) : DescriptorBase
    {
        public DescriptorBase Left { get; } = left;
        public DescriptorBase Right { get; } = right;
    }
}