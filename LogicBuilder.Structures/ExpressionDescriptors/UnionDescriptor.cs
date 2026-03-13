namespace LogicBuilder.Expressions.Utils.ExpressionDescriptors
{
    public class UnionDescriptor(DescriptorBase left, DescriptorBase right) : DescriptorBase
    {
        public DescriptorBase Left { get; set; } = left;
        public DescriptorBase Right { get; set; } = right;
    }
}
