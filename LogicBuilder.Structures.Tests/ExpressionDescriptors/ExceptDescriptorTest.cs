using LogicBuilder.Expressions.Utils.ExpressionDescriptors;
using LogicBuilder.Structures.Tests.Helpers;
using System.Text.Json;

namespace LogicBuilder.Structures.Tests.ExpressionDescriptors
{
    public class ExceptDescriptorTest
    {
        [Fact]
        public void CanSerializeAndDeserialize_ExceptDescriptor()
        {
            // Arrange
            var descriptor = new ExceptDescriptor
            (
                new ParameterDescriptor("source1"),
                new ParameterDescriptor("source2")
            );

            // Act
            string json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<ExceptDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.IsType<ParameterDescriptor>(deserializedDescriptor.Left);
            Assert.IsType<ParameterDescriptor>(deserializedDescriptor.Right);
            Assert.Equal("source1", ((ParameterDescriptor)deserializedDescriptor.Left).ParameterName);
            Assert.Equal("source2", ((ParameterDescriptor)deserializedDescriptor.Right).ParameterName);
        }
    }
}
