namespace LogicBuilder.Expressions.Utils.ExpressionDescriptors
{
    public class FirstOrDefaultDescriptor(DescriptorBase sourceOperand, DescriptorBase? filterBody = null, string? filterParameterName = null) : FilterMethodDescriptorBase(sourceOperand, filterBody, filterParameterName)
    {
    }
}