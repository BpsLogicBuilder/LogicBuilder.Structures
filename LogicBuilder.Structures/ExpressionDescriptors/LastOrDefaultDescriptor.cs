namespace LogicBuilder.Expressions.Utils.ExpressionDescriptors
{
    public class LastOrDefaultDescriptor(DescriptorBase sourceOperand, DescriptorBase? filterBody = null, string? filterParameterName = null) : FilterMethodDescriptorBase(sourceOperand, filterBody, filterParameterName)
    {
    }
}