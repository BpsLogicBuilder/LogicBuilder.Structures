using System.Collections.Generic;

namespace LogicBuilder.Expressions.Utils.ExpressionDescriptors
{
    public class MemberInitDescriptor(IDictionary<string, DescriptorBase> memberBindings, string? newType = null) : DescriptorBase
    {
        public IDictionary<string, DescriptorBase> MemberBindings { get; set; } = memberBindings;
        public string? NewType { get; set; } = newType;
    }
}