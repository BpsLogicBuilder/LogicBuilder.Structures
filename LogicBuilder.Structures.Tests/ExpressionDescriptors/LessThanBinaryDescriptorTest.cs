using LogicBuilder.Expressions.Utils.ExpressionDescriptors;
using LogicBuilder.Structures.Tests.Helpers;
using System.Text.Json;

namespace LogicBuilder.Structures.Tests.ExpressionDescriptors
{
    public class LessThanBinaryDescriptorTest
    {
        private static readonly string parameterName = "$it";

        [Fact]
        public void CanSerializeAndDeserialize_LessThanBinaryDescriptor()
        {
            // Arrange
            var descriptor = new LessThanBinaryDescriptor
            (
                new MemberSelectorDescriptor("Price", new ParameterDescriptor(parameterName)),
                new ConstantDescriptor(100.0m, typeof(decimal).AssemblyQualifiedName)
            );

            // Act
            string json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<LessThanBinaryDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.IsType<MemberSelectorDescriptor>(deserializedDescriptor.Left);
            Assert.IsType<ConstantDescriptor>(deserializedDescriptor.Right);
            Assert.Equal("Price", ((MemberSelectorDescriptor)deserializedDescriptor.Left).MemberFullName);
            Assert.Equal(100.0m, (decimal)((ConstantDescriptor)deserializedDescriptor.Right).ConstantValue);
        }
    }
}
