namespace LogicBuilder.Expressions.Utils.ExpressionDescriptors
{
    public class WhereDescriptor(DescriptorBase sourceOperand, DescriptorBase filterBody, string filterParameterName) : FilterMethodDescriptorBase(sourceOperand, filterBody, filterParameterName)
    {
    }
}