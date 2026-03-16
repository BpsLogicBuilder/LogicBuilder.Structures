using LogicBuilder.Expressions.Utils.ExpressionDescriptors;
using LogicBuilder.Structures.Tests.Helpers;
using System.Text.Json;

namespace LogicBuilder.Structures.Tests.ExpressionDescriptors
{
    public class ToUpperDescriptorTest
    {
        private static readonly string parameterName = "$it";

        [Fact]
        public void CanSerializeAndDeserialize_ToUpperDescriptor()
        {
            // Arrange
            var descriptor = new ToUpperDescriptor
            (
                new MemberSelectorDescriptor("Name", new ParameterDescriptor(parameterName))
            );

            // Act
            string json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<ToUpperDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.IsType<MemberSelectorDescriptor>(deserializedDescriptor.Operand);
            Assert.Equal("Name", ((MemberSelectorDescriptor)deserializedDescriptor.Operand).MemberFullName);
        }
    }
}
