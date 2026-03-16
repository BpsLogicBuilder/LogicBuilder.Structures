using LogicBuilder.Expressions.Utils.ExpressionDescriptors;
using LogicBuilder.Structures.Tests.Helpers;
using System.Text.Json;

namespace LogicBuilder.Structures.Tests.ExpressionDescriptors
{
    public class SubstringDescriptorTest
    {
        private static readonly string parameterName = "$it";

        [Fact]
        public void CanSerializeAndDeserialize_SubstringDescriptor()
        {
            // Arrange
            var descriptor = new SubstringDescriptor
            (
                new MemberSelectorDescriptor("Text", new ParameterDescriptor(parameterName)),
                new ConstantDescriptor(0, typeof(int).AssemblyQualifiedName),
                new ConstantDescriptor(5, typeof(int).AssemblyQualifiedName)
            );

            // Act
            string json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<SubstringDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.IsType<MemberSelectorDescriptor>(deserializedDescriptor.SourceOperand);
            Assert.Equal(2, deserializedDescriptor.Indexes.Length);
            Assert.Equal("Text", ((MemberSelectorDescriptor)deserializedDescriptor.SourceOperand).MemberFullName);
        }
    }
}
