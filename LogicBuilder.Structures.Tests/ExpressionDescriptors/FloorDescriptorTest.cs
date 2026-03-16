using LogicBuilder.Expressions.Utils.ExpressionDescriptors;
using LogicBuilder.Structures.Tests.Helpers;
using System.Text.Json;

namespace LogicBuilder.Structures.Tests.ExpressionDescriptors
{
    public class FloorDescriptorTest
    {
        private static readonly string parameterName = "$it";

        [Fact]
        public void CanSerializeAndDeserialize_FloorDescriptor()
        {
            // Arrange
            var descriptor = new FloorDescriptor
            (
                new MemberSelectorDescriptor("Price", new ParameterDescriptor(parameterName))
            );

            // Act
            string json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<FloorDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.IsType<MemberSelectorDescriptor>(deserializedDescriptor.Operand);
            Assert.Equal("Price", ((MemberSelectorDescriptor)deserializedDescriptor.Operand).MemberFullName);
        }
    }
}
