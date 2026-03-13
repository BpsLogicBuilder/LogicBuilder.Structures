using System.Reflection;

namespace LogicBuilder.Expressions.Utils.ExpressionDescriptors
{
    public class CustomMethodDescriptor(MethodInfo methodInfo, DescriptorBase[] args) : DescriptorBase
    {
        public MethodInfo MethodInfo { get; set; } = methodInfo;
        public DescriptorBase[] Args { get; set; } = args;
    }
}