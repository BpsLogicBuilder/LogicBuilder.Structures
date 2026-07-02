using System;

namespace LogicBuilder.Expressions.Utils.ExpressionDescriptors
{
    public class SelectorLambdaDescriptor(DescriptorBase selector, string sourceElementType, string parameterName, string? bodyType = null) : DescriptorBase
    {
        public DescriptorBase Selector { get; } = selector;
        public string SourceElementType { get; } = sourceElementType;
        public string? BodyType { get; } = bodyType;
        public string ParameterName { get; } = parameterName;
    }
}