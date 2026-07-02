using System;

namespace LogicBuilder.Expressions.Utils.ExpressionDescriptors
{
    public class FilterLambdaDescriptor(DescriptorBase filterBody, string sourceElementType, string parameterName) : DescriptorBase
    {
        public DescriptorBase FilterBody { get; } = filterBody;
        public string SourceElementType { get; } = sourceElementType;
        public string ParameterName { get; } = parameterName;
    }
}