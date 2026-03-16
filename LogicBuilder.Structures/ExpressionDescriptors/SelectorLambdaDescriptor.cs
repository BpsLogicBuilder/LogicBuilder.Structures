using System;

namespace LogicBuilder.Expressions.Utils.ExpressionDescriptors
{
    public class SelectorLambdaDescriptor(DescriptorBase selector, string sourceElementType, string parameterName, string? bodyType = null) : DescriptorBase
    {
        public DescriptorBase Selector { get; set; } = selector;
        public string SourceElementType { get; set; } = sourceElementType;
        public string? BodyType { get; set; } = bodyType;
        public string ParameterName { get; set; } = parameterName;
    }
}