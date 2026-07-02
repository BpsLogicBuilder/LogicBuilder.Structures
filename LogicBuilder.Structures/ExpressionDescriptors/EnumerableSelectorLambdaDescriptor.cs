using System;

namespace LogicBuilder.Expressions.Utils.ExpressionDescriptors
{
    public class EnumerableSelectorLambdaDescriptor(DescriptorBase selector, string sourceElementType, string parameterName) : DescriptorBase
    {
        public DescriptorBase Selector { get; } = selector;
        public string SourceElementType { get; } = sourceElementType;
        public string ParameterName { get; } = parameterName;
    }
}