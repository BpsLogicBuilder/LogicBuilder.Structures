namespace LogicBuilder.Expressions.Utils.ExpressionDescriptors
{
    public class CustomMethodDescriptor(string declaringType, string methodName, string[] parameterTypeNames, DescriptorBase[] args) : DescriptorBase
    {
        public string DeclaringType { get; } = declaringType;
        public string MethodName { get; } = methodName;
        public string[] ParameterTypeNames { get; } = parameterTypeNames;
        public DescriptorBase[] Args { get; } = args;
    }
}