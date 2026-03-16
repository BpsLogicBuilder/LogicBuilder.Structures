using LogicBuilder.Expressions.Utils.ExpressionDescriptors;

namespace LogicBuilder.Expressions.Utils.ExpansionDescriptors
{
    public class SelectExpandItemFilterDescriptor(FilterLambdaDescriptor filterLambdaOperator)
    {
        public FilterLambdaDescriptor FilterLambdaOperator { get; set; } = filterLambdaOperator;
    }
}
