namespace LogicBuilder.Expressions.Utils.ExpressionDescriptors
{
    abstract public class SelectorMethodDescriptorBase(DescriptorBase sourceOperand, DescriptorBase? selectorBody = null, string? selectorParameterName = null) : DescriptorBase
    {
        public DescriptorBase SourceOperand { get; } = sourceOperand;
        public virtual DescriptorBase? SelectorBody { get; } = selectorBody;
        public virtual string? SelectorParameterName { get; } = selectorParameterName;
    }
}