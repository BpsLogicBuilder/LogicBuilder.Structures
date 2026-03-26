namespace LogicBuilder.Expressions.Utils.ExpressionDescriptors
{
    public class AllDescriptor(DescriptorBase sourceOperand, DescriptorBase filterBody, string filterParameterName) : FilterMethodDescriptorBase(sourceOperand, filterBody, filterParameterName)
    {
        public override DescriptorBase FilterBody { get; } = filterBody;
        public override string FilterParameterName { get; } = filterParameterName;
    }
}