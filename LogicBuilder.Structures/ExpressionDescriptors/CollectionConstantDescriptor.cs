using System.Collections.Generic;
using System;

namespace LogicBuilder.Expressions.Utils.ExpressionDescriptors
{
    public class CollectionConstantDescriptor(ICollection<object> constantValues, string elementType) : DescriptorBase
    {
        public string ElementType { get; set; } = elementType;
        public ICollection<object> ConstantValues { get; set; } = constantValues;
    }
}