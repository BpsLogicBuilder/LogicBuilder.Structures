namespace LogicBuilder.Expressions.Utils.ExpressionDescriptors
{
    public class GroupByDescriptor(DescriptorBase sourceOperand, DescriptorBase selectorBody, string selectorParameterName) : SelectorMethodDescriptorBase(sourceOperand, selectorBody, selectorParameterName)
    {
        public override DescriptorBase SelectorBody { get; } = selectorBody;
        public override string SelectorParameterName { get; } = selectorParameterName;
    }
}