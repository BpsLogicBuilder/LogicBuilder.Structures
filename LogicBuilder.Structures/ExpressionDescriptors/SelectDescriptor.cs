namespace LogicBuilder.Expressions.Utils.ExpressionDescriptors
{
    public class SelectDescriptor(DescriptorBase sourceOperand, DescriptorBase selectorBody, string selectorParameterName) : SelectorMethodDescriptorBase(sourceOperand, selectorBody, selectorParameterName)
    {
    }
}