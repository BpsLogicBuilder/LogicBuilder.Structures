using LogicBuilder.Expressions.Utils.ExpressionDescriptors;
using LogicBuilder.Structures.Tests.Helpers;
using System.Text.Json;

namespace LogicBuilder.Structures.Tests.ExpressionDescriptors
{
    public class ConvertToNullableUnderlyingValueDescriptorTest
    {
        private static readonly string parameterName = "$it";

        [Fact]
        public void CanSerializeAndDeserialize_ConvertToNullableUnderlyingValueDescriptor()
        {
            // Arrange
            var descriptor = new ConvertToNullableUnderlyingValueDescriptor
            (
                new MemberSelectorDescriptor("NullableValue", new ParameterDescriptor(parameterName))
            );

            // Act
            string json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<ConvertToNullableUnderlyingValueDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.IsType<MemberSelectorDescriptor>(deserializedDescriptor.SourceOperand);
            Assert.Equal("NullableValue", ((MemberSelectorDescriptor)deserializedDescriptor.SourceOperand).MemberFullName);
        }
    }
}
