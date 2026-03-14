using LogicBuilder.Expressions.Utils.ExpressionDescriptors;
using LogicBuilder.Structures.Tests.Helpers;
using System.Text.Json;

namespace LogicBuilder.Structures.Tests.ExpressionDescriptors
{
    public class DistinctDescriptorTest
    {
        [Fact]
        public void CanSerializeAndDeserialize_DistinctDescriptor()
        {
            // Arrange
            var descriptor = new DistinctDescriptor
            (
                new ParameterDescriptor("source")
            );

            // Act
            string json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<DistinctDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.IsType<ParameterDescriptor>(deserializedDescriptor.SourceOperand);
            Assert.Equal("source", ((ParameterDescriptor)deserializedDescriptor.SourceOperand).ParameterName);
        }
    }
}
