namespace LogicBuilder.Expressions.Utils.ExpressionDescriptors
{
    public class SelectManyDescriptor(DescriptorBase sourceOperand, DescriptorBase selectorBody, string selectorParameterName) : SelectorMethodDescriptorBase(sourceOperand, selectorBody, selectorParameterName)
    {
    }
}