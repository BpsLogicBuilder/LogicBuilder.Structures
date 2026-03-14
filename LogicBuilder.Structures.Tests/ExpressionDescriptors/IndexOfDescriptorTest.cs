using LogicBuilder.Expressions.Utils.ExpressionDescriptors;
using LogicBuilder.Structures.Tests.Helpers;
using System.Text.Json;

namespace LogicBuilder.Structures.Tests.ExpressionDescriptors
{
    public class IndexOfDescriptorTest
    {
        private static readonly string parameterName = "$it";

        [Fact]
        public void CanSerializeAndDeserialize_IndexOfDescriptor()
        {
            // Arrange
            var descriptor = new IndexOfDescriptor
            (
                new MemberSelectorDescriptor("Text", new ParameterDescriptor(parameterName)),
                new ConstantDescriptor("test", typeof(string).AssemblyQualifiedName)
            );

            // Act
            string json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<IndexOfDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.IsType<MemberSelectorDescriptor>(deserializedDescriptor.SourceOperand);
            Assert.IsType<ConstantDescriptor>(deserializedDescriptor.ItemToFind);
            Assert.Equal("Text", ((MemberSelectorDescriptor)deserializedDescriptor.SourceOperand).MemberFullName);
            Assert.Equal("test", ((ConstantDescriptor)deserializedDescriptor.ItemToFind).ConstantValue);
        }
    }
}
