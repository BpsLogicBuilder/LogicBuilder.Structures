using System.Collections.Generic;
using System;

namespace LogicBuilder.Expressions.Utils.ExpressionDescriptors
{
    public class MemberInitDescriptor(IDictionary<string, DescriptorBase> memberBindings, string? newType) : DescriptorBase
    {
        public IDictionary<string, DescriptorBase> MemberBindings { get; set; } = memberBindings;
        public string? NewType { get; set; } = newType;
    }
}