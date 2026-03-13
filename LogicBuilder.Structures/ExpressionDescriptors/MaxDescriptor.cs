namespace LogicBuilder.Expressions.Utils.ExpressionDescriptors
{
    public class MaxDescriptor(DescriptorBase sourceOperand, DescriptorBase? selectorBody = null, string? selectorParameterName = null) : SelectorMethodDescriptorBase(sourceOperand, selectorBody, selectorParameterName)
    {
    }
}