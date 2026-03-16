namespace LogicBuilder.Expressions.Utils.ExpressionDescriptors
{
    abstract public class SelectorMethodDescriptorBase(DescriptorBase sourceOperand, DescriptorBase? selectorBody = null, string? selectorParameterName = null) : DescriptorBase
    {
        public DescriptorBase SourceOperand { get; set; } = sourceOperand;
        public DescriptorBase? SelectorBody { get; set; } = selectorBody;
        public string? SelectorParameterName { get; set; } = selectorParameterName;
    }
}