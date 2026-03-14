using LogicBuilder.Expressions.Utils.ExpressionDescriptors;
using LogicBuilder.Structures.Tests.Helpers;
using System.Text.Json;

namespace LogicBuilder.Structures.Tests.ExpressionDescriptors
{
    public class ConvertToNumericDateDescriptorTest
    {
        private static readonly string parameterName = "$it";

        [Fact]
        public void CanSerializeAndDeserialize_ConvertToNumericDateDescriptor()
        {
            // Arrange
            var descriptor = new ConvertToNumericDateDescriptor
            (
                new MemberSelectorDescriptor("CreatedDate", new ParameterDescriptor(parameterName))
            );

            // Act
            string json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<ConvertToNumericDateDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.IsType<MemberSelectorDescriptor>(deserializedDescriptor.SourceOperand);
            Assert.Equal("CreatedDate", ((MemberSelectorDescriptor)deserializedDescriptor.SourceOperand).MemberFullName);
        }
    }
}
