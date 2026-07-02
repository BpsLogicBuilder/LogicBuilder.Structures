using System.Collections.Generic;

namespace LogicBuilder.Expressions.Utils.ExpressionDescriptors
{
    public class CollectionConstantDescriptor(ICollection<object?> constantValues, string elementType) : DescriptorBase
    {
        public string ElementType { get; } = elementType;
        public ICollection<object?> ConstantValues { get; } = constantValues;
    }
}