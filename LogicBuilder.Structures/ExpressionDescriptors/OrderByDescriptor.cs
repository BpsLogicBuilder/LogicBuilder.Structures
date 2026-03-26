using LogicBuilder.Expressions.Utils.Strutures;

namespace LogicBuilder.Expressions.Utils.ExpressionDescriptors
{
    public class OrderByDescriptor(DescriptorBase sourceOperand, DescriptorBase selectorBody, ListSortDirection sortDirection, string selectorParameterName) : SelectorMethodDescriptorBase(sourceOperand, selectorBody, selectorParameterName)
    {
        public ListSortDirection SortDirection { get; } = sortDirection;
        public override DescriptorBase SelectorBody { get; } = selectorBody;
        public override string SelectorParameterName { get; } = selectorParameterName;
    }
}