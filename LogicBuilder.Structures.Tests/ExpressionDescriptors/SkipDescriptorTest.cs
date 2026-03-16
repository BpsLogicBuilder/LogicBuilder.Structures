using LogicBuilder.Expressions.Utils.ExpressionDescriptors;
using LogicBuilder.Structures.Tests.Helpers;
using System.Text.Json;

namespace LogicBuilder.Structures.Tests.ExpressionDescriptors
{
    public class SkipDescriptorTest
    {
        [Fact]
        public void CanSerializeAndDeserialize_SkipDescriptor()
        {
            // Arrange
            var descriptor = new SkipDescriptor
            (
                new ParameterDescriptor("source"),
                5
            );

            // Act
            string json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<SkipDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.IsType<ParameterDescriptor>(deserializedDescriptor.SourceOperand);
            Assert.Equal(5, deserializedDescriptor.Count);
        }
    }
}
