using System;

namespace LogicBuilder.Expressions.Utils.ExpressionDescriptors
{
    public class EnumerableSelectorLambdaDescriptor(DescriptorBase selector, string sourceElementType, string parameterName) : DescriptorBase
    {
        public DescriptorBase Selector { get; set; } = selector;
        public string SourceElementType { get; set; } = sourceElementType;
        public string ParameterName { get; set; } = parameterName;
    }
}