using LogicBuilder.Expressions.Utils.ExpressionDescriptors;
using LogicBuilder.Structures.Tests.Helpers;
using System.Text.Json;

namespace LogicBuilder.Structures.Tests.ExpressionDescriptors
{
    public class ParameterDescriptorTest
    {
        [Fact]
        public void CanSerializeAndDeserialize_ParameterDescriptor()
        {
            // Arrange
            var descriptor = new ParameterDescriptor("$it");

            // Act
            string json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<ParameterDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.Equal("$it", deserializedDescriptor.ParameterName);
        }
    }
}
