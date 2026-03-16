using System;

namespace LogicBuilder.Expressions.Utils.ExpressionDescriptors
{
    public class FilterLambdaDescriptor(DescriptorBase filterBody, string sourceElementType, string parameterName) : DescriptorBase
    {
        public DescriptorBase FilterBody { get; set; } = filterBody;
        public string SourceElementType { get; set; } = sourceElementType;
        public string ParameterName { get; set; } = parameterName;
    }
}