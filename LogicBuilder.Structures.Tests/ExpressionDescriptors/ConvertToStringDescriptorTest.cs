using LogicBuilder.Expressions.Utils.ExpressionDescriptors;
using LogicBuilder.Structures.Tests.Helpers;
using System.Text.Json;

namespace LogicBuilder.Structures.Tests.ExpressionDescriptors
{
    public class ConvertToStringDescriptorTest
    {
        private static readonly string parameterName = "$it";

        [Fact]
        public void CanSerializeAndDeserialize_ConvertToStringDescriptor()
        {
            // Arrange
            var descriptor = new ConvertToStringDescriptor
            (
                new MemberSelectorDescriptor("Id", new ParameterDescriptor(parameterName))
            );

            // Act
            string json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<ConvertToStringDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.IsType<MemberSelectorDescriptor>(deserializedDescriptor.SourceOperand);
            Assert.Equal("Id", ((MemberSelectorDescriptor)deserializedDescriptor.SourceOperand).MemberFullName);
        }
    }
}
