namespace LogicBuilder.Expressions.Utils.ExpressionDescriptors
{
    public class CustomMethodDescriptor(string declaringType, string methodName, string[] parameterTypeNames, DescriptorBase[] args) : DescriptorBase
    {
        public string DeclaringType { get; set; } = declaringType;
        public string MethodName { get; set; } = methodName;
        public string[] ParameterTypeNames { get; set; } = parameterTypeNames;
        public DescriptorBase[] Args { get; set; } = args;
    }
}