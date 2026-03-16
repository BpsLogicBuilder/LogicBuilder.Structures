namespace LogicBuilder.Expressions.Utils.ExpressionDescriptors
{
    public class AnyDescriptor(DescriptorBase sourceOperand, DescriptorBase? filterBody = null, string? filterParameterName = null) : FilterMethodDescriptorBase(sourceOperand, filterBody, filterParameterName)
    {
    }
}