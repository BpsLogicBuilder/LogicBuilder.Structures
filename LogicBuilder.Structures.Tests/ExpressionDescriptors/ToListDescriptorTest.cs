using LogicBuilder.Expressions.Utils.ExpressionDescriptors;
using LogicBuilder.Structures.Tests.Helpers;
using System.Text.Json;

namespace LogicBuilder.Structures.Tests.ExpressionDescriptors
{
    public class ToListDescriptorTest
    {
        [Fact]
        public void CanSerializeAndDeserialize_ToListDescriptor()
        {
            // Arrange
            var descriptor = new ToListDescriptor
            (
                new ParameterDescriptor("source")
            );

            // Act
            string json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<ToListDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.IsType<ParameterDescriptor>(deserializedDescriptor.SourceOperand);
            Assert.Equal("source", ((ParameterDescriptor)deserializedDescriptor.SourceOperand).ParameterName);
        }
    }
}
