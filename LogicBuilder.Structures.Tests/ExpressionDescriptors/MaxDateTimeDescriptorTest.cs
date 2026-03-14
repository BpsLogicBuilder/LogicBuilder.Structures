using LogicBuilder.Expressions.Utils.ExpressionDescriptors;
using LogicBuilder.Structures.Tests.Helpers;
using System.Text.Json;

namespace LogicBuilder.Structures.Tests.ExpressionDescriptors
{
    public class MaxDateTimeDescriptorTest
    {
        [Fact]
        public void CanSerializeAndDeserialize_MaxDateTimeDescriptor()
        {
            // Arrange
            var descriptor = new MaxDateTimeDescriptor();

            // Act
            string json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<MaxDateTimeDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
        }
    }
}
