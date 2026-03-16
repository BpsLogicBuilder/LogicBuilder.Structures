namespace LogicBuilder.Expressions.Utils.ExpressionDescriptors
{
    abstract public class FilterMethodDescriptorBase(DescriptorBase sourceOperand, DescriptorBase? filterBody = null, string? filterParameterName = null) : DescriptorBase
    {
        public DescriptorBase SourceOperand { get; set; } = sourceOperand;
        public DescriptorBase? FilterBody { get; set; } = filterBody;
        public string? FilterParameterName { get; set; } = filterParameterName;
    }
}