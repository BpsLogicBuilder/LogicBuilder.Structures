namespace LogicBuilder.Expressions.Utils.ExpressionDescriptors
{
    abstract public class FilterMethodDescriptorBase(DescriptorBase sourceOperand, DescriptorBase? filterBody = null, string? filterParameterName = null) : DescriptorBase
    {
        public DescriptorBase SourceOperand { get; } = sourceOperand;
        public virtual DescriptorBase? FilterBody { get; } = filterBody;
        public virtual string? FilterParameterName { get; } = filterParameterName;
    }
}