namespace LogicBuilder.Expressions.Utils.ExpressionDescriptors
{
    public class AllDescriptor(DescriptorBase sourceOperand, DescriptorBase? filterBody = null, string? filterParameterName = null) : FilterMethodDescriptorBase(sourceOperand, filterBody, filterParameterName)
    {
    }
}