using System.Collections.Generic;

namespace LogicBuilder.Expressions.Utils.ExpressionDescriptors
{
    public class MemberInitDescriptor(IDictionary<string, DescriptorBase> memberBindings, string? newType = null) : DescriptorBase
    {
        public IDictionary<string, DescriptorBase> MemberBindings { get; } = memberBindings;
        public string? NewType { get; } = newType;
    }
}