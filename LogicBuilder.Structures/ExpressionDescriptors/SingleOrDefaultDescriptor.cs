namespace LogicBuilder.Expressions.Utils.ExpressionDescriptors
{
    public class SingleOrDefaultDescriptor(DescriptorBase sourceOperand, DescriptorBase? filterBody = null, string? filterParameterName = null) : FilterMethodDescriptorBase(sourceOperand, filterBody, filterParameterName)
    {
    }
}